

CREATE PROCEDURE [Test].[DemoTournamentRegisterTeamsOnSite] 
AS

DECLARE @TournamentID			int

BEGIN

 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	
	UPDATE Planner.Teams SET 
		Registered = 'true' 
	WHERE ClubID IN (SELECT ID FROM Planner.Clubs WHERE TournamentID = @TournamentID)
	AND AttendanceType IN (1,5)



END