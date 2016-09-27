GO

CREATE TABLE [EDNF_SYS_FloatAD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Left_Width] [int] NOT NULL,
	[Left_Height] [int] NOT NULL,
	[Left_left] [int] NULL DEFAULT(10),
	[Left_top] [int] NULL DEFAULT(50),
	[Left_Body] [nvarchar](4000) NULL,
	[Left_Enable] [bit] NULL DEFAULT(0),
	[Right_Width] [int] NOT NULL,
	[Right_Height] [int] NOT NULL,
	[Right_right] [int] NULL DEFAULT(10),
	[Right_top] [int] NULL DEFAULT(50),
	[Right_Body] [nvarchar](4000) NULL,
	[Right_Enable] [bit] NULL DEFAULT(0),
 CONSTRAINT [PK_EDNF_SYS_FloatAD_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO