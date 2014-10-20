using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhongYi.WuSe.WebApi.Logic.Exceptions
{
    /// <summary>
    /// 系统服务内部异常
    /// </summary>
    public class InternalServerException : BaseException
    {
        public InternalServerException()
            : this("系统服务内部发生了错误")
        {
        }

        public InternalServerException(string message)
        {
            this.message = message;
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

        /// <summary>
        /// 状态码
        /// </summary>
        public override Response.StatusCode StatusCode
        {
            get
            {
                return Response.StatusCode.InternalServerError;
            }
        }
    }
}
