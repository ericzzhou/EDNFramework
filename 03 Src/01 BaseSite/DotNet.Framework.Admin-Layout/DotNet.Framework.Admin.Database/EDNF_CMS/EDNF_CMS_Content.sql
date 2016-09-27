GO


CREATE TABLE [EDNF_CMS_Content](
	[ContentID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[SubTitle] [nvarchar](300) NULL,
	[Summary] [nvarchar](600) NULL,
	[Description] [text] NULL,
	[ImageUrl] [varchar](500) NULL,
	[ThumbImageUrl] [varchar](500) NULL,
	[NormalImageUrl] [varchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[CreatedUserID] [int] NOT NULL,
	[LastEditUserID] [int] NULL,
	[LastEditDate] [datetime] NULL,
	[LinkUrl] [nvarchar](500) NULL,
	[PvCount] [int] NOT NULL DEFAULT(0),
	[State] [bit] NOT NULL DEFAULT(0),
	[ClassID] [int] NOT NULL,
	[Keywords] [nvarchar](200) NULL,
	[Sequence] [int] NOT NULL DEFAULT(0),
	[IsRecomend] [bit] NOT NULL DEFAULT(0),
	[IsHot] [bit] NOT NULL DEFAULT(0),
	[IsColor] [bit] NOT NULL DEFAULT(0),
	[IsTop] [bit] NOT NULL DEFAULT(0),
	[Attachment] [varchar](200) NULL,
	[Remary] [varchar](200) NULL,
	[TotalComment] [int] NOT NULL DEFAULT(0),
	[TotalSupport] [int] NOT NULL DEFAULT(0),
	[TotalFav] [int] NOT NULL DEFAULT(0),
	[TotalShare] [int] NOT NULL DEFAULT(0),
	[BeFrom] [nvarchar](50) NULL,
	[FileName] [nvarchar](200) NULL,
	[Meta_Title] [nvarchar](1000) NULL,
	[Meta_Description] [nvarchar](1000) NULL,
	[Meta_Keywords] [nvarchar](1000) NULL,
	[SeoUrl] [nvarchar](300) NULL,
	[SeoImageAlt] [nvarchar](300) NULL,
	[SeoImageTitle] [nvarchar](300) NULL,
	[StaticUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_EDNF_CMS_Content] PRIMARY KEY NONCLUSTERED 
(
	[ContentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO