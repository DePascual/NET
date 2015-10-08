<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logeo.aspx.cs" Inherits="Agapea.Logeo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 567px;
        }

        .auto-style2 {
            height: 512px;
        }

        .auto-style3 {
            height: 66px;
        }
        .auto-style4 {
            height: 46px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/encabezado_logeo.PNG" Height="82px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <table align="center" cellspacing="5px" id="tablaLogin">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" Text="Usuario"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txBx_nombreUsuario" runat="server" Width="187px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" Text="Contraseña"></asp:Label>
                                </td>
                                <td id="txBx_passwordUsuario">
                                    <asp:TextBox ID="txBx_passwordUsuario" runat="server" Width="186px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:ImageButton ID="btn_identificarme" runat="server" ImageUrl="~/imagenes/btn_identificate.PNG" Width="150px" OnClick="btn_identificate" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Text="Si aun no estás registrado, ¿a qué esperas?. Haz Click en Registrarme"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style4"></td>
                                <td class="auto-style4">
                                    <asp:ImageButton ID="btn_registrarme" runat="server" ImageUrl="~/imagenes/btn_registrame.png" OnClick="btn_registarme" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/pie_registro.PNG" />
                    </td>
                </tr>
            </table>
              <asp:TextBox ID="seguimientoTextBox" runat="server" Height="200px" TextMode="MultiLine" Width="634px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
