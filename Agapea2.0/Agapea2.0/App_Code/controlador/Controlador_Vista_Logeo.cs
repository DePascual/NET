using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea.App_Code.modelo;
using System.Collections;

namespace Agapea.App_Code.controlador
{
    public class Controlador_Vista_Logeo
    {
        private Controlador_Acceso_Ficheros miControlador = new Controlador_Acceso_Ficheros();

        public bool existeUsuario (string nombreUsuario, string passUsuario)
        {
            miControlador.RutaFichero = "~/ficheros/Usuarios.txt";
            miControlador.AbrirFichero("ruta", "leer");

            bool resultadoBusqueda = miControlador.existeUsuario(nombreUsuario, passUsuario);
            return resultadoBusqueda;
        }


    }
}