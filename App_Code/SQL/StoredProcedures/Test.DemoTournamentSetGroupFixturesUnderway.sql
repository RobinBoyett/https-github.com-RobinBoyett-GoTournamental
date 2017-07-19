

CREATE PROCEDURE [Test].[DemoTournamentSetGroupFixturesUnderway] 
AS

DECLARE @TournamentID			int

BEGIN

 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	
	UPDATE Planner.Groups SET 
		FixturesUnderWay = 'true' 
	WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID)


END