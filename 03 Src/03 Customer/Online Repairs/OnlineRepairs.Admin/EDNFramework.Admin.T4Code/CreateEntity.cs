
using System;
using DotNet.Framework.DataAccess.Attribute;
using System.Data;
namespace MyProject.Entities 
{     
	public class ALL
	{
		Entity_Account_UserType Account_UserType = new Entity_Account_UserType();
		Entity_Account_UserRoles Account_UserRoles = new Entity_Account_UserRoles();
		Entity_Account_UserBind Account_UserBind = new Entity_Account_UserBind();
		Entity_Account_User_LogonLog Account_User_LogonLog = new Entity_Account_User_LogonLog();
		Entity_Account_User Account_User = new Entity_Account_User();
		Entity_Account_RolePermissionsAction Account_RolePermissionsAction = new Entity_Account_RolePermissionsAction();
		Entity_Account_RolePermissions Account_RolePermissions = new Entity_Account_RolePermissions();
		Entity_Account_Role Account_Role = new Entity_Account_Role();
		Entity_Account_PermissionCategories Account_PermissionCategories = new Entity_Account_PermissionCategories();
		Entity_Account_PermissionActions Account_PermissionActions = new Entity_Account_PermissionActions();
		Entity_Account_Permission Account_Permission = new Entity_Account_Permission();
		Entity_Account_Department Account_Department = new Entity_Account_Department();
		Entity_Repairs_Brand Repairs_Brand = new Entity_Repairs_Brand();
		Entity_Repairs_ContactsAddress Repairs_ContactsAddress = new Entity_Repairs_ContactsAddress();
		Entity_Repairs_Order Repairs_Order = new Entity_Repairs_Order();
		Entity_Repairs_OrderHistory Repairs_OrderHistory = new Entity_Repairs_OrderHistory();
		Entity_SYS_ErrorLog SYS_ErrorLog = new Entity_SYS_ErrorLog();
		Entity_SYS_ConfigContent SYS_ConfigContent = new Entity_SYS_ConfigContent();
	}

  

