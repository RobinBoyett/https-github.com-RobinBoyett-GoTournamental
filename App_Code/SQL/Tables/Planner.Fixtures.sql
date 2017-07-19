USE [GoTournamental]
GO

/****** Object: Table [dbo].[Fixtures] Script Date: 28/03/2015 07:23:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Fixtures] (
    [ID]                INT          IDENTITY (1, 1) NOT NULL,
    [CompetitionID]     INT          NULL,
    [GroupID]           INT          NULL,
    [PlayingAreaID]     INT          NULL,
    [Name]              VARCHAR (50) NULL,
    [StartTime]         DATETIME     NULL,
    [IsLeagueFixture]   BIT          NULL,
    [HomeTeamID]        INT          NULL,
    [HomeTeamScore]     INT          NULL,
    [AwayTeamID]        INT          NULL,
    [AwayTeamScore]     INT          NULL,
    [PrimaryOfficialID] INT          NULL, 
    CONSTRAINT [PK_Fixtures] PRIMARY KEY ([ID])
);


