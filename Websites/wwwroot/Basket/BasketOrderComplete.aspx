<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketOrderComplete.aspx.cs" Inherits="SieraDelta.Website.Basket.BasketOrderComplete" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.OrderComplete %> - <%=Languages.LanguageStrings.ShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
		
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
    			<h1 id="hHeader" runat="server"><%#Languages.LanguageStrings.OrderComplete %></h1>

                    <h3 id="hInvoice" runat="server" class="content form">
                        <%#Languages.LanguageStrings.Invoice %>
                    </h3>

                    <p id="pPaypal" runat="server" class="content form">
                        <%#Languages.LanguageStrings.OrderCompletePaypal %>
                    </p>

                    <p id="pCheque" runat="server" class="content form">

                    </p>

                    <p id="pTelephone" runat="server" class="content form">
                        
                    </p>

                    <p id="pCashOnDelivery" runat="server" class="content form">
                        
                    </p>

                    <p id="pDirectTransfer" runat="server" class="content form">
                        
                    </p>

                    <p class="content form"><strong><%#Languages.LanguageStrings.QuoteOrderNumber %></strong></p>
                    <p id="pPostalAddress" runat="server" class="content form">
                        
                    </p>
            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
