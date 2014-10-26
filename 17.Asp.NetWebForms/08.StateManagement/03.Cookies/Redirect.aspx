<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Redirect.aspx.cs" Inherits="_03.Cookies.Redirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>This page will redirect you to the login page if the expected cookie is missing or expired.</h2>

        <asp:Label ID="LabelStatus" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
