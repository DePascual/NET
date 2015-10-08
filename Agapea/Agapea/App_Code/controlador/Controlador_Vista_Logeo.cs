﻿using System;
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

        public Usuario recuperarUsuario()
        {
            miControlador.RutaFichero = "~/ficheros/Usuarios.txt";
            miControlador.AbrirFichero("ruta", "leer");

            ArrayList arrayUsuariosRecuperados = new ArrayList(miControlador.RecuperarDatos());

            string[] usuarioRecuperadorString = (string[])arrayUsuariosRecuperados.ToArray(typeof(string));

            Usuario usuarioRecuperado = new Usuario();

            for (int i = 0; i < arrayUsuariosRecuperados.Count; i++)
            {
                string[]argUsuarioRecuperado = usuarioRecuperadorString[i].Split(new char[] { ':' });
                usuarioRecuperado.loginUsuario = argUsuarioRecuperado[3].ToString();
                usuarioRecuperado.passwordUsuario = argUsuarioRecuperado[4].ToString();
            }
            return usuarioRecuperado;
        }

    }
}