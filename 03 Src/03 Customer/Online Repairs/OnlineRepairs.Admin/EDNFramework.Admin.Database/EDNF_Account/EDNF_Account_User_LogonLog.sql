GO

CREATE TABLE [EDNF_Account_User_LogonLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[LogonTime] [datetime] NOT NULL DEFAULT(GETDATE()),
	[Status] [nvarchar](50) NULL,
	[StatusDescription] [NVARchar](200) NULL,
	[LogonIP] [varchar] NULL,
 CONSTRAINT [PK_EDNF_Account_User_LogonLog] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

