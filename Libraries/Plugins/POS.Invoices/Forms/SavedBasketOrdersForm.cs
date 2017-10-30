using System;
using System.Windows.Forms;

using Languages;

using Library.BOL.Basket;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Invoices.Forms
{
    public partial class SavedBasketOrdersForm : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public SavedBasketOrdersForm()
        {
            InitializeComponent();

            LoadSavedOrders();

            btnOpenSelected.Enabled = false;
            btnDeleteSelected.Enabled = false;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceOrderOpenSaved;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppOrderCreateSelect;

            lblSavedOrders.Text = LanguageStrings.AppOrderSavedOrdersDescription;
            btnDeleteSelected.Text = LanguageStrings.AppMenuButtonDeleteSelected; 
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOpenSelected.Text = LanguageStrings.AppMenuButtonOpen;

            colCustomer.Text = LanguageStrings.AppCustomer;
            colStaff.Text = LanguageStrings.Staff;
            colDate.Text = LanguageStrings.Date;
        }

        #endregion Overridden Methods

        #region Properties

        public Int64 BasketID
        {
            get
            {
                SavedBasket basket = (SavedBasket)lstSavedOrders.SelectedItems[0].Tag;
                return (basket.BasketID);
            }
        }


        public Int64 UserID
        {
            get
            {
                SavedBasket basket = (SavedBasket)lstSavedOrders.SelectedItems[0].Tag;
                return (basket.UserID);
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadSavedOrders()
        {
            lstSavedOrders.Items.Clear();

            SavedBaskets saved = SavedBaskets.Get();

            foreach (SavedBasket basket in saved)
            {
                // 3 parts, user, staff and then date
                string[] parts = basket.Description.Split(';');

                if (parts.Length > 0)
                {
                    string[] pairs = parts[0].Split(':');
                    ListViewItem item = new ListViewItem(pairs[1].Trim());
                    item.Tag = basket;
                    item.SubItems.Add(String.Empty);
                    item.SubItems.Add(String.Empty);

                    if (parts.Length > 1)
                    {
                        pairs = parts[1].Split(':');
                        item.SubItems[1].Text = pairs[1].Trim();
                    }

                    if (parts.Length >= 2)
                    {
                        item.SubItems[2].Text = parts[2].Substring(6).Trim();
                    }

                    lstSavedOrders.Items.Add(item);
                }
            }
        }

        private void btnOpenSelected_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void lstSavedOrders_DoubleClick(object sender, EventArgs e)
        {
            if (lstSavedOrders.SelectedItems.Count > 0)
                DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void lstSavedOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpenSelected.Enabled = lstSavedOrders.SelectedItems.Count > 0;
            btnDeleteSelected.Enabled = lstSavedOrders.SelectedItems.Count > 0;
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (lstSavedOrders.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppOrderSavedDeleteSelectedPrompt))
            {
                SavedBasket basket = (SavedBasket)lstSavedOrders.SelectedItems[0].Tag;
                SavedBaskets.Delete(basket);
                lstSavedOrders.Items.Remove(lstSavedOrders.SelectedItems[0]);
            }
        }

        #endregion Private Methods
    }
}
