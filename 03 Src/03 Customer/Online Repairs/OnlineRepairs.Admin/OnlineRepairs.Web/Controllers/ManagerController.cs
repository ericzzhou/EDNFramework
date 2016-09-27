using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Business.EDNFramework_Repairs;
using DotNet.Framework.Admin.Core.Entity;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Repairs;
using OnlineRepairs.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRepairs.Web.Controllers
{
    [InitializeMembership(Role = 3)]
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        /// <summary>
        /// 维修师傅登录后的首页，列出指派给当前师傅的所有订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int userID = BusEntity_LoginUser.Sys_LoginUser.UserID;

            return View(Business_Repairs.GetOrdersByAssignedTo(userID) ?? new List<Entity_AssignedOrder>());
        }

        public ActionResult Details(int id = 0)
        {
            Entity_Order order = new Entity_Order();
            IList<Entity_Order_History> histories = new List<Entity_Order_History>();
            Entity_Order_ContactsAddress contact = new Entity_Order_ContactsAddress();
            if (id > 0)
            {
                order = Business_Repairs.GetOrderInfo(id) ?? new Entity_Order();

                if (order != null)
                {
                    histories = Business_Repairs.GetOrderHistory(id) ?? new List<Entity_Order_History>();
                    contact = Business_Repairs.GetContactsAddress(order.UserContactID) ?? new Entity_Order_ContactsAddress();

                    if (order.AssignedTo > 0)
                    {
                        var AssignedUser = Business_User.GetModel(order.AssignedTo);
                        if (AssignedUser != null)
                        {
                            order.AssignedToUser = AssignedUser.NickName;
                        }
                    }

                    order.BrandName = Business_Repairs.GetBrand(order.BrandID).Name;
                    if (order.UserID > 0)
                    {
                        var user = Business_User.GetModel(order.UserID) ?? new Entity_User();
                        order.UserName = user.NickName;
                    }
                }
            }
            ViewBag.order = order;
            ViewBag.histories = histories;
            ViewBag.contact = contact;
            return View();
        }

    }
}
