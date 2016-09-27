if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_Department]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_Department]

CREATE TABLE [EDNF_Account_Department] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[Code] [varchar]  (50) NULL,
[Name] [nvarchar]  (100) NOT NULL,
[ShortName] [nvarchar]  (100) NULL,
[ParentID] [int]  NOT NULL DEFAULT (0),
[Type] [char]  (10) NULL,
[Manager] [varchar]  (50) NULL,
[Manager2] [varchar]  (50) NULL,
[Phone] [varchar]  (50) NULL,
[ExtNumber] [varchar]  (50) NULL,
[Fax] [varchar]  (50) NULL,
[Status] [char]  (10) NULL,
[Description] [nvarchar]  (500) NULL)

ALTER TABLE [EDNF_Account_Department] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_Department] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [EDNF_Account_Department] ON


SET IDENTITY_INSERT [EDNF_Account_Department] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_Permission]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_Permission]

CREATE TABLE [EDNF_Account_Permission] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[ParentID] [int]  NOT NULL DEFAULT (0),
[CategoryID] [int]  NOT NULL DEFAULT (0),
[PermissionCode] [varchar]  (100) NOT NULL,
[PermissionName] [varchar]  (100) NOT NULL,
[Description] [varchar]  (255) NULL,
[Sequence] [int]  NOT NULL DEFAULT (0),
[CreateDate] [datetime]  NOT NULL DEFAULT (getdate()),
[RequestUrl] [varchar]  (500) NULL)

ALTER TABLE [EDNF_Account_Permission] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_Permission] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [EDNF_Account_Permission] ON

INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 1,0,1,N'repairs_index',N'报修系统',0,N'2013/9/4 23:21:32',N'#')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate]) VALUES ( 3,0,1,N'root_log',N'日志查询',0,N'2013/9/4 23:21:32')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate]) VALUES ( 4,0,1,N'root_controlpanel',N'控制面板',0,N'2013/9/4 23:21:32')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate]) VALUES ( 6,0,1,N'root_Account',N'系统安全',0,N'2013/9/4 23:21:32')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 36,1,1,N'repairs_order_index',N'查看订单',0,N'2013/9/7 0:46:23',N'/Pages/Repairs/order/Index.aspx')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 37,3,1,N'log_sys_index',N'系统日志',0,N'2013/9/7 0:47:28',N'/Pages/Log/ErrorLog/default.aspx')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 41,6,1,N'Account_Permission_Index',N'权限管理',0,N'2014/1/4 20:14:50',N'/Pages/Account/Permission/Index.aspx')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 42,6,1,N'Account_Role_Index',N'角色管理',0,N'2014/1/4 20:15:42',N'/Pages/Account/Role/default.aspx')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 43,6,1,N'Account_RolePermission_Index',N'角色权限',0,N'2014/1/4 20:16:35',N'/Pages/Account/Role/RolePermission.aspx')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 44,6,1,N'Account_User_Index',N'用户管理',0,N'2014/1/4 20:17:20',N'/Pages/Account/User/default.aspx')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 46,4,1,N'controlpanel_sysConfig_default',N'系统设定',0,N'2014/1/6 23:03:02',N'/Pages/ControlPanel/SYSConfig/default.aspx')
INSERT [EDNF_Account_Permission] ([ID],[ParentID],[CategoryID],[PermissionCode],[PermissionName],[Sequence],[CreateDate],[RequestUrl]) VALUES ( 55,1,1,N'repairs_brand_index',N'品牌管理',0,N'2014/9/27 23:09:44',N'/Pages/Repairs/brand/Index.aspx')

SET IDENTITY_INSERT [EDNF_Account_Permission] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_PermissionActions]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_PermissionActions]

CREATE TABLE [EDNF_Account_PermissionActions] (
[ActionID] [int]  IDENTITY (1, 1)  NOT NULL,
[ActionCode] [varchar]  (100) NOT NULL,
[Description] [varchar]  (200) NULL,
[PermissionCode] [varchar]  (100) NOT NULL)

ALTER TABLE [EDNF_Account_PermissionActions] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_PermissionActions] PRIMARY KEY  NONCLUSTERED ( [ActionID] )
SET IDENTITY_INSERT [EDNF_Account_PermissionActions] ON

INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 11,N'btn_add',N'新增',N'article_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 12,N'btn_modify',N'编辑',N'article_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 13,N'btn_delete',N'删除',N'article_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 14,N'btn_save',N'保存',N'article_category_add')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 15,N'btn_add',N'新增',N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 16,N'btn_modify',N'编辑',N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 17,N'btn_delete',N'删除',N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 18,N'btn_search',N'搜索',N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 19,N'btn_save',N'保存',N'article_item_add')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 20,N'btn_add',N'新增',N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 21,N'btn_modify',N'编辑',N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 22,N'btn_delete',N'删除',N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 23,N'btn_search',N'搜索',N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 24,N'btn_add',N'新增',N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 25,N'btn_modify',N'编辑',N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 26,N'btn_delete',N'删除',N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 27,N'btn_search',N'查询',N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 28,N'btn_save',N'保存',N'product_item_add')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 29,N'btn_clear',N'清除',N'log_sys_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 30,N'btn_viewdetail',N'查看详细',N'log_sys_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 31,N'btn_add',N'新增',N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 32,N'btn_modify',N'编辑',N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 33,N'btn_delete',N'删除',N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 34,N'btn_clear',N'清除',N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 35,N'btn_add',N'新增',N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 36,N'btn_clear',N'清除',N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 37,N'btn_action_manager',N'权限按钮维护',N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 38,N'btn_save',N'保存',N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 39,N'btn_delete',N'删除',N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 40,N'btn_modify',N'修改',N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 41,N'btn_add',N'新增',N'Account_Role_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 42,N'btn_modify',N'编辑',N'Account_Role_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 43,N'btn_delete',N'删除',N'Account_Role_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 44,N'btn_user_add',N'添加成员',N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 45,N'btn_user_remove',N'移除成员',N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 46,N'btn_promission_gave',N'模块授权',N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 47,N'btn_action_load',N'模块按钮加载',N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 48,N'btn_action_save',N'模块按钮授权',N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 49,N'btn_add',N'新增',N'Account_User_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 50,N'btn_modify',N'编辑',N'Account_User_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 51,N'btn_delete',N'删除',N'Account_User_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 52,N'btn_add',N'新增',N'Account_Department_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 53,N'btn_modify',N'编辑',N'Account_Department_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 54,N'btn_delete',N'删除',N'Account_Department_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 55,N'btn_add',N'新增',N'other_flink_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 56,N'btn_modify',N'编辑',N'other_flink_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 57,N'btn_delete',N'删除',N'other_flink_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 58,N'btn_add',N'新增',N'other_sild_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 59,N'btn_modify',N'编辑',N'other_sild_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 60,N'btn_file_manager',N'维护文件',N'other_sild_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 61,N'btn_add',N'新增',N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 62,N'btn_modify',N'编辑',N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 63,N'btn_delete',N'删除',N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 64,N'btn_search',N'搜索',N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 65,N'btn_recycle',N'回收',N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 66,N'btn_update',N'更新',N'Repairs_brand_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 67,N'btn_add',N'添加',N'Repairs_brand_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 68,N'btn_delete',N'删除',N'Repairs_brand_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 69,N'btn_AssignedTo',N'任务指派',N'Repairs_order_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID],[ActionCode],[Description],[PermissionCode]) VALUES ( 70,N'btn_delete',N'订单删除',N'Repairs_order_index')

SET IDENTITY_INSERT [EDNF_Account_PermissionActions] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_PermissionCategories]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_PermissionCategories]

CREATE TABLE [EDNF_Account_PermissionCategories] (
[CategoryID] [int]  IDENTITY (1, 1)  NOT NULL,
[Description] [varchar]  (255) NULL)

ALTER TABLE [EDNF_Account_PermissionCategories] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_PermissionCategories] PRIMARY KEY  NONCLUSTERED ( [CategoryID] )
SET IDENTITY_INSERT [EDNF_Account_PermissionCategories] ON

INSERT [EDNF_Account_PermissionCategories] ([CategoryID],[Description]) VALUES ( 1,N'系统功能管理')
INSERT [EDNF_Account_PermissionCategories] ([CategoryID],[Description]) VALUES ( 2,N'主菜单管理')
INSERT [EDNF_Account_PermissionCategories] ([CategoryID],[Description]) VALUES ( 3,N'基础数据')

SET IDENTITY_INSERT [EDNF_Account_PermissionCategories] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_Role]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_Role]

CREATE TABLE [EDNF_Account_Role] (
[RoleID] [int]  IDENTITY (1, 1)  NOT NULL,
[RoleName] [varchar]  (50) NOT NULL,
[Description] [varchar]  (255) NULL)

