<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="MetaStatistics.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.MetaStatistics" %>
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
					<li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Reports/MetaStatistics.aspx">META Statistics</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContent">
			
				<h1>Website Meta Data Statistics</h1>
                <h3>References</h3>
                <p>
                    The following links can be used as a reference for SEO
                </p>
                <p>
                    <a href="https://searchenginewatch.com/2016/05/16/how-to-write-meta-title-tags-for-seo-with-good-and-bad-examples/" target="_blank">Meta Titles</a><br />
                    <a href="https://searchenginewatch.com/sew/how-to/2067564/how-to-use-html-meta-tags" target="_blank">Meta Tags</a><br />

                </p>
                <h3>Example</h3>
                <p>
                    Skinwipes Tags: Skin Wipe Mascara Pectin Exfoliate
                </p>
                <p>
                    Skinwipes Meta Description: These large organic cloth cotton wipes contain apple pectin and are textured to exfoliate deep clean and even remove mascara.
                </p>
                <p>
                    Title:  EllaJane Celebrity Organic Face Wipes
                </p>
				<h3>Product Information</h3>
                <p>The following products have either no hash tags, no title or no description.  For maximum SEO potential please follow the links for each product and change what is missing.</p>
				<%=GetProductInformation() %>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
