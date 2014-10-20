using ZhongYi.WuSe.WebApi.Logic.Helpers;
namespace ZhongYi.WuSe.WebApi.Logic.Request
{
    /// <summary>
    /// 验签请求
    /// </summary>
    public class SignRequest
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeReq { get; set; }

        /// <summary>
        /// 验签类型 md5
        /// </summary>
        public string SignType { get; set; }

        /// <summary>
        /// 客户端系统
        /// </summary>
        public string OS { get; set; }

        /// <summary>
        /// 客户端签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 客户端与服务端签名 不参与传输
        /// </summary>
        private string GetAppKey()
        {
            // TODO:获取客户端签名方法
            return "0000000000000000001";
        }

        /// <summary>
        /// 进行验证
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            var paramString = string.Format("os={0}&timereq={1}&appkey={2}", this.OS, this.TimeReq, this.GetAppKey());
            
            //paramString = "os=iphone&timereq=20140309112229&appkey=3452CB52D98A987E798E071D798E090D";
            
            var md5 = HashHelper.MD5(paramString).HexDigest;

            return md5 == Sign;
        }

    }
}