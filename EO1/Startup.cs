//add the attribute here
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Security;
using Owin;
[assembly: OwinStartup(typeof(EO1.Startup))]

namespace EO1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }

    }
}