<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveFeedback.ascx.cs" Inherits="Heavenskincare.Helpdesk.Controls.LeaveFeedback" %>
<%@ Register src="~/Controls/VerificationImage.ascx" tagname="VerificationImage" tagprefix="uc1" %>
<div class="content form">
                <asp:Label ForeColor="Red" ID="lblError" runat="server">Error Message goes here, hidden if no message</asp:Label><br /><br />
                <label><%=Languages.LanguageStrings.Name %></label><asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
                <label><%=Languages.LanguageStrings.Comments %></label><asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" MaxLength="8000"></asp:TextBox><br />
                <uc1:VerificationImage ID="VerificationImage1" runat="server" />
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    onclick="btnSubmit_Click" />		

</div>