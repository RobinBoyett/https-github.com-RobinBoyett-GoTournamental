USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[TournamentDeleteFileImportWithCascade] Script Date: 28/03/2015 07:32:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[TournamentDeleteFileImportWithCascade] (
	@TournamentID		int
)
AS

BEGIN
	
	DELETE FROM Planner.Fixtures WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID) AND GroupID IS NULL
	DELETE FROM Planner.Fixtures WHERE GroupID IN (SELECT ID FROM Planner.Groups WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID))


	DELETE FROM Planner.GroupsPlayingAreas WHERE GroupID IN (SELECT ID FROM Planner.Groups WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID))
	DELETE FROM Planner.Groups WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID)

	DELETE FROM Planner.Adverts WHERE AdvertiserID IN (SELECT ID FROM Planner.Advertisers WHERE TournamentID = @TournamentID)
	DELETE FROM Planner.Advertisers WHERE TournamentID = @TournamentID
	DELETE FROM Planner.Contacts WHERE TournamentID = @TournamentID AND Type = 4							--// Delete Referees
	DELETE FROM Planner.Teams WHERE ClubID IN (SELECT ID FROM Planner.Clubs WHERE TournamentID = @TournamentID)		--// Delete Teams
	DELETE FROM Planner.Clubs WHERE TournamentID = @TournamentID AND AttendanceType != 1	--// Delete all but host club
	DELETE FROM Planner.Contacts WHERE TournamentID = @TournamentID AND Type IN (2	, 3)	--// Delete Club and TeamContacts
	DELETE FROM Planner.Competitions WHERE TournamentID = @TournamentID

	DELETE FROM Administration.FileImportAudits WHERE TournamentID = @TournamentID

END