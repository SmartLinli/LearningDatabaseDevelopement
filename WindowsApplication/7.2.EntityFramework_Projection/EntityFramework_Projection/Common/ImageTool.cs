using System.Drawing;                                                                          
using System.IO;                                                                               

namespace EntityFramework_Projection
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
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);  
            byte[] bytes = new byte[fileStream.Length];                                        
            fileStream.Read(bytes, 0, bytes.Length);                                           
            return bytes;                                                                      
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
