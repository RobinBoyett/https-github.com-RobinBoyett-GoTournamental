USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[TournamentDeleteFileImportWithCascade] Script Date: 28/03/2015 07:32:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[TeamDeleteWithCascade] (
	@teamID		int
)
AS

BEGIN
	
	DELETE FROM Planner.Fixtures WHERE HomeTeamID = @teamID OR AwayTeamID = @teamID
	UPDATE Planner.Teams SET GroupID = NULL, AttendanceType = 8 WHERE ID = @teamID

END
