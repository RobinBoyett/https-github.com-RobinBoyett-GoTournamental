


CREATE PROCEDURE [Planner].[FixtureReplaceFinalistTeam] (
	@FinalistTeamID							int	,
	@ReplacementTeamID						int	
)
AS


BEGIN
	
	UPDATE [Planner].[Fixtures] SET HomeTeamID = @ReplacementTeamID 
	WHERE HomeTeamID = @FinalistTeamID AND GroupID IS NULL

	UPDATE [Planner].[Fixtures] SET AwayTeamID = @ReplacementTeamID 
	WHERE AwayTeamID = @FinalistTeamID AND GroupID IS NULL



END