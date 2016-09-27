using DotNet.Framework.Admin.Business.EDNFramework_Repairs;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Entity.EDNFramework_Repairs;
using OnlineRepairs.Web.Filters;
using OnlineRepairs.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRepairs.Web.Controllers
{
    [InitializeMembership]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Index()
        {

            return View(Business_Repairs.GetBrands() ?? new List<Entity_Brand>());
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(OrderModel model)
        {
            var ret = new JsonReturnValue { status = 0, message = "下单失败" };
            if (model.ComputyBrand <= 0)
            {
                ret.message = "请选择电脑品牌";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(model.ComputyModel))
            {
                ret.message = "请输入电脑型号";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(model.ContactsAddress))
            {
                ret.message = "请输入维修地址";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(model.ContactsMobile))
            {
                ret.message = "请输入联系电话";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(model.ContactsName))
            {
                ret.message = "请输入联系人";
                return Json(ret);
            }
            if (string.IsNullOrWhiteSpace(model.RepairsDescription))
            {
                ret.message = "故障描述不能为空";
                return Json(ret);
            }

            int userID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            string orderNo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            Entity_Order order = new Entity_Order()
            {
                AssignedTo = 0,
                AssignedToUser = "",
                BrandID = model.ComputyBrand,
                ComputerType = model.ComputerType,
                Model = model.ComputyModel,
                RepairsDescription = model.RepairsDescription,
                Statu = 0,
                UserID = userID,
                OrderNumber = orderNo
            };

            Entity_Order_ContactsAddress contact = new Entity_Order_ContactsAddress()
            {
                ContactsAddress = model.ContactsAddress,
                ContactsMobile = model.ContactsMobile,
                ContactsName = model.ContactsName,
                UserID = userID
            };

            int orderId = Business_Repairs.SaveUserOrder(order, contact);
            if (orderId > 0)
            {
                ret = new JsonReturnValue()
                {
                    message = orderNo,
                    status = 1
                };

                SendSMS(orderNo, contact);
            }
            else
            {
                ret.message = "下单失败，请重试。";
            }

            return Json(ret);
        }

        private static void SendSMS(string orderNo, Entity_Order_ContactsAddress contact)
        {
            try
            {
                //【鑫奕科技】系统新订单通知！订单号:{@单号}  姓名{@姓名}  电话：{@手机} 地址：{@地址}  所在城市：{@城市}  费用:{@费用}
                string sms_neworder = Business_ConfigContent.GetValueByKey("sms_neworder")
                    .Replace("{@单号}", orderNo)
                    .Replace("{@姓名}", contact.ContactsName)
                    .Replace("{@手机}", contact.ContactsMobile)
                    .Replace("{@地址}", contact.ContactsAddress)
                    .Replace("{@费用}", "面议");

                string[] adminsPhones = ConfigurationManager.AppSettings["SMS_Admin"].Split(',');

                //【鑫奕科技】尊敬的客户您好，您的订单已经受理，我们将尽快和你取得联系确认该订单，请保持手机畅通，您的订单号为：{@单号},可通过网站查询订单状态和评价服务质量。
                string sms_createorder = Business_ConfigContent.GetValueByKey("sms_createorder")
                    .Replace("{@单号}", orderNo);
                List<string> phone = new List<string>();
                foreach (var item in adminsPhones)
                {
                    phone.Add(item);
                }
                phone.Add(contact.ContactsMobile);

                List<string> msg = new List<string>();
                foreach (var item in adminsPhones)
                {
                    msg.Add(sms_neworder);
                }
                msg.Add(sms_createorder);
                OnlineRepairs.Library.ORBusiness.SendSMSList(phone, msg);
            }
            catch { }
        }

        public ActionResult Success(string id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        /// <summary>
        /// 订单明细（进度）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            ViewBag.OrderId = id;
            ViewBag.OrderInfo = Business_Repairs.GetOrderInfo(id) ?? new Entity_Order();
            return View(Business_Repairs.GetOrderHistory(id) ?? new List<Entity_Order_History>());
        }

        [HttpPost]
        public JsonResult SetOrderCompleted(string remark, int id = 0, int status = 4)
        {
            var ret = new JsonReturnValue { status = 0, message = "内部异常，请联系管理员" };

            if (id <= 0)
            {
                ret.message = "订单编号获取失败，请刷新重试。";
                return Json(ret);
            }
            int userID = BusEntity_LoginUser.Sys_LoginUser.UserID;
            if (Business_Repairs.ChangeOrderStatus(id, userID, status, remark))
            {
                ret.status = 1;
                try
                {
                    Entity_Order_Notify notify = Business_Repairs.GetOrderNotify(id);
                    //【鑫奕科技】尊敬的{@姓名}，您的{@单号}订单已经完成，我们已将您的联系方式存入用户数据库，同时请您保存报修中心热线4008-743-095[仅能拨打报修中心热线尊享售后服务]感谢您的信任与支持，祝您生活愉快！另添加微信服务号x1kj_cn[或QQ:743095老客户专享电脑故障在线答疑及紧急救援服务。
                    string sms = Business_ConfigContent.GetValueByKey("sms_ordercompleted")
                        .Replace("{@姓名}", notify.ContactsName)
                        .Replace("{@单号}", notify.OrderNumber);
                    OnlineRepairs.Library.ORBusiness.SendSMS(notify.ContactsMobile, sms);
                }
                catch { }
            }
            else
            {
                ret.status = 0;
                ret.message = "订单状态更新失败";
            }

            return Json(ret);
        }

        public ActionResult MyOrder()
        {
            int userID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            return View(Business_Repairs.GetUserOrders(userID) ?? new List<Entity_UserOrder>());
        }
    }
}
