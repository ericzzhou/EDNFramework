using EFramework.Utils.Helper;
using EFramework.Web.Framework.WorkContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace EFramework.Web.Framework.Controllers
{
    public class BaseWebController : Controller
    {
        //工作上下午
        public WebWorkContext WorkContext = new WebWorkContext();

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            WorkContext.SEOKeyword = "SEOKeyword";
            WorkContext.SEODescription = "SEODescription";
            WorkContext.SiteTitle = "网站名称";
            WorkContext.IsHttpAjax = WebHelper.IsAjax();
            WorkContext.IP = WebHelper.GetIP();
            WorkContext.Url = WebHelper.GetUrl();
            WorkContext.UrlReferrer = WebHelper.GetUrlReferrer();

            ////获得用户唯一标示符sid
            //WorkContext.Sid = ShopUtils.GetSidCookie();
            //if (WorkContext.Sid.Length == 0)
            //{
            //    //生成sid
            //    WorkContext.Sid = Sessions.GenerateSid();
            //    //将sid保存到cookie中
            //    ShopUtils.SetSidCookie(WorkContext.Sid);
            //}

            //PartUserInfo partUserInfo;

            ////获得用户id
            //int uid = ShopUtils.GetUidCookie();
            //if (uid < 1)//当用户为游客时
            //{
            //    //创建游客
            //    partUserInfo = Users.CreatePartGuest();
            //}
            //else//当用户为会员时
            //{
            //    //获得保存在cookie中的密码
            //    string encryptPwd = ShopUtils.GetCookiePassword();
            //    //防止用户密码被篡改为危险字符
            //    if (encryptPwd.Length == 0 || !SecureHelper.IsBase64String(encryptPwd))
            //    {
            //        //创建游客
            //        partUserInfo = Users.CreatePartGuest();
            //        encryptPwd = string.Empty;
            //        ShopUtils.SetUidCookie(-1);
            //        ShopUtils.SetCookiePassword("");
            //    }
            //    else
            //    {
            //        partUserInfo = Users.GetPartUserByUidAndPwd(uid, ShopUtils.DecryptCookiePassword(encryptPwd));
            //        if (partUserInfo != null)
            //        {
            //            //发放登陆积分
            //            Credits.SendLoginCredits(ref partUserInfo, DateTime.Now);
            //        }
            //        else//当会员的账号或密码不正确时，将用户置为游客
            //        {
            //            partUserInfo = Users.CreatePartGuest();
            //            encryptPwd = string.Empty;
            //            ShopUtils.SetUidCookie(-1);
            //            ShopUtils.SetCookiePassword("");
            //        }
            //    }
            //    WorkContext.EncryptPwd = encryptPwd;
            //}

            //设置用户等级
            //if (UserRanks.IsBanUserRank(partUserInfo.UserRid) && partUserInfo.LiftBanTime <= DateTime.Now)
            //{
            //    UserRankInfo userRankInfo = UserRanks.GetUserRankByCredits(partUserInfo.PayCredits);
            //    Users.UpdateUserRankByUid(partUserInfo.Uid, userRankInfo.UserRid);
            //    partUserInfo.UserRid = userRankInfo.UserRid;
            //}

            //WorkContext.PartUserInfo = partUserInfo;

            //WorkContext.Uid = partUserInfo.Uid;
            //WorkContext.UserName = partUserInfo.UserName;
            //WorkContext.UserEmail = partUserInfo.Email;
            //WorkContext.UserMobile = partUserInfo.Mobile;
            //WorkContext.Password = partUserInfo.Password;
            //WorkContext.NickName = partUserInfo.NickName;
            //WorkContext.Avatar = partUserInfo.Avatar;
            //WorkContext.PayCreditName = Credits.PayCreditName;
            //WorkContext.PayCreditCount = partUserInfo.PayCredits;
            //WorkContext.RankCreditName = Credits.RankCreditName;
            //WorkContext.RankCreditCount = partUserInfo.RankCredits;

            WorkContext.UserRid = 0;
            //WorkContext.UserRankInfo = UserRanks.GetUserRankById(partUserInfo.UserRid);
            //WorkContext.UserRTitle = WorkContext.UserRankInfo.Title;
            ////设置用户管理员组
            //WorkContext.AdminGid = partUserInfo.AdminGid;
            //WorkContext.AdminGroupInfo = AdminGroups.GetAdminGroupById(partUserInfo.AdminGid);
            //WorkContext.AdminGTitle = WorkContext.AdminGroupInfo.Title;

            //设置当前控制器类名
            WorkContext.Controller = RouteData.Values["controller"].ToString().ToLower();
            //设置当前动作方法名
            WorkContext.Action = RouteData.Values["action"].ToString().ToLower();
            WorkContext.PageKey = string.Format("/{0}/{1}", WorkContext.Controller, WorkContext.Action);

            //当前商城主题名称
            //WorkContext.ThemeName = WorkContext.ShopConfig.ThemeName;
            //设置图片目录
            //WorkContext.ImageDir = string.Format("{0}/Themes/{1}/Images", WorkContext.ShopConfig.ImageCDN, WorkContext.ThemeName);
            ////设置css目录
            //WorkContext.CSSDir = string.Format("{0}/Themes/{1}/CSS", WorkContext.ShopConfig.CSSCDN, WorkContext.ThemeName);
            ////设置脚本目录
            //WorkContext.ScriptDir = string.Format("{0}/Scripts", WorkContext.ShopConfig.ScriptCDN);

            //在线总人数
            //WorkContext.OnlineUserCount = OnlineUsers.GetOnlineUserCount();
            ////在线游客数
            //WorkContext.OnlineGuestCount = OnlineUsers.GetOnlineGuestCount();
            ////在线会员数
            //WorkContext.OnlineMemberCount = WorkContext.OnlineUserCount - WorkContext.OnlineGuestCount;
            //搜索词
            WorkContext.SearchWord = string.Empty;
            //购物车中商品数量
            //WorkContext.SCProductCount = Orders.GetShopCartProductCountCookie();

            //分类列表
            //WorkContext.CategoryList = Categories.GetCategoryList();
            ////设置导航列表
            //WorkContext.NavList = Navs.GetNavList();
            ////设置友情链接列表
            //WorkContext.FriendLinkList = FriendLinks.GetFriendLinkList();
            ////设置帮助列表
            //WorkContext.HelpList = Helps.GetHelpList();
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //不能应用在子方法上
            if (filterContext.IsChildAction)
                return;

            //商城已经关闭
            //if (WorkContext.ShopConfig.IsClosed == 1 && WorkContext.AdminGid == 1 && WorkContext.PageKey != "/account/login" && WorkContext.PageKey != "/account/logout")
            //{
            //    filterContext.Result = PromptView(WorkContext.ShopConfig.CloseReason);
            //    return;
            //}

            //当前时间为禁止访问时间
            //if (ValidateHelper.BetweenPeriod(WorkContext.ShopConfig.BanAccessTime) && WorkContext.AdminGid == 1 && WorkContext.PageKey != "/account/login" && WorkContext.PageKey != "/account/logout")
            //{
            //    filterContext.Result = PromptView("当前时间不能访问本商城");
            //    return;
            //}

            //当用户ip在被禁止的ip列表时
            //if (ValidateHelper.InIPList(WorkContext.IP, WorkContext.ShopConfig.BanAccessIP))
            //{
            //    filterContext.Result = PromptView("您的IP被禁止访问本商城");
            //    return;
            //}

            //当用户ip不在允许的ip列表时
            //if (!string.IsNullOrEmpty(WorkContext.ShopConfig.AllowAccessIP) && !ValidateHelper.InIPList(WorkContext.IP, WorkContext.ShopConfig.AllowAccessIP))
            //{
            //    filterContext.Result = PromptView("您的IP被禁止访问本商城");
            //    return;
            //}

            //当用户IP被禁止时
            //if (BannedIPs.CheckIP(WorkContext.IP))
            //{
            //    filterContext.Result = PromptView("您的IP被禁止访问本商城");
            //    return;
            //}

            //当用户等级是禁止访问等级时
            if (WorkContext.UserRid == 1)
            {
                filterContext.Result = PromptView("您的账号当前被锁定,不能访问");
                return;
            }

            //判断目前访问人数是否达到允许的最大人数
            //if (WorkContext.OnlineUserCount > WorkContext.ShopConfig.MaxOnlineCount && WorkContext.AdminGid == 1 && (WorkContext.Controller != "account" && (WorkContext.Action != "login" || WorkContext.Action != "logout")))
            //{
            //    filterContext.Result = PromptView("商城人数达到访问上限, 请稍等一会再访问！");
            //    return;
            //}
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //不能应用在子方法上
            if (filterContext.IsChildAction)
                return;
#if DEBUG
            //清空执行的sql语句数目
            //RDBSHelper.ExecuteCount = 0;
            //清空执行的sql语句细节
            //RDBSHelper.ExecuteDetail = "";
#endif
            //页面开始执行时间
            WorkContext.StartExecuteTime = DateTime.Now;

            //当用户为会员时,更新用户的在线时间
            //if (WorkContext.Uid > 0)
            //    Users.UpdateUserOnlineTime(WorkContext.Uid);

            //更新在线用户
            //Asyn.UpdateOnlineUser(WorkContext.Uid, WorkContext.Sid, WorkContext.NickName, WorkContext.IP, WorkContext.RegionId);
            ////更新PV统计
            //if (WorkContext.ShopConfig.UpdatePVStatTimespan != 0)
            //    Asyn.UpdatePVStat(WorkContext.Uid, WorkContext.RegionId, WebHelper.GetBrowserType(), WebHelper.GetOSType());
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //不能应用在子方法上
            if (filterContext.IsChildAction)
                return;
#if DEBUG
            //执行的sql语句数目
            //WorkContext.ExecuteCount = RDBSHelper.ExecuteCount;

            ////执行的sql语句细节
            //if (RDBSHelper.ExecuteDetail == string.Empty)
            //    WorkContext.ExecuteDetail = "当前页面没有和数据库的任何交互";
            //else
            //    WorkContext.ExecuteDetail = "<div>数据查询分析:</div>" + RDBSHelper.ExecuteDetail;
#endif
            //页面执行时间
            WorkContext.ExecuteTime = DateTime.Now.Subtract(WorkContext.StartExecuteTime).TotalMilliseconds / 1000;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            EFramework.Core.Logger.Factory.Instance.Wirte(filterContext.Exception);
            if (WorkContext.IsHttpAjax)
                filterContext.Result = new ContentResult { Content = "error" };
            else
                filterContext.Result = new ViewResult() { ViewName = "Error" };
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        protected string GetRouteString(string key, string defaultValue)
        {
            object value = RouteData.Values[key];
            if (value != null)
                return value.ToString();
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        protected string GetRouteString(string key)
        {
            return GetRouteString(key, "");
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        protected int GetRouteInt(string key, int defaultValue)
        {
            return TypeHelper.ObjectToInt(RouteData.Values[key], defaultValue);
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        protected int GetRouteInt(string key)
        {
            return GetRouteInt(key, 0);
        }

        /// <summary>
        /// 提示信息视图
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected ViewResult PromptView(string message)
        {
            return View("Prompt", new PromptModel(message));
        }

        /// <summary>
        /// 提示信息视图
        /// </summary>
        /// <param name="backUrl">返回地址</param>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        protected ViewResult PromptView(string backUrl, string message)
        {
            return View("Prompt", new PromptModel(backUrl, message));
        }

        /// <summary>
        /// 获得验证错误列表
        /// </summary>
        /// <returns></returns>
        protected string GetVerifyErrorList()
        {
            if (ModelState.Count == 0)
                return "null";

            StringBuilder errorList = new StringBuilder("[");
            foreach (KeyValuePair<string, ModelState> item in ModelState)
            {
                errorList.AppendFormat("{0}\"key\":\"{1}\",\"msg\":\"{2}\"{3},", "{", item.Key, item.Value.Errors[0].ErrorMessage, "}");
            }
            errorList.Remove(errorList.Length - 1, 1);
            errorList.Append("]");
            return errorList.ToString();
        }
    }
}
