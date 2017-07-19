USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountPlayingAreasForTournament] Script Date: 28/03/2015 07:41:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [Planner].[TournamentCountPlayingAreas] (
	@TournamentID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoPlayingAreas		int

	SELECT @NoPlayingAreas = COUNT(*) FROM Planner.PlayingAreas WHERE TournamentID = @TournamentID

	RETURN @NoPlayingAreas

END