using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.Products;
using POS.Base.Classes;

namespace POS.Administration.Forms.Products
{
    public partial class NewProductGroupForm : Base.Forms.BaseForm
    {
        #region Constructors

        public NewProductGroupForm()
        {
            InitializeComponent();

            //set NewProduct to null
            NewProductGroup = null;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = Base.Classes.HelpTopics.ProductGroupNew;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppProductGroupCreateNew;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Newly created product
        /// </summary>
        public ProductGroup NewProductGroup { private set; get; }

        #endregion Properties

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            NewProductGroup = createProductControl1.Create(AppController.Administration);

            if (NewProductGroup != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        #endregion Private Methods
    }
}