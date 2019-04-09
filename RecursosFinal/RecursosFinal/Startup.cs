using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecursosFinal.Startup))]
namespace RecursosFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
