using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea2.App_Code.controlador;
using Agapea2.App_Code.modelo;
using System.Net.Mail;


namespace Agapea2.App_Code.controlador
{
    public class controlador_Email
    {
        //public bool MandarEmail(Usuario user) //Donde estan los datos de este usuario
        //{
        //    MailMessage mensajeAMandar = this.CrearEmail(user);
        //    SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
        //    try
        //    {
        //        server.Send(mensajeAMandar);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //private MailMessage CrearEmail(Usuario user)
        //{
        //    //dentro de user habra un carrito con una coleccion de libros
        //    Dictionary<string, Libro> librosCarrito = user.obtenerUltimoCarrito();
        //    controlador_generar_PDF generadorFactura = new controlador_generar_PDF();

        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(new MailAddress(user.emailUsuario));
        //    mail.From = "agapea@gmail.com";
        //    mail.Subject = "Factura con fecha...";
        //    mail.Attachments.Add(new Attachment(generadorFactura.CrearDocPDF(librosCarrito))); //la ruta del pdf, hay que guardarlo

        //    return mail;
        //}
    }
}