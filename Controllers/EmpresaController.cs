using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using ProyectoPA.Models;

namespace ProyectoPA.Controllers
{
    public class EmpresaController : Controller
    {
        clsEmpresa ObjEmpresa = new clsEmpresa();
        
        // GET: Empresa
        public ActionResult Index()
        {
            try
            {
                var dato = ObjEmpresa.ConsultarEmpresa();

                List<Empresa> ListaEmpresas = new List<Empresa>();//Aqui se hace un nuevo objeto de tipo lista de tipo linea(donde linea es la clase de BLL)

                foreach (var item in dato)//el foreach requiere un segundo dato que es una coleccion y q en este caso se llama
                                           //datos q es donde el SP almacena la informacion
                {
                    Empresa empresa = new Empresa();//Aquí se crea un objeto individual para llenar la lista linea a linea

                    empresa.IdEmpresa = item.IdEmpresa;
                    empresa.NombreEmpresa = item.NombreEmpresa;
                    empresa.Descripcion = item.Descripcion;
                    empresa.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    empresa.Identificacion = item.Identificacion;
                    empresa.Telefono = item.Telefono;
                    empresa.Contacto = item.Contacto;
                    empresa.Estado = item.Estado;

                    ListaEmpresas.Add(empresa);

                }
                return View(ListaEmpresas);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar las lineas");

            }

        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                
                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Empresa");
            }
        }
        [HttpPost]
        public ActionResult Crear(Empresa empresa)
        {
            try
            {
                //Session["Empresa"] = 1;

                if (ObjEmpresa.CrearEmpresa( 
                    empresa.NombreEmpresa,empresa.Descripcion,empresa.IdTipoIdentificacion,
                    empresa.Identificacion,empresa.Telefono,empresa.Contacto, empresa.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la empresa");
            }
        }




        // GET: Empresa/Edit/5
        public ActionResult Editar(int id)
        {
            try
            {
                Session["Empresa"] = 1;

                var dato = ObjEmpresa.ConsultaEmpresa(Convert.ToInt32(Session["Empresa"].ToString()));

                Empresa empresa = new Empresa();//Aquí se crea un objeto individual para llenar la lista linea a linea

                empresa.IdEmpresa = dato.IdEmpresa;
                empresa.NombreEmpresa = dato.NombreEmpresa;
                empresa.Descripcion = dato.Descripcion;
                empresa.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                empresa.Identificacion = dato.Identificacion;
                empresa.Telefono = dato.Telefono;
                empresa.Contacto = dato.Contacto;
                empresa.Estado = dato.Estado;

                
                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();

                return View(empresa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Empresa");

            }

        }
        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {
            try
            {
                Session["Empresa"] = 1;

                if (ObjEmpresa.ActualizaEmpresa(Convert.ToInt32(Session["Empresa"].ToString()),
                    empresa.NombreEmpresa,empresa.Descripcion, empresa.IdTipoIdentificacion, empresa.Identificacion,
                    empresa.Telefono, empresa.Contacto, empresa.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Linea");

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                Session["Empresa"] = 1;

                var dato = ObjEmpresa.ConsultaEmpresa(Convert.ToInt32(Session["Empresa"].ToString()));

                Empresa empresa = new Empresa();//Aquí se crea un objeto individual para llenar la lista linea a linea

                empresa.IdEmpresa = dato.IdEmpresa;
                empresa.NombreEmpresa = dato.NombreEmpresa;
                empresa.Descripcion = dato.Descripcion;
                empresa.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                empresa.Identificacion = dato.Identificacion;
                empresa.Telefono = dato.Telefono;
                empresa.Contacto = dato.Contacto;
                empresa.Estado = dato.Estado;


                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();

                return View(empresa);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Empresa");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Empresa empresa)
        {
            try
            {
                Session["Empresa"] = 1;

                if (ObjEmpresa.EliminaEmpresa(Convert.ToInt32(Session["Empresa"].ToString()), empresa.IdEmpresa))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar la Empresa");
            }
        }
    }
    
}
