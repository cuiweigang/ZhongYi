using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhongYi.WuSe.WebApi.Logic.Exceptions
{
    /// <summary>
    /// 未登录异常
    /// </summary>
    public class UnLoginedException : BaseException
    {
        public UnLoginedException()
            : this("请重新登录")
        {
        }

        public UnLoginedException(string message)
        {
            this.Message = message;
        }

        public override Response.StatusCode StatusCode
        {
            get { return Response.StatusCode.UnLogined; }
        }
    }
}
