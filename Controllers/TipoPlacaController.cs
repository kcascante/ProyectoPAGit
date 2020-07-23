using BLL;
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
    public class TipoPlacaController : Controller
    {
        clsTipoPlaca ObjTipoPlaca = new clsTipoPlaca();
        // GET: TipoPlaca
        public ActionResult Index()
        {
            try
            {
                var dato = ObjTipoPlaca.ConsultarTipoPlaca();

                List<TipoPlaca> ListaTipoPlacas = new List<TipoPlaca>();

                foreach (var item in dato)

                {
                    TipoPlaca tipoplaca = new TipoPlaca();

                    tipoplaca.IdTipoPlaca = item.IdTipoPlaca;
                    tipoplaca.Descripcion = item.Descripcion;
                    tipoplaca.Estado = item.Estado;


                    ListaTipoPlacas.Add(tipoplaca);

                }
                return View(ListaTipoPlacas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los Tipos de Placas");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.TipoPlacas = ObjTipoPlaca.ConsultarTipoPlaca();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar  los Tipos de Placa ");
            }
        }
        [HttpPost]
        public ActionResult Crear(TipoPlaca tipoPlaca)
        {
            try
            {



                if (ObjTipoPlaca.CrearTipoPlaca(tipoPlaca.Descripcion, tipoPlaca.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoPlacas = ObjTipoPlaca.ConsultarTipoPlaca();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Tipo Placa");
            }
        }
        public ActionResult Editar(int IdTipoPlaca)
        {
            try
            {


                var dato = ObjTipoPlaca.ConsultaTipoPlaca(IdTipoPlaca);

                TipoPlaca tipoPlaca = new TipoPlaca();

                tipoPlaca.IdTipoPlaca = dato.IdTipoPlaca;
                tipoPlaca.Descripcion= dato.Descripcion;
                tipoPlaca.Estado = dato.Estado;

                ViewBag.TipoPlaca = ObjTipoPlaca.ConsultarTipoPlaca();

                return View(tipoPlaca);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Tipo de Deposito");

            }

        }
        [HttpPost]
        public ActionResult Editar(TipoPlaca tipoPlaca)
        {
            try
            {


                if (ObjTipoPlaca.ActualizaTipoPlaca(tipoPlaca.IdTipoPlaca, tipoPlaca.Descripcion, tipoPlaca.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoPlacas = ObjTipoPlaca.ConsultarTipoPlaca();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar TipoPlaca");

            }
        }
        public ActionResult Eliminar(int IdTipoPlaca)
        {
            try
            {
                var dato = ObjTipoPlaca.ConsultaTipoPlaca(IdTipoPlaca);

                TipoPlaca tipoPlaca = new  TipoPlaca();

                tipoPlaca.IdTipoPlaca = dato.IdTipoPlaca;
                tipoPlaca.Descripcion = dato.Descripcion;
                tipoPlaca.Estado = dato.Estado;


                ViewBag.TipoPlacas = ObjTipoPlaca.ConsultarTipoPlaca();

                return View(tipoPlaca);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el TipoPlaca");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(TipoPlaca tipoPlaca)
        {
            try
            {


                if (ObjTipoPlaca.EliminaTipoPlaca(tipoPlaca.IdTipoPlaca))
                {
                    return RedirectToAction("Index");
                }

                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el TipoPlaca");
            }
        }
    }

}



