using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZhongYi.WuSe.WebApi.Logic.Response.Shop
{
    /// <summary>
    /// 店铺信息
    /// </summary>
    public class ShopInfo
    {
        /// <summary>
        /// 商店Id
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string ShopDescription { get; set; }

        /// <summary>
        /// 信用值
        /// </summary>
        public int Credit { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像信息
        /// </summary>
        public string HeadSculptureUrl { get; set; }

        /// <summary>
        /// 背景图
        /// </summary>
        public string BackupImgUrl { get; set; }

        /// <summary>
        /// 店铺HtmlUrl展示地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [DataMember(Name = "productn")]
        public int ProductNumber { get; set; }

        /// <summary>
        /// 是否新店铺
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 模版ID
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        /// 用户等级
        /// </summary>
        public int CustomerLevel { get; set; }
    }
}
