using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GoTournamental.API.Utilities;
using GoTournamental.API.Identity;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.UI.Organiser {

    public partial class AdministrativeTasksList : Page {

        #region Declare Domain Objects & Page Variables
		GoTournamentalIdentityHelper identityHelper = new GoTournamentalIdentityHelper();
        Tournament tournament = new Tournament();
        ITournament iTournament = new Tournament();
        Array enumTaskStatuses = Enum.GetValues(typeof(AdministrativeTask.TaskStatuses));
        #endregion

        #region Declare page controls
		AdvertPanel advert300x600 = new AdvertPanel();
		TournamentMenu tournamentMenu = new TournamentMenu();
		SetUpMenu setUpMenu = new SetUpMenu();
		#endregion
		
        protected void Page_Load(object sender, EventArgs e) {

            AssignControlsAll();

            ParticipationTasksListLoad();
            FacilitiesTasksListLoad();
            CommunicationsTasksListLoad();
            SafetyTasksListLoad();

			advert300x600.graphicFileStyle = Advert.GraphicFileStyles.Advert300By600;
			advert300x600.tournamentID = tournament.ID;

        }

		protected void AssignControlsAll() {
            advert300x600 = (AdvertPanel)AdministrativeTasksListPanel.FindControl("Advert300x600");
		}

        protected void ParticipationTasksListLoad() {
            Array enumValues = Enum.GetValues(typeof(AdministrativeTask.ParticipationTaskTypes));
            ParticipationTasksList.DataSource = enumValues;
            ParticipationTasksList.DataBind();
        }
        protected void ParticipationTasksList_ItemDataBound(object sender, DataListItemEventArgs e) {
            AdministrativeTask.ParticipationTaskTypes taskTypes = (AdministrativeTask.ParticipationTaskTypes)e.Item.DataItem;
            Label participationTaskLabel = (Label)e.Item.FindControl("ParticipationTaskLabel");
            HiddenField participationTaskID = (HiddenField)e.Item.FindControl("ParticipationTaskID");
            DropDownList participationTaskStatus = (DropDownList)e.Item.FindControl("ParticipationTaskStatus");

            if (taskTypes != AdministrativeTask.ParticipationTaskTypes.Undefined) {
                participationTaskLabel.Text = EnumExtensions.GetStringValue(taskTypes);
                participationTaskID.Value = EnumExtensions.GetIntValue(taskTypes).ToString();
                foreach (Enum status in enumTaskStatuses) {
                    if (EnumExtensions.GetIntValue(status) > 0) {
                        participationTaskStatus.Items.Add(new ListItem(EnumExtensions.GetStringValue(status).ToString(), EnumExtensions.GetIntValue(status).ToString()));
                    }
                }
            }
            else {
                participationTaskStatus.Visible = false;
            }
        }

        protected void FacilitiesTasksListLoad() {
            Array enumValues = Enum.GetValues(typeof(AdministrativeTask.FacilitiesTaskTypes));
            FacilitiesTasksList.DataSource = enumValues;
            FacilitiesTasksList.DataBind();
        }
        protected void FacilitiesTasksList_ItemDataBound(object sender, DataListItemEventArgs e) {
            AdministrativeTask.FacilitiesTaskTypes taskTypes = (AdministrativeTask.FacilitiesTaskTypes)e.Item.DataItem;
            Label facilitiesTaskLabel = (Label)e.Item.FindControl("FacilitiesTaskLabel");
            HiddenField facilitiesTaskID = (HiddenField)e.Item.FindControl("FacilitiesTaskID");
            DropDownList facilitiesTaskStatus = (DropDownList)e.Item.FindControl("FacilitiesTaskStatus");
 
            if (taskTypes != AdministrativeTask.FacilitiesTaskTypes.Undefined) {
                facilitiesTaskLabel.Text = EnumExtensions.GetStringValue(taskTypes);
                facilitiesTaskID.Value = EnumExtensions.GetIntValue(taskTypes).ToString();
                foreach (Enum status in enumTaskStatuses) {
                    if (EnumExtensions.GetIntValue(status) > 0) {
                        facilitiesTaskStatus.Items.Add(new ListItem(EnumExtensions.GetStringValue(status).ToString(), EnumExtensions.GetIntValue(status).ToString()));
                    }
                }
            }
            else {
                facilitiesTaskStatus.Visible = false;
            }
        }

        protected void CommunicationsTasksListLoad() {
            Array enumValues = Enum.GetValues(typeof(AdministrativeTask.CommunicationTaskTypes));
            CommunicationsTasksList.DataSource = enumValues;
            CommunicationsTasksList.DataBind();
        }
        protected void CommunicationsTasksList_ItemDataBound(object sender, DataListItemEventArgs e) {
            AdministrativeTask.CommunicationTaskTypes taskTypes = (AdministrativeTask.CommunicationTaskTypes)e.Item.DataItem;
            Label communicationsTaskLabel = (Label)e.Item.FindControl("CommunicationsTaskLabel");
            HiddenField communicationsTaskID = (HiddenField)e.Item.FindControl("CommunicationsTaskID");
            DropDownList communicationsTaskStatus = (DropDownList)e.Item.FindControl("CommunicationsTaskStatus");
 
            if (taskTypes != AdministrativeTask.CommunicationTaskTypes.Undefined) {
                communicationsTaskLabel.Text = EnumExtensions.GetStringValue(taskTypes);
                communicationsTaskID.Value = EnumExtensions.GetIntValue(taskTypes).ToString();
                foreach (Enum status in enumTaskStatuses) {
                    if (EnumExtensions.GetIntValue(status) > 0) {
                        communicationsTaskStatus.Items.Add(new ListItem(EnumExtensions.GetStringValue(status).ToString(), EnumExtensions.GetIntValue(status).ToString()));
                    }
                }
            }
            else {
                communicationsTaskStatus.Visible = false;
            }
        }

        protected void SafetyTasksListLoad() {
            Array enumValues = Enum.GetValues(typeof(AdministrativeTask.SafetyTaskTypes));
            SafetyTasksList.DataSource = enumValues;
            SafetyTasksList.DataBind();
        }
        protected void SafetyTasksList_ItemDataBound(object sender, DataListItemEventArgs e) {
            AdministrativeTask.SafetyTaskTypes taskTypes = (AdministrativeTask.SafetyTaskTypes)e.Item.DataItem;
            Label safetyTaskLabel = (Label)e.Item.FindControl("SafetyTaskLabel");
            HiddenField safetyTaskID = (HiddenField)e.Item.FindControl("SafetyTaskID");
            DropDownList safetyTaskStatus = (DropDownList)e.Item.FindControl("SafetyTaskStatus");

            if (taskTypes != AdministrativeTask.SafetyTaskTypes.Undefined) {
                safetyTaskLabel.Text = EnumExtensions.GetStringValue(taskTypes);
                safetyTaskID.Value = EnumExtensions.GetIntValue(taskTypes).ToString();
                foreach (Enum status in enumTaskStatuses) {
                    if (EnumExtensions.GetIntValue(status) > 0) {
                        safetyTaskStatus.Items.Add(new ListItem(EnumExtensions.GetStringValue(status).ToString(), EnumExtensions.GetIntValue(status).ToString()));
                    }
                }
            }
            else {
                safetyTaskStatus.Visible = false;
            }
        }
        
	}

}



