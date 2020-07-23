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
    public class TipoIdentificacionController : Controller
    {
        clsTipoIdentificacion ObjTipoIdentificacion= new clsTipoIdentificacion();
        // GET: TipoId
        public ActionResult Index()
        {
            try
            {
                var dato = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                List<TipoIdentificacion> ListaTipoIdentificaciones = new List<TipoIdentificacion>();

                foreach (var item in dato)

                {
                    TipoIdentificacion tipoidentificacion = new TipoIdentificacion();

                    tipoidentificacion.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    tipoidentificacion.Identificacion = item.Identificacion;
                    tipoidentificacion.Estado = item.Estado;

                    ListaTipoIdentificaciones.Add(tipoidentificacion);

                }
                return View(ListaTipoIdentificaciones);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los tipos de Identificacion");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Identificacion");
            }
        }
        [HttpPost]
        public ActionResult Crear(TipoIdentificacion tipoidentificacion)
        {
            try
            {



                if (ObjTipoIdentificacion.CrearTipoIdentificacion(tipoidentificacion.Identificacion, tipoidentificacion.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Unidades = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de Identificacion");
            }
        }
        public ActionResult Editar(int IdTipoIdentificacion)
        {
            try
            {


                var dato = ObjTipoIdentificacion.ConsultaTipoIdentificacion(IdTipoIdentificacion);

                TipoIdentificacion tipoidentificacion = new TipoIdentificacion();

                tipoidentificacion.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                tipoidentificacion.Identificacion = dato.Identificacion;
                tipoidentificacion.Estado = dato.Estado;

                ViewBag.TipoIdentificaciones= ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View(tipoidentificacion);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de identificacion");

            }

        }
        [HttpPost]
        public ActionResult Editar(TipoIdentificacion tipoidentificacion)
        {
            try
            {


                if (ObjTipoIdentificacion.ActualizaTipoIdentificacion(tipoidentificacion.IdTipoIdentificacion, tipoidentificacion.Identificacion, tipoidentificacion.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoIdentidicaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar EL  Tipo de Indentificacion");

            }
        }
        public ActionResult Eliminar(int IdTipoIdentificacion)
        {
            try
            {
                var dato = ObjTipoIdentificacion.ConsultaTipoIdentificacion(IdTipoIdentificacion);

                TipoIdentificacion tipoidentificacion = new TipoIdentificacion();//Aquí se crea un objeto individual para llenar la lista linea a linea

                tipoidentificacion.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                tipoidentificacion.Identificacion = dato.Identificacion;
                tipoidentificacion.Estado = dato.Estado;


                ViewBag.TipoIdentificaciones = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                return View(tipoidentificacion);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el tipo de Identificacion");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(TipoIdentificacion tipoidentificacion)
        {
            try
            {


                if (ObjTipoIdentificacion.EliminaTipoIdentificacion(tipoidentificacion.IdTipoIdentificacion))
                {
                    return RedirectToAction("Index");
                }
                //else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Unidad");
            }
        }
    }

}


