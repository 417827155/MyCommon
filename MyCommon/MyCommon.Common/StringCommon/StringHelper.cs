using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace MyCommon.Common.StringCommon
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public class StringHelper
    {
        #region 字符串转list
        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <returns></returns>
        public static List<string> Str2List(string str, string speater,bool isremoveEmpyt = false)
        {
            string[] ss ;
            if (isremoveEmpyt)
            {
                ss = str.Split(speater.ToCharArray(),StringSplitOptions.None);
            }
            else
            {
                ss = str.Split(speater.ToCharArray());
            }

            List<string> list = new List<string>(ss);
            return list;
        }
        /// <summary>
        /// 把字符串转 按照, 分割 换为数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> Str2List(string str)
        {
            List<string> result = new List<string>(str.Split(new Char[] { ',' }));
            return result;
        }
        /// <summary>
        /// 分割字符串（正则表达式）
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="splitstr">正则表达式</param>
        /// <returns></returns>
        public static string[] Str2ArrayByRegex(string str, string splitstr)
        {
            string[] strArray = null;
            if ((str != null) && (str != ""))
            {
                strArray = new Regex(splitstr).Split(str);
            }
            return strArray;
        }
        /// <summary>
        /// 分割字符串（正则表达式）
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="splitstr">正则表达式</param>
        /// <returns></returns>
        public static List<string> Str2ListByRegex(string str, string splitstr)
        {
            List<string> result = new List<string>(Str2ArrayByRegex(str,splitstr));
            return result;
        }
        #endregion

        #region list转字符串
        /// <summary>
        /// 把 List<string> 按照分隔符组装成 string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="speater"></param>
        /// <returns></returns>
        public static string List2Str(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i]);
                sb.Append(speater);
            }
            if (list.Count > 0)
            {
                return DelCharLast(sb.ToString(),speater);
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 把 List<int> 按照分隔符组装成 string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="speater"></param>
        /// <returns></returns>
        public static string List2Str(List<int> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i]);
                sb.Append(speater);
            }
            if (list.Count > 0)
            {
                return DelCharLast(sb.ToString(), speater);
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 得到数组列表以逗号分隔的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string List2Str(List<string> list)
        {
            return List2Str(list, ",");
        }
        /// <summary>
        /// 得到数组列表以逗号分隔的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string List2Str(List<int> list)
        {
            return List2Str(list,",");
        }
        /// <summary>
        /// 得到数组列表以逗号分隔的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string List2Str(Dictionary<int, int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, int> kvp in list)
            {
                sb.Append(kvp.Value + ",");
            }
            if (list.Count > 0)
            {
                return sb.ToString().TrimEnd(',');
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region 删除最后的指定字符及以后的字符

        /// <summary>
        /// 删除最后的指定字符及以后的字符
        /// </summary>
        public static string DelCharLast(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        #endregion

        #region 全角半角转换
        /// <summary>
        /// 半角转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DBC2SBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  全角转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string SBC2DBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region 空字符串处理
        public static string Null2String(string str)
        {
            if (str == null)
            {
                return "";
            }
            else
            {
                return str;
            }
        }
        #endregion

        #region 将字符串替换内容替换成空
        /// <summary>
        ///  将字符串替换内容替换成空
        /// </summary>
        /// <param name="strList">源字符串</param>
        /// <param name="splitString">替换内容</param>
        /// <returns></returns>
        public static string GetReplaceStr(string strList, string splitString)
        {
            string RetrunValue = Null2String(strList);
            RetrunValue = RetrunValue.Replace(splitString, "");
            return RetrunValue;
        }
        #endregion

        #region 将字符串转换为新样式
        /// <summary>
        /// 将字符串转换为新样式
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="newStyle"></param>
        /// <param name="splitString"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string GetNewStyle(string strList, string newStyle, string splitString, out string error)
        {
            string ReturnValue = "";
            //如果输入空值，返回空，并给出错误提示
            if (strList == null)
            {
                ReturnValue = "";
                error = "请输入需要划分格式的字符串";
            }
            else
            {
                //检查传入的字符串长度和样式是否匹配,如果不匹配，则说明使用错误。给出错误信息并返回空值
                int strListLength = strList.Length;
                int NewStyleLength = GetReplaceStr(newStyle, splitString).Length;
                if (strListLength != NewStyleLength)
                {
                    ReturnValue = "";
                    error = "样式格式的长度与输入的字符长度不符，请重新输入";
                }
                else
                {
                    //检查新样式中分隔符的位置
                    string Lengstr = "";
                    for (int i = 0; i < newStyle.Length; i++)
                    {
                        if (newStyle.Substring(i, 1) == splitString)
                        {
                            Lengstr = Lengstr + "," + i;
                        }
                    }
                    if (Lengstr != "")
                    {
                        Lengstr = Lengstr.Substring(1);
                    }
                    //将分隔符放在新样式中的位置
                    string[] str = Lengstr.Split(',');
                    foreach (string bb in str)
                    {
                        strList = strList.Insert(int.Parse(bb), splitString);
                    }
                    //给出最后的结果
                    ReturnValue = strList;
                    //因为是正常的输出，没有错误
                    error = "";
                }
            }
            return ReturnValue;
        }
        #endregion

        #region sql安全处理
        /// <summary>
        /// sql安全处理
        /// </summary>
        /// <param name="String"></param>
        /// <param name="IsDel"></param>
        /// <returns></returns>
        public static string SqlSafeString(string String, bool IsDel)
        {
            if (IsDel)
            {
                String = String.Replace("'", "");
                String = String.Replace("\"", "");
                return String;
            }
            String = String.Replace("'", "&#39;");
            String = String.Replace("\"", "&#34;");
            return String;
        }
        #endregion

        #region 获取正确正整数，如果不是正整数，返回0
        /// <summary>
        /// 获取正确正整数，如果不是正整数或长度超出限制，返回0
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static int StrToInt32(string _value)
        {
            int result = 0;
            if (IsNumberId(_value))
                int.TryParse(_value,out result);
            return result;
        }
        /// <summary>
        /// 获取正确正整数，如果不是正整数或长度超出限制，返回0
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static Int64 StrToInt64(string _value)
        {
            Int64 result = 0;
            if (IsNumberId(_value))
                Int64.TryParse(_value, out result);
            return result;
        }
        #endregion

        #region 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。(0除外)
        /// </summary>
        /// <param name="_value">需验证的字符串。。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumberId(string _value)
        {
            return QuickValidate("^[1-9]*[0-9]*$", _value);
        }
        #endregion

        #region 快速验证一个字符串是否符合指定的正则表达式。
        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="_express">正则表达式的内容。</param>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(string _express, string _value)
        {
            if (_value == null) return false;
            Regex myRegex = new Regex(_express);
            if (_value.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(_value);
        }
        #endregion

        #region MD5 加密
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5Encrypt16(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(value)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string value)
        {
            string cl = value;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X2");
            }
            return pwd;
        }
        /// <summary>
        /// 64位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt64(string password)
        {
            string cl = password;
            //string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }
        /// <summary>
        /// 加密用户密码
        /// </summary>
        /// <param name="value">加密字符串</param>
        /// <param name="codeLength">加密位数</param>
        /// <returns>加密密码</returns>
        public static string md5(string value, int codeLength)
        {
            if (!string.IsNullOrEmpty(value))
            {
                // 16位MD5加密（取32位加密的9~25字符）  
                if (codeLength == 16)
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5").ToLower().Substring(8, 16);
                }

                // 32位加密
                if (codeLength == 32)
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5").ToLower();
                }
            }
            return string.Empty;
        }
        #endregion

        #region des 加密解密
        /// <summary>
        /// DES数据加密
        /// </summary>
        /// <param name="targetValue">目标值</param>
        /// <param name="key">密钥</param>
        /// <returns>加密值</returns>
        public static string Encrypt(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }

            var returnValue = new StringBuilder();
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(targetValue);
            // 通过两次哈希密码设置对称算法的初始化向量   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").
                                                        Substring(0, 8), "sha1").Substring(0, 8));
            // 通过两次哈希密码设置算法的机密密钥   
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                                                        .Substring(0, 8), "md5").Substring(0, 8));
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            foreach (byte b in ms.ToArray())
            {
                returnValue.AppendFormat("{0:X2}", b);
            }
            return returnValue.ToString();
        }
        /// <summary>
        /// DES数据解密
        /// </summary>
        /// <param name="targetValue"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            // 定义DES加密对象
            var des = new DESCryptoServiceProvider();
            int len = targetValue.Length / 2;
            var inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(targetValue.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            // 通过两次哈希密码设置对称算法的初始化向量   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").
                                                        Substring(0, 8), "sha1").Substring(0, 8));
            // 通过两次哈希密码设置算法的机密密钥   
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                    (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                                                        .Substring(0, 8), "md5").Substring(0, 8));
            // 定义内存流
            var ms = new MemoryStream();
            // 定义加密流
            var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
        #endregion

        #region 哈希加密
        /// <summary>
        /// 哈希256加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToHex256String(string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = new SHA256Managed().ComputeHash(valueBytes);
            string result = Convert.ToBase64String(hashBytes);
            return result;
        }
        /// <summary>
        /// 哈希384加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToHex384String(string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = new SHA384Managed().ComputeHash(valueBytes);
            string result = Convert.ToBase64String(hashBytes);
            return result;
        }
        /// <summary>
        /// 哈希512加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToHex512String(string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = new SHA512Managed().ComputeHash(valueBytes);
            string result = Convert.ToBase64String(hashBytes);
            return result;
        }
        #endregion

        #region 得到字符串长度，一个汉字长度为2
        /// <summary>
        /// 得到字符串长度，一个汉字长度为2
        /// </summary>
        /// <param name="inputString">参数字符串</param>
        /// <returns></returns>
        public static int StrLength(string inputString)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }
        #endregion

        #region 截取指定长度字符串
        /// <summary>
        /// 截取指定长度字符串
        /// </summary>
        /// <param name="inputString">要处理的字符串</param>
        /// <param name="len">指定长度</param>
        /// <returns>返回处理后的字符串</returns>
        public static string ClipString(string inputString, int len)
        {
            bool isShowFix = false;
            if (len % 2 == 1)
            {
                isShowFix = true;
                len--;
            }
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }

            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (isShowFix && mybyte.Length > len)
                tempString += "…";
            return tempString;
        }
        #endregion

        #region HTML转行成TEXT
        /// <summary>
        /// HTML转行成TEXT
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlToTxt(string strHtml)
        {
            string[] aryReg ={
            @"<script[^>]*?>.*?</script>",
            @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
            @"([\r\n])[\s]+",
            @"&(quot|#34);",
            @"&(amp|#38);",
            @"&(lt|#60);",
            @"&(gt|#62);",
            @"&(nbsp|#160);",
            @"&(iexcl|#161);",
            @"&(cent|#162);",
            @"&(pound|#163);",
            @"&(copy|#169);",
            @"&#(\d+);",
            @"-->",
            @"<!--.*\n"
            };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, string.Empty);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");


            return strOutput;
        }
        #endregion

        #region 判断对象是否为空
        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <typeparam name="T">要验证的对象的类型</typeparam>
        /// <param name="data">要验证的对象</param>        
        public static bool IsNullOrEmpty<T>(T data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }

        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <param name="data">要验证的对象</param>
        public static bool IsNullOrEmpty(object data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }
        #endregion
    }
}
