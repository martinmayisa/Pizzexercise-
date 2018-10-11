using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PizzExercise.Startup))]
namespace PizzExercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
