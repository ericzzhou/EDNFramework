using DotNet.Framework.Admin.Business.EDNFramework_Repairs;
using DotNet.Framework.Admin.Core.Business;
using DotNet.Framework.Admin.Entity.EDNFramework_Repairs;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
namespace DotNet.Framework.Admin.UI.Ajax.Repairs
{
    /// <summary>
    /// Order 的摘要说明
    /// </summary>
    public class Order : IHttpHandler
    {

        string permissionCode = "repairs_order_index";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ajax = context.Request.QueryString["ajax"];
            switch (ajax.ToLower())
            {
                case "getpagerdata":
                    GetPagerData(context);
                    break;
                case "delete":
                    Delete(context);
                    break;
                case "assignedtos":
                    GetAssignedTos(context);
                    break;
                case "changeorderstatus":
                    ChangeOrderStatus(context);
                    break;
                case "update":
                //    Update(context);
                //    break;
                //case "getpermissionnames":
                //    GetPermissionNames(context);
                //    break;
                default:
                    break;
            }
        }

        private void ChangeOrderStatus(HttpContext context)
        {
            CheckPermission.CheckRight(permissionCode, "btn_AssignedTo");
            int userid = context.Request["userid"].ToInt();
            int orderid = context.Request["orderid"].ToInt();
            int status = context.Request["status"].ToInt();
            string makedate = context.Request["makedate"];
            string maketime = context.Request["maketime"];
            if (userid <= 0)
            {
                throw new BusinessException("请选择处理人");
            }
            if (!Business_Repairs.ChangeOrderStatus(orderid, userid, status))
            {
                throw new BusinessException("订单状态变更失败");
            }
            else
            {
                try
                {
                    Entity_Order_Notify notify = Business_Repairs.GetOrderNotify(orderid);
                    //【鑫奕科技】尊敬的{@姓名}您好,您的{@单号}订单已经确认，我们将安排指定工程师{@工程师}上门服务，预约上门时间为{@预约日期}{@预约时间}，请在此时间家里留人，谢谢!
                    string sms = Business_ConfigContent.GetValueByKey("sms_assignedordernotify")
                        .Replace("{@姓名}", notify.ContactsName)
                        .Replace("{@单号}", notify.OrderNumber)
                        .Replace("{@工程师}", notify.masterName)
                        .Replace("{@预约日期}", makedate)
                        .Replace("{@预约时间}", maketime);

                    //sms_assignedorder【鑫奕科技】新任务提醒:{@工程师},公司安排您上门服务该客户:订单号{@单号}姓名{@姓名}{@性别}电话：{@手机}地址：{@城市}{@地址}费用：{@费用}
                    string sms_master = Business_ConfigContent.GetValueByKey("sms_assignedorder")
                       .Replace("{@姓名}", notify.ContactsName)
                       .Replace("{@单号}", notify.OrderNumber)
                       .Replace("{@工程师}", notify.masterName)
                       .Replace("{@预约日期}", makedate)
                       .Replace("{@手机}", notify.ContactsMobile)
                       .Replace("{@地址}", notify.ContactsAddress)
                       .Replace("{@城市}", "")
                       .Replace("{@费用}", "面议")
                       .Replace("{@预约时间}", maketime);
                    //OnlineRepairs.Library.ORBusiness.SendSMS(notify.ContactsMobile, sms);
                    OnlineRepairs.Library.ORBusiness.SendSMSList(
                        new List<string>(){
                            notify.ContactsMobile,
                            notify.masterPhone
                        },
                        new List<string>(){
                            sms,
                            sms_master
                        }
                    );
                }
                catch { }
            }
        }

        private void GetAssignedTos(HttpContext context)
        {
            CheckPermission.CheckRight(permissionCode, "btn_AssignedTo");
            var Entities = Business_Repairs.GetAssignedTos();
            var json = ObjectJsonSerializer.Serialize<IList<Entity_GetAssignedTo>>(Entities);
            context.Response.Write(json);
        }

        private void Delete(HttpContext context)
        {
            CheckPermission.CheckRight(permissionCode, "btn_delete");
            int id = context.Request["ID"].ToInt();
            int userID = BusEntity_LoginUser.Sys_LoginUser.UserID;
            string userName = BusEntity_LoginUser.Sys_LoginUser.UserName;
            if (!Business_Repairs.DeleteOrder(id, userID, userName))
            {
                throw new BusinessException("删除失败");
            }
        }

        private void GetPagerData(HttpContext context)
        {
            ViewQueryCondition<Entity_Order_List>
  query =
     ObjectJsonSerializer.Json2EntityFromAjaxRequest<ViewQueryCondition<Entity_Order_List>>(context.Request);

            PagingResult<IList<Entity_Order_List>> result = Business_Repairs.GetOrderListByPager(query);
            context.Response.Write(result.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}