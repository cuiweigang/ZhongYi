namespace ZhongYi.WuSe.WebApi.Api.Versions.V2
{
    using System.Web.Http;
    using System.Web.Mvc;

    public class V2AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "V2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                this.AreaName + "Api",
                "api/" + this.AreaName + "/{controller}/{action}/{id}",
                new
                {
                    action = RouteParameter.Optional,
                    id = RouteParameter.Optional,
                    namespaceName = new string[] { string.Format("ZhongYi.WuSe.WebApi.Api.Versions.{0}.Controllers", this.AreaName) }
                });
        }
    }
}
