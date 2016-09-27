GO

CREATE TABLE [EDNF_Account_Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ShortName] [nvarchar](100) NULL,
	[ParentID] [int] NOT NULL DEFAULT(0),
	[Type] [char](10) NULL,
	[Manager] [varchar](50) NULL,
	[Manager2] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[ExtNumber] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Status] [char](10) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_EDNF_Account_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

