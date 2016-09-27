
GO

CREATE TABLE [Hospital_NormItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemCode] [varchar](200) NULL,
	[ItremName] [nvarchar](200) NOT NULL,
	[ItemCategory] [int] NULL,
	[ItemCreateTime] [datetime] NOT NULL DEFAULT(GETDATE()),
	[ItemStopTime] [datetime] NULL,
	[ItemStatus] [char](1) NOT NULL,
 CONSTRAINT [PK_Hospital_NormItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

