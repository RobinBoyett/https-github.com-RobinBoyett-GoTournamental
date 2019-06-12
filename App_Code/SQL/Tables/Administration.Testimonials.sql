USE [GoTournamental]
GO

/****** Object: Table [Administration].[ToolTips] Script Date: 14/05/2018 09:28:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Administration].[Testimonials] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [ContactName]  VARCHAR (200) NULL,
    [ContactRole]  VARCHAR (200) NULL,
    [Organisation] VARCHAR (200) NULL,
    [Snippet]      VARCHAR (200) NULL,
    [MainText]     VARCHAR (MAX) NULL,
    [DateModified] DATETIME      NOT NULL, 
    [LogoFileName] VARCHAR(50) NULL
);