		/// <summary> 
		/// Entity_Account_UserType的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_UserType
		{
			[DataMapping("UserType")]
			public String UserType { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_UserRoles的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_UserRoles
		{
			[DataMapping("UserID")]
			public Int32 UserID { get; set; }
		   
			[DataMapping("RoleID")]
			public Int32 RoleID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_UserBind的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_UserBind
		{
			[DataMapping("BindId")]
			public Int32 BindId { get; set; }
		   
			[DataMapping("UserId")]
			public Int32 UserId { get; set; }
		   
			[DataMapping("Token")]
			public String Token { get; set; }
		   
			[DataMapping("MediaUserID")]
			public Int32 MediaUserID { get; set; }
		   
			[DataMapping("MediaNickName")]
			public String MediaNickName { get; set; }
		   
			[DataMapping("MediaID")]
			public Int32 MediaID { get; set; }
		   
			[DataMapping("iHome")]
			public Boolean iHome { get; set; }
		   
			[DataMapping("Comment")]
			public Boolean Comment { get; set; }
		   
			[DataMapping("GroupTopic")]
			public Boolean GroupTopic { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_User_LogonLog的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_User_LogonLog
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("UserName")]
			public String UserName { get; set; }
		   
			[DataMapping("LogonTime")]
			public DateTime LogonTime { get; set; }
		   
			[DataMapping("Status")]
			public String Status { get; set; }
		   
			[DataMapping("StatusDescription")]
			public String StatusDescription { get; set; }
		   
			[DataMapping("LogonIP")]
			public String LogonIP { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_User的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_User
		{
			[DataMapping("UserID")]
			public Int32 UserID { get; set; }
		   
			[DataMapping("UserName")]
			public String UserName { get; set; }
		   
			[DataMapping("Password")]
			public String Password { get; set; }
		   
			[DataMapping("NickName")]
			public String NickName { get; set; }
		   
			[DataMapping("TrueName")]
			public String TrueName { get; set; }
		   
			[DataMapping("Sex")]
			public String Sex { get; set; }
		   
			[DataMapping("Phone")]
			public String Phone { get; set; }
		   
			[DataMapping("Email")]
			public String Email { get; set; }
		   
			[DataMapping("EmployeeID")]
			public Int32 EmployeeID { get; set; }
		   
			[DataMapping("DepartmentID")]
			public String DepartmentID { get; set; }
		   
			[DataMapping("Activity")]
			public Boolean Activity { get; set; }
		   
			[DataMapping("UserType")]
			public String UserType { get; set; }
		   
			[DataMapping("Style")]
			public Int32 Style { get; set; }
		   
			[DataMapping("User_iCreator")]
			public Int32 User_iCreator { get; set; }
		   
			[DataMapping("User_dateCreate")]
			public DateTime User_dateCreate { get; set; }
		   
			[DataMapping("User_dateValid")]
			public DateTime User_dateValid { get; set; }
		   
			[DataMapping("User_dateExpire")]
			public DateTime User_dateExpire { get; set; }
		   
			[DataMapping("User_iApprover")]
			public Int32 User_iApprover { get; set; }
		   
			[DataMapping("User_dateApprove")]
			public DateTime User_dateApprove { get; set; }
		   
			[DataMapping("User_iApproveState")]
			public Int32 User_iApproveState { get; set; }
		   
			[DataMapping("User_cLang")]
			public String User_cLang { get; set; }
		   
			[DataMapping("auth_token")]
			public String auth_token { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_RolePermissionsAction的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_RolePermissionsAction
		{
			[DataMapping("ARPAID")]
			public Guid ARPAID { get; set; }
		   
			[DataMapping("ARPID")]
			public Guid ARPID { get; set; }
		   
			[DataMapping("ActionCode")]
			public String ActionCode { get; set; }
		   
			[DataMapping("RoleID")]
			public Int32 RoleID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_RolePermissions的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_RolePermissions
		{
			[DataMapping("ARPID")]
			public Guid ARPID { get; set; }
		   
			[DataMapping("RoleID")]
			public Int32 RoleID { get; set; }
		   
			[DataMapping("PermissionCode")]
			public String PermissionCode { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_Role的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_Role
		{
			[DataMapping("RoleID")]
			public Int32 RoleID { get; set; }
		   
			[DataMapping("RoleName")]
			public String RoleName { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_PermissionCategories的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_PermissionCategories
		{
			[DataMapping("CategoryID")]
			public Int32 CategoryID { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_PermissionActions的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_PermissionActions
		{
			[DataMapping("ActionID")]
			public Int32 ActionID { get; set; }
		   
			[DataMapping("ActionCode")]
			public String ActionCode { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("PermissionCode")]
			public String PermissionCode { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_Permission的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_Permission
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("ParentID")]
			public Int32 ParentID { get; set; }
		   
			[DataMapping("CategoryID")]
			public Int32 CategoryID { get; set; }
		   
			[DataMapping("PermissionCode")]
			public String PermissionCode { get; set; }
		   
			[DataMapping("PermissionName")]
			public String PermissionName { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("CreateDate")]
			public DateTime CreateDate { get; set; }
		   
			[DataMapping("RequestUrl")]
			public String RequestUrl { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Account_Department的注释
		/// </summary> 
		[Serializable]
		public class Entity_Account_Department
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("Code")]
			public String Code { get; set; }
		   
			[DataMapping("Name")]
			public String Name { get; set; }
		   
			[DataMapping("ShortName")]
			public String ShortName { get; set; }
		   
			[DataMapping("ParentID")]
			public Int32 ParentID { get; set; }
		   
			[DataMapping("Type")]
			public String Type { get; set; }
		   
			[DataMapping("Manager")]
			public String Manager { get; set; }
		   
			[DataMapping("Manager2")]
			public String Manager2 { get; set; }
		   
			[DataMapping("Phone")]
			public String Phone { get; set; }
		   
			[DataMapping("ExtNumber")]
			public String ExtNumber { get; set; }
		   
			[DataMapping("Fax")]
			public String Fax { get; set; }
		   
			[DataMapping("Status")]
			public String Status { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Repairs_Brand的注释
		/// </summary> 
		[Serializable]
		public class Entity_Repairs_Brand
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("Name")]
			public String Name { get; set; }
		   
			[DataMapping("Descriptino")]
			public String Descriptino { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Repairs_ContactsAddress的注释
		/// </summary> 
		[Serializable]
		public class Entity_Repairs_ContactsAddress
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
		/// Entity_Repairs_Order的注释
		/// </summary> 
		[Serializable]
		public class Entity_Repairs_Order
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
			public DateTime CreateTime { get; set; }
		   
			[DataMapping("ModifyTime")]
			public DateTime ModifyTime { get; set; }
		   
			[DataMapping("AssignedTo")]
			public Int32 AssignedTo { get; set; }
		   
			[DataMapping("Statu")]
			public Int32 Statu { get; set; }
		   
			[DataMapping("Remark")]
			public String Remark { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Repairs_OrderHistory的注释
		/// </summary> 
		[Serializable]
		public class Entity_Repairs_OrderHistory
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("OrderID")]
			public Int32 OrderID { get; set; }
		   
			[DataMapping("Status")]
			public Int32 Status { get; set; }
		   
			[DataMapping("CreateTime")]
			public DateTime CreateTime { get; set; }
		   
			[DataMapping("Note")]
			public String Note { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_SYS_ErrorLog的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_ErrorLog
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("OPTime")]
			public DateTime OPTime { get; set; }
		   
			[DataMapping("Url")]
			public String Url { get; set; }
		   
			[DataMapping("Loginfo")]
			public String Loginfo { get; set; }
		   
			[DataMapping("StackTrace")]
			public String StackTrace { get; set; }
		   
			[DataMapping("ErrorType")]
			public String ErrorType { get; set; }
		   
			[DataMapping("Domain")]
			public String Domain { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_SYS_ConfigContent的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_ConfigContent
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("Keyname")]
			public String Keyname { get; set; }
		   
			[DataMapping("Value")]
			public String Value { get; set; }
		   
			[DataMapping("KeyType")]
			public Int32 KeyType { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		            
		}             
	
}