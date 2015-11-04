using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Agapea2.App_Code.controlador;
using Agapea2.App_Code.modelo;
using Agapea2.Controles_Usuario;

namespace Agapea2
{
    public partial class Compras_conMaster : System.Web.UI.Page
    {
        private controlador_CarritoCompra miControladorCompra = new controlador_CarritoCompra();


        private void Dibuja_Tabla(List<Libro> librosAPintarList)
        {
            for (int i = 0; i < librosAPintarList.Count(); i++)
            {
                tablaLibrosCesta.Rows.Add(new TableRow());

                for (int k = 0; k < 1; k++)
                {
                    tablaLibrosCesta.Rows[i].Cells.Add(new TableCell());
                    Libro libro = librosAPintarList.ElementAt(i);

                    control_LibroCesta unLibro;

                    unLibro = (control_LibroCesta)LoadControl("~/Controles_Usuario/control_LibroCesta.ascx");

                    TextBox cantidad = (TextBox)unLibro.FindControl("txtBox_Cantidad");

                    unLibro.tituloLibro = libro.titulo;
                    unLibro.precioLibro = libro.precio;
                    unLibro.precioTotal = libro.precio * Convert.ToDecimal(cantidad.Text);

                    tablaLibrosCesta.Rows[i].Cells[k].Controls.Add(unLibro);
                }
            }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection coleccionCookies_userInfo;

            if (!IsPostBack)
            {
                if (Request.Cookies["userInfo"] != null)
                {
                    coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                    string isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString();

                    List<Libro> LibrosAComprar = miControladorCompra.recuperaLibros(isbn_LibrosAComprar_String);
                  
                    Dibuja_Tabla(LibrosAComprar);
                }
            }
            else
            {
                foreach (string clave in Request.Params.AllKeys)
                {
                    if (clave.Contains("button_SeguirComprando"))
                    {
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        this.Response.Redirect("Inicio_conMaster.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));
                    }

                }


            }
        }
    }
}