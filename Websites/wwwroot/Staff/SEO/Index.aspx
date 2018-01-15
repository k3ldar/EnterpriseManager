<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Staff.Reports.SEO.Index" %>
<%@ Register src="~/Controls/SeoCharts.ascx" tagname="SeoCharts" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Seo Reports</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Home/">Home</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Index.aspx">Staff</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/SEO/Index.aspx">SEO Data</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <div>
            <h1>SEO Reports</h1>
            <uc1:SeoCharts ID="SeoCharts1" runat="server" />
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
    <!-- end of #content -->
</asp:Content>
