using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyCommon.Common.Utility
{
    /// <summary>
    /// 公共帮助类
    /// </summary>
    public class UtilityHelper
    {
        #region 数据转换
        /// <summary>
		/// 返回对象obj的String值,obj为null时返回空值。
		/// </summary>
		/// <param name="obj">对象。</param>
		/// <returns>字符串。</returns>
		public static string Obj2Str(object obj)
        {
            return null == obj ? String.Empty : obj.ToString();
        }

        /// <summary>
        /// 将对象转换为数值(Int32)类型,转换失败返回MinValue。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Int32数值。</returns>
        public static Int32 Obj2Int32(object obj)
        {
            Int32 value = Int32.MinValue;
            Int32.TryParse(Obj2Str(obj), out value);
            return value;
        }

        /// <summary>
        /// 将对象转换为数值(Int32)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Int32数值。</returns>
        public static Int32 Obj2Int32(object obj, Int32 returnValue)
        {
            Int32.TryParse(Obj2Str(obj), out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 将对象转换为数值(Long)类型,转换失败返回MinValue。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Long数值。</returns>
        public static Int64 Obj2Int64(object obj)
        {
            Int64 value = Int64.MinValue;
            Int64.TryParse(Obj2Str(obj), out value);
            return value;
        }
        /// <summary>
        /// 将对象转换为数值(Long)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Long数值。</returns>
        public static Int64 Obj2Int64(object obj, long returnValue)
        {
            Int64.TryParse(Obj2Str(obj), out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 将对象转换为数值(Decimal)类型,转换失败返回MinValue。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Decimal数值。</returns>
        public static decimal Obj2Dec(object obj)
        {
            decimal value = decimal.MinValue;
            decimal.TryParse(Obj2Str(obj), out value);
            return value;
        }

        /// <summary>
        /// 将对象转换为数值(Decimal)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Decimal数值。</returns>
        public static decimal Obj2Dec(object obj, decimal returnValue)
        {
            decimal.TryParse(Obj2Str(obj), out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 将对象转换为数值(Double)类型,转换失败返回MinValue。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Double数值。</returns>
        public static double Obj2Double(object obj)
        {
            double value = double.MinValue;
            double.TryParse(Obj2Str(obj), out value);
            return value;
        }

        /// <summary>
        /// 将对象转换为数值(Double)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Double数值。</returns>
        public static double Obj2Double(object obj, double returnValue)
        {
            double.TryParse(Obj2Str(obj), out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 将对象转换为数值(Float)类型,转换失败返回MinValue。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Float数值。</returns>
        public static float Obj2Float(object obj)
        {
            float value = float.MinValue;
            float.TryParse(Obj2Str(obj), out value);
            return value;
        }

        /// <summary>
        /// 将对象转换为数值(Float)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Float数值。</returns>
        public static float Obj2Float(object obj, float returnValue)
        {
            float.TryParse(Obj2Str(obj), out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 将对象转换为数值(DateTime)类型,转换失败返回Now。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>DateTime值。</returns>
        public static DateTime Obj2Date(object obj)
        {
            DateTime value = DateTime.MinValue;
            DateTime.TryParse(Obj2Str(obj), out value);
            return value;
        }

        /// <summary>
        /// 将对象转换为数值(DateTime)类型。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>DateTime值。</returns>
        public static DateTime Obj2Date(object obj, DateTime returnValue)
        {
            DateTime.TryParse(Obj2Str(obj), out returnValue);
            return returnValue;
        }
        /// <summary>
        /// 从Boolean转换成byte,转换失败返回0。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Byte值。</returns>
        public static byte Bool2Byte(bool obj)
        {
            string text = Obj2Str(obj).Trim();
            if (text == string.Empty)
                return 0;
            else
            {
                try
                {
                    return (byte)(text.ToLower() == "true" ? 1 : 0);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 从Boolean转换成byte。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Byte值。</returns>
        public static byte Bool2Byte(bool obj, byte returnValue)
        {
            string text = Obj2Str(obj).Trim();
            if (text == string.Empty)
                return returnValue;
            else
            {
                try
                {
                    return (byte)(text.ToLower() == "true" ? 1 : 0);
                }
                catch
                {
                    return returnValue;
                }
            }
        }
        /// <summary>
        /// 从byte转换成Boolean,转换失败返回false。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Boolean值。</returns>
        public static bool Byte2Bool(byte obj)
        {
            try
            {
                string s = Obj2Str(obj).ToLower();
                return s == "1" || s == "true" ? true : false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 从byte转换成Boolean。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="returnValue">转换失败返回该值。</param>
        /// <returns>Boolean值。</returns>
        public static bool Byte2Bool(byte obj, bool returnValue)
        {
            try
            {
                string s = Obj2Str(obj).ToLower();
                return s == "1" || s == "true" ? true : false;
            }
            catch
            {
                return returnValue;
            }
        }
        #endregion

        #region 父子关系
        /// <summary>
        /// 判断父子级关系是否正确。
        /// </summary>
        /// <param name="table">数据表。</param>
        /// <param name="columnName">子键列名。</param>
        /// <param name="parentColumnName">父键列名。</param>
        /// <param name="inputString">子键值。</param>
        /// <param name="compareString">父键值。</param>
        /// <returns></returns>
        public static bool IsRightParent(DataTable table, string columnName, string parentColumnName, string inputString, string compareString)
        {
            ArrayList array = new ArrayList();
            SearchChild(array, table, columnName, parentColumnName, inputString, compareString);
            return array.Count == 0;
        }

        // 内部方法
        public static void SearchChild(ArrayList array, DataTable table, string columnName, string parentColumnName, string inputString, string compareString)
        {
            DataView view = new DataView(table);
            view.RowFilter = parentColumnName + "='" + inputString.Trim().Replace("'", "") + "'";//找出所有的子类。
                                                                                                      //查找表中的数据的ID是否与compareString相等，相等返回 false;不相等继续迭代。
            for (int index = 0; index < view.Count; index++)
            {
                if (Obj2Str(view[index][columnName]).ToLower() == compareString.Trim().ToLower())
                {
                    array.Add("1");
                    break;
                }
                else
                {
                    SearchChild(array, table, columnName, parentColumnName, Obj2Str(view[index][columnName]), compareString);
                }
            }
        }
        #endregion

        #region 日期
        /// <summary>
        /// 日期差 日
        /// </summary>
        /// <param name="sdmin">起始日期</param>
        /// <param name="sdmax">结束日期</param>
        /// <returns></returns>
        public static string DateDiff(string sdmin, string sdmax)
        {
            try
            {
                DateTime dt1 = Convert.ToDateTime(sdmin);
                DateTime dt2 = Convert.ToDateTime(sdmax);
                return DateDiff(dt1,dt2) ;
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 日期差
        /// </summary>
        /// <param name="sdmin">起始日期</param>
        /// <param name="sdmax">结束日期</param>
        /// <returns></returns>
        public static string DateDiff(DateTime sdmin, DateTime sdmax)
        {
            try
            {
                TimeSpan ts1 = new TimeSpan(sdmin.Ticks);
                TimeSpan ts2 = new TimeSpan(sdmax.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                var result = ts.Days + "-" + ts.Hours + "-" + ts.Minutes + "" + ts.Seconds;
                return  result;
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 日期差 日
        /// </summary>
        /// <param name="sdmin">起始日期</param>
        /// <param name="sdmax">结束日期</param>
        /// <returns></returns>
        public static double DateDiffDay(DateTime sdmin, DateTime sdmax)
        {
            try
            {
                TimeSpan ts = sdmax - sdmin;
                return ts.TotalDays;
            }
            catch
            {
                return double.MinValue;
            }
        }
        /// <summary>
        /// 日期差 小时
        /// </summary>
        /// <param name="sdmin">起始日期</param>
        /// <param name="sdmax">结束日期</param>
        /// <returns></returns>
        public static double DateDiffHour(DateTime sdmin, DateTime sdmax)
        {
            try
            {
                TimeSpan ts = sdmax - sdmin;
                return ts.TotalHours;
            }
            catch
            {
                return double.MinValue;
            }
        }
        /// <summary>
        /// 日期差 分钟
        /// </summary>
        /// <param name="sdmin">起始日期</param>
        /// <param name="sdmax">结束日期</param>
        /// <returns></returns>
        public static double DateDiffMinutes(DateTime sdmin, DateTime sdmax)
        {
            try
            {
                TimeSpan ts = sdmax - sdmin;
                return ts.TotalMinutes;
            }
            catch
            {
                return double.MinValue;
            }
        }
        /// <summary>
        /// 日期差 秒
        /// </summary>
        /// <param name="sdmin">起始日期</param>
        /// <param name="sdmax">结束日期</param>
        /// <returns></returns>
        public static double DateDiffSecond(DateTime sdmin, DateTime sdmax)
        {
            try
            {
                TimeSpan ts = sdmax - sdmin;
                return ts.TotalSeconds;
            }
            catch
            {
                return double.MinValue;
            }
        }
        #endregion

        #region 用户输入处理
        /// <summary>
		/// 将用户输入的字符串转换为可换行、替换Html编码、无危害数据库特殊字符、去掉首尾空白、的安全方便代码。
		/// </summary>
		/// <param name="inputString">用户输入字符串</param>
		public static string ConvertStr(string inputString)
        {
            string retVal = inputString;
            //retVal=retVal.Replace("&","&amp;"); 
            retVal = retVal.Replace("\"", "&quot;");
            retVal = retVal.Replace("<", "&lt;");
            retVal = retVal.Replace(">", "&gt;");
            retVal = retVal.Replace(" ", "&nbsp;");
            retVal = retVal.Replace("  ", "&nbsp;&nbsp;");
            retVal = retVal.Replace("\t", "&nbsp;&nbsp;");
            retVal = retVal.Replace("\r", "<br>");
            return retVal;
        }

        /// <summary>
        /// 将用户输入的字符串转换为可换行、替换Html编码、无危害数据库特殊字符、去掉首尾空白、的安全方便代码。
        /// </summary>
        /// <param name="inputString">用户输入字符串</param>
        /// <returns></returns>
        public static string InputText(string inputString)
        {
            string retVal = inputString;
            retVal = ConvertStr(retVal);
            retVal = retVal.Replace("[url]", "");
            retVal = retVal.Replace("[/url]", "");
            return retVal;
        }


        /// <summary>
        /// 将html代码显示在网页上
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
		public static string OutputText(string inputString)
        {
            string retVal = System.Web.HttpUtility.HtmlDecode(inputString);
            retVal = retVal.Replace("<br>", "");
            retVal = retVal.Replace("&amp", "&;");
            retVal = retVal.Replace("&quot;", "\"");
            retVal = retVal.Replace("&lt;", "<");
            retVal = retVal.Replace("&gt;", ">");
            retVal = retVal.Replace("&nbsp;", " ");
            retVal = retVal.Replace("&nbsp;&nbsp;", "  ");
            return retVal;
        }

        /// <summary>
        /// 转换成url
        /// </summary>
        /// <param name="inputString">用户输入</param>
        /// <returns></returns>
        public static string ToUrl(string inputString)
        {
            string retVal = inputString;
            retVal = ConvertStr(retVal);
            return Regex.Replace(retVal, @"\[url](?<x>[^\]]*)\[/url]", @"<a href=""$1"" target=""_blank"">$1</a>", RegexOptions.IgnoreCase);
        }
        #endregion
    }
}