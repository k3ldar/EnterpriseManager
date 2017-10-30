using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.Utils;
using Library.BOL.Salons;

namespace POS.WebsiteAdministration.Forms.Salons
{
    public partial class AdminSelectSalon : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public AdminSelectSalon()
        {
            InitializeComponent();

            LoadSalons();
        }

        #endregion Constructors

        #region Properties

        public Salon SelectedSalon
        {
            get
            {
                return ((Salon)lstSalons.SelectedItem);
            }

            set
            {
                lstSalons.SelectedIndex = -1;

                foreach (Salon salon in lstSalons.Items)
                {
                    if (salon.ID == value.ID)
                    {
                        lstSalons.SelectedIndex = lstSalons.Items.IndexOf(salon);
                        return;
                    }
                }
            }
        }

        #endregion Properties

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebSalonSelect;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSalonSelect;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadSalons()
        {
            Library.BOL.Salons.Salons salons = Library.BOL.Salons.Salons.Get(1, 10000);

            foreach (Salon salon in salons)
            {
                lstSalons.Items.Add(salon);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstSalons.SelectedIndex == -1)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppSalonSelectError);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lstSalons_Format(object sender, ListControlConvertEventArgs e)
        {
            Salon salon = (Salon)e.ListItem;
            e.Value = salon.Name;
        }

        private void lstSalons_DoubleClick(object sender, EventArgs e)
        {
            if (lstSalons.SelectedIndex > -1)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion Private Methods
    }
}
