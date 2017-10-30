using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Library;
using Library.Utils;
using Library.BOL.Invoices;
using Library.BOL.Users;

using Languages;

using Reports.Accounts;
using POS.Base.Classes;
using POS.Base.Controls;
using POS.Base.Forms;
using POS.Base.Labels;

namespace POS.Invoices.Forms
{
    public partial class ChangeSalesPerson : BaseForm
    {
        #region Constructors

        public ChangeSalesPerson()
        {
            InitializeComponent();
        }


        public ChangeSalesPerson(Invoice invoice)
            : this()
        {
            CurrentInvoice = invoice;

            LoadInvoiceItems();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceChangeSalesPerson;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppChangeSalesPerson;
            btnClose.Text = LanguageStrings.AppMenuButtonClose;
            lblDescription.Text = LanguageStrings.AppChangeSalesPersonDesc;
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Current Invoice being looked at
        /// </summary>
        public Invoice CurrentInvoice { get; private set; }

        #endregion Properties

        #region Private Methods

        private void LoadInvoiceItems()
        {
            gridInvoiceItems.DataSource = CurrentInvoice.InvoiceItems;

            gridInvoiceItems.Columns[1].Width = 300;

            gridInvoiceItems.Columns[0].Visible = false;
            gridInvoiceItems.Columns[2].Visible = false;
            gridInvoiceItems.Columns[3].Visible = false;
            gridInvoiceItems.Columns[4].Visible = false;
            gridInvoiceItems.Columns[5].Visible = false;
            gridInvoiceItems.Columns[6].Visible = false;
            gridInvoiceItems.Columns[7].Visible = false;
            gridInvoiceItems.Columns[8].Visible = false;
            gridInvoiceItems.Columns[9].Visible = false;
            gridInvoiceItems.Columns[10].Visible = false;
            gridInvoiceItems.Columns[11].Visible = false;
            gridInvoiceItems.Columns[12].Visible = false;
            gridInvoiceItems.Columns[13].Visible = false;
            gridInvoiceItems.Columns[14].Visible = false;
            gridInvoiceItems.Columns[15].Visible = false;
            gridInvoiceItems.Columns[16].Visible = false;
            gridInvoiceItems.Columns[17].Visible = false;
            gridInvoiceItems.Columns[18].Visible = false;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            column.HeaderText = gridInvoiceItems.Columns[10].HeaderText;
            column.DropDownWidth = 200;
            column.Width = 200;
            column.MaxDropDownItems = 8;
            column.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            column.FlatStyle = FlatStyle.Popup;
            column.DisplayStyleForCurrentCellOnly = true;

            LoadStaffMembers(column);
            gridInvoiceItems.Columns.Add(column);
        }

        private void LoadStaffMembers(DataGridViewComboBoxColumn column)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(Int64));
            table.Columns.Add("Name", typeof(string));

            Library.BOL.Users.Users staff = Library.BOL.Users.User.StaffMembers(false);

            foreach (User staffMember in staff)
            {
                DataRow newRow = table.Rows.Add();
                newRow["ID"] = staffMember.ID;
                newRow["Name"] = staffMember.UserName;
            }


            foreach (InvoiceItem item in CurrentInvoice.InvoiceItems)
            {
                foreach (User member in staff)
                    if (item.StaffMemberID == member.ID)
                        continue;

                DataRow newMissingRow = table.Rows.Add();
                newMissingRow["ID"] = item.StaffMember == null ? -1 : item.StaffMember.ID;
                newMissingRow["Name"] = item.StaffMember == null ? String.Empty : item.StaffMember.UserName;
            }

            column.DataSource = table;
            column.DisplayMember = "Name";
            column.ValueMember = "ID";
            column.DataPropertyName = "StaffMemberID";
        }

        private void gridInvoiceItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gridInvoiceItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                gridInvoiceItems.BeginEdit(false);
                ComboBox comboBox = (ComboBox)gridInvoiceItems.EditingControl;
                //comboBox.DroppedDown = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        #endregion Private Methods
    }
}
