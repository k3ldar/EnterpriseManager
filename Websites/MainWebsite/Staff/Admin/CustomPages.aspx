<%@ Page EnableEventValidation="false" Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="CustomPages.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Admin.CustomPages" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx">Home</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Index.aspx">Staff</a></li>
                <li>&rsaquo;</li>
                <li>Admin</li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Admin/CustomPages.aspx">Custom Web Pages</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <uc1:LeftContainerControl ID="LeftContainerControl2" runat="server" SubOptionsShow="true" />

        <div class="mainContent">

            <h1>Custom Website Pages</h1>

            <p>From here you can update custom web pages on your website.</p>

            <div class="form">
                <p>
                    Country<br />
                    <asp:DropDownList ID="lstCountry" runat="server" style="width: 350px;" AutoPostBack="True" OnSelectedIndexChanged="lstCountry_SelectedIndexChanged"></asp:DropDownList>
                </p>
                <p>
                    Website Page<br />
                    <asp:DropDownList ID="lstPage" runat="server" style="width: 350px;" AutoPostBack="True" OnSelectedIndexChanged="lstPage_SelectedIndexChanged"></asp:DropDownList><br /><br />
                    <asp:Button ID="btnLoad" runat="server" Text="Load" />
                </p>
            </div>
            <p>&nbsp;</p>
            <p>

                <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" EnableSanitization="false"
                    DisplaySourceTab="true" TargetControlID="txtContent"
                    OnImageUploadComplete="HtmlEditorExtender1_ImageUploadComplete">
                    <Toolbar>
                        <asp:Undo />
                        <asp:Redo />
                        <asp:Bold />
                        <asp:Italic />
                        <asp:Underline />
                        <asp:StrikeThrough />
                        <asp:Subscript />
                        <asp:JustifyLeft />
                        <asp:JustifyCenter />
                        <asp:JustifyRight />
                        <asp:JustifyFull />
                        <asp:InsertOrderedList />
                        <asp:InsertUnorderedList />
                        <asp:RemoveFormat />
                        <asp:SelectAll />
                        <asp:UnSelect />
                        <asp:Delete />
                        <asp:Cut />
                        <asp:Copy />
                        <asp:Paste />
                        <asp:BackgroundColorSelector />
                        <asp:ForeColorSelector />
                        <asp:FontNameSelector />
                        <asp:FontSizeSelector />
                        <asp:Indent />
                        <asp:Outdent />
                        <asp:InsertHorizontalRule />
                        <asp:HorizontalSeparator />
                        <asp:CreateLink />
                        <asp:UnLink />
                        <asp:InsertImage />
                    </Toolbar>
                </asp:HtmlEditorExtender>
                <asp:TextBox ID="txtContent" runat="server" Height="800px" TextMode="MultiLine"
                    Width="100%" MaxLength="32000"></asp:TextBox>
            </p>
            
            <div class="form">
                <p><asp:CheckBox id="cbActive" runat="server" Text="Active"></asp:CheckBox><br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                </p>
            </div>

            <div id="divOptions" runat="server"></div>

        </div>
        <!-- end of #mainContent -->

        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
