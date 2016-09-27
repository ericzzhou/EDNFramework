using System;
using DotNet.Framework.Core.Extends;
using DotNet.Framework.Admin.Entity.EDNFramework_Repairs;
using System.Collections.Generic;
using DotNet.Framework.Admin.Business.EDNFramework_Repairs;
using DotNet.Framework.Utils.Serialization;
using DotNet.Framework.Admin.Business.EDNFramework_Account;
using DotNet.Framework.Admin.Entity.EDNFramework_Account;
namespace DotNet.Framework.Admin.UI.Pages.Repairs.Order
{
    public partial class Detail : System.Web.UI.Page
    {
        public string OrderInfoJson = "{ }";
        //public dynamic ViewModel ;
        public Entity_Order order = new Entity_Order();
        public IList<Entity_Order_History> histories = new List<Entity_Order_History>();
        public Entity_Order_ContactsAddress contact = new Entity_Order_ContactsAddress();
        protected void Page_Load(object sender, EventArgs e)
        {

            int ID = Request["id"].ToInt();

            if (ID > 0)
            {
                order = Business_Repairs.GetOrderInfo(ID) ?? new Entity_Order();

                if (order != null)
                {
                    histories = Business_Repairs.GetOrderHistory(ID) ?? new List<Entity_Order_History>();
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
            //ViewModel = new
            //{
            //    order = order,
            //    histories = histories,
            //    contact = contact
            //};
            OrderInfoJson = ObjectJsonSerializer.Serialize<dynamic>(new
            {
                order = order,
                histories = histories,
                contact = contact
            });
        }
    }
}