namespace ZhongYi.WuSe.WebApi.Logic.Exceptions
{
    /// <summary>
    /// 验签失败异常
    /// </summary>
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException()
            : this("验签失败")
        {
        }

        public UnauthorizedException(string message)
        {
            this.Message = message;
        }

        public override Response.StatusCode StatusCode
        {
            get { return Response.StatusCode.Unauthorized; }
        }
    }
}