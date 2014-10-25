<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Countries.WebClient.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server" ConnectionString="name=CountriesEntities" DefaultContainerName="CountriesEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Continents" EntityTypeFilter="Continent"></asp:EntityDataSource>        

        <h2>Continents ListBox</h2>
        <asp:ListBox ID="ListBoxContinents" runat="server" DataSourceID="EntityDataSourceContinents" DataTextField="Name" DataValueField="Id"></asp:ListBox>

        <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server" ConnectionString="name=CountriesEntities" DefaultContainerName="CountriesEntities" EnableFlattening="False" EnableInsert="True" EntitySetName="Countries" EntityTypeFilter="Country"></asp:EntityDataSource>

        <h2>Countries GridView</h2>
        <asp:GridView ID="GridViewCountries" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="EntityDataSourceCountries">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
                <asp:BoundField DataField="LanguageId" HeaderText="LanguageId" SortExpression="LanguageId" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
            </Columns>
        </asp:GridView>
        
        <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server" ConnectionString="name=CountriesEntities" DefaultContainerName="CountriesEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Towns" EntityTypeFilter="Town" Include="Country"></asp:EntityDataSource>

        <h2>Towns ListView</h2>
        <asp:ListView ID="ListViewTowns" 
            runat="server" 
            DataKeyNames="Id" 
            DataSourceID="EntityDataSourceTowns"
            ItemType="Countries.Data.Town" 
            InsertItemPosition="LastItem">   
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server"></th>
                                    <th runat="server">Name</th>
                                    <th runat="server">Population</th>
                                    <th runat="server">Country</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>   
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Item.Name %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Item.Population %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#: Item.Country.Name %>' />
                    </td>
                </tr>
            </ItemTemplate>   
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>               
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%#: Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: Bind("Population") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%#: Bind("Country.Name") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%#: BindItem.Name %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: BindItem.Population %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" placeholder="Country Id" Text='<%#: BindItem.CountryId %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.Name") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

    </form>
</body>
</html>
