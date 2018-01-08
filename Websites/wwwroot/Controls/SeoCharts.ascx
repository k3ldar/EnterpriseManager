<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SeoCharts.ascx.cs" Inherits="SieraDelta.Website.Controls.SeoCharts" %>

<div class="content form" id="divSelectCriteria" runat="server">
        <label>Period</label>
        <asp:DropDownList ID="lstRange" runat="server" style="margin-top: 7px;" AutoPostBack="True" OnSelectedIndexChanged="lstRange_SelectedIndexChanged">
            <asp:ListItem>Hourly</asp:ListItem>
            <asp:ListItem Selected="True">Daily</asp:ListItem>
            <asp:ListItem>Weekly</asp:ListItem>
            <asp:ListItem>Monthly</asp:ListItem>
        </asp:DropDownList> <br />
    <div id="divType" runat="server">
        <label id="lblType" runat="server">Type</label>
        <asp:DropDownList ID="lstType" runat="server" style="margin-top: 7px;" AutoPostBack="True" OnSelectedIndexChanged="lstRange_SelectedIndexChanged">
            <asp:ListItem Selected="True">Visitors</asp:ListItem>
            <asp:ListItem>Visits by Countries</asp:ListItem>
            <asp:ListItem>Visits by Cities</asp:ListItem>
            <asp:ListItem>Sales By Countries</asp:ListItem>
            <asp:ListItem>Sales By Cities</asp:ListItem>
        </asp:DropDownList> 
                    
        <br />
    </div>
    <div id="divMonthSelection" runat="server">
        <label id="lblYear" runat="server">Year</label>
        <asp:DropDownList ID="lstYears" runat="server" style="margin-top: 7px;">
        </asp:DropDownList> 
                    
        <br />
        <label id="lblMonth" runat="server">Month</label>
        <asp:DropDownList ID="lstMonths" runat="server" style="margin-top: 7px;">
        </asp:DropDownList> 
        <br />

    </div>
    <br />

    <div id="divSeriesOptions" runat="server">
        <label id="lblSeries1" runat="server">Series 1</label>
        <asp:DropDownList ID="lstDataType1" runat="server" style="margin-top: 7px;width:140px;">
        </asp:DropDownList>
        <asp:DropDownList ID="lstBarType1" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
            <asp:ListItem Selected="True">Area</asp:ListItem>
            <asp:ListItem>Column</asp:ListItem>
            <asp:ListItem>Line</asp:ListItem>
        </asp:DropDownList><br />
                
        <label id="lblSeries2" runat="server">Series 2</label>
        <asp:DropDownList ID="lstDataType2" runat="server" style="margin-top: 7px;width:140px;">
        </asp:DropDownList>
        <asp:DropDownList ID="lstBarType2" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
            <asp:ListItem>Area</asp:ListItem>
            <asp:ListItem Selected="True">Column</asp:ListItem>
            <asp:ListItem>Line</asp:ListItem>
        </asp:DropDownList><br />

        <label id="lblSeries3" runat="server">Series 3</label>
        <asp:DropDownList ID="lstDataType3" runat="server" style="margin-top: 7px;width:140px;">
        </asp:DropDownList>
        <asp:DropDownList ID="lstBarType3" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
            <asp:ListItem>Area</asp:ListItem>
            <asp:ListItem Selected="True">Column</asp:ListItem>
            <asp:ListItem>Line</asp:ListItem>
        </asp:DropDownList><br />

        <label id="lblSeries4" runat="server">Series 4</label>
        <asp:DropDownList ID="lstDataType4" runat="server" style="margin-top: 7px;width:140px;">
        </asp:DropDownList>
        <asp:DropDownList ID="lstBarType4" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
            <asp:ListItem>Area</asp:ListItem>
            <asp:ListItem Selected="True">Column</asp:ListItem>
            <asp:ListItem>Line</asp:ListItem>
        </asp:DropDownList><br />

        <label id="lblSeries5" runat="server">Series 5</label>
        <asp:DropDownList ID="lstDataType5" runat="server" style="margin-top: 7px;width:140px;">
        </asp:DropDownList>
        <asp:DropDownList ID="lstBarType5" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
            <asp:ListItem>Area</asp:ListItem>
            <asp:ListItem Selected="True">Column</asp:ListItem>
            <asp:ListItem>Line</asp:ListItem>
        </asp:DropDownList><br />

        <label id="lblSeries6" runat="server">Series 6</label>
        <asp:DropDownList ID="lstDataType6" runat="server" style="margin-top: 7px;width:140px;">
            <asp:ListItem>None</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="lstBarType6" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
            <asp:ListItem>Area</asp:ListItem>
            <asp:ListItem Selected="True">Column</asp:ListItem>
            <asp:ListItem>Line</asp:ListItem>
        </asp:DropDownList><br />
    </div>
    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                    onclick="btnRefresh_Click" />
</div>
<div class="content">
    <p id="pChart" runat="server">
        <asp:Chart ID="Chart1" runat="server" Width="1100px" Height="500px" Palette="BrightPastel">
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
        <div id="divMap" runat="server" style="height:500px;width:800px;">
        </div>
</div>


