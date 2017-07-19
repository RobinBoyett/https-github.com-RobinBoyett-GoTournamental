USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CompetitionIDForAgeBand] Script Date: 28/03/2015 07:37:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [Planner].[CompetitionIDForAgeBand] (
	@tournamentID	int					,
	@ageBand		int
)
RETURNS INT
AS

BEGIN

	DECLARE @CompetitionID		int
	SELECT @CompetitionID = 0

	SELECT @CompetitionID = ID FROM Planner.Competitions WHERE TournamentID = @tournamentID AND AgeBand = @ageBand

	RETURN @CompetitionID

END