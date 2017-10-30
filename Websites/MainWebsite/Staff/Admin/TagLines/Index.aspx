<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Admin.TagLines.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="http://www.heavenskincare.com/Index.aspx">Home</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Index.aspx">Staff</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Admin/Index.aspx">Administration</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Admin/TagLines/Index.aspx">Tag Lines</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Tag Lines</h1>

                <h3>Tag Lines</h3>
                <p>From here you can edit the tag lines that appear in the header of each page within the main website, they will be randomly selected to appear.</p>

				<div id="divControls" runat="server">  
                    <hr />
				</div>
						
                <div class="form">
                    <asp:Button ID="btnNew" runat="server" Text="New Tag Line" OnClick="btnNew_Click" />
                    <asp:Button ID="btnUpdateMainSite" runat="server" Text="Refresh Main Web Site" OnClick="btnUpdateMainSite_Click" />
                </div>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
