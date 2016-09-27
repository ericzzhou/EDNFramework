GO

CREATE TABLE [EDNF_Account_Permission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL DEFAULT(0),
	[CategoryID] [int] NOT NULL DEFAULT(0),
	[PermissionCode] [varchar](100) NOT NULL,
	[PermissionName] [varchar](100) NOT NULL,
	[Description] [varchar](255) NULL,
	[Sequence] [int] NOT NULL DEFAULT(0),
	[CreateDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[RequestUrl] [varchar](500) NULL
 CONSTRAINT [PK_EDNF_Account_Permission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET IDENTITY_INSERT [EDNF_Account_Permission] ON
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (1, 0, 1, N'root_article', N'文章管理', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (2, 0, 1, N'root_product', N'产品管理', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (3, 0, 1, N'root_log', N'日志查询', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (4, 0, 1, N'root_controlpanel', N'控制面板', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (6, 0, 1, N'root_Account', N'系统安全', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (7, 1, 1, N'article_category_index', N'文章类别管理', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'/Pages/Articles/Category/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (8, 1, 1, N'article_category_add', N'文章类别添加', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'/Pages/Articles/Category/add.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (9, 1, 1, N'article_item_index', N'文章信息管理', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'/Pages/Articles/Item/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (11, 2, 1, N'product_category_index', N'产品类别管理', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'/Pages/Product/Category/Index.aspx')
--INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (12, 2, 1, N'product_category_add', N'产品类别添加', N'', 0, CAST(0x0000A22F0180F1C3 AS DateTime), N'/Pages/Product/Category/Add.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (13, 2, 1, N'product_item_index', N'产品信息管理', N'', 0, CAST(0x0000A22F0180F1C8 AS DateTime), N'/Pages/Product/Item/Index.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (14, 2, 1, N'product_item_add', N'产品信息添加', N'', 0, CAST(0x0000A22F0180F1C8 AS DateTime), N'/Pages/Product/Item/Add.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (36, 1, 1, N'article_item_add', N'文章信息添加', N'', 0, CAST(0x0000A232000CBDB6 AS DateTime), N'/Pages/Articles/Item/Add.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (37, 3, 1, N'log_sys_index', N'系统日志', N'', 0, CAST(0x0000A232000D0A2A AS DateTime), N'/Pages/Log/ErrorLog/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (38, 3, 1, N'log_operation_Index', N'操作日志', N'', 0, CAST(0x0000A232000D31BC AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (39, 3, 1, N'log_user_index', N'用户日志', N'', 0, CAST(0x0000A232000D46FA AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (41, 6, 1, N'Account_Permission_Index', N'权限管理', N'', 0, CAST(0x0000A2A9014DAA9C AS DateTime), N'/Pages/Account/Permission/Index.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (42, 6, 1, N'Account_Role_Index', N'角色管理', N'', 0, CAST(0x0000A2A9014DE7B7 AS DateTime), N'/Pages/Account/Role/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (43, 6, 1, N'Account_RolePermission_Index', N'角色权限', N'', 0, CAST(0x0000A2A9014E2517 AS DateTime), N'/Pages/Account/Role/RolePermission.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (44, 6, 1, N'Account_User_Index', N'用户管理', N'', 0, CAST(0x0000A2A9014E5AB9 AS DateTime), N'/Pages/Account/User/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (45, 6, 1, N'Account_Department_Index', N'部门管理', N'', 0, CAST(0x0000A2A9014E84E6 AS DateTime), N'/Pages/Account/Department/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (46, 4, 1, N'controlpanel_sysConfig_default', N'系统设定', N'', 0, CAST(0x0000A2AB017BDDA6 AS DateTime), N'/Pages/ControlPanel/SYSConfig/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (47, 4, 1, N'controlpanel_SYSFilterWords_default', N'敏感词', N'', 0, CAST(0x0000A2AB017D489B AS DateTime), N'/Pages/ControlPanel/SYSFilterWords/Index.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (48, 4, 1, N'controlpanel_SYSMailConfig_default', N'邮件配置', N'', 0, CAST(0x0000A2AB017D867F AS DateTime), N'/Pages/ControlPanel/SYSMailConfig/Index.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (49, 0, 1, N'other', N'其他', N'', 0, CAST(0x0000A2D1015B8397 AS DateTime), N'')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (50, 49, 1, N'other_flink_default', N'友情连接', N'', 0, CAST(0x0000A2D1015C17F3 AS DateTime), N'/Pages/Other/FLink/Default.aspx')

INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (51, 49, 1, N'other_sild_default', N'幻灯片组', N'', 0, CAST(0x0000A2D1015C17F3 AS DateTime), N'/Pages/Other/Slide/Default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (52, 49, 1, N'other_sild_item_default', N'幻灯片文件', N'', 0, CAST(0x0000A2D1015C17F3 AS DateTime), N'/Pages/Other/Slide/Item/Default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (53, 4, 1, N'controlpanel_sysfloatad_default', N'网页浮动广告', N'', 0, CAST(0x0000A2D1015C17F3 AS DateTime), N'/Pages/ControlPanel/SYSFloatAD/default.aspx')
INSERT [EDNF_Account_Permission] ([ID], [ParentID], [CategoryID], [PermissionCode], [PermissionName], [Description], [Sequence], [CreateDate], [RequestUrl]) VALUES (54, 4, 1, N'controlpanel_sysfloatad_SingleJumpAD', N'弹跳广告维护', N'弹跳广告', 0, CAST(0x0000A2D1015C17F3 AS DateTime), N'/Pages/ControlPanel/SYSFloatAD/SingleJumpAD.aspx')

SET IDENTITY_INSERT [EDNF_Account_Permission] OFF

GO