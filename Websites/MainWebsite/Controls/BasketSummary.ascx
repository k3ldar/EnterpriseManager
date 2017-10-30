<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasketSummary.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.BasketSummary" %>
    <script type="text/javascript">
        function HideSummaryDetails()
        {
            document.getElementById("<%=basketSummary.ClientID%>").style.display = "none";
        }

        var autoHide = <%=GetAutoHide()%>;

        if (autoHide)
            setTimeout(function () { document.getElementById("<%=basketSummary.ClientID%>").style.display = "none"; }, <%=AutoHideTimeOut() %>);
    </script>

  <div id="basketSummary" runat="server" class="cartConfirm content" onmouseleave="HideSummaryDetails()">
    <h2><%=Languages.LanguageStrings.ShoppingBag %></h2>
    <div  class="cartItemDescription">
            <img src="https://static.heavenskincare.com/Images/Products/<%=GetProductImage()%>" alt="" border="0" width="89" height="64" align="left" />
        <div><%=GetProductName() %></div>
    </div>
    <div class="subTotal bag">
      <p><%=BasketInfo() %></p>
    </div>
    <div class="basketForm buttonWrapper">
        <asp:Button ID="btnViewBag" runat="server" Text="Button" OnClick="btnViewBag_Click" />
    </div>
  </div>
