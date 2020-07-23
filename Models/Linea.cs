using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPA.Models
{
    public class Linea
    {
        public int IdEmpresa { get; set; }
        public int IdLinea { get; set; }
        public string Descripcion { get; set; }
        public string CodigoCTP { get; set; }
        public char Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public bool Estado { get; set; }
        
    }
}