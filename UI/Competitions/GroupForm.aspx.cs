using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class GroupForm : Page {

        #region Declare Domain Objects & Page Variables
 		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        IGroup iGroup = new Group();
        Group group = new Group();
        ICompetition iCompetition = new Competition();
        Competition competition = new Competition();
        IFixture iFixture = new Fixture();
        #endregion
        #region Declare Page Controls
		Label groupTitle = new Label();
        DropDownList fixtureTurnaround = new DropDownList();
		Button saveButton = new Button();
		#endregion

        protected void Page_Load(object sender, EventArgs e) {
            AssignControlsAll();
            AssignDomainObjects();
            GroupEditFormLoad();
        }
		protected void AssignControlsAll() {
			groupTitle = (Label)GroupFormPanel.FindControl("GroupTitle");
            fixtureTurnaround = (DropDownList)GroupFormPanel.FindControl("FixtureTurnaround");
			saveButton = (Button)GroupFormPanel.FindControl("SaveButton");
        }
        protected void AssignDomainObjects() {
            if (Request.QueryString.Get("TournamentID") != null) {
	            tournament = iTournament.SQLSelect<Tournament, int>(Int32.Parse(Request.QueryString.Get("TournamentID")));
            }
            if (Request.QueryString.Get("GroupID") != null) {
	            group = iGroup.SQLSelect<Group, int>(Int32.Parse(Request.QueryString.Get("GroupID")));
                competition = iCompetition.SQLSelect<Competition, int>(group.CompetitionID);
            }
        }

        protected void GroupEditFormLoad() {
			groupTitle.Text = group.Name;
			Array fixtureTurnaroundEnum = Enum.GetValues(typeof(Tournament.FixtureTurnarounds));
            if (fixtureTurnaround.Items.Count < 2) {
                foreach (Enum type in fixtureTurnaroundEnum) {
                    if (EnumExtensions.GetIntValue(type) > 0) {
                        fixtureTurnaround.Items.Add(new ListItem(EnumExtensions.GetIntValue(type).ToString(), EnumExtensions.GetIntValue(type).ToString()));
                    }
                }
            }
            if (!IsPostBack) {
                if (group.FixtureTurnaround != Tournament.FixtureTurnarounds.Undefined) {
                    fixtureTurnaround.SelectedValue = EnumExtensions.GetIntValue(group.FixtureTurnaround).ToString();
                }
                else {
			        fixtureTurnaround.SelectedValue = EnumExtensions.GetIntValue(competition.FixtureTurnaround).ToString();
                }
            }
		}
        
		protected void SaveButton_Click(object sender, EventArgs e) {
            if (identityHelper.ClaimExistsForUser(HttpContext.Current.User.Identity.GetUserId(), "TournamentID", tournament.ID.ToString())) {
                if (fixtureTurnaround.SelectedValue != "0") {
                    iGroup.SQLUpdateFixtureTurnaround(group.ID, (Tournament.FixtureTurnarounds)Int32.Parse(fixtureTurnaround.SelectedValue));
                    iFixture.AdjustFixtureTurnaroundForGroup(group.ID, Int32.Parse(fixtureTurnaround.SelectedValue));
                }
            }
            Response.Redirect("~/UI/Competitions/CompetitionView?TournamentID=" + tournament.ID.ToString() + "&competition_id=" + competition.ID.ToString());
        }

    }

}

