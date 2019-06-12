
CREATE PROCEDURE [Planner].[GroupLeagueTable] (
	@GroupID		int
)
AS

DECLARE @rowcount					int
DECLARE @HomeTeamID					int
DECLARE @AwayTeamID					int
DECLARE @HomeTeamScore				int
DECLARE @AwayTeamScore				int
DECLARE @TeamID						int
DECLARE @Score						int
DECLARE @Position					int
DECLARE @Points						int
DECLARE @TeamIDPositionN			int
DECLARE @TeamIDPositionNPlus1		int

BEGIN


	SELECT ID AS TeamID, Name, 0 AS Played, 0 AS Wins, 0 AS Draws, 0 AS Defeats, 0 AS GoalsFor, 0 AS GoalsAgainst, 0 AS GoalDifference, 0 AS Points, 0 AS HiddenPoints
	INTO #TemporaryLeagueTable
	FROM Planner.Teams
	WHERE GroupID = @GroupID 

	SELECT @rowcount = 0
	SELECT @rowcount = COUNT(*) FROM Planner.Fixtures WHERE GroupID = @GroupID

	IF @rowcount > 0
	BEGIN

		DECLARE FixtureCursor CURSOR FOR
			SELECT HomeTeamID, HomeTeamScore, AwayTeamID, AwayTeamScore
			FROM Planner.Fixtures
			WHERE GroupID = @GroupID AND IsLeagueFixture = 'True'

		OPEN FixtureCursor
		FETCH NEXT FROM FixtureCursor INTO
			@HomeTeamID		,
			@HomeTeamScore	,
			@AwayTeamID		,
			@AwayTeamScore

		WHILE @@FETCH_STATUS = 0
		BEGIN

			IF @HomeTeamScore > @AwayTeamScore			-- Home Wins
				BEGIN
					UPDATE #TemporaryLeagueTable SET Points = Points + 3, Wins = Wins + 1 WHERE TeamID = @HomeTeamID
					UPDATE #TemporaryLeagueTable SET Defeats = Defeats + 1 WHERE TeamID = @AwayTeamID
				END
			IF @AwayTeamScore > @HomeTeamScore			-- Away Wins
				BEGIN
					UPDATE #TemporaryLeagueTable SET Points = Points + 3, Wins = Wins + 1 WHERE TeamID = @AwayTeamID
					UPDATE #TemporaryLeagueTable SET Defeats = Defeats + 1 WHERE TeamID = @HomeTeamID
				END
			IF @HomeTeamScore = @AwayTeamScore			-- Draws
			BEGIN
				UPDATE #TemporaryLeagueTable SET Points = Points + 1, Draws = Draws + 1 WHERE TeamID = @HomeTeamID
				UPDATE #TemporaryLeagueTable SET Points = Points + 1, Draws = Draws + 1 WHERE TeamID = @AwayTeamID
			END

		FETCH NEXT FROM FixtureCursor INTO
			@HomeTeamID		,
			@HomeTeamScore	,
			@AwayTeamID		,
			@AwayTeamScore

		END
		CLOSE FixtureCursor
		DEALLOCATE FixtureCursor 



		DECLARE TeamCursor CURSOR FOR
			SELECT TeamID
			FROM #TemporaryLeagueTable

		OPEN TeamCursor
		FETCH NEXT FROM TeamCursor INTO
			@TeamID

		WHILE @@FETCH_STATUS = 0
		BEGIN

			SELECT @rowcount = COUNT(*) FROM Planner.Fixtures WHERE (HomeTeamID = @TeamID OR AwayTeamID = @TeamID) AND IsLeagueFixture = 'True' AND HomeTeamScore IS NOT NULL AND AwayTeamScore IS NOT NULL
			UPDATE #TemporaryLeagueTable SET Played = @rowcount WHERE TeamID = @TeamID											-- Games Played

			SELECT @Score = SUM(HomeTeamScore) FROM Planner.Fixtures WHERE HomeTeamID = @TeamID AND IsLeagueFixture = 'True'
			IF @Score IS NOT NULL
				UPDATE #TemporaryLeagueTable SET GoalsFor = GoalsFor + @Score WHERE TeamID = @TeamID							-- Sum Goals For From Home Games
			SELECT @Score = SUM(AwayTeamScore) FROM Planner.Fixtures WHERE AwayTeamID = @TeamID AND IsLeagueFixture = 'True'
			IF @Score IS NOT NULL
				UPDATE #TemporaryLeagueTable SET GoalsFor = GoalsFor + @Score WHERE TeamID = @TeamID							-- Sum Goals For From Away Games

			SELECT @Score = SUM(AwayTeamScore) FROM Planner.Fixtures WHERE HomeTeamID = @TeamID AND IsLeagueFixture = 'True'
			IF @Score IS NOT NULL
				UPDATE #TemporaryLeagueTable SET GoalsAgainst = GoalsAgainst + @Score WHERE TeamID = @TeamID					-- Sum Goals Against From Home Games
			SELECT @Score = SUM(HomeTeamScore) FROM Planner.Fixtures WHERE AwayTeamID = @TeamID AND IsLeagueFixture = 'True'
			IF @Score IS NOT NULL
				UPDATE #TemporaryLeagueTable SET GoalsAgainst = GoalsAgainst + @Score WHERE TeamID = @TeamID					-- Sum Goals Against From Away Games

		FETCH NEXT FROM TeamCursor INTO
			@TeamID

		END
		CLOSE TeamCursor
		DEALLOCATE TeamCursor



	END

	SELECT TeamID AS ID, CAST(ROW_NUMBER() OVER(ORDER BY Points DESC, GoalDifference DESC, GoalsFor DESC, GoalsAgainst) AS int) AS Position, TeamID, Played, Wins, Draws, Defeats, GoalsFor, GoalsAgainst, GoalsFor - GoalsAgainst AS GoalDifference, Points, HiddenPoints
	INTO #AdjustedLeagueTable
	FROM #TemporaryLeagueTable L
	INNER JOIN Planner.Teams T ON T.ID = L.TeamID
	ORDER BY Points DESC, GoalDifference DESC, GoalsFor DESC

	SELECT @rowcount = 0
	SELECT @rowcount = COUNT(Position) FROM #AdjustedLeagueTable


	DECLARE LeagueTableCursor CURSOR FOR
		SELECT TeamID, Position, Points
		FROM #AdjustedLeagueTable

	OPEN LeagueTableCursor
	FETCH NEXT FROM LeagueTableCursor INTO
		@TeamID		,
		@Position	,
		@Points

	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF @Position < @rowcount
		BEGIN

			SELECT @HomeTeamScore = 0, @AwayTeamScore = 0

			IF (SELECT Points FROM #AdjustedLeagueTable WHERE Position = @Position) = (SELECT Points FROM #AdjustedLeagueTable WHERE Position = @Position + 1)
				AND (SELECT GoalDifference FROM #AdjustedLeagueTable WHERE Position = @Position) = (SELECT GoalDifference FROM #AdjustedLeagueTable WHERE Position = @Position + 1)
				AND (SELECT GoalsFor FROM #AdjustedLeagueTable WHERE Position = @Position) = (SELECT GoalsFor FROM #AdjustedLeagueTable WHERE Position = @Position + 1)
			BEGIN

				SELECT @TeamIDPositionN = TeamID FROM #AdjustedLeagueTable WHERE Position = @Position
				SELECT @TeamIDPositionNPlus1 = TeamID FROM #AdjustedLeagueTable WHERE Position = @Position + 1

				SELECT @HomeTeamScore = HomeTeamScore, @AwayTeamScore = AwayTeamScore
				FROM Planner.Fixtures
				WHERE HomeTeamID = @TeamIDPositionN AND AwayTeamID = @TeamIDPositionNPlus1
			
				IF @HomeTeamScore > @AwayTeamScore
					UPDATE #AdjustedLeagueTable SET HiddenPoints = HiddenPoints + 1 WHERE TeamID = @TeamIDPositionN
				IF @AwayTeamScore > @HomeTeamScore
					UPDATE #AdjustedLeagueTable SET HiddenPoints = HiddenPoints + 1 WHERE TeamID = @TeamIDPositionNPlus1
			
				SELECT @HomeTeamScore = HomeTeamScore, @AwayTeamScore = AwayTeamScore
				FROM Planner.Fixtures
				WHERE HomeTeamID = @TeamIDPositionNPlus1 AND AwayTeamID = @TeamIDPositionN
			
				IF @HomeTeamScore > @AwayTeamScore
					UPDATE #AdjustedLeagueTable SET HiddenPoints = HiddenPoints + 1 WHERE TeamID = @TeamIDPositionNPlus1
				IF @AwayTeamScore > @HomeTeamScore
					UPDATE #AdjustedLeagueTable SET HiddenPoints = HiddenPoints + 1 WHERE TeamID = @TeamIDPositionN
						
			END

		END


	FETCH NEXT FROM LeagueTableCursor INTO
		@TeamID			,
		@Position		,
		@Points

	END
	CLOSE LeagueTableCursor
	DEALLOCATE LeagueTableCursor



	SELECT ID, Position, TeamID, Played, Wins, Draws, Defeats, GoalsFor, GoalsAgainst, GoalDifference, Points, HiddenPoints 
	FROM #AdjustedLeagueTable
	ORDER BY Points DESC, GoalDifference DESC, GoalsFor DESC, HiddenPoints DESC


END