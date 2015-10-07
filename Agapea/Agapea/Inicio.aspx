<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Agapea.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            height: 546px;
        }
        .auto-style3 {
            height: 83px;
        }
        .auto-style4 {
            height: 369px;
        }
        .auto-style5 {
            height: 369px;
            width: 97px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table border="1" class="auto-style2" >
            <tr>
                <td colspan="2" class="auto-style3">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/encabezado_inicio.PNG" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style4">
                    <asp:Table ID="tablaGeneral" runat="server">
                    </asp:Table>
                </td>
            </tr>
            <tr aling ="center">
                <td colspan="2" >
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/pie_registro.PNG"  />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
