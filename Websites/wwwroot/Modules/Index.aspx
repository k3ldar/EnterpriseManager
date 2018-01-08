<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Modules.Index" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Modules %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Modules/Index.aspx"><%=Languages.LanguageStrings.Modules %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1><%=Languages.LanguageStrings.Modules %></h1>
                
            <!-- end of .productInfo -->

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    Over many years I have developed a set of Core modules which contain, well tested, reusable components and objects.    
                </p>
                <p>
                    These modules are now available as freeware, for use in commercial and non commercial software under a <a href="#licence">general Freeware licence</a> and downloadable from below, or from the <a href="/Download/Index.aspx">download area</a>.
                </p>
                <p>
                    By reusing thoroughly tested, optimized objects and components, application development time can be significantly reduced.
                </p>
                    
                <%=GetModuleNames() %>

                <h2 id="licence" style="padding-top:50px">Freeware Licence</h2>
                <p>This Freeware License Agreement (the "Agreement") is a legal agreement between you ("Licensee"), the end-user, and SieraDelta.com for the use of this software product ("Software"). Commercial as well as non-commercial use is allowed. By using this Software or storing this program or parts of it on a computer hard drive (or other media), you agree to be bound by the terms of this Agreement. Provided that you verify that you are handling the original freeware version you are hereby licensed to make as many copies of the freeware version of this Software and documentation as long as you do not charge money or request donations for such copies. You may not alter this Software in any way. You may not modify, rent or sell this Software, or create derivative works based upon this Software.</p>
                <p>Provided that you verify that you are handling the original freeware version you are hereby licensed to make as many copies of the Freeware version of this Software and documentation as long as you do not charge money or request donations for such copies. You may not alter this Software in any way. You may not modify, rent or resell for profit this Software, or create derivative works based upon this Software.</p> 
                <h5>Governing Law</h5>
                <p>This agreement shall be governed by the laws of the United Kingdom. If any portion of this Agreement is deemed unenforceable by a court of competent jurisdiction, it shall not affect the forcibility of the other portions of this Agreement. Limited Warranty and Disclaimer of Warranty.</p>
                <h5>Limited Warranty and Disclaimer of Warranty</h5>
                <p>SieraDelta.com EXPRESSLY DISCLAIMS ANY WARRANTY FOR THE SOFTWARE. THIS SOFTWARE AND THE ACCOMPANYING FILES ARE PROVIDED "AS IS" AND WITHOUT WARRANTIES AS TO PERFORMANCE OF MERCHANTABILITY OR ANY OTHER WARRANTIES WHETHER EXPRESSED OR IMPLIED, OR NONINFRINGEMENT. THIS SOFTWARE IS NOT FAULT TOLERANT AND SHOULD NOT BE USED IN ANY ENVIRONMENT WHICH REQUIRES THIS. NO LIABILITY FOR DAMAGES. In no event shall SieraDelta.com or its suppliers be liable for any consequential, incidental or indirect damages whatsoever (including, without limitation, damages for loss of business profits, business interruption, loss of business information, or any other pecuniary loss) resulting of the use of or inability to use this SOFTWARE EVEN IF SieraDelta.com HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. The entire risk resulting of use or performance of the SOFTWARE remains with you.</p>
                <h5>Copyright</h5>
                <p>Copyright (c) by SieraDelta.com. All rights reserved.</p>
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
