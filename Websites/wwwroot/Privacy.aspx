<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Privacy.aspx.cs" Inherits="SieraDelta.Website.Privacy" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Privacy %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Privacy.aspx"><%=Languages.LanguageStrings.Privacy %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <%--<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />--%>

        <div class="mainContent" style="float:left;">

            <h1><%=Languages.LanguageStrings.Privacy %></h1>

            <div id="divTranslated" runat="server">
            </div>

            <p>&nbsp;</p>

            <uc2:WebPageTags ID="WebPageTags1" runat="server" />
        </div>
        <!-- end of #mainContent -->


        <div class="clear">
            <!-- clear -->
        </div>
    </div>
</asp:Content>
