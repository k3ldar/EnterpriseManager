/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BasketTreatmentButton.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.IO;
using SharedBase.BOL.Appointments;

using POS.Base.Classes;

#pragma warning disable IDE1006

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