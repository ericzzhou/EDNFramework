GO

CREATE TABLE [EDNF_Account_UserBind](
	[BindId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [nvarchar](200) NULL,
	[MediaUserID] [int] NOT NULL DEFAULT(0),
	[MediaNickName] [nvarchar](200) NULL,
	[MediaID] [int] NOT NULL,
	[iHome] [bit] NOT NULL DEFAULT(0),
	[Comment] [bit] NOT NULL DEFAULT(0),
	[GroupTopic] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_EDNF_Account_UserBind] PRIMARY KEY CLUSTERED 
(
	[BindId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

