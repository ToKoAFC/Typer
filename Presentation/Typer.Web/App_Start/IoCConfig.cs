using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Typer.Database.Models;
using static Typer.Web.IdentityConfig;

namespace Typer.Web
{
    public class IoCConfig
    {
        public static void SetupIoC(ContainerBuilder builder)
        {
            //Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // register controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<UserManager<DbAppUser>>())
              .InstancePerLifetimeScope();

            builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>())
                .InstancePerLifetimeScope();

            // Build the container.
            var container = builder.Build();

            // Resolver for MVC.
            var mvc_resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvc_resolver);

        }
    }
}
