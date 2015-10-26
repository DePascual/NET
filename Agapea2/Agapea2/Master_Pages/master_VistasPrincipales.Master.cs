using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.App_Code.controlador;
using Agapea2.App_Code.modelo;
using Agapea2.Controles_Usuario;


namespace Agapea2.Master_Pages
{
    public partial class master_VistasPrincipales : System.Web.UI.MasterPage
    {
        private controlador_VistaInicio miControlador = new controlador_VistaInicio();

        private void cargaTreeView (Dictionary<String, List<String>> datos)
        {
            List<string> categorias = datos.Keys.ToList();

            foreach (string cat in categorias)
            {
                treeView_Categorias.Nodes.Add(new TreeNode() { Text = cat, Value = "Categoria:" + cat });
            }

            categorias.ForEach(delegate (String cat)
            {
                datos[cat].ForEach(subcategoria => treeView_Categorias.FindNode("Categoria:" + cat).ChildNodes.Add(new TreeNode() { Text = subcategoria, Value = "Subcategoria:" + subcategoria }));
            });          
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            controlador_VistaInicio miControlador = new controlador_VistaInicio();

            if (!this.IsPostBack)
            {
                cargaTreeView(miControlador.recuperarCatySub());
            }
            else
            {
                switch (this.Request.Params.GetValues("__EVENTTARGET")[0])
                {
                    case "treeView_Categorias": 
                        string valueNodoTreeview = this.Request.Params.GetValues("__EVENTARGUMENT")[0].ToString();                        
                        break;
                };
            }



        }
    }
}