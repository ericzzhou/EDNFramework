GO

CREATE TABLE [EDNF_CMS_VideoClass](
	[VideoClassID] [int] IDENTITY(1,1) NOT NULL,
	[VideoClassName] [varchar](100) NOT NULL,
	[ParentID] [int] NOT NULL DEFAULT(0),
	[Sequence] [int] NOT NULL DEFAULT(0),
	[Path] [varchar](1000) NOT NULL,
	[Depth] [int] NOT NULL DEFAULT(1),
 CONSTRAINT [PK_EDNF_CMS_VideoClass] PRIMARY KEY CLUSTERED 
(
	[VideoClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [EDNF_CMS_VideoClass]([VideoClassName],[ParentID],[Sequence],[Path],[Depth])
		VALUES (N'原创',0,0,N'1' ,1)
GO




