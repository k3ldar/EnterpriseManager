<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Terms.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Terms" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Terms %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Terms.aspx"><%=Languages.LanguageStrings.TermsAndConditions %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />

        <div class="mainContent">

            <h1><%=Languages.LanguageStrings.Terms %></h1>

            <div id="divCustomContents" runat="server">
                <h3>heaven購物說明</h3>

                <h3>線上購物方式</h3>

                <p>
                    簡易購物流程：step by step！<br />
                    選擇商品加入購物車→結帳→確認寄件地址→選擇付款方式→確認購物明細→完成購物
                </p>

                <p>
                    Step 1.<br />
                    挑選您喜愛的商品及數量放入「購物車」。
                </p>
                <p>
                    Step 2.<br />
                    會員：請輸入使用者名稱、密碼後按下「登入」。<br />
                    訪客：第一次購買請先「加入會員」。
                </p>
                <p>
                    Step 3.<br />
                    確認寄件地址
                </p>
                <p>Step 4.</p>
                <ol type="1" style="color: #666; font-size: 1.3em; list-style: decimal; line-height: 1.5em; margin: 0 0 1.5em 20px;">
                    <li>選擇「付款方式」。</li>
                    <li>備註收件時間及其他需求。</li>
                    <li>查看購物明細及金額是否正確。</li>
                    <li>點選「確認訂單」完成訂購。</li>
                </ol>


                <p>
                    Step 5.<br />
                    完成線上刷卡或匯款後，將在3-5個工作天內收到您的商品。<br />
                    可於「我的帳號」中檢視您的訂單明細。
                </p>

                <h3>付款方式</h3>
                <p>
                    線上刷卡：適用卡別有VISA、Master Card、JCB信用卡、銀聯卡、美國運通卡。<br />
                    PayPal：適用卡別有VISA、Master Card、美國運通卡。(注意：第一次購物須先登入PayPal帳號。)<br />
                    轉帳匯款：春藤國際事業股份有限公司<br />
                    合作金庫 東門分行<br />
                    帳號：0060717329778<br />
                    電洽客服：由heaven客服為您以信用卡結帳 02-23410005<br />
                    heaven線上購物系統皆採用SSL加密，敬請安心購物。
                </p>

                <h3>配送方式</h3>
                <p>
                    訂單成立並完成結帳後，將於3-5個工作天內(不含例假日)，透過宅配通將訂購商品送達指定地點。<br />
                    請注意：預購商品出貨時間，依預購單上註明之出貨時間為準。
                </p>

                <h3>運費計算</h3>
                <p>
                    台灣地區：不限品項及數量，一律免運費
                    <br />
                    亞太區其他國家：單筆訂單酌收國際運費NT$ 200元
                </p>

                <h3>退貨/換貨流程</h3>
                <p>
                    快速退換貨：<br />
                    自購買日起七日之內，持原購物發票及商品完整包裝（含標籤）至原購買門市辦理。<br />
                    若為持信用卡消費者，請攜帶原信用卡和簽單。消費時若有贈送抵用券（含各式禮券）、贈品，須於退貨或換貨時將抵用券及贈品一併附回。
                </p>

                <p>
                    線上/海外退換貨流程：step by step！<br />
                    告知客服→寄回商品→辦理退款或換貨→完成退換貨
                </p>

                <p>
                    Step 1.<br />
                    電話申請：撥打客服專線 02-23410005<br />
                    來函申請：寫信至heaven客服信箱 service@heavenskincare.com.tw<br />
                    請註明您的姓名、退換貨商品及有效之聯絡方式，以便加速處理時間。
                </p>

                <p>
                    Step 2.<br />
                    將收到之商品完整包裝寄返原購買門市。消費時若有贈送抵用券（含各式禮券）、贈品，須於退貨或換貨時將抵用券及贈品一併附回。<br />
                    如您已收到發票，請依發票背面銷退折讓單之說明，簽章確認後連同完整商品一並寄回原購門市，以便客服人員儘速為您辦理退款。
                </p>

                <p>
                    Step 3.<br />
                    門市人員收到您的寄返商品，並確認無誤後，將盡速為您辦理退款或換貨。
                </p>

                <p>
                    Step 4.<br />
                    於3-5個工作天內(不含例假日)收到您的退款或換購商品，完成退換貨流程。
                </p>

                <p>下列情況除商品本身瑕疵外，恕無法辦理退換貨：</p>
                <ul>
                    <li>發票、信用卡、抵用券未附回或商品包裝已破壞者。</li>
                    <li>所支付的禮券及提貨券性質為購買當初已開立發票者。</li>
                    <li>購買門市特價、折扣商品者。</li>
                </ul>
                <h3>售後須知</h3>
                <ol type="1" style="color: #666; font-size: 1.3em; list-style: decimal; line-height: 1.5em; margin: 0 0 1.5em 20px;">
                    <li>基於個人衛生安全考量，全系列商品一經拆封或使用，恕無接受退換貨。</li>
                    <li>請將商品保存於乾燥陰涼的地方，勿長期放置在高溫或高濕的環境中，以免變質。</li>
                    <li>商品本身有瑕疵可辦理退貨，請保持包裝完整(包含購買商品、附件、內外包裝、贈品等)請一併退回，若缺件將會影響退貨權限。</li>
                    <li>網頁商品依個人電子裝置螢幕色差及解析度不同，造成圖片顏色略有差異，請以實品顏色為準。</li>
                </ol>
            </div>

            <p>&nbsp;</p>
            <uc2:WebPageTags ID="WebPageTags1" runat="server" />
        </div>
        <!-- end of #mainContent -->


        <div class="clear">
            <!-- clear -->
        </div>
    </div>
</asp:Content>
