using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhongYi.WuSe.WebApi.Logic.Response;

namespace ZhongYi.WuSe.WebApi.Logic.Exceptions
{
    /// <summary>
    /// 客户端异常
    /// </summary>
    public class ClientErrorException : BaseException
    {
        public ClientErrorException()
            : this("客户端错误")
        {
        }

        public ClientErrorException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get
            {
                return this.message;
            }
        }

        /// <summary>
        /// 状态值
        /// </summary>
        public override StatusCode StatusCode
        {
            get
            {
                return StatusCode.ClientError;
            }
        }
    }
}
