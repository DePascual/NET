using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Agapea.App_Code.modelo;
using Agapea.App_Code.controlador;
using System.Collections;

namespace Agapea.App_Code.controlador
{
    public class Controlador_Acceso_Ficheros
    {

        private StreamReader __lectorFichero;
        private StreamWriter __escritorFichero;
        private string __strFichero;
        private FileStream fichero;



        public string RutaFichero
        {
            get { return __strFichero; }
            set { __strFichero = HttpContext.Current.Request.MapPath(value); }
        }


        //public string RutaFichero { get; set;  }

        public Boolean AbrirFichero(string ruta, string accion)
        {
            try
            {

                switch (accion)
                {
                    case "escribir":
                        __escritorFichero = new StreamWriter(new FileStream(RutaFichero, FileMode.Append, FileAccess.Write));
                        break;

                    case "leer":
                        __lectorFichero = new StreamReader(new FileStream(RutaFichero, FileMode.Open, FileAccess.Read));
                        break;

                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public Boolean GrabarDatos(Usuario nuevoUsuario)
        {
            try
            {
                //esto se puede generalizar y pasarlo al método en cuestion MIRARRRRR!!!!
                __escritorFichero.WriteLine(nuevoUsuario.nombreUsuario.ToUpper() + ":" +
                                            nuevoUsuario.apellidoUsuario.ToUpper() + ":" +
                                            nuevoUsuario.emailUsuario.ToUpper() + ":" +
                                            nuevoUsuario.loginUsuario.ToUpper() + ":" +
                                            nuevoUsuario.passwordUsuario.ToUpper());
                __escritorFichero.Flush();
                __escritorFichero.Close();
                return true;
            }
            catch (IOException e)
            {
                return false;
            }


        }

        public bool existeUsuario (string usuario, string password)
        {
            bool resultadoBusqueda = (from unalinea in this.__lectorFichero.ReadToEnd().Split(new char[] { '\r','\n'}).Where(linea=>! new System.Text.RegularExpressions.Regex("^$").Match(linea).Success)
                                      let campoUsuario = unalinea.Split(new char[] { ':' })[3]
                                      let campoPass = unalinea.Split(new char[] { ':' })[4]
                                      where usuario == campoUsuario && password == campoPass
                                      select true).Single();
            return resultadoBusqueda == true ? true : false;
        }


        public string [] recuperaLibro()
        {
            string [] lineas = new string[] { };

            lineas = (from unaLinea in this.__lectorFichero.ReadToEnd().Split(new char[] { '\r', '\n' }).Where(linea => !new System.Text.RegularExpressions.Regex("^$").Match(linea).Success)
                      select unaLinea).ToArray();

            return lineas;
        }



        /*public string[] RecuperarDatos(string filtro, int numCampo, string valorBuscado)
        {
            string[] lineas = new string[] { };

            switch (filtro)
            {
                case "usuario":
                    lineas = (from unaLinea in this.__lectorFichero.ReadToEnd().Split(new char[] { '\n' })
                              where unaLinea.Split(new char [] { ':'})[numCampo]==valorBuscado
                              select unaLinea).ToArray();
                    break;

                case "libro":
                    lineas = (from unaLinea in this.__lectorFichero.ReadToEnd().Split(new char[] { '\n' })
                              where unaLinea.Split(new char[] { ':' })[numCampo] == valorBuscado
                              select unaLinea).ToArray();
                    break;

                case "categoria":
                    lineas = (from unaLinea in this.__lectorFichero.ReadToEnd().Split(new char[] { '\n' })
                              let categoriaLinea = unaLinea.Split(new char[] { ':' })[numCampo]
                              where categoriaLinea == filtro
                              select unaLinea).ToArray();
                    break;
            }





            return lineas;
        }*/

    }
}