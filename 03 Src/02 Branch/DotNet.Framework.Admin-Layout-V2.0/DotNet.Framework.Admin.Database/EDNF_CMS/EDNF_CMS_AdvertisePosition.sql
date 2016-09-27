GO

CREATE TABLE [EDNF_CMS_AdvertisePosition](
	[AdvPositionId] [int] IDENTITY(1,1) NOT NULL,
	[AdvPositionName] [nvarchar](50) NOT NULL,
	[ShowType] [int] NOT NULL DEFAULT(0),
	[RepeatColumns] [int] NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[AdvHtml] [nvarchar](1000) NULL,
	[IsOne] [bit] NOT NULL DEFAULT(0),
	[TimeInterval] [int] NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[CreatedUserID] [int] NULL,
 CONSTRAINT [PK_EDNF_CMS_AdvertisePosition] PRIMARY KEY CLUSTERED 
(
	[AdvPositionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO