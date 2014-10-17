<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03.CustomHandler._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h4>Enter some text. Only letters are allowed!!!:</h4>        
        <asp:TextBox ID="TextBoxMessage" runat="server" value="SampleText"></asp:TextBox>
        <asp:Button ID="ButtonSum" runat="server" Text="Convert" OnClick="ButtonImgRequest_Click" />
    </div>
</asp:Content>
