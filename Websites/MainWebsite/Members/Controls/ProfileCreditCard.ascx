<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileCreditCard.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.Controls.ProfileCreditCard" %>
<div id="dMain" runat="server" class="content form">
    <label ForeColor="Red" ID="lblError" runat="server">Error Message goes here, hidden if no message</label><br /><br />
    <label><%=Languages.LanguageStrings.CardNumber %></label><asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox><br />
    <label id="lblValidFrom" runat="server"><%=Languages.LanguageStrings.ValidFrom %></label>
    <asp:DropDownList ID="ddlFromMonth" runat="server" style="Width:50px;" >
        <asp:ListItem Value="01">01</asp:ListItem>
        <asp:ListItem Value="02">02</asp:ListItem>
        <asp:ListItem Value="03">03</asp:ListItem>
        <asp:ListItem Value="04">04</asp:ListItem>
        <asp:ListItem Value="05">05</asp:ListItem>
        <asp:ListItem Value="06">06</asp:ListItem>
        <asp:ListItem Value="07">07</asp:ListItem>
        <asp:ListItem Value="08">08</asp:ListItem>
        <asp:ListItem Value="09">09</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="11">11</asp:ListItem>
        <asp:ListItem Value="12">12</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlFromYear" runat="server" style="Width:50px;">
    </asp:DropDownList>    <br />
    <label><%=Languages.LanguageStrings.ValidTo %></label>
    <asp:DropDownList ID="ddlToMonth" runat="server" style="Width:50px;">
        <asp:ListItem Value="01">01</asp:ListItem>
        <asp:ListItem Value="02">02</asp:ListItem>
        <asp:ListItem Value="03">03</asp:ListItem>
        <asp:ListItem Value="04">04</asp:ListItem>
        <asp:ListItem Value="05">05</asp:ListItem>
        <asp:ListItem Value="06">06</asp:ListItem>
        <asp:ListItem Value="07">07</asp:ListItem>
        <asp:ListItem Value="08">08</asp:ListItem>
        <asp:ListItem Value="09">09</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="11">11</asp:ListItem>
        <asp:ListItem Value="12">12</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlToYear" runat="server" style="Width:50px;">
    </asp:DropDownList>     <br />
    <label><%=Languages.LanguageStrings.NameOnCard %></label><asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Last3Digits %></label><asp:TextBox ID="txtLast3" runat="server" Style="width: 50px;" MaxLength="3"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.CardType %></label><asp:DropDownList ID="ddlCardType" runat="server" 
        style="Width:150px;">
    </asp:DropDownList><br />
    
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Add Card" 
        onclick="btnSubmit_Click" />
    
    <asp:CheckBox ID="cbStoreDetails" runat="server" Visible="false" /><label id="lblStoreDetails" runat="server" visible="false" style="width: 270px;text-align: left;margin-left: 10px;"><%=Languages.LanguageStrings.CardSaveCardDetails %></label></div>
