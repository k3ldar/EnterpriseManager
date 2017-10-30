﻿using System;
using Languages;

using Library;

using POS.Base.Classes;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{
    public class InvoicePartiallyDispatchedTrayStatus : TrayNotification
    {
        #region Constructors

        public InvoicePartiallyDispatchedTrayStatus(BasePlugin parent)
            : base(parent)
        {
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
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
                int _countInvoices = AppController.Administration.StatsInvoices(InvoiceStatistics.PartiallyDispatched);
                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppInvoicesToProcessPartiallyDispatched1;

                if (_countInvoices == 1)
                    Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppInvoiceToProcessPartiallyDispatched;

                Result = String.Format(Result, _countInvoices);
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
            return (LanguageStrings.AppPluginTrayInvoicesPartiallyDispatched);
        }

        public override void DoubleClick()
        {
            ((InvoicesPluginModule)Parent).ShowInvoiceManager();
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