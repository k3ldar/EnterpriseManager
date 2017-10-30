using System;
using System.Text;

using Languages;
using Library;

namespace Reports
{
    public static class TranslatedEnums
    {
        public static string TranslateProductReportType(ProductReportType reportType)
        {
            switch (reportType)
            {
                case ProductReportType.Top10SellingProducts:
                    return (LanguageStrings.Top10SellingProducts);
                case ProductReportType.Top20SellingProducts:
                    return (LanguageStrings.Top20SellingProducts);
                case ProductReportType.TopSellingProducts:
                    return (LanguageStrings.TopSellingProducts);
                default:
                    throw new Exception ("Invalid ProductReportType in Translation");
            }
        }
    }
}
