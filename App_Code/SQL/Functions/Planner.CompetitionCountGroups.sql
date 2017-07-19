USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[CountGroupsForCompetition] Script Date: 28/03/2015 07:40:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [Planner].[CompetitionCountGroups] (
	@competitionID int
)
RETURNS INT
AS

BEGIN

	DECLARE @NoGroup		int

	SELECT @NoGroup = COUNT(*) FROM Planner.Groups WHERE CompetitionID = @competitionID


	RETURN @NoGroup

END