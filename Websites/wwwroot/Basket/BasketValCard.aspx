<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketValCard.aspx.cs" Inherits="SieraDelta.Website.Basket.BasketValCard" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.PaynetPayment %> - <%=Languages.LanguageStrings.YourShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Google Code for Sale Conversion Page -->
    		<div class="content">
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
    			<h1><%=Languages.LanguageStrings.PaynetPayment %></h1>
			
               <p id="pPaymentText" runat="server"></p>
            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
