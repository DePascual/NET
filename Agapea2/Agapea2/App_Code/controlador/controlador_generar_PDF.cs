using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Pdf;
using Agapea2.App_Code.modelo;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf.HtmlConverter;
using System.Threading;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Collections.Specialized;


namespace Agapea2.App_Code.controlador
{
    public class controlador_generar_PDF
    {
        //public PdfDocument CrearDocPDF(string rutaFichero, Usuario user, Dictionary<string, List<Libro>> coleccionLibrosCarrito)
        //{
        //    String facturaHTML = GenerarFacturaEnHTML(rutaFichero + "imagenes/", coleccionLibrosCarrito.Values.ElementAt(0));

        //    //PdfDocument miFactura = new PdfDocument();

        //    System.Threading.Thread thread = new System.Threading.Thread(() =>
        //    {
        //        PdfDocument fact = new PdfDocument();

        //        fact.LoadFromHTML(facturaHTML, true, true, false);
        //        fact.SaveToFile("C:/Users/karol/Desktop/facturas/" + user.loginUsuario + "_" + coleccionLibrosCarrito.Keys.ToString() + ".pdf");
        //    });
        //    thread.SetApartmentState(System.Threading.ApartmentState.STA);
        //    thread.Start();
        //    return null;
        //    /*
        //    Task<PdfDocument> generadorPDF = Task.Factory.StartNew<PdfDocument>((stringHTML) =>
        //    {
        //        string factHTML = (string)stringHTML;
        //        PdfDocument fact = new PdfDocument();
        //        fact.LoadFromHTML(factHTML,true,true,false);
        //        return fact;

        //    }, facturaHTML, 
        //       System.Threading.CancellationToken.None, 
        //       TaskCreationOptions.None , 
        //       TaskScheduler.FromCurrentSynchronizationContext());

        //    //generadorPDF.Start();
        //    generadorPDF.Wait(); //...nos aseguramos que el hilo acabe         

        //    generadorPDF.Result.SaveToFile("C:/Users/karol/Desktop/facturas/" + user.loginUsuario + "_" + coleccionLibrosCarrito.Keys.ToString() + ".pdf"); //("CAROLINA_13/11/2015_15:10:25.pdf")

        //    //si en el pdf lo quiero grabar en un fichero en el servidor llamaria a miFactura.SaveToFile("nombre_fichero.pdf")

        //    return generadorPDF.Result;
        //    */

        //}

        public PdfDocument CrearDocPDF(string rutaFichero, Usuario user, Dictionary<string, List<Libro>> coleccionLibrosCarrito, string infoCookieLibros)
        {
            PdfDocument miFactura = new PdfDocument();

            PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat();

            htmlLayoutFormat.IsWaiting = false;

            PdfPageSettings setting = new PdfPageSettings();
            setting.Size = PdfPageSize.A4;

            //String facturaHTML = File.ReadAllText(rutaFichero + "PlantillaFactura.html");
            String facturaHTML = GenerarFacturaEnHTML(rutaFichero + "imagenes/", coleccionLibrosCarrito.Values.ElementAt(0), user, infoCookieLibros);

            List<string> nombreKey = coleccionLibrosCarrito.Keys.ToList();
            string keyString = "";
            foreach (string key in nombreKey)
            {
                keyString = key;
                keyString = keyString.Replace('/', '_').Replace(' ', '_').Replace(':', '_');
            }

            Thread thread = new Thread(() =>
            {
                miFactura.LoadFromHTML(facturaHTML, false, setting, htmlLayoutFormat);
                //miFactura.LoadFromHTML(facturaHTML, false, true, true);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            //string filePath = rutaFichero + "facturas/" + user.loginUsuario + keyString + ".pdf";

            //if (!File.Exists(filePath))
            //{
            //    FileStream f = File.Create(filePath);
            //    f.Close();
            //}
            try
            {
                miFactura.SaveToFile(rutaFichero + "facturas/" + user.loginUsuario + keyString + ".pdf");
            }
            catch (Exception e)
            {

            }


            //System.Diagnostics.Process.Start(rutaFichero + "facturas/" + user.loginUsuario + keyString + ".pdf");

            return miFactura;
        }


        private String GenerarFacturaEnHTML(string ruta, List<Libro> coleccionLibrosCarrito, Usuario user, string infoCookieLibros)
        {
            string filas = "";
            StringBuilder midocHTML = new StringBuilder();



            midocHTML.Append("LIBRERÍA AGAPEA" + @"<br/>");
            midocHTML.Append("FACTURA DEL CLIENTE: " + user.nombreUsuario + @"<br/>");
            midocHTML.Append("Libros comprados:" + @"<br/>");

            foreach (Libro lib in coleccionLibrosCarrito)
            {
                midocHTML.Append(lib.titulo + @"<br/>");
                midocHTML.Append(lib.autor + @"<br/>");
                midocHTML.Append(lib.precio + @"<br/>");
                midocHTML.Append(recuperaCantidad(infoCookieLibros, lib.isbn10.ToString()) + @"<br/>");
                midocHTML.Append("------------------------------------" + @"<br/>");
            }



            //midocHTML.Append("<!DOCTYPE html><html<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title>FACTURA DE  CLIENTE</ title ><meta charset='utf-8'/></head>");
            ////midocHTML.Append("<html><head><title>FACTURA DE  CLIENTE</title></head>");
            //midocHTML.Append("<body><img src='" + ruta + "encabezado_inicio.png");
            //midocHTML.Append("<table>");

            //(from unLibro in coleccionLibrosCarrito
            // select
            //   "<tr>" +
            //   "<td>" + unLibro.titulo + "</td>" +
            //   "<td>" + unLibro.autor + "</td></td>").ToList<string>().ForEach(filaHTML => filas += filaHTML);

            //midocHTML.Append(filas);
            //midocHTML.Append("</table></body></html>");


            return midocHTML.ToString();
        }

        public int recuperaCantidad(string infoCookieLibros, string isbn10)
        {
            int cantidad = 0;

            List<string> isbn = infoCookieLibros.Split(new char[] { '$' }).ToList();

            for (int i = 0; i < isbn.Count; i++)
            {
                if (isbn[i].ToString() != "")
                {
                    if (isbn[i].ToString() == isbn10)
                    {
                        cantidad = Convert.ToInt32(isbn[i - 1]);
                    }
                }
            }

            return cantidad;
        }
    }
}

