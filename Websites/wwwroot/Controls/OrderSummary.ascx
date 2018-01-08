<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderSummary.ascx.cs" Inherits="SieraDelta.Website.Controls.OrderSummary" %>

<div class="orderSummary">
    <h2><%=Languages.LanguageStrings.OrderSummary %></h2>
    <div runat="server" id="divOrderDetails" class="orderDetails"></div>
    <div runat="server" id="divDeliveryAddress" class="orderAddress"></div>
    <div runat="server" id="divBillingAddress" class="orderAddress"></div>
</div>
