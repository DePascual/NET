using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agapea2
{
    public partial class FinalizarPedido_conMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                Label labelUsu = (Label)this.Master.FindControl("label_idUsuario");
                if (labelUsu != null)
                {
                    labelUsu.Text = labelUsu.Text + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper();
                }

            }

            if (!IsPostBack)
            {
                if (Request.Cookies["userInfo"] != null)
                {
                    coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                    string isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString();
                    Dibuja_Tabla(librosList(isbn_LibrosAComprar_String));

                    HttpCookie miCookie = Request.Cookies["userInfo"];
                    coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                    List<string> infoCookie = new List<string>();
                    infoCookie.Add(coleccionCookies_userInfo["nombreUsu"]);
                    infoCookie.Add(coleccionCookies_userInfo["IP"]);
                    infoCookie.Add(coleccionCookies_userInfo["ultimaVisita"]);
                    infoCookie.Add(coleccionCookies_userInfo["isbn_LibrosAComprar"]);

                    miControladorCompra.datosUsuario(infoCookie);
                }
            }
            else
            {
            }
    }
}