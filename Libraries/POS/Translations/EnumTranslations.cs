using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using Library;
using Library.BOL.Accounts;

using POS.Base.Classes;

namespace POS.Base
{
    public static class EnumTranslations
    {
        public static string Translate(RecurringType type)
        {
            switch (type)
            {
                case RecurringType.Day:
                    return (LanguageStrings.Days);

                case RecurringType.Month:
                    return (LanguageStrings.Months);

                case RecurringType.Week:
                    return (LanguageStrings.Weeks);

                case RecurringType.Year:
                    return (LanguageStrings.Years);

                default:
#if DEBUG
                    throw new Exception("Invalid RecurringType");
#else
                    return (type.ToString());
#endif
            }
        }

        public static string Translate(ImageTypes type)
        {
            switch (type)
            {
                case ImageTypes.Products:
                    return (LanguageStrings.Products);
                case ImageTypes.Treatments:
                    return (LanguageStrings.Treatments);
                case ImageTypes.WebsiteTreatments:
                    return (LanguageStrings.AppTreatmentsOnline);
                case ImageTypes.HomePageBanners:
                    return (LanguageStrings.AppHomePageBanners);
                case ImageTypes.OfferImages:
                    return (LanguageStrings.AppCampaign);
                case ImageTypes.PageBanners:
                    return (LanguageStrings.AppPageBanners);
                case ImageTypes.Celebrities:
                    return (LanguageStrings.Celebrities);
                case ImageTypes.Logo:
                    return (LanguageStrings.CompanyLogo);
                default:
#if DEBUG
                    throw new Exception("Invalid ImageTypes Type");
#else
                    return (type.ToString());
#endif
            }
        }

        public static string Translate(SupplierStatus status)
        {
            switch (status)
            {
                case SupplierStatus.Active:
                    return (LanguageStrings.Active);
                case SupplierStatus.OnHold:
                    return (LanguageStrings.OnHold);
                default:
#if DEBUG
                    throw new Exception("Invalid EmployeeLeaveStatus Type");
#else
                    return (status.ToString());
#endif
            }
        }

        public static string Translate(AssetType type)
        {
            switch (type)
            {
                case AssetType.Accessory:
                    return (LanguageStrings.AssetAccessory);
                case AssetType.Asset:
                    return (LanguageStrings.AssetAsset);
                case AssetType.Component:
                    return (LanguageStrings.AssetComponent);
                case AssetType.Consumable:
                    return (LanguageStrings.AssetConsumable);
                case AssetType.License:
                    return (LanguageStrings.AssetLicense);
                default:
#if DEBUG
                    throw new Exception("Invalid EmployeeLeaveStatus Type");
#else
                    return (type.ToString());
#endif
            }
        }

        public static string Translate(EmployeeLeaveStatus status)
        {
            switch (status)
            {
                case EmployeeLeaveStatus.Approved:
                    return (LanguageStrings.AppStaffLeaveStatusApproved);
                case EmployeeLeaveStatus.Authorised:
                    return (LanguageStrings.AppStaffLeaveStatusAuthorised);
                case EmployeeLeaveStatus.Cancelled:
                    return (LanguageStrings.AppStaffLeaveStatusCancelled);
                case EmployeeLeaveStatus.Denied:
                    return (LanguageStrings.AppStaffLeaveStatusDenied);
                case EmployeeLeaveStatus.Requested:
                    return (LanguageStrings.AppStaffLeaveStatusRequested);
                default:
#if DEBUG
                    throw new Exception("Invalid EmployeeLeaveStatus Type");
#else
                    return (status.ToString());
#endif
            }
        }

        /// <summary>
        /// Gets translated text for expense type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string Translate(EmployeeExpenseType type)
        {
            switch (type)
            {
                case EmployeeExpenseType.Lodgings:
                    return (LanguageStrings.AppExpensesLodgings);
                case EmployeeExpenseType.MealBreakfast:
                    return (LanguageStrings.AppExpensesMealBreakfast);
                case EmployeeExpenseType.MealDinner:
                    return (LanguageStrings.AppExpensesMealDinner);
                case EmployeeExpenseType.MealLunch:
                    return (LanguageStrings.AppExpensesMealLunch);
                case EmployeeExpenseType.Mileage:
                    return (LanguageStrings.AppExpensesMileage);
                case EmployeeExpenseType.Other:
                    return (LanguageStrings.AppExpensesOther);
                case EmployeeExpenseType.Parking:
                    return (LanguageStrings.AppExpensesParking);
                case EmployeeExpenseType.TransportOther:
                    return (LanguageStrings.AppExpensesTransportOther);
                case EmployeeExpenseType.TransportPlane:
                    return (LanguageStrings.AppExpensesTransportPlane);
                case EmployeeExpenseType.TransportPublic:
                    return (LanguageStrings.AppExpensesTransportPublic);
                case EmployeeExpenseType.TransportTaxi:
                    return (LanguageStrings.AppExpensesTransportTaxi);
                case EmployeeExpenseType.TransportTrain:
                    return (LanguageStrings.AppExpensesTransportTrain);
                case EmployeeExpenseType.Tolls:
                    return (LanguageStrings.AppExpensesTolls);
                default:
#if DEBUG
                    throw new Exception("Invalid Expense Type");
#else
                    return (type.ToString());
#endif
            }
        }

