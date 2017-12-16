using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCommon.Common
{
    public class CommException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="errCode"></param>
        public CommException(string errMsg,string errCode)
        {
            ErrMsg = errMsg;
            ErrCode = errCode;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get;  }
        /// <summary>
        /// 错误编码
        /// </summary>
        public string ErrCode { get;  }
    }
}
