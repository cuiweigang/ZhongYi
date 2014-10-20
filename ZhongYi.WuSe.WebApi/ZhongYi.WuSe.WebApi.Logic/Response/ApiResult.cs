namespace ZhongYi.WuSe.WebApi.Logic.Response
{
    using System.Runtime.Serialization;

    /// <summary>
    /// 执行结果
    /// </summary>
    [DataContract]
    public class ApiResult
    {
        /// <summary>
        /// 是否执行成功
        /// </summary>
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        [DataMember(Name = "desc")]
        public string Description { get; set; }
    }
}
