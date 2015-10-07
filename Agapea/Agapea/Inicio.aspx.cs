using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea.App_Code.controlador;


namespace Agapea
{
    public partial class Inicio : System.Web.UI.Page
    {
        private Controlador_Vista_Inicio controladorVistaInicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            int contador = 0;

            controladorVistaInicio = new Controlador_Vista_Inicio();
            for (int i = 0; i < 3; i++)
            {
                tablaGeneral.Rows.Add(new TableRow());

                for (int k = 0; k < 3; k++)
                {
                    tablaGeneral.Rows[i].Cells.Add(new TableCell());
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).titulo  });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).autor });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).editorial });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).categoria });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).isbn10.ToString() });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).isbn13.ToString() });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).precio.ToString() });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).numeroPaginas.ToString() });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).resumen });
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new LiteralControl(" <br>"));
                    tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador).cantidadLibros.ToString() });

                    contador++;
                   
                }
            }
        }
    }
}