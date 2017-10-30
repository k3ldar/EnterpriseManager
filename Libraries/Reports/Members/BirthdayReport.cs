using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SharedControls.Forms;

using Library.BOL.Users;

namespace Reports.Members
{
    public partial class frmBirthdayReport : BaseForm
    {
        public frmBirthdayReport()
        {
            InitializeComponent();

            rbCurrentMonth.Text = DateTime.Now.ToString("MMMM");
            rbNextMonth.Text = DateTime.Now.AddMonths(1).ToString("MMMM");
        }

        #region Public Static Methods

        /// <summary>
        /// Launches the view stock reports form
        /// </summary>
        public static void ViewConfirmList(User activeUser)
        {
            try
            {
                frmBirthdayReport reports = new frmBirthdayReport();
                try
                {
                    //reports._activeUser = activeUser;
                    reports.ShowDialog();
                }
                finally
                {
                    reports.Dispose();
                    reports = null;
                }
            }
            catch (Exception err)
            {
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                throw;
            }
        }

        #endregion Public Static Methods

        #region Overridden Methods

        #endregion Overridden Methods

        #region Private Methods

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lstCustomers.BeginUpdate();
            try
            {
                lstCustomers.Items.Clear();
                Users allBirthdays = User.GetBirthdayList(txtCurrentPostCode.Text, rbNextMonth.Checked ? DateTime.Now.AddMonths(1).Month : DateTime.Now.Month, (int)udRadius.Value);

                foreach (User birthdayUser in allBirthdays)
                {
                    ListViewItem item = lstCustomers.Items.Add(birthdayUser.UserName);
                    item.SubItems.Add(birthdayUser.Telephone);
                    item.SubItems.Add(birthdayUser.AddressLine1);
                    item.SubItems.Add(birthdayUser.City);
                    item.SubItems.Add(birthdayUser.County);
                    item.SubItems.Add(birthdayUser.PostCode);
                    item.Tag = birthdayUser;
                    item.Checked = true;
                }
            }
            finally
            {
                lstCustomers.EndUpdate();
            }

            lblCount.Text = String.Format("Total users {0}; Selected users {1}", lstCustomers.Items.Count, lstCustomers.CheckedItems.Count);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Users confirmed = new Users();

            foreach (ListViewItem item in lstCustomers.CheckedItems)
            {
                confirmed.Add((User)item.Tag);
            }

            PDFBirthdayList.ConfirmList(confirmed);
        }

        private void lstCustomers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lblCount.Text = String.Format("Total users {0}; Selected users {1}", lstCustomers.Items.Count, lstCustomers.CheckedItems.Count);
        }

        #endregion Private Methods
    }
}
