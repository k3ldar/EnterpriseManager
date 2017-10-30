<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Video.Index" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.VideoLibrary %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Video/Index.aspx"><%=Languages.LanguageStrings.Videos %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.VideoLibrary %></h1>
				
                <p><%=GetVideoReference()%></p>

				<ul class="productList fixed">
                  <%=GetVideoList() %>
                  
				</ul>
				
                <uc2:MediaLinks ID="MediaLinks1" runat="server" />

				<div class="pagination">
					<ul class="fixed">
                        <%=BuildPagination(Library.BOL.Video.Videos.GetCount(), 12, GetFormValue("Page", 1), "/Video/Index.aspx")%>
					</ul>
				</div><!-- end of .pagination -->
                			    <uc2:WebPageTags ID="WebPageTags1" runat="server" />

			</div><!-- end of #mainContent -->
			<div class="clear"><!-- clear --></div>
		</div><!-- end of #content -->
</asp:Content>
