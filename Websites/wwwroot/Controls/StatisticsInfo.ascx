<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatisticsInfo.ascx.cs" Inherits="SieraDelta.Website.Controls.StatisticsInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="divPopupControl" runat="server" class="webDefenderStatistics">
   <strong><%=Languages.LanguageStrings.CurrentStatistics %></strong> <img src="/images/question_mark.png" alt="What does this mean?" />
    <p>
        <%=IntrusionsStatistics() %>
    </p>
</div>

<cc1:modalpopupextender id="ModalPopupExtender1" runat="server" 
	cancelcontrolid="btnCancel" 
    
	targetcontrolid="divPopupControl" 
    popupcontrolid="pnlWebDefenderStatistics"
    backgroundcssclass="ModalPopupBG"  >
</cc1:modalpopupextender>

<asp:panel id="pnlWebDefenderStatistics" runat="server">
	<div class="statisticsPopup">
        <div id="divLanguage" runat="server">
		    <h2><%=Languages.LanguageStrings.CurrentStatistics %></h2>
		    <div class="content">
			    <p>
                    The statistics are made from connections that have at least 10 failed connections over a 20 second period.
                    <br />
                    OR
                    <br />
                    20 failed connections in total or an average of 4 failed connections per minute.
			    </p>
                <p>The first ban for an ip address is for 10 hours, <br />the second ban is for 24 hours,<br />the third ban is for 300 hours.</p>
                <p>The figures provided are based on IP Addresses banned across 2 public facing servers.</p>
		    </div>
        </div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
	</div>
</asp:panel>
