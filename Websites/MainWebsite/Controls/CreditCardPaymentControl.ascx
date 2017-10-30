<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreditCardPaymentControl.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.CreditCardPaymentControl" %>
<%@ Register src="~/Members/Controls/ProfileCreditCard.ascx" tagname="ProfileCreditCard" tagprefix="uc1" %>

<div class="content basketForm" style="border-right: thin solid #666; padding-bottom: 10px; padding-right: 40px;">
    <h3 id="hCurrent" runat="server"><%=Languages.LanguageStrings.CurrentCardDetails %></h3>
    
    <p id="pCurrentSelection" runat="server">
        <asp:RadioButton ID="rbCurrent" runat="server" Checked="true" value="rbCurrent" GroupName="CardSelected" />
        <%=Languages.LanguageStrings.CardUseExisting %>
    </p>
    <p id="pCurrentDetails" runat="server">
    </p>
                
    <h3><%=Languages.LanguageStrings.CardDetails %></h3>
    <p id="pUseNewSelection" runat="server"><asp:RadioButton ID="rbNew" runat="server" value="rbNew" GroupName="CardSelected" />
        <%=Languages.LanguageStrings.CardUseNew %>
    </p>
	<uc1:ProfileCreditCard ID="ProfileCreditCard1" runat="server" />
</div>