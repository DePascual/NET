using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.App_Code.controlador;

namespace Agapea2
{
    public partial class Registro_conMaestra : System.Web.UI.Page
    {
        private controlador_VistaRegistro controladorVistaReg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                foreach (string clave in Request.Params.AllKeys)
                {
                    if (clave.Contains("btn_registrarme"))
                    {
                        controladorVistaReg = new controlador_VistaRegistro();

                        if (this.IsValid)
                        {
                            controladorVistaReg.GrabarDatosUsuarios(txBx_nomUsuario.Text, txBx_apeUsuario.Text, txBx_emailUsuario.Text, txBx_loginUsuario.Text, txBx_passUsuario.Text);
                            this.Response.Redirect("Inicio.aspx?usuario=" + txBx_nomUsuario.Text);
                        }
                    }
                }
            }
        }


        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (!this.check_Acepto.Checked) args.IsValid = false;
        }
    }
}