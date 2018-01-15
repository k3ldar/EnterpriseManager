<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberLogin.ascx.cs" Inherits="SieraDelta.Website.Members.Controls.MemberLogin" %>
<div class="content form">
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
					<label for="txtUsername"><%=Languages.LanguageStrings.Username %>:</label>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
					
					<label for="txtPassword"><%=Languages.LanguageStrings.Password %>:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
					
					<asp:Button 
                        ID="btnLostPassword" runat="server" Text="Forgot Password" 
                        onclick="btnLostPassword_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogin" runat="server" Text="Login" 
        onclick="btnLogin_Click" /><div class="spacer"></div><br />
        <a id="aSignUpLink" runat="server" href="/Account/Signup/"><%=Languages.LanguageStrings.CreateAnAccount %></a>

</div>