ALTER TABLE [EDNF_Account_Role] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_Role] PRIMARY KEY  NONCLUSTERED ( [RoleID] )
SET IDENTITY_INSERT [EDNF_Account_Role] ON

INSERT [EDNF_Account_Role] ([RoleID],[RoleName],[Description]) VALUES ( 1,N'系统管理员',N'拥有管理权限的账号集团')
INSERT [EDNF_Account_Role] ([RoleID],[RoleName]) VALUES ( 2,N'普通用户')
INSERT [EDNF_Account_Role] ([RoleID],[RoleName]) VALUES ( 3,N'维修人员')

SET IDENTITY_INSERT [EDNF_Account_Role] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_RolePermissions]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_RolePermissions]

CREATE TABLE [EDNF_Account_RolePermissions] (
[ARPID] [uniqueidentifier]  NOT NULL,
[RoleID] [int]  NOT NULL,
[PermissionCode] [varchar]  (100) NOT NULL)

ALTER TABLE [EDNF_Account_RolePermissions] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_RolePermissions] PRIMARY KEY  NONCLUSTERED ( [ARPID] )
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'ed289bb8-74bb-4cb3-9f7d-0816f0454853',1,N'Account_RolePermission_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'9c975c44-305c-442b-bf89-461c550ea17a',3,N'repairs_order_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'f6d66e95-097b-4d74-b21e-503496b7c200',1,N'Account_Permission_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'227875b0-3b9d-4413-8f4c-55a8890d1967',1,N'Repairs_order_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'c06fc942-27c4-4f3f-be3d-5d6b598aa489',3,N'repairs_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'4251bc76-0d38-408e-b73d-5fc426dad888',1,N'Repairs_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'9c6610c2-15d7-40f2-88a4-64413e97b531',1,N'root_controlpanel')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'50598344-4623-4135-a6da-66c7508812b4',1,N'Account_Role_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'a123c1d5-55cb-418d-b44c-846143f0408f',1,N'root_log')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'5a90d183-4b7d-44a9-95d3-b00f4bc6ac8c',1,N'Account_User_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'33844cfc-e84b-4b9a-965f-c2d51f168a37',1,N'Repairs_brand_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'79a4967b-f61a-4870-b7f8-c8e15f81d166',1,N'log_sys_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'5c310b97-d0fe-425c-afcc-d03cc012469d',1,N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_RolePermissions] ([ARPID],[RoleID],[PermissionCode]) VALUES ( N'1cec22d5-1c39-4600-8b08-d737ff70a4be',1,N'root_Account')
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_RolePermissionsAction]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_RolePermissionsAction]

CREATE TABLE [EDNF_Account_RolePermissionsAction] (
[ARPAID] [uniqueidentifier]  NOT NULL,
[ARPID] [uniqueidentifier]  NOT NULL,
[ActionCode] [varchar]  (100) NOT NULL,
[RoleID] [int]  NOT NULL)

