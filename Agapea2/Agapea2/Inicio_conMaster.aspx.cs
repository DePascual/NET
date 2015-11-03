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
            //Recupero el valor de la cookie

            
            if (Request.Cookies["userInfo"] != null)
            {
                NameValueCollection coleccionCookies_userInfo;
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                //Lo meto en la label de la MasterPage
                Label labelUsu = (Label)this.Master.FindControl("label_idUsuario");
                if (labelUsu != null)
                {
                    labelUsu.Text = labelUsu.Text + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper();
                }

            }

            if (!this.IsPostBack)
            {
                List<Libro> todosLosLibros = miControlador.listaLibrosRecuperados();
                Dibuja_Tabla(todosLosLibros, "control_Libro");
            }
            else
            {

                foreach (string clave  in Request.Params.AllKeys)
                {
                    if (clave.Contains("button_Comprar") && clave.EndsWith(".x"))
                    {
                        string isbnLibroAComprar = clave.Split(new char[] { '$' })[4].Replace(".x", "");
                        List<Libro> libroRecuperado = miControlador.recuperarLibrosPorParametro("ISBN", isbnLibroAComprar);
                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        miCookie.Values["isbnLibroAComprar"] = isbnLibroAComprar;
                        Response.Cookies.Add(miCookie);
                        //llamaria al controlador del carrito y añadiria en la lista de la compra este libro. Guardar en la cookie el valor del isbn de la compra
                    }

                    if(clave == ("__EVENTTARGET"))
                    {
                        string valor = this.Request.Params[clave];

                        if (valor.Contains("treeView_Categorias"))
                        {
                            string nodoTreeViewSeleccionado = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                            List<Libro> librosCategoriaSeleccionada = nodoTreeViewSeleccionado.Contains("Subcategoria") ? miControlador.recuperarLibrosPorParametro("Subcategoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[2]) : miControlador.recuperarLibrosPorParametro("Categoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[1]);
                            Dibuja_Tabla(librosCategoriaSeleccionada, "control_Libro");
                        }
                    }

                }




                ////string elementoQueHaProducidoPostBack = this.Request.Params.GetValues("__EVENTTARGET")[0].Split(new char[] { '$' })[1];
                //string elementoQueHaProducidoPostBack = this.Request.Params.GetValues("__EVENTTARGET")[0];
                ////__EVENTTARGET = _ctl00$treeView_Categorias


                //if (elementoQueHaProducidoPostBack.Contains("treeView_Categorias"))
                //{
                //    string nodoTreeViewSeleccionado = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                //    List<Libro> librosCategoriaSeleccionada = nodoTreeViewSeleccionado.Contains("Subcategoria") ? miControlador.recuperarLibrosPorParametro("Subcategoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[2]) : miControlador.recuperarLibrosPorParametro("Categoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[1]);
                //    Dibuja_Tabla(librosCategoriaSeleccionada, "control_Libro");
                //}

                //if (elementoQueHaProducidoPostBack.Contains("linkButton_Titulo"))
                //{
                //    string isbnLibroSeleccionado = this.Request.Params.GetValues("__EVENTTARGET")[0].Split(new char[] { '$' })[3].Replace("linkButton_Titulo", "");
                //    List<Libro> libroRecuperado = miControlador.recuperarLibrosPorParametro("ISBN", isbnLibroSeleccionado);
                //    Dibuja_Tabla(libroRecuperado, "detalles_Libro");
                //}

                //if (elementoQueHaProducidoPostBack.Contains("button_Comprar"))
                //{
                //    string isbnLibroSeleccionado = this.Request.Params.GetValues("__EVENTTARGET")[0].Split(new char[] { '$' })[3].Replace("button_Comprar", "");
                //}
          
            }


        }

       


        protected void button_Buscar_Click(object sender, EventArgs e)
        {

            if (radioButton_Titulo.Checked)
            {
                radioButton_CheckedChanged(radioButton_Titulo, null);
            }
            else if (radioButton_Autor.Checked)
            {
                radioButton_CheckedChanged(radioButton_Autor, null);
            }
            else if (radioButton_ISBN.Checked)
            {
                radioButton_CheckedChanged(radioButton_ISBN, null);
            }
        }



        protected void radioButton_CheckedChanged(object sender, EventArgs e)
        {

            string radioButton = ((RadioButton)sender).Text;
            string textoABuscar = txtBox_Buscador.Text.ToUpper();

            List<Libro> librosRecuperados = new List<Libro>();
            switch (radioButton)
            {
                case "Titulo":
                    librosRecuperados = miControlador.recuperarLibrosPorParametro("Titulo", textoABuscar);
                    break;
                case "Autor":
                    librosRecuperados = miControlador.recuperarLibrosPorParametro("Autor", textoABuscar);
                    break;
                case "ISBN":
                    librosRecuperados = miControlador.recuperarLibrosPorParametro("ISBN", textoABuscar);
                    break;
            }
            Dibuja_Tabla(librosRecuperados, "control_Libro");
        }


    }
}