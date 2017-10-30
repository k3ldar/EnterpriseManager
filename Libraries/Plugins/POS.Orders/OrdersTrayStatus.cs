using System;
using Languages;

using Library;
using Library.BOL.Invoices;
using Library.BOL.Statistics;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Orders
{

    public class OrdersTrayStatus : TrayNotification
    {
        #region Constructors

        public OrdersTrayStatus(BasePlugin parent)
            : base(parent)
        {
            this.UpdateFrequency = new TimeSpan(0, 0, 15);
            this.CanBlink = false;
            this.Position = 0;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            string Result = String.Empty;
            try
            {
                SimpleStatistics stats = Invoices.InvoicesGetStats(AppController.ActiveUser, -1, -1, false, ProcessStatuses.Processing);

                int total = 0;

                foreach (SimpleStatistic stat in stats)
                    total += stat.Count;

                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppOrdersOutstanding;
                Result = String.Format(Result, total);
            }
            catch (Exception err)
            {
                Result = LanguageStrings.AppErrorShowingStats +
                    StringConstants.SYMBOL_HYPHON_SPACES + err.Message;
            }

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayInvoicesOrders);
        }

        public override void DoubleClick()
        {

        }

        public override bool CanLoad()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override void Load()
        {

        }

        #endregion Overridden Methods
    }
}
