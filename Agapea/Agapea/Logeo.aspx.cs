using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea.App_Code.controlador;

namespace Agapea
{
    public partial class Logeo : System.Web.UI.Page
    {
        private Controlador_Vista_Logeo miControladoLogeo;
        protected void Page_Load(object sender, EventArgs e)
        {
            mostar();
        }


        private void mostar()
        {
            this.seguimientoTextBox.Text = "";

            string mensaje = "";
            foreach (string clave in this.Request.Params.Keys)
            {
                mensaje += "clave:_" + clave + " --> valor:_" + this.Request.Params[clave].ToString() + "\n";
            }

            this.seguimientoTextBox.Text = mensaje;
        }

        protected void btn_identificate(object sender, ImageClickEventArgs e)
        {
            miControladoLogeo = new Controlador_Vista_Logeo();
            miControladoLogeo.recuperarUsuario();

            if(miControladoLogeo.recuperarUsuario().loginUsuario == txBx_nombreUsuario.Text.ToUpper() && miControladoLogeo.recuperarUsuario().passwordUsuario == txBx_passwordUsuario.Text.ToUpper())
            {
                this.Response.Redirect("Inicio.aspx?usuario=" + txBx_nombreUsuario.Text);
            }
            else
            {
                /*Label labelError = new Label();
                labelError.ForeColor = System.Drawing.Color.Red;
                labelError.Text = "El usuario no está registrado";

                Logeo.Controls.Add(labelError);*/
                
                

                this.Response.Redirect("Registro.aspx");
            }
            
        }

        protected void btn_registarme(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("Registro.aspx");
        }
    }

}