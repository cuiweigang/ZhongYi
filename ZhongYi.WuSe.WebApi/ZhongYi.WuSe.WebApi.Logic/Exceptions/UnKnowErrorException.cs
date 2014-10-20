namespace ZhongYi.WuSe.WebApi.Logic.Exceptions
{
    /// <summary>
    /// 未知错误异常
    /// </summary>
    public class UnKnowErrorException : BaseException
    {
        public UnKnowErrorException()
            : this("系统发生了未知错误")
        {
        }



        public UnKnowErrorException(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Message
        /// </summary>
        public override string Message
        {
            get
            {
                return this.message;
            }
        }

        public override Response.StatusCode StatusCode
        {
            get { return Response.StatusCode.UnKnow; }
        }
    }
}