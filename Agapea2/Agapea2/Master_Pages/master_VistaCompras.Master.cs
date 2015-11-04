using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agapea2.Master_Pages
{
    public partial class master_VistaCompras : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostar();
        }

        private void mostar()
        {
            this.seguimientoTextBox.Text = "";

            string mensaje = "";
            foreach (string clave in this.Request.Params.AllKeys)
            {
                mensaje += "clave:_" + clave + " --> valor:_" + this.Request.Params[clave].ToString() + "\n";
            }

            this.seguimientoTextBox.Text = mensaje;
        }
    }
}