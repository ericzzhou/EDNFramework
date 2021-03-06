﻿GO

CREATE TABLE [EDNF_Poll_Reply](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TopicID] [int] NOT NULL DEFAULT(0),
	[ReContent] [varchar](300) NULL,
	[ReTime] [datetime] NOT NULL DEFAULT(GETDATE()),
 CONSTRAINT [PK_EDNF_Poll_Reply] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO