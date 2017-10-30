using System;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Users;

namespace POS.Base.Forms
{
    public partial class SelectUser : BaseForm
    {
        #region Properties

        public User SelectedUser
        {
            get
            {
                User Result = null;

                if (rbNoUser.Checked)
                {
                    Result = User.SystemUser();
                }
                else
                {
                    foreach (ListViewItem itm in lvUsers.SelectedItems)
                    {
                        if (itm.Selected)
                        {
                            string id = itm.SubItems[6].Text;
                            Result = User.UserGet(Convert.ToInt64(id));
                            break;
                        }
                    }
                }

                return (Result);
            }
        }

        #endregion Properties

        #region Constructors

        public SelectUser(bool allowWithHeld)
            : this()
        {
            if (!allowWithHeld)
            {
                rbFindUser.Checked = true;
                rbNoUser.Enabled = false;
            }
        }

        public SelectUser()
        {
            InitializeComponent();
        }

        public SelectUser(User user, bool allowWithHeld)
            : this(allowWithHeld)
        {
            if (user != null)
            {
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmailAddress.Text = user.Email;
                DoSearch();

                if (lvUsers.Items.Count == 1)
                    lvUsers.Items[0].Selected = true;
            }
        }

        #endregion Constructors

        #region Public Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnCreateUser.Text = LanguageStrings.AppMenuButtonCreateUser;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
            btnSearch.Text = LanguageStrings.AppMenuButtonSearch;

            rbFindUser.Text = LanguageStrings.AppUserFind;
            rbNoUser.Text = LanguageStrings.AppUserWithheld;

            lblEmail.Text = LanguageStrings.AppUserEmail;
            lblFirstName.Text = LanguageStrings.AppUserFirstName;
            lblLastName.Text = LanguageStrings.AppUserLastName;

            columnAddress1.Text = LanguageStrings.AddressLine1;
            columnDateOfBirth.Text = LanguageStrings.AppUserDateOfBirth;
            columnEmail.Text = LanguageStrings.AppUserEmail;
            columnTelephone.Text = LanguageStrings.AppUserTelephone;
            columnName.Text = LanguageStrings.AppUserName;
        }

        #endregion Public Methods

        #region Private Methods

        private void rbNoUser_CheckedChanged(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void rbFindUser_CheckedChanged(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void DoRefresh()
        {
            btnCreateUser.Enabled = rbFindUser.Checked;
            lvUsers.Enabled = rbFindUser.Checked;
            txtEmailAddress.Enabled = rbFindUser.Checked;
            txtFirstName.Enabled = rbFindUser.Checked;
            txtLastName.Enabled = rbFindUser.Checked;
            btnSearch.Enabled = rbFindUser.Checked;
        }

        private void SelectUser_Load(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DoSearch();
                AcceptButton = btnOK;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void DoSearch()
        {
            txtFirstName.Text = txtFirstName.Text.ToLower();
            txtLastName.Text = txtLastName.Text.ToLower();
            txtEmailAddress.Text = txtEmailAddress.Text.ToLower();

            lvUsers.Items.Clear();
            Users users = User.UserSearch(txtFirstName.Text, txtLastName.Text, txtEmailAddress.Text, String.Empty, 100);

            int i = 0;

            foreach (User user in users)
            {
                if (user.FirstName.ToLower().Contains(txtFirstName.Text) &&
                    user.LastName.ToLower().Contains(txtLastName.Text) &&
                    user.Email.ToLower().Contains(txtEmailAddress.Text) &&
                    user.MemberLevel != MemberLevel.System)
                {
                    ListViewItem itm = new ListViewItem(user.UserName);
                    itm.SubItems.Add(user.Email);
                    itm.SubItems.Add(user.Telephone);
                    itm.SubItems.Add(user.BirthDate.Year == 1 ? String.Empty : user.BirthDate.ToShortDateString());
                    itm.SubItems.Add(user.AddressLine1);
                    itm.SubItems.Add(user.PostCode);
                    itm.SubItems.Add(user.ID.ToString());
                    lvUsers.Items.Add(itm);

                    i++;

                    if (i > 100)
                        break;
                }
            }

            if (lvUsers.Items.Count > 0)
                this.AcceptButton = btnOK;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser newuser = new CreateUser();
            try
            {
                if (newuser.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    lvUsers.Items.Clear();
                    User user = newuser.SelectedUser;

                    ListViewItem itm = new ListViewItem(user.UserName);
                    itm.SubItems.Add(user.Email);
                    itm.SubItems.Add(user.Telephone);
                    itm.SubItems.Add(user.BirthDate.Year == 1 ? String.Empty : user.BirthDate.ToShortDateString());
                    itm.SubItems.Add(user.AddressLine1);
                    itm.SubItems.Add(user.PostCode);
                    itm.SubItems.Add(user.ID.ToString());
                    lvUsers.Items.Add(itm);
                    itm.Selected = true;
                    lvUsers.Items[0].Selected = true;
                }
            }
            finally
            {
                newuser.Dispose();
                newuser = null;
            }
        }

        private void lvUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
                DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedUser != null)
                DialogResult = DialogResult.OK;
        }

        #endregion Private Methods

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.Customers;
        }

        #endregion Overridden Methods
    }
}
