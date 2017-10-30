using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using POS.Base.Classes;

namespace PointOfSale.Forms.Other
{
    public partial class SystemConfig : POS.Base.Forms.BaseForm
    {
        public SystemConfig()
        {
            InitializeComponent();

            int count = ConfigurationSettings.GetConfigCount();
            cmbConfigNames.Items.Clear();

            for (int i = 0; i < count; i++)
                cmbConfigNames.Items.Add(ConfigurationSettings.GetConfigName(i));

            cmbConfigNames.SelectedIndex = 0;
        }

        private void cmbConfigNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = ConfigurationSettings.GetConfigValue((string)cmbConfigNames.SelectedItem);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ConfigurationSettings.SetConfigValue((string)cmbConfigNames.SelectedItem, txtValue.Text.Trim());
        }
    }
}