ALTER TABLE [EDNF_Account_RolePermissionsAction] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_RolePermissionsAction] PRIMARY KEY  NONCLUSTERED ( [ARPAID] )
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'398b8eb4-1294-4b62-ac1e-034766c8887c',N'5a90d183-4b7d-44a9-95d3-b00f4bc6ac8c',N'btn_delete',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'54e65b56-1016-4110-8f76-0bb161254f43',N'5c310b97-d0fe-425c-afcc-d03cc012469d',N'btn_add',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'f233f948-6829-4f14-bf12-1873dbad499f',N'f6d66e95-097b-4d74-b21e-503496b7c200',N'btn_delete',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'0e365603-686c-40c7-bd44-1cdfffeff7f5',N'ed289bb8-74bb-4cb3-9f7d-0816f0454853',N'btn_action_load',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'1b37dff2-82bd-45bf-bef1-2920036df0ae',N'ed289bb8-74bb-4cb3-9f7d-0816f0454853',N'btn_user_remove',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'36bea8fd-e4e6-4926-95d8-300d27d59944',N'f6d66e95-097b-4d74-b21e-503496b7c200',N'btn_clear',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'bcc92f83-cd2d-45f4-85b5-382439e64055',N'ed289bb8-74bb-4cb3-9f7d-0816f0454853',N'btn_user_add',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'7a917633-75f6-47c3-a447-3cddfb52b1c3',N'50598344-4623-4135-a6da-66c7508812b4',N'btn_add',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'cf26bb70-4eff-427b-8494-3db05bd1b57e',N'5a90d183-4b7d-44a9-95d3-b00f4bc6ac8c',N'btn_add',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'77cd4baf-c970-4b3f-b854-3e6afef4ebbf',N'f6d66e95-097b-4d74-b21e-503496b7c200',N'btn_action_manager',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'4ff7676c-d72e-4ad1-b227-5ca695d60f32',N'5c310b97-d0fe-425c-afcc-d03cc012469d',N'btn_modify',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'5da96d98-cda2-4774-b16b-618debcb18ef',N'5c310b97-d0fe-425c-afcc-d03cc012469d',N'btn_delete',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'41d30974-d526-4d30-a497-6ca5c46e4ee1',N'79a4967b-f61a-4870-b7f8-c8e15f81d166',N'btn_clear',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'b3f9fdf6-0eec-4503-8182-75f87614167b',N'33844cfc-e84b-4b9a-965f-c2d51f168a37',N'btn_update',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'7062eb8b-50ef-4ddc-acf3-7dc0143096dc',N'79a4967b-f61a-4870-b7f8-c8e15f81d166',N'btn_viewdetail',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'0db499ab-48b2-4bef-9abf-8142c4b2b2bf',N'33844cfc-e84b-4b9a-965f-c2d51f168a37',N'btn_add',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'412e5280-3e82-4be4-ba04-83d2a21b01a1',N'f6d66e95-097b-4d74-b21e-503496b7c200',N'btn_add',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'd044a67a-25c4-4398-ba61-8630ad453969',N'ed289bb8-74bb-4cb3-9f7d-0816f0454853',N'btn_action_save',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'658dd58a-4107-4c01-8168-8cc1eb1b4616',N'33844cfc-e84b-4b9a-965f-c2d51f168a37',N'btn_delete',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'5bc398e5-d254-4e27-9df6-9a3ada05312c',N'227875b0-3b9d-4413-8f4c-55a8890d1967',N'btn_AssignedTo',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'514d7016-f4b1-4b48-b460-a7e8935f003c',N'ed289bb8-74bb-4cb3-9f7d-0816f0454853',N'btn_promission_gave',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'35daface-a9ef-4250-9d39-c09472cd200e',N'5c310b97-d0fe-425c-afcc-d03cc012469d',N'btn_clear',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'a855fdf0-c857-4614-9b6c-ca107c05496b',N'f6d66e95-097b-4d74-b21e-503496b7c200',N'btn_save',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'e2ba03a5-25ae-45d7-aa8c-d2bfe7f72502',N'5a90d183-4b7d-44a9-95d3-b00f4bc6ac8c',N'btn_modify',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'bd77d2f7-9a37-4329-bb6a-d4703f709d1e',N'f6d66e95-097b-4d74-b21e-503496b7c200',N'btn_modify',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'7521fbaa-86ff-412a-a85f-d6a867e294d8',N'50598344-4623-4135-a6da-66c7508812b4',N'btn_modify',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'2cdbc17f-658f-435d-bcf5-e4ef55fc5f41',N'50598344-4623-4135-a6da-66c7508812b4',N'btn_delete',1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID],[ARPID],[ActionCode],[RoleID]) VALUES ( N'08c8ff29-e20f-4688-a79a-eea21866b36c',N'227875b0-3b9d-4413-8f4c-55a8890d1967',N'btn_delete',1)
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_User]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_User]

CREATE TABLE [EDNF_Account_User] (
[UserID] [int]  IDENTITY (1, 1)  NOT NULL,
[UserName] [varchar]  (100) NOT NULL,
[Password] [varchar]  (500) NOT NULL,
[NickName] [varchar]  (50) NULL,
[TrueName] [varchar]  (50) NULL,
[Sex] [char]  (10) NULL,
[Phone] [varchar]  (20) NULL,
[Email] [varchar]  (100) NULL,
[EmployeeID] [int]  NULL,
[DepartmentID] [varchar]  (15) NULL,
[Activity] [bit]  NOT NULL DEFAULT (0),
[UserType] [char]  (2) NULL,
[Style] [int]  NULL,
[User_iCreator] [int]  NULL,
[User_dateCreate] [datetime]  NOT NULL DEFAULT (getdate()),
[User_dateValid] [datetime]  NULL,
[User_dateExpire] [datetime]  NULL,
[User_iApprover] [int]  NULL,
[User_dateApprove] [datetime]  NULL,
[User_iApproveState] [int]  NULL,
[User_cLang] [varchar]  (10) NULL,
[auth_token] [varchar]  (500) NULL)

