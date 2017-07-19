USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountTeamsForTournament] Script Date: 28/03/2015 07:43:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [Planner].[TournamentCountTeamsForAttendanceType] (
	@TournamentID		int,
	@AttendanceType		int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoTeams		int
	SELECT @NoTeams = 0
	
	IF @AttendanceType = 4
	BEGIN
		SELECT @NoTeams = COUNT(*) FROM Planner.Teams WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID) AND AttendanceType IN (1, 4)
	END
	ELSE
	BEGIN
		SELECT @NoTeams = COUNT(*) FROM Planner.Teams WHERE CompetitionID IN (SELECT ID FROM Planner.Competitions WHERE TournamentID = @TournamentID) AND AttendanceType = @AttendanceType
	END

	RETURN @NoTeams

END
