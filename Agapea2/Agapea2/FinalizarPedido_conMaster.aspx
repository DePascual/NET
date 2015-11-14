<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/master_VistaCompras.Master" AutoEventWireup="true" CodeBehind="FinalizarPedido_conMaster.aspx.cs" Inherits="Agapea2.FinalizarPedido_conMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 38px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor" style="position: relative; margin: auto; height: 50%; width: 50%; font:medium arial ">
        <asp:Panel ID="miPanel" runat="server">
           <%-- <table id="encabezado" style="width:100%; text-align:center">
                <tr>
                    <td style="width:20%">Referencia</td>
                    <td style="width:20%">Titulo</td>
                    <td style="width:20%">Autor</td>
                    <td style="width:20%">Unidades</td>
                    <td style="width:20%">Precio</td>
                </tr>
            </table>--%>
            <asp:Table ID="tablaLibros" runat="server" Font-Names="Arial" Font-Size="Medium" HorizontalAlign="Center" Width="100%" ></asp:Table>
        </asp:Panel>
    </div>
</asp:Content>
