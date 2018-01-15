<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="UploadWizard.aspx.cs" Inherits="SieraDelta.Website.Staff.Downloads.Downloads" %>
<%@ Register src="../Controls/FileUpload.ascx" tagname="FileUpload" tagprefix="uc1" %>
<%@ Register src="../Controls/FileUpload1.ascx" tagname="FileUpload1" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/">Home</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Index.aspx">Staff</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Downloads/Index.aspx">Downloads</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Downloads/UploadWizard.aspx">Upload Wizard</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>File Upload Wizard</h1>
				
				<uc1:FileUpload ID="FileUpload1" runat="server" />

			    <uc2:FileUpload1 ID="FileUpload11" runat="server" />
				
												
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content --></asp:Content>
