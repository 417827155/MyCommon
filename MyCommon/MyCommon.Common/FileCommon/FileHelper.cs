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
        #region 路径
        /// <summary>
        /// 根据相对路径或绝对路径获取绝对路径
        /// e.g.E:\张嵩\myself\MyCommon\MyCommon\MyCommon.Web\Home 
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
        #endregion

        #region 文件、文件夹
        /// <summary>
        /// 检查文件是否真实存在。
        /// </summary>
        /// <param name="path">文件全名（包括路径）。</param>
        /// <returns>Boolean</returns>
        public static bool IsExistFile(string path)
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
		public static bool IsExistDirectory(string path)
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
        /// 删除文件夹
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>Boolean</returns>
        public static bool DeleteDirectory(string path)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.Delete(path);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除文件夹及子文件
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns>Boolean</returns>
        public static bool DeleteDirectoryAll(string path)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.Delete(path,true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取指定目录中文件
        /// </summary>
        /// <param name="directoryPath">绝对路径</param>
        /// <returns></returns>
        public static string[] GetFileNames(string directoryPath)
        {
            try
            {
                if (!IsExistDirectory(directoryPath))
                {
                    throw new FileNotFoundException();
                }
                return Directory.GetFiles(directoryPath);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取指定目录中所有子目录
        /// </summary>
        /// <param name="directoryPath">绝对路径</param>
        /// <returns></returns>
        public static string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取指定目录及子目录中所有文件列表
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>
        /// <param name="isSearchChild">是否搜索子目录</param>
        public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            //如果目录不存在，则抛出异常
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            try
            {
                if (isSearchChild)
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检测指定目录是否为空
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>        
        public static bool IsEmptyDirectory(string directoryPath)
        {
            try
            {
                //判断是否存在文件
                string[] fileNames = GetFileNames(directoryPath);
                if (fileNames.Length > 0)
                {
                    return false;
                }

                //判断是否存在文件夹
                string[] directoryNames = GetDirectories(directoryPath);
                if (directoryNames.Length > 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //这里记录日志
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 检测指定目录中是否存在指定的文件,若要搜索子目录请使用重载方法.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>        
        public static bool Contains(string directoryPath, string searchPattern)
        {
            try
            {
                //获取指定的文件列表
                string[] fileNames = GetFileNames(directoryPath, searchPattern, false);

                //判断指定文件是否存在
                if (fileNames.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检测指定目录中是否存在指定的文件
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param> 
        /// <param name="isSearchChild">是否搜索子目录</param>
        public static bool Contains(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                //获取指定的文件列表
                string[] fileNames = GetFileNames(directoryPath, searchPattern, true);

                //判断指定文件是否存在
                if (fileNames.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file">路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string file)
        {
            try
            {
                if (IsExistFile(file))
                {
                    File.Delete(file);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="dir">路径</param>
        /// <param name="filename">文件名</param>
        /// <param name="filestr">文件内容</param>
        /// <returns></returns>
        public static bool CreateFile(string dir,string filename,string filestr)
        {
            try
            {
                if (IsExistDirectory(dir))
                {
                    StreamWriter sw = new StreamWriter(dir + "/" + filename,false,Encoding.GetEncoding("GB2312"));
                    sw.Write(filestr);
                    sw.Close();
                }
                else
                {
                    CreateDirectory(dir);
                    StreamWriter sw = new StreamWriter(dir + "/" + filename, false, Encoding.GetEncoding("GB2312"));
                    sw.Write(filestr);
                    sw.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="sourceFile">源文件路径</param>
        /// <param name="targetDir">目标文件目录</param>
        /// <param name="targetFile">目标文件名</param>
        /// <returns></returns>
        public static bool MoveFile(string sourceFile,string targetDir,string targetFile)
        {
            try
            {
                if (IsExistFile(sourceFile))
                {
                    if (!IsExistDirectory(targetDir))
                    {
                        CreateDirectory(targetDir);
                    }
                    File.Move(sourceFile,targetDir + targetFile);
                    return true;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourceFile">源文件路径</param>
        /// <param name="targetDir">目标文件目录</param>
        /// <param name="targetFile">目标文件名</param>
        /// <returns></returns>
        public static bool CopyFile(string sourceFile, string targetDir, string targetFile)
        {
            try
            {
                if (IsExistFile(sourceFile))
                {
                    if (!IsExistDirectory(targetDir))
                    {
                        CreateDirectory(targetDir);
                    }
                    File.Copy(sourceFile, targetDir + targetFile);
                    return true;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 复制文件夹(递归)
        /// </summary>
        /// <param name="sourceDir">源文件夹路径</param>
        /// <param name="targetDir">目标文件夹路径</param>
        public static bool CopyFolder(string sourceDir, string targetDir)
        {
            try
            {
                Directory.CreateDirectory(targetDir);

                if (!IsExistDirectory(sourceDir))
                {
                    throw new IOException();
                }

                string[] directories = Directory.GetDirectories(sourceDir);

                if (directories.Length > 0)
                {
                    foreach (string d in directories)
                    {
                        CopyFolder(d, targetDir + d.Substring(d.LastIndexOf("\\")));
                    }
                }
                string[] files = Directory.GetFiles(sourceDir);
                if (files.Length > 0)
                {
                    foreach (string s in files)
                    {
                        File.Copy(s, targetDir + s.Substring(s.LastIndexOf("\\")), true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 删除指定文件夹对应其他文件夹里的文件
        /// </summary>
        /// <param name="varFromDirectory">指定文件夹路径</param>
        /// <param name="targetDir">对应其他文件夹路径</param>
        public static bool DeleteFolderFiles(string sourceDir, string targetDir)
        {
            try
            {
                Directory.CreateDirectory(targetDir);

                if (!IsExistDirectory(sourceDir))
                {
                    throw new IOException();
                }

                string[] directories = Directory.GetDirectories(sourceDir);

                if (directories.Length > 0)
                {
                    foreach (string d in directories)
                    {
                        DeleteFolderFiles(d, targetDir + d.Substring(d.LastIndexOf("\\")));
                    }
                }


                string[] files = Directory.GetFiles(sourceDir);

                if (files.Length > 0)
                {
                    foreach (string s in files)
                    {
                        File.Delete(targetDir + s.Substring(s.LastIndexOf("\\")));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /// <summary>
        /// 创建一个文件。
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static bool CreateFile(string filePath)
        {
            try
            {
                //如果文件不存在则创建该文件
                if (!IsExistFile(filePath))
                {
                    //创建一个FileInfo对象
                    FileInfo file = new FileInfo(filePath);

                    //创建文件
                    FileStream fs = file.Create();

                    //关闭文件流
                    fs.Close();
                    return true;
                }
                else
                {
                    throw new IOException();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 创建一个文件,并将字节流写入文件。
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="buffer">二进制流数据</param>
        public static bool CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                //如果文件不存在则创建该文件
                if (!IsExistFile(filePath))
                {
                    //创建一个FileInfo对象
                    FileInfo file = new FileInfo(filePath);

                    //创建文件
                    FileStream fs = file.Create();

                    //写入二进制流
                    fs.Write(buffer, 0, buffer.Length);

                    //关闭文件流
                    fs.Close();

                    return true;
                }
                else
                {
                    throw new IOException();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 获取文本文件的行数
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static int GetLineCount(string filePath)
        {
            //将文本文件的各行读到一个字符串数组中
            string[] rows = File.ReadAllLines(filePath);

            //返回行数
            return rows.Length;
        }

        /// <summary>
        /// 获取一个文件的长度,单位为Byte
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static int GetFileSize(string filePath)
        {
            //创建一个文件对象
            FileInfo fi = new FileInfo(filePath);

            //获取文件的大小
            return (int)fi.Length;
        }

        /// <summary>
        /// 向文本文件中写入内容
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="text">写入的内容</param>
        /// <param name="encoding">编码</param>
        public static void WriteText(string filePath, string text, Encoding encoding)
        {
            //向文件写入内容
            File.WriteAllText(filePath, text, encoding);
        }

        /// <summary>
        /// 向文本文件的尾部追加内容
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="content">写入的内容</param>
        public static void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        /// <summary>
        /// 从文件的绝对路径中获取文件名( 不包含扩展名 )
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static string GetFileNameNoExtension(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            string ext = fi.Extension;
            return fi.Name.TrimEnd( ext.ToCharArray()) ;
        }

        /// <summary>
        /// 从文件的绝对路径中获取扩展名
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static string GetExtension(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            return fi.Extension;
        }

        /// <summary>
        /// 清空指定目录下所有文件及子目录,但该目录依然保存.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static bool ClearDirectory(string directoryPath)
        {
            var result = false;
            try
            {
                if (IsExistDirectory(directoryPath))
                {
                    //删除目录中所有的文件
                    string[] fileNames = GetFileNames(directoryPath);
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        result = DeleteFile(fileNames[i]);
                    }

                    //删除目录中所有的子目录
                    string[] directoryNames = GetDirectories(directoryPath);
                    for (int i = 0; i < directoryNames.Length; i++)
                    {
                        result = DeleteDirectory(directoryNames[i]);
                    }
                    return result;
                }
                else
                {
                    throw new IOException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
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

        /// <summary>
        /// 获取指定文件详细属性
        /// </summary>
        /// <param name="filePath">文件详细路径</param>
        /// <returns></returns>
        public static string GetFileAttibe(string filePath)
        {
            string str = "";
            FileInfo objFI = new FileInfo(filePath);
            str += "详细路径:" + objFI.FullName + "<br>文件名称:" + objFI.Name + "<br>文件长度:" + objFI.Length.ToString() + "字节<br>创建时间" + objFI.CreationTime.ToString() + "<br>最后访问时间:" + objFI.LastAccessTime.ToString() + "<br>修改时间:" + objFI.LastWriteTime.ToString() + "<br>所在目录:" + objFI.DirectoryName + "<br>扩展名:" + objFI.Extension;
            return str;
        }
        #endregion

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
