using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheConnoisseur.Startup))]
namespace TheConnoisseur
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
