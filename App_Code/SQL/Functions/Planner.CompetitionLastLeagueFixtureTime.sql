USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountTeamsForCompetition] Script Date: 28/03/2015 07:42:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [Planner].[CompetitionLastLeagueFixtureTime] (
	@CompetitionID int
)
RETURNS DATETIME
AS

BEGIN

	DECLARE @LastFixture		datetime

	SELECT @LastFixture = MAX(StartTime) 
	FROM Fixtures 
	WHERE GroupID IN (SELECT ID FROM Planner.Groups WHERE CompetitionID = @CompetitionID)
	AND IsLeagueFixture = 1

	RETURN @LastFixture

END
