

CREATE PROCEDURE [Test].[DemoTournamentCompetitionsCreate] 
AS

DECLARE @TournamentID			int

BEGIN

	--// CREATE AGEBANDS / COMPETITIONS
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) -- 2x5
	VALUES (@TournamentID, 1, 1, CONVERT(datetime,'24/06/2017 09:00:00',103), 2, 15, 0, 0, 5, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --3x5
	VALUES (@TournamentID, 2, 1, CONVERT(datetime,'25/06/2017 09:00:00',103), 2, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --3x6
	VALUES (@TournamentID, 3, 5, CONVERT(datetime,'24/06/2017 14:30:00',103), 3, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --2x6
	VALUES (@TournamentID, 4, 5, CONVERT(datetime,'25/06/2017 14:30:00',103), 3, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --3x5
	VALUES (@TournamentID, 5, 6, CONVERT(datetime,'25/06/2017 09:00:00',103), 2, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --2x6
	VALUES (@TournamentID, 6, 5, CONVERT(datetime,'24/06/2017 09:00:00',103), 2, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --3x6
	VALUES (@TournamentID, 7, 5, CONVERT(datetime,'25/06/2017 14:30:00',103), 3, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --2x7
	VALUES (@TournamentID, 8, 5, CONVERT(datetime,'25/06/2017 14:30:00',103), 3, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --3x6
	VALUES (@TournamentID, 9, 5, CONVERT(datetime,'24/06/2017 14:30:00',103), 3, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --2x5
	VALUES (@TournamentID, 10, 4, CONVERT(datetime,'24/06/2017 09:00:00',103), 2, 15, 0, 0, 6, 8)
	INSERT INTO Planner.Competitions (TournamentID, AgeBand, CompetitionFormat, StartTime, [Session], FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize) --1x5
	VALUES (@TournamentID, 19, 4, CONVERT(datetime,'25/06/2017 09:00:00',103), 2, 15, 0, 0, 6, 8)



END