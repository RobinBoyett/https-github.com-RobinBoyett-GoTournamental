USE [GoTournamental]
GO

/****** Object: Table [dbo].[Groups] Script Date: 28/03/2015 07:24:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Groups] (
    [ID]                INT          IDENTITY (1, 1) NOT NULL,
    [CompetitionID]     INT          NULL,
    [Name]              VARCHAR (50) NULL,
    [FixtureTurnaround] INT          NULL,
    [FixturesUnderWay] BIT NULL, 
    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([ID] ASC)
);



