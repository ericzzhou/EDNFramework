GO

CREATE TABLE [EDNF_Account_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](500) NOT NULL,
	[NickName] [varchar](50) NULL,
	[TrueName] [varchar](50) NULL,
	[Sex] [char](10) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[EmployeeID] [int] NULL,
	[DepartmentID] [varchar](15) NULL,
	[Activity] [bit] NOT NULL DEFAULT(0),
	[UserType] [char](2) NULL,
	[Style] [int] NULL,
	[User_iCreator] [int] NULL,
	[User_dateCreate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[User_dateValid] [datetime] NULL,
	[User_dateExpire] [datetime] NULL,
	[User_iApprover] [int] NULL,
	[User_dateApprove] [datetime] NULL,
	[User_iApproveState] [int] NULL,
	[User_cLang] [varchar](10) NULL,
	[auth_token] [varchar](500) NULL,
 CONSTRAINT [PK_EDNF_Account_User] PRIMARY KEY NONCLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*默认管理员账号 admin  密码 admin888*/
IF ((SELECT COUNT(UserID) FROM [EDNF_Account_User] WHERE [UserName] = 'admin') <= 0)
	BEGIN
		INSERT INTO [EDNF_Account_User] 
		([UserName],[Password],[NickName],[TrueName],[Sex],[Phone],[Email],[Activity],[UserType]) 
		VALUES 
		(N'admin',N'AC6BA01828733094F88CFC385EBDA78B',N'管理员',N'管理员',N'男',N'15829082171',N'zhouzhaokun@gmail.com',1,N'AA')
	END

GO