ALTER TABLE [EDNF_Account_User] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_User] PRIMARY KEY  NONCLUSTERED ( [UserID] )
SET IDENTITY_INSERT [EDNF_Account_User] ON

INSERT [EDNF_Account_User] ([UserID],[UserName],[Password],[NickName],[TrueName],[Sex],[Phone],[Email],[Activity],[UserType],[User_dateCreate]) VALUES ( 1,N'admin',N'AC6BA01828733094F88CFC385EBDA78B',N'管理员',N'管理员',N'男',N'15829082171',N'zhouzhaokun@gmail.com',1,N'AA',N'2014/9/27 19:47:35')
INSERT [EDNF_Account_User] ([UserID],[UserName],[Password],[NickName],[Phone],[Activity],[UserType],[User_dateCreate]) VALUES ( 2,N'周兆坤',N'9EDFD31E7365EA5EB6B97EF04ABE7FA3',N'周兆坤',N'15829082174',1,N'UU',N'2014/9/27 23:12:17')
INSERT [EDNF_Account_User] ([UserID],[UserName],[Password],[NickName],[Phone],[Activity],[UserType],[User_dateCreate]) VALUES ( 3,N'测试',N'284B232377C0226D1B61D59D43906ADF',N'测试',N'110',1,N'UU',N'2014/9/27 23:15:30')
INSERT [EDNF_Account_User] ([UserID],[UserName],[Password],[NickName],[Phone],[Activity],[UserType],[User_dateCreate]) VALUES ( 4,N'xkun',N'9829FEA4FC08BC5AC09BEC97E9D64002',N'zzz',N'15390419416',1,N'UU',N'2014/9/27 23:23:29')
INSERT [EDNF_Account_User] ([UserID],[UserName],[Password],[NickName],[Phone],[Activity],[UserType],[User_dateCreate]) VALUES ( 41,N'testuser',N'9EDFD31E7365EA5EB6B97EF04ABE7FA3',N'123',N'testuser',1,N'UU',N'2014/9/30 19:34:40')
INSERT [EDNF_Account_User] ([UserID],[UserName],[Password],[NickName],[Sex],[Phone],[Email],[Activity],[UserType],[User_dateCreate]) VALUES ( 5,N'曾地坤',N'634C0648346F501303D68F33A154F5F8',N'曾地坤',N'男',N'18683370227',N'xkun@x1kj.com',1,N'AA',N'2014/9/28 23:07:04')

SET IDENTITY_INSERT [EDNF_Account_User] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_User_LogonLog]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_User_LogonLog]

CREATE TABLE [EDNF_Account_User_LogonLog] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[UserName] [varchar]  (100) NOT NULL,
[LogonTime] [datetime]  NOT NULL DEFAULT (getdate()),
[Status] [nvarchar]  (50) NULL,
[StatusDescription] [nvarchar]  (200) NULL,
[LogonIP] [varchar]  (1) NULL)

ALTER TABLE [EDNF_Account_User_LogonLog] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_User_LogonLog] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [EDNF_Account_User_LogonLog] ON


SET IDENTITY_INSERT [EDNF_Account_User_LogonLog] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_UserBind]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_UserBind]

CREATE TABLE [EDNF_Account_UserBind] (
[BindId] [int]  IDENTITY (1, 1)  NOT NULL,
[UserId] [int]  NOT NULL,
[Token] [nvarchar]  (200) NULL,
[MediaUserID] [int]  NOT NULL DEFAULT (0),
[MediaNickName] [nvarchar]  (200) NULL,
[MediaID] [int]  NOT NULL,
[iHome] [bit]  NOT NULL DEFAULT (0),
[Comment] [bit]  NOT NULL DEFAULT (0),
[GroupTopic] [bit]  NOT NULL DEFAULT (0))

ALTER TABLE [EDNF_Account_UserBind] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_UserBind] PRIMARY KEY  NONCLUSTERED ( [BindId] )
SET IDENTITY_INSERT [EDNF_Account_UserBind] ON


SET IDENTITY_INSERT [EDNF_Account_UserBind] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_UserRoles]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_UserRoles]

CREATE TABLE [EDNF_Account_UserRoles] (
[UserID] [int]  NOT NULL,
[RoleID] [int]  NOT NULL)

