using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using ProyectoPA.Models;

namespace ProyectoPA.Controllers
{
    public class LineaController : Controller
    {
        clsLinea ObjLinea = new clsLinea();
        clsEmpresa ObjEmpresa = new clsEmpresa();
        clsConsulta ObjConsulta = new clsConsulta();

        // GET: Linea
        public ActionResult Index()
        {
            try
            {
                Session["Empresa"] = 1;

                var datos = ObjLinea.ConsultarLinea(Convert.ToInt32(Session["Empresa"].ToString()));

                List<Linea> ListaLineas = new List<Linea>();//Aqui se hace un nuevo objeto de tipo Linea(donde Linea es el modelo)

                foreach (var item in datos)//el foreach requiere un segundo dato que es una coleccion y q en este caso se llama
                                           //datos q es donde el SP almacena la informacion
                {
                    Linea linea = new Linea();//Aquí se crea un objeto individual para llenar la lista linea a linea

                    linea.IdEmpresa = item.IdEmpresa;
                    linea.IdLinea = item.IdLinea;
                    linea.Descripcion = item.Descripcion;
                    linea.CodigoCTP = item.CodigoCTP;
                    linea.Provincia = (char)item.Provincia;
                    linea.Canton = item.Canton;
                    linea.Distrito = item.Distrito;
                    linea.Estado = item.Estado;

                    ListaLineas.Add(linea);

                }
                return View(ListaLineas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar las lineas");

            }

        }

        public ActionResult Editar(int IdLinea)
        {
            try
            {
                Session["Empresa"] = 1;

                var dato = ObjLinea.ConsultaLinea(Convert.ToInt32(Session["Empresa"].ToString()), IdLinea);

                Linea linea = new Linea();//Aquí se crea un objeto individual para llenar la lista linea a linea


                linea.IdEmpresa = dato.IdEmpresa;
                linea.IdLinea = dato.IdLinea;
                /* linea.NombreEmpresa = dato.NombreEmpresa;*/ //Esta linea de nombre empresa para editar no funciona
                linea.Descripcion = dato.Descripcion;
                linea.CodigoCTP = dato.CodigoCTP;
                linea.Provincia = (char)dato.Provincia;
                linea.Canton = dato.Canton;
                linea.Distrito = dato.Distrito;
                linea.Estado = dato.Estado;

                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();

                return View(linea);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");

            }

        }
        [HttpPost]
        public ActionResult Editar(Linea linea)
        {
            try
            {
                Session["Empresa"] = 1;

                if (ObjLinea.ActualizaLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.IdLinea,
                    linea.Descripcion, linea.CodigoCTP, linea.Provincia, linea.Canton, linea.Distrito, linea.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Linea");

            }
        }
        public ActionResult Crear()
        {
            try
            {
                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                ViewBag.Provincias = ObjConsulta.ListaProvincias();
                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");
            }
        }
        [HttpPost]
        public ActionResult Crear(Linea linea)
        {
            try
            {
                Session["Empresa"] = 1;

                if (ObjLinea.CrearLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.Descripcion, linea.CodigoCTP, linea.Provincia, linea.Canton, linea.Distrito, linea.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    ViewBag.Provincias = ObjConsulta.ListaProvincias();
                    ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                    ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");
            }
        }

    
        public ActionResult Eliminar(int id)
        {
            try
            {
                Session["Empresa"] = 1;

                var dato = ObjLinea.ConsultaLinea(Convert.ToInt32(Session["Empresa"].ToString()), id);

                Linea linea = new Linea();

                linea.IdEmpresa = dato.IdEmpresa;
                linea.IdLinea = dato.IdLinea;
                linea.Descripcion = dato.Descripcion;
                linea.CodigoCTP = dato.CodigoCTP;
                linea.Provincia = (char)dato.Provincia;
                linea.Canton = dato.Canton;
                linea.Distrito = dato.Distrito;
                linea.Estado = dato.Estado;

                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();

                return View(linea);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Linea linea)
        {
            try
            {
                Session["Empresa"] = 1;

                if (ObjLinea.EliminaLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.IdLinea))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea");
            }
        }
        /// <summary>
        /// Cargar Cantones hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaCantones(char provincia)
        {
            List<CantonesResult> cantones = ObjConsulta.ListaCantones(provincia);
            return Json(cantones, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Cargar Disttritos hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        [HttpPost]
            public JsonResult CargaDistritos(char provincia, string canton)
            {
                List<DistritosResult> distritos = ObjConsulta.ListaDistritos(provincia, canton);
                return Json(distritos, JsonRequestBehavior.AllowGet);
            }
        }

    }