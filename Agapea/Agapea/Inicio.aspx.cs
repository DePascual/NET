using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea.App_Code.controlador;


namespace Agapea
{
    public partial class Inicio : System.Web.UI.Page
    {
        private Controlador_Vista_Inicio controladorVistaInicio;

        protected void Page_Load(object sender, EventArgs e)
        {

            controladorVistaInicio = new Controlador_Vista_Inicio();


            string[] materias = { "Drecho", "Informatica", "Ciencias Naturales", "Economia" };

            if (this.IsPostBack)
            {
                foreach (string clave in this.Request.Params.AllKeys)
                {
                    if (clave == this.BotonComprarLibro.ID)
                    {
                        this.Label1.Text = "HAS PULSADO EL BOTON";
                    }
                    else if (clave == "__EVENTTARGET" && this.Request.Params[clave] == this.TreeView1.ID)
                    {
                        this.Label1.Text = "HAS SELECCIONADO EL BOTON DEL TREEVIEW...." + this.Request.Params["__EVENTARGUMENT"].ToString();
                    }
                }
            }
            else
            {
                //En vez de hacer un if, cuando nos recorremos el archivo para ver si las categorias del los libros coinciden, se puede hacer
                //una select para seleccionar los campos que queremos. Hay 3 formas:

                /*----------------------FORMA TRADICIONAL------------------------------
                foreach (string unamateria in materias)
                {
                    TreeNode nuevoNodo = new TreeNode() { Text = unamateria, Value = unamateria };
                    this.TreeView1.Nodes.Add(nuevoNodo);
                }*/

                //--------------con LINQ sintaxis sql-----------------------------------
                TreeNode[] nodos = (from unamateria in materias
                                    select new TreeNode() { Text = unamateria, Value = unamateria }).ToArray();

                foreach (TreeNode nodo in nodos)
                    this.TreeView1.Nodes.Add(nodo);

                /*----------------con LINQ sintaxis extendida---------------------------------
                //Forma de hacer un foreach mas sencilla. Es un LINQ. Usa sentencias SQL sobre colecciones de objetos
                //El de arriba y el de abajo hacen exactamente lo mismo



                foreach (TreeNode nodo in materias.Select(materia => new TreeNode() { Text = materia, Value = materia }))
                {
                    this.TreeView1.Nodes.Add(nodo);
                }

                }
                */

                this.Label1.Text = (string)this.Request.QueryString["usuario"];
                mostar();

                int contador = 0;

               
                for (int i = 0; i < 3; i++)
                {
                    tablaGeneral.Rows.Add(new TableRow());

                    for (int k = 0; k < 3; k++)
                    {
                        tablaGeneral.Rows[i].Cells.Add(new TableCell());
                        tablaGeneral.Rows[i].Cells[k].Controls.Add(new Label() { Text = controladorVistaInicio.recuperarLibro(contador) });
                        contador++;
                    }
                }
            }
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


        protected void button_Buscar(object sender, EventArgs e)
        {
            string contenidoABuscar = txtBox_Busqueda.Text;
            string radioButtonCheckeado = radButtonChekeado();

            if(contenidoABuscar != "")
            {
                switch (radioButtonCheckeado)
                {
                    case "radioButton_Titulo":
                        //controladorVistaInicio.recuperarLibro();
                        break;
                    case "radioButton_Autor":
                        break;
                    case "radioButton_Isbn":
                        break;
                    case "radioButton_Editorial":
                        break;
                }
            }
            else
            {
                txtBox_Busqueda.Text = "No hay libro que buscar";
               
            }
        }

        public string radButtonChekeado()
        {
            string checkeado = "";

            foreach (RadioButton radio in form1.Controls)
            {
                if (radio.Checked)
                {
                    checkeado = radio.ID;
                }
                else
                {
                    checkeado = "";
                }

            }
            return checkeado;
        }
       
    }
}
