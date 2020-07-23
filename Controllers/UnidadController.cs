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
    public class UnidadController : Controller  
    {
        /*clsLinea ObjLinea = new clsLinea();
        clsEmpresa ObjEmpresa = new clsEmpresa();*/
        clsUnidad ObjUnidad = new clsUnidad();
        // GET: Unidad
        public ActionResult Index()
        {
            try
            {
                var dato = ObjUnidad.ConsultarUnidad();

                List<Unidad> ListaUnidades = new List<Unidad>();

                foreach (var item in dato)
                                          
                {
                    Unidad unidad = new Unidad();

                    unidad.IdUnidad = item.IdUnidad;
                    unidad.Descripcion = item.Descripcion;
                    unidad.IdTipoPlaca = item.IdTipoPlaca;
                    unidad.Placa = item.Placa;
                    unidad.Estado = item.Estado;
                    
                    ListaUnidades.Add(unidad);

                }
                return View(ListaUnidades);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar las Unidades");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Unidades = ObjUnidad.ConsultarUnidad();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Unidad");
            }
        }
        [HttpPost]
        public ActionResult Crear(Unidad unidad)
        {
            try
            {



                if (ObjUnidad.CrearUnidad( unidad.Descripcion, unidad.IdTipoPlaca, unidad.Placa, unidad.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Unidades = ObjUnidad.ConsultarUnidad();
                   
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la unidad");
            }
        }
        public ActionResult Editar(int IdUnidad)
        {                                                                       
            try
            {


                var dato = ObjUnidad.ConsultaUnidad( IdUnidad);

                Unidad unidad = new Unidad();

                unidad.IdUnidad = dato.IdUnidad;
                unidad.Descripcion = dato.Descripcion;
                unidad.IdTipoPlaca = dato.IdTipoPlaca;
                unidad.Placa = dato.Placa;
                unidad.Estado = dato.Estado;

                ViewBag.Unidades = ObjUnidad.ConsultarUnidad();

                return View(unidad);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Unidad");

            }

        }
        [HttpPost]
        public ActionResult Editar(Unidad unidad)
        {
            try
            {
               

                if (ObjUnidad.ActualizaUnidad(unidad.IdUnidad,unidad.Descripcion, unidad.IdTipoPlaca, unidad.Placa, unidad.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Unidades = ObjUnidad.ConsultarUnidad();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Unidad");

            }
        }
        public ActionResult Eliminar(int IdUnidad)
        {
            try
            {
                var dato = ObjUnidad.ConsultaUnidad(IdUnidad);

                Unidad unidad = new Unidad();//Aquí se crea un objeto individual para llenar la lista linea a linea

                unidad.IdUnidad = dato.IdUnidad;
                unidad.Descripcion = dato.Descripcion;
                unidad.IdTipoPlaca = dato.IdTipoPlaca;
                unidad.Placa = dato.Placa;
                unidad.Estado = dato.Estado;


                ViewBag.Unidades = ObjUnidad.ConsultarUnidad();

                return View(unidad);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Unidad");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Unidad unidad)
        {
            try
            {
                

                if (ObjUnidad.EliminaUnidad(unidad.IdUnidad, unidad.Placa))
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


 