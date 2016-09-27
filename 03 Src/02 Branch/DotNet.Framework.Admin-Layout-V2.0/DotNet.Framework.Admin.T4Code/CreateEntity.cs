
using System;
using DotNet.Framework.DataAccess.Attribute;
using System.Data;
namespace MyProject.Entities 
{     
	public class ALL
	{
		Entity_SYS_FilterWords SYS_FilterWords = new Entity_SYS_FilterWords();
		Entity_Account_UserType Account_UserType = new Entity_Account_UserType();
		Entity_Account_UserRoles Account_UserRoles = new Entity_Account_UserRoles();
		Entity_Account_UserBind Account_UserBind = new Entity_Account_UserBind();
		Entity_SYS_EmailQueue SYS_EmailQueue = new Entity_SYS_EmailQueue();
		Entity_CMS_FLinks CMS_FLinks = new Entity_CMS_FLinks();
		Entity_SYS_ConfigType SYS_ConfigType = new Entity_SYS_ConfigType();
		Entity_SYS_ConfigContent SYS_ConfigContent = new Entity_SYS_ConfigContent();
		Entity_Account_Role Account_Role = new Entity_Account_Role();
		Entity_Account_PermissionCategories Account_PermissionCategories = new Entity_Account_PermissionCategories();
		Entity_SYS_UserLog SYS_UserLog = new Entity_SYS_UserLog();
		Entity_Account_Permission Account_Permission = new Entity_Account_Permission();
		Entity_SYS_SiteSettings SYS_SiteSettings = new Entity_SYS_SiteSettings();
		Entity_CMS_ClassType CMS_ClassType = new Entity_CMS_ClassType();
		Entity_CMS_Brand CMS_Brand = new Entity_CMS_Brand();
		Entity_SYS_SiteMessageLog SYS_SiteMessageLog = new Entity_SYS_SiteMessageLog();
		Entity_SYS_SiteMessage SYS_SiteMessage = new Entity_SYS_SiteMessage();
		Entity_CMS_AdvertisePosition CMS_AdvertisePosition = new Entity_CMS_AdvertisePosition();
		Entity_Account_User_LogonLog Account_User_LogonLog = new Entity_Account_User_LogonLog();
		Entity_SYS_MailConfig SYS_MailConfig = new Entity_SYS_MailConfig();
		Entity_CMS_Advertisement CMS_Advertisement = new Entity_CMS_Advertisement();
		Entity_SYS_Log SYS_Log = new Entity_SYS_Log();
		Entity_SYS_Guestbook SYS_Guestbook = new Entity_SYS_Guestbook();
		Entity_CMS_WebMenuConfig CMS_WebMenuConfig = new Entity_CMS_WebMenuConfig();
		Entity_Hospital_NormCategory Hospital_NormCategory = new Entity_Hospital_NormCategory();
		Entity_CMS_Slide_Item CMS_Slide_Item = new Entity_CMS_Slide_Item();
		Entity_Poll_Reply Poll_Reply = new Entity_Poll_Reply();
		Entity_CMS_VideoClass CMS_VideoClass = new Entity_CMS_VideoClass();
		Entity_CMS_Slide CMS_Slide = new Entity_CMS_Slide();
		Entity_Hospital_NormItem Hospital_NormItem = new Entity_Hospital_NormItem();
		Entity_Poll_Options Poll_Options = new Entity_Poll_Options();
		Entity_CMS_VideoAlbum CMS_VideoAlbum = new Entity_CMS_VideoAlbum();
		Entity_Poll_Forms Poll_Forms = new Entity_Poll_Forms();
		Entity_Poll_Users Poll_Users = new Entity_Poll_Users();
		Entity_CMS_Video CMS_Video = new Entity_CMS_Video();
		Entity_Poll_UserPoll Poll_UserPoll = new Entity_Poll_UserPoll();
		Entity_Poll_Topics Poll_Topics = new Entity_Poll_Topics();
		Entity_Account_User Account_User = new Entity_Account_User();
		Entity_SYS_ErrorLog SYS_ErrorLog = new Entity_SYS_ErrorLog();
		Entity_CMS_PhotoClass CMS_PhotoClass = new Entity_CMS_PhotoClass();
		Entity_CMS_PhotoAlbum CMS_PhotoAlbum = new Entity_CMS_PhotoAlbum();
		Entity_Hospital_NormValue Hospital_NormValue = new Entity_Hospital_NormValue();
		Entity_CMS_Photo CMS_Photo = new Entity_CMS_Photo();
		Entity_Account_Department Account_Department = new Entity_Account_Department();
		Entity_Account_PermissionActions Account_PermissionActions = new Entity_Account_PermissionActions();
		Entity_Account_RolePermissionsAction Account_RolePermissionsAction = new Entity_Account_RolePermissionsAction();
		Entity_Account_RolePermissions Account_RolePermissions = new Entity_Account_RolePermissions();
		Entity_CMS_ContentClass CMS_ContentClass = new Entity_CMS_ContentClass();
		Entity_Product_Class Product_Class = new Entity_Product_Class();
		Entity_Product_Item Product_Item = new Entity_Product_Item();
		Entity_CMS_Comment CMS_Comment = new Entity_CMS_Comment();
		Entity_CMS_Content CMS_Content = new Entity_CMS_Content();
	}

  

