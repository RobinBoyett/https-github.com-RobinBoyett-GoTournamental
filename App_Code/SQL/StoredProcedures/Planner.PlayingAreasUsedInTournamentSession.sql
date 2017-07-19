

CREATE PROCEDURE [Planner].[PlayingAreasUsedInTournamentSession] (
	@TournamentID		int			,
	@CompetitionID		int
)
AS

DECLARE @StartDate		date
DECLARE @Session			int


BEGIN
	
	SELECT @StartDate = CAST(StartTime AS date), @Session = [Session] FROM Planner.Competitions WHERE ID = @CompetitionID

	SELECT PA.ID, PA.TournamentID, PA.Name
	FROM Planner.GroupsPlayingAreas GPA
	INNER JOIN Planner.PlayingAreas PA ON PA.ID = GPA.PlayingAreaID
	INNER JOIN Planner.Groups G ON G.ID = GPA.GroupID
	INNER JOIN Planner.Competitions C ON C.ID = G.CompetitionID
	WHERE PlayingAreaID IN (SELECT ID FROM Planner.PlayingAreas WHERE TournamentID = @TournamentID)
	AND C.[Session] = @Session AND CAST(C.StartTime AS date) = @StartDate

END