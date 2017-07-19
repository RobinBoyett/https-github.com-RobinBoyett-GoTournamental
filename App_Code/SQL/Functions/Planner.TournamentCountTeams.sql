USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountTeamsForTournament] Script Date: 28/03/2015 07:43:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [Planner].[TournamentCountTeams] (
	@TournamentID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoTeams		int

	SELECT @NoTeams = COUNT(*) FROM Planner.Teams WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID)

	RETURN @NoTeams

END
