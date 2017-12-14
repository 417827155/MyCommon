using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommon.Common.DataCommon
{
    /// <summary>
    /// 数据处理帮助类
    /// </summary>
    public class DataHelper
    {
        #region 数据判断
        /// <summary>
		/// 判断文本obj是否为空值。
		/// </summary>
		/// <param name="obj">对象。</param>
		/// <returns>Boolean值。</returns>
		public static bool IsEmpty(string obj)
        {
            return Utility.UtilityHelper.Obj2Str(obj).Trim() == String.Empty ? true : false;
        }

        /// <summary>
        /// 判断对象是否为正确的日期值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Boolean。</returns>
        public static bool IsDateTime(object obj)
        {
            DateTime value = new DateTime();
            return DateTime.TryParse(Utility.UtilityHelper.Obj2Str(obj),out value);
        }

        /// <summary>
        /// 判断对象是否为正确的Int32值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Int32值。</returns>
        public static bool IsInt32(object obj)
        {
            Int32 value = Int32.MinValue;
            return Int32.TryParse(Utility.UtilityHelper.Obj2Str(obj), out value);
        }

        /// <summary>
        /// 判断对象是否为正确的Long值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Long值。</returns>
        public static bool IsInt64(object obj)
        {
            Int64 value = Int64.MinValue;
            return Int64.TryParse(Utility.UtilityHelper.Obj2Str(obj), out value);
        }

        /// <summary>
        /// 判断对象是否为正确的Float值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Float值。</returns>
        public static bool IsFloat(object obj)
        {
            float value = float.MinValue;
            return float.TryParse(Utility.UtilityHelper.Obj2Str(obj), out value);
        }

        /// <summary>
        /// 判断对象是否为正确的Double值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Double值。</returns>
        public static bool IsDouble(object obj)
        {
            double value = double.MinValue;
            return double.TryParse(Utility.UtilityHelper.Obj2Str(obj), out value);
        }

        /// <summary>
        /// 判断对象是否为正确的Decimal值。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <returns>Decimal值。</returns>
        public static bool IsDecimal(object obj)
        {
            decimal value = decimal.MinValue;
            return decimal.TryParse(Utility.UtilityHelper.Obj2Str(obj), out value);
        }
        #endregion
    }
}
