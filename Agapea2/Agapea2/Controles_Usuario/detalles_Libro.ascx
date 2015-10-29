<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="detalles_Libro.ascx.cs" Inherits="Agapea2.Controles_Usuario.detalles_Libro" %>
<html>
    <style type="text/css">
        .auto-style1 {
            width: 77px;
        }
    </style>

    <body>
        <table>
            <tr>
                <td rowspan="7" class="auto-style1">
                    <asp:Image ID="Image1" runat="server" />
                </td>
                <td colspan="3">
                    <asp:Label ID="label_Titulo" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" Text="titulo libro"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="label_Autor" runat="server" Text="autor" Font-Names="Arial"></asp:Label>
                </td>
                <td rowspan="3"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="label_Editorial" runat="server" Text="editorial" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="label_Isbn" runat="server" Text="isbn" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="label_Precio" runat="server" Text="precio" Font-Names="Arial"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="label_Isbn0" runat="server" Text="Entrega de 1 a 7 días por envío urgente" Font-Names="Arial" Font-Size="Small" ForeColor="#009933"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Image ID="btn_Comprar" runat="server" ImageUrl="~/imagenes/btn_Comprar.PNG" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="label_Resumen" runat="server" Font-Names="Arial" Text="Resumen libro"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="label_Indice" runat="server" Font-Names="Arial" Text="Indice libro"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="label_Valoracion" runat="server" Font-Names="Arial" Text="Valoracion"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="label_Apodo" runat="server" Font-Names="Arial" Text="Apodo"></asp:Label>
                    <asp:TextBox ID="txtBox_Apodo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="TextBox1" runat="server" Height="98px" Width="747px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_EnviarValoracion" runat="server" Text="Envía tu valoración" />
                </td>
            </tr>
        </table>
    </body>
</html>