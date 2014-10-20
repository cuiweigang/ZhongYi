using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhongYi.WuSe.WebApi.Logic.Request
{
    /// <summary>
    /// 公共参数
    /// </summary>
    public class CommonRequest
    {
        #region[系统相关]

        /// <summary>
        /// 客户端平台 iphone/ipad/andriod
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// 设备名称 Iphone5s
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 客户端操作系统 andorid/ios/html
        /// </summary>
        public string OS { get; set; }

        /// <summary>
        /// 客户端系统版本
        /// </summary>
        public string OSVersion { get; set; }

        /// <summary>
        /// Mac地址
        /// </summary>
        public string MacId { get; set; }

        /// <summary>
        /// 国际移动设备身份码
        /// </summary>
        public string IMEI { get; set; }

        /// <summary>
        /// 网络连接类型 wifi 3g
        /// </summary>
        public string WanType { get; set; }

        /// <summary>
        /// 运营商类型 移动联通
        /// </summary>
        public string Carrier { get; set; }

        /// <summary>
        /// 屏幕宽
        /// </summary>
        public string ScreenWidth { get; set; }

        /// <summary>
        /// 屏幕高
        /// </summary>
        public string ScreenHeight { get; set; }

        /// <summary>
        /// 调用的服务端Api接口版本
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// 客户端版本
        /// </summary>
        public string ClientVersion { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }
        #endregion

        #region[业务参数]
        /// <summary>
        /// 7位渠道号
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// SessionId
        /// </summary>
        public string SessionId { get; set; }

        #endregion

        /// <summary>
        /// 客户端推广来源ID 91助手/应用宝等
        /// </summary>
        public string SourcesId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int CustomerId { get; set; }
    }
}
