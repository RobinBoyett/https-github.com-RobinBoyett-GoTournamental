USE [GoTournamental]
GO

/****** Object: Table [dbo].[Teams] Script Date: 28/03/2015 07:27:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[Teams] (
    [ID]               INT          IDENTITY (1, 1) NOT NULL,
    [ClubID]           INT          NULL,
    [CompetitionID]    INT          NULL,
    [GroupID]          INT          NULL,
    [Name]             VARCHAR (50) NULL,
    [AttendanceType]   INT          NULL,
    [Registered]	   BIT			NULL, 
    [PrimaryContactID] INT          NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED ([ID] ASC)
);

