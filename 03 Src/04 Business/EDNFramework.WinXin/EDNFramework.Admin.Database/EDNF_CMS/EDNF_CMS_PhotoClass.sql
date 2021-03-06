﻿GO

CREATE TABLE [EDNF_CMS_PhotoClass](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](200) NOT NULL,
	[ParentId] [int] NOT NULL DEFAULT(0),
	[Sequence] [int] NOT NULL DEFAULT(0),
	[Path] [varchar](200) NULL,
	[Depth] [int] NOT NULL DEFAULT(1)
 CONSTRAINT [PK_EDNF_CMS_PhotoClass] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO