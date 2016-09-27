GO

CREATE TABLE [EDNF_SYS_Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[datetime] [datetime] NOT NULL DEFAULT(GETDATE()),
	[loginfo] [varchar](500) NULL,
	[Particular] [varchar](1000) NULL
) ON [PRIMARY]

GO