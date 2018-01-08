<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="FBCompare.aspx.cs" Inherits="SieraDelta.Website.Products.FBCompare" %>

<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>

<%@ Register src="~/Controls/FileDownload.ascx" tagname="FileDownload" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetProductGroupName()%> - <%=GetProductName() %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=GetPrimaryProductGroup()%></li>
                <li>&rsaquo;</li>
                <li><a href="/Products/FBCompare.aspx">Firebird Database Compare</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>Firebird Database Compare</h1>

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    Firebird Compare scans two databases (Master and Child) and highlights any differences between them, and provides the necessary SQL to rectify the differences.
                </p>
                <p>
                    <img src="/Images/Products/FBCompare/fbCompare1.png" border="0" alt="" />
                </p>
                <p>
                    <img src="/Images/Products/FBCompare/fbCompare2.png" border="0" alt="" />
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>GUI Interface.
                        </li>
                        <li>View missing, different or all database objects.
                        </li>
                        <li>Hide specific database objects.
                        </li>
                        <li>Generates SQL
                        </li>
                        <li>Provides a detailed list of the differences between Master and Child databases.
                        </li>
                        <li>Code view for Procedures and Triggers.
                        </li>
                        <li>Specify which database object types to view.
                        </li>
                        <li>100% Free.
                        </li>
                        <li>Unlimited Updates/Patches
                        </li>
                    </ul>
                </div>
            </div>

            <uc1:FileDownload ID="FileDownload1" runat="server" />

            <div class="productVideo" id="divVideoLink" runat="server">
                <h5><%=Languages.LanguageStrings.Video %></h5>
                <p><%=GetVideoLink() %></p>
                <span><%=Languages.LanguageStrings.VideoDescription %> <a href="<%=GetFullVideoLink() %>" target="_blank"><%=Languages.LanguageStrings.ClickHere %></a></span>
            </div>

            <uc2:medialinks id="MediaLinks1" runat="server" />
            <uc2:webpagetags id="WebPageTags1" runat="server" />

            <div class="clear">
                <!-- clear -->
            </div>
        </div>

        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
