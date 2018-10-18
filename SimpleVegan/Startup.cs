using Microsoft.Owin;
using Owin;
using SimpleVegan;

[assembly: OwinStartupAttribute(typeof(SimpleVegan.Startup))]
namespace SimpleVegan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
