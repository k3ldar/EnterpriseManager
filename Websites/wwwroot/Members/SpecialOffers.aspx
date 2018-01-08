<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="SpecialOffers.aspx.cs" Inherits="SieraDelta.Website.Members.SpecialOffers" %>
<%@ Register src="~/Members/Controls/ProfileSpecialOffers.ascx" tagname="ProfileSpecialOffers" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Special Offers - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.MyAccount %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/SpecialOffers.aspx"><%=Languages.LanguageStrings.SpecialOffers %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MySpecialOffers %></h1>
				
                <p><%=Languages.LanguageStrings.SpecialOffersDescription %></p>
			
			    <uc1:ProfileSpecialOffers ID="ProfileSpecialOffers1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
