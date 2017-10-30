<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="OfferDC.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.OfferDC" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=Languages.LanguageStrings.SpecialOffers %></li>
                <li>&rsaquo;</li>
                <li><a href="/Offers/Offers.aspx"><%=Languages.LanguageStrings.Offers %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc2:leftcontainercontrol id="LeftContainerControl1" runat="server" />

        <div class="mainContent">

            <h1><%=Languages.LanguageStrings.Offers %></h1>

            <div id="divOffer" runat="server">
                <p>Congratulations, thanks to The Doctors, you’ve won two of Heaven by Deborah Mitchell’s star-studded products, the Silver Bee Venom Mask and Age Defiance. Heaven products are natural and organic and yield amazing, anti-aging results.</p>

                <h3>Info on Bee Venom</h3>

                <p>Formulated with a proprietary ingredient, ABEETOXIN®</p>

                <p>Deborah Mitchell’s signature product, the Bee Venom Mask has gained a World-wide reputation as the ‘natural alternative to Botulinum Toxin’ which is the most acutely toxic substance known.</p>

                <p>Already with a massive celebrity following, it positions itself as a revolutionary organic cream that works to control the facial muscles for  immediate lifting, tightening and firming, whilst targeting frown lines and wrinkles.</p>

                <p>Using this product can provide a facial with a difference: completely natural, non-evasive and with real results.</p>

                <h3>Info on Age Defiance</h3>

                <p>This unique, anti-aging moisturizer helps prevent future breakouts.</p>

                <p>With Increased hyaluronic acid and vitamins, this wonder cream plumps up fine lines, works on scar tissue and gives skin a soft youthful look. What is worst than lines & spots but this anti-ageing cream repairs skin so spots heal. </p>

                <p>To redeem your offer please enter your unique code below and click submit.</p>

                <p id="pError" runat="server" class="hashTagError" style="color: red;"></p>

                <div class="form">
                    <asp:TextBox ID="txtDCCode" runat="server" MaxLength="30"></asp:TextBox><asp:Button Style="margin-left: 20px;" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                </div>
            </div>
            <div id="divSuccess" runat="server">
                <p>Congratulations on redeeming your Heaven gift offer.</p>

                <p>Our busy bee's now have your order and will bee working in a hive of activity to get this flown out to you.</p>

                <p>Prepare to be bee-autiful.</p>

                <p>Love Deb x</p>
            </div>
        </div>
        <!-- end of #mainContent -->


        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
