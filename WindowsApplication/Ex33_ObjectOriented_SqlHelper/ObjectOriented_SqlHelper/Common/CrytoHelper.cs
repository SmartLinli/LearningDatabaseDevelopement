using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace ObjectOriented_SqlHelper
{
	/// <summary>
	/// 加密助手；
	/// </summary>
	public class CrytoHelper
	{
		/// <summary>
		/// MD5加密；
		/// </summary>
		/// <param name="plainText">明文</param>
		/// <returns>密文</returns>
		public static byte[] Md5(string plainText)
		{
			byte[] plainBytes = Encoding.Default.GetBytes(plainText);
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] cryptedBytes = md5.ComputeHash(plainBytes);
			return cryptedBytes;
		}
		/// <summary>
		/// MD5值是否相等；
		/// </summary>
		/// <param name="md5">MD5值</param>
		/// <param name="otherPlainText">另一明文</param>
		/// <returns>是否相等</returns>
		public static bool Md5Equal(byte[] md5, string otherPlainText) 
		=>	md5.SequenceEqual(Md5(otherPlainText));
	}
}
