﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Agapea2.App_Code.controlador;
using Agapea2.App_Code.modelo;
using Agapea2.Controles_Usuario;

namespace Agapea2
{
    public partial class Compras_conMaster : System.Web.UI.Page
    {
        private controlador_CarritoCompra miControladorCompra = new controlador_CarritoCompra();

        CarritoCompra cesta = new CarritoCompra();


        private void Dibuja_Tabla(List<Libro> librosAPintarList)
        {
            cesta.valoresLibros = new List<decimal>();

            for (int i = 0; i < librosAPintarList.Count(); i++)
            {
                tablaLibrosCesta.Rows.Add(new TableRow());

                for (int k = 0; k < 1; k++)
                {
                    tablaLibrosCesta.Rows[i].Cells.Add(new TableCell());
                    Libro libro = librosAPintarList.ElementAt(i);

                    control_LibroCesta unLibro;

                    unLibro = (control_LibroCesta)LoadControl("~/Controles_Usuario/control_LibroCesta.ascx");

                    Label cantidad = (Label)unLibro.FindControl("label_Cantidad");
                    Button borrar = (Button)unLibro.FindControl("button_BorrarLibro");
                    borrar.ID += "$" + libro.isbn10;

                    unLibro.tituloLibro = libro.titulo;
                    unLibro.precioLibro = libro.precio;
                    unLibro.precioTotal = libro.precio * Convert.ToDecimal(cantidad.Text);

                    cesta.valoresLibros.Add(Convert.ToDecimal(unLibro.precioTotal));
                    tablaLibrosCesta.Rows[i].Cells[k].Controls.Add(unLibro);                  
                }             
            }

            pintarTotales();
        }

        public void pintarTotales()
        {
            decimal sumatorio = 0;
            decimal total = 0;
            foreach (decimal precio in cesta.valoresLibros)
            {              
                sumatorio += precio;               
            }
            total = sumatorio + Convert.ToDecimal("3,50");

            ContentPlaceHolder miContentPlaceHolder;
            Label precioSub;
            Label gastosEnv;
            Label precioAPagar;

            miContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            if (miContentPlaceHolder != null)
            {
                precioSub = (Label)miContentPlaceHolder.FindControl("label_Subtotal");
                gastosEnv = (Label)miContentPlaceHolder.FindControl("label_GastosEnvio");
                precioAPagar = (Label)miContentPlaceHolder.FindControl("label_TotalAPagar");

                if (precioSub != null)
                {
                    precioSub.Text = sumatorio.ToString();
                }

                if (gastosEnv != null)
                {
                    gastosEnv.Text = "3,50";
                }

                if(precioAPagar != null)
                {
                    precioAPagar.Text = total.ToString();
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection coleccionCookies_userInfo;

            if (Request.Cookies["userInfo"] != null)
            {
                coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                Label labelUsu = (Label)this.Master.FindControl("label_idUsuario");
                if (labelUsu != null)
                {
                    labelUsu.Text = labelUsu.Text + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper();
                }

            }

            if (!IsPostBack)
            {
                if (Request.Cookies["userInfo"] != null)
                {
                    coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                    string isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString();               
                    List<Libro> LibrosAComprar = miControladorCompra.fabricaLibro(miControladorCompra.recuperaLibros(isbn_LibrosAComprar_String));              
                    Dibuja_Tabla(LibrosAComprar);
                }
            }
            else
            {
                foreach (string clave in Request.Params.AllKeys)
                {
                    if (clave.Contains("button_SeguirComprando"))
                    {
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        this.Response.Redirect("Inicio_conMaster.aspx?usuario=" + Server.HtmlEncode(coleccionCookies_userInfo["nombreUsu"]).ToUpper() + "$libro=" + Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]));
                    }

                    if (clave.Contains("button_BorrarLibro"))
                    {
                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;

                        string isbnABorrar = clave.Split(new char[] { '$' })[4];
                        string isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString().Replace("$" + isbnABorrar, "");

                        HttpCookie miCookie = Request.Cookies["userInfo"];
                        miCookie.Values["isbn_LibrosAComprar"] = isbn_LibrosAComprar_String;
                        if(miCookie.Values["isbn_LibrosAComprar"].Count() == 0)
                        {
                            miCookie.Values.Remove("isbn_LibrosAComprar");
                        };
                        Response.Cookies.Add(miCookie);

                        List<Libro> LibrosAComprar = miControladorCompra.fabricaLibro(miControladorCompra.recuperaLibros(isbn_LibrosAComprar_String));
                        Dibuja_Tabla(LibrosAComprar);


                    }

                    if (clave.Contains("button_Menos"))
                    {
                        control_LibroCesta unLibro;

                        unLibro = (control_LibroCesta)LoadControl("~/Controles_Usuario/control_LibroCesta.ascx");

                        Label cantidad = (Label)unLibro.FindControl("label_Cantidad");
                        if (Convert.ToDecimal(cantidad.Text) < 0)
                        {
                            cantidad.Text = "1";
                        }
                        else
                        {
                           cantidad.Text = (Convert.ToDecimal(cantidad.Text) - 1).ToString();
                        }


                    }

                    if (clave.Contains("button_Mas"))
                    {
                        control_LibroCesta unLibro;

                        unLibro = (control_LibroCesta)LoadControl("~/Controles_Usuario/control_LibroCesta.ascx");

                        Label cantidad = (Label)unLibro.FindControl("label_Cantidad");

                        cantidad.Text = (Convert.ToDecimal(cantidad.Text) + 1).ToString();

                        coleccionCookies_userInfo = Request.Cookies["userInfo"].Values;
                        string isbn_LibrosAComprar_String = Server.HtmlEncode(coleccionCookies_userInfo["isbn_LibrosAComprar"]).ToString();
                        List<Libro> LibrosAComprar = miControladorCompra.fabricaLibro(miControladorCompra.recuperaLibros(isbn_LibrosAComprar_String));
                        Dibuja_Tabla(LibrosAComprar);

                    }

                }


            }
        }
    }
}