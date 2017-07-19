USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[FixturesForTournament] Script Date: 28/03/2015 07:30:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[ContactTournamentHostClub] (
	@TournamentID		int
)
AS

BEGIN
	
	SELECT FirstName, LastName, TelephoneNumber, Email 
	FROM Planner.Contacts 
	WHERE ID = (
		SELECT PrimaryContactID FROM Planner.Clubs WHERE TournamentID = @TournamentID AND AttendanceType = 1
	)

END