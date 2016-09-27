GO


CREATE TABLE [EDNF_CMS_ContentClass](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](50) NOT NULL,
	[ClassIndex] [varchar](50) NULL,
	[Sequence] [int] NOT NULL DEFAULT(0),
	[ParentId] [int] NULL,
	[State] [bit] NOT NULL DEFAULT(0),
	[AllowSubclass] [bit] NOT NULL DEFAULT(1),
	[AllowAddContent] [bit] NOT NULL DEFAULT(1),
	[ImageUrl] [nvarchar](200) NULL,
	[Description] [text] NULL,
	[Keywords] [varchar](50) NULL,
	[ClassTypeID] [int] NOT NULL,
	[ClassModel] [smallint] NOT NULL,
	[PageModelName] [varchar](200) NULL,
	[CreatedDate] [datetime] NULL DEFAULT(GETDATE()),
	[CreatedUserID] [int] NOT NULL,
	[Path] [varchar](1000) NULL,
	[Depth] [int] NOT NULL DEFAULT(1),
	[Remark] [varchar](200) NULL,
	[Meta_Title] [nvarchar](1000) NULL,
	[Meta_Description] [nvarchar](1000) NULL,
	[Meta_Keywords] [nvarchar](1000) NULL,
	[SeoUrl] [nvarchar](300) NULL,
	[SeoImageAlt] [nvarchar](300) NULL,
	[SeoImageTitle] [nvarchar](300) NULL,
	[IndexChar] [nvarchar](200) NULL,
 CONSTRAINT [PK_EDNF_CMS_ContentClass] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO