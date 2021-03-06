﻿GO

CREATE TABLE [EDNF_SYS_UserLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OPTime] [datetime] NOT NULL DEFAULT(GETDATE()),
	[Url] [varchar](200) NULL,
	[OPInfo] [nvarchar](max) NULL,
	[UserName] [varchar](50) NULL,
	[UserType] [char](10) NULL,
	[UserIP] [varchar](20) NULL,
 CONSTRAINT [PK_EDNF_SYS_UserLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO