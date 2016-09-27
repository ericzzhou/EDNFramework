GO

CREATE TABLE [EDNF_CMS_PhotoAlbum](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [varchar](200) NOT NULL,
	[Description] [text] NULL,
	[CoverPhoto] [int] NULL,
	[State] [bit] NOT NULL DEFAULT(0),
	[CreatedUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[PVCount] [int] NOT NULL DEFAULT(0),
	[Sequence] [int] NOT NULL DEFAULT(0),
	[Privacy] [bit] NOT NULL DEFAULT(0),
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_EDNF_CMS_PhotoAlbum] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO