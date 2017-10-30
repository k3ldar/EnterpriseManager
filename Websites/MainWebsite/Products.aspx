<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.PageProducts" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Products.aspx"><%=Languages.LanguageStrings.Products %></a></li>
                    <%=GetProductGroupProfessional() %>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			

			<div class="mainContent">
			
				<h1 id="headerH1" runat="server"><%=GetProductGroupTitle(GetFormValue("GroupID", -1))%></h1>
                <div id="headerH2" class="headerH2" runat="server">
                    <span class="headerSubContent"><%=GetProductGroupSubHeader(GetFormValue("GroupID", -1))%></span><br />
                    <span class="headerContent"><%=GetProductGroupHeader(GetFormValue("GroupID", -1))%></span>                    
                </div>
				
				<%=GetProductGroupTagLine() %>
				
				<ul class="productList fixed">
                    <%=GetProductsStratosphere(GetFormValue("GroupID", -1), 178) %>
				</ul>
				
				
				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination()%>
					</ul>
				</div><!-- end of .pagination -->

				<uc2:MediaLinks ID="MediaLinks1" runat="server" />
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />

			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
