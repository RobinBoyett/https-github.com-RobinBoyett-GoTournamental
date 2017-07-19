USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Advertisers] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [TournamentID]   INT           NULL,
    [AdvertiserName] VARCHAR (100) NULL,
    [WebsiteURL]     VARCHAR (100) NULL,
    [TooltipText]    VARCHAR (250) NULL, 
    CONSTRAINT [PK_Advertisers] PRIMARY KEY ([ID])
);


