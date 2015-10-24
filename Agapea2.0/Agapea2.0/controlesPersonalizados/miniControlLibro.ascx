<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="miniControlLibro.ascx.cs" Inherits="Agapea2._0.controlesPersonalizados.miniControlLibro" %>
<html>
<head></head>
<body>
    <table>
        <tr>
            <td rowspan="4" style="text-align: center">
                <asp:Image ID="img_Libro" runat="server" ImageUrl="~/imagenes/libro.png" />
            </td>
            <td colspan="2">
                <asp:LinkButton ID="linkButton_Titulo" runat="server" Font-Names="Arial" Font-Size="Medium">aqui va el titulo</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_Autor" runat="server" Text="aqui va el autor"></asp:Label>
            </td>
            <td>
                <asp:Label ID="label_Editorial" runat="server" Text="aqui va la editorial"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_Precio" runat="server" Text="aqui va el precio"></asp:Label>
            </td>
            <td>
                <asp:Label ID="label_ISBN" runat="server" Text="aqui va el isbn"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:ImageButton ID="btn_Comprar" runat="server" ImageUrl="~/imagenes/btn_comprar.PNG" />
            </td>
        </tr>
    </table>
</body>
</html>


