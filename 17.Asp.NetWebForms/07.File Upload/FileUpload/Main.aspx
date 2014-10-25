<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="FileUpload.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Please use the script file in the root folder to create the database schema. Modify the connection string according your setup. Then use the provided zip archive  to test.</h2>
        <asp:FileUpload ID="FileUploadZip" runat="server" />
        <asp:Button ID="ButtonUpload" OnClick="Upload" runat="server" Text="Upload" />
        <asp:Label ID="LabelFeedback" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
