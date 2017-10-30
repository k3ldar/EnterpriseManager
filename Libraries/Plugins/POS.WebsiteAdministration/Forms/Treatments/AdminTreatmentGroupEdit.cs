using System;
using System.IO;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Products;
using Library.BOL.Treatments;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Treatments
{
    public partial class AdminTreatmentGroupEdit : Base.Forms.BaseForm
    {
        #region Private Members

        private TreatmentGroup _treatGroup;

        #endregion Private Members

        #region Constructors

        public AdminTreatmentGroupEdit()
        {
            InitializeComponent();

        }

        public AdminTreatmentGroupEdit(TreatmentGroup Group)
            : this()
        {
            _treatGroup = Group;

            txtGroupName.Text = _treatGroup.Description;
            spnSortOrder.Value = _treatGroup.SortOrder;
            txtTagLine.Text = _treatGroup.TagLine;

            this.Text = LanguageStrings.AppProductGroupTreatmentEdit;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            tabControl1_SelectedIndexChanged(this, e);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnDelete.Text = LanguageStrings.AppMenuButtonDelete;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;

            lblGroupName.Text = LanguageStrings.AppProductGroupName;
            lblSortOrder.Text = LanguageStrings.AppSortOrder;
            lblTagLine.Text = LanguageStrings.AppProductGroupTagLine;
        }

        protected override void SetPermissions()
        {
            btnSave.Enabled = AppController.ActiveUser.MemberLevel > Library.MemberLevel.AdminReadOnly;
            btnDelete.Enabled = AppController.ActiveUser.MemberLevel >= Library.MemberLevel.AdminUpdateDelete;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _treatGroup.Description = txtGroupName.Text;
                _treatGroup.SortOrder = (int)spnSortOrder.Value;
                _treatGroup.TagLine = txtTagLine.Text;
                //_Group.ShowOnWebsite = cbShowOnWebsite.Checked;
                //_Group.URL = txtURL.Text;
                _treatGroup.Save(AppController.ActiveUser);

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception error)
            {
                string msg = LanguageStrings.AppErrorUnexpectedDescription;

                if (error.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                    msg = LanguageStrings.AppErrorProductGroupConflict;

                ShowError(LanguageStrings.AppProductGroupSave, msg);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ShowHardConfirm(LanguageStrings.AppTreatmentGroupDelete,
                LanguageStrings.AppTreatmentGroupDeletePrompt))
            {
                if (_treatGroup.Treatments.Count > 0)
                    ShowInformation(LanguageStrings.AppTreatmentGroupDelete, 
                        LanguageStrings.AppTreatmentGroupDeleteContainsTreatments);
                else
                {
                    _treatGroup.Delete(AppController.ActiveUser);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
            }
        }

        private void cmbGroupType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroupType item = (ProductGroupType)e.ListItem;
            e.Value = item.Description;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageGeneral)
                HelpTopic = POS.Base.Classes.HelpTopics.OnlineTreatmetGroupEditGeneral;
        }

        #endregion Private Methods
    }
}
