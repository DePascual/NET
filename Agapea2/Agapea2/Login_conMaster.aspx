<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/master_Login.Master" AutoEventWireup="true" CodeBehind="Login_conMaster.aspx.cs" Inherits="Agapea2.Login_conMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tablaLogeo" style="position:absolute; margin-left:auto; margin-right:auto">
    <table>
        <tr>
            <td style="text-align: right;" class="auto-style1" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Medium" Text="Usuario:"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtBx_nombreUsuario" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="#666666" CssClass="auto-style2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" colspan="2">
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Medium" Text="Contraseña:"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtBx_passwordUsuario" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="#666666" CssClass="auto-style2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">                
            </td>
            <td colspan="2" >
                <asp:ImageButton ID="btn_identificarme" runat="server" ImageUrl="~/imagenes/btn_identificate.PNG" OnClick="btn_identificarme_Click" />
            </td>
        </tr>
        <tr>
            <td>                
            </td>
            <td colspan="2">
                <asp:Label ID="labelError" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red" Text="El usuario no está registrado" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Text="Si aun no estás registrado, ¿a qué esperas?. Haz Click en Registrarme"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  colspan="2"></td>
            <td  colspan="2">
                <asp:ImageButton ID="btn_registrarme" runat="server" ImageUrl="~/imagenes/btn_registrame.png" OnClick="btn_registarme" />
            </td>
        </tr>
    </table>
        </div>
</asp:Content>
