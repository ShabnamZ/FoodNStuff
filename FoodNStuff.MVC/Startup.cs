using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodNStuff.MVC.Startup))]
namespace FoodNStuff.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
