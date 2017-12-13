using System.Web.Mvc;

namespace MyCommon.Web.Areas.SystemManager
{
    public class SystemManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SystemManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SystemManager_default",
                "SystemManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "MyCommon.Web.Areas.SystemManager.Controllers" }
            );
        }
    }
}