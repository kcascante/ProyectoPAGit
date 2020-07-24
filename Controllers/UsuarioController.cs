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
    public class UsuarioController : Controller
    {
        clsUsuario ObjUsuario= new clsUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            try
            {
                var dato = ObjUsuario.ConsultarUsuario();

                List<Usuario> ListaUsuarios = new List<Usuario>();

                foreach (var item in dato)

                {
                    Usuario usuario = new Usuario();

                    usuario.IdUsuario = item.IdUsuario;
                    usuario.Nombre_usuario = item.Nombre_usuario;
                    usuario.Apellido1_usuario = item.Apellido1_usuario;
                    usuario.Apellido2_usuario = item.Apellido2_usuario;
                    usuario.Fecha_nacimiento = item.Fecha_nacimiento;
                    usuario.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    usuario.Identificacion = item.Identificacion;
                    usuario.Correo = item.Correo;
                    usuario.Saldo = item.Saldo;
                    usuario.Telefono = item.Telefono;
                    usuario.Clave = item.Clave;
                    usuario.Estado = item.Estado;

                    ListaUsuarios.Add(usuario);

                }
                return View(ListaUsuarios);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los Usuarios");

            }
        }

        public ActionResult Crear()
        {
            try
            {
                ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                return View();
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar los Usuario");
            }
        }
        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
            try
            {



                if(ObjUsuario.CrearUsuario(usuario.Nombre_usuario, usuario.Apellido1_usuario, usuario.Apellido2_usuario,usuario.Fecha_nacimiento, usuario.IdTipoIdentificacion,
                    usuario.Identificacion, usuario.Correo, usuario.Saldo, usuario.Telefono,usuario.Clave, usuario.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                    return View();
                }
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Usuario");
            }
        }
        public ActionResult Editar(int IdUsuario)
        {
            try
            {


                var dato = ObjUsuario.ConsultaUsuario(IdUsuario);

                Usuario usuario = new Usuario();

                usuario.IdUsuario = dato.IdUsuario;
                usuario.Nombre_usuario = dato.Nombre_usuario;
                usuario.Apellido1_usuario = dato.Apellido1_usuario;
                usuario.Apellido2_usuario = dato.Apellido2_usuario;
                usuario.Fecha_nacimiento = dato.Fecha_nacimiento;
                usuario.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                usuario.Identificacion = dato.Identificacion;
                usuario.Correo = dato.Correo;
                usuario.Saldo = dato.Saldo;
                usuario.Telefono = dato.Telefono;
                usuario.Clave = dato.Clave;
                usuario.Estado = dato.Estado;

                ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();

                return View(usuario);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar el Usuario");

            }

        }
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            try
            {


                if (ObjUsuario.ActualizaUsuario(usuario.IdUsuario,usuario.Nombre_usuario,usuario.Apellido1_usuario,usuario.Apellido2_usuario,
                    usuario.Fecha_nacimiento,usuario.IdTipoIdentificacion,usuario.Identificacion,usuario.Correo,
                    usuario.Saldo,usuario.Telefono,usuario.Clave,usuario.Estado))
                {
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    //ViewBag.Usuarios = ObjUsuario.ConsultarUsuario();
                    return View();
                }
            }

            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al editar Usuario");

            }
        }
        public ActionResult Eliminar(int IdUsuario)
        {
            try
            {
                var dato = ObjUsuario.ConsultaUsuario(IdUsuario);

                Usuario usuario = new Usuario();

                usuario.IdUsuario = dato.IdUsuario;
                usuario.Nombre_usuario = dato.Nombre_usuario;
                usuario.Apellido1_usuario = dato.Apellido1_usuario;
                usuario.Apellido2_usuario = dato.Apellido2_usuario;
                usuario.Fecha_nacimiento = dato.Fecha_nacimiento;
                usuario.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                usuario.Identificacion = dato.Identificacion;
                usuario.Correo = dato.Correo;
                usuario.Saldo = dato.Saldo;
                usuario.Telefono = dato.Telefono;
                usuario.Clave = dato.Clave;
                usuario.Estado = dato.Estado;



                ViewBag.Unidades = ObjUsuario.ConsultarUsuario();

                return View(usuario);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult("Error al consultar Usuario");
            }
        }
        [HttpPost]
        public ActionResult Eliminar(Usuario usuario)
        {
            try
            {


                if (ObjUsuario.EliminaUsuario(usuario.IdUsuario))
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
                return new HttpNotFoundResult("Error al consultar el Usuario");
            }
        }
    }

}

