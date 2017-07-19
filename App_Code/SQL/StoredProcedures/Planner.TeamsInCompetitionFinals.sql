

CREATE PROCEDURE [Planner].[TeamsInCompetitionFinals] (
	@CompetitionID		int
)
AS

BEGIN
	
	SELECT ID, ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered 
	FROM Planner.Teams 
	WHERE CompetitionID = @CompetitionID
	AND ID IN (
		SELECT DISTINCT HomeTeamID FROM Planner.Fixtures WHERE CompetitionID = @CompetitionID AND GroupID IS NULL AND HomeTeamID IS NOT NULL
		UNION
		SELECT DISTINCT AwayTeamID FROM Planner.Fixtures WHERE CompetitionID = @CompetitionID AND GroupID IS NULL AND AwayTeamID IS NOT NULL
	)

END