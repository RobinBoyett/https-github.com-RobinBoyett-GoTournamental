USE [GoTournamental]
GO

/****** Object: Table [dbo].[PlayingAreas] Script Date: 28/03/2015 07:26:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[PlayingAreas] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
    [TournamentID] INT          NULL,
    [Name]         VARCHAR (50) NULL, 
    CONSTRAINT [PK_PlayingAreas] PRIMARY KEY ([ID])
);


