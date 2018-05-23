using ShowRoom.App_Helpers;
using ShowRoom.App_Start;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShowRoom
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Removing all the view engines
            ViewEngines.Engines.Clear();
            //Add Razor Engine (which we are using)
            ViewEngines.Engines.Add(new MinhaViewEngine());

            AreaRegistration.RegisterAllAreas();
            //IdentityConfig.RegisterIdentities();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;

            ModelBinders.Binders.Add(
                typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(
                typeof(decimal?), new DecimalModelBinder());
          
        }
    }
}
