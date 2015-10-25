using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.Master_Pages;

namespace Agapea2
{
    public partial class Inicio_conMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (TreeView)treeView_Categorias = (TreeView)this.Master.FindControl("treeView_Categorias");
        }
    }
}