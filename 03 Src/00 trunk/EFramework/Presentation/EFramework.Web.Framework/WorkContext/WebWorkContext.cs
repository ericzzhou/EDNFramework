﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFramework.Web.Framework.WorkContext
{
    /// <summary>
    /// 商城前台工作上下文类
    /// </summary>
    public class WebWorkContext
    {
        //public ShopConfigInfo ShopConfig = BSPConfig.ShopConfig;//商城配置信息

        public bool IsHttpAjax;//当前请求是否为ajax请求

        public string IP;//用户ip

        //public RegionInfo RegionInfo;//区域信息

        //public int RegionId;//区域id

        public string Url;//当前url

        public string UrlReferrer;//上一次访问的url

        //public string Sid;//用户sid

        public int Uid = -1;//用户id

        public string UserName;//用户名

        public string UserEmail;//用户邮箱

        public string UserMobile;//用户手机号

        public string NickName;//用户昵称

        public string Avatar;//用户头像

        public string Password;//用户密码

        public string EncryptPwd;//加密密码

        //public string PayCreditName;//支付积分名称

        //public int PayCreditCount = 0;//支付积分数量

        //public string RankCreditName;//等级积分名称

        //public int RankCreditCount = 0;//等级积分数量

        //public PartUserInfo PartUserInfo;//用户信息

        public int UserRid = -1;//用户等级id

        //public UserRankInfo UserRankInfo;//用户等级信息

        //public string UserRTitle;//用户等级标题

        //public int AdminGid = -1;//用户管理员组id

        //public AdminGroupInfo AdminGroupInfo;//用户管理员组信息

        //public string AdminGTitle;//管理员组标题

        public string Controller;//控制器

        public string Action;//动作方法

        public string PageKey;//页面标示符

        //public string ThemeName;//当前主题名称

        public string ImageDir;//图片目录

        public string CSSDir;//css目录

        public string ScriptDir;//脚本目录

        //public int OnlineUserCount = 0;//在线总人数

        //public int OnlineMemberCount = 0;//在线会员数

        //public int OnlineGuestCount = 0;//在线游客数

        public string SearchWord;//搜索词

        public int SCProductCount = 0;//购物车中商品数量

        //public List<CategoryInfo> CategoryList;//分类列表

        //public List<NavInfo> NavList;//导航列表

        //public FriendLinkInfo[] FriendLinkList;//友情链接列表

        //public List<HelpInfo> HelpList;//帮助列表

        public DateTime StartExecuteTime;//页面开始执行时间

        public double ExecuteTime;//页面执行时间

        public int ExecuteCount = 0;//执行的sql语句数目

        public string ExecuteDetail;//执行的sql语句细节

        //public string ShopVersion = BSPVersion.SHOP_VERSION;//商城版本

        //public string ShopCopyright = BSPVersion.SHOP_COPYRIGHT;//商城版权


        public string SiteTitle { get; set; }

        public string SEOKeyword { get; set; }

        public string SEODescription { get; set; }
    }
}
