using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.Products;
using POS.Base.Classes;

namespace POS.Administration.Forms.Products
{
    public partial class NewProductForm : Base.Forms.BaseForm
    {
        #region Constructors

        public NewProductForm()
        {
            InitializeComponent();

            //set NewProduct to null
            NewProduct = null;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.ProductNew;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppProductCreateNew;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// Newly created product
        /// </summary>
        public Product NewProduct { private set; get; }

        #endregion Properties

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            NewProduct = createProductControl1.Create(AppController.Administration);

            if (NewProduct != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        #endregion Private Methods
    }
}
