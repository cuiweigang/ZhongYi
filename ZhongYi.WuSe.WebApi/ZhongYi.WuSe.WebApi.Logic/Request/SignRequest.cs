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
            return this.SignType;
        }

        /// <summary>
        /// 进行验证
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            // TODO: 验签认证
            return true;
        }

    }
}