﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Pdf;
using Agapea2.App_Code.modelo;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf.HtmlConverter;
using System.Threading;

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

        public PdfDocument CrearDocPDF(string rutaFichero, Usuario user, Dictionary<string, List<Libro>> coleccionLibrosCarrito)
        {
            PdfDocument miFactura = new PdfDocument();

            PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat();
            //webBrowser load html whether Waiting
            htmlLayoutFormat.IsWaiting = false;
            //page setting
            PdfPageSettings setting = new PdfPageSettings();
            setting.Size = PdfPageSize.A4;

            String facturaHTML = GenerarFacturaEnHTML(rutaFichero + "imagenes/", coleccionLibrosCarrito.Values.ElementAt(0));

            List<string> nombreKey = coleccionLibrosCarrito.Keys.ToList();
            string keyString = "";
            foreach (string key in nombreKey)
            {
                keyString = key;
                keyString = keyString.Replace('/', '_').Replace(' ', '_');
            }

            Thread thread = new Thread(() =>
            {
                //PdfDocument fact = new PdfDocument();
                miFactura.LoadFromHTML(facturaHTML, false, setting, htmlLayoutFormat);
                //fact.SaveToFile("C:/Users/karol/Desktop/facturas/" + user.loginUsuario + "_" + keyString.ToString() + ".pdf");
            });
           
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
         
            miFactura.SaveToFile(user.loginUsuario + ".pdf");
                     
            System.Diagnostics.Process.Start(user.loginUsuario + ".pdf");

            return miFactura;
        }


        private String GenerarFacturaEnHTML(string ruta, List<Libro> coleccionLibrosCarrito)
        {
            string filas = "";
            StringBuilder midocHTML = new StringBuilder();
            midocHTML.Append("<html><head><title>FACTURA DE  CLIENTE</title></head>");
            midocHTML.Append("<body><img src='" + ruta + "encabezado_inicio.png");
            midocHTML.Append("<table>");

            (from unLibro in coleccionLibrosCarrito
             select
               "<tr>" +
               "<td>" + unLibro.titulo + "</td>" +
               "<td>" + unLibro.autor + "</td></td>").ToList<string>().ForEach(filaHTML => filas += filaHTML);

            midocHTML.Append(filas);
            midocHTML.Append("</table></body></html>");
            return midocHTML.ToString();
        }
    }
}