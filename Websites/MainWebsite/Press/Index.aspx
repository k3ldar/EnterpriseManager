<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Press.Index" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.NewsAndPress %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Press/Index.aspx"><%=Languages.LanguageStrings.NewsAndPress %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
		
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.NewsAndPress %></h1>
				
				<ul class="productList fixed">
                    <%=GetPressItems() %>
				</ul>
				
				
				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(Library.BOL.News.NewsItems.GetCount(), 12, GetFormValue("Page", 1), "/Press/Index.aspx")%>
					</ul>
				</div><!-- end of .pagination -->
				
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
