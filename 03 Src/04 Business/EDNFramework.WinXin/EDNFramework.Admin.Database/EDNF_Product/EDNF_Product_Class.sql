GO


CREATE TABLE [EDNF_Product_Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[ClassIndex] [varchar](50) NULL,
	[Sequence] [int] NOT NULL DEFAULT(0),
	[ParentId] [int] NULL,
	[Activity] [bit] NOT NULL DEFAULT(0),
	[AllowAddContent] [bit] NOT NULL DEFAULT(1),
	[ImageUrl] [nvarchar](200) NULL,
	[Description] [nvarchar](max) NULL,
	[Keywords] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL DEFAULT(GETDATE()),
	[CreatedUserID] [int] NOT NULL,
	[LastEditDate] [datetime] NULL,
	[LastEditUserID] [int] NULL,
	[Path] [varchar](1000) NULL,
	[Depth] [int] NOT NULL DEFAULT(1),
	[Remark] [nvarchar](200) NULL,
	[Meta_Title] [nvarchar](1000) NULL,
	[Meta_Description] [nvarchar](1000) NULL,
	[Meta_Keywords] [nvarchar](1000) NULL,
	[SeoUrl] [nvarchar](300) NULL,
	[SeoImageAlt] [nvarchar](300) NULL,
	[SeoImageTitle] [nvarchar](300) NULL,
	[IndexChar] [nvarchar](200) NULL,
	[Domain] [nvarchar](200) NULL,
 CONSTRAINT [PK_EDNF_Product_Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

INSERT INTO [[EDNF_Product_Class]
           ([ClassName]
           ,[Sequence]
           ,[Activity]
           ,[AllowAddContent]
           ,[Description]
           ,[CreatedDate]
           ,[CreatedUserID] )
     VALUES
           (N'默认分类'
           ,1
           ,1
           ,1
           ,N'默认分类'
           ,GETDATE()
           ,1)
GO

