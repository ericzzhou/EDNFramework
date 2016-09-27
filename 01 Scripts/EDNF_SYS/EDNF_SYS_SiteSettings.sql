GO

CREATE TABLE [EDNF_SYS_SiteSettings](
	[SettingsId] [int] IDENTITY(100,1) NOT NULL,
	[Disabled] [bit] NOT NULL DEFAULT(0),
	[Version] [nvarchar](64) NULL,
	[SettingsXML] [ntext] NULL,
	[SettingsKey] [uniqueidentifier] NULL,
	[ApplicationName] [nvarchar](256) NULL,
 CONSTRAINT [PK_EDNF_SYS_SiteSettings] PRIMARY KEY CLUSTERED 
(
	[SettingsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO