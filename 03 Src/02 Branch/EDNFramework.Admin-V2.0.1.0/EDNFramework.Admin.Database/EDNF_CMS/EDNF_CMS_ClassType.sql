﻿GO


CREATE TABLE [EDNF_CMS_ClassType](
	[ClassTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ClassTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EDNF_CMS_ClassType] PRIMARY KEY NONCLUSTERED 
(
	[ClassTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO [EDNF_CMS_ClassType] ([ClassTypeName]) VALUES ('主导航')
INSERT INTO [EDNF_CMS_ClassType] ([ClassTypeName]) VALUES ('频道板块')
GO

