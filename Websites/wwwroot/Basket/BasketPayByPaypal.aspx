<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketPayByPaypal.aspx.cs" Inherits="SieraDelta.Website.Basket.BasketPayByPaypal" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.PaymentFailed %> - <%=Languages.LanguageStrings.YourShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
		
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
    			<h1 id="hHeader" runat="server"><%=Languages.LanguageStrings.OrderComplete %></h1>

                    <p id="pInvoice" runat="server" class="content form">
                        <%=Languages.LanguageStrings.PaypointPaymentFailed %> <br /><br />
						<asp:Button id="btnPayNow" runat="server" Text="Pay Now" onclick="btnPayNow_Click"></asp:Button> &nbsp;
						<asp:Button id="btnCancelOrder" runat="server" Text="Cancel Order" onclick="btnCancelOrder_Click"></asp:Button>&nbsp;
						<asp:Button id="btnContactUs" runat="server" Text="Contact Us" onclick="btnContactUs_Click"></asp:Button>
                    </p>


            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
