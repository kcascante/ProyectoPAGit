
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
    public class LineaUnidadController : Controller
    {
        clsLineaUnidad ObjLineaUnidad = new clsLineaUnidad();
        // GET: LineaUnidad
        public ActionResult Index()
        {
            try
            {
                var dato = ObjLineaUnidad.ConsultarLineaUnidad();

                List<LineaUnidad> ListaLineaUnidades = new List<LineaUnidad>();

                foreach (var item in dato)

                {
                    LineaUnidad lineaunidad = new LineaUnidad();

                    lineaunidad.IdLineaUnidad = item.IdLineaUnidad;
                    lineaunidad.IdUnidad = item.IdUnidad;
                    lineaunidad.IdLinea = item.IdLinea;


                    ListaLineaUnidades.Add(lineaunidad);

                }
                return View(ListaLineaUnidades);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la linea Unidad");

            }
        }

        //public ActionResult Crear()
        //{
        //    try
        //    {
        //        ViewBag.LineaTarifas = ObjLineaTarifa.ConsultarLineaTarifa();

        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpNotFoundResult("Error al consultar la linea Tarifa");
        //    }
        //}
        //public ActionResult Crear(Deposito deposito)
        //{
        //    try
        //    {



        //        if (ObjDeposito.CrearDeposito(deposito.IdUsuario, deposito.Telefono, deposito.Monto, deposito.Fecha, deposito.Estado))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.Depositos = ObjDeposito.ConsultarDeposito();

        //            return View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpNotFoundResult("Error al consultar el Deposito");
        //    }
        //}
        //[HttpPost]

        public ActionResult Consulta(int IdLineaUnidad)
        {
            try
            {


                var dato = ObjLineaUnidad.ConsultaLineaUnidad(IdLineaUnidad);

                LineaUnidad lineaunidad = new LineaUnidad();

                lineaunidad.IdLineaUnidad = dato.IdLineaUnidad;
                lineaunidad.IdUnidad = dato.IdUnidad;
                lineaunidad.IdLinea = dato.IdLinea;

                ViewBag.LineaUnidades = ObjLineaUnidad.ConsultarLineaUnidad();

                return View(lineaunidad);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Linea Unidad");

            }

        }
        //[HttpPost]
        //public ActionResult Editar(Deposito deposito)
        //{
        //    try
        //    {


        //        if (ObjDeposito.ActualizaDeposito(deposito.IdDeposito, deposito.IdUsuario, deposito.Telefono, deposito.Monto, deposito.Fecha, deposito.Estado))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.Depositos = ObjDeposito.ConsultarDeposito();
        //            return View();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        return new HttpNotFoundResult("Error al editar Deposito");

        //    }
        //}
        //public ActionResult Eliminar(int IdLineaTarifa)
        //{
        //    try
        //    {
        //        var dato = ObjLineaTarifa.ConsultaLineaTarifa(IdLineaTarifa);

        //         LineaTarifa lineaTarifa = new LineaTarifa();

        //        lineaTarifa.IdLineaTarifa = dato.IdLineaTarifa;
        //        lineaTarifa.IdLinea = dato.IdLinea;
        //        lineaTarifa.IdTarifa = dato.IdTarifa;


        //        ViewBag.LineaTarifas = ObjLineaTarifa.ConsultarLineaTarifa();

        //        return View(lineaTarifa);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpNotFoundResult("Error al consultar la Linea Tarifa");
        //    }
        //}
        //[HttpPost]
        ////public ActionResult Eliminar(Deposito deposito)
        //{
        //    try
        //    {


        //        if (ObjDeposito.EliminaDeposito(deposito.IdDeposito))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        //else
        //        {
        //            return View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpNotFoundResult("Error al consultar el Deposito");
        //    }
        //}
    }

}


