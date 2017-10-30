<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="CardDetails.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.CreditCard" %>
<%@ Register src="~/Members/Controls/ProfileCreditCard.ascx" tagname="ProfileCreditCard" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.CreditDebitCard %> - <%=Languages.LanguageStrings.Home %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Members/CardDetails.aspx"><%=Languages.LanguageStrings.CreditDebitCard %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />

			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MyCreditCard %></h1>

                <h3><%=Languages.LanguageStrings.CurrentCardDetails %></h3>
                <p id="pCurrentDetails" runat="server"></p>

                <p id="pDeleteDetails" runat="server" class="form">
                    <asp:Button ID="btnRemove" runat="server" Text="Remove Card Details" 
                        onclick="btnRemove_Click" /></p>

                <p>&nbsp;</p><p>&nbsp;</p>

                <h3><%=Languages.LanguageStrings.UpdateAddCard %></h3>
			    <uc1:ProfileCreditCard ID="ProfileCreditCard1" runat="server" />
                <p>&nbsp;</p><p>&nbsp;</p>
                <div id="divCustomContents" runat="server">
                <p>Heavenskincare.com accepts payment by a variety of methods including Visa, Mastercard and Paypal.</p>

                <p>We are committed to ensuring the safety of your purchases, as well as your personal details and we want our customers to feel safe before, during and after their online transactions.</p>

                <p>This is why we have all the security protocols that protect you and allow you to make secure purchases on Heavenskincare.com. </p>

                <p>Your personal details will not be shared with other companies without your express permission.</p>

                <p>Why do we need your credit card details?  Some of our services require confirmation, this is achieved by storing credit card details on file, where this is the case you will be clearly notified.</p>

                <p>You are under no obligation to store credit/debit card details with us however, access to certain products or services may not be available.</p>
                </div>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
