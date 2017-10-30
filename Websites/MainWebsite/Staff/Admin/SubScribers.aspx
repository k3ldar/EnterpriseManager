<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="SubScribers.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Admin.SubScribers" %>

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
					<li>Admin</li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Admin/SubScribers.aspx">Subscribers</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc1:LeftContainerControl ID="LeftContainerControl2" runat="server" SubOptionsShow="true" />

            <div class="mainContent">
			
				<h1>Mail List Subscribers</h1>
				
                <p>The following is a list of mail list subscribers, only showing those that have subscribed to the mail list.  Appears in date descending order.</p>
                
                <div id="divOptions" runat="server"></div>
     
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
