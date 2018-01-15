<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TradeSignup3.ascx.cs" Inherits="SieraDelta.Website.Controls.Controls.TradeSignup3" %>
<div class="content form">
    <h3><%=Languages.LanguageStrings.StepThreeOfThree %></h3>
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage3A %></label><asp:TextBox ID="txtTreatments" runat="server" TextMode="MultiLine"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage3B %></label><asp:TextBox ID="txtProductsUse" runat="server" TextMode="MultiLine"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage3C %>?</label><asp:TextBox ID="txtClients" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage3D %></label><asp:TextBox ID="txtFurther" runat="server" TextMode="MultiLine"></asp:TextBox><br />
   
    <asp:Button ID="btnNext" runat="server" Text="Submit" 
        onclick="btnNext_Click" />
    <div class="spacer"></div>
</div>
