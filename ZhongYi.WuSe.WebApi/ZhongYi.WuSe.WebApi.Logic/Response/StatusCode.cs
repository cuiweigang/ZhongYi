namespace ZhongYi.WuSe.WebApi.Logic.Response
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 状态码
    /// </summary>
    [DataContract(Name = "statuscode")]
    public enum StatusCode
    {
        /// <summary>
        /// 未知状态
        /// </summary>
        [EnumMember]
        UnKnow = 0,

        /// <summary>
        /// 操作成功
        /// </summary>
        [EnumMember]
        OK = 200,

        /// <summary>
        /// 客户端错误
        /// </summary>
        [EnumMember]
        ClientError = 400,

        /// <summary>
        ///未通过验证
        /// </summary>
        [EnumMember]
        Unauthorized = 401,

        /// <summary>
        ///未登录，该操作需要登录态
        /// </summary>
        [EnumMember]
        UnLogined = 402,

        /// <summary>
        /// 提交参数错误
        /// </summary>
        [EnumMember]
        ParameterError = 407,

        /// <summary>
        /// 请求超时
        /// </summary>
        [EnumMember]
        RequestTimeout = 408,

        /// <summary>
        /// 服务系统内部错误
        /// </summary>
        [EnumMember]
        InternalServerError = 500,

        /// <summary>
        /// 服务不可用
        /// </summary>
        [EnumMember]
        ServiceUnavailable = 503

    }
}
