CREATE PROCEDURE [Test].[ResetDatabase] 
AS

BEGIN
	
	TRUNCATE TABLE Administration.ContactUs
	TRUNCATE TABLE Administration.Exceptions
	TRUNCATE TABLE Administration.TermsSignatories
	TRUNCATE TABLE Administration.FileImportAudits
	TRUNCATE TABLE Planner.Documents
	TRUNCATE TABLE Planner.Fixtures
	TRUNCATE TABLE Planner.GroupsPlayingAreas
	TRUNCATE TABLE Planner.Groups
	TRUNCATE TABLE Planner.Adverts
	TRUNCATE TABLE Planner.Advertisers
	TRUNCATE TABLE Planner.Contacts
	TRUNCATE TABLE Planner.Teams
	TRUNCATE TABLE Planner.Clubs
	TRUNCATE TABLE Planner.PlayingAreas
	TRUNCATE TABLE Planner.Competitions
	TRUNCATE TABLE Planner.Tournaments

	DROP TABLE AspNetUserClaims
	DROP TABLE AspNetUserLogins
	DROP TABLE AspNetUserRoles
	DROP TABLE AspNetRoles
	DROP TABLE AspNetUsers
	DROP TABLE __MigrationHistory

END