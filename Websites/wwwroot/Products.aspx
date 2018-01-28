<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SieraDelta.Website.PageProducts" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetProductGroupName() %> - <%=Languages.LanguageStrings.Products %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/All-Products/"><%=Languages.LanguageStrings.Products %></a></li>
                    <%=GetProductGroup() %>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			

			<div class="mainContent">
			
				<h1 id="divTitle" runat="server">
                    <span id="spanSubHeader" runat="server" class="headerSubContent"><%=GetSubHeader() %> <br /></span>
                    <div><%=GetProductTitle()%></div>
				</h1>

				<%=GetProductGroupTagLine() %>
				
				<ul class="productList fixed">
                    <%=GetProducts(178) %>
				</ul>
				
				
				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination()%>
					</ul>
				</div><!-- end of .pagination -->
				
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />

			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->

    <script type="text/javascript">
        jQuery(document).on('load', function () {
            jQuery('.mycarousel').jcarousel({
                scroll: 3,
                wrap: "circular"
            });
        });
    </script>
</asp:Content>
