USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountFixturesForCompetition] Script Date: 28/03/2015 07:39:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [Planner].[CompetitionCountLeagueFixtures] (
	@CompetitionID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoFixtures		int

	SELECT @NoFixtures = COUNT(*) FROM Fixtures WHERE GroupID IN (
		SELECT ID FROM Planner.Groups WHERE CompetitionID = @CompetitionID
	)

	RETURN @NoFixtures

END