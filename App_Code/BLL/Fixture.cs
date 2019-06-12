using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Planner;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser 
{

    public class Fixture: IFixture 
    {

        #region Member Enumerations & Collections
        public enum OrderListBy 
        {
            Undefined = 0,
            [DescriptionAttribute("Kick Off Time")] StartTime = 1,
            [DescriptionAttribute("Pitch No.")] PlayingArea = 2
        }
        public enum Venue 
        {
            Undefined = 0,
            Home = 1,
            Away = 2
        }
        #endregion

		#region Constructors
        public Fixture() { }
        public Fixture(
            int id, int? competitionID, int? groupID, bool? isLeagueFixture, int? playingAreaID, string name, DateTime? startTime, 
            int? homeTeamID, int? homeTeamScore, int? homeTeamPenaltiesScore, int? awayTeamID, int? awayTeamScore, int? awayTeamPenaltiesScore, int? primaryOfficialID
        ) 
        {
			this.ID = id;
			this.CompetitionID = competitionID;
			this.GroupID = groupID;
			this.IsLeagueFixture = isLeagueFixture;
			this.PlayingAreaID = playingAreaID;
			this.Name = name;
			this.StartTime = startTime;
			this.HomeTeamID = homeTeamID;
			this.HomeTeamScore = homeTeamScore;
            this.HomeTeamPenaltiesScore = homeTeamPenaltiesScore;
			this.AwayTeamID = awayTeamID;
			this.AwayTeamScore = awayTeamScore;
            this.AwayTeamPenaltiesScore = awayTeamPenaltiesScore;
			this.PrimaryOfficialID = primaryOfficialID;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int? CompetitionID { get; set; }
        public Competition Competition 
        {
            get 
            {
                Competition competition = new Competition();
                ICompetition iCompetition = new Competition();
                if (this.CompetitionID != null) 
                {
                    competition = iCompetition.SQLSelect<Competition, int?>(CompetitionID);
                }
                return competition;
            }
        }
        public int? GroupID { get; set; }
        public Group Group
        {
            get
            {
                Group group = new Group();
                IGroup iGroup = new Group();
                if (this.GroupID != null) 
                {
                    group = iGroup.SQLSelect<Group, int?>(GroupID);
                }
                return group;
            }
        }
        public bool? IsLeagueFixture { get; set; }
		public int? PlayingAreaID { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public int? HomeTeamID { get; set; }
        public Team HomeTeam 
        {
            get 
            {
                Team team = new Team();
                ITeam iTeam = new Team();
                if (this.HomeTeamID != null) 
                {
                    team = iTeam.SQLSelect<Team, int?>(HomeTeamID);
                }
                return team;
            }
        }
        public int? HomeTeamScore { get; set; }
        public int? HomeTeamPenaltiesScore { get; set; }
        public int? AwayTeamID { get; set; }
        public Team AwayTeam 
        {
            get 
            {
                Team team = new Team();
                ITeam iTeam = new Team();
                if (this.AwayTeamID != null) 
                {
                    team = iTeam.SQLSelect<Team, int?>(AwayTeamID);
                }
                return team;
            }
        }
        public int? AwayTeamScore { get; set; }
        public int? AwayTeamPenaltiesScore { get; set; }
        public int? PrimaryOfficialID { get; set; }
        public Contact PrimaryOfficial 
        {
            get 
            {
                Contact contact = new Contact();
                IContact iContact = new Contact();
                if (this.PrimaryOfficialID != null) 
                {
                    contact = iContact.SQLSelect<Contact, int?>(PrimaryOfficialID);
                }
                return contact;
            }
        }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input)
        {
            if (ObjectExtensions.ObjectTypesMatch<Fixture, T>(input)) 
            {
                FixtureDbContext context = new FixtureDbContext();
                context.Fixtures.Add((Fixture)(object)input);
                context.SaveChanges();
            }
        }
		public void SQLUpdateScores(Fixture fixture)
        {
			FixtureDbContext context = new FixtureDbContext();
			Fixture updated = fixture;
			Fixture selected = context.Fixtures.Single(i => i.ID == updated.ID);
			selected.HomeTeamScore = updated.HomeTeamScore;
			selected.AwayTeamScore = updated.AwayTeamScore;
            selected.HomeTeamPenaltiesScore = updated.HomeTeamPenaltiesScore;
            selected.AwayTeamPenaltiesScore = updated.AwayTeamPenaltiesScore;
			context.SaveChanges();
		}
		public void SQLUpdatePenaltyScores(Fixture fixture) 
        {
			FixtureDbContext context = new FixtureDbContext();
			Fixture updated = fixture;
			Fixture selected = context.Fixtures.Single(i => i.ID == updated.ID);
			selected.HomeTeamPenaltiesScore = updated.HomeTeamPenaltiesScore;
			selected.AwayTeamPenaltiesScore = updated.AwayTeamPenaltiesScore;
			context.SaveChanges();
		}

        public T SQLSelect<T, U>(U id) 
        {
            FixtureDbContext context = new FixtureDbContext();
            Fixture selected = context.Fixtures.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }

        public List<Fixture> SQLSelectForGroup(int groupID) 
        {
            FixtureDbContext context = new FixtureDbContext();
            List<Fixture> selectedList = context.Fixtures.Where(i => i.GroupID == groupID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
		public List<Fixture> SQLSelectFinalsForCompetition(int competitionID) 
        {
            FixtureDbContext context = new FixtureDbContext();
            List<Fixture> selectedList = context.Fixtures.Where(i => i.GroupID == null && i.CompetitionID == competitionID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
		public List<Fixture> SQLSelectForCompetition(int competitionID)
        {
            FixtureDbContext context = new FixtureDbContext();
            List<Fixture> selectedList = context.Fixtures.Where(i => i.CompetitionID == competitionID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }		
        public List<Fixture> SQLSelectForPlayingArea(int playingAreaID)
        {
            FixtureDbContext context = new FixtureDbContext();
            List<Fixture> selectedList = context.Fixtures.Where(i => i.PlayingAreaID == playingAreaID).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
		public List<Fixture> SQLSelectForPlayingArea(int playingAreaID, DateTime scheduledDay) 
        {
            FixtureDbContext context = new FixtureDbContext();
            List<Fixture> selectedList = context.Fixtures.Where(i => i.PlayingAreaID == playingAreaID && i.StartTime.Value.Day == scheduledDay.Day).OrderBy(i => i.StartTime).ToList();
            return selectedList;
        }        		
		public List<Fixture> GetSearchFixturesForTournament(int tournamentID, Competition competition, Fixture.OrderListBy orderBy, GoTournamental.BLL.Organiser.Contact contact, Club club, Team team) 
        {
            FixtureDbContext context = new FixtureDbContext();
            List<Fixture> selectedList = context.GetFixturesForTournament(tournamentID).ToList();
        	IQueryable<Fixture> query = selectedList.ToList().AsQueryable();
			if (contact.ID != null && contact.ID != 0) 
            {
				query = query.Where(i => i.PrimaryOfficialID == contact.ID || i.HomeTeam.PrimaryContactID == contact.ID || i.AwayTeam.PrimaryContactID == contact.ID);
			}
			if (club.ID != null && club.ID != 0) 
            {
				query = query.Where(i => i.HomeTeam.ClubID == club.ID || i.AwayTeam.ClubID == club.ID);
			}
			if (team.ID != null && team.ID != 0) 
            {
				query = query.Where(i => i.HomeTeamID == team.ID || i.AwayTeamID == team.ID);
			}
			if (contact.ID == 0 && club.ID == 0 && team.ID == 0) 
            {
				query = query.Where(i => i.CompetitionID == competition.ID);
			}
			switch (orderBy) 
            {
				case Fixture.OrderListBy.PlayingArea:
					query = query.OrderBy(i => i.PlayingAreaID);  	
					break;
				case Fixture.OrderListBy.StartTime:
				default:
					query = query.OrderBy(i => i.StartTime);  	
					break;
			}
			selectedList = query.ToList();
			return selectedList;        
        }                     
		public DateTime? GetLastLeagueFixtureTimeForCompetition(int competitionID)
        {
            FixtureDbContext context = new FixtureDbContext();
			DateTime? start = new DateTime?();
			if (context.GetLastLeagueFixtureTimeForCompetition(competitionID).Single() != null) 
            {
				start = context.GetLastLeagueFixtureTimeForCompetition(competitionID).Single();
			}
            return start;
        }	
		
        public void GenerateFixturesForCompetition(Tournament tournament, Competition competition)
        {
            #region local objects, interfaces and variables
            IFixture iFixture = new Fixture();
            DateTime fixtureStart = new DateTime();
            #endregion

            #region generate fixtures for groups
            if (competition.CompetitionFormat != Competition.CompetitionFormats.Undefined )   // this will need refactoring if cup knockouts are introduced as formats
            { 
                GenerateFixturesForCompetitionGroups(competition);
            }
            #endregion

            #region generate quarters, semis and finals
            if (iFixture.GetLastLeagueFixtureTimeForCompetition(competition.ID) != null) // this will need refactoring if cup knockouts are introduced as formats
            {
                fixtureStart = (DateTime)iFixture.GetLastLeagueFixtureTimeForCompetition(competition.ID);
            }

            if (    // plate quarter finals
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals
            )
            {
                fixtureStart = GenerateFixturesForPlateQuarterFinals(competition, fixtureStart);
            }

            if (    // cup quarter finals
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals
            )
            {
                fixtureStart = GenerateFixturesForCupQuarterFinals(competition, fixtureStart);
            }

            if (    // plate semi-finals
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals
            )
            {
                fixtureStart = GenerateFixturesForPlateSemiFinals(competition, fixtureStart);
            }

            if (    // cup semi-finals
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals
            )
            {
                fixtureStart = GenerateFixturesForCupSemiFinals(competition, fixtureStart);
            }

            if (    // plate final
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals
            )
            {
                fixtureStart = GenerateFixtureForPlateFinal(competition, fixtureStart);
            }

            if (    // 3rd place play off
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace
            )
            {
                fixtureStart = GenerateFixtureForThirdPlace(competition, fixtureStart);
            }

            if (    // cup final
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals ||
                competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals
            )
            {
                GenerateFixtureForCupFinal(competition, fixtureStart);
            }
            #endregion

        }

        public void GenerateFixturesForCompetitionGroups(Competition competition)
        {
            #region local objects, interfaces and variables
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            ITeam iTeam = new Team();
            List<Team> teamsInGroup = new List<Team>();
            IFixture iFixture = new Fixture();
            Fixture fixture = new Fixture();
            ArrayList teamsArray = new ArrayList();
            ArrayList fixturesArray = new ArrayList();
            ArrayList tempArray = new ArrayList();
            int noTeams = 0;
            int noFixtureRounds = 0;
            int noMatchesPerRound = 0;
            int noMatchesGenerated = 0;
            #endregion
            foreach (Group group in groupsList)
            {
                teamsInGroup = null;
                teamsInGroup = iTeam.SQLSelectForGroup(group.ID);
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
                DateTime fixtureStart = (DateTime)competition.StartTime;

                Team fixedTeam = teamsInGroup[0];
                for (int teamIndex = 0; teamIndex < teamsInGroup.Count; teamIndex++) 
                {
                    teamsArray.Add(teamsInGroup[teamIndex]);
                    fixturesArray.Add(teamsInGroup[teamIndex]);
                    tempArray.Add(teamsInGroup[teamIndex]);
                }
                noTeams = teamsInGroup.Count;
                noFixtureRounds = (teamsInGroup.Count - 1);

                if (teamsInGroup.Count % 2 == 0)
                {                                            // Groups with even number of teams
                    noFixtureRounds = (teamsInGroup.Count - 1);
                    noMatchesPerRound = (teamsInGroup.Count / 2);
                    for (int fixtureRound = 0; fixtureRound < noFixtureRounds; fixtureRound++) 
                    {
                        for (int noMatches = 1; noMatches <= noMatchesPerRound; noMatches++) 
                        {
                            noMatchesGenerated++;
                            if (fixtureRound % 2 == 0)
                            {
                                fixture = new Fixture(
                                    id: 0,
                                    competitionID : competition.ID ,
                                    groupID: group.ID,
                                    isLeagueFixture : true ,
                                    playingAreaID: playingArea.ID,
                                    name: "Match " + noMatchesGenerated.ToString(),
                                    startTime: fixtureStart,
                                    homeTeamID: ((Team)fixturesArray[(noMatches - 1) * 2]).ID,
                                    homeTeamScore: null,
                                    homeTeamPenaltiesScore: null,
                                    awayTeamID: ((Team)fixturesArray[(noMatches * 2) - 1]).ID,
                                    awayTeamScore: null,
                                    awayTeamPenaltiesScore: null,
                                    primaryOfficialID: null
                                );
                            }
                            else
                            {
                                fixture = new Fixture(
                                    id: 0,
                                    competitionID : competition.ID ,
                                    groupID: group.ID,
                                    isLeagueFixture : true ,
                                    playingAreaID: playingArea.ID,
                                    name: "Match " + noMatchesGenerated.ToString(),
                                    startTime: fixtureStart,
                                    homeTeamID: ((Team)fixturesArray[(noMatches * 2) - 1]).ID,
                                    homeTeamScore: null,
                                    homeTeamPenaltiesScore: null,
                                    awayTeamID: ((Team)fixturesArray[(noMatches - 1) * 2]).ID,
                                    awayTeamScore: null,
                                    awayTeamPenaltiesScore: null,
                                    primaryOfficialID: null
                                );
                            }
                            iFixture.SQLInsert<Fixture>(fixture);
                            fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
                        }
                        tempArray[0] = fixedTeam;
                        for (int i = 0; i < teamsInGroup.Count; i++) 
                        {
                            if (i == 1)
                            {
                                tempArray[i] = fixturesArray[i + 1];
                            }
                            if (i % 2 == 1 && i > 2) 
                            {
                                tempArray[i] = fixturesArray[i - 2];
                            }
                            if (i % 2 == 0 && i > 0 && i < teamsInGroup.Count - 2) 
                            {
                                tempArray[i] = fixturesArray[i + 2];
                            }
                            if (i == teamsInGroup.Count - 2) 
                            {
                                tempArray[teamsInGroup.Count - 2] = fixturesArray[teamsInGroup.Count - 1];
                            }
                        }
                        for (int i = 0; i < teamsInGroup.Count; i++)
                        {
                            fixturesArray[i] = tempArray[i];
                        }
                    }
                }
                else if (teamsInGroup.Count % 2 == 1) 
                {                                             // Groups with odd number of teams
                    noFixtureRounds = (teamsInGroup.Count);
                    noMatchesPerRound = (teamsInGroup.Count / 2);
                    for (int fixtureRound = 0; fixtureRound < noFixtureRounds; fixtureRound++) 
                    {

                        for (int noMatches = 1; noMatches <= noMatchesPerRound; noMatches++) 
                        {
                            noMatchesGenerated++;
                            if (fixtureRound % 2 == 0) 
                            {
                                fixture = new Fixture(
                                    id: 0,
                                    competitionID : competition.ID ,
                                    groupID: group.ID,
                                    isLeagueFixture : true ,
                                    playingAreaID: playingArea.ID,
                                    name: "Match " + noMatchesGenerated.ToString(),
                                    startTime: fixtureStart,
                                    homeTeamID: ((Team)fixturesArray[(noMatches - 1) * 2]).ID,
                                    homeTeamScore: null,
                                    homeTeamPenaltiesScore: null,
                                    awayTeamID: ((Team)fixturesArray[(noMatches * 2) - 1]).ID,
                                    awayTeamScore: null,
                                    awayTeamPenaltiesScore: null,
                                    primaryOfficialID: null
                                );
                            }
                            else 
                            {
                                fixture = new Fixture(
                                    id: 0,
                                    competitionID : competition.ID ,
                                    groupID: group.ID,
                                    isLeagueFixture : true ,
                                    playingAreaID: playingArea.ID,
                                    name: "Match " + noMatchesGenerated.ToString(),
                                    startTime: fixtureStart,
                                    homeTeamID: ((Team)fixturesArray[(noMatches * 2) - 1]).ID,
                                    homeTeamScore: null,
                                    homeTeamPenaltiesScore: null,
                                    awayTeamID: ((Team)fixturesArray[(noMatches - 1) * 2]).ID,
                                    awayTeamScore: null,
                                    awayTeamPenaltiesScore: null,
                                    primaryOfficialID: null
                                );
                            }
                            iFixture.SQLInsert<Fixture>(fixture);
                            fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));

                        }
                        for (int i = 0; i < teamsInGroup.Count; i++)
                        {
                            if (i == 1) 
                            {
                                tempArray[i] = fixturesArray[i - 1];
                            }
                            if (i % 2 == 1 && i > 1)
                            {
                                tempArray[i] = fixturesArray[i - 2];
                            }
                            if (i % 2 == 0 && i < teamsInGroup.Count - 2)
                            {
                                tempArray[i] = fixturesArray[i + 2];
                            }
                            if (i == teamsInGroup.Count - 1)
                            {
                                tempArray[teamsInGroup.Count - 1] = fixturesArray[teamsInGroup.Count - 2];
                            }
                        }
                        for (int i = 0; i < teamsInGroup.Count; i++)
                        {
                            fixturesArray[i] = tempArray[i];
                        }
                    }

                }
                fixturesArray.RemoveRange(0, fixturesArray.Count);
                noMatchesGenerated = 0;

                //if (teamsInGroup.Count == 4) 
                //{
                //    AdjustFixtureTimesInGroupOfFour(group.ID);
                //}
                if (teamsInGroup.Count == 5) 
                {
                    AdjustToAvoidConsecutiveTeamFixtures(group.ID);
                }
            }
        }
        public DateTime GenerateFixturesForPlateQuarterFinals(Competition competition, DateTime fixtureStart)
        {
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            foreach (Group group in groupsList)
            {
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
            }
            Fixture fixture = new Fixture();
            IFixture iFixture = new Fixture();
            int pitchIndex = 0;
            int quarterFinal = 1;


            for (int i = 0; i < 4; i++)
            {
                if (pitchIndex == 0)
                {
                    fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
                }
                fixture = new Fixture(
                    id: 0,
                    competitionID: competition.ID,
                    groupID: null,
                    isLeagueFixture : false ,
                    playingAreaID: pitchesForCompetition[pitchIndex].ID ,
                    name: "Plate Quarter-Final " + quarterFinal.ToString(),
                    startTime: fixtureStart,
                    homeTeamID: null,
                    homeTeamScore: null,
                    homeTeamPenaltiesScore: null,
                    awayTeamID: null,
                    awayTeamScore: null,
                    awayTeamPenaltiesScore: null,
                    primaryOfficialID: null
                );
                iFixture.SQLInsert<Fixture>(fixture);
                quarterFinal++;
                pitchIndex++;
                if (pitchIndex > pitchesForCompetition.Count-1)
                {
                    pitchIndex = 0;
                }
            }
            return fixtureStart;
        }
        public DateTime GenerateFixturesForCupQuarterFinals(Competition competition, DateTime fixtureStart)
        {
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            foreach (Group group in groupsList)
            {
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
            }
            Fixture fixture = new Fixture();
            IFixture iFixture = new Fixture();
            int pitchIndex = 0;
            int quarterFinal = 1;

            for (int i = 0; i < 4; i++)
            {
                if (pitchIndex == 0)
                {
                    fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
                }
                fixture = new Fixture(
                    id: 0,
                    competitionID: competition.ID,
                    groupID: null,
                    isLeagueFixture : false ,
                    playingAreaID: pitchesForCompetition[pitchIndex].ID ,
                    name: "Cup Quarter-Final " + quarterFinal.ToString(),
                    startTime: fixtureStart,
                    homeTeamID: null,
                    homeTeamScore: null,
                    homeTeamPenaltiesScore: null,
                    awayTeamID: null,
                    awayTeamScore: null,
                    awayTeamPenaltiesScore: null,
                    primaryOfficialID: null
                );
                iFixture.SQLInsert<Fixture>(fixture);
                quarterFinal++;

                pitchIndex++;
                if (pitchIndex > pitchesForCompetition.Count-1)
                {
                    pitchIndex = 0;
                }
            }
            return fixtureStart;
        }       
        public DateTime GenerateFixturesForPlateSemiFinals(Competition competition, DateTime fixtureStart)
        {
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            foreach (Group group in groupsList)
            {
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
            }
            Fixture fixture = new Fixture();
            IFixture iFixture = new Fixture();
            int pitchIndex = 0;
            int semiFinal = 1;

            fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
            for (int i = 0; i < 2; i++)
            {
                fixture = new Fixture(
                    id: 0,
                    competitionID: competition.ID,
                    groupID: null,
                    isLeagueFixture : false ,
                    playingAreaID: pitchesForCompetition[pitchIndex].ID ,
                    name: "Plate Semi-Final " + semiFinal.ToString(),
                    startTime: fixtureStart,
                    homeTeamID: null,
                    homeTeamScore: null,
                    homeTeamPenaltiesScore: null,
                    awayTeamID: null,
                    awayTeamScore: null,
                    awayTeamPenaltiesScore: null,
                    primaryOfficialID: null
                );
                iFixture.SQLInsert<Fixture>(fixture);
                semiFinal++;
                if (groupsList.Count == 1) 
                {
                    fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
                }
                pitchIndex++;
                if (pitchIndex > pitchesForCompetition.Count-1)
                {
                    pitchIndex = 0;
                }
            }
            return fixtureStart;
        }
        public DateTime GenerateFixturesForCupSemiFinals(Competition competition, DateTime fixtureStart)
        {
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            foreach (Group group in groupsList)
            {
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
            }
            Fixture fixture = new Fixture();
            IFixture iFixture = new Fixture();
            int pitchIndex = 0;
            int semiFinal = 1;

            fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
            for (int i = 0; i < 2; i++)
            {
                fixture = new Fixture(
                    id: 0,
                    competitionID: competition.ID,
                    groupID: null,
                    isLeagueFixture: false,
                    playingAreaID: pitchesForCompetition[pitchIndex].ID,
                    name: "Cup Semi-Final " + semiFinal.ToString(),
                    startTime: fixtureStart,
                    homeTeamID: null,
                    homeTeamScore: null,
                    homeTeamPenaltiesScore: null,
                    awayTeamID: null,
                    awayTeamScore: null,
                    awayTeamPenaltiesScore: null,
                    primaryOfficialID: null
                );
                iFixture.SQLInsert<Fixture>(fixture);
                semiFinal++;
                if (groupsList.Count == 1)
                {
                    fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
                }
                pitchIndex++;
                if (pitchIndex > pitchesForCompetition.Count - 1)
                {
                    pitchIndex = 0;
                }
            }            
            return fixtureStart;
        }
        public DateTime GenerateFixtureForPlateFinal(Competition competition, DateTime fixtureStart)
        {
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            foreach (Group group in groupsList)
            {
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
            }
            Fixture fixture = new Fixture();
            IFixture iFixture = new Fixture();

            fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
            fixture = new Fixture(
                id: 0,
                competitionID: competition.ID,
                groupID: null,
                isLeagueFixture: false,
                playingAreaID: pitchesForCompetition[0].ID,
                name: "Plate Final",
                startTime: fixtureStart,
                homeTeamID: null,
                homeTeamScore: null,
                homeTeamPenaltiesScore: null,
                awayTeamID: null,
                awayTeamScore: null,
                awayTeamPenaltiesScore: null,
                primaryOfficialID: null
            );
            iFixture.SQLInsert<Fixture>(fixture);
            
            return fixtureStart;
        }     
        public DateTime GenerateFixtureForThirdPlace(Competition competition, DateTime fixtureStart)
        {
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            foreach (Group group in groupsList)
            {
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
            }
            Fixture fixture = new Fixture();
            IFixture iFixture = new Fixture();

            fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
            fixture = new Fixture(
                id: 0,
                competitionID: competition.ID,
                groupID: null,
                isLeagueFixture: false,
                playingAreaID: pitchesForCompetition[0].ID,
                name: "3rd Place Final",
                startTime: fixtureStart,
                homeTeamID: null,
                homeTeamScore: null,
                homeTeamPenaltiesScore: null,
                awayTeamID: null,
                awayTeamScore: null,
                awayTeamPenaltiesScore: null,
                primaryOfficialID: null
            );
            iFixture.SQLInsert<Fixture>(fixture);
            
            return fixtureStart;
        }
        public void GenerateFixtureForCupFinal(Competition competition, DateTime fixtureStart)
        {
            IGroup iGroup = new Group();
            List<Group> groupsList = iGroup.SQLSelectForCompetition(competition.ID);
            IGroupPlayingArea iGroupPlayingArea = new GroupPlayingArea();
            IPlayingArea iPlayingArea = new PlayingArea();
            List<PlayingArea> pitchesForCompetition = new List<PlayingArea>();
            foreach (Group group in groupsList)
            {
                GroupPlayingArea groupPlayingArea = iGroupPlayingArea.SQLGroupPlayingAreaForGroupID(group.ID);
                PlayingArea playingArea = iPlayingArea.SQLSelect<PlayingArea, int>(groupPlayingArea.PlayingAreaID);
                pitchesForCompetition.Add(playingArea);
            }
            Fixture fixture = new Fixture();
            IFixture iFixture = new Fixture();
            fixtureStart = fixtureStart.AddMinutes(EnumExtensions.GetIntValue(competition.FixtureTurnaround));
            fixture = new Fixture(
                id: 0,
                competitionID: competition.ID,
                groupID: null,
                isLeagueFixture: false,
                playingAreaID: pitchesForCompetition[0].ID,
                name: "Cup Final",
                startTime: fixtureStart,
                homeTeamID: null,
                homeTeamScore: null,
                homeTeamPenaltiesScore: null,
                awayTeamID: null,
                awayTeamScore: null,
                awayTeamPenaltiesScore: null,
                primaryOfficialID: null
            );
            iFixture.SQLInsert<Fixture>(fixture);
        }


        public static void AdjustToAvoidConsecutiveTeamFixtures(int groupID)
        {
            FixtureDbContext context = new FixtureDbContext();
			context.AdjustToAvoidConsecutiveTeamFixtures(groupID);
		}
		public static void AdjustFixtureTimesInGroupOfFour(int groupID)
        {
            FixtureDbContext context = new FixtureDbContext();
			context.AdjustFixtureTimesInGroupOfFour(groupID);
		}
		public void AdjustFixtureTurnaroundForGroup(int groupID, int fixtureTurnaround)
        {
            FixtureDbContext context = new FixtureDbContext();
            context.AdjustFixtureTurnaroundForGroup(groupID, fixtureTurnaround);
        }
        public void ReplaceCancelledTeamInFixtures(int targetTeamID, int replacementTeamID)
        {
            FixtureDbContext context = new FixtureDbContext();
            context.ReplaceCancelledTeamInFixtures(targetTeamID, replacementTeamID);
        }
        public void ReplaceFinalistTeamInFixtures(int targetTeamID, int replacementTeamID)
        {
            FixtureDbContext context = new FixtureDbContext();
            context.ReplaceFinalistTeamInFixtures(targetTeamID, replacementTeamID);
        }
		public void DeleteFixturesForCompetition(int competitionID)
        {
            FixtureDbContext context = new FixtureDbContext();
			context.DeleteFixturesForCompetition(competitionID);
		}

		public bool FixturesUnderway(Competition competition)
        {
			bool underway = false;
            FixtureDbContext context = new FixtureDbContext();
            int? completedFixtures = context.Fixtures.Where(i => i.CompetitionID == competition.ID && i.HomeTeamScore.HasValue && i.AwayTeamScore.HasValue).Count();
			if (completedFixtures.HasValue && completedFixtures > 0) 
            {
				underway = true;
			}
			return underway;
		}
		public bool FixtureCompleted(Competition competition, string fixtureName) 
        {
			bool completed = false;
            FixtureDbContext context = new FixtureDbContext();
			Fixture fixture = context.Fixtures.SingleOrDefault(i => i.CompetitionID == competition.ID && i.Name == fixtureName);
			if (fixture != null && fixture.HomeTeamScore != null && fixture.AwayTeamScore != null) 
            {
				completed = true;
			}
			return completed;
		}
		public bool AllLeagueFixturesCompleted(Competition competition) 
        {
			bool completed = false;
            FixtureDbContext context = new FixtureDbContext();
            int? leagueFixtures = context.Fixtures.Where(i => i.GroupID != null && i.CompetitionID == competition.ID).Count();
            int? completedFixtures = context.Fixtures.Where(i => i.GroupID != null && i.CompetitionID == competition.ID && i.HomeTeamScore.HasValue && i.AwayTeamScore.HasValue).Count();
			if (leagueFixtures == completedFixtures) 
            {
				completed = true;
			}
			return completed;
		}
		public bool AllLeagueFixturesCompleted(Group group)
        {
			bool completed = false;
            FixtureDbContext context = new FixtureDbContext();
            int? leagueFixtures = context.Fixtures.Where(i => i.GroupID == group.ID).Count();
            int? completedFixtures = context.Fixtures.Where(i => i.GroupID == group.ID && i.HomeTeamScore.HasValue && i.AwayTeamScore.HasValue).Count();
			if (leagueFixtures == completedFixtures)
            {
				completed = true;
			}
			return completed;
		}

		public void UpdateTeamInFixture(Competition competition, string fixtureName, Venue venue, int teamID) 
        {
			FixtureDbContext context = new FixtureDbContext();
			Fixture selected = context.Fixtures.Single(i => i.CompetitionID == competition.ID && i.Name == fixtureName);
			if (venue == Fixture.Venue.Home) 
            {
				selected.HomeTeamID = teamID;
			}
			else 
            {
				selected.AwayTeamID = teamID;
			}
			context.SaveChanges();
		}

		public string GetTeamNameFromPositionInGroup(int groupID, int position, Competition competition, string fixtureName, Venue venue) 
        {
			string teamName = "";
			ILeagueTable iLeagueTable = new LeagueTable();
			List<LeagueTable> leagueTable = new List<LeagueTable>();
			IClub iClub = new Club();
			ITeam iTeam = new Team();
			Team team = new Team();
			int teamID = 0;
			leagueTable = iLeagueTable.GetLeagueTableForGroup(groupID);
			teamID = leagueTable[position].TeamID;
			this.UpdateTeamInFixture(competition, fixtureName, venue, teamID);
			team = iTeam.SQLSelect<Team, int>(teamID);
			teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
			return teamName;
		}
        public string GetTeamNameForGroupWinnerInCompetition(int position, Competition competition, string fixtureName, Venue venue)
        {
            string teamName = "";
			ILeagueTable iLeagueTable = new LeagueTable();
			List<LeagueTable> leagueTable = new List<LeagueTable>();
			IClub iClub = new Club();
			ITeam iTeam = new Team();
			Team team = new Team();
			int teamID = 0;
			leagueTable = iLeagueTable.GetLeagueWinnersForCompetition(competition.ID);
			teamID = leagueTable[position].TeamID;
			this.UpdateTeamInFixture(competition, fixtureName, venue, teamID);
			team = iTeam.SQLSelect<Team, int>(teamID);
			teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
            return teamName;
        }

		public Team GetRunnersUpPositions(Competition competition, string position) 
        {

			Team ret = new Team();
			int noGroups = competition.CountGroupsForCompetition();
			IGroup iGroup = new Group();
			ILeagueTable iLeagueTable = new LeagueTable();
			List<Group> groupList = iGroup.SQLSelectForCompetition(competition.ID).OrderBy(i => i.Name).ToList();

			List<LeagueTable> leagueTable0 = iLeagueTable.GetLeagueTableForGroup(groupList[0].ID);
			List<LeagueTable> leagueTable1 = iLeagueTable.GetLeagueTableForGroup(groupList[1].ID);
			List<LeagueTable> leagueTable2 = iLeagueTable.GetLeagueTableForGroup(groupList[2].ID);

			if (position == "Best Runner-Up" || position == "2nd Best Runner-Up" || position == "3rd Best Runner-Up") 
            {

				List<LeagueTable> runnersUp = new List<LeagueTable>();
				Team bestRunnerUp = new Team();
				Team secondBestRunnerUp = new Team();
				Team thirdRunnerUp = new Team();
				runnersUp.Add(leagueTable0[1]);
				runnersUp.Add(leagueTable1[1]);
				runnersUp.Add(leagueTable2[1]);
				runnersUp = runnersUp.OrderByDescending(i => i.Points).ThenByDescending(i => (i.GoalsFor - i.GoalsAgainst)).ThenByDescending(i => i .GoalsFor).ToList();

				bestRunnerUp = runnersUp[0].Team;
				secondBestRunnerUp = runnersUp[1].Team;
				thirdRunnerUp = runnersUp[2].Team;

				if (position == "Best Runner-Up")
                {
					ret = bestRunnerUp;
				}
				else if (position == "2nd Best Runner-Up") 
                {
					ret = secondBestRunnerUp;
				}
				else if (position == "3rd Best Runner-Up")
                {
					ret = thirdRunnerUp;
				}

			}

			if (position == "Best 3rd Place" || position == "2nd Best 3rd Place")
            {

				List<LeagueTable> thirdPlace = new List<LeagueTable>();
				Team bestThirdPlace = new Team();
				Team secondBestThirdPlace = new Team();
				thirdPlace.Add(leagueTable0[2]);
				thirdPlace.Add(leagueTable1[2]);
				thirdPlace.Add(leagueTable2[2]);
				thirdPlace = thirdPlace.OrderByDescending(i => i.Points).ThenByDescending(i => (i.GoalsFor - i.GoalsAgainst)).ToList();

				bestThirdPlace = thirdPlace[0].Team;
				secondBestThirdPlace = thirdPlace[1].Team;

				if (position == "Best 3rd Place") 
                {
					ret = bestThirdPlace;
				}
				else if (position == "2nd Best 3rd Place") 
                {
					ret = secondBestThirdPlace;
				}

			}

			return ret;

		}
		public Team GetWinningTeamFromFixture(Competition competition, string fixtureName) 
        {
			FixtureDbContext context = new FixtureDbContext();
			Fixture fixture = context.Fixtures.Where(i => i.CompetitionID == competition.ID && i.Name == fixtureName).SingleOrDefault();
			ITeam iTeam = new Team();
			Team team = new Team();
			if (fixture.HomeTeamScore > fixture.AwayTeamScore)
            {
				team = iTeam.SQLSelect<Team, int>((int)fixture.HomeTeamID);
			}
			else if (fixture.AwayTeamScore > fixture.HomeTeamScore)
            {
				team = iTeam.SQLSelect<Team, int>((int)fixture.AwayTeamID);
			}
            else if (fixture.AwayTeamScore == fixture.HomeTeamScore)
            {
                if (fixture.HomeTeamPenaltiesScore > fixture.AwayTeamPenaltiesScore) 
                {
    				team = iTeam.SQLSelect<Team, int>((int)fixture.HomeTeamID);
                }
                else if (fixture.AwayTeamPenaltiesScore > fixture.HomeTeamPenaltiesScore) 
                {
    				team = iTeam.SQLSelect<Team, int>((int)fixture.AwayTeamID);
                }
            }
			return team;
		}
		public Team GetLosingTeamFromFixture(Competition competition, string fixtureName)
        {
			FixtureDbContext context = new FixtureDbContext();
			Fixture fixture = context.Fixtures.Where(i => i.CompetitionID == competition.ID && i.Name == fixtureName).SingleOrDefault();
			ITeam iTeam = new Team();
			Team team = new Team();
			if (fixture.HomeTeamScore > fixture.AwayTeamScore) 
            {
				team = iTeam.SQLSelect<Team, int>((int)fixture.AwayTeamID);
			}
			else if (fixture.AwayTeamScore > fixture.HomeTeamScore) 
            {
				team = iTeam.SQLSelect<Team, int>((int)fixture.HomeTeamID);
			}
            else if (fixture.AwayTeamScore == fixture.HomeTeamScore) 
            {
                if (fixture.HomeTeamPenaltiesScore > fixture.AwayTeamPenaltiesScore)
                {
    				team = iTeam.SQLSelect<Team, int>((int)fixture.AwayTeamID);
                }
                else if (fixture.AwayTeamPenaltiesScore > fixture.HomeTeamPenaltiesScore)
                {
    				team = iTeam.SQLSelect<Team, int>((int)fixture.HomeTeamID);
                }
            }
			return team;
		}

		public string GetTeamNameForFixture(Competition competition, string fixtureName, Venue venue) 
        {
			string teamName = "";

            if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromQuarterFinals)
            {
                if (fixtureName.Contains("Quarter-Final"))
                {
                    teamName = GetTeamNameForQuarterFinalFixture(competition, fixtureName, venue);
                }
                if (fixtureName.Contains("Semi-Final"))
                {
                    teamName = GetTeamNameForSemiFinalAfterQuarterFinalsFixture(competition, fixtureName, venue);
                }
                if (fixtureName.Contains("Plate Final") || fixtureName.Contains("Cup Final"))
                {
                    teamName = GetTeamNameForFinalFixture(competition, fixtureName, venue);
                } 
            }
            if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueCupAndPlateFromSemiFinals)
            {
                if (fixtureName.Contains("Semi-Final"))
                {
                    teamName = GetTeamNameForSemiFinalFixture(competition, fixtureName, venue);
                }
                if (fixtureName.Contains("Plate Final") || fixtureName.Contains("Cup Final"))
                {
                    teamName = GetTeamNameForFinalFixture(competition, fixtureName, venue);
                } 
            }
            if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCupWith3rdPlace)
            {
                if (fixtureName.Contains("Semi-Final"))
                {
                    teamName = GetTeamNameForSemiFinalFixture(competition, fixtureName, venue);
                }
                if (fixtureName.Contains("3rd Place"))
                {
                    teamName = GetTeamNameForThirdPlaceFixture(competition, fixtureName, venue);
                }
                if (fixtureName.Contains("Cup Final"))
                {
                    teamName = GetTeamNameForFinalFixture(competition, fixtureName, venue);
                } 
            }
            if (competition.CompetitionFormat == Competition.CompetitionFormats.LeagueAndCup)
            {
                if (fixtureName.Contains("Semi-Final"))
                {
                    teamName = GetTeamNameForSemiFinalFixture(competition, fixtureName, venue);
                }
                if (fixtureName.Contains("Cup Final"))
                {
                    teamName = GetTeamNameForFinalFixture(competition, fixtureName, venue);
                } 
            }
                   
            return teamName;
		}
        public string GetTeamNameForQuarterFinalFixture(Competition competition, string fixtureName, Venue venue) {
            #region local objects, interfaces and variables
            IGroup iGroup = new Group();
			IFixture iFixture = new Fixture();
			List<Group> groupList = iGroup.SQLSelectForCompetition(competition.ID).OrderBy(i => i.Name).ToList();
			IClub iClub = new Club();
			ITeam iTeam = new Team();
			Team team = new Team();
			string teamName = "";
			int noGroups = competition.CountGroupsForCompetition();
            #endregion
			switch (noGroups) 
            {
                case 2:

                    break;
                case 3:

                    break;
                case 4:
					if (fixtureName == "Plate Quarter-Final 1" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 2, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[0].Name + " 3rd Place";
						}
					}
					else if (fixtureName == "Plate Quarter-Final 1" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 3, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[1].Name + " 4th Place";
						}
					}
					else if (fixtureName == "Plate Quarter-Final 2" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 2, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[1].Name + " 3rd Place";
						}
					}
					else if (fixtureName == "Plate Quarter-Final 2" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 3, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[0].Name + " 4th Place";
						}
					}
					else if (fixtureName == "Plate Quarter-Final 3" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[2].ID, 2, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[2].Name + " 3rd Place";
						}
					}
					else if (fixtureName == "Plate Quarter-Final 3" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[3].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[3].ID, 3, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[3].Name + " 4th Place";
						}
					}
					else if (fixtureName == "Plate Quarter-Final 4" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[3].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[3].ID, 2, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[3].Name + " 3rd Place";
						}
					}
					else if (fixtureName == "Plate Quarter-Final 4" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[2].ID, 3, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[2].Name + " 4th Place";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 1" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 0, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[0].Name + " Winners";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 1" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 1, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[1].Name + " Runners Up";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 2" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 0, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[1].Name + " Winners";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 2" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 1, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[0].Name + " Runners Up";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 3" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[2].ID, 0, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[2].Name + " Winners";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 3" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[3].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[3].ID, 1, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[3].Name + " Runners Up";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 4" && venue == Venue.Home) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[3].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[3].ID, 0, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[3].Name + " Winners";
						}
					}
					else if (fixtureName == "Cup Quarter-Final 4" && venue == Venue.Away) 
                    {
						if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID))) 
                        {
							teamName = GetTeamNameFromPositionInGroup(groupList[2].ID, 1, competition, fixtureName, venue);
						}
						else 
                        {
							teamName = groupList[2].Name + " Runners Up";
						}
					}
                    break;
            }
            return teamName; 
        }
        public string GetTeamNameForSemiFinalAfterQuarterFinalsFixture(Competition competition, string fixtureName, Venue venue) {
            #region local objects, interfaces and variables
            IGroup iGroup = new Group();
			IFixture iFixture = new Fixture();
			List<Group> groupList = iGroup.SQLSelectForCompetition(competition.ID).OrderBy(i => i.Name).ToList();
			IClub iClub = new Club();
			ITeam iTeam = new Team();
			Team team = new Team();
			string teamName = "";
			int noGroups = competition.CountGroupsForCompetition();
            #endregion           
            switch (noGroups) 
            {
                case 1 : 

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
				    if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Home)
                    {
                        teamName = "Winner Plate Quarter-Final 1";
                        if (FixtureCompleted(competition, "Plate Quarter-Final 1"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Plate Quarter-Final 1");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Away)
                    {
                        teamName = "Winner Plate Quarter-Final 2";
                        if (FixtureCompleted(competition, "Plate Quarter-Final 2"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Plate Quarter-Final 2");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
				    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Home)
                    {
                        teamName = "Winner Plate Quarter-Final 3";
                        if (FixtureCompleted(competition, "Plate Quarter-Final 3"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Plate Quarter-Final 3");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
				    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Away)
                    {
                        teamName = "Winner Plate Quarter-Final 4";
                        if (FixtureCompleted(competition, "Plate Quarter-Final 4"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Plate Quarter-Final 4");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
				    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Home)
                    {
                        teamName = "Winner Cup Quarter-Final 1";
                        if (FixtureCompleted(competition, "Cup Quarter-Final 1"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Cup Quarter-Final 1");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Away)
                    {
                        teamName = "Winner Cup Quarter-Final 2";
                        if (FixtureCompleted(competition, "Cup Quarter-Final 2"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Cup Quarter-Final 2");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
				    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Home)
                    {
                        teamName = "Winner Cup Quarter-Final 3";
                        if (FixtureCompleted(competition, "Cup Quarter-Final 3"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Cup Quarter-Final 3");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Away)
                    {
                        teamName = "Winner Cup Quarter-Final 4";
                        if (FixtureCompleted(competition, "Cup Quarter-Final 4"))
                        {
                            team = GetWinningTeamFromFixture(competition, "Cup Quarter-Final 4");
                            if (team.ID != 0)
                            {
                                this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                                teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                            }
                        }
                    }
                    break;
            }

            return teamName;
        }       
        public string GetTeamNameForSemiFinalFixture(Competition competition, string fixtureName, Venue venue)
        {
            #region local objects, interfaces and variables
            IGroup iGroup = new Group();
			IFixture iFixture = new Fixture();
			List<Group> groupList = iGroup.SQLSelectForCompetition(competition.ID).OrderBy(i => i.Name).ToList();
			IClub iClub = new Club();
			ITeam iTeam = new Team();
			Team team = new Team();
			string teamName = "";
			int noGroups = competition.CountGroupsForCompetition();
            #endregion
            switch (noGroups)
            {
                case 1:
                    if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Group Winners";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 3, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "4th Place";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Runners-Up";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 2, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "3rd Place";
                        }
                    }
                    break;
                case 2:
                    if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 2, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "3rd Group 1";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 3, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "4th Group 2";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 3, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "4th Group 1";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 2, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "3rd Group 2";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 1";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Runner-Up Group 2";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 2";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Runner-Up Group 1";
                        }
                    }
                    break;
                case 3:
                    if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(competition))
                        {
                            team = GetRunnersUpPositions(competition, "2nd Best Runner-Up");
                            this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                            teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                        }
                        else
                        {
                            teamName = "2nd Best Runner-Up";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(competition))
                        {
                            team = GetRunnersUpPositions(competition, "3rd Best Runner-Up");
                            this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                            teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                        }
                        else
                        {
                            teamName = "3rd Best Runner-Up";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(competition))
                        {
                            team = GetRunnersUpPositions(competition, "Best 3rd Place");
                            this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                            teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                        }
                        else
                        {
                            teamName = "Best 3rd Place";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(competition))
                        {
                            team = GetRunnersUpPositions(competition, "2nd Best 3rd Place");
                            this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                            teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                        }
                        else
                        {
                            teamName = "2nd Best 3rd Place";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 1";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 2";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[2].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 3";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(competition))
                        {
                            team = GetRunnersUpPositions(competition, "Best Runner-Up");
                            this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                            teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                        }
                        else
                        {
                            teamName = "Best Runner-Up";
                        }
                    }
                    break;
                case 4:
                    if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Runner-Up Group 1";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Runner-Up Group 2";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[2].ID, 1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Runner-Up Group 3";
                        }
                    }
                    else if (fixtureName == "Plate Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[3].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[3].ID, 1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Runner-Up Group 4";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[0].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 1";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[1].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 2";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[2].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 3";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[3].ID)))
                        {
                            teamName = GetTeamNameFromPositionInGroup(groupList[3].ID, 0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Winner Group 4";
                        }
                    }
                    break;
                default:
                    if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[0].ID)))
                        {
                            teamName = GetTeamNameForGroupWinnerInCompetition(0, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "Best Group Winner";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 1" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[1].ID)))
                        {
                            teamName = GetTeamNameForGroupWinnerInCompetition(1, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "4th Best Group Winner";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Home)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[2].ID)))
                        {
                            teamName = GetTeamNameForGroupWinnerInCompetition(2, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "2nd Best Group Winner";
                        }
                    }
                    else if (fixtureName == "Cup Semi-Final 2" && venue == Venue.Away)
                    {
                        if (iFixture.AllLeagueFixturesCompleted(iGroup.SQLSelect<Group, int>(groupList[3].ID)))
                        {
                            teamName = GetTeamNameForGroupWinnerInCompetition(3, competition, fixtureName, venue);
                        }
                        else
                        {
                            teamName = "3rd Best Group Winner";
                        }
                    }
                    break;
                }

            return teamName;
        }
        public string GetTeamNameForThirdPlaceFixture(Competition competition, string fixtureName, Venue venue)
        {
            #region local objects, interfaces and variables
            IGroup iGroup = new Group();
			IFixture iFixture = new Fixture();
			List<Group> groupList = iGroup.SQLSelectForCompetition(competition.ID).OrderBy(i => i.Name).ToList();
			IClub iClub = new Club();
			ITeam iTeam = new Team();
			Team team = new Team();
			string teamName = "";
			int noGroups = competition.CountGroupsForCompetition();
            #endregion
            if (fixtureName == "3rd Place Final" && venue == Venue.Home)
            {
                teamName = "Loser Cup Semi-Final 1";
                if (FixtureCompleted(competition, "Cup Semi-Final 1"))
                {
                    team = GetLosingTeamFromFixture(competition, "Cup Semi-Final 1");
                    if (team.ID != 0)
                    {
                        this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                        teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                    }
                }
            }
            else if (fixtureName == "3rd Place Final" && venue == Venue.Away)
            {
                teamName = "Loser Cup Semi-Final 2";
                if (FixtureCompleted(competition, "Cup Semi-Final 2"))
                {
                    team = GetLosingTeamFromFixture(competition, "Cup Semi-Final 2");
                    if (team.ID != 0)
                    {
                        this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                        teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                    }
                }
            }
            return teamName;
        }
        public string GetTeamNameForFinalFixture(Competition competition, string fixtureName, Venue venue)
        {
            #region local objects, interfaces and variables
            IGroup iGroup = new Group();
			IFixture iFixture = new Fixture();
			List<Group> groupList = iGroup.SQLSelectForCompetition(competition.ID).OrderBy(i => i.Name).ToList();
			IClub iClub = new Club();
			ITeam iTeam = new Team();
			Team team = new Team();
			string teamName = "";
			int noGroups = competition.CountGroupsForCompetition();
            #endregion
            if (fixtureName == "Plate Final" && venue == Venue.Home)
            {
                teamName = "Winner Plate Semi-Final 1";
                if (FixtureCompleted(competition, "Plate Semi-Final 1"))
                {
                    team = GetWinningTeamFromFixture(competition, "Plate Semi-Final 1");
                    if (team.ID != 0)
                    {
                        this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                        teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                    }
                }
            }
            else if (fixtureName == "Plate Final" && venue == Venue.Away)
            {
                teamName = "Winner Plate Semi-Final 2";
                if (FixtureCompleted(competition, "Plate Semi-Final 2"))
                {
                    team = GetWinningTeamFromFixture(competition, "Plate Semi-Final 2");
                    if (team.ID != 0)
                    {
                        this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                        teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                    }
                }
            }
            else if (fixtureName == "Cup Final" && venue == Venue.Home)
            {
                teamName = "Winner Cup Semi-Final 1";
                if (FixtureCompleted(competition, "Cup Semi-Final 1"))
                {
                    team = GetWinningTeamFromFixture(competition, "Cup Semi-Final 1");
                    if (team.ID != 0)
                    {
                        this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                        teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                    }
                }
            }
            else if (fixtureName == "Cup Final" && venue == Venue.Away)
            {
                teamName = "Winner Cup Semi-Final 2";
                if (FixtureCompleted(competition, "Cup Semi-Final 2"))
                {
                    team = GetWinningTeamFromFixture(competition, "Cup Semi-Final 2");
                    if (team.ID != 0)
                    {
                        this.UpdateTeamInFixture(competition, fixtureName, venue, team.ID);
                        teamName = iClub.SQLSelect<Club, int>(team.ClubID).Name + " " + team.Name;
                    }
                }
            }
            return teamName;
        }
		#endregion Methods

    }

    public interface IFixture : ISQLInsertable, ISQLSelectable
    {
        int ID { get; }
		int? CompetitionID { get; }
        int? GroupID { get; }
		bool? IsLeagueFixture { get; }
        int? PlayingAreaID { get; }
        string Name { get; }
        DateTime? StartTime { get; }
        int? HomeTeamID { get; }
        Team HomeTeam { get; }
        int? HomeTeamScore { get; }
        int? HomeTeamPenaltiesScore { get; }
        int? AwayTeamID { get; }
        Team AwayTeam { get; }
        int? AwayTeamScore { get; }
        int? AwayTeamPenaltiesScore { get; }
        int? PrimaryOfficialID { get; }
        Contact PrimaryOfficial { get; }
		void SQLUpdateScores(Fixture fixture);
        void SQLUpdatePenaltyScores(Fixture fixture);
        List<Fixture> SQLSelectForGroup(int groupID);
		List<Fixture> SQLSelectFinalsForCompetition(int competitionID);
        List<Fixture> SQLSelectForCompetition(int competitionID);
		List<Fixture> SQLSelectForPlayingArea(int playingAreaID);
		List<Fixture> SQLSelectForPlayingArea(int playingAreaID, DateTime scheduledDay);
        List<Fixture> GetSearchFixturesForTournament(int tournamentID, Competition competition, Fixture.OrderListBy orderBy, GoTournamental.BLL.Organiser.Contact contact, Club club, Team team);
		void GenerateFixturesForCompetition(Tournament tournament, Competition competition);
        void AdjustFixtureTurnaroundForGroup(int groupID, int fixtureTurnaround);
        void ReplaceCancelledTeamInFixtures(int targetTeamID, int replacementTeamID);
        void ReplaceFinalistTeamInFixtures(int targetTeamID, int replacementTeamID);
		void DeleteFixturesForCompetition(int competitionID);
		bool FixturesUnderway(Competition competition);
		DateTime? GetLastLeagueFixtureTimeForCompetition(int competitionID);
		bool AllLeagueFixturesCompleted(Competition competition);
		bool AllLeagueFixturesCompleted(Group group);
		string GetTeamNameForFixture(Competition competition, string fixtureName, Fixture.Venue venue);
    }

}