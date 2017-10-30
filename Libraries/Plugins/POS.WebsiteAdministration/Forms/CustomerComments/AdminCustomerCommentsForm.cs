using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.Helpdesk;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.CustomerComments
{
    public partial class AdminCustomerCommentsForm : POS.Base.Controls.BaseOptionsControl
    {
        #region Private Members

        private CustomerComment _selectedComment;
        private ToolStripButton btnViewUser;

        #endregion Private Members

        #region Constructors

        public AdminCustomerCommentsForm()
        {
            InitializeComponent();

            AllowAddNew = false;

            if (!AppController.ApplicationRunning)
                return;

            AddToolbarSeperator();
            btnViewUser = new ToolStripButton();
            btnViewUser.Image = Base.Icons.UserIcon();
            btnViewUser.ToolTipText = LanguageStrings.AppHintViewUser;
            btnViewUser.Click += BtnViewUser_Click;
            AddToobarButton(btnViewUser);

            LoadComments();
            UpdateUI(null, false);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblAllComments.Text = LanguageStrings.AppCustomerCommentsAllComments;
            lblComments.Text = LanguageStrings.AppComments;
            lblName.Text = LanguageStrings.AppName;

            cbShowOnWebsite.Text = LanguageStrings.AppShowOnWebsite;

            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderShowOnWebsite.Text = LanguageStrings.AppShowOnWebsite;
        }

        protected override void OnSaveClicked()
        {
            _selectedComment.Comments = txtComments.Text;
            _selectedComment.UserName = txtName.Text;
            _selectedComment.ShowOnWeb = cbShowOnWebsite.Checked;
            _selectedComment.Save();
            LoadComments();
        }

        protected override void OnDeleteClicked()
        {
            _selectedComment.Delete();
            lvComments.Items.Remove(lvComments.SelectedItems[0]);

            LoadComments();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void BtnViewUser_Click(object sender, EventArgs e)
        {
            Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(_selectedComment.UserID);

            if (user != null)
            {
                PluginManager.RaiseEvent(new POS.Base.Plugins.NotificationEventArgs(user));
            }
            else
            {
                ShowInformation(LanguageStrings.AppCustomerFind, LanguageStrings.AppCustomerNotFound);
            }
        }

        private void LoadComments()
        {
            lvComments.Items.Clear();
            Library.BOL.Helpdesk.CustomerComments comments = Library.BOL.Helpdesk.CustomerComments.GetAll();

            foreach (CustomerComment comment in comments)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = comment.UserName;
                lv.SubItems.Add(comment.ShowOnWeb ? LanguageStrings.AppYes : LanguageStrings.AppNo);
                lv.SubItems.Add(comment.ID.ToString());
                lvComments.Items.Add(lv);
            }
        }

        private void lvComments_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem lv = e.Item;

            UpdateUI(lv, e.IsSelected);

            if (e.IsSelected)
            {
                _selectedComment = Library.BOL.Helpdesk.CustomerComments.Get(Shared.Utilities.StrToIntDef(lv.SubItems[2].Text, -1));
                txtName.Text = _selectedComment.UserName;
                txtComments.Text = _selectedComment.Comments;
                cbShowOnWebsite.Checked = _selectedComment.ShowOnWeb;
            }
            else
                _selectedComment = null;

        }

        private void UpdateUI(ListViewItem lv, bool IsSelected)
        {
            bool enabled = lv != null && IsSelected;

            if (!enabled)
            {
                cbShowOnWebsite.Checked = false;
                txtComments.Text = StringConstants.SYMBOL_EMPTY_STRING;
                txtName.Text = StringConstants.SYMBOL_EMPTY_STRING;
            }

            txtComments.Enabled = enabled;
            txtName.Enabled = enabled;
            cbShowOnWebsite.Enabled = enabled;
            btnViewUser.Enabled = enabled;

            AllowDelete = enabled;
            IsEditing = enabled;
            UpdateUI(IsSelected);
        }

        #endregion Private Methods
    }
}
