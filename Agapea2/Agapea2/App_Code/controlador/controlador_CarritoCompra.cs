using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea2.App_Code.modelo;
using Agapea2.App_Code.controlador;



namespace Agapea2.App_Code.controlador
{
    public class controlador_CarritoCompra
    {
        private controlador_AccesoFicheros miControlador = new controlador_AccesoFicheros();

        public List<string> recuperaLibros(string isbn_LibrosAComprar_String)
        {
            miControlador.RutaFichero = "~/ficheros/Libros.txt";
            miControlador.AbrirFichero("ruta", "leer");

            List<string> filas = miControlador.recuperarLineasFichero();

            List<string> librosRecuperadosFichero = new List<string>();

            List<string> isbns = isbn_LibrosAComprar_String.Split(new char[] { '$' }).ToList();

            foreach (string isbnLibros in isbns)
            {
                if (isbnLibros != "")
                {
                    string libroRecup = (from unaLinea in filas.Where(linea => linea.Split(new char[] { ':' })[5] == isbnLibros) select unaLinea).SingleOrDefault();
                    librosRecuperadosFichero.Add(libroRecup);
                }
                            
            }

            return librosRecuperadosFichero;
        }


        public List<Libro> fabricaLibro(List<string> librosTransform)
        {
            List<Libro> librosRecuperados = new List<Libro>();

            foreach (string libroATransformar in librosTransform)
            {
                Libro libroRecuperado = new Libro();
                string[] argumentos = libroATransformar.Split(new char[] { ':' });

                libroRecuperado.titulo = argumentos[0];
                libroRecuperado.autor = argumentos[1];
                libroRecuperado.editorial = argumentos[2];
                libroRecuperado.categoria = argumentos[3];
                libroRecuperado.subCategoria = argumentos[4];
                libroRecuperado.isbn10 = long.Parse(argumentos[5]);
                libroRecuperado.isbn13 = long.Parse(argumentos[6]);
                libroRecuperado.precio = decimal.Parse(argumentos[7]);
                libroRecuperado.numeroPaginas = int.Parse(argumentos[8]);
                libroRecuperado.resumen = argumentos[9];
                libroRecuperado.cantidadLibros = int.Parse(argumentos[10]);

                librosRecuperados.Add(libroRecuperado);
            }

            return librosRecuperados;

        }

    }
}