namespace ZhongYi.WuSe.WebApi.Api.App_Start
{
    using System.Web.Mvc;

    using ZhongYi.WuSe.WebApi.Api.Filters;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}