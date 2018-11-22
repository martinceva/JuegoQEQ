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
        { //ver como asignar los personajes a las categorias
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
        { //ver como asignar las preguntas a los personajes
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

        
         public ActionResult ABMPersonajes(Personajes pe)
        {
            ViewBag.Personajes = BD.ListarPersonajes();
            return View();
        }
        public ActionResult InsertarPersonajes(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }

        public ActionResult FormPersonaje(string Accion, int Id)
        {
            ViewBag.Preguntas = BD.ListarPersonajes();
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                Personajes pe = BD.ObtenerPersonajes(Id);
                return View("EdicionPersonajes", pe);
            }
            else
            {
                if (Accion == "Eliminar")
                {
                    BD.EliminarPersonaje(Id);
                   
                    return View("ABMPersonajes");
                }
            }
            return View("EdicionPersonajes");
        }
        [HttpPost]
        public ActionResult EdicionPersonajes(Personajes pe, string Accion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Personajes = BD.ListarPersonajes();
                return View("ABMPersonajes");
            }
            else
            {
                if (Accion == "Obtener")
                {
                    BD.ModificarPersonaje(pe);
                    ViewBag.Personajes = BD.ListarPersonajes();
                    return View("ABMPersonajes");
                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarPersonajes(pe);
                        ViewBag.Personajes = BD.ListarPersonajes();
                        return View("ABMPersonajes");
                    }
                }
                ViewBag.Personajes = BD.ListarPersonajes();
                return View("ABMPersonajes");
            }

        }
         

    }
}