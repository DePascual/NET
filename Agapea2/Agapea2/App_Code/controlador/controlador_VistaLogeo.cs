using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea2.App_Code.controlador;

namespace Agapea2.App_Code.controlador
{
    public class controlador_VistaLogeo
    {

        private controlador_AccesoFicheros miControlador = new controlador_AccesoFicheros();

        public bool existeUsuario(string nombreUsuario, string passUsuario)
        {
            miControlador.RutaFichero = "~/ficheros/usuarios.txt";
            miControlador.AbrirFichero("ruta", "leer");

            bool resultadoBusqueda = miControlador.existeUsuario(nombreUsuario, passUsuario);
            return resultadoBusqueda;
        }
    }
}