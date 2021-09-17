using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcNotas.Startup))]
namespace MvcNotas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
