using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using GoTournamental.API;
using GoTournamental.API.Utilities;
using GoTournamental.API.Interface;
using GoTournamental.ORM.Organiser;

namespace GoTournamental.BLL.Organiser 
{

    public class Advert: IAdvert 
    {

		#region Member Enumerations & Collections
		public enum GraphicFileStyles
        {
            Undefined = 0,
            [DescriptionAttribute("Advert 300(w) By 250(h) Pixels")] Advert300By250 = 1,
            [DescriptionAttribute("Advert 300(w) By 600(h) Pixels")] Advert300By600 = 2,
            [DescriptionAttribute("Advert 120(w) By 600(h) Pixels")] Advert120By600 = 3,
            [DescriptionAttribute("Advert 728(w) By 90(h) Pixels")] Advert728By90 = 4
        }
		public enum DisplayWeighting
        {
            Undefined = 0
        }

		#endregion

		#region Constructors
		public Advert() {}
		public Advert(int id, int advertiserID, string graphicFileName, Domains.GraphicFileTypes graphicFileType, GraphicFileStyles graphicStyle, int? clicksThrough) 
        {
			this.ID = id;
			this.AdvertiserID = advertiserID;
			this.GraphicFileName = graphicFileName;
			this.GraphicFileType = graphicFileType;
			this.GraphicStyle = graphicStyle;
			this.ClicksThrough = clicksThrough;
		}
        #endregion

        #region Properties
        public int ID { get; set; }
        public int AdvertiserID { get; set; }
		public string GraphicFileName { get; set; }
		public Domains.GraphicFileTypes GraphicFileType { get; set; }
		public GraphicFileStyles GraphicStyle { get; set; }
        public string GraphicFilePath 
        {
            get 
            {
                IAdvertiser iAdvertiser = new Advertiser();
                Advertiser advertiser = new Advertiser();
                advertiser = iAdvertiser.SQLSelect<Advertiser, int>(this.AdvertiserID);
                string filePath = "";
                if (advertiser != null && advertiser.TournamentID != null && advertiser.TournamentID != 0)
                {
                    filePath = "~/Uploads/Tournament" + advertiser.TournamentID.ToString() + "/Adverts/" + this.GraphicFileName + EnumExtensions.GetStringValue(GraphicFileType);
                }
                else
                {
                    filePath = "~/Uploads/GT/Adverts/" + this.GraphicFileName + EnumExtensions.GetStringValue(GraphicFileType);
                }
				return filePath;
            }
        }
        public int? ClicksThrough { get; set; }
        #endregion

        #region Methods
        public void SQLInsert<T>(T input)
        {
            if (ObjectExtensions.ObjectTypesMatch<Advert, T>(input))
            {
                AdvertDbContext context = new AdvertDbContext();
                Advert existing = context.Adverts.Where(i => i.AdvertiserID == ((Advert)(object)input).AdvertiserID && i.GraphicStyle == ((Advert)(object)input).GraphicStyle).SingleOrDefault();
                if (existing == null) 
                {
                    context.Adverts.Add((Advert)(object)input);
                    context.SaveChanges();
                }
            }
        }
        public T SQLSelect<T, U>(U id)
        {
            AdvertDbContext context = new AdvertDbContext();
            Advert selected = context.Adverts.Where(i => i.ID == (int)(object)id).SingleOrDefault();
            return (T)(object)selected;
        }
		public Advert GetAdvert(GraphicFileStyles graphicFileStyle, int tournamentID) 
        {
			AdvertDbContext context = new AdvertDbContext();
			List<Advert> adverts = new List<Advert>();
			Advert advert = new Advert();
			if (tournamentID == 0)
            {
				adverts = context.GetAdvertsForGoTournamental().Where(i => i.GraphicFileName != null && i.GraphicStyle == graphicFileStyle).ToList();
			}
			else
            {
				adverts = context.GetAdvertsForTournament(tournamentID).Where(i => i.GraphicFileName != null && i.GraphicStyle == graphicFileStyle).ToList();
			}
			if (adverts.Count > 0)
            {
				Random r = new Random();
				int index = r.Next(0, adverts.Count);
				advert = adverts[index];
			}
			return advert;
        }
 		public List<Advert> GetAdvertsForTournament(int tournamentID) 
        {
            AdvertDbContext context = new AdvertDbContext();
            List<Advert> selectedList = context.GetAdvertsForTournament(tournamentID).ToList();
            return selectedList;
        }   	
		public void AddClickThrough(int id) 
        {
			int? currentValue = null;
            AdvertDbContext context = new AdvertDbContext();
            Advert selected = context.Adverts.Single(i => i.ID == id);
			currentValue = selected.ClicksThrough;
			if (currentValue == null) 
            {
				selected.ClicksThrough = 1;
			}
			else 
            {
				selected.ClicksThrough = selected.ClicksThrough + 1;
			}
            context.SaveChanges();
        }	
		#endregion

    }
    public interface IAdvert: ISQLInsertable, ISQLSelectable 
    {
        int ID { get; }
		int AdvertiserID { get; }
		string GraphicFileName { get; }
		Domains.GraphicFileTypes GraphicFileType { get; }
		Advert.GraphicFileStyles GraphicStyle { get; }
		string GraphicFilePath { get; }
		int? ClicksThrough { get; }
		Advert GetAdvert(Advert.GraphicFileStyles graphicFileStyle, int tournamentID);
		List<Advert> GetAdvertsForTournament(int tournamentID);
		void AddClickThrough(int id);
    }

}