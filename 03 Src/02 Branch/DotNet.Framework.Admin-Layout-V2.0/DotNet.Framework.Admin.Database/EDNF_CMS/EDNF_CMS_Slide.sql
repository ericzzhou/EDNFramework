﻿CREATE TABLE [EDNF_CMS_Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Width] [int] NOT NULL DEFAULT ((0)),
	[Height] [int] NOT NULL DEFAULT ((0)),
	[ItemType] [nvarchar](50) NULL,
	[delay] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_EDNF_CMS_Slide_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO