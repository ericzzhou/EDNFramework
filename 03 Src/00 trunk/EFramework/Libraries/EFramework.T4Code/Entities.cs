
using System;
using System.Data;
namespace MyProject.Entities 
{     
	public class ALL
	{
		SYS_FilterWordsEntity SYS_FilterWords = new SYS_FilterWordsEntity();
		Account_UserTypeEntity Account_UserType = new Account_UserTypeEntity();
		Account_UserRolesEntity Account_UserRoles = new Account_UserRolesEntity();
		Account_UserBindEntity Account_UserBind = new Account_UserBindEntity();
		SYS_EmailQueueEntity SYS_EmailQueue = new SYS_EmailQueueEntity();
		CMS_FLinksEntity CMS_FLinks = new CMS_FLinksEntity();
		SYS_ConfigTypeEntity SYS_ConfigType = new SYS_ConfigTypeEntity();
		SYS_ConfigContentEntity SYS_ConfigContent = new SYS_ConfigContentEntity();
		Account_RoleEntity Account_Role = new Account_RoleEntity();
		Account_PermissionCategoriesEntity Account_PermissionCategories = new Account_PermissionCategoriesEntity();
		SYS_UserLogEntity SYS_UserLog = new SYS_UserLogEntity();
		Account_PermissionEntity Account_Permission = new Account_PermissionEntity();
		SYS_SiteSettingsEntity SYS_SiteSettings = new SYS_SiteSettingsEntity();
		CMS_ClassTypeEntity CMS_ClassType = new CMS_ClassTypeEntity();
		CMS_BrandEntity CMS_Brand = new CMS_BrandEntity();
		SYS_SiteMessageLogEntity SYS_SiteMessageLog = new SYS_SiteMessageLogEntity();
		SYS_SiteMessageEntity SYS_SiteMessage = new SYS_SiteMessageEntity();
		CMS_AdvertisePositionEntity CMS_AdvertisePosition = new CMS_AdvertisePositionEntity();
		Account_User_LogonLogEntity Account_User_LogonLog = new Account_User_LogonLogEntity();
		SYS_MailConfigEntity SYS_MailConfig = new SYS_MailConfigEntity();
		CMS_AdvertisementEntity CMS_Advertisement = new CMS_AdvertisementEntity();
		SYS_LogEntity SYS_Log = new SYS_LogEntity();
		SYS_GuestbookEntity SYS_Guestbook = new SYS_GuestbookEntity();
		CMS_WebMenuConfigEntity CMS_WebMenuConfig = new CMS_WebMenuConfigEntity();
		Hospital_NormCategoryEntity Hospital_NormCategory = new Hospital_NormCategoryEntity();
		CMS_Slide_ItemEntity CMS_Slide_Item = new CMS_Slide_ItemEntity();
		Poll_ReplyEntity Poll_Reply = new Poll_ReplyEntity();
		CMS_VideoClassEntity CMS_VideoClass = new CMS_VideoClassEntity();
		Hospital_NormItemEntity Hospital_NormItem = new Hospital_NormItemEntity();
		Poll_OptionsEntity Poll_Options = new Poll_OptionsEntity();
		CMS_VideoAlbumEntity CMS_VideoAlbum = new CMS_VideoAlbumEntity();
		Poll_FormsEntity Poll_Forms = new Poll_FormsEntity();
		Poll_UsersEntity Poll_Users = new Poll_UsersEntity();
		CMS_VideoEntity CMS_Video = new CMS_VideoEntity();
		CMS_SlideEntity CMS_Slide = new CMS_SlideEntity();
		Poll_UserPollEntity Poll_UserPoll = new Poll_UserPollEntity();
		Poll_TopicsEntity Poll_Topics = new Poll_TopicsEntity();
		Account_RolePermissionsActionEntity Account_RolePermissionsAction = new Account_RolePermissionsActionEntity();
		Account_UserEntity Account_User = new Account_UserEntity();
		SYS_FloatADEntity SYS_FloatAD = new SYS_FloatADEntity();
		SYS_ErrorLogEntity SYS_ErrorLog = new SYS_ErrorLogEntity();
		CMS_PhotoClassEntity CMS_PhotoClass = new CMS_PhotoClassEntity();
		CMS_PhotoAlbumEntity CMS_PhotoAlbum = new CMS_PhotoAlbumEntity();
		SYS_SingleJumpADEntity SYS_SingleJumpAD = new SYS_SingleJumpADEntity();
		Product_ClassEntity Product_Class = new Product_ClassEntity();
		Hospital_NormValueEntity Hospital_NormValue = new Hospital_NormValueEntity();
		CMS_PhotoEntity CMS_Photo = new CMS_PhotoEntity();
		Account_DepartmentEntity Account_Department = new Account_DepartmentEntity();
		Account_PermissionActionsEntity Account_PermissionActions = new Account_PermissionActionsEntity();
		Account_RolePermissionsEntity Account_RolePermissions = new Account_RolePermissionsEntity();
		CMS_ContentClassEntity CMS_ContentClass = new CMS_ContentClassEntity();
		Product_ItemEntity Product_Item = new Product_ItemEntity();
		CMS_CommentEntity CMS_Comment = new CMS_CommentEntity();
		CMS_ContentEntity CMS_Content = new CMS_ContentEntity();
	}

  

