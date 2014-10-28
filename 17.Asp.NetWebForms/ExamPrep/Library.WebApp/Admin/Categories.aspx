<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Categories.aspx.cs" Inherits="Library.WebApp.Admin.Categories" %>

<asp:Content ID="ContentCategories" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="container">
            <asp:ListView ID="ListViewCategoriesTest" runat="server"
                ItemType="Library.WebApp.Category"
                DataKeyNames="Id" 
                SelectMethod="ListViewCategories_GetData"
                DeleteMethod="ListViewCategoriesTest_DeleteItem"
                UpdateMethod="ListViewCategoriesTest_UpdateItem"
                InsertMethod="ListViewCategoriesTest_InsertItem"
                InsertItemPosition="LastItem">
                <LayoutTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>
                                    <asp:LinkButton Text="Category" runat="server"
                                        CommandName="Sort" CommandArgument="Category" />
                                </th>
                                <th>Action</th>
                            </tr>                            
                        </thead>

                        <tfoot>
                            <tr>
                                <td colspan="2">
                                    <asp:DataPager ID="DataPagerCategories" runat="server" 
                                        PagedControlID="ListViewCategoriesTest" PageSize="5">
                                        <Fields>
                                            <asp:NumericPagerField />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </tfoot>

                        <tbody>
                            <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td>
                            <asp:Button Text="Edit" CommandName="Edit" runat="server" />
                            <asp:Button Text="Delete" CommandName="Delete" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>

                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                        </td>
                        <td>
                            <asp:Button Text="Save" CommandName="Update" runat="server" />
                            <asp:Button Text="Cancel" CommandName="Cancel" runat="server" />
                        </td>
                    </tr>
                </EditItemTemplate>

                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonInsert" Text="Save" CommandName="Insert" runat="server" />
                            <asp:Button ID="ButtonCancel" Text="Cancel" CommandName="Cancel" runat="server" />
                        </td>
                    </tr>
                </InsertItemTemplate>

            </asp:ListView>

            <%--<asp:ListView ID="ListViewCategories" runat="server"
                SelectMethod="ListViewCategories_GetData"
                ItemType="Library.WebApp.Category"
                DataKeyNames="Id">
                <LayoutTemplate>
                    <table class="table">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        <thead>
                            <th>Name</th>
                            <th>Edit</th>
                            <th>Delete</th>
                        </thead>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td>
                            <asp:LinkButton CssClass="btn btn-default" Text="Edit" runat="server"
                                Command="Edit" />
                        </td>
                        <td>
                            <asp:LinkButton CssClass="btn btn-default" Text="Delete" runat="server"
                                Command="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td> <asp:TextBox runat="server" Text="<%#: BindItem.Name %>" /> </td>
                        <td>
                            <asp:LinkButton CssClass="btn btn-default" Text="Save" runat="server"
                                 CommandName="Save" />
                        </td>
                        <td>
                            <asp:LinkButton CssClass="btn btn-default" Text="Cancel" runat="server"
                                 CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>--%>
        </div>

        <div class="container">
            <h2>Insert category</h2>
            <asp:TextBox ID="TextBoxCategoryName" placeholder="Category name" runat="server" />
            <asp:LinkButton CssClass="btn btn-default btn-lg" Text="Add new category" runat="server"
                OnCommand="Insert_Command" />
        </div>
    </div>
</asp:Content>
