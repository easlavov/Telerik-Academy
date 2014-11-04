<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewSoccer" AutoGenerateColumns="true" runat="server"></asp:GridView>
        <asp:DetailsView ID="DetailsView1Barry" runat="server" Height="50px" Width="125px"></asp:DetailsView>
    </form>
</body>
</html>
