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
    public class DepositoController : Controller
    {
        clsDeposito ObjDeposito = new clsDeposito();
        // GET: Deposito
        public ActionResult Index()
        {
            try
            {
                var dato = ObjDeposito.ConsultarDeposito();

                List<Deposito> ListaDepositos= new List<Deposito>();

                foreach (var item in dato)

                {
                    Deposito deposito = new Deposito();

                    deposito.IdDeposito = item.IdDeposito;
                    deposito.IdUsuario = item.IdUsuario;
                    deposito.Telefono = item.Telefono;
                    deposito.Monto= item.Monto;
                    deposito.Fecha = item.Fecha;
                    deposito.Estado = item.Estado; 
                    

                    ListaDepositos.Add(deposito);

                }
                return View(ListaDepositos);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los Depositos");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Depositos = ObjDeposito.ConsultarDeposito();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Deposito");
            }
        }
        [HttpPost]
        public ActionResult Crear(Deposito deposito)
        {
            try
            {



                if (ObjDeposito.CrearDeposito(deposito.IdUsuario, deposito.Telefono, deposito.Monto, deposito.Fecha, deposito.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Depositos= ObjDeposito.ConsultarDeposito();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Deposito");
            }
        }
        public ActionResult Editar(int IdDeposito, int IdUsuario)
        {
            try
            {


                var dato = ObjDeposito.ConsultaDeposito(IdDeposito, IdUsuario);

                Deposito deposito = new Deposito();

                deposito.IdDeposito = dato.IdDeposito;
                deposito.IdUsuario = dato.IdUsuario;
                deposito.Telefono = dato.Telefono;
                deposito.Monto = dato.Monto;
                deposito.Fecha = dato.Fecha;
                deposito.Estado = dato.Estado;

                ViewBag.Depositos = ObjDeposito.ConsultarDeposito();

                return View(deposito);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Deposito");

            }

        }
        [HttpPost]
        public ActionResult Editar(Deposito deposito)
        {
            try
            {


                if (ObjDeposito.ActualizaDeposito(deposito.IdDeposito, deposito.IdUsuario,deposito.Telefono, deposito.Monto, deposito.Fecha, deposito.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Depositos = ObjDeposito.ConsultarDeposito();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Deposito");

            }
        }
        public ActionResult Eliminar(int IdDeposito, int IdUsuario)
        {
            try
            {
                var dato = ObjDeposito.ConsultaDeposito(IdDeposito, IdUsuario);

                Deposito deposito = new Deposito();

                deposito.IdDeposito = dato.IdDeposito;
                deposito.IdUsuario = dato.IdUsuario;
                deposito.Telefono = dato.Telefono;
                deposito.Monto = dato.Monto;
                deposito.Fecha = dato.Fecha;
                deposito.Estado = dato.Estado;


                ViewBag.Depositos = ObjDeposito.ConsultarDeposito();

                return View(deposito);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Deposito");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Deposito deposito)
        {
            try
            {


                if (ObjDeposito.EliminaDeposito(deposito.IdDeposito))
                {
                    return RedirectToAction("Index");
                }
                
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Deposito");
            }
        }
    }

}


