using Agapea.App_Code.modelo;
using System.Web;
using Agapea.App_Code.controlador;


namespace Agapea.App_Code.controlador
{
    public class Controlador_Vista_Registro
    {
        private Controlador_Acceso_Ficheros miControlador = new Controlador_Acceso_Ficheros();


        public Usuario GrabarDatosUsuarios(string Nombre, string Apellidos, string Mail, string Login, string Pass)
        {


            Usuario nuevoUsuario = new Usuario();

            nuevoUsuario.nombreUsuario = Nombre;
            nuevoUsuario.apellidoUsuario = Apellidos;
            nuevoUsuario.emailUsuario = Mail;
            nuevoUsuario.loginUsuario = Login;
            nuevoUsuario.passwordUsuario = Pass;

            miControlador.RutaFichero = "~/ficheros/Usuarios.txt";

            miControlador.AbrirFichero("ruta", "escribir");
            miControlador.GrabarDatos(nuevoUsuario);

            return nuevoUsuario;


        }

    }
}