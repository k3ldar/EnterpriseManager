<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="EditTagLine.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Admin.TagLines.EditTagLine" %>
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
                    <li>&rsaquo;</li>
                    <li>Edit Tag Line</li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Edit Tag Line</h1>
						
                <div class="form">
                    <b>TagLine</b><br />
                    <asp:TextBox ID="txtTagLine" runat="server" MaxLength="250" TextMode="MultiLine" Rows="3" Width="70%"></asp:TextBox><br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                </div>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
