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
            if (BD.isAdmin() == true)
            {
                return View();
            }
            else
            {
                return View("../QEQ/Login");
            }

        }

        public ActionResult ABMCategorias(Categorias ct)
        { //ver como asignar los personajes a las categorias
            //Llamar a una funcion que verifique que es administrador
            if (BD.isAdmin() == true)
            {
                ViewBag.Categorias = BD.ListarCategorias();
                return View();
            }
            else
            {
                return View("../QEQ/Login");
            }

        }

        public ActionResult InsertarCategorias(string Accion)
        {
            if (BD.isAdmin() == true)
            {
                ViewBag.Accion = Accion;
                return View();
            }
            else
            {
                return View("../QEQ/Login");
            }

        }

        public ActionResult FormCategoria(string Accion, int Id)
        {
            if (BD.isAdmin() == true)
            {
                ViewBag.Categorias = BD.ListarCategorias();
                ViewBag.Accion = Accion;
                if (Accion == "Obtener")
                {
                    if (!ModelState.IsValid)
                    {
                        return View("InsertarCategorias");
                    }
                    else
                    {
                        Categorias ct = BD.ObtenerCategorias(Id);
                        return View("EdicionCategoria", ct);
                    }
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
            else
            {
                return View("../QEQ/Login");
            }

        }
        [HttpPost]
        public ActionResult EdicionCategoria(Categorias ct, string Accion)
        {
            if (BD.isAdmin() == true)
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
                        if (!ModelState.IsValid)
                        {
                            ViewBag.Categorias = BD.ListarCategorias();
                            return View("EdicionCategoria");
                        }
                        else
                        {
                            BD.ModificarCategoria(ct);
                            ViewBag.Categorias = BD.ListarCategorias();
                            return View("ABMCategorias");
                        }
                    }
                    else
                    {
                        if (Accion == "Insertar")
                        {
                            if (!ModelState.IsValid)
                            {
                                ViewBag.Categorias = BD.ListarCategorias();
                                return View("InsertarCategorias");
                            }
                            else
                            {
                                BD.InsertarCategoria(ct);
                                ViewBag.Categorias = BD.ListarCategorias();
                                return View("ABMCategorias");
                            }
                        }
                    }
                    ViewBag.Categorias = BD.ListarCategorias();
                    return View("ABMCategorias");
                }
            }
            else
            {
                return View("../QEQ/Login");
            }

        }

        public ActionResult ABMPreguntas(Preguntas pr)
        {
            if (BD.isAdmin() == true)
            {
                ViewBag.Preguntas = BD.ListarPreguntas();
                return View();
            }
            else
            {
                return View("../QEQ/Login");
            }

        }
        public ActionResult InsertarPreguntas(string Accion)
        {
            if (BD.isAdmin() == true)
            {
                ViewBag.Accion = Accion;
                return View();
            }
            else
            {
                return View("../QEQ/Login");
            }

        }

        public ActionResult FormPregunta(string Accion, int Id)
        {
            if (BD.isAdmin() == true)
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
            else
            {
                return View("../QEQ/Login");
            }

        }
        [HttpPost]
        public ActionResult EdicionPreguntas(Preguntas pr, string Accion)
        { //ver como asignar las preguntas a los personajes
            if (BD.isAdmin() == true)
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
            else
            {
                return View("../QEQ/Login");
            }

        }




        public ActionResult ABMPersonajes(Personajes pe)
        {
            if (BD.isAdmin() == true)
            {
                ViewBag.Personajes = BD.ListarPersonajes();
                return View();
            }
            else
            {
                return View("../QEQ/Login");
            }

        }
        public ActionResult InsertarPersonajes(string Accion)
        {
            if (BD.isAdmin() == true)
            {
                ViewBag.Accion = Accion;
                return View();
            }
            else
            {
                return View("../QEQ/Login");
            }

        }

        public ActionResult FormPersonaje(string Accion, int Id)
        {
            if (BD.isAdmin() == true)
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
            else
            {
                return View("../QEQ/Login");
            }

        }
        [HttpPost]
        public ActionResult EdicionPersonajes(Personajes pe, string Accion)
        {
            if (BD.isAdmin() == true)
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

            else
            {
                return View("../QEQ/Login");
            }

            }

        } 
         
       
    }