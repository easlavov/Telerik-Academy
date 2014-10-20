<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.EmployeesMultipage.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
    <style>
        table table {
            border: 1px solid black;
            border-collapse: collapse;
        }

        table table td {
            border: 1px solid black;
            max-width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">        
        <div>
            <asp:FormView ID="FormViewEmployees" AllowPaging="true"
                OnPageIndexChanging="FormViewEmployees_PageIndexChanging" runat="server">
                <ItemTemplate>
                    <h3>
                        <%#: Eval("FirstName") %>
                        <%#: Eval("LastName") %>
                    </h3>
                    
                    <table>
                        <tr>
                            <td>Title</td>
                            <td><%#: Eval("Title") %></td>
                        </tr>
                        <tr>
                            <td>City</td>
                            <td><%#: Eval("City") %></td>
                        </tr>
                        <tr>
                            <td>Postal code</td>
                            <td><%#: Eval("PostalCode") %></td>
                        </tr>
                        <tr>
                            <td>Country</td>
                            <td><%#: Eval("Country") %></td>
                        </tr>
                        <tr>
                            <td>Extension</td>
                            <td><%#: Eval("Extension") %></td>
                        </tr>
                        <tr>
                            <td>Notes</td>
                            <td><%#: Eval("Notes") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
