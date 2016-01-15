using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace BDATOS_sinConexion
{
    public partial class Registro : System.Web.UI.Page
    {
        private DataSet miDataSet = new DataSet();
        private SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexionSQLSERVER"].ConnectionString);
        private SqlDataAdapter adaptadorUsuarios;
        private SqlCommandBuilder builderUsuarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                using (this.conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexionSQLSERVER"].ConnectionString))
                {
                    try
                    {
                        this.conexionBD.Open();
                        adaptadorUsuarios = new SqlDataAdapter("SELECT * FROM Clientes", this.conexionBD);
                        builderUsuarios = new SqlCommandBuilder(adaptadorUsuarios);
                        adaptadorUsuarios.Fill(miDataSet, "Clientes");
                    }
                    catch (SqlException ex)
                    {
                    }
                    finally { this.conexionBD.Close();
                        Session["miDataSet"] = this.miDataSet;
                    }
                }
            }
            else
            {
                this.miDataSet = (DataSet)Session["miDataSet"];
            }       
        }

        protected void buttonRegistro_Click(object sender, EventArgs e)
        {
            DataTable miTabla = miDataSet.Tables["Clientes"];
            miTabla.Rows.Add(new object[] { this.textBoxNIF.Text, this.textBoxNombre.Text, this.textBoxApellidos.Text, this.textBoxDireccion.Text, this.textBoxLocalidad.Text, this.textBoxProvincia.Text });
        }

        protected void buttonModificar_Click(object sender, EventArgs e)
        {
            DataTable miTabla = miDataSet.Tables["Clientes"];
            foreach (DataRow fila in miTabla.Rows)
            {
                if ((string)fila["NIF"] == this.textBoxNIF.Text)
                {
                    fila["Nombre"] = this.textBoxNombre.Text;
                    fila["Apellidos"] = this.textBoxApellidos.Text;
                    fila["Direccion"] = this.textBoxDireccion.Text;
                    fila["Localidad"] = this.textBoxLocalidad.Text;
                    fila["Provincia"] = this.textBoxProvincia.Text;
                }
            }
        }

        protected void buttonBorrar_Click(object sender, EventArgs e)
        {
            DataTable miTabla = miDataSet.Tables["Clientes"];
            foreach (DataRow fila in miTabla.Rows)
            {
                if ((string)fila["NIF"] == this.textBoxNIF.Text)
                {
                    miTabla.Rows.Remove(fila);
                }
            }

            //miTabla.Rows.Remove(miTabla.Rows.Cast<DataRow>().Where(fila => fila["NIF"] == this.textBoxNIF.Text));

        }

        protected void buttonFinalizar_Click(object sender, EventArgs e)
        {
            using (this.conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexionSQLSERVER"].ConnectionString))
            {
                try
                {
                    this.conexionBD.Open();
                    this.adaptadorUsuarios.Update(this.miDataSet.Tables["Clientes"]);
                    this.miDataSet.AcceptChanges();

                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    this.conexionBD.Close();
                }
            }
        }
    }
}