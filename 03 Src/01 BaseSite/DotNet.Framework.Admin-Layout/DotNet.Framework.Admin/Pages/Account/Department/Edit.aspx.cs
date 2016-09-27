using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.Department
{
    public partial class Edit : System.Web.UI.Page
    {
        public string Json_Model = "{}";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_Department_Index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "edit":
                    EditData();
                    break;
            }

            var id = Request["id"];
            if (id.IsInt())
            {
                GetModel(id.ToInt());
            }
        }

        private void EditData()
        {
            Entity_Department entity =
                ObjectJsonSerializer
                .Json2EntityFromAjaxRequest<Entity_Department>(Request);

            if (entity.Name.IsNull())
            {
                throw new BusinessException("请输入部门名称");
            }
            if (Business_Department.GetDepartmentCountByName(entity.Name,entity.ID) > 0)
            {
                throw new BusinessException(string.Format("请部门名称[{0}]已存在，不能重复输入", entity.Name));
            }
            if (Business_Department.Edit(entity) <= 0)
            {
                throw new BusinessException("编辑部门信息失败，请重试");
            }
            Response.Write("{}");
            Response.End();
        }

        private void GetModel(int id)
        {
            Entity_Department dep = Business_Department.GetModel(id) ?? new Entity_Department();
            Json_Model = ObjectJsonSerializer.Serialize<Entity_Department>(dep);
        }
    }
}