ALTER TABLE [EDNF_Account_UserRoles] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Account_UserRoles] PRIMARY KEY  NONCLUSTERED ( [UserID],[RoleID] )
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 1,1)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 1,3)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 2,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 2,3)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 3,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 4,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 5,1)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 5,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 5,3)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 6,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 7,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 8,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 9,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 10,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 11,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 12,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 13,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 14,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 15,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 16,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 21,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 22,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 23,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 24,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 25,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 27,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 28,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 29,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 30,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 31,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 32,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 33,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 34,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 35,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 36,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 37,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 38,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 39,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 40,2)
INSERT [EDNF_Account_UserRoles] ([UserID],[RoleID]) VALUES ( 41,2)
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Account_UserType]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Account_UserType]

CREATE TABLE [EDNF_Account_UserType] (
[UserType] [char]  (10) NOT NULL,
[Description] [nvarchar]  (50) NOT NULL)

INSERT [EDNF_Account_UserType] ([UserType],[Description]) VALUES ( N'AA',N'管理员')
INSERT [EDNF_Account_UserType] ([UserType],[Description]) VALUES ( N'UU',N'普通用户')
INSERT [EDNF_Account_UserType] ([UserType],[Description]) VALUES ( N'BB',N'维修人员')
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_Repairs_Brand]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_Repairs_Brand]

CREATE TABLE [EDNF_Repairs_Brand] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[Name] [nvarchar]  (100) NOT NULL,
[Descriptino] [nvarchar]  (500) NULL,
[Deleted] [bit]  NOT NULL DEFAULT (0))

ALTER TABLE [EDNF_Repairs_Brand] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_Repairs_Brand] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [EDNF_Repairs_Brand] ON

INSERT [EDNF_Repairs_Brand] ([ID],[Name],[Deleted]) VALUES ( 1,N'华硕',0)
INSERT [EDNF_Repairs_Brand] ([ID],[Name],[Deleted]) VALUES ( 2,N'联想',0)
INSERT [EDNF_Repairs_Brand] ([ID],[Name],[Deleted]) VALUES ( 3,N'华硕',0)
INSERT [EDNF_Repairs_Brand] ([ID],[Name],[Descriptino],[Deleted]) VALUES ( 4,N'戴尔',N'·',0)
INSERT [EDNF_Repairs_Brand] ([ID],[Name],[Descriptino],[Deleted]) VALUES ( 5,N'1212',N'888',1)

SET IDENTITY_INSERT [EDNF_Repairs_Brand] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_SYS_ConfigContent]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_SYS_ConfigContent]

CREATE TABLE [EDNF_SYS_ConfigContent] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[Keyname] [varchar]  (50) NOT NULL,
[Value] [varchar]  (MAX) NOT NULL,
[KeyType] [int]  NOT NULL DEFAULT (0),
[Description] [varchar]  (200) NULL)

ALTER TABLE [EDNF_SYS_ConfigContent] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_SYS_ConfigContent] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [EDNF_SYS_ConfigContent] ON

INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 1,N'AdminVirtualPath','',-2,N'Admin 站点目录，如果是根站点，则为空')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 2,N'Reserved_AdminID',N'1',-2,N'系统预留管理员帐号ID，不允许删除')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 3,N'Reserved_RoleIDs',N'1,2',-2,N'系统预留的角色(逗号分隔)')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 4,N'Reserved_PermIDs',N'2,87,88',-2,N'系统保留的权限(逗号分隔)')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 5,N'Default_Password',N'123456789',-1,N'默认密码')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 6,N'Default_NormalImageWidth',N'100',-1,N'图片管理：正常显示图的宽度')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 7,N'Default_NormalImageHeight',N'100',-1,N'图片管理：正常显示图的高度')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 8,N'Default_ThumbImageWidth',N'100',-1,N'图片管理：缩略图的宽度')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 9,N'Default_ThumbImageHeight',N'100',-1,N'图片管理：缩略图的高度')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 10,N'Default_UserRoleID',N'2',-1,N'默认的用户注册角色ID')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 11,N'Default_UserType',N'UU',-1,N'默认的用户注册类型')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 12,N'Default_PhotoLength',N'5',-1,N'图片管理：上传图片的大小（单位：M）')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 13,N'Default_Image_KeyAlt',N'DotNet.Framework',-1,N'默认的图片Alt属性')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 14,N'Default_UploadFolder',N'/UploadFolder/',-1,N'默认上传目录')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 15,N'Default_YouKuAPI',N'http://player.youku.com/player.php/sid/{0}/v.swf',0,N'优酷视频API')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 16,N'SYS_WebSiteName',N'鑫奕科技电脑在线报修修中心',-1,N'站点Title')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 17,N'SYS_WebHost',N'localhost',-1,N'站点域名')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 18,N'SYS_WebLogoPath',N'/Upload/WebSiteLogo/201212191628392638234.jpg',-1,N'网站Logo路径')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 19,N'SYS_AdminLogoPath',N'/Resource/Images/logo.png',-1,N'网站管理平台Logo路径,建议高度50px,png 格式')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 20,N'SYS_WebPowerBy',N'Copyright &#169; 2013 Maticsoft. All Rights Reserved.',-1,N'版权信息')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 21,N'SYS_WebCopyRight',N'Copyright &2013 鑫奕科技. All Rights Reserved.蜀ICP备13028023号',-1,N'网站版权信息')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 22,N'SYS_WebSiteKeywords',N'站点框架,DotNet,DotNet.Framework',-1,N'站点关键字')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 23,N'SYS_WebSiteDescription',N'DotNet.Framework',-1,N'站点描述')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 24,N'SYS_CacheTime',N'30',-1,N'系统缓存时间(分钟)')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 25,N'SYS_PageFootJs',N'<div style="display: none;">这里放统计代码</div>',-1,N'网站统计脚本')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 26,N'SYS_AuthorizeCode','',-1,N'AuthorizeCode')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 27,N'SYS_WelecomeEmployee',N'工程师，你好！欢迎登陆！',0,N'维修师傅登录 提示语')
INSERT [EDNF_SYS_ConfigContent] ([ID],[Keyname],[Value],[KeyType],[Description]) VALUES ( 28,N'SYS_WelecomeUser',N'亲爱的用户你好！欢迎来到鑫奕科技电脑维修中心！',0,N'用户登录提示语')

SET IDENTITY_INSERT [EDNF_SYS_ConfigContent] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_SYS_ConfigType]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_SYS_ConfigType]

CREATE TABLE [EDNF_SYS_ConfigType] (
[KeyType] [int]  IDENTITY (1, 1)  NOT NULL,
[TypeName] [nvarchar]  (50) NOT NULL)

ALTER TABLE [EDNF_SYS_ConfigType] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_SYS_ConfigType] PRIMARY KEY  NONCLUSTERED ( [KeyType] )
SET IDENTITY_INSERT [EDNF_SYS_ConfigType] ON


SET IDENTITY_INSERT [EDNF_SYS_ConfigType] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[EDNF_SYS_ErrorLog]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [EDNF_SYS_ErrorLog]

CREATE TABLE [EDNF_SYS_ErrorLog] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[OPTime] [datetime]  NULL,
[Url] [varchar]  (MAX) NULL,
[Loginfo] [varchar]  (MAX) NULL,
[StackTrace] [varchar]  (MAX) NULL,
[ErrorType] [varchar]  (100) NULL,
[Domain] [varchar]  (200) NULL)

ALTER TABLE [EDNF_SYS_ErrorLog] WITH NOCHECK ADD  CONSTRAINT [PK_EDNF_SYS_ErrorLog] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [EDNF_SYS_ErrorLog] ON


SET IDENTITY_INSERT [EDNF_SYS_ErrorLog] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[ENDF_Repairs_ContactsAddress]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [ENDF_Repairs_ContactsAddress]

CREATE TABLE [ENDF_Repairs_ContactsAddress] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[UserID] [int]  NOT NULL DEFAULT (0),
[ContactsName] [nvarchar]  (50) NOT NULL,
[ContactsMobile] [varchar]  (50) NOT NULL,
[ContactsAddress] [nvarchar]  (500) NULL)

ALTER TABLE [ENDF_Repairs_ContactsAddress] WITH NOCHECK ADD  CONSTRAINT [PK_ENDF_Repairs_ContactsAddress] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [ENDF_Repairs_ContactsAddress] ON

INSERT [ENDF_Repairs_ContactsAddress] ([ID],[UserID],[ContactsName],[ContactsMobile],[ContactsAddress]) VALUES ( 1,2,N'111',N'222',N'333')
INSERT [ENDF_Repairs_ContactsAddress] ([ID],[UserID],[ContactsName],[ContactsMobile],[ContactsAddress]) VALUES ( 2,4,N'地坤',N'15390419416',N'成都市')
INSERT [ENDF_Repairs_ContactsAddress] ([ID],[UserID],[ContactsName],[ContactsMobile],[ContactsAddress]) VALUES ( 3,41,N'警察',N'110',N'公安局')

