<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_03.HtmlEscaping.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span>Enter your text here: </span>
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonDisplay" runat="server" Text="Display" OnClick="ButtonDisplay_Click" />
        <br />
        <span>Result: </span>
        <asp:TextBox ID="TextBoxResult" runat="server"></asp:TextBox>
        <asp:Label ID="LabelResult" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
