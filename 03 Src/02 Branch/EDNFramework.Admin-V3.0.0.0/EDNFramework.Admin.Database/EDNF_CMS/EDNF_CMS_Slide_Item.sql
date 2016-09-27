GO

CREATE TABLE [EDNF_CMS_Slide_Item](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SlideID] [int] NOT NULL  DEFAULT ((0)),
	[Name] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Href] [nvarchar](500) NOT NULL DEFAULT (''),
	[FilePath] [nvarchar](500) NULL,
	[Enable] [bit] NOT NULL DEFAULT ((0)),
	[sequence] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_EDNF_CMS_Slide_Item_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO