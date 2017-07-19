

CREATE PROCEDURE [Administration].[TournamentDeleteWithCascade] (
	@TournamentID			int
)
AS

BEGIN
	
	DELETE FROM Planner.Fixtures WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID) AND GroupID IS NULL
	DELETE FROM Planner.Fixtures WHERE GroupID IN (SELECT ID FROM Planner.Groups WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID))
	DELETE FROM Planner.GroupsPlayingAreas WHERE GroupID IN (SELECT ID FROM Planner.Groups WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @tournamentID))
	DELETE FROM Planner.Groups WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID)
	DELETE FROM Planner.PlayingAreas WHERE TournamentID = @TournamentID
	DELETE FROM Planner.Teams WHERE ClubID = (SELECT ID FROM Planner.Clubs WHERE TournamentID = @TournamentID)
	DELETE FROM Planner.Clubs WHERE TournamentID = @TournamentID
	DELETE FROM Planner.Contacts WHERE TournamentID = @TournamentID
	DELETE FROM Planner.Documents WHERE TournamentID = @TournamentID
	DELETE FROM Planner.Adverts WHERE AdvertiserID IN (SELECT ID FROM Planner.Advertisers WHERE TournamentID = @TournamentID)
	DELETE FROM Planner.Advertisers WHERE TournamentID = @TournamentID
	DELETE FROM Administration.FileImportAudits WHERE TournamentID = @TournamentID
	DELETE FROM Planner.Competitions WHERE TournamentID = @TournamentID
	DELETE FROM Planner.Tournaments WHERE ID = @TournamentID


END
