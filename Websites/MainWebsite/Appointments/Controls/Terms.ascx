<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Terms.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Appointments.Controls.Terms" %>
<h3>
    <%=Languages.LanguageStrings.TermsAndConditions %></h3>
<h5>
    <%=Languages.LanguageStrings.Appointments %></h5>

<div id="divCustomContents" runat="server">
<p>
    Please note that as a courtesy to all clients' prompt appointment schedule is adhered
    To. Late appointments may not be honoured.</p>
<p>
    The booking you are about to make is a provisional booking only, you will be notified
    by a member of staff if this provisional booking can not be made for any reason.
    Please ensure your <a href="/members/Index.aspx" target="_blank">
        contact details are upto date</a>.</p>
<p>
    Once the booking has been confirmed you will be notified by email.</p>
<h5>
    cancellations and non arrival</h5>
<p>
    You must store your credit/debit card details on file, no payment will be taken
    from you unless you cancel with less than 48 hours notice or do not arrive for your
    appointment. If you do fail to arrive for your appointment or cancel with less than
    48 hours notice we regret that we will charge you 50% of the value of your treatment.</p>
<h5>
    Smoking</h5>
<p>
    Please note that it is illegal to smoke anywhere in the Salon.</p>
<h5>
    data security</h5>
<p>
    Personal details taken from clients during consultation procedures will be kept
    safe and in the strictest confidence. We would, on occasion like to send you details
    of open evenings and special promotions. If you would rather not receive these you
    can <a href="/members/SpecialOffers.aspx" target="_blank">
        change your preferences online</a>.</p>
<h5>
    price alteration</h5>
<p>
    We reserve the right to alter prices, without prior notice.</p>
<h5>
    medical conditions</h5>
<p>
    Please inform your therapist of any medical condition including pregnancy prior
    to booking, as some treatments may not be appropriate for you.</p>
<h5>
    contra-indications</h5>
<p>
    <ul>
        <li>We do not recommend waxing or facials before or after sunbeds, sauna, or sunbathing.</li>
        <li>Alcohol should not be consumed before or after Holistic treatments and ensure you
            drink plenty of water.</li>
        <li>We do not recommend pedicures if you suffer from athlete's foot, verrucae or fungal
            infections.</li>
        <li>A skin test is required before having an eyelash tint (new clients only).</li>
    </ul>
</p>
<h5>
    helpful hints</h5>
<p>
    <ul>
        <li>Bring open-toed shoes for your Pedicure.</li>
        <li>Wear loose dark clothing when having a St.Tropez treatment.</li>
        <li>It is advisable to leave all jewellery at home before treatments i.e. massage, facials
            etc.</li>
    </ul>
</p>
<p class="form">
    Please click continue to confirm you accept these terms and conditions.</p>
    </div>
<div class="content form">
    <p>
        <asp:Button ID="btnConfrim" runat="server" Text="Accept Terms and Conditions" OnClick="btnConfrim_Click" />
    </p>
</div>
