USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Administration].[Exceptions] (
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] NVARCHAR (128) NULL,
	[UserIPAddress] [varchar](500) NULL,
	[LoggedDate] [datetime] NULL,
	[ReferringURL] [varchar](500) NULL,
	[RequestedURL] [varchar](500) NULL,
	[TypeName] [varchar](500) NULL,
	[Message] [varchar](max) NULL,
	[StackTrace] [varchar](max) NULL,
    CONSTRAINT [PK_Exceptions] PRIMARY KEY ([ID])
);

