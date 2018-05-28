using MagisterWeb.Models;
using MagisterWeb.Security;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MagisterWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            // Contexto Global
            var contexto = HttpContext.GetOwinContext();

            // UserManager disponibilizado no contexto
            var manager = contexto.GetUserManager<UserAppManager>();

            // Usuario - classe filha de IdentityUser
            var usuario = new Usuario()
            {
                UserName = "alissonlima07",
                FirstName = "Alisson",
                LastName = "Lima",
                Email = "alisson.santos@sounit.com.br"
            };

            // Método disponibilizado pela classe UserManager
            await manager.CreateAsync(usuario, "123Trocar@@");

            return View();
        }

        /* public ActionResult Index()
         {
             return View();
         }

         public ActionResult About()
         {
             ViewBag.Message = "Your application description page.";

             return View();
         }

         public ActionResult Contact()
         {
             ViewBag.Message = "Your contact page.";

             return View();
         } */
    }
}