using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelerikAcademy.AutoDealer.Web.Startup))]
namespace TelerikAcademy.AutoDealer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
