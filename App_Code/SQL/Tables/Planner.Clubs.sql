USE [GoTournamental]
GO

/****** Object: Table [dbo].[Clubs] Script Date: 28/03/2015 07:17:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Clubs] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [TournamentID]      INT           NULL,
    [Name]              VARCHAR (100) NULL,
    [AttendanceType]    INT           NULL,
    [WebsiteURL]        VARCHAR (500) NULL,
    [LogoFile]          VARCHAR (50)  NULL,
    [Twitter]           VARCHAR (50)  NULL,
    [ColourPrimary]     VARCHAR (50)  NULL,
    [ColourSecondary]   VARCHAR (50)  NULL,
    [Affiliation]       INT           NULL,
    [AffiliationNumber] VARCHAR (50)  NULL,
    [PrimaryContactID]  INT           NULL,
    CONSTRAINT [PK_Clubs] PRIMARY KEY CLUSTERED ([ID] ASC)
);


