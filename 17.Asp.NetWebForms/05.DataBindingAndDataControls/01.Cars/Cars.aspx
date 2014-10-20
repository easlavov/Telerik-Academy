<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="_01.Cars.Cars" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelProducer" runat="server" Text="Producer: "></asp:Label>
            <asp:DropDownList ID="DropDownListProducer" AutoPostBack="true"  OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged" DataTextField="Name" runat="server">

            </asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="LabelModel" runat="server" Text="Model: "></asp:Label>
            <asp:DropDownList ID="DropDownListModel" runat="server"></asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="LabelExtras" runat="server" Text="Extras: "></asp:Label>
            <asp:CheckBoxList ID="CheckBoxListExtras" DataTextField="Value" runat="server"></asp:CheckBoxList>
        </div>

        <div>
            <asp:Label ID="LabelEngine" runat="server" Text="Engine"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListEngine" DataTextField="Value" runat="server"></asp:RadioButtonList>
        </div>

        <asp:Button ID="ButtonSubmit" OnClick="ButtonSubmit_Click" runat="server" Text="Button" />
        <br />

        <asp:Literal ID="LiteralFeedback" runat="server"></asp:Literal>
    </form>
</body>
</html>
