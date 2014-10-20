<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="_02.EmployeesMultipage.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ButtonBack" PostBackUrl="~/Employees.aspx" runat="server" Text="Back" />

        <div>
            <asp:DetailsView ID="DetailsViewEmployee" runat="server" Height="50px" Width="125px"></asp:DetailsView>
        </div>
    </form>
</body>
</html>
