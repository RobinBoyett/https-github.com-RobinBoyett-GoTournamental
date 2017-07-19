USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[TournamentDeleteFileImportWithCascade] Script Date: 28/03/2015 07:32:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[ClubDeleteWithCascade] (
	@clubID		int
)
AS

BEGIN


	DELETE FROM Planner.Fixtures 
	WHERE (HomeTeamID IN (SELECT ID FROM Planner.Teams WHERE ClubID = @clubID)) OR (AwayTeamID IN (SELECT ID FROM Planner.Teams WHERE ClubID = @clubID))

	UPDATE Planner.Teams SET GroupID = NULL, AttendanceType = 9
	WHERE ID IN (SELECT ID FROM Planner.Teams WHERE ClubID = @clubID)

	UPDATE Planner.Clubs SET AttendanceType = 9
	WHERE ID = @clubID

END
