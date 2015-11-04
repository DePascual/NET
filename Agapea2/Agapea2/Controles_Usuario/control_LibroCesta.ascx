<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="control_LibroCesta.ascx.cs" Inherits="Agapea2.Controles_Usuario.control_LibroCesta" %>
<html>
<style type="text/css">
    .imgLibro {
        width: 28px;
    }  
    .auto-style1 {
        margin-bottom: 0px;
    }
    .auto-style2 {
        height: 26px;
    }
</style>

<body>
    <table>
        
        <tr>
            <td rowspan="2" style="margin-left: auto; margin-right: auto;" class="imgLibro">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/minilibro.PNG" />
            </td>
            <td class="auto-style2">
                <asp:LinkButton ID="linkButton_Titulo" runat="server" Font-Names="Arial" Font-Size="Medium">Titulo</asp:LinkButton>
            </td>
            <td class="auto-style2">
                <asp:Button ID="Button1" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Red" Text="X" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtBox_Cantidad" runat="server" CssClass="auto-style1" Font-Names="Arial" Font-Size="Medium" Width="24px">1</asp:TextBox>
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Medium" Text="  x" ></asp:Label>
                <asp:Label ID="label_PrecioUnidad" runat="server" Font-Names="Arial" Font-Size="Medium" Text="precio" ForeColor="#990000"></asp:Label>
            </td>
            <td>
                <asp:Label ID="label_PrecioTotal" runat="server" Font-Names="Arial" Font-Size="Medium" Text="precio" ForeColor="#990000"></asp:Label>
            </td>
        </tr>
       
    </table>
</body>
</html>
