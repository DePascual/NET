using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agapea2.App_Code.controlador;
using Agapea2.App_Code.modelo;

namespace Agapea2.App_Code.controlador
{
    public class controlador_VistaInicio
    {
        private controlador_AccesoFicheros miControlador = new controlador_AccesoFicheros();

        public List<Libro> listaLibrosRecuperados()
        {
            List<Libro> listaLibrosRecuperados = new List<Libro>();

            miControlador.RutaFichero = "~/ficheros/Libros.txt";
            miControlador.AbrirFichero("ruta", "leer");

            List<string> lineasFicheroRecuperadas = miControlador.recuperarLineasFichero();

            for (int i = 0; i < lineasFicheroRecuperadas.Count; i++)
            {
                Libro libroRecuperado = new Libro();
                string[] argumentos = lineasFicheroRecuperadas[i].Split(new char[] { ':' });

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

                listaLibrosRecuperados.Add(libroRecuperado);
            }

            return listaLibrosRecuperados;

        }

        public Dictionary<String, List<string>> recuperarCatySub()
        {
            miControlador.RutaFichero = "~/ficheros/Libros.txt";
            miControlador.AbrirFichero("ruta", "leer");

            Dictionary<string, List<string>> CategoriasYSubcategorias = new Dictionary<string, List<string>>();

            List<string> filas = miControlador.recuperarLineasFichero();

            List<string> catYSubcat = filas.Select(f => f.Split(new char[] { ':' })[3] + ":" + f.Split(new char[] { ':' })[4]).Distinct().ToList();

            foreach (string tupla in catYSubcat)
            {
                string categoria = tupla.Split(new char[] { ':' })[0];

                if (!CategoriasYSubcategorias.Keys.Contains(categoria))
                {
                    List<string> subcategorias = (from elemento in catYSubcat
                                                  where categoria == elemento.Split(new char[] { ':' })[0].ToString()
                                                  select elemento.Split(new char[] { ':' })[1]).ToList();
                    CategoriasYSubcategorias.Add(categoria, subcategorias);
                }
            }
            return CategoriasYSubcategorias;
        }

        public List<Libro> recuperarLibrosPorCategoria(string parametro, string valor)
        {
            miControlador.RutaFichero = "~/ficheros/Libros.txt";
            miControlador.AbrirFichero("ruta", "leer");

            List<Libro> librosRecuperadosList = new List<Libro>();
            List<string> filas = miControlador.recuperarLineasFichero();

            List<string> librosDeLaCategoria = new List<string>();

            switch (parametro)
            {
                case "Categoria":
                    librosDeLaCategoria = (from unaLinea in filas
                                           let categoria = unaLinea.Split(new char[] { ':' })[3].ToString()
                                           where valor == categoria
                                           select unaLinea).ToList();
                    break;

                case "Subcategoria":
                    librosDeLaCategoria = (from unaLinea in filas
                                           let subCategoria = unaLinea.Split(new char[] { ':' })[4].ToString()
                                           where valor == subCategoria
                                           select unaLinea).ToList();
                    break;
            }

            for (int i = 0; i < librosDeLaCategoria.Count; i++)
            {
                string[] argumentos = librosDeLaCategoria[i].Split(new char[] { ':' });

                Libro libroRecuperado = new Libro();

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

                librosRecuperadosList.Add(libroRecuperado);
            }


            return librosRecuperadosList;
        }

    }
}