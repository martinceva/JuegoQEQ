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

            if(!ModelState.IsValid)
            {
                return View("Login",x );
            }
            else
            {
                Usuario a = BD.Login(x);            
                if (a.Email != null)
                {
                    Session["User"] = a;
                   
                    string rol = BD.admin(a);
                    if(rol == "Admin")
                    {
                        BackofficeController l = new BackofficeController();
                        l.Menu();
                    }
                    else
                    {
                        return View("Funciono");
                    }
                }
                ViewBag.EstaMal = "El usuario o la contraseña ingresados son incorrectas";
                return View("Login");
            }
        }
        
        public ActionResult CuentaCreada(Usuario x)
        {
            if (!ModelState.IsValid)
            {
                return View("Register",x);
            }
            else
            {
                bool val = BD.Registrarse(x);
                if (val == false)
                {
                    ViewBag.val = false;
                    return View("Register", x);
                }
                else
                {
                    return View("CuentaCreada");
                }
            }
        }
    }
}
