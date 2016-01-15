using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using LoginBDATOS.App_Code.Controladores;

namespace LoginBDATOS
{
    public partial class Login : System.Web.UI.Page
    {
        private controlador_AccesoBaseDatos miControladorAccesoBD = new controlador_AccesoBaseDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonEntrar_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                Boolean existe = miControladorAccesoBD.existeUsuario(txtBoxNombre.Text, txtBoxPassword.Text);

                if (existe  == true)
                {
                    Response.Redirect("tienda.aspx");
                }
                else
                {
                    Response.Redirect("registro.aspx");
                }
            }
        }

        protected void buttonRegistro_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                Response.Redirect("registro.aspx");
            }
        }
    }
}