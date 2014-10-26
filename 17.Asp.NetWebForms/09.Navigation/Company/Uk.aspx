<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Uk.aspx.cs" Inherits="Company.Uk" %>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>