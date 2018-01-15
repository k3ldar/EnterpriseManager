<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Trade.aspx.cs" Inherits="SieraDelta.Website.PageTrade" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Trade %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Trade.aspx"><%=Languages.LanguageStrings.Trade %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <%--<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />	--%>		
			
			<div class="mainContent" style="float:left;">
			    <div id="divTranslated" runat="server">
								
                </div>				
                <p id="pTradeSignup" runat="server"><a href="/Trade-Customers/Sign-up/">For more information please complete our online trade signup form.</a></p>
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
