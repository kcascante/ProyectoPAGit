using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Error { get; set; }
        public int Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }

    }
}
