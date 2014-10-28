<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Library.WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <header class="container">
        <h1 class="pull-left">Books</h1>
        <div class="pull-right">
            <asp:TextBox ID="TextBoxSearch" runat="server" />
            <asp:Button CssClass="btn" ID="ButtonSearch" Text="Search" runat="server"
                 OnClick="ButtonSearch_Click" />
        </div>
    </header>

    <div class="jumbotron">
        <asp:ListView ID="ListViewBooks" class="jumbotron" runat="server"
            ItemType="Library.WebApp.Category">
            <ItemTemplate>
                <div class="">
                    <h2><%#: Item.Name %></h2>
                    <ul>
                        <asp:Repeater ID="RepeaterBooks" runat="server"
                             DataSource="<%# Item.Books %>"
                             ItemType="Library.WebApp.Book">
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink NavigateUrl='<%#: string.Format(@"~/BookDetails.aspx?id={0}", Item.Id) %>' 
                                        Text='<%#: string.Format(@"""{0}"" by {1}", Item.Title, Item.Author) %>' runat="server" />
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
