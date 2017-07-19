USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[FixturesForTournament] Script Date: 28/03/2015 07:30:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[CompetitionClubsAll] (
	@CompetitionID		int
)
AS

BEGIN
	
	SELECT * FROM Planner.Clubs WHERE ID IN (
		SELECT ClubID FROM Planner.Teams WHERE CompetitionID = @CompetitionID
	)

END