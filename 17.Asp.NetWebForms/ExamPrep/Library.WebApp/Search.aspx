<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="Library.WebApp.Search" %>

<asp:Content ID="ContentSearch" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <ul>
            <asp:Repeater ID="RepeaterBooks" ItemType="Library.WebApp.Book" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink NavigateUrl='<%#: string.Format(@"~/BookDetails.aspx?id={0}", Item.Id) %>'
                            Text='<%#: string.Format(@"""{0}"" by {1}", Item.Title, Item.Author) %>' runat="server" />
                        (Category) <span><%#: Item.Category.Name %></span>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
