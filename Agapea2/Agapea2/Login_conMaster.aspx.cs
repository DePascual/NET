using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.App_Code.controlador;

namespace Agapea2
{
    public partial class Login_conMaster : System.Web.UI.Page
    {
        private controlador_VistaLogeo miControladoLogeo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_identificarme_Click(object sender, ImageClickEventArgs e)
        {
            miControladoLogeo = new controlador_VistaLogeo();

            string usuarioTextBox = txtBx_nombreUsuario.Text.ToUpper();
            string passTextBox = txtBx_passwordUsuario.Text.ToUpper();

            if (miControladoLogeo.existeUsuario(usuarioTextBox, passTextBox) == true)
            {
                this.Response.Redirect("Inicio_conMaster.aspx?usuario=" + txtBx_nombreUsuario.Text);
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