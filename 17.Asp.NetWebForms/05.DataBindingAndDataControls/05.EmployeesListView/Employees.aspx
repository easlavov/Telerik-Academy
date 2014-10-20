<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_04.EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table {
            border: 1px solid black;
            border-collapse: collapse;
        }

        td {
            border: 1px solid black;
            max-width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListViewEmployees" runat="server">
                <ItemTemplate>
                    <h3>
                        <%#: DataBinder.Eval(Container.DataItem, "FirstName") %>
                        <%#: DataBinder.Eval(Container.DataItem, "LastName") %>
                    </h3>

                    <table>
                        <tr>
                            <td>Title</td>
                            <td><%#: DataBinder.Eval(Container.DataItem, "Title") %></td>
                        </tr>
                        <tr>
                            <td>City</td>
                            <td><%#: DataBinder.Eval(Container.DataItem, "City") %></td>
                        </tr>
                        <tr>
                            <td>Postal code</td>
                            <td><%#: DataBinder.Eval(Container.DataItem, "PostalCode") %></td>
                        </tr>
                        <tr>
                            <td>Country</td>
                            <td><%#: DataBinder.Eval(Container.DataItem, "Country") %></td>
                        </tr>
                        <tr>
                            <td>Extension</td>
                            <td><%#: DataBinder.Eval(Container.DataItem, "Extension") %></td>
                        </tr>
                        <tr>
                            <td>Notes</td>
                            <td><%#: DataBinder.Eval(Container.DataItem, "Notes") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>            
        </div>
    </form>
</body>
</html>
