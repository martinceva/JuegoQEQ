using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ1.Models;
namespace QEQ1.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        public ActionResult Menu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EdicionCategoria(string Accion, int Id)
        {
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                Categorias ct = BD.ObtenerCategorias(Id);
                return View("EdicionCategoria", ct);
            }
            else
            {
                if (Accion == "Eliminar")
                {
                    BD.EliminarCategoria(Id);
                    ViewBag.Categorias = BD.ListarCategorias();
                    return View("Index");
                }
            }
            return View("EdicionCategoria");
        }

    }
}