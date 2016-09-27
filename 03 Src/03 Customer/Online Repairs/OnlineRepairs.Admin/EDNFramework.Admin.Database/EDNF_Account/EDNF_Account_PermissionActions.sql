GO


CREATE TABLE [EDNF_Account_PermissionActions](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[ActionCode] [varchar](100) NOT NULL,
	[Description] [varchar](200) NULL,
	[PermissionCode] [varchar](100) NOT NULL,
 CONSTRAINT [PK_EDNF_Account_PermissionActions] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET IDENTITY_INSERT [EDNF_Account_PermissionActions] ON
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (11, N'btn_add', N'新增', N'article_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (12, N'btn_modify', N'编辑', N'article_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (13, N'btn_delete', N'删除', N'article_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (14, N'btn_save', N'保存', N'article_category_add')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (15, N'btn_add', N'新增', N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (16, N'btn_modify', N'编辑', N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (17, N'btn_delete', N'删除', N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (18, N'btn_search', N'搜索', N'article_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (19, N'btn_save', N'保存', N'article_item_add')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (20, N'btn_add', N'新增', N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (21, N'btn_modify', N'编辑', N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (22, N'btn_delete', N'删除', N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (23, N'btn_search', N'搜索', N'product_category_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (24, N'btn_add', N'新增', N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (25, N'btn_modify', N'编辑', N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (26, N'btn_delete', N'删除', N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (27, N'btn_search', N'查询', N'product_item_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (28, N'btn_save', N'保存', N'product_item_add')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (29, N'btn_clear', N'清除', N'log_sys_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (30, N'btn_viewdetail', N'查看详细', N'log_sys_index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (31, N'btn_add', N'新增', N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (32, N'btn_modify', N'编辑', N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (33, N'btn_delete', N'删除', N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (34, N'btn_clear', N'清除', N'controlpanel_sysConfig_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (35, N'btn_add', N'新增', N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (36, N'btn_clear', N'清除', N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (37, N'btn_action_manager', N'权限按钮维护', N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (38, N'btn_save', N'保存', N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (39, N'btn_delete', N'删除', N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (40, N'btn_modify', N'修改', N'Account_Permission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (41, N'btn_add', N'新增', N'Account_Role_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (42, N'btn_modify', N'编辑', N'Account_Role_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (43, N'btn_delete', N'删除', N'Account_Role_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (44, N'btn_user_add', N'添加成员', N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (45, N'btn_user_remove', N'移除成员', N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (46, N'btn_promission_gave', N'模块授权', N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (47, N'btn_action_load', N'模块按钮加载', N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (48, N'btn_action_save', N'模块按钮授权', N'Account_RolePermission_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (49, N'btn_add', N'新增', N'Account_User_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (50, N'btn_modify', N'编辑', N'Account_User_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (51, N'btn_delete', N'删除', N'Account_User_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (52, N'btn_add', N'新增', N'Account_Department_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (53, N'btn_modify', N'编辑', N'Account_Department_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (54, N'btn_delete', N'删除', N'Account_Department_Index')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (55, N'btn_add', N'新增', N'other_flink_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (56, N'btn_modify', N'编辑', N'other_flink_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (57, N'btn_delete', N'删除', N'other_flink_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (58, N'btn_add', N'新增', N'other_sild_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (59, N'btn_modify', N'编辑', N'other_sild_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (60, N'btn_file_manager', N'维护文件', N'other_sild_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (61, N'btn_add', N'新增', N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (62, N'btn_modify', N'编辑', N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (63, N'btn_delete', N'删除', N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (64, N'btn_search', N'搜索', N'other_sild_item_default')
INSERT [EDNF_Account_PermissionActions] ([ActionID], [ActionCode], [Description], [PermissionCode]) VALUES (65, N'btn_recycle', N'回收', N'product_item_index')
SET IDENTITY_INSERT [EDNF_Account_PermissionActions] OFF

GO