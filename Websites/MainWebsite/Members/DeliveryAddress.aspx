<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="DeliveryAddress.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.PageDeliveryAddress" %>
<%@ Register src="../Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.DeliveryAddresses %> - <%=Languages.LanguageStrings.Home %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/DeliveryAddress.aspx"><%=Languages.LanguageStrings.DeliveryAddresses %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />		
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MyDeliveryAddresses %></h1>
				
                <p id="pDeliveryAddresses" runat="server">
                
                </p>


                <div class="content form">
                    <asp:Button ID="btnNew" runat="server" Text="New" onclick="btnNew_Click" />
                    <div class="spacer"></div>
                </div>


			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
