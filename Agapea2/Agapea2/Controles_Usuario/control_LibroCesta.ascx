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
                <asp:Button ID="button_BorrarLibro" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Red" Text="X" />
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td> 
                            <asp:Button ID="button_Menos" runat="server" Text="-" BackColor="White" BorderColor="#666666" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#990000" />
                        </td>
                        <td>
                             <asp:Label ID="label_Cantidad" runat="server" Font-Names="Arial" Font-Size="Medium"></asp:Label>
                        </td>
                        <td>
                             <asp:Button ID="button_Mas" runat="server" Text="+" BackColor="White" BorderColor="#666666" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#990000" />
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Medium" Text="  x" ></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="label_PrecioUnidad" runat="server" Font-Names="Arial" Font-Size="Medium" Text="precio" ForeColor="#990000"></asp:Label>
                        </td>
                    </tr>
                </table>                         
            </td>
            <td>
                <asp:Label ID="label_PrecioTotal" runat="server" Font-Names="Arial" Font-Size="Medium" Text="precio" ForeColor="#990000"></asp:Label>
            </td>
            
        </tr>
       
    </table>
</body>
</html>
