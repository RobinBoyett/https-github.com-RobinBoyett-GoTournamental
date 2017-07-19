

CREATE PROCEDURE [Test].[DemoTournamentFixturesRunAll] 
AS

BEGIN

	--// Run Under 7s
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 1
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 2
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 3
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 4
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 5
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 6
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 0 WHERE ID = 7
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 8
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 9
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 10
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 11
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 12
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 13
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 6, AwayTeamScore = 2 WHERE ID = 14
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 15
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 16
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 1 WHERE ID = 17
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 18
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 19
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 20

	--// Run Under 8s
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 21
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 22
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 23
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 24
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 25
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 26
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 6, AwayTeamScore = 0 WHERE ID = 27
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 4 WHERE ID = 28
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 29
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 30
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 5, AwayTeamScore = 1 WHERE ID = 31
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 32
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 3 WHERE ID = 33
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 34
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 35
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 36
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 37
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 38
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 39
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 40
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 41
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 42
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 43
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 44
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 45
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 46
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 2 WHERE ID = 47
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 48
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 49
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 50

	--// Run Under 9s
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 2 WHERE ID = 51
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 52
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 53
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 54
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 55
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 56
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 5 WHERE ID = 57
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 58
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 59
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 60

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 61
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 62
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 63
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 64
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 65
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 66
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 67
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 3 WHERE ID = 68
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 69
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 70
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 71
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 72
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 5 WHERE ID = 73
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 74
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 75
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 76
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 77
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 78
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 79
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 80
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 81
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 82
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 5 WHERE ID = 83
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 84
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 85
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 86
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 87
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 88
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 89
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 90
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 3 WHERE ID = 91
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 92
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 93
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 94
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 95
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 8, HomeTeamScore = 4, AwayTeamID = 116, AwayTeamScore = 1 WHERE ID = 96
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 93, HomeTeamScore = 0, AwayTeamID = 26, AwayTeamScore = 1 WHERE ID = 97
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 103, HomeTeamScore = 2, AwayTeamID = 58, AwayTeamScore = 1 WHERE ID = 98
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 143, HomeTeamScore = 1, AwayTeamID = 35, AwayTeamScore = 0 WHERE ID = 99
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 8, HomeTeamScore = 0, AwayTeamID = 26, AwayTeamScore = 1 WHERE ID = 100
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 103, HomeTeamScore = 2, AwayTeamID = 143, AwayTeamScore = 1 WHERE ID = 101

	--// Run Under 10s

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 102
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 103
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 104
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 105
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 106
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 107
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 108
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 6, AwayTeamScore = 0 WHERE ID = 109
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 110
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 111
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 112
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 113
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 114
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 115
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 116
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 3 WHERE ID = 117
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 1 WHERE ID = 118
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 119
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 120
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 121
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 122
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 123
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 124
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 125
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 126
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 127
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 128
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 3 WHERE ID = 129
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 130
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 131

END