<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="FBReplication.aspx.cs" Inherits="SieraDelta.Website.Products.FBReplication" %>

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
                <li><a href="/Products/FBReplication.aspx">Firebird Replication Engine</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>Firebird Replication Engine</h1>

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    SieraDelta's Firebird replication engine provides support for replication between one or more databases, the
                    replication engine supports bi-directional asynchrounous replication with multiple configuration options.
                </p>
                <p>
                    Currently at version 4.0, SieraDelta's Replication is distributed as freeware for personal or commercial use. 
                </p>
                <p> 
                    Technical support is offered on a pay per use basis, please <a href="/ContactUs.aspx">contact us</a> for more details.
                </p>
                <p>
                    <img src="/Images/Products/Replication/Replicationconfig.png" border="0" alt="" />
                </p>
                <p>
                    The replication engine can process replication record failures based on rules.  In general the primary 
                    reason a record fails to replicate is due to inconsistency in a database structure between the master 
                    and child databases.  Should replication fail, detailed logs provide full details.
                </p>
                <p>
                    <img src="/Images/Products/Replication/RulesConfig.png" border="0" alt="" />
                </p>
                <p>
                    As well as providing replication it also supports remote updates and automated backups with options to copy 
                    backup file to off-site locations for security.
                </p>
                <p>
                    <img src="/Images/Products/Replication/Config.png" border="0" alt="" />
                </p>
                <p>
                    Replication can be used in a number of configurations to ensure <a href="/Papers/FirebirdReplicationForHighAvailability.aspx">high availability</a> for business operations.
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>Highly configurable.
                        </li>
                        <li>Freeware for personal or commercial use.
                        </li>
                        <li>Includes remote database update facility.
                        </li>
                        <li>Includes backup up facility.
                        </li>
                        <li>Rules engine for processing failed replication records.
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
