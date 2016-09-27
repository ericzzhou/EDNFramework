using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Core.Business;
namespace DotNet.Framework.Admin.Pages.Account.User
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPermission.CheckRight("Account_User_Index");
            var ajax = Request.QueryString["ajax"];
            switch (ajax)
            {
                case "adddata":
                    AddModel();
                    break;

                default:
                    break;
            }
        }


        private void AddModel()
        {
            Entity_User entity = new Entity_User();
            entity.Activity = Request["Activity"].ToBoolean();
            entity.Email = Request["Email"];
            entity.NickName = Request["NickName"];
            entity.Password = Utils.Safety.DESEncrypt.EncryptPassword(Business_ConfigContent.GetValueByKey(Core.Config.SysConfig.Default_Password));
            entity.Phone = Request["Phone"];
            entity.Sex = Request["Sex"];
            entity.UserName = Request["UserName"];
            entity.UserType = Request["UserType"];

            if (string.IsNullOrWhiteSpace(entity.UserType))
            {
                throw new BusinessException("请选择账号类型");
            }

            if (string.IsNullOrWhiteSpace(entity.Sex))
            {
                throw new BusinessException("请选择性别");
            }

            int defaultRole = Convert.ToInt32(DotNet.Framework.Admin.Business.EDNFramework_SYS.Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.Default_UserRoleID));
            if (Business_User.Add(entity, defaultRole) <= 0)
            {
                throw new BusinessException("添加失败");
            }
            Response.Write("{}");
            Response.End();
        }
    }
}