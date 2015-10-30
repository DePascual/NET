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

namespace Agapea2
{
    public partial class Inicio_conMaster : System.Web.UI.Page
    {
        private master_VistasPrincipales miMaster = new master_VistasPrincipales();
        private controlador_VistaInicio miControlador = new controlador_VistaInicio();

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
                            break;
                        case "detalles_Libro":
                            detalles_Libro detallesLibroSelecc;





                            break;
                    }

                }
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                List<Libro> todosLosLibros = miControlador.listaLibrosRecuperados();
                Dibuja_Tabla(todosLosLibros, "control_Libro");
            }
            else
            {
                string elementoQueHaProducidoPostBack = this.Request.Params.GetValues("__EVENTTARGET")[0].Split(new char[] { '$' }).ToArray()[1];
                //__EVENTTARGET = _ctl00$treeView_Categorias

                switch (elementoQueHaProducidoPostBack)
                {
                    case "treeView_Categorias":
                        string nodoTreeViewSeleccionado = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();
                        List<Libro> librosCategoriaSeleccionada = nodoTreeViewSeleccionado.Contains("Subcategoria") ? miControlador.recuperarLibrosPorParametro("Subcategoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[2]) : miControlador.recuperarLibrosPorParametro("Categoria", nodoTreeViewSeleccionado.Split(new char[] { ':' })[1]);
                        Dibuja_Tabla(librosCategoriaSeleccionada, "control_Libro");
                        break;

                    default:
                        if (this.Request.Params.GetValues("__EVENTTARGET")[0].Contains("linkButton_Titulo"))
                        {
                            string isbnLibroSeleccionado = this.Request.Params.GetValues("__EVENTTARGET")[0].Split(new char[] { '$' })[3].Replace("linkButton_Titulo", "");
                            List<Libro> libroRecuperado = miControlador.recuperarLibrosPorParametro("ISBN", isbnLibroSeleccionado);
                            Dibuja_Tabla(libroRecuperado, "detalles_Libro");
                        };
                        break;
                }


            }


        }


    }
}