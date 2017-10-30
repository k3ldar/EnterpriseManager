using System;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Statistics;

namespace POS.Administration.Forms.Products
{
    public partial class AdminSetTopProducts : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private WebsiteAdministration _Admin;
        private int _count = 15;
        private int _ageDays = 30;

        #endregion Private Members

        #region Constructors

        public AdminSetTopProducts(WebsiteAdministration Admin)
        {
            _Admin = Admin;

            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainDays.Image = POS.Base.Icons.DateIcon();
            toolStripMainItemCount.Image = POS.Base.Icons.CountIcon();
            toolStripMainSetTopProducts.Image = POS.Base.Icons.SearchIcon();
            toolStripMainDelete.Enabled = false;
            toolStripMainEdit.Enabled = false;
            toolStripMainAdd.Enabled = false;

            toolStripMainItemCount10.Tag = 10;
            toolStripMainItemCount15.Tag = 15;
            toolStripMainItemCount20.Tag = 20;
            toolStripMainItemCount25.Tag = 25;
            toolStripMainItemCount30.Tag = 30;

            toolStripMainDays7.Tag = 7;
            toolStripMainDays30.Tag = 30;

            RetrieveTopProducts();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            toolStripMainAdd.Text = LanguageStrings.AppMenuButtonNew;

            colHeaderSKU.Text = LanguageStrings.AppSKU;
            colHeaderName.Text = LanguageStrings.AppProductName;
            colHeaderCount.Text = LanguageStrings.AppQuantity;
            colHeaderSize.Text = LanguageStrings.AppProductSize;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;

            toolStripMainItemCount10.Text = String.Format(LanguageStrings.AppItems, 10);
            toolStripMainItemCount15.Text = String.Format(LanguageStrings.AppItems, 15);
            toolStripMainItemCount20.Text = String.Format(LanguageStrings.AppItems, 20);
            toolStripMainItemCount25.Text = String.Format(LanguageStrings.AppItems, 25);
            toolStripMainItemCount30.Text = String.Format(LanguageStrings.AppItems, 30);

            toolStripMainDays7.Text = String.Format(LanguageStrings.AppDays, 7);
            toolStripMainDays30.Text = String.Format(LanguageStrings.AppDays, 30);

        }

        #endregion Overridden Methods

        #region Private Methods

        private void toolStripMainRefresh_Click(object sender, System.EventArgs e)
        {
            RetrieveTopProducts();
        }

        private void RetrieveTopProducts()
        {
            this.Cursor = Cursors.WaitCursor;
            lvTopProducts.BeginUpdate();
            try
            {
                SimpleStatistics results = Statistics.TopProducts(_count, _ageDays);
                lvTopProducts.Items.Clear();

                foreach (SimpleStatistic stat in results)
                {
                    ListViewItem item = new ListViewItem(stat.Name1);
                    item.SubItems.Add(stat.Name2);
                    item.SubItems.Add(stat.Name3);
                    item.SubItems.Add(stat.Count.ToString());
                    lvTopProducts.Items.Add(item);
                }
            }
            finally
            {
                lvTopProducts.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void toolStripMainSetTopProducts_Click(object sender, System.EventArgs e)
        {
            if (ShowQuestion(LanguageStrings.AppSetTopProducts, LanguageStrings.AppSetTopProductsQuestion))
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Statistics.TopProductsSet(_count, _ageDays);
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void toolStripMainDays_DropDownOpening(object sender, System.EventArgs e)
        {
            toolStripMainDays7.Checked = _ageDays == 7;
            toolStripMainDays30.Checked = _ageDays == 30;
        }

        private void toolStripMainItemCount_DropDownOpening(object sender, System.EventArgs e)
        {
            toolStripMainItemCount10.Checked = _count == 10;
            toolStripMainItemCount15.Checked = _count == 15;
            toolStripMainItemCount20.Checked = _count == 20;
            toolStripMainItemCount25.Checked = _count == 25;
            toolStripMainItemCount30.Checked = _count == 30;
        }

        private void ToolStripDaysClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem selItem = (ToolStripMenuItem)sender;
            _ageDays = (int)selItem.Tag;
        }

        private void ToolStripCountClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem selItem = (ToolStripMenuItem)sender;
            _count = (int)selItem.Tag;
        }

        #endregion Private Methods
    }
}
