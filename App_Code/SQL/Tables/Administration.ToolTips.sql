USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Administration].[ToolTips] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [WebPage]				VARCHAR (200)  NOT NULL,
    [ControlID]				VARCHAR (200)  NOT NULL,
    [ToolTipText]           VARCHAR(MAX)   NOT NULL,
    [UserID]				VARCHAR (200)  NOT NULL,
	[DateModified]				DATETIME NOT NULL
    CONSTRAINT [PK_ToolTips] PRIMARY KEY ([ID])
);


