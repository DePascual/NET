using System;
using System.IO;
using System.Windows;
using System.Web.UI;
using System.Drawing;
using Agapea.App_Code.controlador;

namespace Agapea
{
    public partial class Registro : System.Web.UI.Page
    {
        private Controlador_Vista_Registro controladorVistaReg;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_registrarme_Click(object sender, ImageClickEventArgs e)
        {
            controladorVistaReg = new Controlador_Vista_Registro();

            if (this.IsValid)
            {
                controladorVistaReg.GrabarDatosUsuarios(txBx_nomUsuario.Text, txBx_apeUsuario.Text, txBx_emailUsuario.Text, txBx_loginUsuario.Text, txBx_passUsuario.Text);
                //this.Response.Redirect("./Inicio.aspx");
                this.Response.Redirect("Inicio.aspx?usuario=" + txBx_nomUsuario.Text);
            }
        }

        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!this.check_Acepto.Checked) args.IsValid = false;
        }

   
    }
}