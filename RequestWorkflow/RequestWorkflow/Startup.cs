using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RequestWorkflow.Startup))]
namespace RequestWorkflow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
