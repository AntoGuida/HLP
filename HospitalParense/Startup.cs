using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalParense.Startup))]
namespace HospitalParense
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
