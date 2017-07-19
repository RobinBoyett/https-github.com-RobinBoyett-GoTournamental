USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[SwapTeamsBetweenGroupsWithCascadeToFixtures] Script Date: 15/06/2015 11:50:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Planner].[GroupsInCompetitionDeleteWithCascadeToFixtures] (
	@CompetitionID		int
)
AS


BEGIN
	BEGIN TRANSACTION
	
	DELETE FROM Planner.Fixtures WHERE CompetitionID = @CompetitionID
	
	UPDATE Planner.Teams SET GroupID = NULL WHERE CompetitionID = @CompetitionID

	DELETE FROM Planner.GroupsPlayingAreas WHERE GroupID IN (SELECT ID FROM Planner.Groups WHERE CompetitionID = @CompetitionID)

	DELETE FROM Planner.Groups WHERE CompetitionID = @CompetitionID

	COMMIT TRANSACTION

END

