GO

CREATE TABLE [EDNF_Account_PermissionCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_EDNF_Account_PermissionCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [EDNF_Account_PermissionCategories] ([Description]) VALUES (N'系统功能管理')
INSERT INTO [EDNF_Account_PermissionCategories] ([Description]) VALUES (N'主菜单管理')
INSERT INTO [EDNF_Account_PermissionCategories] ([Description]) VALUES (N'基础数据')

GO