		/// <summary> 
		/// Entity_SYS_FilterWords的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_FilterWords
		{
			[DataMapping("FilterId")]
			public Int32 FilterId { get; set; }
		   
			[DataMapping("WordPattern")]
			public String WordPattern { get; set; }
		   
			[DataMapping("IsForbid")]
			public Boolean IsForbid { get; set; }
		   
			[DataMapping("IsMod")]
			public Boolean IsMod { get; set; }
		   
			[DataMapping("RepalceWord")]
			public String RepalceWord { get; set; }
		            
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
		/// Entity_SYS_EmailQueue的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_EmailQueue
		{
			[DataMapping("EmailId")]
			public Int32 EmailId { get; set; }
		   
			[DataMapping("EmailPriority")]
			public Int32 EmailPriority { get; set; }
		   
			[DataMapping("IsBodyHtml")]
			public Boolean IsBodyHtml { get; set; }
		   
			[DataMapping("EmailTo")]
			public String EmailTo { get; set; }
		   
			[DataMapping("EmailCc")]
			public String EmailCc { get; set; }
		   
			[DataMapping("EmailBcc")]
			public String EmailBcc { get; set; }
		   
			[DataMapping("EmailFrom")]
			public String EmailFrom { get; set; }
		   
			[DataMapping("EmailSubject")]
			public String EmailSubject { get; set; }
		   
			[DataMapping("EmailBody")]
			public String EmailBody { get; set; }
		   
			[DataMapping("NextTryTime")]
			public DateTime NextTryTime { get; set; }
		   
			[DataMapping("NumberOfTries")]
			public Int32 NumberOfTries { get; set; }
		   
			[DataMapping("Successed")]
			public Boolean Successed { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_FLinks的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_FLinks
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("Name")]
			public String Name { get; set; }
		   
			[DataMapping("ImgUrl")]
			public String ImgUrl { get; set; }
		   
			[DataMapping("LinkUrl")]
			public String LinkUrl { get; set; }
		   
			[DataMapping("LinkDesc")]
			public String LinkDesc { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("OrderID")]
			public Int32 OrderID { get; set; }
		   
			[DataMapping("ContactPerson")]
			public String ContactPerson { get; set; }
		   
			[DataMapping("Email")]
			public String Email { get; set; }
		   
			[DataMapping("TelPhone")]
			public String TelPhone { get; set; }
		   
			[DataMapping("TypeID")]
			public Int16 TypeID { get; set; }
		   
			[DataMapping("IsDisplay")]
			public Boolean IsDisplay { get; set; }
		   
			[DataMapping("ImgWidth")]
			public Int32 ImgWidth { get; set; }
		   
			[DataMapping("ImgHeight")]
			public Int32 ImgHeight { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_SYS_ConfigType的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_ConfigType
		{
			[DataMapping("KeyType")]
			public Int32 KeyType { get; set; }
		   
			[DataMapping("TypeName")]
			public String TypeName { get; set; }
		            
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
		/// Entity_SYS_UserLog的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_UserLog
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("OPTime")]
			public DateTime OPTime { get; set; }
		   
			[DataMapping("Url")]
			public String Url { get; set; }
		   
			[DataMapping("OPInfo")]
			public String OPInfo { get; set; }
		   
			[DataMapping("UserName")]
			public String UserName { get; set; }
		   
			[DataMapping("UserType")]
			public String UserType { get; set; }
		   
			[DataMapping("UserIP")]
			public String UserIP { get; set; }
		            
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
		/// Entity_SYS_SiteSettings的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_SiteSettings
		{
			[DataMapping("SettingsId")]
			public Int32 SettingsId { get; set; }
		   
			[DataMapping("Disabled")]
			public Boolean Disabled { get; set; }
		   
			[DataMapping("Version")]
			public String Version { get; set; }
		   
			[DataMapping("SettingsXML")]
			public String SettingsXML { get; set; }
		   
			[DataMapping("SettingsKey")]
			public Guid SettingsKey { get; set; }
		   
			[DataMapping("ApplicationName")]
			public String ApplicationName { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_ClassType的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_ClassType
		{
			[DataMapping("ClassTypeID")]
			public Int32 ClassTypeID { get; set; }
		   
			[DataMapping("ClassTypeName")]
			public String ClassTypeName { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Brand的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Brand
		{
			[DataMapping("BrandID")]
			public Int32 BrandID { get; set; }
		   
			[DataMapping("BrandName")]
			public String BrandName { get; set; }
		   
			[DataMapping("BrandLogo")]
			public String BrandLogo { get; set; }
		   
			[DataMapping("BrandDesc")]
			public String BrandDesc { get; set; }
		   
			[DataMapping("EnterpriseID")]
			public Int32 EnterpriseID { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("Orders")]
			public Int32 Orders { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_SYS_SiteMessageLog的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_SiteMessageLog
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("MessageID")]
			public Int32 MessageID { get; set; }
		   
			[DataMapping("MessageType")]
			public String MessageType { get; set; }
		   
			[DataMapping("MessageState")]
			public String MessageState { get; set; }
		   
			[DataMapping("ReceiverID")]
			public Int32 ReceiverID { get; set; }
		   
			[DataMapping("Ext1")]
			public String Ext1 { get; set; }
		   
			[DataMapping("Ext2")]
			public String Ext2 { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_SYS_SiteMessage的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_SiteMessage
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("SenderID")]
			public Int32 SenderID { get; set; }
		   
			[DataMapping("ReceiverID")]
			public Int32 ReceiverID { get; set; }
		   
			[DataMapping("Title")]
			public String Title { get; set; }
		   
			[DataMapping("Content")]
			public String Content { get; set; }
		   
			[DataMapping("MsgType")]
			public String MsgType { get; set; }
		   
			[DataMapping("SendTime")]
			public DateTime SendTime { get; set; }
		   
			[DataMapping("ReadTime")]
			public DateTime ReadTime { get; set; }
		   
			[DataMapping("ReceiverIsRead")]
			public Boolean ReceiverIsRead { get; set; }
		   
			[DataMapping("SenderIsDel")]
			public Boolean SenderIsDel { get; set; }
		   
			[DataMapping("ReaderIsDel")]
			public Boolean ReaderIsDel { get; set; }
		   
			[DataMapping("Ext1")]
			public String Ext1 { get; set; }
		   
			[DataMapping("Ext2")]
			public String Ext2 { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_AdvertisePosition的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_AdvertisePosition
		{
			[DataMapping("AdvPositionId")]
			public Int32 AdvPositionId { get; set; }
		   
			[DataMapping("AdvPositionName")]
			public String AdvPositionName { get; set; }
		   
			[DataMapping("ShowType")]
			public Int32 ShowType { get; set; }
		   
			[DataMapping("RepeatColumns")]
			public Int32 RepeatColumns { get; set; }
		   
			[DataMapping("Width")]
			public Int32 Width { get; set; }
		   
			[DataMapping("Height")]
			public Int32 Height { get; set; }
		   
			[DataMapping("AdvHtml")]
			public String AdvHtml { get; set; }
		   
			[DataMapping("IsOne")]
			public Boolean IsOne { get; set; }
		   
			[DataMapping("TimeInterval")]
			public Int32 TimeInterval { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		            
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
		/// Entity_SYS_MailConfig的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_MailConfig
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("UserID")]
			public Int32 UserID { get; set; }
		   
			[DataMapping("Mailaddress")]
			public String Mailaddress { get; set; }
		   
			[DataMapping("Username")]
			public String Username { get; set; }
		   
			[DataMapping("Password")]
			public String Password { get; set; }
		   
			[DataMapping("SMTPServer")]
			public String SMTPServer { get; set; }
		   
			[DataMapping("SMTPPort")]
			public Int32 SMTPPort { get; set; }
		   
			[DataMapping("SMTPSSL")]
			public Boolean SMTPSSL { get; set; }
		   
			[DataMapping("POPServer")]
			public String POPServer { get; set; }
		   
			[DataMapping("POPPort")]
			public Int32 POPPort { get; set; }
		   
			[DataMapping("POPSSL")]
			public Boolean POPSSL { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Advertisement的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Advertisement
		{
			[DataMapping("AdvertisementId")]
			public Int32 AdvertisementId { get; set; }
		   
			[DataMapping("AdvertisementName")]
			public String AdvertisementName { get; set; }
		   
			[DataMapping("AdvPositionId")]
			public Int32 AdvPositionId { get; set; }
		   
			[DataMapping("ContentType")]
			public Int32 ContentType { get; set; }
		   
			[DataMapping("FileUrl")]
			public String FileUrl { get; set; }
		   
			[DataMapping("AlternateText")]
			public String AlternateText { get; set; }
		   
			[DataMapping("NavigateUrl")]
			public String NavigateUrl { get; set; }
		   
			[DataMapping("AdvHtml")]
			public String AdvHtml { get; set; }
		   
			[DataMapping("Impressions")]
			public Int32 Impressions { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("StartDate")]
			public DateTime StartDate { get; set; }
		   
			[DataMapping("EndDate")]
			public DateTime EndDate { get; set; }
		   
			[DataMapping("DayMaxPV")]
			public Int32 DayMaxPV { get; set; }
		   
			[DataMapping("DayMaxIP")]
			public Int32 DayMaxIP { get; set; }
		   
			[DataMapping("CPMPrice")]
			public Decimal CPMPrice { get; set; }
		   
			[DataMapping("AutoStop")]
			public Boolean AutoStop { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("EnterpriseID")]
			public Int32 EnterpriseID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_SYS_Log的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_Log
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("datetime")]
			public DateTime datetime { get; set; }
		   
			[DataMapping("loginfo")]
			public String loginfo { get; set; }
		   
			[DataMapping("Particular")]
			public String Particular { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_SYS_Guestbook的注释
		/// </summary> 
		[Serializable]
		public class Entity_SYS_Guestbook
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("CreateUserID")]
			public Int32 CreateUserID { get; set; }
		   
			[DataMapping("CreateNickName")]
			public String CreateNickName { get; set; }
		   
			[DataMapping("ToUserID")]
			public Int32 ToUserID { get; set; }
		   
			[DataMapping("ToNickName")]
			public String ToNickName { get; set; }
		   
			[DataMapping("CreatorUserIP")]
			public String CreatorUserIP { get; set; }
		   
			[DataMapping("Title")]
			public String Title { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatorEmail")]
			public String CreatorEmail { get; set; }
		   
			[DataMapping("CreatorRegion")]
			public String CreatorRegion { get; set; }
		   
			[DataMapping("CreatorCompany")]
			public String CreatorCompany { get; set; }
		   
			[DataMapping("CreatorPageSite")]
			public String CreatorPageSite { get; set; }
		   
			[DataMapping("CreatorPhone")]
			public String CreatorPhone { get; set; }
		   
			[DataMapping("CreatorQQ")]
			public String CreatorQQ { get; set; }
		   
			[DataMapping("CreatorMsn")]
			public String CreatorMsn { get; set; }
		   
			[DataMapping("CreatorSex")]
			public Boolean CreatorSex { get; set; }
		   
			[DataMapping("HandlerNickName")]
			public String HandlerNickName { get; set; }
		   
			[DataMapping("HandlerUserID")]
			public Int32 HandlerUserID { get; set; }
		   
			[DataMapping("HandlerDate")]
			public DateTime HandlerDate { get; set; }
		   
			[DataMapping("Privacy")]
			public Boolean Privacy { get; set; }
		   
			[DataMapping("ReplyCount")]
			public Int32 ReplyCount { get; set; }
		   
			[DataMapping("ParentID")]
			public Int32 ParentID { get; set; }
		   
			[DataMapping("Status")]
			public Boolean Status { get; set; }
		   
			[DataMapping("ReplyDescription")]
			public String ReplyDescription { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_WebMenuConfig的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_WebMenuConfig
		{
			[DataMapping("MenuID")]
			public Int32 MenuID { get; set; }
		   
			[DataMapping("MenuName")]
			public String MenuName { get; set; }
		   
			[DataMapping("NavURL")]
			public String NavURL { get; set; }
		   
			[DataMapping("MenuTitle")]
			public String MenuTitle { get; set; }
		   
			[DataMapping("MenuType")]
			public Int32 MenuType { get; set; }
		   
			[DataMapping("Target")]
			public Int32 Target { get; set; }
		   
			[DataMapping("IsUsed")]
			public Boolean IsUsed { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("Visible")]
			public Int32 Visible { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Hospital_NormCategory的注释
		/// </summary> 
		[Serializable]
		public class Entity_Hospital_NormCategory
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("CategoryName")]
			public String CategoryName { get; set; }
		   
			[DataMapping("CategoryCode")]
			public String CategoryCode { get; set; }
		   
			[DataMapping("ParentID")]
			public Int32 ParentID { get; set; }
		   
			[DataMapping("Deleted")]
			public String Deleted { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Slide_Item的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Slide_Item
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("SlideID")]
			public Int32 SlideID { get; set; }
		   
			[DataMapping("Name")]
			public String Name { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("Href")]
			public String Href { get; set; }
		   
			[DataMapping("FilePath")]
			public String FilePath { get; set; }
		   
			[DataMapping("Enable")]
			public Boolean Enable { get; set; }
		   
			[DataMapping("sequence")]
			public Int32 sequence { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Poll_Reply的注释
		/// </summary> 
		[Serializable]
		public class Entity_Poll_Reply
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("TopicID")]
			public Int32 TopicID { get; set; }
		   
			[DataMapping("ReContent")]
			public String ReContent { get; set; }
		   
			[DataMapping("ReTime")]
			public DateTime ReTime { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_VideoClass的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_VideoClass
		{
			[DataMapping("VideoClassID")]
			public Int32 VideoClassID { get; set; }
		   
			[DataMapping("VideoClassName")]
			public String VideoClassName { get; set; }
		   
			[DataMapping("ParentID")]
			public Int32 ParentID { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("Path")]
			public String Path { get; set; }
		   
			[DataMapping("Depth")]
			public Int32 Depth { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Slide的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Slide
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("Name")]
			public String Name { get; set; }
		   
			[DataMapping("Width")]
			public Decimal Width { get; set; }
		   
			[DataMapping("Height")]
			public Decimal Height { get; set; }
		   
			[DataMapping("ItemType")]
			public String ItemType { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Hospital_NormItem的注释
		/// </summary> 
		[Serializable]
		public class Entity_Hospital_NormItem
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("ItemCode")]
			public String ItemCode { get; set; }
		   
			[DataMapping("ItremName")]
			public String ItremName { get; set; }
		   
			[DataMapping("ItemCategory")]
			public Int32 ItemCategory { get; set; }
		   
			[DataMapping("ItemCreateTime")]
			public DateTime ItemCreateTime { get; set; }
		   
			[DataMapping("ItemStopTime")]
			public DateTime ItemStopTime { get; set; }
		   
			[DataMapping("ItemStatus")]
			public String ItemStatus { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Poll_Options的注释
		/// </summary> 
		[Serializable]
		public class Entity_Poll_Options
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("Name")]
			public String Name { get; set; }
		   
			[DataMapping("TopicID")]
			public Int32 TopicID { get; set; }
		   
			[DataMapping("isChecked")]
			public Boolean isChecked { get; set; }
		   
			[DataMapping("SubmitNum")]
			public Int32 SubmitNum { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_VideoAlbum的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_VideoAlbum
		{
			[DataMapping("AlbumID")]
			public Int32 AlbumID { get; set; }
		   
			[DataMapping("AlbumName")]
			public String AlbumName { get; set; }
		   
			[DataMapping("CoverVideo")]
			public String CoverVideo { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("LastUpdateUserID")]
			public Int32 LastUpdateUserID { get; set; }
		   
			[DataMapping("LastUpdatedDate")]
			public DateTime LastUpdatedDate { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("Privacy")]
			public Boolean Privacy { get; set; }
		   
			[DataMapping("PvCount")]
			public Int32 PvCount { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Poll_Forms的注释
		/// </summary> 
		[Serializable]
		public class Entity_Poll_Forms
		{
			[DataMapping("FormID")]
			public Int32 FormID { get; set; }
		   
			[DataMapping("Name")]
			public String Name { get; set; }
		   
			[DataMapping("IsActive")]
			public Boolean IsActive { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Poll_Users的注释
		/// </summary> 
		[Serializable]
		public class Entity_Poll_Users
		{
			[DataMapping("UserID")]
			public Int32 UserID { get; set; }
		   
			[DataMapping("UserName")]
			public String UserName { get; set; }
		   
			[DataMapping("Password")]
			public String Password { get; set; }
		   
			[DataMapping("TrueName")]
			public String TrueName { get; set; }
		   
			[DataMapping("Age")]
			public Int32 Age { get; set; }
		   
			[DataMapping("Sex")]
			public String Sex { get; set; }
		   
			[DataMapping("Phone")]
			public String Phone { get; set; }
		   
			[DataMapping("Email")]
			public String Email { get; set; }
		   
			[DataMapping("UserType")]
			public String UserType { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Video的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Video
		{
			[DataMapping("VideoID")]
			public Int32 VideoID { get; set; }
		   
			[DataMapping("Title")]
			public String Title { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("AlbumID")]
			public Int32 AlbumID { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("LastUpdateUserID")]
			public Int32 LastUpdateUserID { get; set; }
		   
			[DataMapping("LastUpdateDate")]
			public DateTime LastUpdateDate { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("VideoClassID")]
			public Int32 VideoClassID { get; set; }
		   
			[DataMapping("IsRecomend")]
			public Boolean IsRecomend { get; set; }
		   
			[DataMapping("ImageUrl")]
			public String ImageUrl { get; set; }
		   
			[DataMapping("ThumbImageUrl")]
			public String ThumbImageUrl { get; set; }
		   
			[DataMapping("NormalImageUrl")]
			public String NormalImageUrl { get; set; }
		   
			[DataMapping("TotalTime")]
			public Int32 TotalTime { get; set; }
		   
			[DataMapping("TotalComment")]
			public Int32 TotalComment { get; set; }
		   
			[DataMapping("TotalFav")]
			public Int32 TotalFav { get; set; }
		   
			[DataMapping("TotalUp")]
			public Int32 TotalUp { get; set; }
		   
			[DataMapping("Reference")]
			public Int32 Reference { get; set; }
		   
			[DataMapping("Tags")]
			public String Tags { get; set; }
		   
			[DataMapping("VideoUrl")]
			public String VideoUrl { get; set; }
		   
			[DataMapping("UrlType")]
			public Int16 UrlType { get; set; }
		   
			[DataMapping("VideoFormat")]
			public String VideoFormat { get; set; }
		   
			[DataMapping("Domain")]
			public String Domain { get; set; }
		   
			[DataMapping("Grade")]
			public Int32 Grade { get; set; }
		   
			[DataMapping("Attachment")]
			public String Attachment { get; set; }
		   
			[DataMapping("Privacy")]
			public Boolean Privacy { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("Remark")]
			public String Remark { get; set; }
		   
			[DataMapping("PVCount")]
			public Int32 PVCount { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Poll_UserPoll的注释
		/// </summary> 
		[Serializable]
		public class Entity_Poll_UserPoll
		{
			[DataMapping("UserID")]
			public Int32 UserID { get; set; }
		   
			[DataMapping("TopicID")]
			public Int32 TopicID { get; set; }
		   
			[DataMapping("OptionID")]
			public Int32 OptionID { get; set; }
		   
			[DataMapping("CreatTime")]
			public DateTime CreatTime { get; set; }
		   
			[DataMapping("UserIP")]
			public String UserIP { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Poll_Topics的注释
		/// </summary> 
		[Serializable]
		public class Entity_Poll_Topics
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("Title")]
			public String Title { get; set; }
		   
			[DataMapping("Type")]
			public Int32 Type { get; set; }
		   
			[DataMapping("FormID")]
			public Int32 FormID { get; set; }
		            
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
		/// Entity_CMS_PhotoClass的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_PhotoClass
		{
			[DataMapping("ClassID")]
			public Int32 ClassID { get; set; }
		   
			[DataMapping("ClassName")]
			public String ClassName { get; set; }
		   
			[DataMapping("ParentId")]
			public Int32 ParentId { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("Path")]
			public String Path { get; set; }
		   
			[DataMapping("Depth")]
			public Int32 Depth { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_PhotoAlbum的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_PhotoAlbum
		{
			[DataMapping("AlbumID")]
			public Int32 AlbumID { get; set; }
		   
			[DataMapping("AlbumName")]
			public String AlbumName { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("CoverPhoto")]
			public Int32 CoverPhoto { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("PVCount")]
			public Int32 PVCount { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("Privacy")]
			public Boolean Privacy { get; set; }
		   
			[DataMapping("LastUpdatedDate")]
			public DateTime LastUpdatedDate { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Hospital_NormValue的注释
		/// </summary> 
		[Serializable]
		public class Entity_Hospital_NormValue
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("NormID")]
			public Int32 NormID { get; set; }
		   
			[DataMapping("DepartmentID")]
			public Int32 DepartmentID { get; set; }
		   
			[DataMapping("Value")]
			public Decimal Value { get; set; }
		   
			[DataMapping("InDate")]
			public DateTime InDate { get; set; }
		   
			[DataMapping("InUser")]
			public Int32 InUser { get; set; }
		   
			[DataMapping("OccurrenceTime")]
			public DateTime OccurrenceTime { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Photo的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Photo
		{
			[DataMapping("PhotoID")]
			public Int32 PhotoID { get; set; }
		   
			[DataMapping("PhotoName")]
			public String PhotoName { get; set; }
		   
			[DataMapping("ImageUrl")]
			public String ImageUrl { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("AlbumID")]
			public Int32 AlbumID { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("PVCount")]
			public Int32 PVCount { get; set; }
		   
			[DataMapping("ClassID")]
			public Int32 ClassID { get; set; }
		   
			[DataMapping("ThumbImageUrl")]
			public String ThumbImageUrl { get; set; }
		   
			[DataMapping("NormalImageUrl")]
			public String NormalImageUrl { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("IsRecomend")]
			public Boolean IsRecomend { get; set; }
		   
			[DataMapping("CommentCount")]
			public Int32 CommentCount { get; set; }
		   
			[DataMapping("Tags")]
			public String Tags { get; set; }
		   
			[DataMapping("FavouriteCount")]
			public Int32 FavouriteCount { get; set; }
		            
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
		/// Entity_CMS_ContentClass的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_ContentClass
		{
			[DataMapping("ClassID")]
			public Int32 ClassID { get; set; }
		   
			[DataMapping("ClassName")]
			public String ClassName { get; set; }
		   
			[DataMapping("ClassIndex")]
			public String ClassIndex { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("ParentId")]
			public Int32 ParentId { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("AllowSubclass")]
			public Boolean AllowSubclass { get; set; }
		   
			[DataMapping("AllowAddContent")]
			public Boolean AllowAddContent { get; set; }
		   
			[DataMapping("ImageUrl")]
			public String ImageUrl { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("Keywords")]
			public String Keywords { get; set; }
		   
			[DataMapping("ClassTypeID")]
			public Int32 ClassTypeID { get; set; }
		   
			[DataMapping("ClassModel")]
			public Int16 ClassModel { get; set; }
		   
			[DataMapping("PageModelName")]
			public String PageModelName { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("Path")]
			public String Path { get; set; }
		   
			[DataMapping("Depth")]
			public Int32 Depth { get; set; }
		   
			[DataMapping("Remark")]
			public String Remark { get; set; }
		   
			[DataMapping("Meta_Title")]
			public String Meta_Title { get; set; }
		   
			[DataMapping("Meta_Description")]
			public String Meta_Description { get; set; }
		   
			[DataMapping("Meta_Keywords")]
			public String Meta_Keywords { get; set; }
		   
			[DataMapping("SeoUrl")]
			public String SeoUrl { get; set; }
		   
			[DataMapping("SeoImageAlt")]
			public String SeoImageAlt { get; set; }
		   
			[DataMapping("SeoImageTitle")]
			public String SeoImageTitle { get; set; }
		   
			[DataMapping("IndexChar")]
			public String IndexChar { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Product_Class的注释
		/// </summary> 
		[Serializable]
		public class Entity_Product_Class
		{
			[DataMapping("ClassID")]
			public Int32 ClassID { get; set; }
		   
			[DataMapping("ClassName")]
			public String ClassName { get; set; }
		   
			[DataMapping("ClassIndex")]
			public String ClassIndex { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("ParentId")]
			public Int32 ParentId { get; set; }
		   
			[DataMapping("Activity")]
			public Boolean Activity { get; set; }
		   
			[DataMapping("AllowAddContent")]
			public Boolean AllowAddContent { get; set; }
		   
			[DataMapping("ImageUrl")]
			public String ImageUrl { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("Keywords")]
			public String Keywords { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("LastEditDate")]
			public DateTime LastEditDate { get; set; }
		   
			[DataMapping("LastEditUserID")]
			public Int32 LastEditUserID { get; set; }
		   
			[DataMapping("Path")]
			public String Path { get; set; }
		   
			[DataMapping("Depth")]
			public Int32 Depth { get; set; }
		   
			[DataMapping("Remark")]
			public String Remark { get; set; }
		   
			[DataMapping("Meta_Title")]
			public String Meta_Title { get; set; }
		   
			[DataMapping("Meta_Description")]
			public String Meta_Description { get; set; }
		   
			[DataMapping("Meta_Keywords")]
			public String Meta_Keywords { get; set; }
		   
			[DataMapping("SeoUrl")]
			public String SeoUrl { get; set; }
		   
			[DataMapping("SeoImageAlt")]
			public String SeoImageAlt { get; set; }
		   
			[DataMapping("SeoImageTitle")]
			public String SeoImageTitle { get; set; }
		   
			[DataMapping("IndexChar")]
			public String IndexChar { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_Product_Item的注释
		/// </summary> 
		[Serializable]
		public class Entity_Product_Item
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("PName")]
			public String PName { get; set; }
		   
			[DataMapping("SubPName")]
			public String SubPName { get; set; }
		   
			[DataMapping("Summary")]
			public String Summary { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("ImageUrl")]
			public String ImageUrl { get; set; }
		   
			[DataMapping("ThumbImageUrl")]
			public String ThumbImageUrl { get; set; }
		   
			[DataMapping("NormalImageUrl")]
			public String NormalImageUrl { get; set; }
		   
			[DataMapping("Price")]
			public Decimal Price { get; set; }
		   
			[DataMapping("DiscountPrice")]
			public Decimal DiscountPrice { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("LastEditUserID")]
			public Int32 LastEditUserID { get; set; }
		   
			[DataMapping("LastEditDate")]
			public DateTime LastEditDate { get; set; }
		   
			[DataMapping("LinkUrl")]
			public String LinkUrl { get; set; }
		   
			[DataMapping("PvCount")]
			public Int32 PvCount { get; set; }
		   
			[DataMapping("Deleted")]
			public Boolean Deleted { get; set; }
		   
			[DataMapping("ClassID")]
			public Int32 ClassID { get; set; }
		   
			[DataMapping("Keywords")]
			public String Keywords { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("IsRecomend")]
			public Boolean IsRecomend { get; set; }
		   
			[DataMapping("IsHot")]
			public Boolean IsHot { get; set; }
		   
			[DataMapping("IsColor")]
			public Boolean IsColor { get; set; }
		   
			[DataMapping("IsTop")]
			public Boolean IsTop { get; set; }
		   
			[DataMapping("Attachment")]
			public String Attachment { get; set; }
		   
			[DataMapping("Remary")]
			public String Remary { get; set; }
		   
			[DataMapping("TotalComment")]
			public Int32 TotalComment { get; set; }
		   
			[DataMapping("TotalSupport")]
			public Int32 TotalSupport { get; set; }
		   
			[DataMapping("TotalFav")]
			public Int32 TotalFav { get; set; }
		   
			[DataMapping("TotalShare")]
			public Int32 TotalShare { get; set; }
		   
			[DataMapping("BeFrom")]
			public String BeFrom { get; set; }
		   
			[DataMapping("FileName")]
			public String FileName { get; set; }
		   
			[DataMapping("Meta_Title")]
			public String Meta_Title { get; set; }
		   
			[DataMapping("Meta_Description")]
			public String Meta_Description { get; set; }
		   
			[DataMapping("Meta_Keywords")]
			public String Meta_Keywords { get; set; }
		   
			[DataMapping("SeoUrl")]
			public String SeoUrl { get; set; }
		   
			[DataMapping("SeoImageAlt")]
			public String SeoImageAlt { get; set; }
		   
			[DataMapping("SeoImageTitle")]
			public String SeoImageTitle { get; set; }
		   
			[DataMapping("StaticUrl")]
			public String StaticUrl { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Comment的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Comment
		{
			[DataMapping("ID")]
			public Int32 ID { get; set; }
		   
			[DataMapping("ContentId")]
			public Int32 ContentId { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("ReplyCount")]
			public Int32 ReplyCount { get; set; }
		   
			[DataMapping("ParentID")]
			public Int32 ParentID { get; set; }
		   
			[DataMapping("TypeID")]
			public Int16 TypeID { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("IsRead")]
			public Boolean IsRead { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Entity_CMS_Content的注释
		/// </summary> 
		[Serializable]
		public class Entity_CMS_Content
		{
			[DataMapping("ContentID")]
			public Int32 ContentID { get; set; }
		   
			[DataMapping("Title")]
			public String Title { get; set; }
		   
			[DataMapping("SubTitle")]
			public String SubTitle { get; set; }
		   
			[DataMapping("Summary")]
			public String Summary { get; set; }
		   
			[DataMapping("Description")]
			public String Description { get; set; }
		   
			[DataMapping("ImageUrl")]
			public String ImageUrl { get; set; }
		   
			[DataMapping("ThumbImageUrl")]
			public String ThumbImageUrl { get; set; }
		   
			[DataMapping("NormalImageUrl")]
			public String NormalImageUrl { get; set; }
		   
			[DataMapping("CreatedDate")]
			public DateTime CreatedDate { get; set; }
		   
			[DataMapping("CreatedUserID")]
			public Int32 CreatedUserID { get; set; }
		   
			[DataMapping("LastEditUserID")]
			public Int32 LastEditUserID { get; set; }
		   
			[DataMapping("LastEditDate")]
			public DateTime LastEditDate { get; set; }
		   
			[DataMapping("LinkUrl")]
			public String LinkUrl { get; set; }
		   
			[DataMapping("PvCount")]
			public Int32 PvCount { get; set; }
		   
			[DataMapping("State")]
			public Boolean State { get; set; }
		   
			[DataMapping("ClassID")]
			public Int32 ClassID { get; set; }
		   
			[DataMapping("Keywords")]
			public String Keywords { get; set; }
		   
			[DataMapping("Sequence")]
			public Int32 Sequence { get; set; }
		   
			[DataMapping("IsRecomend")]
			public Boolean IsRecomend { get; set; }
		   
			[DataMapping("IsHot")]
			public Boolean IsHot { get; set; }
		   
			[DataMapping("IsColor")]
			public Boolean IsColor { get; set; }
		   
			[DataMapping("IsTop")]
			public Boolean IsTop { get; set; }
		   
			[DataMapping("Attachment")]
			public String Attachment { get; set; }
		   
			[DataMapping("Remary")]
			public String Remary { get; set; }
		   
			[DataMapping("TotalComment")]
			public Int32 TotalComment { get; set; }
		   
			[DataMapping("TotalSupport")]
			public Int32 TotalSupport { get; set; }
		   
			[DataMapping("TotalFav")]
			public Int32 TotalFav { get; set; }
		   
			[DataMapping("TotalShare")]
			public Int32 TotalShare { get; set; }
		   
			[DataMapping("BeFrom")]
			public String BeFrom { get; set; }
		   
			[DataMapping("FileName")]
			public String FileName { get; set; }
		   
			[DataMapping("Meta_Title")]
			public String Meta_Title { get; set; }
		   
			[DataMapping("Meta_Description")]
			public String Meta_Description { get; set; }
		   
			[DataMapping("Meta_Keywords")]
			public String Meta_Keywords { get; set; }
		   
			[DataMapping("SeoUrl")]
			public String SeoUrl { get; set; }
		   
			[DataMapping("SeoImageAlt")]
			public String SeoImageAlt { get; set; }
		   
			[DataMapping("SeoImageTitle")]
			public String SeoImageTitle { get; set; }
		   
			[DataMapping("StaticUrl")]
			public String StaticUrl { get; set; }
		            
		}             
	
}