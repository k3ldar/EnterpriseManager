<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="SalesEvents.aspx.cs" Inherits="SieraDelta.Website.Reports.SalesEvents" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
                <li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Reports/SalesEvents.aspx">Charts - With Event History</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <div class="Content">
            <h1>
                Monthly Salon Chart</h1>
            <div class="content">
                <table border="0" width="600px">
                    <tr>
                        <td style="width: 30%;">Data Range</td>
                        <td style="width: 30%;" id="tdSelectText" runat="server"></td>
                        <td style="width: 30%;">Country</td>
                        <td style="width: 10%;"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="lstRange" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="lstRange_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="lstMonth" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="lstMonth_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="lstCountry" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="lstCountry_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            Invoice Type</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="cmbInvoiceType" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem>Online</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Office</asp:ListItem>
                                <asp:ListItem>Salon</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td><asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                                onclick="btnRefresh_Click" /></td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox ID="cbShowTextAsHint" runat="server" Checked="True" 
                                Text="Show Maximum Detail in Hint" AutoPostBack="True" 
                                oncheckedchanged="cbShowTextAsHint_CheckedChanged" />&nbsp;
                            <asp:CheckBox ID="cbShowRedLine" Checked="true" runat="server" 
                                Text="Show Red Line" AutoPostBack="True" 
                                oncheckedchanged="cbShowTextAsHint_CheckedChanged" />
                        </td>
                    </tr>
                </table>

                <p>
                    <asp:Chart ID="Chart1" runat="server" Width="1100px" Height="600px" Palette="BrightPastel">
                        <Titles>
                            <asp:Title Font="Ariel, 14pt"></asp:Title>
                        </Titles>
                        <Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"  AlignmentOrientation="Horizontal" >
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Docking="Bottom" Alignment="Center" >
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                </p>
            </div>
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
    <!-- end of #content -->
</asp:Content>
