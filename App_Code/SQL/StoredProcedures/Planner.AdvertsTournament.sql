USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[FixturesForTournament] Script Date: 28/03/2015 07:30:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[AdvertsTournament] (
	@TournamentID		int
)
AS

BEGIN
	
	SELECT * FROM Planner.Adverts WHERE AdvertiserID IN (
		SELECT ID FROM Planner.Advertisers WHERE TournamentID = @TournamentID
	)

END
