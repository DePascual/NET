using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Agapea2.App_Code.modelo
{
    public class Usuario
    {
        public String nombreUsuario { get; set; }
        public String apellidoUsuario { get; set; }
        public String emailUsuario { get; set; }
        public String loginUsuario { get; set; }
        public String passwordUsuario { get; set; }
        public List<CarritoCompra> comprasUsuario { get; set; }
    }
}