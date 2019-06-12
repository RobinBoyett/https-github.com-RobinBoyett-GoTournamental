using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoTournamental.Startup))]
namespace GoTournamental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
