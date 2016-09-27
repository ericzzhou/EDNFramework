GO

CREATE TABLE [EDNF_Account_RolePermissions](
	[ARPID] uniqueidentifier NOT NULL,
	[RoleID] [int] NOT NULL,
	[PermissionCode] [varchar](100) NOT NULL,
 CONSTRAINT [PK_EDNF_Account_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[ARPID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'c5adc3fb-2675-4626-b2a1-0c6d82d001bd', 1, N'root_product')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'aade0a05-ebba-45b1-9f60-1583156d0229', 1, N'Account_RolePermission_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'576b0615-ead2-40d1-b5f7-15b5c1888b41', 1, N'article_category_add')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'35fa5aca-7392-4ba0-9450-3fafefbadbf3', 1, N'root_article')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'90fb8e31-0ca1-4133-922e-3fc372f90637', 1, N'Account_Permission_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'a5e30917-c13e-4740-902e-461a2aafee3d', 1, N'log_sys_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'b8a3b8f9-cf0e-46ec-883c-58d4d152901c', 1, N'product_category_add')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'25fe0907-6339-4a23-9d0c-67e5b50f2ced', 1, N'product_item_add')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'75519f18-1d50-44b5-9baa-7564366d175f', 1, N'product_item_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'b2cbc4e3-a347-4fa3-b6f2-765d9097ee00', 1, N'product_category_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'e969efdf-fb66-4051-a43f-7a3a6b97eb79', 1, N'Account_Department_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'7dded5af-983d-4c73-8fde-84c9fb829639', 1, N'root_Account')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'940404f6-1314-47e8-848c-a04834e92307', 1, N'log_operation_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'3ad7681f-de0f-49b1-929b-adafcf3c7939', 1, N'Account_User_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'bd68e59f-218e-42f3-8492-c61bf16c1d4b', 1, N'article_category_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'0c51c814-f274-4adf-8b35-d598d18bfc96', 1, N'Account_Role_Index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'68e25ca2-d7d4-4372-9790-d636304d0a76', 1, N'log_user_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'a93f23d3-5eb8-4472-8f2e-de7253d77524', 1, N'article_item_index')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'f61dda1e-a1dc-458b-9e5e-dec56ad348b0', 1, N'article_item_add')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'29dd6036-1ee4-40f2-bd8a-eb0759534137', 1, N'root_controlpanel')
INSERT [EDNF_Account_RolePermissions] ([ARPID], [RoleID], [PermissionCode]) VALUES (N'86c0cf32-95f6-4890-aad2-f5567107ee6a', 1, N'root_log')

GO