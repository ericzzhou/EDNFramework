GO

CREATE TABLE [EDNF_CMS_Photo](
	[PhotoID] [int] IDENTITY(1,1) NOT NULL,
	[PhotoName] [varchar](200) NULL,
	[ImageUrl] [varchar](200) NOT NULL,
	[Description] [varchar](500) NULL,
	[AlbumID] [int] NOT NULL DEFAULT(0),
	[State] [bit] NOT NULL DEFAULT(0),
	[CreatedUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[PVCount] [int] NOT NULL DEFAULT(0),
	[ClassID] [int] NOT NULL DEFAULT(0),
	[ThumbImageUrl] [varchar](200) NULL,
	[NormalImageUrl] [varchar](200) NULL,
	[Sequence] [int] NOT NULL DEFAULT(0),
	[IsRecomend] [bit] NOT NULL DEFAULT(0),
	[CommentCount] [int] NOT NULL DEFAULT(0),
	[Tags] [varchar](200) NULL,
	[FavouriteCount] [int] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_EDNF_CMS_Photo] PRIMARY KEY CLUSTERED 
(
	[PhotoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO