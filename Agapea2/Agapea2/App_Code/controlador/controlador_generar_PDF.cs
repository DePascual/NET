using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Pdf;
using Agapea2.App_Code.modelo;
using System.Text;
using System.Threading.Tasks;

namespace Agapea2.App_Code.controlador
{
    public class controlador_generar_PDF
    {

        public PdfDocument CrearDocPDF(Usuario user, Dictionary<string, List<Libro>> coleccionLibrosCarrito)
        {
            String facturaHTML = GenerarFacturaEnHTML(coleccionLibrosCarrito);

            PdfDocument miFactura = new PdfDocument();
            Task generadorPDF = new Task(() => miFactura.LoadFromHTML(facturaHTML, false, true, true));
            generadorPDF.Start();

            coleccionLibrosCarrito.Keys.ToList().ForEach(delegate (string fecha)
            {
                
            });


            miFactura.SaveToFile(user.loginUsuario + "_" );
            //si en el pdf lo quiero grabar en un fichero en el servidor llamaria a miFactura.SaveToFile("nombre_fichero.pdf")
            generadorPDF.Wait(); //...nos aseguramos que el hilo acabe         
            return miFactura;

        }

        private String GenerarFacturaEnHTML(Dictionary<string, List<Libro>> coleccionLibrosCarrito)
        {
            StringBuilder midocHTML = new StringBuilder();
            midocHTML.Append("<html><head><title>FACTURA DE  CLIENTE</title></head>");
            midocHTML.Append("<body><img src='" + HttpContext.Current.Request.MapPath("/imagenes/encabezado_inicio.png"));
            midocHTML.Append("<table>");
            midocHTML.Append((from unLibro in coleccionLibrosCarrito.Select(z => z.Value)
                              select
                                "<tr>" +
                                "<td>" + unLibro.Select(x => x.titulo) + "</td>" +
                                "<td>" + unLibro.Select(x => x.autor) + "</td></td>").Single());
            midocHTML.Append("</table></body></html>");
            return midocHTML.ToString();
        }
    }
}