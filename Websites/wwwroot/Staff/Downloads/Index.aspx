<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Staff.Downloads.Index" %>
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
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="leftColumn">
			
				<h5>options</h5>
				
				<ul>
                  <li><a href="/Staff/Downloads/UploadWizard.aspx">Upload Files</a></li>
				</ul>			
			</div><!-- end of #leftColumn -->
			
			
			<div class="mainContent" style="width:740px">
			    <h1>Salon/Distributor Downloads</h1>
				
                <p>The following files are available to download.</p>
				
                <p id="pPlaceHolder" runat="server"></p>

				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination()%>
					</ul>
				</div><!-- end of .pagination -->
				
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
