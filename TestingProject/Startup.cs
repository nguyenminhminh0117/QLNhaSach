using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingProject.Startup))]
namespace TestingProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
