using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUnidad { get; set; }
        public int IdUsuario { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public bool Estado { get; set; }

    }
}
