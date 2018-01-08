<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VerificationImage.ascx.cs" Inherits="SieraDelta.Website.Controls.VerificationImage" %>


<asp:Image ID="Image1" runat="server" class="left210" /><br />
<label><%=Languages.LanguageStrings.EnterCodeShown %></label>
<asp:TextBox ID="txtValidationCode" runat="server"></asp:TextBox><br />
<asp:Label ForeColor="Red" ID="lblValid" runat="server" Text="The code you entered is not valid!" class="left210"></asp:Label>
