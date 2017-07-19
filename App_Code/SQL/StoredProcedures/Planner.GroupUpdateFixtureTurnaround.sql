USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[AdjustFixtureTimesInGroupOfFour] Script Date: 14/07/2015 11:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Planner].[GroupUpdateFixtureTurnaround] (
	@GroupID				int		,
	@FixtureTurnaround		int
)
AS

DECLARE @StartTime		datetime
DECLARE @FixtureID		int

BEGIN

	SELECT @StartTime = MIN(StartTime) FROM Planner.Fixtures WHERE GroupID = @GroupID

	DECLARE FixtureCursor CURSOR FOR
		SELECT ID
		FROM Planner.Fixtures
		WHERE GroupID = @GroupID AND StartTime > @StartTime
		ORDER BY StartTime

	OPEN FixtureCursor
	FETCH NEXT FROM FixtureCursor INTO
		@FixtureID

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SELECT @StartTime = DATEADD(minute,@FixtureTurnaround,@StartTime)
	
		UPDATE Planner.Fixtures SET StartTime = @StartTime WHERE ID = @FixtureID

	FETCH NEXT FROM FixtureCursor INTO
		@FixtureID

	END
	CLOSE FixtureCursor
	DEALLOCATE FixtureCursor 


END