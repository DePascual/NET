<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/master_VistaCompras.Master" AutoEventWireup="true" CodeBehind="Registro_conMaestra.aspx.cs" Inherits="Agapea2.Registro_conMaestra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="texto">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/registro.PNG" />
    </div>
    <div id="registro" style="position: relative; margin:auto; height:50%; width:50%">
        <table style="text-align:center;  border:0; width:40%;  border-spacing:5px ">
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
                    <asp:CompareValidator ID="ComparePasswords" runat="server" ControlToCompare="txBx_confPassUsuario" ControlToValidate="txBx_passUsuario" ErrorMessage="Deben coincidir las contraseñas" Font-Names="Arial" Font-Size="Small" ForeColor="Red">Deben coincidir las contraseñas</asp:CompareValidator>

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
                <td class="auto-style8"></td>
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
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" Text="De acuerdo con las disposiciones de la Ley Orgánica de Protección de Datos de Carácter Personal nº 15/1999, de 13 de diciembre de 1999, puedes ejercer los derechos de acceso, rectificación, cancelación y oposición sobre tus datos personales"></asp:Label>

                </td>
            </tr>
        </table>
    </div>

</asp:Content>
