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
            <input type="text" id="TextBoxFrom" runat="server" />
            <br />
            <label>To: </label>
            <input type="text" id="TextBoxTo" runat="server" />
            <br />
            <input type="button" id="ButtonGenerate" value="Generate random number" runat="server" onserverclick="ButtonGenerate_Click" />
            <label id="LabelNumber" runat="server"></label>
        </div>
    </form>
</body>
</html>
