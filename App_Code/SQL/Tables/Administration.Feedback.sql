USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Administration].[Feedback] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]             VARCHAR(MAX)   NOT NULL,
    [LastName]              VARCHAR(MAX)   NOT NULL,
    [Email]                 VARCHAR(MAX)   NOT NULL,
    [Organisation]          VARCHAR (100)  NULL,
    [TelephoneNumber]       VARCHAR(MAX)   NULL,
    [TournamentType]        INT            NULL,
    [AdditionalInformation] VARCHAR (2000) NULL,
    [FeedbackDate]           DATETIME       NULL,
    CONSTRAINT [PK_ContactUs] PRIMARY KEY ([ID])
);


