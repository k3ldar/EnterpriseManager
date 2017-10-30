<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Admin.FAQ.Index" %>
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
                    <li><a href="/Staff/Admin/FAQ/Index.aspx">FAQ</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Products</h1>
				
				<p>Please select an FAQ to edit, or click "New" to create a new product.</p>
				                
				<div class="form">
                    <p id="pFAQItems" runat="server"></p>
                    <p>
                        <asp:Button ID="btnNew" runat="server" Text="New" onclick="btnNew_Click"  />
                    </p>
                </div>
                <p style="position: static;"><br /></p>

                <div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination()%>
					</ul>
				</div><!-- end of .pagination -->
							
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
