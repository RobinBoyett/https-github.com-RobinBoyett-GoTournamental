USE [GoTournamental]
GO

/****** Object: Table [dbo].[FileImportAudits] Script Date: 28/03/2015 07:22:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Administration].[FileImportAudits] (
    [ID]                 INT IDENTITY (1, 1) NOT NULL,
    [TournamentID]       INT NULL,
    [FileType]           INT NULL,
    [NoClubs]            INT NULL,
    [NoCompetitions]     INT NULL,
    [NoTeams]            INT NULL,
    [NoPrimaryOfficials] INT NULL,
    [NoSponsors]         INT NULL, 
    CONSTRAINT [PK_FileImportAudits] PRIMARY KEY ([ID])
);


