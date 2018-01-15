<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SieraDelta.Website.PageAbout" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.AboutUs %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Company/About/"><%=Languages.LanguageStrings.AboutUs %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <%--<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />--%>
			
			<div class="mainContent" style="float:left;">
			
				<h1><%=Languages.LanguageStrings.AboutUs %></h1>
								
                <div id="divTranslated" runat="server">				
				</div>

                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
