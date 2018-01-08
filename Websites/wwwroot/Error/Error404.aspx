<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="SieraDelta.Website.Error.Error404" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/buyitnow.css" type="text/css" media="screen" />
    <title><%=Languages.LanguageStrings.PageNotFound %> - <%=Languages.LanguageStrings.Error %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=Languages.LanguageStrings.Error %></li>
                <li>&rsaquo;</li>
                <li><%=Languages.LanguageStrings.PageNotFound %></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />

        <div class="mainContent">

            <h1><%=Languages.LanguageStrings.PageNotFound %></h1>

            <p><%=Languages.LanguageStrings.Error404A %></p>

            <p><%=Languages.LanguageStrings.Error404B %></p>

            <p>
                &nbsp;&nbsp;1. <%=Languages.LanguageStrings.Error404C %><br />
                &nbsp;&nbsp;2. <%=Languages.LanguageStrings.Error404D %><br />
                &nbsp;&nbsp;3. <%=Languages.LanguageStrings.Error404E %>
            </p>

            <p><%=Languages.LanguageStrings.Error404F %></p>

            <p><%=Languages.LanguageStrings.Error404G %></p>

                <div class="frm_search" style="margin-right: 550px;">
                    <asp:TextBox ID="txtSearchTerms" runat="server" onblur="clickrecall(this)" onclick="clickclear(this)"></asp:TextBox>
                    <input type="image" src="/images/search.gif" runat="server" id="btnSearch" />
                </div>
                        

            <p>
        </div>
        <!-- end of #mainContent -->


        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
