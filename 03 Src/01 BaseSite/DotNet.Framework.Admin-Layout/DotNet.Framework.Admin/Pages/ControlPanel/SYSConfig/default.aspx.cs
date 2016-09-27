using System;
using System.Collections.Generic;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_SYS;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Utils.Serialization;
using System.Linq;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.ControlPanel.SYSConfig
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            var ajax = Request.QueryString["ajax"];
            if (string.IsNullOrWhiteSpace(ajax))
            {
                CheckPermission.CheckRight("controlpanel_sysConfig_default");
            }
            switch (ajax)
            {
                case "getPagerData":
                    GetPagerData();
                    break;
                case "getmodel":
                    GetModel();
                    break;
                case "editdata":
                    UpdateData();
                    break;
                case "adddata":
                    InsertData();
                    break;
                case "deletemodel":
                    Delete();
                    break;
                //default:
                //    break;
            }

        }
        
        private void GetPagerData()
        {
            int pageindex = Request["pageindex"].ToInt();
            int pagesize = Request["pagesize"].ToInt();
            string orderField = Request["orderField"];
            string dir = Request["sortDir"];

            int totolCount = 0;
            IList<Entity_ConfigContent> pageResult = Business_ConfigContent.GetListByPager(pageindex, pagesize, orderField, dir, out totolCount);

            var json = ObjectJsonSerializer.Serialize_NewTon<IList<Entity_ConfigContent>>(pageResult.ToArray());
            Response.Write("{\"totalRecords\": " + totolCount + ", \"curPage\": " + pageindex + ",\"data\":" + json + " }");
            Response.End();

        }

        private void InsertData()
        {
            string Keyname = Request["Keyname"];
            string Value = Request["Value"];
            string Description = Request["Description"];

            if (string.IsNullOrWhiteSpace(Keyname))
            {
                throw new BusinessException("Keyname 不能为空");
            }

            Entity_ConfigContent entity = new Entity_ConfigContent();
            entity.Value = Value;
            entity.Description = Description;
            entity.Keyname = Keyname;
            // 0:默认用户自己添加，可任意维护
            //-2:系统保留，不可见，不可维护
            //-1:系统保留，可见，可改，不可删
            entity.KeyType = 0;

            if (Business_ConfigContent.AddModel(entity) <= 0)
            {
                throw new BusinessException("添加失败");
            }

            Response.End();
        }

        private void UpdateData()
        {
            int id = Request["id"].ToInt();
            string Value = Request["Value"];
            string Description = Request["Description"];
            string Keyname = Request["Keyname"];

            if (string.IsNullOrWhiteSpace(Keyname))
            {
                throw new BusinessException("Keyname 不能为空");
            }
            Entity_ConfigContent entity = new Entity_ConfigContent();
            entity.ID = id;
            entity.Value = Value;
            entity.Description = Description;
            entity.Keyname = Keyname;

            if (!Business_ConfigContent.UpdateModel(entity))
            {
                throw new BusinessException("更新失败");
            }
            Response.End();
        }

        private void GetModel()
        {
            int id = Request["id"].ToInt();
            var entity = Business_ConfigContent.GetModel(id);
            var json = DotNet.Framework.Utils.Serialization.ObjectJsonSerializer.Serialize<Entity_ConfigContent>(entity);
            Response.Write(json);
            Response.End();
        }

        private void Delete()
        {
            int ID = Request["ID"].ToInt();

            if (!Business_ConfigContent.Delete(ID))
            {
                throw new BusinessException("删除失败");
            }


            Response.Write("{}");
            Response.End();
        }
    }
}