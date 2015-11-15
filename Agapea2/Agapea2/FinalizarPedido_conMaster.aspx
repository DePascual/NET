<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/master_VistaCompras.Master" AutoEventWireup="true" CodeBehind="FinalizarPedido_conMaster.aspx.cs" Inherits="Agapea2.FinalizarPedido_conMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor" style="position: relative; margin: auto; height: 50%; width: 50%; font:medium arial ">
        <asp:Label ID="Label1" runat="server" Text="Resúmen Factura" Font-Names="Arial" Font-Size="Medium"></asp:Label>
        <asp:Panel ID="miPanel" runat="server">         
            <asp:Table ID="tablaLibros" runat="server" Font-Names="Arial" Font-Size="Medium" HorizontalAlign="Center" Width="100%" ></asp:Table>
        </asp:Panel>
    </div>
    <asp:ImageButton ID="button_FinalizarPedido" runat="server" ImageUrl="~/imagenes/btn_FinalizarPedido.PNG" />
</asp:Content>
