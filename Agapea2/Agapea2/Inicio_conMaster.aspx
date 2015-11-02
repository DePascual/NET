<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/master_VistasPrincipales.Master" AutoEventWireup="true" CodeBehind="Inicio_conMaster.aspx.cs" Inherits="Agapea2.Inicio_conMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtBox_Buscador" runat="server" Width="698px" Font-Names="Arial" Font-Size="Medium" ForeColor="#666666"></asp:TextBox>
            <asp:Button ID="button_Buscar" runat="server" Text="Buscar" BackColor="White" BorderColor="#000066" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#000066" OnClick="button_Buscar_Click" />
            <asp:RadioButton  ID="radioButton_Titulo" runat="server" Font-Names="Arial" Font-Size="Medium" Text="Titulo" OnCheckedChanged="radioButton_CheckedChanged" GroupName="busqueda" />
             <asp:RadioButton ID="radioButton_Autor" runat="server" Font-Names="Arial" Font-Size="Medium" Text="Autor" OnCheckedChanged="radioButton_CheckedChanged"  GroupName="busqueda" />
            <asp:RadioButton ID="radioButton_ISBN" runat="server" Font-Names="Arial" Font-Size="Medium" Text="ISBN" OnCheckedChanged="radioButton_CheckedChanged"  GroupName="busqueda" />
    <asp:Table ID="tablaLibros" runat="server">
    </asp:Table>
</asp:Content>
