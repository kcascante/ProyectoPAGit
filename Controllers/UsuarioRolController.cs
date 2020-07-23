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
    public class UsuarioRolController : Controller
    {
        clsUsuarioRol ObjUsuarioRol = new clsUsuarioRol();

        // GET: UsuarioRol
        public ActionResult Index()
        {
            try
            {
                var dato = ObjUsuarioRol.ConsultarUsuarioRol();

                List<UsuarioRol> ListaUsuarioRoles = new List<UsuarioRol>();

                foreach (var item in dato)

                {
                    UsuarioRol usuariorol = new UsuarioRol();

                    usuariorol.IdUsuarioRol = item.IdUsuarioRol;
                    usuariorol.IdRol = item.IdRol;
                    usuariorol.IdUsuario = item.IdUsuario;


                    ListaUsuarioRoles.Add(usuariorol);

                }
                return View(ListaUsuarioRoles);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el UsuarioRoles");

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

        public ActionResult Consulta(int IdUsuarioRol)
        {
            try
            {


                var dato = ObjUsuarioRol.ConsultaUsuarioRol(IdUsuarioRol);

                UsuarioRol usuariorol = new UsuarioRol();

                usuariorol.IdUsuarioRol = dato.IdUsuarioRol;
                usuariorol.IdRol = dato.IdRol;
                usuariorol.IdUsuario = dato.IdUsuario;

                ViewBag.UsuarioRoles = ObjUsuarioRol.ConsultarUsuarioRol();

                return View(usuariorol);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el usuario Rol");

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


