using System;
using System.Threading.Tasks;
using MagisterWeb.Models;
using MagisterWeb.Security;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MagisterWeb.Models.Start))]

namespace MagisterWeb.Models
{
    public class Start

    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(Context.Create);
            app.CreatePerOwinContext<UserAppManager>(UserAppManager.Create);
        }
    }
}

