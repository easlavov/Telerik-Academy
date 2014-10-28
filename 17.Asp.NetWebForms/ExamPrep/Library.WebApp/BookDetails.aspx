<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BookDetails.aspx.cs" Inherits="Library.WebApp.BookDetails" %>

<asp:Content ID="ContentBook" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewBook" runat="server" SelectMethod="FormViewBook_GetItem"
        ItemType="Library.WebApp.Book">
        <ItemTemplate>
            <h1><%#: Item.Title %></h1>
            <ul class="list-group">
                <li class="list-group-item"><%#: Item.Author %></li>
                <li class="list-group-item"><%#: Item.Isbn %></li>
                <li class="list-group-item">Web site: <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a></li>
                <li class="list-group-item"><%#: Item.Description %></li>
            </ul>
        </ItemTemplate>
    </asp:ListView>

    <a href="Default.aspx">Back to books</a>
</asp:Content>
