using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Deposito
    {
        public int IdDeposito { get; set; }
        public int IdUsuario { get; set; }
        public string Telefono { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
