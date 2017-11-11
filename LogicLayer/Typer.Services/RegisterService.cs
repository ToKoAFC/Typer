using Autofac;
using System.Linq;
using Typer.Database.Access;
using Typer.Services.AdminTeam;

namespace Typer.Services
{
    public class RegisterService
    {
        public static void Register(ContainerBuilder builder, string nameOrConnectionString)
        {
            SetupIoC(builder, nameOrConnectionString);
        }

        private static void SetupIoC(ContainerBuilder builder, string nameOrConnectionString)
        {
            RegisterAccess.Register(builder, nameOrConnectionString);

            builder.RegisterAssemblyTypes(typeof(AdminTeamService).Assembly)
                .Where(t => t.Name.EndsWith("Service") && t.Namespace != null && t.Namespace.StartsWith("Typer.Services"))
                .AsImplementedInterfaces();
        }
    }
}
