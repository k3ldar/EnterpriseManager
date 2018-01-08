<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="FBLockUDF.aspx.cs" Inherits="SieraDelta.Website.Products.FBLockUDF" %>

<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>

<%@ Register src="~/Controls/FileDownload.ascx" tagname="FileDownload" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetProductGroupName()%> - <%=GetProductName() %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <!-- Jscript for syntax highlighting -->
	<script type="text/javascript" src="/js/shCore.js"></script>
	<script type="text/javascript" src="/js/shBrushSQL.js"></script>
	<link type="text/css" rel="stylesheet" href="/css/shCoreDefault.css"/>
	<script type="text/javascript">SyntaxHighlighter.defaults['gutter'] = false; SyntaxHighlighter.defaults['toolbar'] = false; SyntaxHighlighter.all();</script>
    <!-- END of Jscript for syntax highlighting -->
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=GetPrimaryProductGroup()%></li>
                <li>&rsaquo;</li>
                <li><a href="/Products/FBSPGen.aspx">Firebird Stored Procedure Generator</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>Firebird Lock UDF</h1>

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    Firebird Lock UDF is a UDF module for windows server which can obtain a server wide lock for a maximum of a specified amount of seconds.
                </p>
                
                <p>
                    Especially useful if you require unique access to resources for a short period of time.
                </p>

                <p>Locks are not connection or transaction specific, and there is no security available for who can obtain or release a lock.</p>

                <h3>External Function Definitions</h3>
                <pre class="brush: sql;">
                    DECLARE EXTERNAL FUNCTION fb_ServerLockGet CSTRING(100), INTEGER
                    RETURNS INTEGER BY VALUE
                    ENTRY_POINT 'fbServerLockGet'
                    MODULE_NAME 'fbLockUdf';

                    DECLARE EXTERNAL FUNCTION fb_ServerLockRel CSTRING(100)
                    RETURNS INTEGER BY VALUE
                    ENTRY_POINT 'fbServerLockRel'
                    MODULE_NAME 'fbLockUdf';
                </pre>

                <h3>Restrictions</h3>
                <ul>
                    <li>Maximum of 10 locks per database instance.</li>
                    <li>Maximum lock wait of 2000 milliseconds</li>
                </ul>

                <h3>fbServerLockGet</h3>
                <p>
                fbServerLockGet obtains a server wide lock
                </p>

                <h5>Parameters</h5>

                <p>
                    CSTRING(100)  - Unique string to identify the lock
                    INTEGER       - Number of seconds the lock can remain active
                </p>
                <p>
                    Return Value  - INTEGER
                </p>
                <ul>
                    
                    <li>0   -   Lock Obtained</li>
                    <li>1   -   Maximum Lock Count Exceeded</li>
                    <li>2   -   Lock Already Exists</li>
                    <li>3   -   Invalid Lock Handle</li>
                    <li>4   -   Access Denied</li>
                    <li>5   -   Time Out waiting to obtain a lock</li>
                    <li>6   -   Invalid Lock Name </li>
                    <li>7   -   Invalid Parameter</li>
                    <li>8   -   Invalid Age (Must be between 0 and 1440 seconds)</li>
                    <li>9   -   Lock not Found</li>
                    <li>999 -   General Error</li>

                </ul>
                <h3>fbServerLockRel</h3>
                <p>
                fbServerLockRel releases a server wide lock
                </p>

                <h5>Parameters</h5>

                <p>
                    CSTRING(100)  - Unique string to identify the lock
                </p>
                <p>
                    Return Value  - INTEGER
                </p>
                <ul>
                    
                    <li>0   -   Lock Released</li>
                    <li>3   -   Invalid Lock Handle</li>
                    <li>4   -   Access Denied</li>
                    <li>5   -   Time Out waiting to obtain a lock</li>
                    <li>6   -   Invalid Lock Name </li>
                    <li>9   -   Lock not Found</li>
                    <li>999 -   General Error</li>

                </ul>
                <p>
                    
                </p>
                    
                <p>
                    Source code is available via Git Hub <a href="https://github.com/k3ldar/fbLockUDF" target="_blank">https://github.com/k3ldar/fbLockUDF</a>
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>32 and 64 bit versions.</li>
                        <li>Free for personal, commercial and all other uses.</li>
                        <li>Source code available.</li>
                        <li>Unlimited Updates/Patches</li>
                        <li>Open Source - <a href="https://www.firebirdsql.org/en/initial-developer-s-public-license-version-1-0/" target="_blank">Released under Initial Developers Public Licence</a></li>
                    </ul>
                </div>
            </div>

            <uc1:FileDownload ID="FileDownload1" runat="server" />

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
