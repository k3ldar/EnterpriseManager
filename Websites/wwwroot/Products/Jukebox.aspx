<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Jukebox.aspx.cs" Inherits="SieraDelta.Website.Products.Jukebox" %>

<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>
<%@ Register src="../Controls/FileDownload.ascx" tagname="FileDownload" tagprefix="uc1" %>

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
                <li><a href="/Products/Jukebox.aspx">Jukebox</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>Jukebox Music Player</h1>

            <div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server">
					    <img src="/Images/Products/jbox_288.png" alt="" border="0" width="288" height="268"/>
                </asp:HyperLink>
            </div>
            <!-- end of .productImg -->
                
            <!-- end of .productInfo -->

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    Our jukebox software allows you to easily turn your Windows PC into a digital jukebox using your already existing music collection. 
                </p>
                <p>
                    The simple and uncomplicated interface was designed to make it easy to use, by anybody, on any occasion.
                </p>
                <p>
                    Initially designed for use at a wedding, this jukebox offers some unique features to keep a party going, including: 
                </p>
                <h2>Simple Configuration</h2>
                <p>
                    Simply select the folder where your music resides and click Start
                    <img src="/Images/Products/Jukebox/JukeBox1.png" border="0" alt="" />
                </p>
                <h2>Kiosk Mode</h2>
                <p>
                    <img src="/Images/Products/Jukebox/JukeBox2.png" border="0" alt="" />
                </p>
            </div>

                <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>
                            Kiosk Mode - Full screen display allowing users to easily select songs without modifying settings.
                        </li>
                        <li>
                            Prevent Replay - Prevent songs from being replayed until a specific number of songs have been played.
                        </li>
                        <li>
                            Playlist Limit - Only allow a specific number of songs on the playlist, preventing a single person from choosing too many songs of their choice.
                        </li>
                        <li>
                            Overlap songs - Overlap songs for continual playing.
                        </li>
                        <li>
                            Autoplay - Used in kiosk mode, a song will be randomly selected when no songs have been included in the play list.
                        </li>
                        <li>
                            Freeware - Free for personal or commercial use.
                        </li>
                        <li>
                            No licence fee's and free updates.
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
