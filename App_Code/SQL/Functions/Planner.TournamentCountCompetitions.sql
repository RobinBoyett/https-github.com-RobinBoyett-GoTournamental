USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountCompetitionsForTournament] Script Date: 28/03/2015 07:38:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [Planner].[TournamentCountCompetitions] (
	@TournamentID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoCompetitions		int

	SELECT @NoCompetitions = COUNT(*) FROM Planner.Competitions WHERE TournamentID = @TournamentID

	RETURN @NoCompetitions

END