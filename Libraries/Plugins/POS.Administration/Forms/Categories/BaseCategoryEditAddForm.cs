using System;
using System.Globalization;

using Languages;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class BaseCategoryEditAddForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        #endregion Private Members

        #region Constructors

        public BaseCategoryEditAddForm()
        {
            InitializeComponent();
        }

        public BaseCategoryEditAddForm(CategoryType type)
            : this()
        {
            CategoryType = type;
        }

        #endregion Constructors

        #region Properties

        protected bool IsNew { get; set; }

        /// <summary>
        /// Category type
        /// </summary>
        protected CategoryType CategoryType { get; set; }

        /// <summary>
        /// description
        /// </summary>
        protected string Description
        {
            get
            {
                return (txtName.Text);
            }

            set
            {
                txtName.Text = value;
            }
        }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            btnOK.Text = LanguageStrings.ButtonOK;
            btnCancel.Text = LanguageStrings.ButtonCancel;

            lblName.Text = LanguageStrings.Name;
        }

        #endregion Overridden Methods

        #region Protected Methods

        protected virtual void btnOKClick(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = !String.IsNullOrEmpty(txtName.Text);
        }

        #endregion Protected Methods
    }
}
