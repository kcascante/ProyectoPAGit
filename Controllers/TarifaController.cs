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
    public class TarifaController : Controller
    {
        clsTarifa ObjTarifa = new clsTarifa();
        // GET: Tarifa
        public ActionResult Index()
        {
            try
            {
                var dato = ObjTarifa.ConsultarTarifa();

                List<Tarifa> ListaTarifas = new List<Tarifa>();

                foreach (var item in dato)

                {
                    Tarifa tarifa = new Tarifa();

                    tarifa.IdTarifa = item.IdTarifa;
                    tarifa.IdEmpresa = item.IdEmpresa;
                    tarifa.Descripcion = item.Descripcion;
                    tarifa.Monto = item.Monto;
                    tarifa.Estado = item.Estado;

                    ListaTarifas.Add(tarifa);

                }
                return View(ListaTarifas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los Tipos de tarifas");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Tarifas = ObjTarifa.ConsultarTarifa();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los Tipos de tarifas");
            }
        }
        [HttpPost]
        public ActionResult Crear(Tarifa tarifa)
        {
            try
            {



                if (ObjTarifa.CrearTarifa(tarifa.IdEmpresa,tarifa.Descripcion,tarifa.Monto, tarifa.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Tarifas = ObjTarifa.ConsultarTarifa();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la tarifa");
            }
        }
        public ActionResult Editar(int IdTarifa)
        {
            try
            {


                var dato = ObjTarifa.ConsultaTarifa(IdTarifa);

                Tarifa tarifa = new Tarifa();

                tarifa.IdTarifa = dato.IdTarifa;
                tarifa.IdEmpresa = dato.IdEmpresa;
                tarifa.Descripcion = dato.Descripcion;
                tarifa.Monto = dato.Monto;
                tarifa.Estado = dato.Estado;

                ViewBag.Tarifa = ObjTarifa.ConsultarTarifa();

                return View(tarifa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la tarifa");

            }

        }
        [HttpPost]
        public ActionResult Editar(Tarifa tarifa)
        {
            try
            {


                if (ObjTarifa.ActualizaTarifa(tarifa.IdTarifa,tarifa.IdEmpresa, tarifa.Descripcion, tarifa.Monto, tarifa.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Unidades = ObjTarifa.ConsultarTarifa();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Tarifa");

            }
        }
        public ActionResult Eliminar(int IdTarifa)
        {
            try
            {
                var dato = ObjTarifa.ConsultaTarifa(IdTarifa);

                Tarifa tarifa = new Tarifa();

                tarifa.IdTarifa = dato.IdTarifa;
                tarifa.IdEmpresa = dato.IdEmpresa;
                tarifa.Descripcion = dato.Descripcion;
                tarifa.Monto = dato.Monto;
                tarifa.Estado = dato.Estado;



                ViewBag.Unidades = ObjTarifa.ConsultarTarifa();

                return View(tarifa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Tarifa");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Tarifa tarifa)
        {
            try
            {


                if (ObjTarifa.EliminaTarifa(tarifa.IdTarifa, tarifa.IdEmpresa))
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
                return new HttpNotFoundResult("Error al consultar la tarifa");
            }
        }
    }

}


