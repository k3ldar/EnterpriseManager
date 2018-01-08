<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Staff.Admin.Index" %>
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
                    <li><a href="/Staff/Admin/Index.aspx">Administration</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Administration</h1>

                <h3>Product Management</h3>
                <p>Please select from the following options.</p>
                <ul>
                    <li><a href="/Staff/Admin/Products/Index.aspx">Products</a></li>
                    <li>Product Groups</li>
                </ul>


                <h3>FAQ</h3>
				
				<ul>
                    <li><a href="/Staff/Admin/FAQ/Index.aspx">Frequently Asked Questions</a></li>
                </ul>
												
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->

</asp:Content>
