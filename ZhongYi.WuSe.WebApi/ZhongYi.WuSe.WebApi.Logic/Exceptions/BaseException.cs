using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhongYi.WuSe.WebApi.Logic.Response;

namespace ZhongYi.WuSe.WebApi.Logic.Exceptions
{
    /// <summary>
    /// 异常基本类
    /// </summary>
    public abstract class BaseException : Exception
    {
        /// <summary>
        /// 消息
        /// </summary>
        protected string message;

        /// <summary>
        /// 状态值
        /// </summary>
        public abstract StatusCode StatusCode { get; }
    }
}
