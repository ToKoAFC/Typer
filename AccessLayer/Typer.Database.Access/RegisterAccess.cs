using Autofac;
using System.Linq;
using Typer.Database.Migrations;

namespace Typer.Database.Access
{
    public class RegisterAccess
    {
        public static void Register(ContainerBuilder builder, string nameOrConnectionString)
        {
            SetupIoC(builder, nameOrConnectionString);
        }

        private static void SetupIoC(ContainerBuilder builder, string nameOrConnectionString)
        {
            builder.RegisterType<TyperContext>()
                .AsSelf()
                .WithParameter(new NamedParameter("nameOrConnectionString", nameOrConnectionString))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(TeamAccess).Assembly)
                .Where(t => t.Name.EndsWith("Access") && t.Namespace != null && t.Namespace.StartsWith("Typer.Database.Access"))
                .PropertiesAutowired();
        }
    }
}
