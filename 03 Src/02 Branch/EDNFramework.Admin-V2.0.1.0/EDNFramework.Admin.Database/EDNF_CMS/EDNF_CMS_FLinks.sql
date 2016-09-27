GO

CREATE TABLE [EDNF_CMS_FLinks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ImgUrl] [varchar](150) NULL,
	[LinkUrl] [varchar](150) NULL,
	[LinkDesc] [nvarchar](300) NULL,
	[State] [bit] NOT NULL DEFAULT(0),
	[OrderID] [int] NOT NULL DEFAULT(0),
	[ContactPerson] [nvarchar](30) NULL,
	[Email] [nvarchar](100) NULL,
	[TelPhone] [nvarchar](30) NULL,
	[TypeID] [smallint] NOT NULL  DEFAULT(0),
	[IsDisplay] [bit] NOT NULL  DEFAULT(0),
	[ImgWidth] [int] NULL,
	[ImgHeight] [int] NULL,
 CONSTRAINT [PK_EDNF_CMS_FLinks] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO