CREATE TABLE [dbo].[Hypermedia](
	[Href] [nvarchar](500) NOT NULL,
	[Target] [nvarchar](20) NULL,
	[Text] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Object] [nvarchar](50) NOT NULL,
	[ObjectId] [int] NOT NULL,
	[ClientToken] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime] NOT NULL DEFAULT GETDATE(),
	[DateModified] [datetime] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY
)
