using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser {

    public class PlayingArea: IPlayingArea {

		#region Constructors
        public PlayingArea() { }
        public PlayingArea(int id, int tournamentID, string name) {
			this.ID = id;
			this.TournamentID = tournamentID;
			this.Name = name;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public string Name { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) {
            if (ObjectExtensions.ObjectTypesMatch<PlayingArea, T>(input)) {
                PlayingAreaDbContext context = new PlayingAreaDbContext();
                context.PlayingAreas.Add((PlayingArea)(object)input);
                context.SaveChanges();
            }
        }
        public T SQLSelect<T, U>(U id) {
            PlayingAreaDbContext context = new PlayingAreaDbContext();
            PlayingArea selected = context.PlayingAreas.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }        
		public List<PlayingArea> SQLSelectForTournament(int tournamentID) {
            PlayingAreaDbContext context = new PlayingAreaDbContext();
            List<PlayingArea> selectedList = context.PlayingAreas.Where(i => i.TournamentID == tournamentID).OrderBy(i => i.Name).ToList();
            return selectedList;
        }
		public List<PlayingArea> SQLSelectForTournamentDay(int tournamentID, DateTime eventDay) {
            PlayingAreaDbContext context = new PlayingAreaDbContext();
            List<PlayingArea> selectedList = context.PlayingAreas.Where(i => i.TournamentID == tournamentID).OrderBy(i => i.Name).ToList();
            return selectedList;
        }
		public List<PlayingArea> SQLSelectInUseForTournamentSession(int tournamentID, int competitionID) {
			PlayingAreaDbContext context = new PlayingAreaDbContext();
			List<PlayingArea> selectedList = context.GetPlayingAreasInUseForTournamentSession(tournamentID, competitionID).ToList();
			return selectedList;
		}		
		public string GetPlayingAreaName(int playingAreaID) {
			string ret = "";
			PlayingAreaDbContext context = new PlayingAreaDbContext();
            PlayingArea playingArea = context.PlayingAreas.Where(i => i.ID == playingAreaID).SingleOrDefault();
			ret = playingArea.Name;
			return ret;
		}		
		#endregion

    }

    public interface IPlayingArea: ISQLInsertable, ISQLSelectable {
        int ID { get; }
        int TournamentID { get; }
        string Name { get; }
		List<PlayingArea> SQLSelectForTournament(int tournamentID);
		List<PlayingArea> SQLSelectForTournamentDay(int tournamentID, DateTime eventDay);
		List<PlayingArea> SQLSelectInUseForTournamentSession(int tournamentID, int competitionID);
		string GetPlayingAreaName(int playingAreaID);
    }

}