		/// <summary> 
		/// SYS_FilterWordsEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_FilterWordsEntity
		{
			public Int32 FilterId { get; set; }
		   
			public String WordPattern { get; set; }
		   
			public Boolean IsForbid { get; set; }
		   
			public Boolean IsMod { get; set; }
		   
			public String RepalceWord { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_UserTypeEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_UserTypeEntity
		{
			public String UserType { get; set; }
		   
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_UserRolesEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_UserRolesEntity
		{
			public Int32 UserID { get; set; }
		   
			public Int32 RoleID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_UserBindEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_UserBindEntity
		{
			public Int32 BindId { get; set; }
		   
			public Int32 UserId { get; set; }
		   
			public String Token { get; set; }
		   
			public Int32 MediaUserID { get; set; }
		   
			public String MediaNickName { get; set; }
		   
			public Int32 MediaID { get; set; }
		   
			public Boolean iHome { get; set; }
		   
			public Boolean Comment { get; set; }
		   
			public Boolean GroupTopic { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_EmailQueueEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_EmailQueueEntity
		{
			public Int32 EmailId { get; set; }
		   
			public Int32 EmailPriority { get; set; }
		   
			public Boolean IsBodyHtml { get; set; }
		   
			public String EmailTo { get; set; }
		   
			public String EmailCc { get; set; }
		   
			public String EmailBcc { get; set; }
		   
			public String EmailFrom { get; set; }
		   
			public String EmailSubject { get; set; }
		   
			public String EmailBody { get; set; }
		   
			public DateTime NextTryTime { get; set; }
		   
			public Int32 NumberOfTries { get; set; }
		   
			public Boolean Successed { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_FLinksEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_FLinksEntity
		{
			public Int32 ID { get; set; }
		   
			public String Name { get; set; }
		   
			public String ImgUrl { get; set; }
		   
			public String LinkUrl { get; set; }
		   
			public String LinkDesc { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Int32 OrderID { get; set; }
		   
			public String ContactPerson { get; set; }
		   
			public String Email { get; set; }
		   
			public String TelPhone { get; set; }
		   
			public Int16 TypeID { get; set; }
		   
			public Boolean IsDisplay { get; set; }
		   
			public Int32 ImgWidth { get; set; }
		   
			public Int32 ImgHeight { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_ConfigTypeEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_ConfigTypeEntity
		{
			public Int32 KeyType { get; set; }
		   
			public String TypeName { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_ConfigContentEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_ConfigContentEntity
		{
			public Int32 ID { get; set; }
		   
			public String Keyname { get; set; }
		   
			public String Value { get; set; }
		   
			public Int32 KeyType { get; set; }
		   
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_RoleEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_RoleEntity
		{
			public Int32 RoleID { get; set; }
		   
			public String RoleName { get; set; }
		   
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_PermissionCategoriesEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_PermissionCategoriesEntity
		{
			public Int32 CategoryID { get; set; }
		   
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_UserLogEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_UserLogEntity
		{
			public Int32 ID { get; set; }
		   
			public DateTime OPTime { get; set; }
		   
			public String Url { get; set; }
		   
			public String OPInfo { get; set; }
		   
			public String UserName { get; set; }
		   
			public String UserType { get; set; }
		   
			public String UserIP { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_PermissionEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_PermissionEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 ParentID { get; set; }
		   
			public Int32 CategoryID { get; set; }
		   
			public String PermissionCode { get; set; }
		   
			public String PermissionName { get; set; }
		   
			public String Description { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public DateTime CreateDate { get; set; }
		   
			public String RequestUrl { get; set; }
		   
			public String ico { get; set; }
		   
			public Boolean HasSon { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_SiteSettingsEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_SiteSettingsEntity
		{
			public Int32 SettingsId { get; set; }
		   
			public Boolean Disabled { get; set; }
		   
			public String Version { get; set; }
		   
			public String SettingsXML { get; set; }
		   
			public Guid SettingsKey { get; set; }
		   
			public String ApplicationName { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_ClassTypeEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_ClassTypeEntity
		{
			public Int32 ClassTypeID { get; set; }
		   
			public String ClassTypeName { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_BrandEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_BrandEntity
		{
			public Int32 BrandID { get; set; }
		   
			public String BrandName { get; set; }
		   
			public String BrandLogo { get; set; }
		   
			public String BrandDesc { get; set; }
		   
			public Int32 EnterpriseID { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Int32 Orders { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_SiteMessageLogEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_SiteMessageLogEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 MessageID { get; set; }
		   
			public String MessageType { get; set; }
		   
			public String MessageState { get; set; }
		   
			public Int32 ReceiverID { get; set; }
		   
			public String Ext1 { get; set; }
		   
			public String Ext2 { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_SiteMessageEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_SiteMessageEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 SenderID { get; set; }
		   
			public Int32 ReceiverID { get; set; }
		   
			public String Title { get; set; }
		   
			public String Content { get; set; }
		   
			public String MsgType { get; set; }
		   
			public DateTime SendTime { get; set; }
		   
			public DateTime ReadTime { get; set; }
		   
			public Boolean ReceiverIsRead { get; set; }
		   
			public Boolean SenderIsDel { get; set; }
		   
			public Boolean ReaderIsDel { get; set; }
		   
			public String Ext1 { get; set; }
		   
			public String Ext2 { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_AdvertisePositionEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_AdvertisePositionEntity
		{
			public Int32 AdvPositionId { get; set; }
		   
			public String AdvPositionName { get; set; }
		   
			public Int32 ShowType { get; set; }
		   
			public Int32 RepeatColumns { get; set; }
		   
			public Int32 Width { get; set; }
		   
			public Int32 Height { get; set; }
		   
			public String AdvHtml { get; set; }
		   
			public Boolean IsOne { get; set; }
		   
			public Int32 TimeInterval { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_User_LogonLogEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_User_LogonLogEntity
		{
			public Int32 ID { get; set; }
		   
			public String UserName { get; set; }
		   
			public DateTime LogonTime { get; set; }
		   
			public String Status { get; set; }
		   
			public String StatusDescription { get; set; }
		   
			public String LogonIP { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_MailConfigEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_MailConfigEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 UserID { get; set; }
		   
			public String Mailaddress { get; set; }
		   
			public String Username { get; set; }
		   
			public String Password { get; set; }
		   
			public String SMTPServer { get; set; }
		   
			public Int32 SMTPPort { get; set; }
		   
			public Boolean SMTPSSL { get; set; }
		   
			public String POPServer { get; set; }
		   
			public Int32 POPPort { get; set; }
		   
			public Boolean POPSSL { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_AdvertisementEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_AdvertisementEntity
		{
			public Int32 AdvertisementId { get; set; }
		   
			public String AdvertisementName { get; set; }
		   
			public Int32 AdvPositionId { get; set; }
		   
			public Int32 ContentType { get; set; }
		   
			public String FileUrl { get; set; }
		   
			public String AlternateText { get; set; }
		   
			public String NavigateUrl { get; set; }
		   
			public String AdvHtml { get; set; }
		   
			public Int32 Impressions { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public Boolean State { get; set; }
		   
			public DateTime StartDate { get; set; }
		   
			public DateTime EndDate { get; set; }
		   
			public Int32 DayMaxPV { get; set; }
		   
			public Int32 DayMaxIP { get; set; }
		   
			public Decimal CPMPrice { get; set; }
		   
			public Boolean AutoStop { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Int32 EnterpriseID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_LogEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_LogEntity
		{
			public Int32 ID { get; set; }
		   
			public DateTime datetime { get; set; }
		   
			public String loginfo { get; set; }
		   
			public String Particular { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_GuestbookEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_GuestbookEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 CreateUserID { get; set; }
		   
			public String CreateNickName { get; set; }
		   
			public Int32 ToUserID { get; set; }
		   
			public String ToNickName { get; set; }
		   
			public String CreatorUserIP { get; set; }
		   
			public String Title { get; set; }
		   
			public String Description { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public String CreatorEmail { get; set; }
		   
			public String CreatorRegion { get; set; }
		   
			public String CreatorCompany { get; set; }
		   
			public String CreatorPageSite { get; set; }
		   
			public String CreatorPhone { get; set; }
		   
			public String CreatorQQ { get; set; }
		   
			public String CreatorMsn { get; set; }
		   
			public Boolean CreatorSex { get; set; }
		   
			public String HandlerNickName { get; set; }
		   
			public Int32 HandlerUserID { get; set; }
		   
			public DateTime HandlerDate { get; set; }
		   
			public Boolean Privacy { get; set; }
		   
			public Int32 ReplyCount { get; set; }
		   
			public Int32 ParentID { get; set; }
		   
			public Boolean Status { get; set; }
		   
			public String ReplyDescription { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_WebMenuConfigEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_WebMenuConfigEntity
		{
			public Int32 MenuID { get; set; }
		   
			public String MenuName { get; set; }
		   
			public String NavURL { get; set; }
		   
			public String MenuTitle { get; set; }
		   
			public Int32 MenuType { get; set; }
		   
			public Int32 Target { get; set; }
		   
			public Boolean IsUsed { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Int32 Visible { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Hospital_NormCategoryEntity 的注释
		/// </summary> 
		[Serializable]
		public class Hospital_NormCategoryEntity
		{
			public Int32 ID { get; set; }
		   
			public String CategoryName { get; set; }
		   
			public String CategoryCode { get; set; }
		   
			public Int32 ParentID { get; set; }
		   
			public String Deleted { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_Slide_ItemEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_Slide_ItemEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 SlideID { get; set; }
		   
			public String Name { get; set; }
		   
			public String Description { get; set; }
		   
			public String Href { get; set; }
		   
			public String FilePath { get; set; }
		   
			public Boolean Enable { get; set; }
		   
			public Int32 sequence { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Poll_ReplyEntity 的注释
		/// </summary> 
		[Serializable]
		public class Poll_ReplyEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 TopicID { get; set; }
		   
			public String ReContent { get; set; }
		   
			public DateTime ReTime { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_VideoClassEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_VideoClassEntity
		{
			public Int32 VideoClassID { get; set; }
		   
			public String VideoClassName { get; set; }
		   
			public Int32 ParentID { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public String Path { get; set; }
		   
			public Int32 Depth { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Hospital_NormItemEntity 的注释
		/// </summary> 
		[Serializable]
		public class Hospital_NormItemEntity
		{
			public Int32 ID { get; set; }
		   
			public String ItemCode { get; set; }
		   
			public String ItremName { get; set; }
		   
			public Int32 ItemCategory { get; set; }
		   
			public DateTime ItemCreateTime { get; set; }
		   
			public DateTime ItemStopTime { get; set; }
		   
			public String ItemStatus { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Poll_OptionsEntity 的注释
		/// </summary> 
		[Serializable]
		public class Poll_OptionsEntity
		{
			public Int32 ID { get; set; }
		   
			public String Name { get; set; }
		   
			public Int32 TopicID { get; set; }
		   
			public Boolean isChecked { get; set; }
		   
			public Int32 SubmitNum { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_VideoAlbumEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_VideoAlbumEntity
		{
			public Int32 AlbumID { get; set; }
		   
			public String AlbumName { get; set; }
		   
			public String CoverVideo { get; set; }
		   
			public String Description { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 LastUpdateUserID { get; set; }
		   
			public DateTime LastUpdatedDate { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Boolean Privacy { get; set; }
		   
			public Int32 PvCount { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Poll_FormsEntity 的注释
		/// </summary> 
		[Serializable]
		public class Poll_FormsEntity
		{
			public Int32 FormID { get; set; }
		   
			public String Name { get; set; }
		   
			public Boolean IsActive { get; set; }
		   
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Poll_UsersEntity 的注释
		/// </summary> 
		[Serializable]
		public class Poll_UsersEntity
		{
			public Int32 UserID { get; set; }
		   
			public String UserName { get; set; }
		   
			public String Password { get; set; }
		   
			public String TrueName { get; set; }
		   
			public Int32 Age { get; set; }
		   
			public String Sex { get; set; }
		   
			public String Phone { get; set; }
		   
			public String Email { get; set; }
		   
			public String UserType { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_VideoEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_VideoEntity
		{
			public Int32 VideoID { get; set; }
		   
			public String Title { get; set; }
		   
			public String Description { get; set; }
		   
			public Int32 AlbumID { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 LastUpdateUserID { get; set; }
		   
			public DateTime LastUpdateDate { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Int32 VideoClassID { get; set; }
		   
			public Boolean IsRecomend { get; set; }
		   
			public String ImageUrl { get; set; }
		   
			public String ThumbImageUrl { get; set; }
		   
			public String NormalImageUrl { get; set; }
		   
			public Int32 TotalTime { get; set; }
		   
			public Int32 TotalComment { get; set; }
		   
			public Int32 TotalFav { get; set; }
		   
			public Int32 TotalUp { get; set; }
		   
			public Int32 Reference { get; set; }
		   
			public String Tags { get; set; }
		   
			public String VideoUrl { get; set; }
		   
			public Int16 UrlType { get; set; }
		   
			public String VideoFormat { get; set; }
		   
			public String Domain { get; set; }
		   
			public Int32 Grade { get; set; }
		   
			public String Attachment { get; set; }
		   
			public Boolean Privacy { get; set; }
		   
			public Boolean State { get; set; }
		   
			public String Remark { get; set; }
		   
			public Int32 PVCount { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_SlideEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_SlideEntity
		{
			public Int32 ID { get; set; }
		   
			public String Name { get; set; }
		   
			public Int32 Width { get; set; }
		   
			public Int32 Height { get; set; }
		   
			public String ItemType { get; set; }
		   
			public Int32 delay { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Poll_UserPollEntity 的注释
		/// </summary> 
		[Serializable]
		public class Poll_UserPollEntity
		{
			public Int32 UserID { get; set; }
		   
			public Int32 TopicID { get; set; }
		   
			public Int32 OptionID { get; set; }
		   
			public DateTime CreatTime { get; set; }
		   
			public String UserIP { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Poll_TopicsEntity 的注释
		/// </summary> 
		[Serializable]
		public class Poll_TopicsEntity
		{
			public Int32 ID { get; set; }
		   
			public String Title { get; set; }
		   
			public Int32 Type { get; set; }
		   
			public Int32 FormID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_RolePermissionsActionEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_RolePermissionsActionEntity
		{
			public Guid ARPAID { get; set; }
		   
			public Guid ARPID { get; set; }
		   
			public String ActionCode { get; set; }
		   
			public Int32 RoleID { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_UserEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_UserEntity
		{
			public Int32 UserID { get; set; }
		   
			public String UserName { get; set; }
		   
			public String Password { get; set; }
		   
			public String NickName { get; set; }
		   
			public String TrueName { get; set; }
		   
			public String Sex { get; set; }
		   
			public String Phone { get; set; }
		   
			public String Email { get; set; }
		   
			public Int32 EmployeeID { get; set; }
		   
			public String DepartmentID { get; set; }
		   
			public Boolean Activity { get; set; }
		   
			public String UserType { get; set; }
		   
			public Int32 Style { get; set; }
		   
			public Int32 User_iCreator { get; set; }
		   
			public DateTime User_dateCreate { get; set; }
		   
			public DateTime User_dateValid { get; set; }
		   
			public DateTime User_dateExpire { get; set; }
		   
			public Int32 User_iApprover { get; set; }
		   
			public DateTime User_dateApprove { get; set; }
		   
			public Int32 User_iApproveState { get; set; }
		   
			public String User_cLang { get; set; }
		   
			public String auth_token { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_FloatADEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_FloatADEntity
		{
			public Int32 ID { get; set; }
		   
			public String Name { get; set; }
		   
			public Int32 Left_Width { get; set; }
		   
			public Int32 Left_Height { get; set; }
		   
			public Int32 Left_left { get; set; }
		   
			public Int32 Left_top { get; set; }
		   
			public String Left_Body { get; set; }
		   
			public Boolean Left_Enable { get; set; }
		   
			public Int32 Right_Width { get; set; }
		   
			public Int32 Right_Height { get; set; }
		   
			public Int32 Right_right { get; set; }
		   
			public Int32 Right_top { get; set; }
		   
			public String Right_Body { get; set; }
		   
			public Boolean Right_Enable { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_ErrorLogEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_ErrorLogEntity
		{
			public Int32 ID { get; set; }
		   
			public DateTime OPTime { get; set; }
		   
			public String Url { get; set; }
		   
			public String Loginfo { get; set; }
		   
			public String StackTrace { get; set; }
		   
			public String ErrorType { get; set; }
		   
			public String Domain { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_PhotoClassEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_PhotoClassEntity
		{
			public Int32 ClassID { get; set; }
		   
			public String ClassName { get; set; }
		   
			public Int32 ParentId { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public String Path { get; set; }
		   
			public Int32 Depth { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_PhotoAlbumEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_PhotoAlbumEntity
		{
			public Int32 AlbumID { get; set; }
		   
			public String AlbumName { get; set; }
		   
			public String Description { get; set; }
		   
			public Int32 CoverPhoto { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 PVCount { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Boolean Privacy { get; set; }
		   
			public DateTime LastUpdatedDate { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// SYS_SingleJumpADEntity 的注释
		/// </summary> 
		[Serializable]
		public class SYS_SingleJumpADEntity
		{
			public Int32 ID { get; set; }
		   
			public String Name { get; set; }
		   
			public Int32 Width { get; set; }
		   
			public Int32 Height { get; set; }
		   
			public Boolean Enable { get; set; }
		   
			public String ContentType { get; set; }
		   
			public String Content { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Product_ClassEntity 的注释
		/// </summary> 
		[Serializable]
		public class Product_ClassEntity
		{
			public Int32 ClassID { get; set; }
		   
			public String ClassName { get; set; }
		   
			public String ClassIndex { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Int32 ParentId { get; set; }
		   
			public Boolean Activity { get; set; }
		   
			public Boolean AllowAddContent { get; set; }
		   
			public String ImageUrl { get; set; }
		   
			public String Description { get; set; }
		   
			public String Keywords { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public DateTime LastEditDate { get; set; }
		   
			public Int32 LastEditUserID { get; set; }
		   
			public String Path { get; set; }
		   
			public Int32 Depth { get; set; }
		   
			public String Remark { get; set; }
		   
			public String Meta_Title { get; set; }
		   
			public String Meta_Description { get; set; }
		   
			public String Meta_Keywords { get; set; }
		   
			public String SeoUrl { get; set; }
		   
			public String SeoImageAlt { get; set; }
		   
			public String SeoImageTitle { get; set; }
		   
			public String IndexChar { get; set; }
		   
			public String Domain { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Hospital_NormValueEntity 的注释
		/// </summary> 
		[Serializable]
		public class Hospital_NormValueEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 NormID { get; set; }
		   
			public Int32 DepartmentID { get; set; }
		   
			public Decimal Value { get; set; }
		   
			public DateTime InDate { get; set; }
		   
			public Int32 InUser { get; set; }
		   
			public DateTime OccurrenceTime { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_PhotoEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_PhotoEntity
		{
			public Int32 PhotoID { get; set; }
		   
			public String PhotoName { get; set; }
		   
			public String ImageUrl { get; set; }
		   
			public String Description { get; set; }
		   
			public Int32 AlbumID { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 PVCount { get; set; }
		   
			public Int32 ClassID { get; set; }
		   
			public String ThumbImageUrl { get; set; }
		   
			public String NormalImageUrl { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Boolean IsRecomend { get; set; }
		   
			public Int32 CommentCount { get; set; }
		   
			public String Tags { get; set; }
		   
			public Int32 FavouriteCount { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_DepartmentEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_DepartmentEntity
		{
			public Int32 ID { get; set; }
		   
			public String Code { get; set; }
		   
			public String Name { get; set; }
		   
			public String ShortName { get; set; }
		   
			public Int32 ParentID { get; set; }
		   
			public String Type { get; set; }
		   
			public String Manager { get; set; }
		   
			public String Manager2 { get; set; }
		   
			public String Phone { get; set; }
		   
			public String ExtNumber { get; set; }
		   
			public String Fax { get; set; }
		   
			public String Status { get; set; }
		   
			public String Description { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_PermissionActionsEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_PermissionActionsEntity
		{
			public Int32 ActionID { get; set; }
		   
			public String ActionCode { get; set; }
		   
			public String Description { get; set; }
		   
			public String PermissionCode { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Account_RolePermissionsEntity 的注释
		/// </summary> 
		[Serializable]
		public class Account_RolePermissionsEntity
		{
			public Guid ARPID { get; set; }
		   
			public Int32 RoleID { get; set; }
		   
			public String PermissionCode { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_ContentClassEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_ContentClassEntity
		{
			public Int32 ClassID { get; set; }
		   
			public String ClassName { get; set; }
		   
			public String ClassIndex { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Int32 ParentId { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Boolean AllowSubclass { get; set; }
		   
			public Boolean AllowAddContent { get; set; }
		   
			public String ImageUrl { get; set; }
		   
			public String Description { get; set; }
		   
			public String Keywords { get; set; }
		   
			public Int32 ClassTypeID { get; set; }
		   
			public Int16 ClassModel { get; set; }
		   
			public String PageModelName { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public String Path { get; set; }
		   
			public Int32 Depth { get; set; }
		   
			public String Remark { get; set; }
		   
			public String Meta_Title { get; set; }
		   
			public String Meta_Description { get; set; }
		   
			public String Meta_Keywords { get; set; }
		   
			public String SeoUrl { get; set; }
		   
			public String SeoImageAlt { get; set; }
		   
			public String SeoImageTitle { get; set; }
		   
			public String IndexChar { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// Product_ItemEntity 的注释
		/// </summary> 
		[Serializable]
		public class Product_ItemEntity
		{
			public Int32 ID { get; set; }
		   
			public String PName { get; set; }
		   
			public String SubPName { get; set; }
		   
			public String Summary { get; set; }
		   
			public String Description { get; set; }
		   
			public String ImageUrl { get; set; }
		   
			public String ThumbImageUrl { get; set; }
		   
			public String NormalImageUrl { get; set; }
		   
			public Decimal Price { get; set; }
		   
			public Decimal DiscountPrice { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public Int32 LastEditUserID { get; set; }
		   
			public DateTime LastEditDate { get; set; }
		   
			public String LinkUrl { get; set; }
		   
			public Int32 PvCount { get; set; }
		   
			public Boolean Deleted { get; set; }
		   
			public Int32 ClassID { get; set; }
		   
			public String Keywords { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Boolean IsRecomend { get; set; }
		   
			public Boolean IsHot { get; set; }
		   
			public Boolean IsColor { get; set; }
		   
			public Boolean IsTop { get; set; }
		   
			public String Attachment { get; set; }
		   
			public String Remary { get; set; }
		   
			public Int32 TotalComment { get; set; }
		   
			public Int32 TotalSupport { get; set; }
		   
			public Int32 TotalFav { get; set; }
		   
			public Int32 TotalShare { get; set; }
		   
			public String BeFrom { get; set; }
		   
			public String FileName { get; set; }
		   
			public String Meta_Title { get; set; }
		   
			public String Meta_Description { get; set; }
		   
			public String Meta_Keywords { get; set; }
		   
			public String SeoUrl { get; set; }
		   
			public String SeoImageAlt { get; set; }
		   
			public String SeoImageTitle { get; set; }
		   
			public String StaticUrl { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_CommentEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_CommentEntity
		{
			public Int32 ID { get; set; }
		   
			public Int32 ContentId { get; set; }
		   
			public String Description { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public Int32 ReplyCount { get; set; }
		   
			public Int32 ParentID { get; set; }
		   
			public Int16 TypeID { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Boolean IsRead { get; set; }
		            
		}             
	
  

		/// <summary> 
		/// CMS_ContentEntity 的注释
		/// </summary> 
		[Serializable]
		public class CMS_ContentEntity
		{
			public Int32 ContentID { get; set; }
		   
			public String Title { get; set; }
		   
			public String SubTitle { get; set; }
		   
			public String Summary { get; set; }
		   
			public String Description { get; set; }
		   
			public String ImageUrl { get; set; }
		   
			public String ThumbImageUrl { get; set; }
		   
			public String NormalImageUrl { get; set; }
		   
			public DateTime CreatedDate { get; set; }
		   
			public Int32 CreatedUserID { get; set; }
		   
			public Int32 LastEditUserID { get; set; }
		   
			public DateTime LastEditDate { get; set; }
		   
			public String LinkUrl { get; set; }
		   
			public Int32 PvCount { get; set; }
		   
			public Boolean State { get; set; }
		   
			public Int32 ClassID { get; set; }
		   
			public String Keywords { get; set; }
		   
			public Int32 Sequence { get; set; }
		   
			public Boolean IsRecomend { get; set; }
		   
			public Boolean IsHot { get; set; }
		   
			public Boolean IsColor { get; set; }
		   
			public Boolean IsTop { get; set; }
		   
			public String Attachment { get; set; }
		   
			public String Remary { get; set; }
		   
			public Int32 TotalComment { get; set; }
		   
			public Int32 TotalSupport { get; set; }
		   
			public Int32 TotalFav { get; set; }
		   
			public Int32 TotalShare { get; set; }
		   
			public String BeFrom { get; set; }
		   
			public String FileName { get; set; }
		   
			public String Meta_Title { get; set; }
		   
			public String Meta_Description { get; set; }
		   
			public String Meta_Keywords { get; set; }
		   
			public String SeoUrl { get; set; }
		   
			public String SeoImageAlt { get; set; }
		   
			public String SeoImageTitle { get; set; }
		   
			public String StaticUrl { get; set; }
		            
		}             
	
}