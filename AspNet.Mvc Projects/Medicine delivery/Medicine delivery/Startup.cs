using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medicine_delivery.Startup))]
namespace Medicine_delivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
