<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SEOChart.ascx.cs" Inherits="SieraDelta.Website.Controls.SEOChart" %>
            <div class="content form">
                <label>Period</label><asp:DropDownList ID="lstRange" runat="server" style="margin-top: 7px;">
                                <asp:ListItem Selected="True">Daily</asp:ListItem>
                                <asp:ListItem>Weekly</asp:ListItem>
                            </asp:DropDownList> <br /><br />
                <label>Series 1</label><asp:DropDownList ID="lstDataType1" runat="server" style="margin-top: 7px;width:140px;">
                                <asp:ListItem>Total Visits</asp:ListItem>
                                <asp:ListItem Selected="True">User Visits</asp:ListItem>
                                <asp:ListItem>Mobile Visits</asp:ListItem>
                                <asp:ListItem>Bot Visits</asp:ListItem>
                                <asp:ListItem>Bounced</asp:ListItem>
                                <asp:ListItem>Minimum Pages</asp:ListItem>
                                <asp:ListItem>Maximum Pages</asp:ListItem>
                                <asp:ListItem>Average Pages</asp:ListItem>
                                <asp:ListItem>Total Pages</asp:ListItem>
                                <asp:ListItem>Timed Visits</asp:ListItem>
                                <asp:ListItem>Conversions</asp:ListItem>
                                <asp:ListItem>Mobile Conversions</asp:ListItem>
                                <asp:ListItem>Percent Converted</asp:ListItem>
                                <asp:ListItem>Percent Converted Mobile</asp:ListItem>
                                <asp:ListItem>Refer Google</asp:ListItem>
                                <asp:ListItem>Refer Twitter</asp:ListItem>
                                <asp:ListItem>Refer Facebook</asp:ListItem>
                                <asp:ListItem>Refer Bing</asp:ListItem>
                                <asp:ListItem>Refer Yahoo</asp:ListItem>
                                <asp:ListItem>Refer Organic</asp:ListItem>
                                <asp:ListItem>Refer Direct</asp:ListItem>
                                <asp:ListItem>Referral</asp:ListItem>
                                <asp:ListItem>Refer Unknown</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="lstBarType1" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
                    <asp:ListItem Selected="True">Area</asp:ListItem>
                    <asp:ListItem>Column</asp:ListItem>
                    <asp:ListItem>Line</asp:ListItem>
                </asp:DropDownList><br />
                
                <label>Series 2</label><asp:DropDownList ID="lstDataType2" runat="server" style="margin-top: 7px;width:140px;">
                                <asp:ListItem>None</asp:ListItem>
                                <asp:ListItem>Total Visits</asp:ListItem>
                                <asp:ListItem>User Visits</asp:ListItem>
                                <asp:ListItem Selected="True">Mobile Visits</asp:ListItem>
                                <asp:ListItem>Bot Visits</asp:ListItem>
                                <asp:ListItem>Bounced</asp:ListItem>
                                <asp:ListItem>Minimum Pages</asp:ListItem>
                                <asp:ListItem>Maximum Pages</asp:ListItem>
                                <asp:ListItem>Average Pages</asp:ListItem>
                                <asp:ListItem>Total Pages</asp:ListItem>
                                <asp:ListItem>Timed Visits</asp:ListItem>
                                <asp:ListItem>Conversions</asp:ListItem>
                                <asp:ListItem>Mobile Conversions</asp:ListItem>
                                <asp:ListItem>Percent Converted</asp:ListItem>
                                <asp:ListItem>Percent Converted Mobile</asp:ListItem>
                                <asp:ListItem>Refer Google</asp:ListItem>
                                <asp:ListItem>Refer Twitter</asp:ListItem>
                                <asp:ListItem>Refer Facebook</asp:ListItem>
                                <asp:ListItem>Refer Bing</asp:ListItem>
                                <asp:ListItem>Refer Yahoo</asp:ListItem>
                                <asp:ListItem>Refer Organic</asp:ListItem>
                                <asp:ListItem>Refer Direct</asp:ListItem>
                                <asp:ListItem>Referral</asp:ListItem>
                                <asp:ListItem>Refer Unknown</asp:ListItem>
                            </asp:DropDownList></asp:DropDownList><asp:DropDownList ID="lstBarType2" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
                    <asp:ListItem>Area</asp:ListItem>
                    <asp:ListItem Selected="True">Column</asp:ListItem>
                    <asp:ListItem>Line</asp:ListItem>
                </asp:DropDownList><br />
                <label>Series 3</label><asp:DropDownList ID="lstDataType3" runat="server" style="margin-top: 7px;width:140px;">
                                <asp:ListItem>None</asp:ListItem>
                                <asp:ListItem>Total Visits</asp:ListItem>
                                <asp:ListItem>User Visits</asp:ListItem>
                                <asp:ListItem>Mobile Visits</asp:ListItem>
                                <asp:ListItem>Bot Visits</asp:ListItem>
                                <asp:ListItem>Bounced</asp:ListItem>
                                <asp:ListItem>Minimum Pages</asp:ListItem>
                                <asp:ListItem>Maximum Pages</asp:ListItem>
                                <asp:ListItem Selected="True">Average Pages</asp:ListItem>
                                <asp:ListItem>Total Pages</asp:ListItem>
                                <asp:ListItem>Timed Visits</asp:ListItem>
                                <asp:ListItem>Conversions</asp:ListItem>
                                <asp:ListItem>Mobile Conversions</asp:ListItem>
                                <asp:ListItem>Percent Converted</asp:ListItem>
                                <asp:ListItem>Percent Converted Mobile</asp:ListItem>
                                <asp:ListItem>Refer Google</asp:ListItem>
                                <asp:ListItem>Refer Twitter</asp:ListItem>
                                <asp:ListItem>Refer Facebook</asp:ListItem>
                                <asp:ListItem>Refer Bing</asp:ListItem>
                                <asp:ListItem>Refer Yahoo</asp:ListItem>
                                <asp:ListItem>Refer Organic</asp:ListItem>
                                <asp:ListItem>Refer Direct</asp:ListItem>
                                <asp:ListItem>Referral</asp:ListItem>
                                <asp:ListItem>Refer Unknown</asp:ListItem>
                            </asp:DropDownList></asp:DropDownList><asp:DropDownList ID="lstBarType3" runat="server" style="width:80px;margin-left:20px;margin-top: 7px;">
                    <asp:ListItem>Area</asp:ListItem>
                    <asp:ListItem Selected="True">Column</asp:ListItem>
                    <asp:ListItem>Line</asp:ListItem>
                </asp:DropDownList><br />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                                onclick="btnRefresh_Click" />
            </div>
            <div class="content">

                <p>
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
            </div>
