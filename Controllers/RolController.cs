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
    public class RolController : Controller
    {
        clsRol ObjRol = new clsRol();
        // GET: Rol
        public ActionResult Index()
        {
            try
            {
                var dato = ObjRol.ConsultarRol();

                List<Rol> ListaRoles = new List<Rol>();

                foreach (var item in dato)

                {
                    Rol rol = new Rol();

                    rol.IdRol = item.IdRol;
                    rol.Descripcion = item.Descripcion;
                    rol.Estado = item.Estado;

                    ListaRoles.Add(rol);

                }
                return View(ListaRoles);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los Roles");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Roles = ObjRol.ConsultarRol();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Rol");
            }
        }
        [HttpPost]
        public ActionResult Crear(Rol rol)
        {
            try
            {



                if (ObjRol.CrearRol(rol.Descripcion, rol.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Roles = ObjRol.ConsultarRol();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Rol");
            }
        }
        public ActionResult Editar(int IdRol)
        {
            try
            {


                var dato = ObjRol.ConsultaRol(IdRol);

                Rol rol = new Rol();

                rol.IdRol = dato.IdRol;
                rol.Descripcion = dato.Descripcion;
                rol.Estado = dato.Estado;

                ViewBag.Unidades = ObjRol.ConsultarRol();

                return View(rol);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Rol");

            }

        }
        [HttpPost]
        public ActionResult Editar(Rol rol)
        {
            try
            {


                if (ObjRol.ActualizaRol(rol.IdRol, rol.Descripcion,rol.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Rol = ObjRol.ConsultarRol();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Rol");

            }
        }
        public ActionResult Eliminar(int IdRol)
        {
            try
            {
                var dato = ObjRol.ConsultaRol(IdRol);

                Rol rol = new Rol();

                rol.IdRol = dato.IdRol;
                rol.Descripcion = dato.Descripcion;
                rol.Estado = dato.Estado;


                ViewBag.Roles = ObjRol.ConsultarRol();

                return View(rol);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Rol");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Rol rol)
        {
            try
            {


                if (ObjRol.EliminaRol(rol.IdRol))
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
                return new HttpNotFoundResult("Error al consultar el Rol");
            }
        }
    }

}



