using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicaretTakipDatabaseFirst.Startup))]
namespace TicaretTakipDatabaseFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
