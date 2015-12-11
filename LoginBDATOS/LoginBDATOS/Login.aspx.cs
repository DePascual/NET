using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

namespace LoginBDATOS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonEntrar_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                using (SqlConnection miConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexionSQLSERVER"].ConnectionString))
                {
                    try
                    {
                        miConexion.Open();
                        //ASI SI USO SELECT
                        //SqlCommand miSelect = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE NOMBRE=@nombre AND PASSWORD=@password", miConexion);

                        /*ASI SI USO UN PROCEDIMIENTO ALMACENADO. 1ºHACEMOS EL PROCEDURE EN LA PANTALLA DE SQL
                        LOS GUARDA EN: AGAPEA->PROGRAMACION->PROCEDIMIENTOS ALMACENADOS

                        CREATE PROCEDURE ExisteUsuario
	                        @Nombre varchar(50), 
                             @Password nchar(15)
                        AS
                        SET NOCOUNT ON;
	                    SELECT * FROM dbo.Usuarios WHERE Nombre=@Nombre AND Password=@Password;

                        CON ESTO PRUEBO SI FUNCIONA O NO
                        exec dbo.ExisteUsuario @NOMBRE = 'carol', @PASSWORD = '1234';*/

                        SqlCommand miSelect = new SqlCommand("dbo.ExisteUsuario", miConexion);
                        miSelect.CommandType = System.Data.CommandType.StoredProcedure;

                        miSelect.Parameters.Add("nombre", System.Data.SqlDbType.VarChar, 50);
                        miSelect.Parameters["nombre"].Value = txtBoxNombre.Text;

                        miSelect.Parameters.Add("password", System.Data.SqlDbType.NChar, 15);
                        miSelect.Parameters["password"].Value = txtBoxPassword.Text;

                        if (miSelect.ExecuteReader().HasRows == true)
                        {
                            Response.Redirect("tienda.aspx");
                        }
                        else
                        {
                            Response.Redirect("registro.aspx");
                        }
                    }
                    catch (SqlException ex)
                    {

                    }
                    finally
                    {
                        miConexion.Close();
                    }

                }
            }
        }
    }
}