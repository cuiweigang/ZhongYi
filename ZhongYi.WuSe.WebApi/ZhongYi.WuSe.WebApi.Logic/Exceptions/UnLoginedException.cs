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
    }

    /// <summary>
    /// 验签失败异常
    /// </summary>
    public class UnauthorizedException : BaseException
    {
    }

    /// <summary>
    /// 未知错误异常
    /// </summary>
    public class UnKnowErrorException : BaseException
    {

    }
}
