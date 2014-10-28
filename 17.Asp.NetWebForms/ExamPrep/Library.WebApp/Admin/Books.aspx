<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="Books.aspx.cs" Inherits="Library.WebApp.Admin.Books" %>
<asp:Content ID="ContentBooks" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server">
        <ItemTemplate></ItemTemplate>
    </asp:ListView>
</asp:Content>
