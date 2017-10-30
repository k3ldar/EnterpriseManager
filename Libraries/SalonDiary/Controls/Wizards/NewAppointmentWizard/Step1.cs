using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SalonDiary.Classes;
using Languages;
using Library.BOL.Therapists;
using Library.BOL.Appointments;
using SharedControls.WizardBase;

namespace SalonDiary.Controls.Wizards.NewAppointmentWizard
{
    public partial class Step1 : BaseWizardPage
    {
        #region Private Members

        private NewAppointmentOptionsDiary _options;

        #endregion Private Members

        #region Constructors

        public Step1(NewAppointmentOptionsDiary options)
        {
            InitializeComponent();
            _options = options;

            LoadTherapists();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectTreatments.Text = LanguageStrings.SelectTreatment;
        }

        public override bool NextClicked()
        {
            if (lstTreatments.SelectedItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.SelectAtLeast1Treatment);
                return (false);
            }

            _options.Treatments.Clear();

            for (int i = 0; i < lstTreatments.SelectedItems.Count; i++)
                _options.Treatments.Add((AppointmentTreatment)lstTreatments.SelectedItems[i]);

            return base.NextClicked();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadTherapists()
        {
            int newWidth = 0;

            lstTreatments.Items.Clear();
            AppointmentTreatments treats = AppointmentTreatments.Get();

            foreach (AppointmentTreatment treat in treats)
            {
                if (treat.IsActive && !treat.RequireFollowOn)
                {
                    lstTreatments.Items.Add(treat);

                    Size size = Shared.Utilities.MeasureText(treat.Name, lstTreatments.Font);

                    if (size.Width > newWidth)
                        newWidth = size.Width + 10;
                }
            }

            lstTreatments.ColumnWidth = newWidth;
        }

        private void lstTreatments_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentTreatment treat = (AppointmentTreatment)e.ListItem;
            e.Value = treat.Name;
        }

        private void lstTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTreatments.SelectedItems.Count > 3)
            {
                lstTreatments.SetSelected(lstTreatments.SelectedIndices[0], false);
            }
        }

        #endregion Private Methods
    }
}
