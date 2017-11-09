using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Typer.Web.Startup))]
namespace Typer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
