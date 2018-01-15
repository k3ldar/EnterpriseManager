<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="FBSPGen.aspx.cs" Inherits="SieraDelta.Website.Products.FBSPGen" %>

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
                <li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=GetPrimaryProductGroup()%></li>
                <li>&rsaquo;</li>
                <li><a href="/Products/FBSPGen.aspx">Firebird Stored Procedure Generator</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>Firebird Stored Procedure Generator</h1>

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    Firebird Stored Procedure Generator (FBSPGen) generates standard, template stored procedures based on table properties, the stored procedures that can be created are:
                </p>
                <ul>
                    <li>Insert</li>
                    <li>Update</li>
                    <li>Update or Insert</li>
                    <li>Delete</li>
                    <li>Select</li>
                    <li>Select All</li>
                    <li>Select Page</li>
                    <li>Count</li>
                </ul>
                <p>As well as creating templated stored procedures, FBSPGen can optionally create a C++ and C# classes that can be used to interact with your database.</p>
                
                <p>    
                     In C++ an application is created, in C# a library is created.  Both languages support a business object layer (BOL) and data access layer (DAL) which can access the stored procedures created.
                </p>
                <h3>BOL/DAL Feature Matrix</h3>
                <p>
                    <img src="/Images/Products/FBSPGen/Step5Options.png" border="0" alt="" />
                </p>
                <p>
                    <img src="/Images/Products/FBSPGen/Step4SelectTables.png" border="0" alt="" />
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>GUI Wizard Interface.
                        </li>
                        <li>Generates a SQL script.
                        </li>
                        <li>Does not update database directly.
                        </li>
                        <li>Generates C++ and C# class library with Business object layer and Data access layer</li>
                        <li>Specify sort order and which tables/columns to include.
                        </li>
                        <li>Save configuration for future use.
                        </li>
                        <li>100% Free for personal, commercial and all other uses.
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
