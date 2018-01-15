<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Download.Index" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ register src="~/Controls/WebPageTags.ascx" tagprefix="uc1" tagname="WebPageTags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Downloads %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Download/Index.aspx"><%=Languages.LanguageStrings.Downloads %></a></li>				
                </ul>
				
			</div><!-- end of #breadcrumb -->
			
			<div class="mainContent">
			    <h1><%=Languages.LanguageStrings.Downloads %></h1>
				
                <p><%=Languages.LanguageStrings.DownloadsDescription %></p>
				
                <p id="pPlaceHolder" runat="server"></p>

				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination()%>
					</ul>
				</div><!-- end of .pagination -->

			    <uc2:MediaLinks ID="MediaLinks1" runat="server" />
                
                <%--<uc1:WebPageTags runat="server" id="WebPageTags" />--%>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
