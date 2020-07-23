using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Tarifa
    {
        public int IdTarifa { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public bool Estado { get; set; }


    }
    
}