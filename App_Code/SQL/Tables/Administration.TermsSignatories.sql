USE [GoTournamental]
GO

/****** Object: Table [dbo].[Sponsors] Script Date: 28/03/2015 07:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Administration].[TermsSignatories] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [UserID]		 NVARCHAR (128) NOT NULL,
    [UserName]       NVARCHAR (256) NOT NULL
    CONSTRAINT [PK_TermsSignatories] PRIMARY KEY ([ID])
);


