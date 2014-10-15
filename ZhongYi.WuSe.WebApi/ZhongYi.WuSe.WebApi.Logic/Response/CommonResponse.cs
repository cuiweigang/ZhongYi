using System.Runtime.Serialization;

namespace ZhongYi.WuSe.WebApi.Logic.Response
{
    /// <summary>
    /// 公共返回部分
    /// </summary>
    [DataContract]
    public class CommonRsponse
    {
        /// <summary>
        /// 状态值
        /// </summary>
        [DataMember(Name = "status")]
        public int Status { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        [DataMember(Name = "desc")]
        public string Description { get; set; }

        /// <summary>
        /// 业务数据
        /// </summary>
        [DataMember(Name = "data")]
        public object Data { get; set; }
    }
}
