<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_02.Codebehind.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelAspx" runat="server" Text="This text is printed from the aspx code!"></asp:Label>
        <br />
        <asp:Label ID="LabelCodebehind" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LabelLocation" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
