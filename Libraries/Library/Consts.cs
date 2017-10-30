using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public sealed class Consts
    {
        public const int INVOICE_VERSION_VAT_ADD = 8;
        public const int INVOICE_VERSION_VAT_ADD_OPTIONS = 9;

        public const string ERROR_NOT_STAFF = "User is not a member of staff";
        public const string ERROR_INVALID_PERMISSIONS = "User does not have the correct permissions";


        public const string STAFF_LEAVE_NOTES_CANCELLED = "\r\n\r\nCancelled by {0} on {1}";
        public const string STAFF_LEAVE_NOTES_DENIED = "\r\n\r\nDenied by {0} on {1}\r\n\r\nReason: {2}";


        public const string APPT_STATUS_DELETED = "Deleted";
        public const string APPT_STATUS_SELECTED = "Selected Appointment";
        public const string APPT_STATUS_REQUESTED = "Requested";
        public const string APPT_STATUS_CONFIRMED = "Confirmed";
        public const string APPT_STATUS_ARRIVED = "Arrived";
        public const string APPT_STATUS_CANCELLED_BY_USER = "Cancelled by User";
        public const string APPT_STATUS_CANCELLED_BY_STAFF = "Cancelled by Staff";
        public const string APPT_STATUS_NO_SHOW = "No Show";
        public const string APPT_STATUS_COMPLETED = "Completed";

        public const int APPT_STATUS_ID_REQUESTED = 1;
        public const int APPT_STATUS_ID_CONFIRMED = 2;
        public const int APPT_STATUS_ID_ARRIVED = 5;
        public const int APPT_STATUS_ID_CANCELLED_BY_USER = 3;
        public const int APPT_STATUS_ID_CANCELLED_BY_STAFF = 4;
        public const int APPT_STATUS_ID_NO_SHOW = 6;
        public const int APPT_STATUS_ID_COMPLETED = 7;
        public const int APPT_STATUS_ID_DELETED = 99;
        public const int APPT_STATUS_ID_SELECTED = 1000;


        // cache names
        public const string CACHE_NAME_PAYMENT_STATUS = "1All Payment Statuses";
        public const string CACHE_NAME_PRODUCT_COST_TYPES = "2All Product Cost Types";
        public const string CACHE_NAME_PRODUCT_GROUPS = "3All Product Groups - {0}";
        public const string CACHE_NAME_PRODUCT_GROUP_TYPES = "4All Product Group Types";
        public const string CACHE_NAME_PRODUCT_CATEGORIES = "5All User Product Categories - {0} {1}";
        public const string CACHE_NAME_CAROUSEL = "6All Carousel Items - Currency {0} Language {1}";
        public const string CACHE_NAME_PRODUCT_TYPES = "7All Product Types";
        public const string CACHE_NAME_PRODUCT_GROUPS_GET = "8ProductGroupsGet {0} - {1}";
        public const string CACHE_NAME_PRODUCTS_DISCOUNTED = "9Discounted Products";
        public const string CACHE_NAME_PRODUCTS_COUNT = "10Product Counts";
        public const string CACHE_NAME_PRODUCTS_COUNT_OFFERS = "11Product Count Offers";
        public const string CACHE_NAME_PRODUCTS_COUNT_BY_PRODUCT_GROUP = "12Product Count By Product Group {0}";
        public const string CACHE_NAME_PRODUCT_FEATURED = "13Featured Product";
        public const string CACHE_NAME_PRODUCTS_CAROUSEL = "14Carousel Products";
        public const string CACHE_NAME_PRODUCTS_CELEBRITY = "15Celebrity Products {0}";
        public const string CACHE_NAME_PRODUCTS_GET_INDIVIDUAL = "16Products Get Individual {0}";
        public const string CACHE_NAME_PRODUCTS_GET_GROUPANDPRODUCT = "17Product By Group {0} {1} {2} {3}";
        public const string CACHE_NAME_PRODUCTS_GET_PRODUCT_AND_COSTS = "18Products By Product Type With Costs {0} {1} {2} {3}";
        public const string CACHE_NAME_PRODUCTS_GET_PRODUCT_BY_TYPE = "19Products By Product Type No Costs {0} {1} {2}";
        public const string CACHE_NAME_PRODUCTS_GET_BY_SKU = "20Products By SKU {0}";
        public const string CACHE_NAME_PRODUCTS_PAGE_OFFERS = "21Products on Offer By Page {0} {1}";

        public const string CACHE_NAME_PRODUCT_COSTS_GIFT_WRAP = "22Product Cost Gift Wrap";
        public const string CACHE_NAME_PRODUCT_COSTS_MEMBER_LEVEL = "23Product Cost By Member Level {0} {1}";
        public const string CACHE_NAME_PRODUCT_COSTS_ALL = "24Product Cost All {1}";
        public const string CACHE_NAME_PRODUCT_COSTS_GET_OFFERS = "25Product Costs Get Free Offers ";
        public const string CACHE_NAME_PRODUCT_COSTS_GET_ID = "26Product Costs Get By ID {0}";
        public const string CACHE_NAME_PRODUCT_COSTS_GET_ID_INT = "27 Product Costs Get By ID {0}";
        public const string CACHE_NAME_PRODUCT_COSTS_GET_ID_MEMBER = "28 Product Costs Get By ID Member {0} {1}";
        public const string CACHE_NAME_PRODUCT_COSTS_BY_SKU = "29 Product Cost By SKU {0}";


        public const string CACHE_NAME_SELECTABLE_LANGUAGE = "Language Select";
        public const string CACHE_NAME_SELECTABLE_CURRENCY = "Selected Currencies ";

        public const string CACHE_NAME_CUSTOM_PAGE_COUNTRY_TYPE = "30 Custom Page {0} {1} {2}";
        public const string CACHE_NAME_CUSTOM_PAGE_ALL_BY_WEBSITE = "31 Custom Page {0}";
        public const string CACHE_NAME_CUSTOM_PAGE_GET_TITLE = "32 Custom Page Title {0} {1} {2}";

        public const string CACHE_NAME_ALL_MODULES = "All Modules";
        public const string CACHE_NAME_ALL_CLASSES = "All Module Classes";
        public const string CACHE_NAME_CLASS = "Module Class {0}";
        public const string CACHE_NAME_CLASS_NAME = "Module Class Name {0}";
        public const string CACHE_NAME_MODULE_CLASSES = "Module Classes {0}";
        public const string CACHE_NAME_CLASS_MEMBERS = "Class Members {0}";
        public const string CACHE_NAME_CLASS_MEMBER_PARAMS = "Class Member Parameters {0}";

        public const string CACHE_NAME_BACKUP_FILE = "Backup File {0} {1} {2} {3}";
    }
}
