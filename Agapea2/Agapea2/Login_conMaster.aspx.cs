using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.App_Code.controlador;
using Agapea2.App_Code.modelo;
using System.Collections.Specialized;

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
            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
            }

            string usuarioTextBox = txtBx_nombreUsuario.Text.ToUpper();
            string passTextBox = txtBx_passwordUsuario.Text.ToUpper();

            if (miControladoLogeo.existeUsuario(usuarioTextBox, passTextBox) == true)
            {
                HttpCookie miCookie = Request.Cookies["userInfo"];
                miCookie.Values["nombreUsu"] = txtBx_nombreUsuario.Text;
                miCookie.Values["ultimaVisita"] = DateTime.Now.ToString();
                Response.Cookies.Add(miCookie);

                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

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