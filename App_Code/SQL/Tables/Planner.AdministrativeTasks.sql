USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Planner].[AdministrativeTasks] (
    [ID]				INT           IDENTITY (1, 1) NOT NULL,
    [TournamentID]		INT           NULL,
    [TaskType]			INT           NULL,
    [TypeID]			INT           NULL,
    [TaskStatus]		INT           NULL,
    CONSTRAINT [PK_AdministrativeTasks] PRIMARY KEY ([ID])
);


