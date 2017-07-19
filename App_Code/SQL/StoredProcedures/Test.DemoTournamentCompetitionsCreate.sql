

CREATE PROCEDURE [Test].[DemoTournamentCompetitionsCreate] 
AS

DECLARE @TournamentID			int

BEGIN

	--// CREATE AGEBANDS / COMPETITIONS
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) -- 2x5
	VALUES (@TournamentID, 1, 1, CONVERT(datetime,'24/06/2017 09:00:00',103), 2, 15, 5, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --3x5
	VALUES (@TournamentID, 2, 1, CONVERT(datetime,'25/06/2017 09:00:00',103), 2, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --3x6
	VALUES (@TournamentID, 3, 4, CONVERT(datetime,'24/06/2017 14:30:00',103), 3, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --2x6
	VALUES (@TournamentID, 4, 4, CONVERT(datetime,'25/06/2017 14:30:00',103), 3, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --3x5
	VALUES (@TournamentID, 5, 4, CONVERT(datetime,'25/06/2017 09:00:00',103), 2, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --2x6
	VALUES (@TournamentID, 6, 4, CONVERT(datetime,'24/06/2017 09:00:00',103), 2, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --3x6
	VALUES (@TournamentID, 7, 4, CONVERT(datetime,'25/06/2017 14:30:00',103), 3, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --2x7
	VALUES (@TournamentID, 8, 4, CONVERT(datetime,'25/06/2017 14:30:00',103), 3, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --3x6
	VALUES (@TournamentID, 9, 4, CONVERT(datetime,'24/06/2017 14:30:00',103), 3, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --2x5
	VALUES (@TournamentID, 10, 4, CONVERT(datetime,'24/06/2017 09:00:00',103), 2, 15, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, TeamSize, SquadSize) --1x5
	VALUES (@TournamentID, 19, 4, CONVERT(datetime,'25/06/2017 09:00:00',103), 2, 15, 6, 8)



END