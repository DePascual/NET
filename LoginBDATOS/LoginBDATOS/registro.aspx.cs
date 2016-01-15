using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginBDATOS.App_Code.Controladores;


namespace LoginBDATOS
{
    public partial class registro : System.Web.UI.Page
    {
        private controlador_AccesoBaseDatos miControladorAccesoBD = new controlador_AccesoBaseDatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonRegistro_Click(object sender, EventArgs e)
        {
            Boolean registrado = miControladorAccesoBD.registraUsuario(textBoxNombre.Text, textBoxApellidos.Text, textBoxNIF.Text, textBoxDireccion.Text, textBoxLocalidad.Text, textBoxProvincia.Text);
            if (registrado == true)
            {
                Response.Redirect("tienda.aspx");
            }
            else
            {
                Response.Redirect("error.aspx");
            }
        }

        protected void buttonModificar_Click(object sender, EventArgs e)
        {
            Boolean existe = miControladorAccesoBD.existeCliente(textBoxNombre.Text, textBoxApellidos.Text, textBoxNIF.Text, textBoxDireccion.Text, textBoxLocalidad.Text, textBoxProvincia.Text);
            if (existe == true)
            {

            }else
            {
                //El usuario que se quiere modificar no existe
                Response.Redirect("error.aspx");
            }
        }
    }
}