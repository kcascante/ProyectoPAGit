using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Unidad
    {
        public int IdUnidad { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoPlaca { get; set; }
        public string Placa { get; set; }
        public bool Estado { get; set; }

    }
}