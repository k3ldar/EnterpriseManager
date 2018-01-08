<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketPaymentFailed.aspx.cs" Inherits="SieraDelta.Website.Basket.BasketPaymentFailed" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.PaymentFailed %> - <%=Languages.LanguageStrings.YourShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
		
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
    			<h1><%=Languages.LanguageStrings.PaymentFailed %></h1>

                    <p class="content form">
                        <%=Languages.LanguageStrings.PaypalPaymentFailed %>
                    </p>
					<p class="content form">
                    	<asp:Button id="btnPayNow" runat="server" onclick="btnPayNow_Click" 
                            Text="Pay Now"></asp:Button>&nbsp;
						<asp:Button id="btnCancelOrder" runat="server" onclick="btnCancelOrder_Click" 
                            Text="Cancel Order"></asp:Button>&nbsp;
						<asp:Button id="btnContactUs" runat="server" onclick="btnContactUs_Click" 
                            Text="Contact Us"></asp:Button>
                    </p>
            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
