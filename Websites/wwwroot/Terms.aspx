<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Terms.aspx.cs" Inherits="SieraDelta.Website.Terms" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Terms %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Terms.aspx"><%=Languages.LanguageStrings.TermsAndConditions %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <uc1:leftcontainercontrol id="LeftContainerControl1" runat="server" />

        <div class="mainContent">

            <h1><%=Languages.LanguageStrings.Terms %></h1>

            <div id="divTranslated" runat="server">
                <h3>1. Introductions</h3>
                <p>PLEASE READ THESE WEBSITE TERMS OF USE AND PRIVACY STATEMENT CAREFULLY BEFORE USING ANY PART OF THE SIERADELTA.COM WEBSITE (THE "WEBSITE"). THESE WEBSITE TERMS OF USE (THE "TERMS OF USE") GOVERN YOUR ACCESS TO AND USE OF THE WEBSITE. IF YOU DO NOT AGREE TO ALL OF THE TERMS OF USE AND PRIVACY STATEMENT SET FORTH BELOW, DO NOT USE THE WEBSITE. BY ACCESSING OR USING THE WEBSITE, YOU AND THE BUSINESS ENTITY OR THE ORGANIZATION YOU REPRESENT ("YOU" OR "YOUR") INDICATE YOUR AGREEMENT TO BE BOUND BY THE TERMS OF USE.</p>

                <h3>2. Scope</h3>
                <p>The Website Terms of Use govern Your use of the Website and all applications, content, software, online localization and services (collectively, "Content") available via the Website, except to the extent such Content is the subject of a separate agreement.</p>

                <p>Note that SieraDelta Software Products are governed solely by the License agreements (the "EULA") under which they are sold or licensed. Always check the SieraDelta Software EULA to make certain that neither You nor Your software application, infringe the intellectual property rights of SieraDelta or others.</p>

                <p>SieraDelta reserves the right to modify and update its Privacy Statement and Website Terms of Use as needs dictate and as legal requirements are updated. If and when a change is made to our Privacy Statement or Website Terms of Use, this page will be duly updated to reflect the change. Your continued use of the Website after any changes to these Privacy Statements/Terms of Use will mean that You accept those changes.</p>

                <h3>3. Privacy Statement</h3>
                <p>SieraDelta Respects Your Privacy</p>

                <p>All Information SieraDelta collects from You are stored and maintained on secured servers. SieraDelta does not lend, lease, sell, or market information it obtains from its customers or those who provide us personally identifiable information. SieraDelta does not disclose purchase information or licensing information to third parties.</p>

                <h4>If You Purchase or License a SieraDelta Product</h4>

                <p>SieraDelta collects personally identifiable information whenever You purchase/license a SieraDelta Product. Information includes Name, Address, Phone Number, Email address, Payment Information, Product Purchases, Licenses Owned, Employee/Contact Details, etc. The information we collect allows SieraDelta to communicate with You regarding upcoming product updates, new product releases, company news and other important business matters.</p>

                <p>In each e-mail communication, you will get the opportunity to be removed from the mailing lists, while still being able to log in and download new versions of your products.</p>

                <h4>Cookies</h4>

                <p>SieraDelta may use cookies for technical purposes so as to improve the Website experience or to make use of persistent cookies to remember You between visits to the Website or store Your product installation preferences. You can disable Cookies by modifying the appropriate settings within Your web browser. If You do not wish to store personally identifiable information in Cookies and do not make the appropriate selections within Your web browser, do not use this Website.</p>

                <h3>4. Legal, Copyright and Trademark Information</h3>

                <p>All intellectual property rights associated with the Website and its Contents are the sole property of SieraDelta. The Content is protected by US and International copyright laws. All SieraDelta Service Marks so designated and all SieraDelta Products referenced on the Website are either trademarks or registered trademarks of SieraDelta. All custom graphics, icons, and other items that appear on the Website are trademarks, service marks or trade dress of SieraDelta and may not be used in any manner without the express written consent of SieraDelta.</p>

                <p>SieraDelta has made every effort to supply third-party trademark information on the Website. All third party trademarks represented on this web site may be the property of their respective owners.</p>

                <p>Certain areas of the Website may contain other proprietary notices, conditions of use, and copyright information, the terms of which must be observed and followed.</p>

                <p>Except for the rights of use and other rights expressly granted by these Terms of Use, You may not copy, reproduce, modify, lease, loan, sell, create derivative works from, upload, transmit, or distribute the Intellectual Property of the Website in any manner without the prior written consent of SieraDelta.</p>

                <p>SieraDelta grants You a limited, personal, nontransferable, revocable license which cannot be sub-licensed to access and use the Website and its Content only in a manner expressly authorized by SieraDelta and the Website Terms of Use. Except to the extent required by law, the Content made available on the Website may not be reverse-engineered, modified, reproduced, republished, translated into any language, re-transmitted in any form or by any means, resold or redistributed without the prior written consent of SieraDelta. You may not make, sell, offer for sale, modify, reproduce, display, publicly perform, import, distribute, retransmit or otherwise use the Content in any way, unless expressly permitted to do so by SieraDelta.</p>

                <h3>5. Outbound Links</h3>
                <p>The Website may contain links and references to non-SieraDelta Websites and resources (â€œExternal Sitesâ€). Links to External Sites are provided for informational purposes and in no way represent an endorsement or approval by SieraDelta. SieraDelta makes no representations or warranties regarding the validity or quality of any content, software, or service hosted on any External Site. You agree that use of External Sites is done so at Your own risk.</p>

                <h3>6. Termination</h3>

                <p>SieraDelta, at its sole discretion, may terminate YOUR access and use of all or any portion of the Website and its Content at any time, with or without cause. Upon such termination, You must immediately discontinue use of the Website.</p>

                <h3>7. Disclaimer of Warranties</h3>
                <p>THE CONTENT PROVIDED ON THE WEBSITE AND ALL RELATED COMMUNICATIONS ARE PROVIDED ON AN "AS IS" BASIS AND ARE FOR INFORMATION PURPOSES ONLY. IN ADDITION, ALL WARRANTIES ARE HEREBY DISCLAIMED, INCLUDING THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, OR NON INFRINGEMENT. SOME JURISDICTIONS DO NOT ALLOW THE EXCLUSION OF IMPLIED WARRANTIES, SO THE ABOVE EXCLUSION MAY NOT APPLY TO YOU.</p>

                <p>The Content, including but not limited to localization tools, provided on the Website may contain technical inaccuracies or typographical errors. Content, including but not limited to pricing, subscription terms may be changed or updated without notice. SieraDelta may also make improvements and/or changes in the products and/or the programs described in this information at any time without notice.</p>

                <h3>8. Limitation of Liability</h3>
                <p>To the extent permitted by applicable law, in no event shall SieraDelta be liable for any special, incidental, indirect, or punitive and consequential damages (including, without limitation, damages for loss of business profits, business interruption, loss of business information, or any other pecuniary loss) arising out of the use of or inability to use the Website and associated Content, even if SieraDelta has been advised of the possibility of such damages.</p>

                <p>You understand that the Content made available on the Website may produce inaccurate results. You assume full and sole responsibility for any use of the Website and its Content and bear the entire risk for failures or faults. You agree that regardless of the cause of failure or fault or the form of any claim, YOUR SOLE REMEDY AND SIERADELTA'S SOLE OBLIGATION SHALL BE GOVERNED BY THIS AGREEMENT AND IN NO EVENT SHALL SIERADELTAS'S LIABILITY EXCEED THE PRICE PAID TO SIERADELTA FOR THE SERVICES RENDERED VIA THE WEBSITE.</p>

                <h3>9. Indemnification</h3>
                <p>You agree to indemnify and hold harmless SieraDelta, its contractors, and its licensors, and their respective directors, officers, employees and agents from and against any and all claims and expenses, including attorneysâ€™ fees, arising out of Your use of the Website, including but not limited to Your violation of this Agreement.</p>

                <h3>10. Trademarks</h3>

                <p>"WebDefender Server", "WebDefender Website" and "WebDefender Firebird" are trademarks of SieraDelta.</p>

                <p>All other trademarks or registered trademarks are property of their respective owners.</p>
            </div>

            <uc2:webpagetags id="WebPageTags1" runat="server" />
        </div>
        <!-- end of #mainContent -->


        <div class="clear">
            <!-- clear -->
        </div>
    </div>
</asp:Content>
