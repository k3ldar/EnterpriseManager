<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Options.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Admin.Options" %>

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
					<li><a href="/Staff/Admin/Options.aspx">Options</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc1:LeftContainerControl ID="LeftContainerControl2" runat="server" SubOptionsShow="true" />

            <div class="mainContent">
			
				<h1>Website Options</h1>
				
                <h3>IMPORTANT</h3>
                <p>Please note there is no "return to default option", changes made here will affect this website as soon as the "Update All" button is clicked.  If the "Update All" button is not clicked then changes won't be made until the website is recycled.</p>
                <p><asp:Button ID="btnUpdateAll" runat="server" Text="Update All" OnClick="btnUpdateAll_Click" /></p>
                
                <div id="divOptions" runat="server"></div>
     
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>

