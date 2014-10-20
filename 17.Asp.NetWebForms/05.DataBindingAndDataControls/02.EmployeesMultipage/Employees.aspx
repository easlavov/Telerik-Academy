<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.EmployeesMultipage.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewEmployees" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:HyperLinkField DataNavigateUrlFields="EmployeeID"
                         DataNavigateUrlFormatString="Details.aspx?id={0}" 
                         Text="Details" HeaderText="ID" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
