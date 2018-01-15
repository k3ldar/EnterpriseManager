<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Terms.aspx.cs" Inherits="SieraDelta.Website.Terms" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Terms %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Company/Terms-And-Conditions/"><%=Languages.LanguageStrings.TermsAndConditions %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <%--<uc1:leftcontainercontrol id="LeftContainerControl1" runat="server" />--%>

        <div class="mainContent" style="float:left;">

            <h1><%=Languages.LanguageStrings.Terms %></h1>

            <div id="divTranslated" runat="server">
            </div>

            <uc2:webpagetags id="WebPageTags1" runat="server" />
        </div>
        <!-- end of #mainContent -->


        <div class="clear">
            <!-- clear -->
        </div>
    </div>
</asp:Content>
