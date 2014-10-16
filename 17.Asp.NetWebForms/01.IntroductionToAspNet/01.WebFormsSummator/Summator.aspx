<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="Summator.aspx.cs"
    Inherits="_01.WebFormsSummator.Summator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Summator</title>
</head>
<body>
    <form id="summatorForm" runat="server">
        <div>
            <h4>Sum two numbers</h4>
            <asp:TextBox ID="TextBoxAugend" runat="server"></asp:TextBox>
            <span>+</span>
            <asp:TextBox ID="TextBoxAddend" runat="server"></asp:TextBox>
            <span>=</span>
            <asp:TextBox ID="TextBoxSum" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSum" runat="server" Text="Sum" onclick="ButtonSum_Click"/>
        </div>
        <br />
        <span>Feedback: </span>
        <asp:TextBox ID="TextBoxFeedback" runat="server" ReadOnly="True" Width="500px"></asp:TextBox>
    </form>
</body>
</html>
