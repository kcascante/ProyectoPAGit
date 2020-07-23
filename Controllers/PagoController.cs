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
    public class PagoController : Controller
    {
        clsPago ObjPago = new clsPago();

        // GET: Pago
        public ActionResult Index()
        {
            try
            {
                var dato = ObjPago.ConsultarPago();

                List<Pago> ListaPagos = new List<Pago>();

                foreach (var item in dato)

                {
                    Pago pago = new Pago();

                    pago.IdPago = item.IdPago;
                    pago.IdEmpresa = item.IdEmpresa;
                    pago.IdUnidad = item.IdUnidad;
                    pago.IdUsuario = item.IdUsuario;
                    pago.Monto = item.Monto;
                    pago.Fecha = item.Fecha;
                    pago.Latitud = Convert.ToDecimal(item.Latitud);
                    pago.Longitud = Convert.ToDecimal(item.Longitud);
                    pago.Estado = item.Estado;



                    ListaPagos.Add(pago);

                }
                return View(ListaPagos);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Lista de Pagos");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Pagos = ObjPago.ConsultarPago();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar  Pago ");
            }
        }
        [HttpPost]
        public ActionResult Crear(Pago pago)
        {
            try
            {



                if (ObjPago.CrearPago(pago.IdEmpresa, pago.IdUnidad, pago.IdUsuario, pago.Monto, pago.Fecha, pago.Latitud, pago.Longitud, pago.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Pagos= ObjPago.ConsultarPago();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Pago");
            }
        }
        public ActionResult Editar(int IdPago)
        {
            try
            {

                
                var dato = ObjPago.ConsultaPago(IdPago);

                Pago pago = new Pago();

                pago.IdPago = dato.IdPago;
                pago.IdEmpresa = dato.IdEmpresa;
                pago.IdUnidad = dato.IdUnidad;
                pago.IdUsuario = dato.IdUsuario;
                pago.Monto = dato.Monto;
                pago.Fecha = dato.Fecha;
                pago.Latitud = Convert.ToDecimal(dato.Latitud);
                pago.Longitud = Convert.ToDecimal(dato.Longitud);
                pago.Estado = dato.Estado;

                ViewBag.Pago = ObjPago.ConsultarPago();

                return View(pago);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Pago");

            }

        }
        [HttpPost]
        public ActionResult Editar(Pago pago)
        {
            try
            {


                if (ObjPago.ActualizaPago(pago.IdPago, pago.IdEmpresa, pago.IdUnidad, pago.IdUsuario, pago.Monto, pago.Fecha, pago.Latitud, pago.Longitud, pago.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Pagos = ObjPago.ConsultarPago();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Pago");

            }
        }
        public ActionResult Eliminar(int IdPago)
        {
            try
            {
                var dato = ObjPago.ConsultaPago(IdPago);

                Pago pago = new Pago();

                pago.IdPago = dato.IdPago;
                pago.IdEmpresa = dato.IdEmpresa;
                pago.IdUnidad = dato.IdUnidad;
                pago.IdUsuario = dato.IdUsuario;
                pago.Monto = dato.Monto;
                pago.Fecha = dato.Fecha;
                pago.Latitud = Convert.ToDecimal(dato.Latitud);
                pago.Longitud = Convert.ToDecimal(dato.Longitud);
                pago.Estado = dato.Estado;


                ViewBag.pagos = ObjPago.ConsultarPago();

                return View(pago);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Pago");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Pago pago)
        {
            try
            {


                if (ObjPago.EliminaPago(pago.IdPago))
                {
                    return RedirectToAction("Index");
                }

                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Pago");
            }
        }
    }

}



