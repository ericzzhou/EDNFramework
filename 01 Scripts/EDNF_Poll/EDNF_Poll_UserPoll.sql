GO

CREATE TABLE [EDNF_Poll_UserPoll](
	[UserID] [int] NOT NULL,
	[TopicID] [int] NOT NULL DEFAULT(0),
	[OptionID] [int] NULL,
	[CreatTime] [datetime] NOT NULL DEFAULT(GETDATE()),
	[UserIP] [varchar](20) NULL
) ON [PRIMARY]

GO