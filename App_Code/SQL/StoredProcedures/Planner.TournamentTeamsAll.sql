USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[TeamsForCompetition] Script Date: 28/03/2015 07:32:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Planner].[TournamentTeamsAll] (
	@TournamentID		int
)
AS

BEGIN
	
	SELECT ID, ClubID, CompetitionID, GroupID, Name, AttendanceType, PrimaryContactID, Registered 
	FROM Planner.Teams 
	WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID) 

END