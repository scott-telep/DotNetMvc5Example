using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetMvc5Example.Startup))]
namespace DotNetMvc5Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
