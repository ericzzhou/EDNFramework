GO

CREATE TABLE [EDNF_SYS_ErrorLog](
	[ID]		 [int] IDENTITY(1,1) NOT NULL,
	[OPTime]	 [datetime] NULL,
	[Url]		 [varchar](max) NULL,
	[Loginfo]	 [varchar](max) NULL,
	[StackTrace] [varchar](max) NULL,
	[ErrorType]	 [varchar](100) NULL,
	[Domain]	 [varchar](200) NULL,
 CONSTRAINT [PK_EDNF_SYS_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO