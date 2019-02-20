using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gTarrGames.Web.Startup))]
namespace gTarrGames.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
