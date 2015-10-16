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

        public Libro recuperarLibro(int contador)
        {

            miControlador.RutaFichero = "~/ficheros/Libros.txt";
            miControlador.AbrirFichero("ruta", "leer");

            Libro libroRecuperado = new Libro();
           // libroRecuperado.titulo = miControlador.RecuperarDatos("libro", 0).ToString();

            /*
            // controladorInicio.RecuperarDatos(); //Me devuelve el array con todos los libros del archivo

            ArrayList librosArchivo = new ArrayList(controladorInicio.RecuperarDatos());

            string [] librosArchivoString = (string[])librosArchivo.ToArray(typeof(string));//Paso los elementos del arrayList a un array normal


            Libro libroRecuperado = new Libro();

            //Cada posición es un libro, pero en forma de cadena separado por :
         
            if(contador < librosArchivoString.Length)
            {
                for (int i = 0; i < contador + 1; i++)
                {
                    string[] arrayArgsLibro = librosArchivoString[i].Split(new char[] { ':' });
                    libroRecuperado.titulo = arrayArgsLibro[0].ToString();
                    libroRecuperado.autor = arrayArgsLibro[1].ToString();
                    libroRecuperado.editorial = arrayArgsLibro[2].ToString();
                    libroRecuperado.categoria = arrayArgsLibro[3].ToString();
                    libroRecuperado.resumen = arrayArgsLibro[8].ToString();

                    try
                    {
                        libroRecuperado.isbn10 = Convert.ToInt64(arrayArgsLibro[4].ToString());
                        libroRecuperado.isbn13 = Convert.ToInt64(arrayArgsLibro[5].ToString());
                        libroRecuperado.precio = Convert.ToSingle(arrayArgsLibro[6].ToString());
                        libroRecuperado.numeroPaginas = Convert.ToInt32(arrayArgsLibro[7].ToString());
                        libroRecuperado.cantidadLibros = Convert.ToInt32(arrayArgsLibro[9].ToString());
                    }
                    catch (FormatException fe)
                    {
                        Console.Write("La cadena no es una secuencia de numeros");
                    }                 
                }
            }*/                     
            return libroRecuperado;
        }


        /*public ArrayList recuperarCategorias()
        {
            
        }*/
    }
}

