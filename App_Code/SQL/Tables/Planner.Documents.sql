USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Documents] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [TournamentID] INT           NULL,
    [DocumentType] INT           NULL,
    [FileName]     VARCHAR (100) NULL, 
    CONSTRAINT [PK_Documents] PRIMARY KEY ([ID])
);


