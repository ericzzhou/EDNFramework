GO

CREATE TABLE [EDNF_SYS_SiteMessage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SenderID] [int] NULL,
	[ReceiverID] [int] NULL,
	[Title] [nvarchar](300) NULL,
	[Content] [nvarchar](max) NULL,
	[MsgType] [nvarchar](50) NULL,
	[SendTime] [datetime] NOT NULL DEFAULT(GETDATE()),
	[ReadTime] [datetime] NULL,
	[ReceiverIsRead] [bit] NOT NULL DEFAULT(0),
	[SenderIsDel] [bit] NOT NULL DEFAULT(0),
	[ReaderIsDel] [bit] NOT NULL DEFAULT(0),
	[Ext1] [nvarchar](300) NULL,
	[Ext2] [nvarchar](300) NULL,
 CONSTRAINT [PK_EDNF_SYS_SiteMessage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO