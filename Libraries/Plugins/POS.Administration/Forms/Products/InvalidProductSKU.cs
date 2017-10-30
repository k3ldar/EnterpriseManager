using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Statistics;

namespace POS.Administration.Forms.Products
{
    public partial class InvalidProductSKU : POS.Base.Forms.BaseForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public InvalidProductSKU()
        {
            InitializeComponent();
        }

        public InvalidProductSKU(string title, string prompt, SimpleStatistics statistics)
            : this()
        {
            this.Text = title;
            lblPrompt.Text = prompt;
            
            foreach (SimpleStatistic stat in statistics)
            {
                ListViewItem item = new ListViewItem(stat.Description);
                item.Tag = stat;
                item.SubItems.Add(stat.Count.ToString());
                lvSKUData.Items.Add(item);
            }
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.ProductInvalidSKU;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            columnHeaderSKU.Text = LanguageStrings.AppSKU;
            columnHeaderCount.Text = LanguageStrings.Count;
        }


        #endregion Overridden Methods

        #region private Methods


        #endregion Private Methods
    }
}
