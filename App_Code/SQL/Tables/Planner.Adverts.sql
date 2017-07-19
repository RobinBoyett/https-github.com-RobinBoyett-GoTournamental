USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Adverts] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [AdvertiserID]    INT           NULL,
    [GraphicFileName] VARCHAR (100) NULL,
    [GraphicFileType] INT           NULL,
    [GraphicStyle]    INT           NULL,
    [ClicksThrough]   INT           NULL, 
    CONSTRAINT [PK_Adverts] PRIMARY KEY ([ID])
);


