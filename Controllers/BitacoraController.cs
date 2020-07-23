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
    public class BitacoraController : Controller
    {
        clsBitacora ObjBitacora = new clsBitacora();

        // GET: Bitacora
        public ActionResult Index()
        {
            try
            {
                var dato = ObjBitacora.ConsultarBitacora();

                List<Bitacora> ListaBitacoras = new List<Bitacora>();

                foreach (var item in dato)

                {
                    Bitacora bitacora = new Bitacora();

                    bitacora.IdBitacora = item.IdBitacora;
                    bitacora.Controlador = item.Controlador;
                    bitacora.Accion = item.Accion;
                    bitacora.Error = item.Error;
                    bitacora.Tipo = item.Tipo;
                    bitacora.Fecha = item.Fecha;
                    bitacora.IdUsuario = item.IdUsuario;


                    ListaBitacoras.Add(bitacora);

                }
                return View(ListaBitacoras);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Bitacora");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Bitacoras = ObjBitacora.ConsultarBitacora();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Bitacora");
            }
        }
        [HttpPost]
        public ActionResult Crear(Bitacora bitacora)
        {
            try
            {



                if (ObjBitacora.CrearBitacora(bitacora.Controlador, bitacora.Accion, bitacora.Error, bitacora.Tipo, bitacora.Fecha, bitacora.IdUsuario ))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Bitacoras = ObjBitacora.ConsultarBitacora();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Bitacora");
            }
        }
        public ActionResult Editar(int IdBitacora, int IdUsuario)
        {
            try
            {


                var dato = ObjBitacora.ConsultaBitacora(IdBitacora);

                Bitacora bitacora = new Bitacora();

                bitacora.IdBitacora = dato.IdBitacora;
                bitacora.Controlador = dato.Controlador;
                bitacora.Accion = dato.Accion;
                bitacora.Error = dato.Error;
                bitacora.Tipo = dato.Tipo;
                bitacora.Fecha = dato.Fecha;
                bitacora.IdUsuario = dato.IdUsuario;

                ViewBag.Bitacoras = ObjBitacora.ConsultarBitacora();

                return View(bitacora);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Bitacora");

            }

        }
        [HttpPost]
        public ActionResult Editar(Bitacora bitacora)
        {
            try
            {


                if (ObjBitacora.ActualizaBitacora(bitacora.IdBitacora, bitacora.Controlador, bitacora.Accion, bitacora.Error,
                    bitacora.Tipo,bitacora.Fecha, bitacora.IdUsuario))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Bitacoras = ObjBitacora.ConsultarBitacora();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar la Bitacaora");

            }
        }
        public ActionResult Eliminar(int IdBitacora, int IdUsuario)
        {
            try
            {
                var dato = ObjBitacora.ConsultaBitacora(IdBitacora);

                Bitacora bitacora = new Bitacora();

                 bitacora.IdBitacora = dato.IdBitacora;
                bitacora.Controlador = dato.Controlador;
                bitacora.Accion = dato.Accion;
                bitacora.Error = dato.Error;
                bitacora.Tipo = dato.Tipo;
                bitacora.Fecha = dato.Fecha;
                bitacora.IdUsuario = dato.IdUsuario;



                ViewBag.Bitacoras = ObjBitacora.ConsultarBitacora();

                return View(bitacora);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Bitacora");
            }
        }
        [HttpPost]
        public ActionResult Eliminar( Bitacora bitacora)
        {
            try
            {


                if (ObjBitacora.EliminaBitacora(bitacora.IdBitacora))
                {
                    return RedirectToAction("Index");
                }

                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Bitacora");
            }
        }
    }

}