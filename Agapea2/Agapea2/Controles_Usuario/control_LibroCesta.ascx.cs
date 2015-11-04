using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.App_Code.modelo;

namespace Agapea2.Controles_Usuario
{
    public partial class control_LibroCesta : System.Web.UI.UserControl
    {
        #region ".......propiedades de mi control......."
        private string __titulo;
        private decimal __precioUnidad;
        private decimal __precioTotal;

        public string tituloLibro
        {
            get { return this.__titulo; }
            set
            {
                this.__titulo = value;
                this.linkButton_Titulo.Text = this.__titulo;
            }
        }
        public decimal precioLibro
        {
            get { return this.__precioUnidad; }
            set
            {
                this.__precioUnidad = value;
                this.label_PrecioUnidad.Text = this.__precioUnidad.ToString() + "€";
            }
        }

        public decimal precioTotal
        {
            get { return this.__precioTotal; }
            set
            {
                this.__precioTotal = value;
                this.label_PrecioTotal.Text = this.__precioTotal.ToString() + "€";
            }
        }

        #endregion

        #region ".......metodos de clase......."

        public control_LibroCesta() { }
        
        public control_LibroCesta(Libro libro)
        {
            this.tituloLibro = libro.titulo;
            this.precioLibro = libro.precio;
            this.precioTotal = libro.precio * Convert.ToDecimal(txtBox_Cantidad);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}