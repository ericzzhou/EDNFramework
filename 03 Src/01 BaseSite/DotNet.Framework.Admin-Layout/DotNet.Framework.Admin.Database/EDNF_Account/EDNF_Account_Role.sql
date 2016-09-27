GO

CREATE TABLE [EDNF_Account_Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_EDNF_Account_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [EDNF_Account_Role] ([RoleName],[Description]) VALUES ( N'系统管理员',N'拥有管理权限的账号集团')

GO

INSERT INTO [EDNF_Account_Role] ([RoleName],[Description]) VALUES ( N'普通用户',N'')

GO