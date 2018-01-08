<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipsnTricks.aspx.cs" Inherits="SieraDelta.Website.Tips.PageTip" %>
<%@ Register src="~/Controls/FeaturedProducts.ascx" tagname="FeaturedProducts" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetTipName() %> - <%=SieraDelta.Languages.LanguageStrings.TipsAndTricks %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=SieraDelta.Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/TipsnTricks.aspx"><%=SieraDelta.Languages.LanguageStrings.TipsAndTricks %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Tips/Tip.aspx?ID=<%=GetFormValue("ID", 1) %>"><%=GetTipName() %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=GetTipName() %></h1>
				
				<div class="clear"><!-- clear --></div>
				
				<p><%=GetTipDescription() %></p>
				
                <uc1:MediaLinks ID="MediaLinks1" runat="server" class="CenteredDiv" />

				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(SieraDelta.Library.BOL.TipsTricks.TipsTricks.GetCount(), 1, GetFormValue("Page", 1), "/TipsnTricks.aspx")%>
					</ul>
				</div><!-- end of .pagination -->

				<uc1:FeaturedProducts ID="FeaturedProducts1" runat="server" />
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
