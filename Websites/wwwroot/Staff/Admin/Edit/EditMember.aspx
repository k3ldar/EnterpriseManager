<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="EditMember.aspx.cs" Inherits="SieraDelta.Website.Staff.Admin.EditObject" %>

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
                <li><a href="/Staff/Admin/CustomPages.aspx">Edit Class Member</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />

        <div class="mainContent">

            <h1 style="text-transform:none;">Edit <%=GetMemberName() %></h1>

            <p>From here you can update Documentation Members</p>
            <p><a href="/Modules/Member.aspx?id=<%=GetMemberID() %>">Preview</a></p>

            <div class="form">
                <p>Description</p>
                <p>
                    <asp:TextBox ID="txtDescription" runat="server" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </p>
                <p>Return Description</p>
                <p>
                    <asp:TextBox ID="txtReturnDescription" runat="server" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </p>
                <p>Example</p>
                <p>
                    <asp:TextBox ID="txtExample" runat="server" Height="400px" TextMode="MultiLine"
                        Width="100%" MaxLength="32000"></asp:TextBox>
                </p>

                <p id="pParamaters" runat="server"></p>
            
                <p>
                    <asp:CheckBox id="cbActive" runat="server" Text="Active"></asp:CheckBox><br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
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
