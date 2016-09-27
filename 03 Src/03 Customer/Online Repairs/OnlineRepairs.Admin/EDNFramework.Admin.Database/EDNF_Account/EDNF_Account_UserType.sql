GO

CREATE TABLE [EDNF_Account_UserType](
	[UserType] [char](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

INSERT [EDNF_Account_UserType] ([UserType],[Description]) VALUES ( N'AA',N'管理员')
INSERT [EDNF_Account_UserType] ([UserType],[Description]) VALUES ( N'UU',N'普通用户')
INSERT [EDNF_Account_UserType] ([UserType],[Description]) VALUES ( N'UU',N'维修人员')


GO