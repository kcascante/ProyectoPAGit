using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre_usuario { get; set; }
        public string Apellido1_usuario { get; set; }
        public string Apellido2_usuario { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public int IdTipoIdentificacion{ get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public decimal Saldo { get; set; }
        public string Telefono { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }

    }
}