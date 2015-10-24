<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MiniControlLibro.ascx.cs" Inherits="Agapea.Controles_Personalizados.MiniControlLibro" %>
<style type="text/css">
    .auto-style1 {
        width: 357px;
        height: 82px;
    }
    .auto-style2 {
        width: 87px;
    }
</style>

<table class="auto-style1" border='1' style='border-collapse:collapse' >
    <tr>
        <td class="auto-style2" rowspan="4">
            <asp:Image ID="img_Libro" runat="server" />
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
        <td colspan="2">
            <asp:Button ID="button_Comprar" runat="server" Font-Names="Arial" Font-Size="Small" Text="Comprar" />
            <br />
            <br />
        </td>
    </tr>

</table>
