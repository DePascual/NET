<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Agapea.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
            width: 337px;
        }

        .auto-style2 {
            height: 26px;
            width: 337px;
        }

        .auto-style3 {
            width: 243px;
        }

        .auto-style4 {
            height: 26px;
            width: 243px;
        }

        .auto-style5 {
            height: 25px;
            width: 243px;
        }

        .auto-style6 {
            width: 337px;
        }

        .auto-style7 {
            width: 337px;
            height: 27px;
        }

        .auto-style8 {
            width: 243px;
            height: 27px;
        }

        .auto-style9 {
            width: 337px;
            height: 31px;
        }

        .auto-style10 {
            height: 31px;
            width: 243px;
        }

        .auto-style11 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/encabezado_registro.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" border="0" width="40%" cellspacing="5px">
                        <tr>
                            <td colspan="2">

                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Text="Regístrate con..." Font-Size="Large"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">

                                <asp:ImageButton ID="btn_regFacebook" runat="server" ImageUrl="~/imagenes/btn_facebook_registro.PNG" />

                            </td>
                            <td class="auto-style3">

                                <asp:ImageButton ID="btn_regGoogle" runat="server" ImageUrl="~/imagenes/btn_google_registro.PNG" />

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Text="o bien  crea un usuario de Agapea"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Text="Regístrate con Agapea" Font-Size="Large"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">

                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" Text="Usuario" Font-Size="Medium"></asp:Label>

                            </td>
                            <td class="auto-style3">

                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" Text="Correo electrónico" Font-Size="Medium"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">

                                <asp:RequiredFieldValidator ID="RequireLogin" runat="server" ControlToValidate="txBx_nomUsuario" CssClass="auto-style1" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>

                                <asp:TextBox ID="txBx_loginUsuario" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Small" Font-Strikeout="False" ForeColor="#999999" Width="323px"></asp:TextBox>

                            </td>
                            <td class="auto-style4">

                                <asp:RequiredFieldValidator ID="RequiredMail" runat="server" ControlToValidate="txBx_emailUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionVMail" runat="server" ControlToValidate="txBx_emailUsuario" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>

                                <asp:TextBox ID="txBx_emailUsuario" runat="server" BorderStyle="Solid" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Width="318px"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">

                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" Text="Escribe cual será tu contraseña" Font-Size="Medium"></asp:Label>

                            </td>
                            <td class="auto-style3">

                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" Text="Repite la contraseña" Font-Size="Medium"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">

                                <asp:RequiredFieldValidator ID="requiredPassword" runat="server" ControlToValidate="txBx_passUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="ComparePasswords" runat="server" ControlToCompare="txBx_confPassUsuario" ControlToValidate="txBx_passUsuario" ErrorMessage="CompareValidator" Font-Names="Arial" Font-Size="Small" ForeColor="Red" Type="Double" >Deben coincidir las contraseñas</asp:CompareValidator>

                                <asp:TextBox ID="txBx_passUsuario" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Small" Font-Strikeout="False" ForeColor="#999999" Width="323px" TextMode="Password">Escribe aquí tu contraseña</asp:TextBox>
                                <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Text="Introduce al menos 8 caracteres"></asp:Label>

                            </td>
                            <td class="auto-style5" valign="top">

                                <asp:RequiredFieldValidator ID="RequiredConfPassword" runat="server" ControlToValidate="txBx_confPassUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>

                                <asp:TextBox ID="txBx_confPassUsuario" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Small" Font-Strikeout="False" ForeColor="#999999" Width="323px" TextMode="Password">Escribe otra vez la contraseña</asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">

                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" Text="Datos personales" Font-Size="Large"></asp:Label>

                            </td>
                            <td class="auto-style8">

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">

                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Arial" Text="Mi nombre es" Font-Size="Medium"></asp:Label>

                            </td>
                            <td class="auto-style3">

                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Arial" Text="Mis apellidos" Font-Size="Medium"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">

                                <asp:RequiredFieldValidator ID="RequiredNombre" runat="server" ControlToValidate="txBx_nomUsuario" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>

                                <asp:TextBox ID="txBx_nomUsuario" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Small" Font-Strikeout="False" ForeColor="#999999" Width="323px"></asp:TextBox>

                            </td>
                            <td class="auto-style3">

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txBx_apeUsuario" ErrorMessage="RequiredApellidos" ForeColor="Red">*</asp:RequiredFieldValidator>

                                <asp:TextBox ID="txBx_apeUsuario" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="Small" Font-Strikeout="False" ForeColor="#999999" Width="323px"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Text="Agapea S.A. se compromete a grantizar la seguridad de tus datos y a guardarlos en la más estricta confidencialidad"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" colspan="2">

                                <asp:CustomValidator ID="CustomCheck" runat="server" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>

                                <asp:CheckBox ID="check_Acepto" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#999999" Text="Acepto las " />
                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Underline="True" ForeColor="#0066CC">Condiciones de uso, y  nuestras Condicones de Cookies</asp:HyperLink>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">

                                <asp:ImageButton ID="btn_registrarme" runat="server" ImageUrl="~/imagenes/btn_registrame.png" OnClick="btn_registrarme_Click" />

                            </td>
                            <td class="auto-style10">

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" Text="De acuerdo con las disposiciones de la Ley Orgánica de Protección de Datos de Carácter Personal nº 15/1999, de 13 de diciembre de 1999, puedes ejercer los derechos de acceso, rectificación, cancelación y oposición sobre tus datos personales"></asp:Label>

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
    </div>
    </form>
</body>
</html>
