<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.PageCelebrities.Index" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.CelebritiesLoveHeaven %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Celebrities/Index.aspx"><%=Languages.LanguageStrings.Celebrities %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.CelebritiesLoveHeaven %></h1>
				
				<ul class="productList fixed">
                  <%=GetCelebrities()%>
				</ul>
				
				<div class="pagination">
					<ul class="fixed">
                        <%=BuildPagination(5, 6, GetFormValue("Page", 1), "/Celebrities/Index.aspx")%>
					</ul>
				</div><!-- end of .pagination -->

                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			<div class="clear"><!-- clear --></div>
		</div><!-- end of #content -->
</asp:Content>
