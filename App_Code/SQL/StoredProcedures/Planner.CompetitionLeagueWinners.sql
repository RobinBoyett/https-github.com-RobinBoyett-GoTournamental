

CREATE PROCEDURE [Planner].[CompetitionLeagueWinners] (
	@CompetitionID			INT
)
AS

DECLARE @GroupID				INT;

BEGIN

		CREATE TABLE #GroupWinners (
			TeamID			INT		,
			Played			INT		,
			Wins			INT		, 
			Draws			INT		, 
			Defeats			INT		, 
			GoalsFor		INT		, 
			GoalsAgainst	INT		, 
			GoalDifference	INT		,
			Points			INT		, 
			HiddenPoints	INT
		);


		DECLARE GroupsCursor CURSOR FOR
			SELECT ID
			FROM Planner.Groups
			WHERE CompetitionID = @CompetitionID;

		OPEN GroupsCursor
		FETCH NEXT FROM GroupsCursor INTO
			@GroupID

		WHILE @@FETCH_STATUS = 0
		BEGIN

			INSERT INTO #GroupWinners EXEC [Planner].[GroupLeagueWinners] @GroupID;

		FETCH NEXT FROM GroupsCursor INTO
			@GroupID

		END
		CLOSE GroupsCursor
		DEALLOCATE GroupsCursor

	
		SELECT TeamID AS ID, CAST(ROW_NUMBER() OVER(ORDER BY Points DESC, GoalDifference DESC, GoalsFor DESC, GoalsAgainst) AS INT) AS Position, 
			TeamID, Played, Wins, Draws, Defeats, GoalsFor, GoalsAgainst, GoalDifference, Points, HiddenPoints 
		FROM #GroupWinners
		ORDER BY Points DESC, GoalDifference DESC, GoalsFor DESC, HiddenPoints DESC;


END