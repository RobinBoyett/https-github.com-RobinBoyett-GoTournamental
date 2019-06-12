USE [GoTournamental]
GO

/****** Object: Table [dbo].[Competitions] Script Date: 28/03/2015 07:19:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Competitions] (
    [ID]                INT      IDENTITY (1, 1) NOT NULL,
    [TournamentID]      INT      NULL,
    [AgeBand]           INT      NULL,
    [StartTime]         DATETIME NULL,
    [Session]           INT      NULL,
    [CompetitionFormat] INT      NULL,
    [FixtureTurnaround] INT      NULL,
	[FixtureStructure] INT	 NULL,
	[FixtureHalvesLength] INT	 NULL,
    [TeamSize]          INT      NULL,
    [SquadSize]         INT      NULL,
    CONSTRAINT [PK_Competitions] PRIMARY KEY ([ID])
);


