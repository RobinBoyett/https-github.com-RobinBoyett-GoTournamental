using System;
using System.IO;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Globalization;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;

namespace GoTournamental.API.Utilities {

	#region System Extensions
	public static partial class ListExtensions {
		public static List<T> RandomiseGenericList<T>(IList<T> inputList) {
			List<T> randomisedList = new List<T>();
			Random random = new Random();
			T value = default(T);
			while (inputList.Count > 0) {
				var nextIndex = random.Next(0, inputList.Count);
				value = inputList[nextIndex];
				randomisedList.Add(value);
				inputList.RemoveAt(nextIndex);
			}
			return randomisedList;
		}
	}
	public static partial class ObjectExtensions {
		public static bool ObjectTypesMatch<U, T>(T input) {
			bool isCorrect = false;
			Type inputType = input.GetType();
			if (inputType.Equals(typeof(U))) {
				isCorrect = true;
			}
			return isCorrect;
		}
	}
    public static partial class DateTimeExtensions {
        public static DateTime FirstDayOfCalendarYear(this DateTime inputDate) {
            return new DateTime(inputDate.Year, 1, 1);
        }
        public static DateTime FirstDayOfCalendarYear(this int inputYear) {
            return new DateTime(inputYear, 1, 1);
        }
        public static DateTime LastDayOfCalendarYear(this DateTime inputDate) {
            return inputDate.FirstDayOfCalendarYear().AddYears(1).AddDays(-1);
        }
        public static DateTime LastDayOfCalendarYear(this int inputYear) {
            return FirstDayOfCalendarYear(inputYear).AddYears(1).AddDays(-1);
        }
        public static DateTime FirstDayOfFinancialYear(this DateTime inputDate) {
            if (inputDate.Month <= 4)
                return new DateTime(inputDate.Year - 1, 5, 1);
            else
                return new DateTime(inputDate.Year, 5, 1);
        }
        public static DateTime FirstDayOfFinancialYear(this int inputYear) {
            return new DateTime(inputYear - 1, 5, 1);
        }
        public static DateTime LastDayOfFinancialYear(this DateTime inputDate) {
            return inputDate.FirstDayOfFinancialYear().AddYears(1).AddDays(-1);
        }
        public static DateTime LastDayOfFinancialYear(this int inputYear) {
            return new DateTime(inputYear, 4, 30);
        }
        public static DateTime FirstDayOfMonth(this DateTime inputDate) {
            return new DateTime(inputDate.Year, inputDate.Month, 1);
        }
        public static DateTime LastDayOfMonth(this DateTime inputDate) {
            return inputDate.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }
        public static DateTime AddWeeks(this DateTime inputDate, int weeks) {
            return inputDate.AddDays(7 * weeks);
        }
        public static string LongDateWithLongDay(this DateTime inputDate) {
            string ret = "";
            ret = inputDate.DayOfWeek.ToString() + " " + inputDate.Day.ToString() + " " + ShortMonthText(inputDate.Month) + " " + inputDate.Year.ToString();
            return ret;
        }
        public static string LongDateWithShortDay(this DateTime inputDate) {
            string ret = "";
            ret = inputDate.DayOfWeek.ToString().Substring(0, 3) + " " + inputDate.Day.ToString() + " " + ShortMonthText(inputDate.Month) + " " + inputDate.Year.ToString();
            return ret;
        }       
		public static string TimeHoursAndMinutes(this DateTime inputDate) {
            string ret = "";
            string hourText = inputDate.Hour.ToString();
            string minuteText = inputDate.Minute.ToString();
            if (hourText.Length == 1) {
                hourText = "0" + hourText;
            }
            if (minuteText.Length == 1) {
                minuteText = "0" + minuteText;
            }
            ret = hourText + ":" + minuteText;
            return ret;
        }
        public static string ShortMonthText(int month) {
            string ret = "";
            switch (month) {
                case 1:
                    ret = "Jan";
                    break;
                case 2:
                    ret = "Feb";
                    break;
                case 3:
                    ret = "Mar";
                    break;
                case 4:
                    ret = "Apr";
                    break;
                case 5:
                    ret = "May";
                    break;
                case 6:
                    ret = "Jun";
                    break;
                case 7:
                    ret = "Jul";
                    break;
                case 8:
                    ret = "Aug";
                    break;
                case 9:
                    ret = "Sep";
                    break;
                case 10:
                    ret = "Oct";
                    break;
                case 11:
                    ret = "Nov";
                    break;
                case 12:
                    ret = "Dec";
                    break;
            }
            return ret;
        }
        public static string LongMonthText(int month) {
            string ret = "";
            switch (month) {
                case 1:
                    ret = "January";
                    break;
                case 2:
                    ret = "February";
                    break;
                case 3:
                    ret = "March";
                    break;
                case 4:
                    ret = "April";
                    break;
                case 5:
                    ret = "May";
                    break;
                case 6:
                    ret = "June";
                    break;
                case 7:
                    ret = "July";
                    break;
                case 8:
                    ret = "August";
                    break;
                case 9:
                    ret = "September";
                    break;
                case 10:
                    ret = "October";
                    break;
                case 11:
                    ret = "November";
                    break;
                case 12:
                    ret = "December";
                    break;
            }
            return ret;
        }
        public static string FormatDateRange(DateTime inputDate1, DateTime inputDate2) {
            string ret = "";
            ret = String.Format("{0:MMMM d}", inputDate1) + " - " + String.Format("{0:MMMM d}", inputDate2) + " " + inputDate1.Year.ToString();
            return ret;
        }        
        public static int IntFromLongMonth(string month) {
            int ret = 0;
            switch (month) {
                case "January":
                    ret = 1;
                    break;
                case "February":
                    ret = 2;
                    break;
                case "March":
                    ret = 3;
                    break;
                case "April":
                    ret = 4;
                    break;
                case "May":
                    ret = 5;
                    break;
                case "June":
                    ret = 6;
                    break;
                case "July":
                    ret = 7;
                    break;
                case "August":
                    ret = 8;
                    break;
                case "September":
                    ret = 9;
                    break;
                case "October":
                    ret = 10;
                    break;
                case "November":
                    ret = 11;
                    break;
                case "December":
                    ret = 12;
                    break;
            }
            return ret;
        }
        public static int DayOfWeek(this DateTime inputDate) {
            int ret = 0;
            switch (inputDate.DayOfWeek.ToString()) {
                case "Sunday":
                    ret = 0;
                    break;
                case "Monday":
                    ret = 1;
                    break;
                case "Tuesday":
                    ret = 2;
                    break;
                case "Wednesday":
                    ret = 3;
                    break;
                case "Thursday":
                    ret = 4;
                    break;
                case "Friday":
                    ret = 5;
                    break;
                case "Saturday":
                    ret = 6;
                    break;
            }
            return ret;
        }
        public static int DaysInYear(this DateTime inputDate) {
            return (inputDate.LastDayOfCalendarYear() - inputDate.FirstDayOfCalendarYear()).Days + 1;
        }
        public static bool IsLeapYear(this DateTime inputDate) {
            return inputDate.DaysInYear() == 366;
        }
        public static StringCollection DaysOfWeek() {
            StringCollection daysOfWeek = new StringCollection();
            daysOfWeek.AddRange(DateTimeFormatInfo.CurrentInfo.DayNames);
            return daysOfWeek;
        }
        public static StringCollection MonthsOfYear() {
            StringCollection monthsOfYear = new StringCollection();
            monthsOfYear.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames);
            if (monthsOfYear.Contains("")) {
                monthsOfYear.Remove("");
            }
            return monthsOfYear;
        }
    }     
    public static partial class EnumExtensions {
        public static int GetIntValue(Enum value) {
            int enumIndex = (int)Enum.Parse(value.GetType(), value.ToString());
            return enumIndex;
        }
        public static string GetStringValue(Enum value) {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
		public static  T GetEnumValue<T>(string str) where T : struct, IConvertible {
			Type enumType = typeof(T);
			if (!enumType.IsEnum) {
				throw new Exception("T must be an Enumeration type.");
			}
			T val;
			return Enum.TryParse<T>(str, true, out val) ? val : default(T);
		}		
		public static T GetValueFromDescription<T>(string description) {
			var type = typeof(T);
			if(!type.IsEnum) throw new InvalidOperationException();
			foreach(var field in type.GetFields()) {
				var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
				if(attribute != null) {
					if(attribute.Description == description)
						return (T)field.GetValue(null);
				}
				else {
					if(field.Name == description)
						return (T)field.GetValue(null);
				}
			}
            throw new ArgumentException("Not found.", "description");
		}	
	}
	public static partial class IOExtensions { 
		public enum TimeUnits {
			Seconds = 0,
			Minutes = 1,
			Hours = 2,
			Days = 4
		}
		public static void DeleteExistingFile(string filePath) {
			if (File.Exists(filePath)) {
				File.Delete(filePath);
			}
		}
		public static void DeleteExistingFile(string filePath, string fileName) {
			if (File.Exists(filePath + fileName)) {
				File.Delete(filePath + Path.GetFileName(fileName));
			}
		}
		public static void DeleteAgedFilesInDirectory(string tempDirectory, TimeUnits ageUnits, int fileAge) {
			if (Directory.Exists(tempDirectory)) {
				string[] files = Directory.GetFiles(tempDirectory);
				foreach (string s in files) {
					DateTime fileLastAccessed = File.GetLastAccessTime(tempDirectory+Path.GetFileName(s));
					if (ageUnits == TimeUnits.Seconds && fileLastAccessed.AddSeconds(fileAge) < DateTime.Now) {
						File.Delete(tempDirectory+Path.GetFileName(s));
					}
					if (ageUnits == TimeUnits.Minutes && fileLastAccessed.AddMinutes(fileAge) < DateTime.Now) {
						File.Delete(tempDirectory+Path.GetFileName(s));
					}
					if (ageUnits == TimeUnits.Hours && fileLastAccessed.AddHours(fileAge) < DateTime.Now) {
						File.Delete(tempDirectory+Path.GetFileName(s));
					}
					if (ageUnits == TimeUnits.Days && fileLastAccessed.AddDays(fileAge) < DateTime.Now) {
						File.Delete(tempDirectory+Path.GetFileName(s));
					}
				}
			}
		}
		public static void CopyFile(string targetFileWithPath, string copiedFileWithPath) {
			if (!File.Exists(copiedFileWithPath)) {
				File.Copy(targetFileWithPath, copiedFileWithPath);
			}
		}
		public static bool DirectoryContainsFiles(string filePath) {
			bool containsFiles = false;
			containsFiles = (Directory.GetFiles(filePath).Length > 0) ? true : false;
			return containsFiles;
		}
	}	
	#endregion

    #region Utility Classes
	public abstract class ParseUtility {
		private delegate T ParseDelegate<T>(string s);
		private static Nullable<T> ParseNullable<T>(string s, ParseDelegate<T> parse) where T : struct {
			if (string.IsNullOrEmpty(s)) {
				return null;
			}
			else {
				return parse(s);
			}
		}
		public static int? ParseNullableInt(string s) {
			return ParseNullable<int>(s, int.Parse);
		}
		public static DateTime? ParseNullableDateTime(string s) {
			return ParseNullable<DateTime>(s, DateTime.Parse);
		}
		public static DateTime? TryParseNullableDateTime(string s) {
			DateTime value;
			return DateTime.TryParse(s, out value) ? value : (DateTime?) null;
		}
		public static bool? ParseNullableBoolean(string s) {
			return ParseNullable<bool>(s, Boolean.Parse);
		}
	}
    public abstract class DocumentWriter {
        public static void WriteDataIntoExcel(string input) {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Test.xls");
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.Write(input);
            HttpContext.Current.Response.End();
        }
    }
    #endregion

    #region UI Extensions
    public partial class DropDownListExtensions {
        public static void BindToXMLDomain(DropDownList ddList, string xmlFilePath, string dataTextField, string dateValueField) {
            if (File.Exists(xmlFilePath)) {
                using (DataSet ds = new DataSet()) {
                    ds.ReadXml(xmlFilePath);
                    ddList.DataSource = ds;
                    ddList.DataTextField = dataTextField;
                    ddList.DataValueField = dateValueField;
                    ddList.DataBind();  
                }
            }
        }
    }
	public static partial class ImageExtensions {
		public static System.Drawing.Image RescaleImage(System.Drawing.Image image, int reqHeight) {
			var ratio = (double)reqHeight / image.Height;
			var newWidth = (int)(image.Width * ratio);
			var newHeight = (int)(image.Height * ratio);
			var newImage = new Bitmap(newWidth, newHeight);
			using (var g = Graphics.FromImage(newImage)) {
				g.DrawImage(image, 0, 0, newWidth, newHeight);
			}
			return newImage;
		}
		public static System.Drawing.Image RescaleImage(System.Drawing.Image image, int reqHeight, int reqWidth) {
			var newImage = new Bitmap(reqWidth, reqHeight);
			using (var g = Graphics.FromImage(newImage)) {
				g.DrawImage(image, 0, 0, reqWidth, reqHeight);
			}
			return newImage;
		}	
	}    	
	#endregion

}


