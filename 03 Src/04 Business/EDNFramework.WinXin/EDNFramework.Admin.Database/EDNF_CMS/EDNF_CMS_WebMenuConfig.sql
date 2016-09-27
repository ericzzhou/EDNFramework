GO

CREATE TABLE [EDNF_CMS_WebMenuConfig](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[NavURL] [nvarchar](max) NULL,
	[MenuTitle] [nvarchar](50) NULL,
	[MenuType] [int] NOT NULL DEFAULT(0),
	[Target] [int] NOT NULL DEFAULT(0),
	[IsUsed] [bit] NOT NULL DEFAULT(1),
	[Sequence] [int] NOT NULL DEFAULT(0),
	[Visible] [int] NOT NULL DEFAULT(1),
 CONSTRAINT [PK_EDNF_CMS_WebMenuConfig] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO