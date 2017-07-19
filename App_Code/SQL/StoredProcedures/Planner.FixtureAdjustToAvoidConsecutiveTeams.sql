USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[AdjustToAvoidConsecutiveTeamFixtures] Script Date: 25/06/2015 10:41:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Planner].[FixtureAdjustToAvoidConsecutiveTeams] (
	@groupID		int		
)
AS

DECLARE @topHomeTeamID			int
DECLARE @topAwayTeamID			int
DECLARE @bottomHomeTeamID		int
DECLARE @bottomAwayTeamID		int

BEGIN
	--3-4, 5-7, 6-8

	SELECT @topHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 3'
	SELECT @topAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 3'
	SELECT @bottomHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 4'
	SELECT @bottomAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 4'

	UPDATE Fixtures SET HomeTeamID = @bottomHomeTeamID WHERE groupID = @groupID AND Name = 'Match 3'
	UPDATE Fixtures SET AwayTeamID = @bottomAwayTeamID WHERE groupID = @groupID AND Name = 'Match 3'
	UPDATE Fixtures SET HomeTeamID = @topHomeTeamID WHERE groupID = @groupID AND Name = 'Match 4'
	UPDATE Fixtures SET AwayTeamID = @topAwayTeamID WHERE groupID = @groupID AND Name = 'Match 4'

	SELECT @topHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 5'
	SELECT @topAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 5'
	SELECT @bottomHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 7'
	SELECT @bottomAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 7'

	UPDATE Fixtures SET HomeTeamID = @bottomHomeTeamID WHERE groupID = @groupID AND Name = 'Match 5'
	UPDATE Fixtures SET AwayTeamID = @bottomAwayTeamID WHERE groupID = @groupID AND Name = 'Match 5'
	UPDATE Fixtures SET HomeTeamID = @topHomeTeamID WHERE groupID = @groupID AND Name = 'Match 7'
	UPDATE Fixtures SET AwayTeamID = @topAwayTeamID WHERE groupID = @groupID AND Name = 'Match 7'

	SELECT @topHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 6'
	SELECT @topAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 6'
	SELECT @bottomHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 8'
	SELECT @bottomAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 8'

	UPDATE Fixtures SET HomeTeamID = @bottomHomeTeamID WHERE groupID = @groupID AND Name = 'Match 6'
	UPDATE Fixtures SET AwayTeamID = @bottomAwayTeamID WHERE groupID = @groupID AND Name = 'Match 6'
	UPDATE Fixtures SET HomeTeamID = @topHomeTeamID WHERE groupID = @groupID AND Name = 'Match 8'
	UPDATE Fixtures SET AwayTeamID = @topAwayTeamID WHERE groupID = @groupID AND Name = 'Match 8'

	SELECT @topHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 7'
	SELECT @topAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 7'
	SELECT @bottomHomeTeamID = HomeTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 8'
	SELECT @bottomAwayTeamID = AwayTeamID FROM [Planner].[Fixtures] WHERE groupID = @groupID AND Name = 'Match 8'

	UPDATE Fixtures SET HomeTeamID = @bottomHomeTeamID WHERE groupID = @groupID AND Name = 'Match 7'
	UPDATE Fixtures SET AwayTeamID = @bottomAwayTeamID WHERE groupID = @groupID AND Name = 'Match 7'
	UPDATE Fixtures SET HomeTeamID = @topHomeTeamID WHERE groupID = @groupID AND Name = 'Match 8'
	UPDATE Fixtures SET AwayTeamID = @topAwayTeamID WHERE groupID = @groupID AND Name = 'Match 8'



END