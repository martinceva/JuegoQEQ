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
        
        public ActionResult ABMCategorias(Categorias ct)
        {
            ViewBag.Categorias = BD.ListarCategorias();
            return View();
        }
        public ActionResult InsertarCategorias(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }

        public ActionResult FormCategoria(string Accion, int Id)
        {
            ViewBag.Categorias = BD.ListarCategorias();
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
                   
                    return View("ABMCategorias");
                }
            }
            return View("EdicionCategoria");
        }
        [HttpPost]
        public ActionResult EdicionCategoria(Categorias ct, string Accion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = BD.ListarCategorias();
                return View("ABMCategorias");
            }
            else
            {
                if (Accion == "Obtener")
                {
                    BD.ModificarCategoria(ct);
                    ViewBag.Categorias = BD.ListarCategorias();
                    return View("ABMCategorias");
                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarCategoria(ct);
                        ViewBag.Categorias = BD.ListarCategorias();
                        return View("ABMCategorias");
                    }
                }
                ViewBag.Categorias = BD.ListarCategorias();
                return View("ABMCategorias");
            }

        }

        public ActionResult EdicionPersonaje()
        {
            return View();
        }
        public ActionResult EdicionPreguntas()
        {
            return View();
        }
    }
}