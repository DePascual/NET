<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="BDATOS_sinConexion.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="REGISTRO"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="textBoxNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="textBoxApellidos" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="NIF"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxNIF" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Direccion"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="textBoxDireccion" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Localidad"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="textBoxLocalidad" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Provincia"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxProvincia" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="buttonRegistro" runat="server" Text="Registrar" OnClick="buttonRegistro_Click" /></td>
                    <td>
                        <asp:Button ID="buttonModificar" runat="server" Text="Modificar" OnClick="buttonModificar_Click" /></td>
                    <td>
                        <asp:Button ID="buttonBorrar" runat="server" Text="Borrar" OnClick="buttonBorrar_Click" /></td>
                    <td>
                        <asp:Button ID="buttonFinalizar" runat="server" Text="Finalizar" OnClick="buttonFinalizar_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
