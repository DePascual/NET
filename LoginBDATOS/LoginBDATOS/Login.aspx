<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginBDATOS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="nombre"></asp:Label>
    
        <asp:TextBox ID="txtBoxNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
    
        <asp:TextBox ID="txtBoxPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="buttonEntrar" runat="server" Text="Entrar" OnClick="buttonEntrar_Click" />
    
    </div>
    </form>
</body>
</html>
