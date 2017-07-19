USE [GoTournamental]
GO

/****** Object: SqlProcedure [dbo].[AdjustFixtureTimesInGroupOfFour] Script Date: 14/07/2015 11:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Planner].[FixtureAdjustTimesInGroupOfFour] (
	@GroupID		int		
)
AS


BEGIN

	UPDATE Planner.Fixtures SET StartTime = DATEADD(MINUTE,15,StartTime) WHERE groupID = @GroupID AND Name = 'Match 3'
	UPDATE Planner.Fixtures SET StartTime = DATEADD(MINUTE,15,StartTime) WHERE groupID = @GroupID AND Name = 'Match 4'
	UPDATE Planner.Fixtures SET StartTime = DATEADD(MINUTE,30,StartTime) WHERE groupID = @GroupID AND Name = 'Match 5'
	UPDATE Planner.Fixtures SET StartTime = DATEADD(MINUTE,30,StartTime) WHERE groupID = @GroupID AND Name = 'Match 6'

END
