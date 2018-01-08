<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Step3.ascx.cs" Inherits="SieraDelta.Website.Appointments.Controls.Step3" %>
<div class="content form">
<asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
<p id="pBookingInfo" runat="server"></p>
<p id="pAppointments" runat="server"></p>
    <asp:Button ID="btnTryAgain" runat="server" Text="TryAgain" 
        onclick="btnTryAgain_Click" />
</div>