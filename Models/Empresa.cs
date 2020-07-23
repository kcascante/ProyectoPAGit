using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public bool Estado { get; set; }

    }
}