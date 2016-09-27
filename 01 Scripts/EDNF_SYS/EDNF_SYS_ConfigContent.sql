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

GO


