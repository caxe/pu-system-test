using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pu_system_test.Startup))]
namespace pu_system_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
