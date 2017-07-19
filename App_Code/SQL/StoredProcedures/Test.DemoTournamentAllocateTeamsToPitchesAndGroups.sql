

CREATE PROCEDURE [Test].[DemoTournamentAllocateTeamsToPitchesAndGroups] 
AS

DECLARE @TournamentID			int
DECLARE @ClubID					int
DECLARE @TeamID					int
DECLARE @ContactID				int
DECLARE @UserID					varchar(2000)
DECLARE @GroupID				int

BEGIN




	--// SET-UP UNDER 7s AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (1, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 1)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (1, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 2)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 1 WHERE ID = 1
	UPDATE Planner.Teams SET GroupID = 2 WHERE ID = 2
	UPDATE Planner.Teams SET GroupID = 1 WHERE ID = 3
	UPDATE Planner.Teams SET GroupID = 2 WHERE ID = 4
	UPDATE Planner.Teams SET GroupID = 1 WHERE ID = 54
	UPDATE Planner.Teams SET GroupID = 2 WHERE ID = 55
	UPDATE Planner.Teams SET GroupID = 1 WHERE ID = 71
	UPDATE Planner.Teams SET GroupID = 2 WHERE ID = 72
	UPDATE Planner.Teams SET GroupID = 1 WHERE ID = 133
	UPDATE Planner.Teams SET GroupID = 2 WHERE ID = 142



	--// SET-UP UNDER 8s AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (2, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 1)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (2, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 2)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (2, 'Group 3', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 3)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 3 WHERE ID = 5
	UPDATE Planner.Teams SET GroupID = 4 WHERE ID = 6
	UPDATE Planner.Teams SET GroupID = 5 WHERE ID = 7
	UPDATE Planner.Teams SET GroupID = 3 WHERE ID = 25
	UPDATE Planner.Teams SET GroupID = 4 WHERE ID = 33
	UPDATE Planner.Teams SET GroupID = 5 WHERE ID = 34
	UPDATE Planner.Teams SET GroupID = 3 WHERE ID = 42
	UPDATE Planner.Teams SET GroupID = 4 WHERE ID = 43
	UPDATE Planner.Teams SET GroupID = 5 WHERE ID = 56
	UPDATE Planner.Teams SET GroupID = 3 WHERE ID = 73
	UPDATE Planner.Teams SET GroupID = 4 WHERE ID = 92
	UPDATE Planner.Teams SET GroupID = 5 WHERE ID = 102
	UPDATE Planner.Teams SET GroupID = 3 WHERE ID = 122
	UPDATE Planner.Teams SET GroupID = 4 WHERE ID = 134
	UPDATE Planner.Teams SET GroupID = 5 WHERE ID = 135

	--// SET-UP UNDER 9s AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (3, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 1)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (3, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 2)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (3, 'Group 3', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 3)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 6 WHERE ID = 8
	UPDATE Planner.Teams SET GroupID = 7 WHERE ID = 9
	UPDATE Planner.Teams SET GroupID = 8 WHERE ID = 10
	UPDATE Planner.Teams SET GroupID = 6 WHERE ID = 26
	UPDATE Planner.Teams SET GroupID = 7 WHERE ID = 35
	UPDATE Planner.Teams SET GroupID = 8 WHERE ID = 44
	UPDATE Planner.Teams SET GroupID = 6 WHERE ID = 57
	UPDATE Planner.Teams SET GroupID = 7 WHERE ID = 58
	UPDATE Planner.Teams SET GroupID = 8 WHERE ID = 67
	UPDATE Planner.Teams SET GroupID = 6 WHERE ID = 74
	UPDATE Planner.Teams SET GroupID = 7 WHERE ID = 75
	UPDATE Planner.Teams SET GroupID = 8 WHERE ID = 93
	UPDATE Planner.Teams SET GroupID = 6 WHERE ID = 103
	UPDATE Planner.Teams SET GroupID = 7 WHERE ID = 104
	UPDATE Planner.Teams SET GroupID = 8 WHERE ID = 116
	UPDATE Planner.Teams SET GroupID = 6 WHERE ID = 123
	UPDATE Planner.Teams SET GroupID = 7 WHERE ID = 136
	UPDATE Planner.Teams SET GroupID = 8 WHERE ID = 143


	--// SET-UP UNDER 10s AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (4, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 1)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (4, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 2)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 9 WHERE ID = 11
	UPDATE Planner.Teams SET GroupID = 10 WHERE ID = 27
	UPDATE Planner.Teams SET GroupID = 9 WHERE ID = 28
	UPDATE Planner.Teams SET GroupID = 10 WHERE ID = 36
	UPDATE Planner.Teams SET GroupID = 9 WHERE ID = 45
	UPDATE Planner.Teams SET GroupID = 10 WHERE ID = 46
	UPDATE Planner.Teams SET GroupID = 9 WHERE ID = 50
	UPDATE Planner.Teams SET GroupID = 10 WHERE ID = 59
	UPDATE Planner.Teams SET GroupID = 9 WHERE ID = 60
	UPDATE Planner.Teams SET GroupID = 10 WHERE ID = 94
	UPDATE Planner.Teams SET GroupID = 9 WHERE ID = 124
	UPDATE Planner.Teams SET GroupID = 10 WHERE ID = 144


	--// SET-UP UNDER 11s AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (5, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 4)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (5, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 5)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (5, 'Group 3', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 6)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 11 WHERE ID = 12
	UPDATE Planner.Teams SET GroupID = 12 WHERE ID = 13
	UPDATE Planner.Teams SET GroupID = 13 WHERE ID = 37
	UPDATE Planner.Teams SET GroupID = 11 WHERE ID = 51
	UPDATE Planner.Teams SET GroupID = 12 WHERE ID = 61
	UPDATE Planner.Teams SET GroupID = 13 WHERE ID = 76
	UPDATE Planner.Teams SET GroupID = 11 WHERE ID = 77
	UPDATE Planner.Teams SET GroupID = 12 WHERE ID = 83
	UPDATE Planner.Teams SET GroupID = 13 WHERE ID = 89
	UPDATE Planner.Teams SET GroupID = 11 WHERE ID = 95
	UPDATE Planner.Teams SET GroupID = 12 WHERE ID = 105
	UPDATE Planner.Teams SET GroupID = 13 WHERE ID = 117
	UPDATE Planner.Teams SET GroupID = 11 WHERE ID = 128
	UPDATE Planner.Teams SET GroupID = 12 WHERE ID = 132
	UPDATE Planner.Teams SET GroupID = 13 WHERE ID = 145


	--// SET-UP UNDER 12s AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (6, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 3)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (6, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 4)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 14 WHERE ID = 14
	UPDATE Planner.Teams SET GroupID = 15 WHERE ID = 15
	UPDATE Planner.Teams SET GroupID = 14 WHERE ID = 29
	UPDATE Planner.Teams SET GroupID = 15 WHERE ID = 38
	UPDATE Planner.Teams SET GroupID = 14 WHERE ID = 47
	UPDATE Planner.Teams SET GroupID = 15 WHERE ID = 52
	UPDATE Planner.Teams SET GroupID = 14 WHERE ID = 78
	UPDATE Planner.Teams SET GroupID = 15 WHERE ID = 110
	UPDATE Planner.Teams SET GroupID = 14 WHERE ID = 112
	UPDATE Planner.Teams SET GroupID = 15 WHERE ID = 125
	UPDATE Planner.Teams SET GroupID = 14 WHERE ID = 130
	UPDATE Planner.Teams SET GroupID = 15 WHERE ID = 139


	--// SET-UP UNDER 13s AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (7, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 3)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (7, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 4)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (7, 'Group 3', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 5)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 16 WHERE ID = 16
	UPDATE Planner.Teams SET GroupID = 17 WHERE ID = 17
	UPDATE Planner.Teams SET GroupID = 18 WHERE ID = 30
	UPDATE Planner.Teams SET GroupID = 16 WHERE ID = 53
	UPDATE Planner.Teams SET GroupID = 17 WHERE ID = 62
	UPDATE Planner.Teams SET GroupID = 18 WHERE ID = 63
	UPDATE Planner.Teams SET GroupID = 16 WHERE ID = 79
	UPDATE Planner.Teams SET GroupID = 17 WHERE ID = 86
	UPDATE Planner.Teams SET GroupID = 18 WHERE ID = 87
	UPDATE Planner.Teams SET GroupID = 16 WHERE ID = 90
	UPDATE Planner.Teams SET GroupID = 17 WHERE ID = 96
	UPDATE Planner.Teams SET GroupID = 18 WHERE ID = 106
	UPDATE Planner.Teams SET GroupID = 16 WHERE ID = 113
	UPDATE Planner.Teams SET GroupID = 17 WHERE ID = 118
	UPDATE Planner.Teams SET GroupID = 18 WHERE ID = 120
	UPDATE Planner.Teams SET GroupID = 16 WHERE ID = 121
	UPDATE Planner.Teams SET GroupID = 17 WHERE ID = 137
	UPDATE Planner.Teams SET GroupID = 18 WHERE ID = 140

	--// SET-UP UNDER 14s BOYS AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (8, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 6)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (8, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 7)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 19 WHERE ID = 18
	UPDATE Planner.Teams SET GroupID = 20 WHERE ID = 19
	UPDATE Planner.Teams SET GroupID = 19 WHERE ID = 39
	UPDATE Planner.Teams SET GroupID = 20 WHERE ID = 80
	UPDATE Planner.Teams SET GroupID = 19 WHERE ID = 84
	UPDATE Planner.Teams SET GroupID = 20 WHERE ID = 97
	UPDATE Planner.Teams SET GroupID = 19 WHERE ID = 98
	UPDATE Planner.Teams SET GroupID = 20 WHERE ID = 107
	UPDATE Planner.Teams SET GroupID = 19 WHERE ID = 108
	UPDATE Planner.Teams SET GroupID = 20 WHERE ID = 114
	UPDATE Planner.Teams SET GroupID = 19 WHERE ID = 115
	UPDATE Planner.Teams SET GroupID = 20 WHERE ID = 126
	UPDATE Planner.Teams SET GroupID = 19 WHERE ID = 138
	UPDATE Planner.Teams SET GroupID = 20 WHERE ID = 141


	--// SET-UP UNDER 15s BOYS AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (9, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 4)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (9, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 5)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (9, 'Group 3', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 6)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 21 WHERE ID = 20
	UPDATE Planner.Teams SET GroupID = 22 WHERE ID = 21
	UPDATE Planner.Teams SET GroupID = 23 WHERE ID = 31
	UPDATE Planner.Teams SET GroupID = 21 WHERE ID = 40
	UPDATE Planner.Teams SET GroupID = 22 WHERE ID = 48
	UPDATE Planner.Teams SET GroupID = 23 WHERE ID = 49
	UPDATE Planner.Teams SET GroupID = 21 WHERE ID = 64
	UPDATE Planner.Teams SET GroupID = 22 WHERE ID = 68
	UPDATE Planner.Teams SET GroupID = 23 WHERE ID = 69
	UPDATE Planner.Teams SET GroupID = 21 WHERE ID = 70
	UPDATE Planner.Teams SET GroupID = 22 WHERE ID = 81
	UPDATE Planner.Teams SET GroupID = 23 WHERE ID = 85
	UPDATE Planner.Teams SET GroupID = 21 WHERE ID = 91
	UPDATE Planner.Teams SET GroupID = 22 WHERE ID = 99
	UPDATE Planner.Teams SET GroupID = 23 WHERE ID = 100
	UPDATE Planner.Teams SET GroupID = 21 WHERE ID = 101
	UPDATE Planner.Teams SET GroupID = 22 WHERE ID = 127
	UPDATE Planner.Teams SET GroupID = 23 WHERE ID = 146



	--// SET-UP UNDER 16s BOYS AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (10, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 5)
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (10, 'Group 2', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 6)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 24 WHERE ID = 22
	UPDATE Planner.Teams SET GroupID = 25 WHERE ID = 23
	UPDATE Planner.Teams SET GroupID = 24 WHERE ID = 41
	UPDATE Planner.Teams SET GroupID = 25 WHERE ID = 65
	UPDATE Planner.Teams SET GroupID = 24 WHERE ID = 82
	UPDATE Planner.Teams SET GroupID = 25 WHERE ID = 88
	UPDATE Planner.Teams SET GroupID = 24 WHERE ID = 109
	UPDATE Planner.Teams SET GroupID = 25 WHERE ID = 111
	UPDATE Planner.Teams SET GroupID = 24 WHERE ID = 119
	UPDATE Planner.Teams SET GroupID = 25 WHERE ID = 131


	--// SET-UP UNDER 19s WOMEN AGE BAND
	--// Set up Groups and Pitches
	INSERT INTO Planner.Groups(CompetitionID, [Name], FixtureTurnaround, FixturesUnderWay)
	VALUES (11, 'Group 1', 0, 'false')
	SELECT @GroupID = @@IDENTITY
	INSERT INTO Planner.GroupsPlayingAreas (GroupID, PlayingAreaID)
	VALUES (@GroupID, 7)
	--// Allocate Teams to Groups
	UPDATE Planner.Teams SET GroupID = 26 WHERE ID = 24
	UPDATE Planner.Teams SET GroupID = 26 WHERE ID = 32
	UPDATE Planner.Teams SET GroupID = 26 WHERE ID = 66
	UPDATE Planner.Teams SET GroupID = 26 WHERE ID = 129
	UPDATE Planner.Teams SET GroupID = 26 WHERE ID = 147




END