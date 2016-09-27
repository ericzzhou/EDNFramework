
CREATE TABLE [Hospital_NormValue](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NormID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Value] decimal(18,2) NOT NULL DEFAULT(0),
	[InDate] [datetime] NOT NULL DEFAULT(GETDATE()),
	[InUser] [int] NOT NULL DEFAULT(0),
	[OccurrenceTime] [datetime] NOT NULL,
 CONSTRAINT [PK_EDNF_Hospital_NormValue] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


