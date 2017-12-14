using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

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
    }
}