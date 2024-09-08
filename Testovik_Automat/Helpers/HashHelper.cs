using System.Security.Cryptography;
using System.Text;

namespace Testovik_Automat.Helpers
{
	public static class HashHelper
	{
		public static string Hash(string password)
		{
			MD5 MD5Hash = MD5.Create(); 
			byte[] inputBytes = Encoding.ASCII.GetBytes(password); 
			byte[] hash = MD5Hash.ComputeHash(inputBytes);

			return Convert.ToHexString(hash);
		}
	}
}
