<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="SieraDelta.Website.Modules.Class" %>

<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetClassName() %><%=Languages.LanguageStrings.Modules %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <!-- Jscript for syntax highlighting -->
	<script type="text/javascript" src="/js/shCore.js"></script>
	<script type="text/javascript" src="/js/shBrushCSharp.js"></script>
	<link type="text/css" rel="stylesheet" href="/css/shCoreDefault.css"/>
	<script type="text/javascript">SyntaxHighlighter.defaults['gutter'] = false; SyntaxHighlighter.defaults['toolbar'] = false; SyntaxHighlighter.all();</script>
    <!-- END of Jscript for syntax highlighting -->

    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Modules/Index.aspx"><%=Languages.LanguageStrings.Modules %></a></li>
                <li>&rsaquo;</li>
                <li style="text-transform:none;"><%=GetModuleName() %></li>
                <li>&rsaquo;</li>
                <li style="text-transform:none;"><a href="/Modules/Class.aspx?id=<%=GetClassID() %>"><%=GetClassName() %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1 style="text-transform:none;"><%=GetClassName() %></h1>
                
            <!-- end of .productInfo -->

            <!--<div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    
                </p>
                    
            </div> -->

            <p><%=GetClassDescription() %></p>

            <!-- Constructors -->
            <h3 id="hConstructors" runat="server">Constructors</h3>
            <table id="tblConstructors" runat="server" width="<%=GetTableWidth() %>" border="0" cellspacing="0" cellpadding="0" class="tblClassMembers">
                <tr>
                    <th style="min-width:80px;">&nbsp;</th>
                    <th style="width:220px;">Name</th>
                    <th style="width:410px;">Description</th>
                </tr>
            </table>
            <!-- End Constructors -->

            <!-- Properties -->
            <h3 id="hProperties" runat="server">Properties</h3>
            <table id="tblProperties" runat="server" width="<%=GetTableWidth() %>" border="0" cellspacing="0" cellpadding="0" class="tblClassMembers">
                <tr>
                    <th style="min-width:80px;">&nbsp;</th>
                    <th style="width:220px;">Name</th>
                    <th style="width:410px;">Description</th>
                </tr>
            </table>
            <!-- End Properties -->

            <!-- Static Properties -->
            <h3 id="hStaticProperties" runat="server">Static Properties</h3>
            <table id="tblStaticProperties" runat="server" width="<%=GetTableWidth() %>" border="0" cellspacing="0" cellpadding="0" class="tblClassMembers">
                <tr>
                    <th style="min-width:80px;">&nbsp;</th>
                    <th style="width:220px;">Name</th>
                    <th style="width:410px;">Description</th>
                </tr>
            </table>
            <!-- End Static Properties -->
           
            <!-- Methods -->
            <h3 id="hMethods" runat="server">Methods</h3>
            <table id="tblMethods" runat="server" width="<%=GetTableWidth() %>" border="0" cellspacing="0" cellpadding="0" class="tblClassMembers">
                <tr>
                    <th style="min-width:80px;">&nbsp;</th>
                    <th style="width:220px;">Name</th>
                    <th style="width:410px;">Description</th>
                </tr>
            </table>
            <!-- End Methods -->
           
            <!-- Static Methods -->
            <h3 id="hStaticMethods" runat="server">Static Methods</h3>
            <table id="tblStaticMethods" runat="server" width="<%=GetTableWidth() %>" border="0" cellspacing="0" cellpadding="0" class="tblClassMembers">
                <tr>
                    <th style="min-width:80px;">&nbsp;</th>
                    <th style="width:220px;">Name</th>
                    <th style="width:410px;">Description</th>
                </tr>
            </table>
            <!-- End Static Methods -->
            
            <!-- Events -->
            <h3 id="hEvents" runat="server">Events</h3>
            <table id="tblEvents" runat="server" width="<%=GetTableWidth() %>" border="0" cellspacing="0" cellpadding="0" class="tblClassMembers">
                <tr>
                    <th style="min-width:80px;">&nbsp;</th>
                    <th style="width:220px;">Name</th>
                    <th style="width:410px;">Description</th>
                </tr>
            </table>
            <!-- End Events -->

            <!-- Static Events -->
            <h3 id="hStaticEvents" runat="server">Static Events</h3>
            <table id="tblStaticEvents" runat="server" width="<%=GetTableWidth() %>" border="0" cellspacing="0" cellpadding="0" class="tblClassMembers">
                <tr>
                    <th style="min-width:80px;">&nbsp;</th>
                    <th style="width:220px;">Name</th>
                    <th style="width:410px;">Description</th>
                </tr>
            </table>
            <!-- End Static Events -->
            
            <h3 style="margin-top: 25px;">Example</h3>
            <pre class="brush: csharp;">
<%=GetSampleUsage() %>
            </pre>

            <p>&nbsp;</p>
            <p id="pEdit" runat="server" style="padding-top:30px;"><a href="/Staff/Admin/Edit/EditClass.aspx?type=class&id=<%=GetClassID() %>">Edit</a></p>

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
