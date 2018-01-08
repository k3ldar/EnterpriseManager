<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Staff.Admin.Products.Index" %>
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
                    <li><a href="/Staff/Admin/Products/Index.aspx">Products</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Products</h1>
				
				<p>Please select a product below or click "New" to create a new product.</p>
				
                <table id="tblProducts" runat="server" class="tblProduct">
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th>SKU</th>
                            <th>Show On Website</th>
                            <th>Regal</th>
                        </tr>
                    </thead>
                </table>
				
                
                <div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination()%>
					</ul>
				</div><!-- end of .pagination -->
							
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
