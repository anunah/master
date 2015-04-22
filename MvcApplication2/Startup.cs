using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using MvcApplication2.Hubs;
[assembly: OwinStartup(typeof(MvcApplication2.Startup))]

namespace MvcApplication2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
