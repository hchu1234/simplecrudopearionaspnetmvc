using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDOperation.Startup))]
namespace CRUDOperation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
