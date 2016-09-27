using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Business.EDNFramework_SYS;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
namespace DotNet.Framework.Admin.Pages.Account.User
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (Business_User.Add(entity) <= 0)
            {
                throw new BusinessException("添加失败");
            }
            Response.Write("{}");
            Response.End();
        }
    }
}