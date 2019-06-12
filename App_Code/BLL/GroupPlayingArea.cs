using System.Linq;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser 
{

    public class GroupPlayingArea: IGroupPlayingArea 
    {

		#region Constructors
        public GroupPlayingArea() { }
        public GroupPlayingArea(int id, int groupID, int playingAreaID) 
        {
			this.ID = id;
			this.GroupID = groupID;
			this.PlayingAreaID = playingAreaID;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int GroupID { get; set; }
        public int PlayingAreaID { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<GroupPlayingArea, T>(input)) 
            {
                GroupPlayingAreaDbContext context = new GroupPlayingAreaDbContext();
                context.GroupPlayingAreas.Add((GroupPlayingArea)(object)input);
                context.SaveChanges();
            }
        }
        public GroupPlayingArea SQLGroupPlayingAreaForGroupID(int id) 
        {
            GroupPlayingArea team = new GroupPlayingArea();
            GroupPlayingAreaDbContext context = new GroupPlayingAreaDbContext();
            team = context.GroupPlayingAreas.Where(i => i.GroupID == id).SingleOrDefault();
            return team;
        }     

        #endregion

    }

    public interface IGroupPlayingArea: ISQLInsertable
    {
        int ID { get; }
        int GroupID { get; }
        int PlayingAreaID { get; }
		GroupPlayingArea SQLGroupPlayingAreaForGroupID(int id);
    }

}