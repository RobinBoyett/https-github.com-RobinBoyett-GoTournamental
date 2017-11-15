USE [GoTournamental]
GO

/****** Object: Table [dbo].[Tournaments] Script Date: 28/03/2015 07:28:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Tournaments] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [Type]              INT           NULL,
    [Name]              VARCHAR (100) NULL,
    [Affiliation]       INT           NULL,
    [StartTime]         DATETIME      NULL,
    [EndTime]           DATETIME      NULL,
    [Venue]             VARCHAR (100) NULL,
    [Postcode]          VARCHAR (10)  NULL,
    [GoogleMapsURL]     VARCHAR (500) NULL,
    [NoOfPlayingAreas]  INT           NULL,
    [FixtureTurnaround] INT           NULL,
    [FixtureHalvesNumber] INT           NULL,
    [FixtureHalvesLength] INT           NULL,
    [TeamSize]          INT           NULL,
    [SquadSize]         INT           NULL,
    [RotatorDate]       DATETIME      NULL,
    [RotatorSession]    INT           NULL, 
    CONSTRAINT [PK_Tournaments] PRIMARY KEY ([ID])
);

