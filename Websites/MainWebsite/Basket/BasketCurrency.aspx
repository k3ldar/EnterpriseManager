<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketCurrency.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Basket.BasketCurrency" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />

        <div class="mainContent">
            <h1 id="hHeader" runat="server"><%#Languages.LanguageStrings.Currency %></h1>

            <p id="pPaypal" runat="server" class="content form">
                <%#Languages.LanguageStrings.OrderCompletePaypal %>
            </p>
        </div>
        <!-- end of #mainContent -->

        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
