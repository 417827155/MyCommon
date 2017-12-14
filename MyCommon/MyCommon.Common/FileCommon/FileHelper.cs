using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCommon.Common.FileCommon
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 根据给出的相对地址获取网站绝对地址
        /// </summary>
        /// <param name="localPath">相对地址</param>
        /// <returns>绝对地址</returns>
        public static string GetWebPath(string localPath)
        {
            string path = HttpContext.Current.Request.ApplicationPath;
            string thisPath;
            string thisLocalPath;
            //如果不是根目录就加上"/" 根目录自己会加"/"
            if (path != "/")
            {
                thisPath = path + "/";
            }
            else
            {
                thisPath = path;
            }
            if (localPath.StartsWith("~/"))
            {
                thisLocalPath = localPath.Substring(2);
            }
            else
            {
                return localPath;
            }
            return thisPath + thisLocalPath;
        }

        /// <summary>
        ///  获取网站绝对地址
        /// </summary>
        /// <returns></returns>
        public static string GetWebPath()
        {
            string path = HttpContext.Current.Request.ApplicationPath;
            string thisPath;
            //如果不是根目录就加上"/" 根目录自己会加"/"
            if (path != "/")
            {
                thisPath = path + "/";
            }
            else
            {
                thisPath = path;
            }
            return thisPath;
        }

        /// <summary>
        /// 根据相对路径或绝对路径获取绝对路径
        /// </summary>
        /// <param name="localPath">相对路径或绝对路径</param>
        /// <returns>绝对路径</returns>
        public static string GetFilePath(string localPath)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(localPath, @"([A-Za-z]):\\([\S]*)"))
            {
                return localPath;
            }
            else
            {
                return HttpContext.Current.Server.MapPath(localPath);
            }
        }

        /// <summary>
		/// 检查文件是否真实存在。
		/// </summary>
		/// <param name="path">文件全名（包括路径）。</param>
		/// <returns>Boolean</returns>
		public static bool IsFileExists(string path)
        {
            try
            {
                return File.Exists(path);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
		/// 检查目录是否真实存在。
		/// </summary>
		/// <param name="path">目录路径.</param>
		/// <returns>Boolean</returns>
		public static bool IsDirectoryExists(string path)
        {
            try
            {
                return Directory.Exists(Path.GetDirectoryName(path));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>Boolean</returns>
        public static bool CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
		/// 查找文件中是否存在匹配行。
		/// </summary>
		/// <param name="fi">目标文件.</param>
		/// <param name="lineText">要查找的行文本.</param>
		/// <param name="lowerUpper">是否区分大小写.</param>
		/// <returns>Boolean</returns>
		public static bool FindLineTextFromFile(FileInfo fi, string lineText, bool lowerUpper)
        {
            bool b = false;
            try
            {
                if (fi.Exists)
                {
                    StreamReader sr = new StreamReader(fi.FullName);
                    string g = "";
                    do
                    {
                        g = sr.ReadLine();
                        if (lowerUpper)
                        {
                            if (Null2Str(g).Trim() == Null2Str(lineText).Trim())
                            {
                                b = true;
                                break;
                            }
                        }
                        else
                        {
                            if (Null2Str(g).Trim().ToLower() == Null2Str(lineText).Trim().ToLower())
                            {
                                b = true;
                                break;
                            }
                        }
                    }
                    while (sr.Peek() != -1);
                    sr.Close();
                }
            }
            catch
            { b = false; }
            return b;
        }

        #region 私有方法
        private static string Null2Str(string value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                return value;
            }
        }
        #endregion
    }
}
