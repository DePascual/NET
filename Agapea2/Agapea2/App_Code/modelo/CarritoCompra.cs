using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agapea2.App_Code.modelo
{
    public class CarritoCompra
    {
        /*El carrito de la compra tiene:
            1. Una lista de Libros, donde iré almacenando todos los id de los libros, que serán sus ISBN10 
            2. El valor de la compra total
            3. La fecha de la compra, que será la actual. Me servirá para buscar compras pasada y ordenarlas
        */

        public List<string> idLibro { get; set; }
        public List<decimal> valoresLibros { get; set; }
        public string fechaCompra { get; set; }

    }
}