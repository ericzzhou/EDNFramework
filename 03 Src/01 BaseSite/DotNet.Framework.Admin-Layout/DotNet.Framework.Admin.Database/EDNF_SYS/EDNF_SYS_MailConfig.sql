GO

CREATE TABLE [EDNF_SYS_MailConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Mailaddress] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[SMTPServer] [nvarchar](50) NULL,
	[SMTPPort] [int] NULL,
	[SMTPSSL] [bit] NOT NULL DEFAULT(0),
	[POPServer] [nvarchar](50) NULL,
	[POPPort] [int] NULL,
	[POPSSL] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_EDNF_SYS_MailConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


IF((SELECT COUNT(UserID) FROM EDNF_SYS_MailConfig WHERE UserID = -1) > 0)
	BEGIN
		INSERT INTO [EDNF_SYS_MailConfig]
           ([UserID]
           ,[Mailaddress]
           ,[Username]
           ,[Password]
           ,[SMTPServer]
           ,[SMTPPort]
           ,[SMTPSSL]
           ,[POPServer]
           ,[POPPort]
           ,[POPSSL])
     VALUES
           (-1
           ,N''
           ,N''
           ,N''
           ,N''
           ,N''
           ,N''
           ,N''
           ,N''
           ,N'')
	END

GO