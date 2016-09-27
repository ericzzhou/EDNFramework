using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRepairs.Web.Models
{
    public class OrderModel
    {
        public int ComputyBrand { get; set; }
        public string ComputyModel { get; set; }
        public string RepairsDescription { get; set; }
        public String ContactsAddress { get; set; }
        public Int32 ComputerType { get; set; }
        public String ContactsName { get; set; }
        public String ContactsMobile { get; set; }

        public static string GetOrderStatusString(int status)
        {
            string ret = string.Empty;
            switch (status)
            {
                case 0:
                    ret = "客户创建订单";
                    break;
                case 1:
                    ret = "系统确认";
                    break;
                case 2:
                    ret = "订单已分派";
                    break;
                case 3:
                    ret = "工作完成";
                    break;
                case 4:
                    ret = "订单完成";
                    break;
                case 5:
                    ret = "订单已经关闭";
                    break;
                case -1:
                    ret = "订单已删除";
                    break;
            }
            return ret;
        }
    }
}