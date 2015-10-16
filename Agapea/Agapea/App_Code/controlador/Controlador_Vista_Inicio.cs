using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea.App_Code.modelo;
using Agapea.App_Code.controlador;
using System.Collections;

namespace Agapea.App_Code.controlador
{
    public class Controlador_Vista_Inicio
    {

        private Controlador_Acceso_Ficheros miControlador = new Controlador_Acceso_Ficheros();

        public string recuperarLibro(int contador)
        {

            miControlador.RutaFichero = "~/ficheros/Libros.txt";
            miControlador.AbrirFichero("ruta", "leer");

            string libroRecuperado = "";

            string[] librosRecuperados = miControlador.recuperaLibro();

            if (contador < librosRecuperados.Length)
            {
                for (int i = 0; i < contador + 1; i++)
                {
                    libroRecuperado = librosRecuperados[i];
                }
            }
            


   
            return libroRecuperado;
        }


        /*public ArrayList recuperarCategorias()
        {
            
        }*/
    }
}

