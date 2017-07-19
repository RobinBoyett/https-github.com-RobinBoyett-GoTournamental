USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[FixturesForTournament] Script Date: 28/03/2015 07:30:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[TournamentFixturesAll] (
	@TournamentID		int
)
AS

BEGIN
	
	SELECT * FROM Planner.Fixtures WHERE GroupID IN (
		SELECT ID FROM Planner.Groups WHERE CompetitionID IN (
			SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID
		)
	)
	OR CompetitionID IN (
		SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID
	) 

END