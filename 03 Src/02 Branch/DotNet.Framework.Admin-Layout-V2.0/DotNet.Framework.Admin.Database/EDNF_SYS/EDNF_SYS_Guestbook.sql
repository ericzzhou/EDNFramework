GO

CREATE TABLE [EDNF_SYS_Guestbook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateUserID] [int] NULL,
	[CreateNickName] [nvarchar](50) NOT NULL DEFAULT(N'匿名'),
	[ToUserID] [int] NULL,
	[ToNickName] [nvarchar](50) NULL,
	[CreatorUserIP] [nvarchar](20) NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[CreatorEmail] [nvarchar](50) NULL,
	[CreatorRegion] [nvarchar](50) NULL,
	[CreatorCompany] [nvarchar](100) NULL,
	[CreatorPageSite] [nvarchar](200) NULL,
	[CreatorPhone] [nvarchar](20) NULL,
	[CreatorQQ] [nvarchar](50) NULL,
	[CreatorMsn] [nvarchar](50) NULL,
	[CreatorSex] [bit] NULL,
	[HandlerNickName] [nvarchar](50) NULL,
	[HandlerUserID] [int] NULL,
	[HandlerDate] [datetime] NULL,
	[Privacy] [bit] NOT NULL DEFAULT(0),
	[ReplyCount] [int] NOT NULL DEFAULT(0),
	[ParentID] [int] NULL,
	[Status] [bit] NOT NULL DEFAULT(0),
	[ReplyDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_EDNF_SYS_Guestbook] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO