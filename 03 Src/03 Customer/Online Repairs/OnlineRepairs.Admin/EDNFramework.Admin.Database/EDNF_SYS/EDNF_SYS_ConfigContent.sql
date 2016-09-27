GO

CREATE TABLE [EDNF_SYS_ConfigContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Keyname] [varchar](50) NOT NULL,
	[Value] [varchar](max) NOT NULL,
	[KeyType] [int] NOT NULL DEFAULT(0),-- -2：不展示给用户看  -1：可修改，不可删除
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_EDNF_SYS_ConfigContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -2,N'AdminVirtualPath',N'',N'Admin 站点目录，如果是根站点，则为空')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -2,N'Reserved_AdminID',N'1',N'系统预留管理员帐号ID，不允许删除')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -2,N'Reserved_RoleIDs',N'1,2',N'系统预留的角色(逗号分隔)')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -2,N'Reserved_PermIDs',N'2,87,88',N'系统保留的权限(逗号分隔)')

INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_Password',N'123456789',N'默认密码')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_NormalImageWidth',N'100',N'图片管理：正常显示图的宽度')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_NormalImageHeight',N'100',N'图片管理：正常显示图的高度')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_ThumbImageWidth',N'100',N'图片管理：缩略图的宽度')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_ThumbImageHeight',N'100',N'图片管理：缩略图的高度')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_UserRoleID',N'2',N'默认的用户注册角色ID')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_UserType',N'UU',N'默认的用户注册类型')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_PhotoLength',N'5',N'图片管理：上传图片的大小（单位：M）')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_Image_KeyAlt',N'DotNet.Framework',N'默认的图片Alt属性')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'Default_UploadFolder',N'/UploadFolder/',N'默认上传目录')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES (  0,N'Default_YouKuAPI',N'http://player.youku.com/player.php/sid/{0}/v.swf',N'优酷视频API')
																					
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_WebSiteName',N'DotNet.Framework',N'站点Title')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_WebHost',N'localhost',N'站点域名')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_WebLogoPath',N'/Upload/WebSiteLogo/201212191628392638234.jpg',N'网站Logo路径')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_AdminLogoPath',N'/Resource/Images/logo.png',N'网站管理平台Logo路径,建议高度50px,png 格式')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_WebPowerBy',N'Copyright &#169; 2013 Maticsoft. All Rights Reserved.',N'版权信息')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_WebCopyRight',N'DotNet,DotNet.Framework 版权所有 陕ICP备0000号',N'网站版权信息')
																						 
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_WebSiteKeywords',N'站点框架,DotNet,DotNet.Framework',N'站点关键字')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_WebSiteDescription',N'DotNet.Framework',N'站点描述')
																						
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_CacheTime',N'30',N'系统缓存时间(分钟)')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_PageFootJs',N'<div style="display: none;">这里放统计代码</div>',N'网站统计脚本')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'SYS_AuthorizeCode',N'',N'AuthorizeCode')

INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'sms_register',N'【鑫奕科技】亲爱的{@用户名}！恭喜您成为【鑫奕科技】会员，请牢记您的账号和密码，用户名：{@用户名} 密码：{@密码}',N'注  册   提   醒')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'sms_neworder',N'【鑫奕科技】系统新订单通知！订单号:{@单号}  姓名{@姓名}  电话：{@手机} 地址：{@地址}  所在城市：{@城市}  费用:{@费用}',N'新 订  单  提 醒')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'sms_createorder',N'【鑫奕科技】尊敬的客户您好，您的订单已经受理，我们将尽快和你取得联系确认该订单，请保持手机畅通，您的订单号为：{@单号},可通过网站查询订单状态和评价服务质量。',N'客户 确 认 提 醒 ')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'sms_assignedorder',N'【鑫奕科技】新任务提醒:{@工程师},公司安排您上门服务该客户:订单号{@单号}姓名{@姓名}{@性别}电话：{@手机}地址：{@城市}{@地址}费用：{@费用}',N'订单 指 派 提 醒')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'sms_assignedordernotify ',N'【鑫奕科技】尊敬的{@姓名}您好,您的{@单号}订单已经确认，我们将安排指定工程师{@工程师}上门服务，预约上门时间为{@预约日期}{@预约时间}，请在此时间家里留人，谢谢!',N'客户 预 约 提 醒')
INSERT INTO [EDNF_SYS_ConfigContent] ([KeyType],[Keyname],[Value],[Description]) VALUES ( -1,N'sms_ordercompleted',N'【鑫奕科技】尊敬的{@姓名}，您的{@单号}订单已经完成，我们已将您的联系方式存入用户数据库，同时请您保存报修中心热线4008-743-095[仅能拨打报修中心热线尊享售后服务]感谢您的信任与支持，祝您生活愉快！另添加微信服务号x1kj_cn[或QQ:743095老客户专享电脑故障在线答疑及紧急救援服务。',N'客户维修完成提醒')

GO


