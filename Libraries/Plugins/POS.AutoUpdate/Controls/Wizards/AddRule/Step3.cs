using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.DatabaseUpdates;
using POS.AutoUpdate.Classes;
using Shared;

namespace POS.AutoUpdate.Controls.Wizards.AddRule
{
    public partial class Step3 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private CreateAutoRuleSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step3(CreateAutoRuleSettings settings)
        {
            _settings = settings;
            _settings.OnRuleChanged += _settings_OnRuleChanged;
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.AppAutoRuleNewValues;
        }

        public override bool NextClicked()
        {
            foreach (UpdateColumn col in _settings.Rule.UpdateColumns)
            {
                SharedControls.Controls.ColumnValue colValue = GetColumnValue(col.FriendlyName);
                col.Value = colValue.ColValue;
            }

            return (base.NextClicked());
        }

        public override void PageShown()
        {
        }

        #endregion Overridden Methods

        #region Private Methods

        private SharedControls.Controls.ColumnValue GetColumnValue(string friendlyName)
        {
            foreach (SharedControls.Controls.ColumnValue item in flowLayoutPanel.Controls)
            {
                if (item.ColumnName == friendlyName)
                    return (item);
            }

            return (null);
        }

        private void _settings_OnRuleChanged(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            SharedControls.Controls.ColumnValue newColValue = null;

            foreach (UpdateColumn col in _settings.Rule.UpdateColumns)
            {
                switch (col.ColumnType)
                {
                    case ColumnType.Decimal:
                        decimal minValue = 0;
                        decimal maxValue = 100;
                        col.GetMinMax(ref minValue, ref maxValue);
                        newColValue = new SharedControls.Controls.ColumnValue(col.FriendlyName, 
                            col.ColumnType, 0, minValue, maxValue);
                        flowLayoutPanel.Controls.Add(newColValue);
                        break;
                    case ColumnType.Boolean:
                        newColValue = new SharedControls.Controls.ColumnValue(col.FriendlyName, 
                            col.ColumnType, col.FriendlyName);
                        flowLayoutPanel.Controls.Add(newColValue);
                        break;
                }
            }
        }


        #endregion Private Methods
    }
}
