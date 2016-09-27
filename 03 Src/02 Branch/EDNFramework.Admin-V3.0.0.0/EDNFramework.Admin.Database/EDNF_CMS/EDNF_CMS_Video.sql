GO


CREATE TABLE [EDNF_CMS_Video](
	[VideoID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Description] [ntext] NULL,
	[AlbumID] [int] NULL,
	[CreatedUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[LastUpdateUserID] [int] NULL,
	[LastUpdateDate] [datetime] NULL,
	[Sequence] [int] NOT NULL DEFAULT(0),
	[VideoClassID] [int] NULL,
	[IsRecomend] [bit] NOT NULL DEFAULT(0),
	[ImageUrl] [varchar](100) NULL,
	[ThumbImageUrl] [varchar](100) NULL,
	[NormalImageUrl] [varchar](100) NULL,
	[TotalTime] [int] NULL,
	[TotalComment] [int] NOT NULL DEFAULT(0),
	[TotalFav] [int] NOT NULL DEFAULT(0),
	[TotalUp] [int] NOT NULL DEFAULT(0),
	[Reference] [int] NOT NULL DEFAULT(0),
	[Tags] [varchar](100) NULL,
	[VideoUrl] [nvarchar](max) NULL,
	[UrlType] [smallint] NOT NULL DEFAULT(1),
	[VideoFormat] [varchar](50) NULL,
	[Domain] [varchar](50) NULL,
	[Grade] [int] NOT NULL DEFAULT(0),
	[Attachment] [varchar](100) NULL,
	[Privacy] [bit] NOT NULL DEFAULT(0),
	[State] [bit] NOT NULL DEFAULT(0),
	[Remark] [varchar](300) NULL,
	[PVCount] [int] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_EDNF_CMS_Video] PRIMARY KEY CLUSTERED 
(
	[VideoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO