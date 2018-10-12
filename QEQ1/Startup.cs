using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QEQ1.Startup))]
namespace QEQ1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