        /// <summary>
        /// Gets translated text for expense status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string Translate(EmployeeExpenseStatus status)
        {
            switch (status)
            {
                case EmployeeExpenseStatus.Approved:
                    return (LanguageStrings.AppApproved);
                case EmployeeExpenseStatus.Paid:
                    return (LanguageStrings.AppPaid);
                case EmployeeExpenseStatus.Submitted:
                    return (LanguageStrings.Submitted);
                case EmployeeExpenseStatus.Declined:
                    return (LanguageStrings.Declined);
                default:
#if DEBUG 
                    throw new Exception("Invalid Expense Status");
#else
                    return (status.ToString());
#endif
            }
        }

        public static string Translate(MaritalStatus gender)
        {
            switch (gender)
            {
                case MaritalStatus.Single:
                    return (LanguageStrings.AppMaritalStatusSingle);
                case MaritalStatus.Married:
                    return (LanguageStrings.AppMaritalStatusMarried);
                case MaritalStatus.Separated:
                    return (LanguageStrings.AppMaritalStatusSeperated);
                case MaritalStatus.Divorced:
                    return (LanguageStrings.AppMaritalStatusDivorced);
                case MaritalStatus.Widowed:
                    return (LanguageStrings.AppMaritalStatusWidowed);
                default:
                    throw new Exception("Invalid Marital Status");
            }
        }

        public static string Translate(EmploymentType employmentType)
        {
            switch (employmentType)
            {
                case EmploymentType.Contract:
                    return (LanguageStrings.AppEmploymentTypeContract);
                case EmploymentType.Casual:
                    return (LanguageStrings.AppEmploymentTypeCasual);
                case EmploymentType.FixedTerm:
                    return (LanguageStrings.AppEmploymentTypeFixedTerm);
                case EmploymentType.Trainee:
                    return (LanguageStrings.AppEmploymentTypeTrainee);
                case EmploymentType.Apprentice:
                    return (LanguageStrings.AppEmploymentTypeApprentice);
                case EmploymentType.Commission:
                    return (LanguageStrings.AppEmploymentTypeCommission);
                case EmploymentType.Contractor:
                    return (LanguageStrings.AppEmploymentTypeContractor);
                case EmploymentType.ZeroHours:
                    return (LanguageStrings.AppEmploymentTypeZeroHours);
                case EmploymentType.Voluntary:
                    return (LanguageStrings.AppEmploymentTypeVoluntary);
                case EmploymentType.Internship:
                    return (LanguageStrings.AppEmploymentTypeInternship);
                default:
                    throw new Exception("Invalid Employment Type");

            }
        }

        public static string Translate(PaymentStatus paymentStatus)
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
                case "In Store Not Paid":
                    return (LanguageStrings.PaymentTypeInStoreNotPaid);
                case "In Store Paid Cash":
                    return (LanguageStrings.PaymentTypeInStorePaidCash);
                case "In Store Paid Card":
                    return (LanguageStrings.PaymentTypeInStorePaidCard);
                case "In Store Paid Cheque":
                    return (LanguageStrings.PaymentTypeInStorePaidCheque);
                case "In Store Split Payment":
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
                    throw new Exception("Invalid Payment Type");
            }
        }

        public static string Translate(GenderType gender)
        {
            switch (gender)
            {
                case GenderType.Female:
                    return (LanguageStrings.AppGenderFemale);
                case GenderType.Male:
                    return (LanguageStrings.AppGenderMale);
                case GenderType.Neutral:
                    return (LanguageStrings.AppGenderNeutral);
                case GenderType.Other:
                    return (LanguageStrings.AppGenderOther);
                case GenderType.TransGender:
                    return (LanguageStrings.AppGenderTransgender);
                default:
                    throw new Exception("Invalid Gender");
            }
        }

        public static string Translate(PayPeriod period)
        {
            switch (period)
            {
                case PayPeriod.Fortnightly:
                    return (LanguageStrings.AppFortnightly);
                case PayPeriod.FourWeekly:
                    return (LanguageStrings.AppFourWeekly);
                case PayPeriod.Monthly:
                    return (LanguageStrings.AppMonthly);
                case PayPeriod.Weekly:
                    return (LanguageStrings.AppWeekly);
                default:
                    throw new Exception("Invalid PayPeriod");
            }
        }

        /// <summary>
        /// Gets translated text for process status
        /// </summary>
        /// <param name="processStatus"></param>
        /// <returns></returns>
        public static string Translate(ProcessStatus processStatus)
        {
            switch (processStatus)
            {
                case ProcessStatus.Cancelled:
                    return (LanguageStrings.ProcessStatusCancelled);
                case ProcessStatus.Completed:
                    return (LanguageStrings.ProcessStatusCompleted);
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
                case ProcessStatus.PartialDispatch:
                    return (LanguageStrings.ProcessStatusPartialDispatch);
                case ProcessStatus.OnHold:
                    return (LanguageStrings.ProcessStatusOnHold);
                case ProcessStatus.VerifyingPayment:
                    return (LanguageStrings.ProcessStatusVerifyPayment);
                default:
                    throw new Exception("Invalid Process Status");
            }
        }
    }
}
