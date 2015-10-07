using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agapea.App_Code.modelo
{
    public class Libro
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string editorial { get; set; }
        public string categoria { get; set; }
        public long isbn10 { get; set; }
        public long isbn13 { get; set; }
        public float precio { get; set; }
        public int numeroPaginas { get; set; }
        public string resumen { get; set; }
        public int cantidadLibros { get; set; }

    }
}