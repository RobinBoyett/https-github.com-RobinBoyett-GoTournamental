USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountFixturesForTournament] Script Date: 28/03/2015 07:39:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [Planner].[TournamentCountFixtures] (
	@TournamentID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoFixtures		int

	SELECT @NoFixtures = COUNT(*) FROM Fixtures WHERE GroupID IN (
		SELECT ID FROM Planner.Groups WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID)
	)

	RETURN @NoFixtures

END
