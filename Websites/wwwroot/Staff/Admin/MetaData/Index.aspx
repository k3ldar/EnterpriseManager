<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Staff.Admin.MetaData.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="http://www.SieraDelta.com/Index.aspx">Home</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Index.aspx">Staff</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Admin/Index.aspx">Administration</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/MetaData/Index.aspx">Meta Data</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Meta Data</h1>
                <p>From here you can edit the Meta Data which appears on the web pages when custom meta data is not set.</p>
                
                <h3>Default Description</h3>
				<p>The default description is used for all pages that do not have a custom description</p>
				<div class="form">
                    <asp:TextBox ID="txtDefaultDescription" runat="server" TextMode="MultiLine" MaxLength="250" Rows="7" Width="600px"></asp:TextBox>
				</div>
			    <div class="clear"><!-- clear --></div>
                <h3>Default Keywords</h3>
				<p>The default keywords are used for all pages that do not have a custom keywords</p>
				<div class="form">
                    <asp:TextBox ID="txtDefaultKeywords" runat="server" TextMode="MultiLine" MaxLength="250" Rows="7" Width="600px"></asp:TextBox>
                    <asp:Button ID="btnUpdateDefaultKeywords" runat="server" Text="Update" OnClick="btnUpdateDefaultKeywords_Click" />
				</div>
						
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
