namespace ZhongYi.WuSe.WebApi.Api.Filters
{
    using System;
    using System.Web.Http.Filters;

    /// <summary>
    /// 不需要授权Filter
    /// </summary>
    public class NoAuthorizeFilterAttribute : Attribute, IFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }
    }
}