using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea.App_Code.modelo;
using Agapea.App_Code.controlador;
using System.Collections;
using Agapea.Controles_Personalizados;

namespace Agapea.App_Code.controlador
{
    public class Controlador_Vista_Inicio
    {

        private Controlador_Acceso_Ficheros miControlador = new Controlador_Acceso_Ficheros();

        public List<Libro> listaLibrosRecuperados()
        {
            List<Libro> listaLibrosRecuperados = new List<Libro>();

            miControlador.RutaFichero = "~/ficheros/Libros.txt";
            miControlador.AbrirFichero("ruta", "leer");

            string[] lineasFicheroRecuperadas = miControlador.recuperaLibro();

            for (int i = 0; i < lineasFicheroRecuperadas.Length; i++)
            {
                Libro libroRecuperado = new Libro();
                string[] argumentos = lineasFicheroRecuperadas[i].Split(new char[] { ':' });

                libroRecuperado.titulo = argumentos[0];
                libroRecuperado.autor = argumentos[1];
                libroRecuperado.editorial = argumentos[2];
                libroRecuperado.categoria = argumentos[3];
                libroRecuperado.isbn10 = long.Parse(argumentos[4]);
                libroRecuperado.isbn13 = long.Parse(argumentos[5]);
                libroRecuperado.precio = decimal.Parse(argumentos[6]);
                libroRecuperado.numeroPaginas = int.Parse(argumentos[7]);
                libroRecuperado.resumen = argumentos[8];
                libroRecuperado.cantidadLibros = int.Parse(argumentos[9]);

                listaLibrosRecuperados.Add(libroRecuperado);
            }

            return listaLibrosRecuperados;

        }



        /*public ArrayList recuperarCategorias()
        {
            
        }*/
    }
}

