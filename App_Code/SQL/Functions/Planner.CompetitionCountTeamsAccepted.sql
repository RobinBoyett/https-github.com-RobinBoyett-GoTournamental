USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountTeamsAcceptedInviteForCompetition] Script Date: 13/10/2015 11:11:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [Planner].[CompetitionCountTeamsAccepted] (
	@CompetitionID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoTeams		int

	SELECT @NoTeams = COUNT(*) FROM Planner.Teams WHERE CompetitionID = @CompetitionID AND AttendanceType = 3 

	RETURN @NoTeams

END