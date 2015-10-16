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

            string usuarioTextBox = txBx_nombreUsuario.Text.ToUpper();
            string passTextBox = txBx_passwordUsuario.Text.ToUpper();

            if (miControladoLogeo.existeUsuario(usuarioTextBox, passTextBox) == true)
            {
                this.Response.Redirect("Inicio.aspx?usuario=" + txBx_nombreUsuario.Text);
            }
            else
            {
                labelError.Visible = true;
            }
        }

        protected void btn_registarme(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("Registro.aspx");
        }
    }

}