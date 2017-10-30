using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Appointments;

using POS.Base.Classes;

namespace POS.Till.Controls
{
    public partial class BasketTreatmentButton : SharedControls.BaseControl
    {
        #region Private Members

        private AppointmentTreatment _treatment;

        #endregion Private Members

        #region Constructors

        public BasketTreatmentButton()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public AppointmentTreatment Treatment
        {
            get
            {
                return (_treatment);
            }

            set
            {
                _treatment = value;

                LoadTreatmentDetails();
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadTreatmentDetails()
        {
            btnAddTreatment.Text = _treatment.Name;

            if (!AppController.LocalSettings.TillShowButtonImages)
                return;

            string imageFile = AppController.POSFolder(ImageTypes.Treatments) + 
                _treatment.Image.Replace(StringConstants.IMAGE_SIZE_DEFAULT, StringConstants.IMAGE_SIZE_BASKET);

            if (File.Exists(imageFile))
            {
                Image img = Image.FromFile(imageFile);
                btnAddTreatment.Image = img;
            }
        }

        private void btnAddTreatment_Click(object sender, EventArgs e)
        {
            if (AddTreatmentToBasket != null)
                AddTreatmentToBasket(this, EventArgs.Empty);
        }

        #endregion Private Methods

        #region Events

        /// <summary>
        /// Event for when a product needs to be added to the basket
        /// </summary>
        public event EventHandler AddTreatmentToBasket;

        #endregion Events
    }
}