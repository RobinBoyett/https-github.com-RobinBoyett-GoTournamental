using System;
using System.Xml;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.Helpers;
using GoTournamental.API.Interface;
using GoTournamental.API.Utilities;
using GoTournamental.BLL.Organiser;

namespace GoTournamental.API.Cryptography {

	public class GoTournamentalCryptography {

		#region Methods

		public static string TournamentPassword() {
			string password = Crypto.Hash("P4!3Sg4t3").Substring(0,8);
			return password;			
		}
		public static string TournamentPassword(int tournamentID) {
			string password = "";
			ITournament iTournament = new Tournament();
			Tournament tournament = iTournament.SQLSelect<Tournament, int>(tournamentID);
			password = Crypto.Hash(tournament.Name + "P4!3Sg4t3").Substring(0,8);
			return password;			
		}





		public static string Encrypt(string unencryptedText, string password) {
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			byte[] plainText = System.Text.Encoding.Unicode.GetBytes(unencryptedText);
			byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
			PasswordDeriveBytes secretKey = new PasswordDeriveBytes(password, salt);
			ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
			cryptoStream.Write(plainText, 0, plainText.Length);
			cryptoStream.FlushFinalBlock();
			byte[] cipherBytes = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			string EncryptedData = Convert.ToBase64String(cipherBytes);
			return EncryptedData;
		}

		public static string Decrypt(string encryptedText, string password) {
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			string decryptedData;
			try {
				byte[] encryptedData = Convert.FromBase64String(encryptedText);
				byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
				PasswordDeriveBytes secretKey = new PasswordDeriveBytes(password, salt);
				ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
				MemoryStream memoryStream = new MemoryStream(encryptedData);
				CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
				byte[] plainText = new byte[encryptedData.Length];
				int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
				memoryStream.Close();
				cryptoStream.Close();
				decryptedData = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
			}
			catch {
				decryptedData = encryptedText;
			}
			return decryptedData;
		}
		#endregion

	}

}