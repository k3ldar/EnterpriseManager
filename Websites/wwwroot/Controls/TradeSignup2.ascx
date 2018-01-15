<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TradeSignup2.ascx.cs" Inherits="SieraDelta.Website.Controls.Controls.TradeSignup2" %>
<div class="content form">
    <h3><%=Languages.LanguageStrings.StepTwoOfthree %></h3>
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage2A %></label><asp:TextBox ID="txtInterested" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage2B %></label><asp:TextBox ID="txtHear" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage2C %></label><asp:TextBox ID="txtSpecialise" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage2D %></label><asp:TextBox ID="txtRooms" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage2E %></label><asp:TextBox ID="txtTherapists" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage2F %></label><asp:TextBox ID="txtTrading" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TradeSignupPage2G %></label><asp:TextBox ID="txtTreatments" 
        runat="server" TextMode="MultiLine"></asp:TextBox><br />
   
    <asp:Button ID="btnNext" runat="server" Text="Next" 
        onclick="btnNext_Click" />
    <div class="spacer"></div>
</div>
