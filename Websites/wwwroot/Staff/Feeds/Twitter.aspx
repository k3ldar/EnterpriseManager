<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Twitter.aspx.cs" Inherits="SieraDelta.Website.WebsiteFeeds.Twitter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Home/">Home</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Index.aspx">Staff</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Feeds/Twitter.aspx">Twitter Feeds</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <div class="mainContentStaff">
            <h1>
                Twitter Searches</h1>
            <p>
                The following tabs display different Twitter search Results, click the different
                tabs to see the search results.</p>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Visible="true"
                Width="100%" Height="600px" ScrollBars="Auto" BackColor="#FAFDD9">
                <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="webdefender">
                    <ContentTemplate>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=webdefender"
                            data-widget-id="393998685064806400">Tweets about "deborah mitchell"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="web defender">
                    <ContentTemplate>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=web+defender" data-widget-id="394002284247404544">
                            Tweets about "bee venom"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="sieradelta">
                    <ContentTemplate>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=sieradelta"
                            data-widget-id="394002116961787905">Tweets about "deborah mitchell"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Firebird Defender">
                    <ContentTemplate>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=firebird+defender"
                            data-widget-id="394001888837771264">Tweets about "heaven skin care"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="heavenskincare">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=heavenskincare" data-widget-id="394001741890338816">
                            Tweets about "heavenskincare"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="bee venom gold">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=bee+venom+gold" data-widget-id="394001561057128448">
                            Tweets about "bee venom gold"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="heaven ellajane">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=heaven+ellajane" data-widget-id="394001230424309760">
                            Tweets about "heaven ellajane"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="heaven ella jane">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=heaven+ella+jane"
                            data-widget-id="394001024018444288">Tweets about "heaven ella jane"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="heavenellajane">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                        <a class="twitter-timeline" href="https://twitter.com/search?q=heavenellajane" data-widget-id="394000677241778177">
                            Tweets about "heavenellajane"</a>
                        <script>                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
    <!-- end of #content -->
</asp:Content>
