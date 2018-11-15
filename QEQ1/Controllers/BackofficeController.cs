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
        
        
         public ActionResult ABMPreguntas(Preguntas pr)
        {
            ViewBag.Preguntas = BD.ListarPreguntas();
            return View();
        }
        public ActionResult InsertarPreguntas(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }

        public ActionResult FormPregunta(string Accion, int Id)
        {
            ViewBag.Preguntas = BD.ListarPreguntas();
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                Preguntas pr = BD.ObtenerPreguntas(Id);
                return View("EdicionPreguntas", pr);
            }
            else
            {
                if (Accion == "Eliminar")
                {
                    BD.EliminarPregunta(Id);
                   
                    return View("ABMPreguntas");
                }
            }
            return View("EdicionPreguntas");
        }
        [HttpPost]
        public ActionResult EdicionPreguntas(Preguntas pr, string Accion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Preguntas = BD.ListarPreguntas();
                return View("ABMPreguntas");
            }
            else
            {
                if (Accion == "Obtener")
                {
                    BD.ModificarPregunta(pr);
                    ViewBag.Preguntas = BD.ListarPreguntas();
                    return View("ABMPreguntas");
                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarPregunta(pr);
                        ViewBag.Preguntas = BD.ListarPreguntas();
                        return View("ABMPreguntas");
                    }
                }
                ViewBag.Preguntas = BD.ListarPreguntas();
                return View("ABMPreguntas");
            }

        }
         
    }
}