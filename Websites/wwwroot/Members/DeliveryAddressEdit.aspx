<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="DeliveryAddressEdit.aspx.cs" Inherits="SieraDelta.Website.Members.DeliveryAddressEdit" %>
<%@ Register src="~/Members/Controls/ProfileDeliveryAddressEdit.ascx" tagname="ProfileDeliveryAddressEdit" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.DeliveryAddress %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="m/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Account/"><%=Languages.LanguageStrings.MyAccount %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Account/Address/Delivery/"><%=Languages.LanguageStrings.DeliveryAddress %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Account/Address/Delivery/Edit/<%=GetAddressID() %>/"><%=Languages.LanguageStrings.Edit %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.DeliveryAddressEdit %></h1>

			    <uc1:ProfileDeliveryAddressEdit ID="ProfileDeliveryAddressEdit1" 
                    runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
