GO

CREATE TABLE [EDNF_CMS_Advertisement](
	[AdvertisementId] [int] IDENTITY(1,1) NOT NULL,
	[AdvertisementName] [nvarchar](50) NULL,
	[AdvPositionId] [int] NULL,
	[ContentType] [int] NULL,
	[FileUrl] [nvarchar](200) NULL,
	[AlternateText] [nvarchar](200) NULL,
	[NavigateUrl] [nvarchar](200) NULL,
	[AdvHtml] [nvarchar](max) NULL,
	[Impressions] [int] NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[CreatedUserID] [int] NULL,
	[State] [bit] NOT NULL DEFAULT(0),
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[DayMaxPV] [int] NULL,
	[DayMaxIP] [int] NULL,
	[CPMPrice] [money] NULL,
	[AutoStop] [bit] NOT NULL DEFAULT(0),
	[Sequence] [int] NOT NULL DEFAULT(0),
	[EnterpriseID] [int] NULL,
 CONSTRAINT [PK_EDNF_CMS_Advertisement] PRIMARY KEY CLUSTERED 
(
	[AdvertisementId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO