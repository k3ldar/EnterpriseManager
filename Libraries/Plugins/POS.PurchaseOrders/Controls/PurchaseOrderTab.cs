using System.Globalization;

using Languages;

namespace POS.PurchaseOrders.Controls
{
    public partial class PurchaseOrderTab : POS.Base.Controls.BaseOptionsControl
    {
        #region Constructors

        public PurchaseOrderTab()
        {
            InitializeComponent();

            AllowAddNew = true;
            AllowRefresh = true;
            AllowDelete = lvPurchaseOrders.SelectedItems.Count > 0;
            AllowEdit = lvPurchaseOrders.SelectedItems.Count > 0;
            UpdateUI(AllowEdit);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            colPODate.Text = LanguageStrings.Date;
            colPOID.Text = LanguageStrings.AppPurchaseOrderID;
            colPOStatus.Text = LanguageStrings.Status;
            colPOSupplier.Text = LanguageStrings.AppSupplierName;
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        protected override void OnCreateClicked()
        {
            base.OnCreateClicked();
        }

        protected override void OnEditClicked()
        {
            base.OnEditClicked();
        }

        #endregion Overridden Methods
    }
}
