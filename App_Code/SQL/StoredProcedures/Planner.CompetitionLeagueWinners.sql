

CREATE PROCEDURE [Planner].[CompetitionLeagueWinners] 
AS

DECLARE @GroupID				int

BEGIN

		CREATE TABLE #GroupWinners (
			TeamID			int		,
			Played			int		,
			Wins			int		, 
			Draws			int		, 
			Defeats			int		, 
			GoalsFor		int		, 
			GoalsAgainst	int		, 
			GoalDifference	int		,
			Points			int		, 
			HiddenPoints	int
		)


		DECLARE GroupsCursor CURSOR FOR
			SELECT ID
			FROM Planner.Groups
			WHERE CompetitionID = 10

		OPEN GroupsCursor
		FETCH NEXT FROM GroupsCursor INTO
			@GroupID

		WHILE @@FETCH_STATUS = 0
		BEGIN

			INSERT INTO #GroupWinners EXEC [Planner].[GroupLeagueWinners] @GroupID

		FETCH NEXT FROM GroupsCursor INTO
			@GroupID

		END
		CLOSE GroupsCursor
		DEALLOCATE GroupsCursor

		SELECT TeamID, CAST(ROW_NUMBER() OVER(ORDER BY Points DESC, GoalDifference DESC, GoalsFor DESC, GoalsAgainst) AS int) AS Position
		FROM #GroupWinners
		ORDER BY Points DESC, GoalDifference DESC, GoalsFor DESC, HiddenPoints DESC


END