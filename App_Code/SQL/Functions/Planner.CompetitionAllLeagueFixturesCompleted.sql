

CREATE FUNCTION [Planner].[CompetitionAllLeagueFixturesCompleted] (
	@CompetitionID int
)
RETURNS bit
AS

BEGIN

	DECLARE @NoFixtures		int
	DECLARE @Completed		bit

	SELECT @Completed = CAST('false' AS bit)
	
	SELECT @NoFixtures = COUNT(*) FROM Planner.Fixtures WHERE CompetitionID = @CompetitionID AND IsLeagueFixture = 'true' AND HomeTeamScore IS NULL

	IF @NoFixtures = 0
		SELECT @Completed= CAST('true' AS bit)

	RETURN @Completed

END