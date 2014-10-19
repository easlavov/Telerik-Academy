<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01.PrintHello.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxName" runat="server" Height="20px" Width="320px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Height="30px" style="margin-left: 29px" Text="Greet" Width="135px" OnClick="ButtonGreet_Click" />
    
    </div>
        <p>
            <asp:Label ID="LabelGreeting" runat="server" Text="Enter your name above and press the button"></asp:Label>
        </p>
    </form>
</body>
</html>
