<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Staff.Statistics.Index" %>
<%@ Register src="../../Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx">Home</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Index.aspx">Staff</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Statistics/Index.aspx">Statistics</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />

            <div class="mainContent">
			
				<h1>Website Statistics</h1>
				
				<h3>Statistics</h3>
				
			    <p><%=GetWebStats()%></p>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
