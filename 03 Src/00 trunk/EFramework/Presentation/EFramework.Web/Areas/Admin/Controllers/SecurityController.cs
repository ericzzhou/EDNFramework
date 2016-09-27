using EFramework.Core;
using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.Account;
using EFramework.Entities.Domain.Account.ViewQueryCondition;
using EFramework.Entities.Domain.ControlPanel.ViewQueryCondition;
using EFramework.Services;
using EFramework.Web.Framework.Controllers;
using EFramework.Web.Framework.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace EFramework.Web.Areas.Admin.Controllers
{
    public class SecurityController : BaseAdminController
    {
        //
        // GET: /Admin/Security/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Permission()
        {
            return View();
        }

        public ActionResult Roles(int pageIndex = 1)
        {
            ViewQueryCondition<object> condition = new ViewQueryCondition<object>();
            condition.Condition = new ConfigSearchCondition();

            condition.PagingInfo = new ViewPagingInfo()
            {
                OrderField = "RoleID",
                PageSize = 10,
                PageIndex = pageIndex
            };
            PagingResult<List<EDNF_Account_RoleEntity>> query = AccountService.GetAccountRolesByPager(condition);

            PagedList<EDNF_Account_RoleEntity> result =
               new PagedList<EDNF_Account_RoleEntity>(query.Result, query.PagingInfo.PageIndex, query.PagingInfo.PageSize, query.TotalCount);

            if (Request.IsAjaxRequest())
                return PartialView("_AjaxRolesPartial", result);
            else
                return View(result);
        }

        public ActionResult Users(int roleId = 0, string UserName = "", int pageIndex = 1)
        {
            ViewBag.RoleID = roleId;
            ViewBag.UserName = UserName;

            ViewQueryCondition<UsersSearchCondition> condition = new ViewQueryCondition<UsersSearchCondition>();
            condition.Condition = new UsersSearchCondition()
            {
                roleId = roleId,
                UserName = UserName
            };
            condition.PagingInfo = new ViewPagingInfo()
            {
                OrderField = "UserID",
                PageSize = 10,
                PageIndex = pageIndex
            };
            PagingResult<List<EF_Account_UserInfoEntity>> query = AccountService.GetUsersByPager(condition);

            PagedList<EF_Account_UserInfoEntity> result =
               new PagedList<EF_Account_UserInfoEntity>(query.Result, query.PagingInfo.PageIndex, query.PagingInfo.PageSize, query.TotalCount);

            if (Request.IsAjaxRequest())
                return PartialView("_AjaxUsersPartial", result);
            else
                return View(result);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult RoleUserDelete(int id = 0, int uid = 0)
        {
            return Json(new { status = -1, message = string.Format("功能未实现。rid={0};uid={1}", id, uid) });
        }

        public ActionResult RoleUsers(int roleId = 0, string UserName = "", int pageIndex = 1)
        {
            ViewBag.RoleID = roleId;
            ViewBag.UserName = UserName;

            ViewQueryCondition<RoleUsersSearchCondition> condition = new ViewQueryCondition<RoleUsersSearchCondition>();
            condition.Condition = new RoleUsersSearchCondition()
            {
                roleId = roleId,
                UserName = UserName
            };
            condition.PagingInfo = new ViewPagingInfo()
            {
                OrderField = "UserID",
                PageSize = 10,
                PageIndex = pageIndex
            };
            PagingResult<List<EF_Account_RoleUsersEntity>> query = AccountService.GetRoleUsersByPager(condition);

            PagedList<EF_Account_RoleUsersEntity> result =
               new PagedList<EF_Account_RoleUsersEntity>(query.Result, query.PagingInfo.PageIndex, query.PagingInfo.PageSize, query.TotalCount);

            if (Request.IsAjaxRequest())
                return PartialView("_AjaxRoleUsersPartial", result);
            else
                return View(result);
        }

        public ActionResult AddAccountRole()
        {
            return View(new EDNF_Account_RoleEntity());
        }

        [ValidatePermission("aaa", "bbb")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddAccountRole(EDNF_Account_RoleEntity entity)
        {
            return Json(new { status = -1, message = "功能未实现." });
        }

        public ActionResult EditAccountRole(int id = 0)
        {
            EDNF_Account_RoleEntity entity = AccountService.GetRoleInfo(id);
            return View(entity);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditAccountRole(EDNF_Account_RoleEntity entity)
        {
            return Json(new { status = -1, message = "修改功能未实现." });
        }



        [ValidateInput(false)]
        [HttpPost]
        public ActionResult DeleteUserFromRole(int userId, int ruleId)
        {
            return Json(new { status = -1, message = "修改功能未实现." });
        }



        public ActionResult AddAccountUsers()
        {
            return View();
        }


        public ActionResult EditUser(int id = 0)
        {
            EF_Account_UserEntity enttiy = new EF_Account_UserEntity();
            return View(enttiy);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult EditUser(EF_Account_UserEntity entity)
        {
            throw new BusinessException("我擦");
            return Json(new { status = -1, message = "功能未实行" });
        }
    }
}
