using System;
using Languages;
using Library;
using Library.BOL.Accounts;

namespace Website.Library.Classes
{
    public static class EnumTranslations
    {
        public static string TranslatedText(PaymentStatus paymentStatus)
        {
            switch (paymentStatus.Description)
            {
                case "Paid":
                    return (LanguageStrings.PaymentTypePaid);
                case "Paypal Not Paid":
                    return (LanguageStrings.PaymentTypePaypalNotPaid);
                case "Phone Not Paid":
                    return (LanguageStrings.PaymentTypePhoneNotPaid);
                case "Cheque Not Paid":
                    return (LanguageStrings.PaymentTypeChequeNotPaid);
                case "Paynet Not Paid":
                    return (LanguageStrings.PaymentTypePaynetNotPaid);
                case "Paypal Paid":
                    return (LanguageStrings.PaymentTypePaypalPaid);
                case "Phone Paid":
                    return (LanguageStrings.PaymentTypePhonePaid);
                case "Cheque Paid":
                    return (LanguageStrings.PaymentTypeChequePaid);
                case "Paynet Paid":
                    return (LanguageStrings.PaymentTypePaynetPaid);
                case "Cancelled":
                    return (LanguageStrings.PaymentTypeCancelled);
                case "Paypal Pending":
                    return (LanguageStrings.PaymentTypePaypalPending);
                case "Credit Card Paid":
                    return (LanguageStrings.PaymentTypeCreditCardPaid);
                case "Credit Card Not Paid":
                    return (LanguageStrings.PaymentTypeCreditCardNotPaid);
                case "Cash On Delivery":
                    return (LanguageStrings.PaymentTypeCashOnDeliveryPaid);
                case "Direct Bank Transfer":
                    return (LanguageStrings.PaymentTypeDirectBankTransferNotPaid);
                case "Cash On Delivery - Paid":
                    return (LanguageStrings.PaymentTypeCashOnDeliveryPaid);
                case "Direct Bank Transfer - Paid":
                    return (LanguageStrings.PaymentTypeDirectBankTransferPaid);
                case "In Salon Not Paid":
                    return (LanguageStrings.PaymentTypeInStoreNotPaid);
                case "In Salon Paid Cash":
                    return (LanguageStrings.PaymentTypeInStorePaidCash);
                case "In Salon Paid Card":
                    return (LanguageStrings.PaymentTypeInStorePaidCard);
                case "In Salon Paid Cheque":
                    return (LanguageStrings.PaymentTypeInStorePaidCheque);
                case "In Salon Split Payment":
                    return (LanguageStrings.PaymentTypeInStoreSplitPayment);
                case "Office Not Paid":
                    return (LanguageStrings.PaymentTypeOfficeNotPaid);
                case "Office Paid":
                    return (LanguageStrings.PaymentTypeOfficePaid);
                case "Unknown":
                    return (LanguageStrings.Unknown);
                case "SunTech BuySafe - Not Paid":
                    return (LanguageStrings.PaymentTypeBuySafeNotPaid);
                case "SunTech BuySafe - Paid":
                    return (LanguageStrings.PaymentTypeBuySafePaid);
                case "SunTech 24Payment - Not Paid":
                    return (LanguageStrings.PaymentType24PaymentNotPaid);
                case "SunTech 24Payment - Paid":
                    return (LanguageStrings.PaymentType24PaymentPaid);
                case "SunTech WebATM - Not Paid":
                    return (LanguageStrings.PaymentTypeWebATMNotPaid);
                case "SunTech WebATM - Paid":
                    return (LanguageStrings.PaymentTypeWebATMPaid);
                default:
#if DEBUG
                    throw new Exception("Invalid Payment Type");
#else
                    return (paymentStatus.ToString());
#endif
            }
        }

        /// <summary>
        /// Gets translated text for process status
        /// </summary>
        /// <param name="processStatus"></param>
        /// <returns></returns>
        public static string TranslatedText(ProcessStatus processStatus)
        {
            switch (processStatus)
            {
                case ProcessStatus.Cancelled:
                    return (LanguageStrings.ProcessStatusCancelled);
                case ProcessStatus.Dispatched:
                    return (LanguageStrings.ProcessStatusDispatched);
                case ProcessStatus.IssueRefund:
                    return (LanguageStrings.ProcessStatusIssueRefund);
                case ProcessStatus.OrderReceived:
                    return (LanguageStrings.ProcessStatusOrderReceived);
                case ProcessStatus.PaymentPending:
                    return (LanguageStrings.ProcessStatusPaymentPending);
                case ProcessStatus.Processing:
                    return (LanguageStrings.ProcessStatusProcessing);
                case ProcessStatus.OnHold:
                    return (processStatus.ToString());
                case ProcessStatus.VerifyingPayment:
                    return (processStatus.ToString());
                default:
#if DEBUG
                    throw new Exception("Invalid Process Status");
#else
                    return (processStatus.ToString());
#endif
            }
        }
    }
}
