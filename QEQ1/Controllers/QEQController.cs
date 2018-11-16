using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ1.Models;

namespace QEQ1.Controllers
{
    public class QEQController : Controller
    {
        // GET: QEQ
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Instrucciones()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Funciono(Usuario x)
        {

            if (!ModelState.IsValid)
            {
                return View("Login", x);
            }
            else
            {
                Usuario a = BD.Login(x);
                if (a.Email != null)
                {
                    Session["User"] = a;
                    BD j = new BD();
                    string rol = j.admin(a);
                    if (rol == "Admin")
                    {
                        BackofficeController l = new BackofficeController();
                        l.Menu();
                    }
                    else
                    {
                        return View("Funciono");
                    }
                }
                else
                {
                    ViewBag.EstaMal = "El usuario o la contraseña ingresados son incorrectas"; ;
                    return View("Login", x);
                }

            }
        }

        public ActionResult CuentaCreada(Usuario x)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", x);
            }
            else
            {
                BD b = new BD();
                bool funciono = b.Registrarse(x);
                if (funciono == true)
                {
                    return View("CuentaCreada");
                }
                else
                {
                    return View("Register", x);
                }
            }

        }
    }
}
