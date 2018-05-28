using MagisterWeb.Models;
using MagisterWeb.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterWeb.Security
{
    public class UserAppManager : UserManager<Usuario>
    {
        public UserAppManager(IUserStore<Usuario> store) : base(store)
        {

        }

        public static UserAppManager Create(IdentityFactoryOptions<UserAppManager> options, IOwinContext context)
        {
            var appcontext = context.Get<Context>();

            var usuarioManager = new UserAppManager(new UserStore<Usuario>(appcontext));

            return usuarioManager;
        }
    }
}
