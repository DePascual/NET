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

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Libro> miListaLibros = miControlador.listaLibrosRecuperados();

            for (int i = 0; i < 3; i++)
            {
                tablaLibros.Rows.Add(new TableRow());

                for (int k = 0; k < 3 && miListaLibros.Count() - 1 >= i * 3 + k; k++)
                {
                    tablaLibros.Rows[i].Cells.Add(new TableCell());

                    control_Libro unLibro;
                    Libro libro = miListaLibros.ElementAt(i * 3 + k);

                    unLibro = (control_Libro)LoadControl("~/Controles_Usuario/control_Libro.ascx");
                    unLibro.tituloLibro = libro.titulo;
                    unLibro.autorLibro = libro.autor;
                    unLibro.editorialLibro = libro.editorial;
                    unLibro.precioLibro = libro.precio;
                    unLibro.isbnLibro = libro.isbn10;
                    tablaLibros.Rows[i].Cells[k].Controls.Add(unLibro);
                }
            }


        }
    }
}