<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="InvoiceView.aspx.cs" Inherits="SieraDelta.Website.Members.InvoiceView" %>
<%@ Register src="../Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.ViewInvoice %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Members/Invoices.aspx"><%=Languages.LanguageStrings.Invoices %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/InvoiceView.aspx?ID=<%=GetInvoiceNumber() %>"><%=Languages.LanguageStrings.View %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
			<h1><%=Languages.LanguageStrings.ViewInvoice %></h1>
			    
                <p><strong><%=Languages.LanguageStrings.Invoice %></strong> WI<%=GetInvoiceNumber()%></p>

                <p><strong><%=Languages.LanguageStrings.Date %></strong> <%=GetInvoiceDate()%></p>

                <p id="pConversionRate" runat="server"><strong><%=Languages.LanguageStrings.ConversionRate %></strong> <%=GetConversionRate() %></p>

                <p><strong><%=Languages.LanguageStrings.SubTotal %></strong> <%=GetInvoiceSubtotal()%></p>

                <p><strong><%=Languages.LanguageStrings.Postage %></strong> <%=GetInvoicePostage()%></p>

                <p id="pVAT" runat="server"><strong><%=Languages.LanguageStrings.VAT %> <small>@<%=GetInvoiceVATRate()%>%</small></strong> <%=GetInvoiceVAT()%></p>

                <p id="pDiscount" runat="server"><strong>Discount</strong> <%=GetDiscount() %></p>

                <p><strong><%=Languages.LanguageStrings.Total %></strong> <%=GetInvoiceTotal()%></p>

                <p><strong><%=Languages.LanguageStrings.Status %></strong> <%=GetInvoiceStatus(0)%></p>

                <p><strong><%=Languages.LanguageStrings.OrderStatus %></strong> <%=GetInvoiceStatus(1)%></p>

                <%=GetTrackingReference() %>

			    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tblBasket" id="tblItems" runat="server">
				    <tr>
					    <th colspan="2"><%=Languages.LanguageStrings.Description %></th>
    					<th width="12%"><%=Languages.LanguageStrings.Price %></th>
	    				<th width="12%"><%=Languages.LanguageStrings.Quantity %></th>
		    			<th width="12%"><%=Languages.LanguageStrings.Total %></th>
				    </tr>
                </table>
			</div><!-- end of #mainContent -->
			
			<p class="content form">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel Invoice" 
                    onclick="btnCancel_Click" />
            </p>
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
