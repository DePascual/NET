using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.App_Code.modelo;
using Agapea2.App_Code.controlador;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace Agapea2
{
    public partial class FinalizarPedido_conMaster : System.Web.UI.Page
    {
        private controlador_CarritoCompra miControladorCompra = new controlador_CarritoCompra();
        private controlador_generar_PDF miControladorPDF = new controlador_generar_PDF();
        string isbn_LibrosAComprar_String = "";
        CarritoCompra miCarrito = new CarritoCompra();

        public List<Libro> librosList(string isbn_LibrosAComprar_String)
        {
            List<Libro> LibrosAComprar = new List<Libro>();
            LibrosAComprar = miControladorCompra.fabricaLibro(miControladorCompra.recuperaLibros(isbn_LibrosAComprar_String));
            return LibrosAComprar;
        }

        private void Dibuja_Tabla(List<Libro> librosAPintarList)
        {
            for (int i = 0; i < librosAPintarList.Count() + 1; i++)
            {
                tablaLibros.Rows.Add(new TableRow());

                for (int k = 0; k < 6; k++)
                {
                    tablaLibros.Rows[i].Cells.Add(new TableCell());

                    if (i == 0)
                    {
                        switch (k)
                        {
                            case 0:
                                tablaLibros.Rows[i].Cells[k].Text = "Referencia";
                                break;
                            case 1:
                                tablaLibros.Rows[i].Cells[k].Text = "Titulo";
                                break;
                            case 2:
                                tablaLibros.Rows[i].Cells[k].Text = "Autor";
                                break;
                            case 3:
                                tablaLibros.Rows[i].Cells[k].Text = "Unidades";
                                break;
                            case 4:
                                tablaLibros.Rows[i].Cells[k].Text = "Precio";
                                break;
                        }
                    }
                    else
                    {
                        Libro libro = librosAPintarList.ElementAt(i - 1);
                        switch (k)
                        {
                            case 0:
                                tablaLibros.Rows[i].Cells[k].Text = libro.isbn10.ToString();
                                break;
                            case 1:
                                tablaLibros.Rows[i].Cells[k].Text = libro.titulo;
                                break;
                            case 2:
                                tablaLibros.Rows[i].Cells[k].Text = libro.autor;
                                break;
                            case 3:
                                tablaLibros.Rows[i].Cells[k].Text = recuperaCantidad(libro.isbn10.ToString()).ToString();
                                break;
                            case 4:
                                tablaLibros.Rows[i].Cells[k].Text = libro.precio.ToString() + "euros";
                                break;
                        }
                    }
                }
            }
            //pintarTotales();
        }


        public int recuperaCantidad(string isbn10)
        {
            int cantidad = 0;

            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                List<string> isbn = coleccionCookies_userInfo["isbn_LibrosAComprar"].Split(new char[] { '$' }).ToList();

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
            }
            return cantidad;
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                Label labelUsu = (Label)this.Master.FindControl("label_idUsuario");
                if (labelUsu != null)
                {
                    labelUsu.Text = labelUsu.Text + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper();
                }

            }

            if (!IsPostBack)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString();
                Dibuja_Tabla(librosList(isbn_LibrosAComprar_String));

            }
            else
            {
                foreach (string clave in Request.Params.AllKeys)
                {
                    if (clave.Contains("button_FinalizarPedido"))
                    {

                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                        List<string> infoCookie = new List<string>();
                        infoCookie.Add(coleccionCookies_userInfo["nombreUsu"]);
                        infoCookie.Add(coleccionCookies_userInfo["IP"]);
                        infoCookie.Add(coleccionCookies_userInfo["ultimaVisita"]);
                        infoCookie.Add(coleccionCookies_userInfo["isbn_LibrosAComprar"]);

                        string fechaCompra = infoCookie[2];
                        List<Libro> librosAComprar = new List<Libro>();
                        librosAComprar = miControladorCompra.fabricaLibro(miControladorCompra.recuperaLibros(infoCookie[3]));
                        miCarrito.librosCarro = new Dictionary<string, List<Libro>>();
                        miCarrito.librosCarro.Add(fechaCompra, librosAComprar);

                        Usuario user = miControladorCompra.datosUsuario(infoCookie);
 
                        Task generarPDF = new Task((ruta) =>
                        {
                            string rutaRaiz = (string)ruta;
                            miControladorPDF.CrearDocPDF(rutaRaiz, user, miCarrito.librosCarro);                      
                        }, Request.RequestContext.HttpContext.Server.MapPath("~/"));
                        generarPDF.Start();
                    }
                }
            }
        }
    }
}