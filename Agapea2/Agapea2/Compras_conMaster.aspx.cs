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
using System.Threading.Tasks;

namespace Agapea2
{
    public partial class Compras_conMaster : System.Web.UI.Page
    {
        private controlador_CarritoCompra miControladorCompra = new controlador_CarritoCompra();
        private controlador_generar_PDF miControladorPDF = new controlador_generar_PDF();
        private controlador_AccesoFicheros miControladorFicheros = new controlador_AccesoFicheros();

        CarritoCompra miCarrito = new CarritoCompra();

        string isbn_LibrosAComprar_String = "";

        private void Dibuja_Tabla(List<Libro> librosAPintarList)
        {
            miCarrito.valoresLibros = new List<decimal>();

            for (int i = 0; i < librosAPintarList.Count(); i++)
            {
                tablaLibrosCesta.Rows.Add(new TableRow());

                for (int k = 0; k < 1; k++)
                {
                    tablaLibrosCesta.Rows[i].Cells.Add(new TableCell());
                    Libro libro = librosAPintarList.ElementAt(i);
                    control_LibroCesta unLibro = (control_LibroCesta)LoadControl("~/Controles_Usuario/control_LibroCesta.ascx");

                    Label cant = (Label)unLibro.FindControl("label_Cantidad");
                    cant.ID += "$" + libro.isbn10;
                    Button borrar = (Button)unLibro.FindControl("button_BorrarLibro");
                    borrar.ID += "$" + libro.isbn10;
                    Button mas = (Button)unLibro.FindControl("button_Mas");
                    mas.ID += "$" + libro.isbn10;
                    Button menos = (Button)unLibro.FindControl("button_Menos");
                    menos.ID += "$" + libro.isbn10;

                    unLibro.tituloLibro = libro.titulo;
                    unLibro.precioLibro = libro.precio;

                    int cantidadLibrosLabel = recuperaCantidad(libro.isbn10.ToString());
                    cant.Text = cantidadLibrosLabel.ToString();

                    unLibro.precioTotal = libro.precio * cantidadLibrosLabel;

                    miCarrito.valoresLibros.Add(Convert.ToDecimal(unLibro.precioTotal));

                    tablaLibrosCesta.Rows[i].Cells[k].Controls.Add(unLibro);
                }
            }
            pintarTotales();
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



        public void pintarTotales()
        {
            decimal sumatorio = 0;
            decimal total = 0;
            foreach (decimal precio in miCarrito.valoresLibros)
            {
                sumatorio += precio;
            }
            total = sumatorio + Convert.ToDecimal("3,50");

            ContentPlaceHolder miContentPlaceHolder;
            Label precioSub;
            Label gastosEnv;
            Label precioAPagar;

            miContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            if (miContentPlaceHolder != null)
            {
                precioSub = (Label)miContentPlaceHolder.FindControl("label_Subtotal");
                gastosEnv = (Label)miContentPlaceHolder.FindControl("label_GastosEnvio");
                precioAPagar = (Label)miContentPlaceHolder.FindControl("label_TotalAPagar");

                if (precioSub != null)
                {
                    precioSub.Text = sumatorio.ToString();
                }

                if (gastosEnv != null)
                {
                    gastosEnv.Text = "3,50";
                }

                if (precioAPagar != null)
                {
                    precioAPagar.Text = total.ToString();
                }
            }
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
                if (Request.Cookies["userInfo"] != null)
                {
                    coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                    isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString();
                    Dibuja_Tabla(librosList(isbn_LibrosAComprar_String));
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

                    if (clave.Contains("button_BorrarLibro"))
                    {
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                        string isbnABorrar = clave.Split(new char[] { '$' })[4];
                        string isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString().Replace("$" + isbnABorrar, "");

                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        miCookie.Values["isbn_LibrosAComprar"] = isbn_LibrosAComprar_String;

                        if (miCookie.Values["isbn_LibrosAComprar"].Count() == 0)
                        {
                            miCookie.Values.Remove("isbn_LibrosAComprar");
                        };
                        Response.Cookies.Add(miCookie);

                        List<Libro> LibrosAComprar = miControladorCompra.fabricaLibro(miControladorCompra.recuperaLibros(isbn_LibrosAComprar_String));
                        Dibuja_Tabla(LibrosAComprar);

                    }

                    if (clave.Contains("button_FinalizarPedido"))
                    {

                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                        List<string> infoCookie = sacaDatosCookie(coleccionCookies_userInfo);
                        grabaEnFichero(infoCookie);

                        this.Response.Redirect("FinalizarPedido_conMaster.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));
                    }

                    if (clave.Contains("button_Menos"))
                    {
                        string isbnARestar = clave.Split(new char[] { '$' })[4];

                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        string isbns_Puros = coleccionCookies_userInfo["isbn_LibrosAComprar"];

                        string cookieModificada = modificarCookie(isbns_Puros, isbnARestar, "resta");
                        miCookie.Values["isbn_LibrosAComprar"] = cookieModificada;
                        Response.Cookies.Add(miCookie);

                        isbn_LibrosAComprar_String = coleccionCookies_userInfo["isbn_LibrosAComprar"];

                        Dibuja_Tabla(librosList(isbn_LibrosAComprar_String));



                    }

                    if (clave.Contains("button_Mas"))
                    {

                        string isbnASumar = clave.Split(new char[] { '$' })[4];

                        HttpCookie miCookie = Request.Cookies["userInfo"];

                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        string isbns_Puros = coleccionCookies_userInfo["isbn_LibrosAComprar"];

                        string cookieModificada = modificarCookie(isbns_Puros, isbnASumar, "suma");
                        miCookie.Values["isbn_LibrosAComprar"] = cookieModificada;
                        Response.Cookies.Add(miCookie);

                        isbn_LibrosAComprar_String = coleccionCookies_userInfo["isbn_LibrosAComprar"];

                        Dibuja_Tabla(librosList(isbn_LibrosAComprar_String));
                    }

                }


            }
        }


        public string modificarCookie(string isbns_puros, string isbn, string operacion)
        {
            string cookieModificada = "";
            string parteMod = "";
            int cantidadInicial = recuperaCantidad(isbn);

            List<string> isbnsList = isbns_puros.Split(new char[] { '$' }).ToList();

            for (int i = 0; i < isbnsList.Count; i++)
            {
                if (isbnsList[i].ToString() != "")
                {
                    if (i % 2 == 0)
                    {
                        if (isbnsList[i].ToString() != isbn)
                        {
                            cookieModificada += "$" + isbnsList[i - 1].ToString() + "$" + isbnsList[i].ToString();
                        }
                    }
                }
            }

            switch (operacion)
            {
                case "suma":
                    parteMod = "$" + (cantidadInicial + 1).ToString() + "$" + isbn;
                    break;

                case "resta":
                    if (cantidadInicial == 1)
                    {
                        parteMod = "$1$" + isbn;
                    }
                    else
                    {
                        parteMod = "$" + (cantidadInicial - 1).ToString() + "$" + isbn;
                    }
                    break;
            }

            cookieModificada += parteMod;
            return cookieModificada;
        }

        public List<Libro> librosList(string isbn_LibrosAComprar_String)
        {
            List<Libro> LibrosAComprar = new List<Libro>();
            LibrosAComprar = miControladorCompra.fabricaLibro(miControladorCompra.recuperaLibros(isbn_LibrosAComprar_String));
            return LibrosAComprar;
        }

        public List<string> sacaDatosCookie(NameValueCollection coleccionCookies_userInfo)
        {
            List<string> infoCookie = new List<string>();
            infoCookie.Add(coleccionCookies_userInfo["nombreUsu"]);
            infoCookie.Add(coleccionCookies_userInfo["IP"]);
            infoCookie.Add(coleccionCookies_userInfo["ultimaVisita"]);
            infoCookie.Add(coleccionCookies_userInfo["isbn_LibrosAComprar"]);
            return infoCookie;
        }

        public void grabaEnFichero(List<string> infoCookie)
        {
            miControladorFicheros.RutaFichero = "~/ficheros/compras.txt";
            miControladorFicheros.AbrirFichero("ruta", "escribir");

            string libros = "";

            string nombreCliente = infoCookie[0];
            string ultimaVisita = infoCookie[2].Replace('/', '_').Replace(' ', '_').Replace(':', '_');

            string nombreLibro = "";
            string autorLibro = "";
            string isbnLibro = "";
            string precioLibro = "";

            List<string> librosAComprar = miControladorCompra.recuperaLibros(infoCookie[3]);

            foreach (string fila in librosAComprar)
            {
                if (fila != null)
                {
                    string[] argumentos = fila.Split(new char[] { ':' }).ToArray();
                    nombreLibro = argumentos[0];
                    autorLibro = argumentos[1];
                    isbnLibro = argumentos[5];
                    precioLibro = argumentos[7];

                    libros += recuperaCantidad(isbnLibro) + ":" + nombreLibro + ":" + autorLibro + ":" + isbnLibro + ":" + precioLibro;
                }

                
            }

            string aGrabar = nombreCliente + ":" + ultimaVisita + ":" + libros;
            miControladorFicheros.GrabarCompra(aGrabar);
        }
    }
}