GO

CREATE TABLE [EDNF_CMS_VideoAlbum](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [varchar](100) NOT NULL,
	[CoverVideo] [varchar](200) NULL,
	[Description] [text] NULL,
	[CreatedUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[LastUpdateUserID] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[State] [bit] NOT NULL DEFAULT(0),
	[Sequence] [int] NOT NULL DEFAULT(0),
	[Privacy] [bit] NOT NULL DEFAULT(0),
	[PvCount] [int] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_EDNF_CMS_VideoAlbum] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO