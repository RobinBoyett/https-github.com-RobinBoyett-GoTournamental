using System;
using System.Linq;
using System.Collections.Generic;
using GoTournamental.API.Utilities;
using GoTournamental.API.Interface;
using GoTournamental.ORM.Planner;

namespace GoTournamental.BLL.Planner 
{

    public class ToolTip: IToolTip
    {

		#region Constructors
		public ToolTip() {}
 		public ToolTip(int id, string webPage, string controlID, string toolTipText, string userID, DateTime dateModified) 
        {
			this.ID = id;
            this.WebPage = webPage;
            this.ControlID = controlID;
            this.ToolTipText = toolTipText;
            this.UserID = userID;
            this.DateModified = dateModified;
		}
		#endregion

        #region Properties
        public int ID { get; set; }
        public string WebPage { get; set; }
        public string ControlID { get; set; }
        public string ToolTipText { get; set; }
        public string UserID { get; set; }
        public DateTime DateModified { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<ToolTip, T>(input))
            {
                ToolTipDbContext context = new ToolTipDbContext();
                context.ToolTips.Add((ToolTip)(object)input);
                context.SaveChanges();
            }
        }
        public T SQLSelect<T, U>(U id)
        {
            ToolTipDbContext context = new ToolTipDbContext();
            ToolTip selected = context.ToolTips.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }
        public List<ToolTip> SQLSelectForWebPage(string webPage) 
        {
            ToolTipDbContext context = new ToolTipDbContext();
            List<ToolTip> selectedList = context.ToolTips.Where(i => i.WebPage == webPage).OrderBy(i => i.ID).ToList();
            return selectedList;
        }
		public void SQLUpdate<T>(T input)
        {
            if (ObjectExtensions.ObjectTypesMatch<ToolTip, T>(input)) 
            {
                ToolTipDbContext context = new ToolTipDbContext();
                ToolTip updated = (ToolTip)(object)input;
                ToolTip selected = context.ToolTips.Single(i => i.ID == updated.ID);
                selected.WebPage = updated.WebPage;
                selected.ControlID = updated.ControlID;
				selected.ToolTipText = updated.ToolTipText;
                selected.UserID = updated.UserID;
                context.SaveChanges();
            }
        }  
        public void SQLDelete<T>(T input) 
        {
            if (ObjectExtensions.ObjectTypesMatch<ToolTip, T>(input))
            {
                ToolTipDbContext context = new ToolTipDbContext();
                ToolTip itemToDelete = (ToolTip)(object)input;
                ToolTip selected = context.ToolTips.Single(i => i.ID == itemToDelete.ID);
                context.ToolTips.Remove(selected);
                context.SaveChanges();
            }
        } 
		#endregion

    }
    public interface IToolTip : ISQLInsertable, ISQLSelectable, ISQLDeletable 
    {
        int ID { get; }
        string WebPage { get; }
        string ControlID { get; }
        string ToolTipText { get; }
        string UserID { get; }
        DateTime DateModified { get; }
        List<ToolTip> SQLSelectForWebPage(string webPage);
	}

}