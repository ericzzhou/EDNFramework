GO


CREATE TABLE [EDNF_Account_PermissionActions](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[ActionCode] [varchar](100) NOT NULL,
	[Description] [varchar](200) NULL,
	[PermissionCode] [varchar](100) NOT NULL,
 CONSTRAINT [PK_EDNF_Account_PermissionActions] PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
