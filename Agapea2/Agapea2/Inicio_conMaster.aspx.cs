using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.Master_Pages;
using Agapea2.App_Code.controlador;
using Agapea2.App_Code.modelo;
using Agapea2.Controles_Usuario;
using System.Collections.Specialized;

namespace Agapea2
{
    public partial class Inicio_conMaster : System.Web.UI.Page
    {
        private master_VistasPrincipales miMaster = new master_VistasPrincipales();
        private controlador_VistaInicio miControlador = new controlador_VistaInicio();

        public ImageButton button_Comprar;



        private void Dibuja_Tabla(List<Libro> librosAPintarList, string tipo_Control)
        {
            for (int i = 0; i < 3; i++)
            {
                tablaLibros.Rows.Add(new TableRow());

                for (int k = 0; k < 3 && librosAPintarList.Count() - 1 >= i * 3 + k; k++)
                {
                    tablaLibros.Rows[i].Cells.Add(new TableCell());
                    Libro libro = librosAPintarList.ElementAt(i * 3 + k);

                    switch (tipo_Control)
                    {
                        case "control_Libro":
                            control_Libro unLibro;

                            unLibro = (control_Libro)LoadControl("~/Controles_Usuario/control_Libro.ascx");
                            unLibro.tituloLibro = libro.titulo;
                            unLibro.autorLibro = libro.autor;
                            unLibro.editorialLibro = libro.editorial;
                            unLibro.precioLibro = libro.precio;
                            unLibro.isbnLibro = libro.isbn10;

                            tablaLibros.Rows[i].Cells[k].Controls.Add(unLibro);

                            unLibro.FindControl("linkButton_Titulo").ID += unLibro.isbnLibro.ToString();

                            unLibro.FindControl("button_Comprar").ID += "$" + unLibro.isbnLibro.ToString();

                            break;
                        case "detalles_Libro":
                            detalles_Libro detallesLibroSelecc;

                            detallesLibroSelecc = (detalles_Libro)LoadControl("~/Controles_Usuario/detalles_Libro.ascx");
                            detallesLibroSelecc.tituloLibro = libro.titulo;
                            detallesLibroSelecc.autorLibro = libro.autor;
                            detallesLibroSelecc.editorialLibro = libro.editorial;
                            detallesLibroSelecc.isbnLibro = libro.isbn10;
                            detallesLibroSelecc.precioLibro = libro.precio;
                            detallesLibroSelecc.resumenLibro = libro.resumen;
                            detallesLibroSelecc.indiceLibro = libro.indice;

                            tablaLibros.Rows[i].Cells[k].Controls.Add(detallesLibroSelecc);
                            break;
                    }

                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection coleccionCookies_userInfo;

            HttpCookie cookie = Request.Cookies["userInfo"];

            if (cookie == null)
            {
                HttpCookie miCookie = new HttpCookie("userInfo");
                miCookie.Values["nombreUsu"] = "anonymous";
                miCookie.Values["IP"] = Context.Request.ServerVariables["REMOTE_ADDR"];
                miCookie.Values["ultimaVisita"] = DateTime.Now.ToString();
                miCookie.Expires = DateTime.MinValue;
                Response.Cookies.Add(miCookie);
            }

            if (!this.IsPostBack)
            {
                List<Libro> todosLosLibros = miControlador.listaLibrosRecuperados();
                Dibuja_Tabla(todosLosLibros, "control_Libro");

                if (!Request.Cookies["userInfo"].Values["nombreUsu"].Equals("anonymous"))
                {
                    cambiaCabecera();
                }

                if (Request.Cookies["userInfo"].Values["isbn_LibrosAComprar"] != null)
                {

                    List<string> isbnsAContar = Request.Cookies["userInfo"].Values["isbn_LibrosAComprar"].Split(new char[] { '$' }).ToList();
                    int cantidad = recuperaCantidad(isbnsAContar);

                    Button cesta = (Button)this.Master.FindControl("button_MiCesta");
                    if (cesta != null)
                    {
                        cesta.Visible = true;
                        cesta.Text += " " + cantidad;
                    }
                }
            }
            else
            {

                foreach (string clave in Request.Params.AllKeys)
                {
                    if (clave.Contains("button_Comprar") && clave.EndsWith(".x"))
                    {
                        string isbnLibroAComprar = clave.Split(new char[] { '$' })[4].Replace(".x", "");
                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        miCookie.Values["isbn_LibrosAComprar"] += "$1$" + isbnLibroAComprar;
                        Response.Cookies.Add(miCookie);

                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        List<string> isbns = coleccionCookies_userInfo["isbn_LibrosAComprar"].Split(new char[] { '$' }).ToList();
                        string isbns_puros = coleccionCookies_userInfo["isbn_LibrosAComprar"].ToString();

                        foreach (string isbnBuscado in isbns)
                        {
                            if (isbnBuscado == isbnLibroAComprar)
                            {
                                miCookie.Values["isbn_LibrosAComprar"] = modificarCookie(isbns_puros, isbnLibroAComprar);
                                Response.Cookies.Add(miCookie);
                            }
                        }

                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        this.Response.Redirect("Compras_conMaster.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));

                    }

                    if (clave.Contains("button_Buscar"))
                    {
                        TextBox libroABuscar = (TextBox)this.Master.FindControl("txtBox_Buscador");
                        List<Libro> librosRecuperados = new List<Libro>();

                        if (libroABuscar != null)
                        {
                            string libroParaBuscar = libroABuscar.Text.ToUpper();
                            foreach (string param in Request.Params.AllKeys)
                            {
                                if (param.Contains("busqueda"))
                                {
                                    string radioButtonSelec = this.Request.Params.GetValues(param)[0].ToString().Split(new char[] { '_' })[1];
                                    librosRecuperados = miControlador.recuperarLibrosPorParametro(radioButtonSelec, libroParaBuscar);
                                    Dibuja_Tabla(librosRecuperados, "control_Libro");

                                }
                            }
                        }
                    }

                    if (clave.Contains("button_MiCesta"))
                    {
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        this.Response.Redirect("Compras_conMaster.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));
                    }



                    if (clave == ("__EVENTTARGET"))
                    {
                        string valor = this.Request.Params[clave];

                        if (valor.Contains("treeView_Categorias"))
                        {
                            string nodoTreeViewSeleccionado = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                            List<Libro> librosCategoriaSeleccionada = nodoTreeViewSeleccionado.Contains("Subcategoria") ? miControlador.recuperarLibrosPorParametro("Subcategoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[2]) : miControlador.recuperarLibrosPorParametro("Categoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[1]);
                            Dibuja_Tabla(librosCategoriaSeleccionada, "control_Libro");
                        }

                        if (valor.Contains("linkButton_Titulo"))
                        {
                            string isbnLibroSeleccionado = this.Request.Params.GetValues("__EVENTTARGET")[0].Split(new char[] { '$' })[3].Replace("linkButton_Titulo", "");
                            List<Libro> libroRecuperado = miControlador.recuperarLibrosPorParametro("ISBN", isbnLibroSeleccionado);
                            Dibuja_Tabla(libroRecuperado, "detalles_Libro");
                        }

                        if (valor.Contains("linkButton_AccesoCuenta"))
                        {
                            coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                            if (coleccionCookies_userInfo["isbn_LibrosAComprar"] != null)
                            {
                                this.Response.Redirect("Login_conMaster.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));
                            }
                            else
                            {
                                this.Response.Redirect("Login_conMaster.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper());
                            }


                        }

                    }

                }


            }

        }

        public string modificarCookie(string isbns_puros, string isbnsASumar)
        {
            string cookieModificada = "";
            string parteSuma = "";

            int contador = 0;

            List<string> isbnsList = isbns_puros.Split(new char[] { '$' }).ToList();

            List<string> listaModificada = new List<string>();


            for (int i = 0; i < isbnsList.Count; i++)
            {
                if (isbnsList[i].ToString() != "")
                {

                    if (i % 2 == 0)
                    {
                        if (isbnsList[i].ToString() == isbnsASumar)
                        {
                            contador++;
                            parteSuma = "$" + contador + "$" + isbnsList[i].ToString();
                        }
                        else
                        {
                            cookieModificada += "$" + isbnsList[i - 1].ToString() + "$" + isbnsList[i].ToString();
                        }
                    }
                }
            }
            cookieModificada += parteSuma;
            return cookieModificada;
        }

        public void cambiaCabecera()
        {
            NameValueCollection coleccionCookies_userInfo;

            LinkButton acceso = (LinkButton)this.Master.FindControl("linkButton_AccesoCuenta");
            if (acceso != null)
            {
                acceso.Visible = false;
            }

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                Label labelUsu = (Label)this.Master.FindControl("label_idUsuario");
                if (labelUsu != null)
                {
                    labelUsu.Visible = true;
                    labelUsu.Text = labelUsu.Text + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper();
                }

            }
        }

        public int recuperaCantidad(List<string> isbnsAContar)
        {
            int cantidad = 0;

            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                for (int i = 0; i < isbnsAContar.Count; i++)
                {
                    if (isbnsAContar[i].ToString() != "")
                    {
                        if (i % 2 == 1)
                        {
                            cantidad += Convert.ToInt32(isbnsAContar[i]);
                        }
                    }
                }
            }
            return cantidad;
        }
    }
}