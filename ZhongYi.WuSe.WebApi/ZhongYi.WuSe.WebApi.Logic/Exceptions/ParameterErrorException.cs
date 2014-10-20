using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhongYi.WuSe.WebApi.Logic.Exceptions
{
    /// <summary>
    /// 参数异常
    /// </summary>
    public class ParameterErrorException : BaseException
    {
        public ParameterErrorException()
            : this("参数异常")
        {
        }

        /// <summary>
        /// 消息
        /// </summary>
        public override string Message
        {
            get
            {
                return this.message;
            }
        }

        public ParameterErrorException(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        public override Response.StatusCode StatusCode
        {
            get
            {
                return Response.StatusCode.ParameterError;
            }
        }
    }
}
