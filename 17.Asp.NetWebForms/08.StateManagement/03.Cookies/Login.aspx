<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_03.Cookies.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task 03: Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>This is the login page. Press the buttonb to login.</h1>
        <asp:TextBox ID="TextBoxUsername" runat="server" placeholder="Username"></asp:TextBox>
        <asp:Button ID="ButtonLogin" runat="server" Text="Button" OnClick="ButtonLogin_Click" />
    </form>
</body>
</html>
