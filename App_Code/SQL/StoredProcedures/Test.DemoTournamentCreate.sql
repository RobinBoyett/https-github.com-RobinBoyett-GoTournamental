

CREATE PROCEDURE [Test].[DemoTournamentCreate] 
AS

DECLARE @TournamentID			int
DECLARE @ClubID					int
DECLARE @TeamID					int
DECLARE @ContactID				int
DECLARE @UserID					varchar(2000)
DECLARE @GroupID				int

BEGIN

	--// CREATE TOURNAMENT
	INSERT INTO Planner.Tournaments ([Type], [Name], StartTime, EndTime, Venue, Postcode, GoogleMapsURL, NoOfPlayingAreas, FixtureTurnaround, FixtureHalvesNumber, FixtureHalvesLength, TeamSize, SquadSize, RotatorDate, RotatorSession) 
	VALUES (1, 'Tournament Demonstration 2017', CONVERT(datetime,'24/06/2017 09:00:00',103), CONVERT(datetime,'25/06/2017 00:00:00',103), 'Sir Alf Ramsey Playing Fields, Broadmead', 'TN6 2TN', NULL, 7, 15, 2, 6, 6, 8, NULL, 0)


 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	--	Allocate tournament to user / administrator
	SELECT @UserID = id FROM dbo.AspNetUsers WHERE UserName = 'Rob'
	INSERT INTO dbo.AspNetUserClaims (UserId, ClaimType, ClaimValue) VALUES (@UserID, 'TournamentID', @TournamentID)
	SELECT @UserID = id FROM dbo.AspNetUsers WHERE UserName = 'Martin'
	INSERT INTO dbo.AspNetUserClaims (UserId, ClaimType, ClaimValue) VALUES (@UserID, 'TournamentID', @TournamentID)

	-- Create Host Club
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Broad Beech', 1, 'Blue', 'Blue', 50, '000354', NULL)
 	SELECT @ClubID = @@IDENTITY

	INSERT INTO Planner.Contacts (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (@TournamentID, 2, NULL, 'Rg+SxJ25zghSvkLGJtjHcw==', 'IasqV6dGeVAy6opPcFXy7RMWGMGo4fW/FRaTF6cQotg=', 'duG6ohtz/8MmkDNbbHphrOXF0RMj9etKEL5NLvhR5ek=', 'i88MDc63lqzXiK3w/Xci70WVvBvjrnDTJA1L8HDraI4PLyDPFNFgUD0fj3krJ09DO9Xmu5aTc+CyuXZdsGFUNYstuO0N4CTtm1kkVsqakpM=')

	--// CREATE AND NAME PLAYING AREAS
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 1')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 2')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 3')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 4')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 5')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 6')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 7')



END