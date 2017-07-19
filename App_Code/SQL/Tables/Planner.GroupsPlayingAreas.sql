USE [GoTournamental]
GO

/****** Object: Table [dbo].[GroupsPlayingAreas] Script Date: 28/03/2015 07:25:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[GroupsPlayingAreas] (
    [ID]            INT IDENTITY (1, 1) NOT NULL,
    [GroupID]       INT NULL,
    [PlayingAreaID] INT NULL, 
    CONSTRAINT [PK_GroupsPlayingAreas] PRIMARY KEY ([ID])
);


