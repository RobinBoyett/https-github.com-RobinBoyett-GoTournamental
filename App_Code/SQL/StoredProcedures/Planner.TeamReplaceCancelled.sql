USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[SwapTeamsBetweenGroupsWithCascadeToFixtures] Script Date: 15/06/2015 11:50:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[TeamReplaceCancelled] (
	@cancelledTeamID						int	,
	@replacementTeamID						int	
)
AS

DECLARE @cancelledTeamGroupID				int
DECLARE @replacementTeamGroupID				int

BEGIN
	
	UPDATE Planner.Fixtures SET HomeTeamID = @replacementTeamID WHERE HomeTeamID = @cancelledTeamID
	UPDATE Planner.Fixtures SET AwayTeamID = @replacementTeamID WHERE AwayTeamID = @cancelledTeamID


	SELECT @cancelledTeamGroupID = GroupID FROM Planner.Teams WHERE ID = @cancelledTeamID

	UPDATE Planner.Teams SET GroupID = @cancelledTeamGroupID, AttendanceType = 5 WHERE ID = @replacementTeamID
	UPDATE Planner.Teams SET GroupID = NULL, AttendanceType = 7 WHERE ID = @cancelledTeamID


END