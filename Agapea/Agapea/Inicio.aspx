<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Agapea.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            height: 906px;
        }
        .auto-style3 {
            height: 83px;
        }
        .auto-style4 {
            height: 755px;
        }
        .auto-style5 {
            height: 23px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="Label1" runat="server" Text="Label">Bienvenid@ </asp:Label>
        <asp:Button ID="BotonComprarLibro" runat="server" Text="Comprar libro" />
        <table class="auto-style2" >
            <tr>
                <td colspan="5" class="auto-style3">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/encabezado_inicio.PNG" Width="1286px" Height="72px" />
                </td>
            </tr>
            <tr>
                <td rowspan="3">

                   
                    <asp:TreeView ID="TreeView1" runat="server">
                    </asp:TreeView>
                   
                   
                </td>
                <td colspan="4">

                    <asp:TextBox ID="txtBox_Busqueda" runat="server" Width="893px" Font-Names="Arial" Font-Size="Small" ForeColor="#666666"></asp:TextBox>
                    <asp:Button ID="btn_Buscar" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Arial" ForeColor="Blue" Height="25px" Text="Buscar" Width="99px" OnClick="button_Buscar" />

                </td>
                
            </tr>
            
            
            <tr>
                <td class="auto-style5">

                    <asp:RadioButton ID="radioButton_Titulo" runat="server" Checked="True" Font-Names="Arial" Font-Size="Small" Text="Titulo" />

                </td>
                
                <td aria-disabled="False" class="auto-style5">

                    <asp:RadioButton ID="radioButton_Autor" runat="server" Font-Names="Arial" Font-Size="Small" Text="Autor" />

                </td>
                
                <td class="auto-style5">

                    <asp:RadioButton ID="radioButton_Isbn" runat="server" Font-Names="Arial" Font-Size="Small" Text="Isbn" />

                </td>
                
                <td class="auto-style5">

                    <asp:RadioButton ID="radioButton_Editorial" runat="server" Font-Names="Arial" Font-Size="Small" Text="Editorial" />

                </td>
                
            </tr>
            
            
            <tr>

                <td class="auto-style4" colspan="4">
                    <asp:Table ID="tablaGeneral" runat="server">
                    </asp:Table>
                </td>
                

            </tr>
            <tr align ="center">
                <td colspan="5" >
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/pie_registro.PNG"  />
                </td>
            </tr>
        </table>
         <asp:TextBox ID="seguimientoTextBox" runat="server" Height="200px" TextMode="MultiLine" Width="634px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
