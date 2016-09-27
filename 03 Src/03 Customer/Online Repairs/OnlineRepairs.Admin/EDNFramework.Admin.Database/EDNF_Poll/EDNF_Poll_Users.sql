GO

CREATE TABLE [EDNF_Poll_Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](500) NULL,
	[TrueName] [varchar](50) NULL,
	[Age] [int] NULL,
	[Sex] [char](2) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[UserType] [char](10) NULL,
 CONSTRAINT [PK_EDNF_Poll_Users] PRIMARY KEY NONCLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO