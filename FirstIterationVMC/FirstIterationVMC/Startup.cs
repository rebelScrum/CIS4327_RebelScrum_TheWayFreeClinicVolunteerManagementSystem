using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstIterationVMC.Startup))]
namespace FirstIterationVMC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
