

CREATE PROCEDURE [Test].[DemoTournamentCreate] 
AS

DECLARE @TournamentID			int
DECLARE @ClubID					int
DECLARE @TeamID					int
DECLARE @ContactID				int
DECLARE @UserID					varchar(2000)
DECLARE @GroupID				int

BEGIN

	--// CREATE TOURNAMENTS
	INSERT INTO Planner.Tournaments ([Type], [Name], StartTime, EndTime, Venue, Postcode, GoogleMapsURL, NoOfPlayingAreas, FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize, RotatorDate, RotatorSession) 
	VALUES (1, 'Tournament Demonstration 2017', CONVERT(datetime,'24/06/2017 09:00:00',103), CONVERT(datetime,'25/06/2017 00:00:00',103), 'Sir Alf Ramsey Playing Fields, Broadmead', 'TN6 2TN', 'https://goo.gl/maps/3fJ161HzWX82', 10, 15, 2, 6, 6, 8, NULL, 0)

	INSERT INTO Planner.Tournaments ([Type], [Name], StartTime, EndTime, Venue, Postcode, GoogleMapsURL, NoOfPlayingAreas, FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize, RotatorDate, RotatorSession) 
	VALUES (1, 'U9 Winter Tournament', CONVERT(datetime,'06/01/2018 09:00:00',103), NULL, 'Recreational Ground', 'TN21 3FG', NULL, 6, 15, 2, 6, 6, 8, NULL, 0)

	INSERT INTO Planner.Tournaments ([Type], [Name], StartTime, EndTime, Venue, Postcode, GoogleMapsURL, NoOfPlayingAreas, FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize, RotatorDate, RotatorSession) 
	VALUES (1, 'Football Fiesta 2018', CONVERT(datetime,'05/05/2018 09:00:00',103), CONVERT(datetime,'07/05/2018 09:00:00',103), 'Riverside Lesiure Centre', 'TN2 8SS', NULL, 10, 15, 2, 6, 6, 8, NULL, 0)

	INSERT INTO Planner.Tournaments ([Type], [Name], StartTime, EndTime, Venue, Postcode, GoogleMapsURL, NoOfPlayingAreas, FixtureTurnaround, FixtureStructure, FixtureHalvesLength, TeamSize, SquadSize, RotatorDate, RotatorSession) 
	VALUES (1, 'Football Festival', CONVERT(datetime,'30/06/2018 09:00:00',103), CONVERT(datetime,'01/06/2018 09:00:00',103), 'Oak Meadow', 'TN12 0KL', NULL, 8, 15, 2, 6, 6, 8, NULL, 0)


 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	--	Allocate tournament to user / administrator
	SELECT @UserID = id FROM dbo.AspNetUsers WHERE UserName = 'Rob'
	INSERT INTO Administration.TermsSignatories (UserID, UserName) VALUES (@UserID, '')
	INSERT INTO dbo.AspNetUserClaims (UserId, ClaimType, ClaimValue) VALUES (@UserID, 'TournamentID', @TournamentID)

	SELECT @UserID = id FROM dbo.AspNetUsers WHERE UserName = 'Martin'
	INSERT INTO Administration.TermsSignatories (UserID, UserName) VALUES (@UserID, '')
	INSERT INTO dbo.AspNetUserClaims (UserId, ClaimType, ClaimValue) VALUES (@UserID, 'TournamentID', @TournamentID)

	--// CREATE TOURNAMENT CONTACTS
	INSERT INTO Planner.Contacts (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (1, 2, NULL, 'Rg+SxJ25zghSvkLGJtjHcw==', 'IasqV6dGeVAy6opPcFXy7RMWGMGo4fW/FRaTF6cQotg=', 'duG6ohtz/8MmkDNbbHphrOXF0RMj9etKEL5NLvhR5ek=', 'i88MDc63lqzXiK3w/Xci70WVvBvjrnDTJA1L8HDraI4PLyDPFNFgUD0fj3krJ09DO9Xmu5aTc+CyuXZdsGFUNYstuO0N4CTtm1kkVsqakpM=')

 	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (2, 2, NULL, 'mYrqxG8eSfZmgpEhw78NqA==', 'J8aQwhOHvVOVkPO75sZ6w12uCH8GKGdQpNkJm2L+97Q=', 'JUu+v1wCxDdU5gjBYfQKvCpSTDHLDq3OkQ1YmZrJIbg=', '')

	INSERT INTO [Planner].[Contacts] (TournamentID, [Type], Title, FirstName, LastName, TelephoneNumber, Email)
	VALUES (3, 2, NULL, 'wJVEzM74gDk27AErq46Dew==', 'QVvVT1p9loSsAULrPagu+g==',  '1wrS5YDuCk7FwTOF8YsH0kL5n5MkMZ0Q5YwCafZqKKk=', 'jrsIeZHsLap+gDIV6MR5wlrsgyu4en0F58/vFbWLhGw7AsO4C2kBLgC5h/TeZ4Ii')


	--// CREATE AND NAME PLAYING AREAS
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 1')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 2')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 3')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 4')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 5')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 6')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 7')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 8')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 9')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 10')
	INSERT INTO [Planner].[PlayingAreas] (TournamentID, Name) VALUES (@TournamentID, 'Pitch 11')

	-- Create Host Clubs
 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Tournament Demonstration 2017'
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Broad Beech', 1, 'Blue', 'Blue', 50, '000354', NULL)
	SELECT @ClubID = @@IDENTITY
	UPDATE Planner.Tournaments SET HostClubID = @ClubID WHERE ID = @TournamentID

 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'U9 Winter Tournament'
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Oakfield', 1, 'SkyBlue', 'Blue', 50, '000721', NULL)
	SELECT @ClubID = @@IDENTITY
	UPDATE Planner.Tournaments SET HostClubID = @ClubID WHERE ID = @TournamentID

 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Football Fiesta 2018'
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Alderhill Rangers', 1, 'Maroon', 'SkyBlue', 50, '0005463', NULL)
	SELECT @ClubID = @@IDENTITY
	UPDATE Planner.Tournaments SET HostClubID = @ClubID WHERE ID = @TournamentID

 	SELECT @TournamentID = ID FROM Planner.Tournaments WHERE [Name] = 'Football Festival'
	INSERT INTO Planner.Clubs (TournamentID, Name, AttendanceType, ColourPrimary, ColourSecondary, Affiliation, AffiliationNumber, PrimaryContactID)
	VALUES (@TournamentID, 'Turners Oast', 1, 'Lime', 'Black', 50, '0009876', NULL)
	SELECT @ClubID = @@IDENTITY
	UPDATE Planner.Tournaments SET HostClubID = @ClubID WHERE ID = @TournamentID



END