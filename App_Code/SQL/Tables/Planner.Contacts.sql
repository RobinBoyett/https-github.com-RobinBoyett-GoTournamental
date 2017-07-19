USE [GoTournamental]
GO

/****** Object: Table [dbo].[Contacts] Script Date: 28/03/2015 07:20:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Contacts] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [TournamentID]    INT           NULL,
    [Type]            INT           NULL,
    [Title]           VARCHAR(50)  NULL,
    [FirstName]       VARCHAR(MAX)  NULL,
    [LastName]        VARCHAR(MAX)  NULL,
    [TelephoneNumber] VARCHAR(MAX)  NULL,
    [Email]           VARCHAR(MAX)  NULL,
	[DateOfBirth]	  DATETIME		NULL,
	[SquadNumber]	  INT			NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([ID])
);


