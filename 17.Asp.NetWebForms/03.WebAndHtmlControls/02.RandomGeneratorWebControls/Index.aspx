<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_01.RandomGenerator.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>From: </label>
            <asp:TextBox ID="TextBoxFrom" runat="server"></asp:TextBox>
            <br />
            <label>To: </label>
            <asp:TextBox ID="TextBoxTo" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonGenerate" runat="server" Text="Get random number" OnClick="ButtonGenerate_Click" />
            <asp:Label ID="LabelNumber" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
