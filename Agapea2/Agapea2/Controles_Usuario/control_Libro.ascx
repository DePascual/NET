<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="control_Libro.ascx.cs" Inherits="Agapea2.Controles_Usuario.control_Libro" %>
<html>
<body>
    <table border='0' style='border-collapse: collapse;width:400px;height:170px'>
        <tr>
            <td rowspan="4">
                <asp:Image ID="img_Libro" runat="server" ImageUrl="~/imagenes/Libro.png" />
            </td>
            <td colspan="2" style='align-content: center'>
                <asp:LinkButton ID="linkButton_Titulo" runat="server" Font-Names="Arial" Font-Size="Medium">aqui va el titulo</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_Autor" runat="server" Font-Names="Arial" Font-Size="Medium" Text="aqui va el autor"></asp:Label>
            </td>
            <td>
                <asp:Label ID="label_Editorial" runat="server" Text="aqui va la editorial" Font-Names="Arial" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label_Precio" runat="server" Font-Names="Arial" Font-Size="Medium" Text="aqui va el precio"></asp:Label>
            </td>
            <td>
                <asp:Label ID="label_ISBN" runat="server" Font-Names="Arial" Font-Size="Medium" Text="aqui va el isbn"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:ImageButton ID="button_Comprar" runat="server" ImageUrl="~/imagenes/btn_Comprar.PNG"  />


            </td>
        </tr>

    </table>

</body>
</html>
