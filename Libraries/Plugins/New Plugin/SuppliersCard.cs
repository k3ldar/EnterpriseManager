using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


using SharedControls.Forms;
using Languages;
using Library;
using Library.BOL.Products;
using Library.BOL.Salons;
using Library.BOL.Statistics;
using POS.Base.Classes;
using POS.Base.Plugins;
using Library.BOL.Users;

namespace POS.Suppliers
{
    public class SuppliersCard : HomeCard
    {
        #region Private Members

        #endregion Private Members

        public SuppliersCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // all users can see currency
            return (true);
        }

        public override Image ButtonImage()
        {
            return (null);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.CurrencyWatch);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            return (null);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppSuppliers);
        }

        public override int StatusPanelCount()
        {
            return (0);
        }

        public override string StatusPanelText(int index)
        {
            return (String.Empty);
        }

        public override string StatusPanelHint(int index)
        {
            return (String.Empty);
        }

        public override int SortOrder()
        {
            return (350);
        }

        public override bool OwnerDrawn()
        {
            return (true);
        }

        #region Private Members


        #endregion Private Members
    }
}
