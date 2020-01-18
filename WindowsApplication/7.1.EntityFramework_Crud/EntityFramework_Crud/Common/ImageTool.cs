using System.Drawing;                                                                           //包含绘图对象；
using System.IO;                                                                                //包含输入输出对象；

namespace EntityFramework_Crud
{

	/// <summary>
	/// 图像工具；
	/// </summary>
	public static class ImageTool
    {

        /// <summary>
        /// 获取字节；
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>字节数组</returns>
        public static byte[] GetBytes(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);   //声明并实例化文件流，用于从指定的文件路径打开并读取文件；
            byte[] bytes = new byte[fileStream.Length];                                         //声明并实例化字节数组，数组长度对应文件流长度；
            fileStream.Read(bytes, 0, bytes.Length);                                            //文件流将文件内容读入字节数组；
            return bytes;                                                                       //返回字节数组；
        }

        /// <summary>
        /// 获取图像；
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>图像</returns>
        public static Image GetImage(byte[] bytes)
        {
            Image image = null;                                                                 //声明图像，并指向空值；
            if (bytes != null)                                                                  //若字节数组非空；
            {
                MemoryStream memoryStream = new MemoryStream(bytes);                            //声明并实例化内存流，用于读取字节数组；
                image = Image.FromStream(memoryStream);                                         //调用图像的静态方法FromStream从内存流中读取图像；
            }
            return image;                                                                       //返回图像；
        }
    }
}
