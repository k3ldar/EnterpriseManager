<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="OrderView.aspx.cs" Inherits="SieraDelta.Website.Members.OrderView" %>
<%@ Register src="../Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.ViewOrder %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Members/Orders.aspx"><%=Languages.LanguageStrings.Orders %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/OrderView.aspx?ID=<%=GetOrderNumber() %>"><%=Languages.LanguageStrings.View %></a></li>
				</ul>
			</div><!-- end of #breadcrumb -->
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
			<h1><%=Languages.LanguageStrings.ViewOrder %></h1>
			    
                <p><strong><%=Languages.LanguageStrings.Order %></strong> #<%=GetOrderNumber() %></p>

                <p><strong><%=Languages.LanguageStrings.Date %></strong> <%=GetOrderDate() %></p>

                <p id="pConversionRate" runat="server"><strong><%=Languages.LanguageStrings.ConversionRate %></strong> <%=GetConversionRate() %></p>

                <p><strong><%=Languages.LanguageStrings.SubTotal %></strong> <%=GetOrderSubtotal() %></p>

                <p><strong><%=Languages.LanguageStrings.Postage %></strong> <%=GetOrderPostage() %></p>

                <p id="pVAT" runat="server"><strong><%=Languages.LanguageStrings.VAT %> <small>@<%=GetOrderVATRate() %>%</small></strong> <%=GetOrderVAT() %></p>

                <p id="pDiscount" runat="server"><strong><%=Languages.LanguageStrings.Discount  %></strong> <%=GetDiscount() %></p>

                <p><strong><%=Languages.LanguageStrings.Total %></strong> <%=GetOrderTotal() %></p>

                <p><strong><%=Languages.LanguageStrings.Status %></strong> <%=GetOrderStatus(0) %></p>

                <p><strong><%=Languages.LanguageStrings.OrderStatus %></strong> <%=GetOrderStatus(1) %></p>

			    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tblBasket" id="tblItems" runat="server">
				    <tr>
					    <th colspan="2"><%=Languages.LanguageStrings.Description %></th>
    					<th width="12%"><%=Languages.LanguageStrings.Price %></th>
	    				<th width="12%"><%=Languages.LanguageStrings.Quantity %></th>
		    			<th width="12%"><%=Languages.LanguageStrings.Total %></th>
				    </tr>
                </table>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
