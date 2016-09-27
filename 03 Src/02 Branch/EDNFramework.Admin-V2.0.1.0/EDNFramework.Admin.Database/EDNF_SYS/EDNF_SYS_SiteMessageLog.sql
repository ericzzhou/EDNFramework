GO

CREATE TABLE [EDNF_SYS_SiteMessageLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MessageID] [int] NULL,
	[MessageType] [nvarchar](50) NULL,
	[MessageState] [nvarchar](50) NULL,
	[ReceiverID] [int] NULL,
	[Ext1] [nvarchar](300) NULL,
	[Ext2] [nvarchar](300) NULL,
 CONSTRAINT [PK_EDNF_SYS_SiteMessageLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO