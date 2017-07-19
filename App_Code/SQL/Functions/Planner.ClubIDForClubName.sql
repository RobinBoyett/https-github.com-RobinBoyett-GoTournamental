USE [GoTournamental]
GO

/****** Object: Scalar Function [dbo].[ClubIDForClubName] Script Date: 28/03/2015 07:36:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [Planner].[ClubIDForClubName] (
	@tournamentID	int					,
	@clubName		varchar(100)
)
RETURNS INT
AS

BEGIN

	DECLARE @ClubID		int
	SELECT @ClubID = 0

	SELECT @ClubID = ID FROM Planner.Clubs WHERE TournamentID = @tournamentID AND Name = @clubName

	RETURN @ClubID

END