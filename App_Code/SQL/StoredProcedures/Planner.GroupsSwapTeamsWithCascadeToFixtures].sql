USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[SwapTeamsBetweenGroupsWithCascadeToFixtures] Script Date: 15/06/2015 11:50:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[GroupsSwapTeamsWithCascadeToFixtures] (
	@teamOneID		int		,
	@teamTwoID		int
)
AS

DECLARE @teamOneGroupID		int
DECLARE @teamTwoGroupID		int

BEGIN
	
	UPDATE Planner.Fixtures SET HomeTeamID = @teamOneID WHERE HomeTeamID = @teamTwoID
	UPDATE Planner.Fixtures SET AwayTeamID = @teamOneID WHERE AwayTeamID = @teamTwoID
	UPDATE Planner.Fixtures SET HomeTeamID = @teamTwoID WHERE HomeTeamID = @teamOneID
	UPDATE Planner.Fixtures SET AwayTeamID = @teamTwoID WHERE AwayTeamID = @teamOneID

	SELECT @teamOneGroupID = GroupID FROM Planner.Teams WHERE ID = @teamOneID
	SELECT @teamTwoGroupID = GroupID FROM Planner.Teams WHERE ID = @teamTwoID

	UPDATE Planner.Teams SET GroupID = @teamTwoGroupID WHERE ID = @teamOneID
	UPDATE Planner.Teams SET GroupID = @teamOneGroupID WHERE ID = @teamTwoID

END