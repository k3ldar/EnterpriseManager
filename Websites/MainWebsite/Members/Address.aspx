<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.Address" %>
<%@ Register src="~/Members/Controls/ProfileBillingAddress.ascx" tagname="ProfileBillingAddress" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.BillingAddress %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Members/Address.aspx"><%=Languages.LanguageStrings.BillingAddress %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true"
                SubHeader="my account"  />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.BillingAddress %></h1>
				
				<p><%=Languages.LanguageStrings.BillingAddressDescription %></p>
				
			    <uc1:ProfileBillingAddress ID="ProfileBillingAddress1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
