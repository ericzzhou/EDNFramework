using DotNet.Framework.DataAccess.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Entity.EDNFramework_Repairs
{
    [Serializable]
    public class Entity_GetAssignedTo
    {
        [DataMapping("UserID")]
        public int UserID { get; set; }

        [DataMapping("UserName")]
        public string UserName { get; set; }

        [DataMapping("NickName")]
        public string NickName { get; set; }

        [DataMapping("TrueName")]
        public string TrueName { get; set; }
    }

    [Serializable]
    public class Entity_AssignedOrder
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("OrderNumber")]
        public String OrderNumber { get; set; }

        [DataMapping("Model")]
        public String Model { get; set; }

        [DataMapping("RepairsDescription")]
        public String RepairsDescription { get; set; }

        [DataMapping("ComputerType")]
        public Int32 ComputerType { get; set; }

        [DataMapping("CreateTime")]
        public DateTime CreateTime { get; set; }

        [DataMapping("Statu")]
        public Int32 Statu { get; set; }

        [DataMapping("UserName")]
        public string UserName { get; set; }

        [DataMapping("NickName")]
        public string NickName { get; set; }

        [DataMapping("phone")]
        public String phone { get; set; }

        [DataMapping("BrandName")]
        public String BrandName { get; set; }
    }

    [Serializable]
    public class Entity_UserOrder
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("OrderNumber")]
        public String OrderNumber { get; set; }

        [DataMapping("Model")]
        public String Model { get; set; }

        [DataMapping("RepairsDescription")]
        public String RepairsDescription { get; set; }

        [DataMapping("ComputerType")]
        public Int32 ComputerType { get; set; }

        [DataMapping("CreateTime")]
        public DateTime CreateTime { get; set; }

        [DataMapping("Statu")]
        public Int32 Statu { get; set; }

        [DataMapping("UserName")]
        public string UserName { get; set; }

        [DataMapping("NickName")]
        public string NickName { get; set; }

        [DataMapping("phone")]
        public String phone { get; set; }

        [DataMapping("BrandName")]
        public String BrandName { get; set; }
    }

    [Serializable]
    public class Entity_Order
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("OrderNumber")]
        public String OrderNumber { get; set; }

        [DataMapping("UserID")]
        public Int32 UserID { get; set; }

        [DataMapping("UserContactID")]
        public Int32 UserContactID { get; set; }

        [DataMapping("BrandID")]
        public Int32 BrandID { get; set; }

        [DataMapping("Model")]
        public String Model { get; set; }

        [DataMapping("RepairsDescription")]
        public String RepairsDescription { get; set; }

        [DataMapping("ComputerType")]
        public Int32 ComputerType { get; set; }

        [DataMapping("CreateTime")]
        public string CreateTime { get; set; }

        [DataMapping("ModifyTime")]
        public string ModifyTime { get; set; }

        [DataMapping("AssignedTo")]
        public Int32 AssignedTo { get; set; }

        [DataMapping("Statu")]
        public Int32 Statu { get; set; }

        [DataMapping("Remark")]
        public String Remark { get; set; }

        [DataMapping("AssignedToUser")]
        public string AssignedToUser { get; set; }

        [DataMapping("UserName")]
        public string UserName { get; set; }

        [DataMapping("BrandName")]
        public string BrandName { get; set; }
    }

    [Serializable]
    public class Entity_Order_List
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("OrderNumber")]
        public String OrderNumber { get; set; }

        [DataMapping("NickName")]
        public string NickName { get; set; }

        [DataMapping("ComputerType")]
        public string ComputerType { get; set; }

        [DataMapping("BrandName")]
        public string BrandName { get; set; }

        [DataMapping("Model")]
        public String Model { get; set; }

        [DataMapping("Statu")]
        public Int32 Statu { get; set; }

    }


    /// <summary> 
    /// Entity_Repairs_OrderHistory的注释
    /// </summary> 
    [Serializable]
    public class Entity_Order_History
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("OrderID")]
        public Int32 OrderID { get; set; }

        [DataMapping("Status")]
        public Int32 Status { get; set; }

        [DataMapping("CreateTime")]
        public string CreateTime { get; set; }

        [DataMapping("Note")]
        public String Note { get; set; }

        [DataMapping("CreateTime2")]
        public DateTime CreateTime2 { get; set; }

        [DataMapping("Phone")]
        public String Phone { get; set; }

        [DataMapping("NickName")]
        public String NickName { get; set; }

    }
    /// <summary> 
    /// Entity_Repairs_ContactsAddress的注释
    /// </summary> 
    [Serializable]
    public class Entity_Order_ContactsAddress
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("UserID")]
        public Int32 UserID { get; set; }

        [DataMapping("ContactsName")]
        public String ContactsName { get; set; }

        [DataMapping("ContactsMobile")]
        public String ContactsMobile { get; set; }

        [DataMapping("ContactsAddress")]
        public String ContactsAddress { get; set; }

    }
    /// <summary> 
    /// Entity_Repairs_Brand的注释
    /// </summary> 
    [Serializable]
    public class Entity_Order_Brand
    {
        [DataMapping("ID")]
        public Int32 ID { get; set; }

        [DataMapping("Name")]
        public String Name { get; set; }

        [DataMapping("Descriptino")]
        public String Descriptino { get; set; }

    }
    
    [Serializable]
    public class Entity_Order_Notify
    {
        [DataMapping("ID")]
        public int ID { get; set; }

        [DataMapping("OrderNumber")]
        public string OrderNumber { get; set; }

        [DataMapping("AssignedTo")]
        public int AssignedTo { get; set; }

        [DataMapping("ContactsName")]
        public string ContactsName { get; set; }

        [DataMapping("ContactsMobile")]
        public string ContactsMobile { get; set; }

        [DataMapping("ContactsAddress")]
        public string ContactsAddress { get; set; }

        [DataMapping("masterName")]
        public string masterName { get; set; }

        [DataMapping("masterPhone")]
        public string masterPhone { get; set; }
    }
}
