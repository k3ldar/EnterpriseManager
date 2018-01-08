<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Cookies.aspx.cs" Inherits="SieraDelta.Website.Members.Cookies" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Cookies %> - <%=Languages.LanguageStrings.Home %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
    <meta name="Keywords" content="<%=GetMetaKeyWords()%>" />

    <script type="text/javascript">
        function OpenPopup(Page) {
            window.open(Page, "List", "scrollbars=yes,menubar=no,toolbar=no,directories=no,resizable=yes,width=500,height=300");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.MyAccount %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Members/CardDetails.aspx"><%=Languages.LanguageStrings.Cookies %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc2:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="false" />

        <div class="mainContent">

            <h1><%=Languages.LanguageStrings.Cookies %></h1>

            <p>If you're seeing this message then your browser's cookie functionality is turned off, it's possible that you don't have cookies enabled in your browser.</p>
            <p>
                The site requires cookies so we can maintain a basket for you.<br />
                Please enable cookies within your browser settings (see notes below) and you can continue to shop.<br />
                If you still experience problems, you may need to delete any stored cookies.
            </p>
            <p><a href="javascript:OpenPopup('http://en.wikipedia.org/wiki/HTTP_cookie');">What are cookies?</a></p>
            <p>Please consult your browsers documentation on how to enable cookies.</p>
        </div>
        <!-- end of #mainContent -->


        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
