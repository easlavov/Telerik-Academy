<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="_02.AppendTextThroughSession.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task 02</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        <br />
        <asp:Label ID="LabelFeedback" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
