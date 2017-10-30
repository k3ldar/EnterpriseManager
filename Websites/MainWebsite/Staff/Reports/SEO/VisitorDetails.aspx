<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="VisitorDetails.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.VisitorDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .scrollFix { line-height: 1.35; white-space: nowrap; }
        .auto-style1 {
            width: 180px;
            float: left;
            font-family: "nimbus-sans", Helvetica, Arial, "Lucida Grande", sans-serif;
            font-size: 1.4em;
            line-height: 1.5em;
        }
            .auto-style1 td
            {
                text-align: left;
                vertical-align: top;
            }
            .auto-style1 th strong
            {
                font-weight: 200;
                vertical-align: top;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Reports/SEO/VisitorDetails.aspx">Visitor Details</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<div class="mainContent">
			
				<h1>Active Visitor Details</h1>

                <div>
                    <%=GetSessionData() %>
                </div>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
