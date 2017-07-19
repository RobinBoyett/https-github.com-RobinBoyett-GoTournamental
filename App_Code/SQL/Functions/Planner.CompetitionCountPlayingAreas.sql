USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountPlayingAreasForCompetition] Script Date: 28/03/2015 07:41:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [Planner].[CompetitionCountPlayingAreas] (
	@CompetitionID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoGroup		int

	SELECT @NoGroup = COUNT(*) FROM Planner.GroupsPlayingAreas WHERE GroupID IN (SELECT ID FROM Planner.Groups WHERE CompetitionID = @CompetitionID)

	RETURN @NoGroup

END
