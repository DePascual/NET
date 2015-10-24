using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agapea.App_Code.modelo;

namespace Agapea.Controles_Personalizados
{
    public partial class MiniControlLibro : System.Web.UI.UserControl
    {
        #region ".......propiedades de mi control......."
        private string __titulo;
        private string __editorial;
        private string __autor;
        private long __isbn;
        private decimal __precio;

        public string tituloLibro
        {
            get { return this.__titulo; }
            set
            {
                this.__titulo = value;
                this.linkButton_Titulo.Text = this.__titulo;
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

        public string autorLibro
        {
            get { return this.__autor; }
            set
            {
                this.__autor = value;
                this.label_Autor.Text = this.__autor;
            }
        }

        public long isbnLibro
        {
            get { return this.__isbn; }
            set
            {
                this.__isbn = value;
                this.label_ISBN.Text = this.__isbn.ToString();
            }
        }

        public decimal precioLibro
        {
            get { return this.__precio; }
            set
            {
                this.__precio = value;
                this.label_Precio.Text = this.__precio.ToString();
            }
        }


        #endregion

        #region ".......metodos de clase......."

        public MiniControlLibro() { }
        public MiniControlLibro(Libro unLibro)
        {
            this.tituloLibro = unLibro.titulo;
            this.editorialLibro = unLibro.editorial;
            this.autorLibro = unLibro.autor;
            this.isbnLibro = unLibro.isbn10;
            this.precioLibro = unLibro.precio;
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}