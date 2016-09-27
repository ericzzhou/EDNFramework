GO

CREATE TABLE [EDNF_SYS_EmailQueue](
	[EmailId] [int] IDENTITY(1,1) NOT NULL,
	[EmailPriority] [int] NOT NULL DEFAULT(0),
	[IsBodyHtml] [bit] NOT NULL DEFAULT(1),
	[EmailTo] [nvarchar](2000) NOT NULL,
	[EmailCc] [ntext] NULL,
	[EmailBcc] [ntext] NULL,
	[EmailFrom] [nvarchar](256) NULL,
	[EmailSubject] [nvarchar](1024) NOT NULL,
	[EmailBody] [ntext] NOT NULL,
	[NextTryTime] [datetime] NOT NULL,
	[NumberOfTries] [int] NOT NULL DEFAULT(0),
	[Successed] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_EDNF_SYS_EmailQueue] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO