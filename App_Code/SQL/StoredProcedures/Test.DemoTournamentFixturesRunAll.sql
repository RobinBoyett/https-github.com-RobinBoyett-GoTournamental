

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



	--#####################################
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 28, HomeTeamScore = 1, AwayTeamID = 27, AwayTeamScore = 2 WHERE ID = 132
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 11, HomeTeamScore = 1, AwayTeamID = 144, AwayTeamScore = 0 WHERE ID = 133
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 45, HomeTeamScore = 3, AwayTeamID = 46, AwayTeamScore = 1 WHERE ID = 134
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 36, HomeTeamScore = 0, AwayTeamID = 124, AwayTeamScore = 2 WHERE ID = 135
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 27, HomeTeamScore = 0, AwayTeamID = 11, AwayTeamScore = 4 WHERE ID = 136
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 45, HomeTeamScore = 1, AwayTeamID = 124, AwayTeamScore = 2 WHERE ID = 137

	--// Run Under 11s

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 138
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 5 WHERE ID = 139
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 140
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 141
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 142
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 143
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 144
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 145
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 146
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 147

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 3 WHERE ID = 148
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 149
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 150
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 151
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 4 WHERE ID = 152
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 153
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 154
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 155
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 156
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 157

	UPDATE [Planner].[Fixtures] SET HomeTeamID = 83, HomeTeamScore = 1, AwayTeamID = 145, AwayTeamScore = 0 WHERE ID = 168
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 105, HomeTeamScore = 1, AwayTeamID = 76, AwayTeamScore = 0 WHERE ID = 169
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 95, HomeTeamScore = 2, AwayTeamID = 61, AwayTeamScore = 0 WHERE ID = 170
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 89, HomeTeamScore = 1, AwayTeamID = 12, AwayTeamScore = 3 WHERE ID = 171
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 83, HomeTeamScore = 4, AwayTeamID = 105, AwayTeamScore = 2 WHERE ID = 172
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 95, HomeTeamScore = 2, AwayTeamID = 12, AwayTeamScore = 1 WHERE ID = 173

	--// Run Under 12s

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 174
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 175
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 176
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 177
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 3 WHERE ID = 178
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 179
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 3 WHERE ID = 180
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 181
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 182
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 4 WHERE ID = 183
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 184
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 185
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 186
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 187
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 188

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 6, AwayTeamScore = 0 WHERE ID = 189
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 190
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 191
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 192
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 193
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 194
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 195
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 196
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 197
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 198
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 199
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 200
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 201
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 202
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 203

	UPDATE [Planner].[Fixtures] SET HomeTeamID = 47, HomeTeamScore = 3, AwayTeamID = 52, AwayTeamScore = 0 WHERE ID = 204
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 130, HomeTeamScore = 2, AwayTeamID = 125, AwayTeamScore = 3 WHERE ID = 205
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 14, HomeTeamScore = 1, AwayTeamID = 110, AwayTeamScore = 0 WHERE ID = 206
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 15, HomeTeamScore = 1, AwayTeamID = 78, AwayTeamScore = 3 WHERE ID = 207
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 47, HomeTeamScore = 0, AwayTeamID = 125, AwayTeamScore = 2 WHERE ID = 208
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 14, HomeTeamScore = 3, AwayTeamID = 78, AwayTeamScore = 2 WHERE ID = 209

	--// Run Under 13s

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 4 WHERE ID = 210
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 211
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 212
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 213
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 214
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 215
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 216
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 217
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 4 WHERE ID = 218
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 219
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 220
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 221
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 5, AwayTeamScore = 0 WHERE ID = 222
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 3 WHERE ID = 223
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 224

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 225
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 3 WHERE ID = 226
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 227
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 228
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 229
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 230
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 231
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 232
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 233
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 5, AwayTeamScore = 2 WHERE ID = 234
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 235
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 3 WHERE ID = 236
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 0 WHERE ID = 237
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 238
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 239

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 240
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 241
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 242
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 243
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 244
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 245
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 246
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 247
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 248
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 249
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 250
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 4 WHERE ID = 251
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 252
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 253
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 254

	UPDATE [Planner].[Fixtures] SET HomeTeamID = 30, HomeTeamScore = 2, AwayTeamID = 86, AwayTeamScore = 0 WHERE ID = 255
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 16, HomeTeamScore = 1, AwayTeamID = 137, AwayTeamScore = 4 WHERE ID = 256
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 53, HomeTeamScore = 2, AwayTeamID = 118, AwayTeamScore = 1 WHERE ID = 257
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 63, HomeTeamScore = 0, AwayTeamID = 121, AwayTeamScore = 1 WHERE ID = 258
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 30, HomeTeamScore = 1, AwayTeamID = 137, AwayTeamScore = 0 WHERE ID = 259
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 53, HomeTeamScore = 2, AwayTeamID = 121, AwayTeamScore = 0 WHERE ID = 260

	--// Run Under 14s Boys

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 0 WHERE ID = 261
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 262
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 263
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 264
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 265
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 266
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 267
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 3 WHERE ID = 268
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 269
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 5, AwayTeamScore = 2 WHERE ID = 270
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 271
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 272
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 273
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 274
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 275
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 276
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 277
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 278
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 279
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 280
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 281


	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 7, AwayTeamScore = 2 WHERE ID = 282
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 283
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 284
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 285
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 286
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 287
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 288
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 289
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 290
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 291
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 292
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 293
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 4 WHERE ID = 294
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 295
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 296
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 297
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 298
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 299
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 3 WHERE ID = 300
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 301
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 302

	UPDATE [Planner].[Fixtures] SET HomeTeamID = 18, HomeTeamScore = 0, AwayTeamID = 141, AwayTeamScore = 3 WHERE ID = 303
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 138, HomeTeamScore = 2, AwayTeamID = 19, AwayTeamScore = 1 WHERE ID = 304
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 84, HomeTeamScore = 0, AwayTeamID = 107, AwayTeamScore = 1 WHERE ID = 305
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 114, HomeTeamScore = 2, AwayTeamID = 108, AwayTeamScore = 0 WHERE ID = 306
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 141, HomeTeamScore = 3, AwayTeamID = 138, AwayTeamScore = 2 WHERE ID = 307
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 107, HomeTeamScore = 4, AwayTeamID = 114, AwayTeamScore = 0 WHERE ID = 308

	--// Run Under 15s Boys

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 309
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 310
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 311
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 312
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 313
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 314
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 315
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 316
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 317
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 318
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 319
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 320
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 2 WHERE ID = 321
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 322
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 323

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 324
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 325
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 326
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 327
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 328
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 329
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 10 WHERE ID = 330
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 331
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 332
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 333
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 334
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 335
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 336
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 5 WHERE ID = 337
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 338

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 339
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 340
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 341
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 342
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 343
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 344
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 345
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 346
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 347
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 348
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 3 WHERE ID = 349
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 6, AwayTeamScore = 2 WHERE ID = 350
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 351
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 352
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 353

	UPDATE [Planner].[Fixtures] SET HomeTeamID = 20, HomeTeamScore = 0, AwayTeamID = 48, AwayTeamScore = 1 WHERE ID = 354
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 31, HomeTeamScore = 3, AwayTeamID = 91, AwayTeamScore = 2 WHERE ID = 355
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 64, HomeTeamScore = 4, AwayTeamID = 127, AwayTeamScore = 0 WHERE ID = 356
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 146, HomeTeamScore = 1, AwayTeamID = 85, AwayTeamScore = 2 WHERE ID = 357
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 48, HomeTeamScore = 0, AwayTeamID = 31, AwayTeamScore = 1 WHERE ID = 358
	UPDATE [Planner].[Fixtures] SET HomeTeamID = 64, HomeTeamScore = 0, AwayTeamID = 85, AwayTeamScore = 1 WHERE ID = 359

	--// Run Under 16s Boys

	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 378
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 379
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 380
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 381
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 382
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 383
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 384
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 385
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 386
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 387
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 4 WHERE ID = 388
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 5, AwayTeamScore = 2 WHERE ID = 389
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 390
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 391
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 392
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 393
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 394
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 395
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 396
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 397
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 398
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 399
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 400
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 3 WHERE ID = 401
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 402
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 403
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 404
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 405
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 406
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 1 WHERE ID = 407
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 408
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 1 WHERE ID = 409
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 410
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 411
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 412
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 413
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 414
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 2 WHERE ID = 415
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 6, AwayTeamScore = 0 WHERE ID = 416
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 417
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 418
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 419
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 420
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 421
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 422
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 423
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 424
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 0 WHERE ID = 425
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 426
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 427
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 428
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 429
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 4 WHERE ID = 430
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 431
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 432
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 433
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 434
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 435
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 436
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 437
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 7, AwayTeamScore = 1 WHERE ID = 438
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 439
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 440
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 441
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 442
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 443
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 3 WHERE ID = 444
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 445
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 446
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 4 WHERE ID = 447
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 448
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 449
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 450
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 451
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 452
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 2 WHERE ID = 453
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 1 WHERE ID = 454
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 455
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 456
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 0 WHERE ID = 457
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 458
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 459
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 460
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 1 WHERE ID = 461
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 462
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 463
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 464
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 465
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 1 WHERE ID = 466
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 467
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 3 WHERE ID = 468
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 5, AwayTeamScore = 0 WHERE ID = 469
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 470
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 3 WHERE ID = 471
	UPDATE [Planner].[Fixtures] SET HomeTeamScore = 4, AwayTeamScore = 2 WHERE ID = 472



	--472

	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 82, HomeTeamScore = 4, AwayTeamID = 23, AwayTeamScore = 1 WHERE ID = 380
	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 41, HomeTeamScore = 2, AwayTeamID = 131, AwayTeamScore = 0 WHERE ID = 381
	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 109, HomeTeamScore = 1, AwayTeamID = 65, AwayTeamScore = 2 WHERE ID = 382
	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 111, HomeTeamScore = 1, AwayTeamID = 22, AwayTeamScore = 2 WHERE ID = 383
	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 82, HomeTeamScore = 2, AwayTeamID = 41, AwayTeamScore = 1 WHERE ID = 384
	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 65, HomeTeamScore = 0, AwayTeamID = 22, AwayTeamScore = 3 WHERE ID = 385

	--// Run Under 19s Women

	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 0 WHERE ID = 386
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 387
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 388
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 1 WHERE ID = 389
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 390
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 0 WHERE ID = 391
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 1, AwayTeamScore = 2 WHERE ID = 392
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 3, AwayTeamScore = 0 WHERE ID = 393
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 2, AwayTeamScore = 2 WHERE ID = 394
	--UPDATE [Planner].[Fixtures] SET HomeTeamScore = 0, AwayTeamScore = 1 WHERE ID = 395

	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 147, HomeTeamScore = 2, AwayTeamID = 66, AwayTeamScore = 1 WHERE ID = 398
	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 24, HomeTeamScore = 0, AwayTeamID = 129, AwayTeamScore = 2 WHERE ID = 399
	--UPDATE [Planner].[Fixtures] SET HomeTeamID = 147, HomeTeamScore = 4, AwayTeamID = 129, AwayTeamScore = 1 WHERE ID = 401


END