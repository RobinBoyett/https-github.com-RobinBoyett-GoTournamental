using System;
using System.Web;
using System.Collections.Specialized;
using System.ComponentModel;

namespace GoTournamental.API {

	public abstract class Domains {

        #region Member Enumerations & Collections
		public enum FAAffiliations {
			Undefined = 0,
			EnglishFA = 1
		}		
		public enum EnglishCountyFAs {
			Undefined = 0,
			[DescriptionAttribute("Amateur Football Alliance")] AmateurFootballAlliance = 1, 
			Army = 2,
			Bedfordshire = 3, 
			[DescriptionAttribute("Berks & Bucks")] BerksBucks = 4, 
			Birmingham = 5, 
			Cambridgeshire = 6, 
			[DescriptionAttribute("Cambridge University")] CambridgeUniversity = 7, 
			Cheshire = 8,
			Cornwall = 9, 
			Cumberland = 10, 
			Derbyshire = 11, 
			Devon = 12, 
			Dorset = 13, 
			Durham = 14,
			[DescriptionAttribute("East Riding")] EastRiding = 15,
			[DescriptionAttribute("English Schools")] EnglishSchools = 16, 
			Essex = 17, 
			Gloucestershire = 18,
			Guernsey = 19, 
			Hampshire = 20, 
			Herefordshire = 21, 
			Hertfordshire = 22, 
			Huntingdonshire = 23, 
			[DescriptionAttribute("Independent Schools")] IndependentSchools = 24, 
			[DescriptionAttribute("Isle of Man")] IsleofMan = 25,
			Jersey = 26, 
			Kent = 27, 
			Lancashire = 28, 
			[DescriptionAttribute("Leicestershire & Rutland")] LeicestershireRutland = 29, 
			Lincolnshire = 30, 
			Liverpool = 31, 
			London = 32,
			Manchester = 33,
			Middlesex = 34, 
			Norfolk = 35, 
			Northamptonshire = 36, 
			[DescriptionAttribute("North Riding")] NorthRiding = 37, 
			Northumberland = 38, 
			Nottinghamshire = 39, 
			Oxfordshire = 40, 
			[DescriptionAttribute("Oxford University")] OxfordUniversity = 41,
			[DescriptionAttribute("Royal Air Force")] RoyalAirForce = 42, 
			[DescriptionAttribute("Royal Navy")] RoyalNavy = 43,
			[DescriptionAttribute("Sheffield & Hallamshire")] SheffieldHallamshire = 44,
			Shropshire = 45, 
			Somerset = 46, 
			Staffordshire = 47, 
			Suffolk = 48, 
			Surrey = 49, 
			Sussex = 50, 
			Westmorland = 51, 
			[DescriptionAttribute("West Riding")] WestRiding = 52, 
			Wiltshire = 53, 
			Worcestershire = 54
 		}
        public enum AttendanceTypes {
            Undefined = 0,
            [DescriptionAttribute("Tournament Hosts")] HostClub = 1,
            Pending = 2,
			Invited = 3,
            Accepted = 4,
            Attending = 5,
            Declined = 6,
            Cancelled = 7,
            Reserve = 8,
            Deleted = 9
        }
		public enum KitColours {
			Undefined = 0,
			White = 1,
			Maroon = 2,
			Red = 3,
			Orange = 4,
			Gold = 5,
			Yellow = 6,
			Lime = 7,
			Green = 8,
			SkyBlue = 9,
			Blue = 10,
			MidnightBlue = 11,
			Black = 12
		}
		public enum NumberOfParticipants {
			Undefined = 0,
			One = 1,
			Two = 2,
			Three = 3,
			Four = 4,
			Five = 5,
			Six = 6,
			Seven = 7,
			Eight = 8,
			Nine = 9,
			Ten = 10,
			Eleven = 11,
			Twelve = 12,
			Thirteen = 13,
			Fourteen = 14,
			Fifteen = 15,
			Sixteen = 16,
			Seventeen = 17,
			Eighteen = 18,
			Nineteen = 19,
			Twenty = 20,
			TwentyOne = 21,
			TwentyTwo = 22,
			TwentyThree = 23,
			TwentyFour = 24
		}
		public enum GraphicFileTypes {
            Undefined = 0,
            [DescriptionAttribute(".png")] PNG = 1,
            [DescriptionAttribute(".jpg")] JPEG = 2,
	        [DescriptionAttribute(".gif")] GIF = 3
        }
		public enum GraphicFileClasses {
            Undefined = 0,
            [DescriptionAttribute("Club Logo")] ClubLogo = 1
        }
		#endregion

		#region Methods
		public static string XMLFilePathForDomain(string domainName) {
			string xmlFilePath = "";
			switch(domainName) {
				case "Colours":
					xmlFilePath = HttpContext.Current.Server.MapPath(@"~/App_Code/API/Domains/Colours.xml");
					break;
			}
			return xmlFilePath;
		}	
		#endregion

	}

}
