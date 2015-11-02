using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea2.App_Code.modelo;

namespace Agapea2.Controles_Usuario
{
    public partial class detalles_Libro : System.Web.UI.UserControl
    {

        #region ".......propiedades de mi control......."
        private string __titulo;
        private string __autor;
        private string __editorial;
        private long __isbn;
        private decimal __precio;
        private string __resumen;
        private string __indice;

        public string tituloLibro
        {
            get { return this.__titulo; }
            set
            {
                this.__titulo = value;
                this.label_Titulo.Text = this.__titulo;
            }
        }

        public string autorLibro
        {
            get { return this.__autor; }
            set
            {
                this.__autor = value;
                this.label_Autor.Text = this.__autor;
            }
        }

        public string editorialLibro
        {
            get { return this.__editorial; }
            set
            {
                this.__editorial = value;
                this.label_Editorial.Text = this.__editorial;
            }
        }

      
        public long isbnLibro
        {
            get { return this.__isbn; }
            set
            {
                this.__isbn = value;
                this.label_Isbn.Text = this.__isbn.ToString();
            }
        }

        public decimal precioLibro
        {
            get { return this.__precio; }
            set
            {
                this.__precio = value;
                this.label_Precio.Text = this.__precio.ToString() + "euros";
            }
        }

        public string resumenLibro
        {
            get { return this.__resumen; }
            set
            {
                this.__resumen = value;
                this.label_Resumen.Text = this.__resumen;
            }
        }

        public string indiceLibro
        {
            get { return this.__indice; }
            set
            {
                this.__indice = value;
                this.label_Indice.Text = this.__indice;
            }
        }
        #endregion

        #region ".......metodos de clase......."

        public detalles_Libro() { }
        public detalles_Libro(Libro unLibro)
        {
            this.tituloLibro = unLibro.titulo;
            this.autorLibro = unLibro.autor;
            this.editorialLibro = unLibro.editorial;       
            this.isbnLibro = unLibro.isbn10;
            this.precioLibro = unLibro.precio;
            this.resumenLibro = unLibro.resumen;
            this.indiceLibro = unLibro.indice;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}