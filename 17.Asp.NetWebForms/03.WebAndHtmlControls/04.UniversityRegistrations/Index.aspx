<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_04.UniversityRegistrations.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student registration</title>
    <style>
        section {
            border: 1px solid black;
            width: 800px;
            margin-bottom: 20px;
        }

        .control-group {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <section>
            <h3>Register student: </h3>
            <div class="control-group">
                <asp:Label ID="LabelFirstName" runat="server" Text="First Name: "></asp:Label>
                <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            </div>

            <div class="control-group">
                <asp:Label ID="LabelLastName" runat="server" Text="Last Name: "></asp:Label>
                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            </div>

            <div class="control-group">
                <asp:Label ID="LabelFacultyNumber" runat="server" Text="Faculty number: "></asp:Label>
                <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
            </div>

            <asp:Label ID="LabelUniversity" runat="server" Text="University: "></asp:Label>
            <asp:DropDownList ID="DropDownListUniversity" runat="server"></asp:DropDownList>

            <asp:Label ID="LabelSpecialty" runat="server" Text="Specialty: "></asp:Label>
            <asp:DropDownList ID="DropDownListSpecialty" runat="server"></asp:DropDownList>

            <asp:Label ID="LabelCourses" runat="server" Text="Courses: "></asp:Label>
            <asp:ListBox ID="ListBoxCourses" SelectionMode="Multiple" runat="server"></asp:ListBox>
            <br />

            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        </section>

        <section>
            <asp:Panel ID="PanelFeedback" runat="server"></asp:Panel>
        </section>
    </form>
</body>
</html>
