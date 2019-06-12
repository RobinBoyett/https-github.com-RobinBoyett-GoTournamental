using System.ComponentModel;

namespace GoTournamental.BLL.Organiser 
{

    public class TrophyRequirement: ITrophyRequirement 
    {

        #region Member Enumerations
        public enum AwardTypes 
        {
            Undefined = 0,
            [DescriptionAttribute("Player: Participation")] PlayerParticipation = 1,
            [DescriptionAttribute("Player: Winner")] PlayerWinner = 2,
            [DescriptionAttribute("Player: Runner-Up")] PlayerRunnerUp = 3,
            [DescriptionAttribute("Team: Winner")] TeamWinner = 4,
            [DescriptionAttribute("Team: Runner-Up")] RunnerUp = 5
        }
        public enum TrophyTypes 
        {
            Undefined = 0,
            [DescriptionAttribute("Not Required")] NotRequired = 1,
            Medal = 2,
            Cup = 3,
            Trophy = 4,
            Salver = 5
        }		
        #endregion

        #region Constructors
        public TrophyRequirement() { }
        public TrophyRequirement(int id, int competitionID, AwardTypes awardType, TrophyTypes trophyType, int? numberRequired, string engraving) 
        {
			this.ID = id;
            this.CompetitionID = competitionID;
            this.AwardType = awardType;
            this.TrophyType = trophyType;
            this.NumberRequired = numberRequired;
            this.Engraving = engraving;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int CompetitionID { get; set; }
        public AwardTypes AwardType { get; set; }
        public TrophyTypes TrophyType { get; set; }
        public int? NumberRequired { get; set; }
        public string Engraving { get; set; }
        #endregion

        #region Methods



		#endregion

    }

    public interface ITrophyRequirement  
    {
        int ID { get; }
        int CompetitionID { get; }
        TrophyRequirement.AwardTypes AwardType { get; }
        TrophyRequirement.TrophyTypes TrophyType { get; }
        int? NumberRequired { get; }
        string Engraving { get; }
	}

}