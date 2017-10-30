<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="CountryLanguageSelect.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.CountryLanguageSelect" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="divPopupControl" runat="server" class="languageCurrencyBox" style="width:100px;">
    <%=GetLanguageCurrency() %>
</div>

<cc1:modalpopupextender id="ModalPopupExtender1" runat="server" 
	cancelcontrolid="btnCancel" 
    
	targetcontrolid="divPopupControl" 
    popupcontrolid="pnlLangCurrSelector"
    backgroundcssclass="ModalPopupBG"  >
</cc1:modalpopupextender>

<asp:panel id="pnlLangCurrSelector" runat="server">
	<div class="langCurrPopup">
        <div id="divLanguage" runat="server">
		    <h2><%=Languages.LanguageStrings.SelectLanguage %></h2>
		    <div class="content">
			    <%=Languages.LanguageStrings.Language %>
                <asp:DropDownList ID="ddlLanguage" runat="server"></asp:DropDownList>
		    </div>
        </div>
        <div id="divCurrency" runat="server">
		    <h2><%=Languages.LanguageStrings.SelectCurrency %></h2>
            <div class="content">
			    <%=Languages.LanguageStrings.Currency %>
                <asp:DropDownList ID="ddlCurrency" runat="server"></asp:DropDownList>
		    </div>
        </div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
	</div>
</asp:panel>