SET IDENTITY_INSERT [ENDF_Repairs_ContactsAddress] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[ENDF_Repairs_Order]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [ENDF_Repairs_Order]

CREATE TABLE [ENDF_Repairs_Order] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[OrderNumber] [varchar]  (50) NULL,
[UserID] [int]  NOT NULL DEFAULT (0),
[UserContactID] [int]  NOT NULL DEFAULT (0),
[BrandID] [int]  NOT NULL DEFAULT (0),
[Model] [nvarchar]  (50) NULL,
[RepairsDescription] [nvarchar]  (500) NULL,
[ComputerType] [int]  NOT NULL DEFAULT (0),
[CreateTime] [datetime]  NOT NULL DEFAULT (getdate()),
[ModifyTime] [datetime]  NULL,
[AssignedTo] [int]  NOT NULL DEFAULT (0),
[Statu] [int]  NOT NULL DEFAULT (0),
[Remark] [nvarchar]  (500) NULL)

ALTER TABLE [ENDF_Repairs_Order] WITH NOCHECK ADD  CONSTRAINT [PK_ENDF_Repairs_Order] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [ENDF_Repairs_Order] ON

INSERT [ENDF_Repairs_Order] ([ID],[OrderNumber],[UserID],[UserContactID],[BrandID],[Model],[RepairsDescription],[ComputerType],[CreateTime],[AssignedTo],[Statu]) VALUES ( 1,N'201409281224340319',2,1,2,N'GD333',N'ASDFSADF',0,N'2014/9/28 20:24:11',0,0)
INSERT [ENDF_Repairs_Order] ([ID],[OrderNumber],[UserID],[UserContactID],[BrandID],[Model],[RepairsDescription],[ComputerType],[CreateTime],[AssignedTo],[Statu]) VALUES ( 2,N'201409291428407161',4,2,1,N'dddd',N'死机',0,N'2014/9/29 14:28:21',0,0)
INSERT [ENDF_Repairs_Order] ([ID],[OrderNumber],[UserID],[UserContactID],[BrandID],[Model],[RepairsDescription],[ComputerType],[CreateTime],[ModifyTime],[AssignedTo],[Statu]) VALUES ( 3,N'201409301137140418',41,3,3,N'hs001',N'测试故障',1,N'2014/9/30 19:36:50',N'2014/9/30 20:27:55',2,2)

SET IDENTITY_INSERT [ENDF_Repairs_Order] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[ENDF_Repairs_OrderHistory]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [ENDF_Repairs_OrderHistory]

CREATE TABLE [ENDF_Repairs_OrderHistory] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[OrderID] [int]  NOT NULL DEFAULT (0),
[Status] [int]  NOT NULL DEFAULT (0),
[CreateTime] [datetime]  NOT NULL DEFAULT (getdate()),
[Note] [nvarchar]  (100) NULL)

ALTER TABLE [ENDF_Repairs_OrderHistory] WITH NOCHECK ADD  CONSTRAINT [PK_ENDF_Repairs_OrderHistory] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [ENDF_Repairs_OrderHistory] ON

INSERT [ENDF_Repairs_OrderHistory] ([ID],[OrderID],[Status],[CreateTime],[Note]) VALUES ( 1,1,0,N'2014/9/28 20:24:11',N'客户创建订单')
INSERT [ENDF_Repairs_OrderHistory] ([ID],[OrderID],[Status],[CreateTime],[Note]) VALUES ( 2,2,0,N'2014/9/29 14:28:21',N'客户创建订单')
INSERT [ENDF_Repairs_OrderHistory] ([ID],[OrderID],[Status],[CreateTime],[Note]) VALUES ( 3,3,0,N'2014/9/30 19:36:50',N'客户创建订单')
INSERT [ENDF_Repairs_OrderHistory] ([ID],[OrderID],[Status],[CreateTime],[Note]) VALUES ( 4,3,2,N'2014/9/30 20:04:46',N'订单已分派')
INSERT [ENDF_Repairs_OrderHistory] ([ID],[OrderID],[Status],[CreateTime],[Note]) VALUES ( 5,3,3,N'2014/9/30 20:09:24',N'工作已完成')
INSERT [ENDF_Repairs_OrderHistory] ([ID],[OrderID],[Status],[CreateTime],[Note]) VALUES ( 6,3,2,N'2014/9/30 20:27:55',N'订单已分派')

SET IDENTITY_INSERT [ENDF_Repairs_OrderHistory] OFF
