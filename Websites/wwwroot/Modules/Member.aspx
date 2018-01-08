<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="SieraDelta.Website.Modules.Member" %>

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
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Modules/Index.aspx"><%=Languages.LanguageStrings.Modules %></a></li>
                <li>&rsaquo;</li>
                <li style="text-transform:none;"><%=GetModuleName() %></li>
                <li>&rsaquo;</li>
                <li style="text-transform:none;"><a href="/Modules/Class.aspx?id=<%=GetClassID() %>"><%=GetClassName() %></a></li>
                <li>&rsaquo;</li>
                <li style="text-transform:none;"><a href="/Modules/Member.aspx?id=<%=GetMemberID() %>"><%=GetMemberNameShort() %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1 style="text-transform:none;"><%=GetMemberName() %></h1>
                
            <!-- end of .productInfo -->

            <!--<div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    
                </p>
                    
            </div> -->

            <p><%=GetMemberDescription() %></p>

            <h3>Namespace</h3>
            <p><%=GetNameSpace() %></p>

            <h3 style="margin-top: 25px;">Syntax</h3>
            <pre class="brush: csharp;">
<%=GetSyntax() %>
            </pre>


            <h3 id="hParameters" runat="server" style="margin-top: 25px;">Parameters</h3>
            <div id="pParameters" runat="server"></div>

            <h3 id="hReturns" runat="server" style="margin-top: 25px;">Returns</h3>
            <div id="pReturns" runat="server"></div>

            <h3 style="margin-top: 25px;">Example</h3>
            <pre class="brush: csharp;">
<%=GetSampleUsage() %>
            </pre>

            <p id="pEdit" runat="server" style="padding-top:30px;"><a href="/Staff/Admin/Edit/EditMember.aspx?type=member&id=<%=GetMemberID() %>">Edit</a></p>
            <p>&nbsp;</p>

            
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
