using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SmartLinli.DatabaseDevelopement
{
	/// <summary>
	/// 图像助手；
	/// </summary>
	public class ImageHelper
	{
		/// <summary>
		/// 获取图像；
		/// </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>图像</returns>
		public static Image GetImage(string fileName)
		=>	Image.FromFile(fileName);
		/// <summary>
		/// 获取图像；
		/// </summary>
		/// <param name="imageBytes">图像所在的字节数组</param>
		/// <returns>图像</returns>
		public static Image GetImage(byte[] imageBytes)
		{
			Image image = null;
			if (imageBytes != null)
			{
				MemoryStream memoryStream = new MemoryStream(imageBytes);
				image = Image.FromStream(memoryStream);
			}
			return image;
		}
		/// <summary>
		/// 获取图像；
		/// </summary>
		/// <param name="imageBytes">图像所在的字节数组</param>
		/// <returns>图像</returns>
		public static Image GetImage(object imageBytes)
		{
			Image image = null;
			if (imageBytes is byte[] bytes)
			{
				image = GetImage(bytes);
			}
			return image;
		}
		/// <summary>
		/// 获取字节数组
		/// </summary>
		/// <param name="image">图像</param>
		/// <returns>字节数组</returns>
		public static byte[] GetBytes(Image image)
		{
			MemoryStream memoryStream = new MemoryStream();
			image.Save(memoryStream, ImageFormat.Bmp);
			byte[] imageBytes = new byte[memoryStream.Length];
			memoryStream.Seek(0, SeekOrigin.Begin);
			memoryStream.Read(imageBytes, 0, imageBytes.Length);
			return imageBytes;
		}
	}
}
