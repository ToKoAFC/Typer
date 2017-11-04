using Autofac;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Typer.Services;

namespace Typer.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            RegisterService.Register(builder, "name=TyperContext");
            IoCConfig.SetupIoC(builder);
        }
    }
}
