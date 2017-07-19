

USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountTeamsAttendingCompetition] Script Date: 24/06/2015 08:42:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [Planner].[CompetitionCountTeamsRegistered] (
	@CompetitionID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoTeams		int

	SELECT @NoTeams = COUNT(*) FROM Planner.Teams WHERE CompetitionID = @CompetitionID AND Registered = 'true'

	RETURN @NoTeams

END
