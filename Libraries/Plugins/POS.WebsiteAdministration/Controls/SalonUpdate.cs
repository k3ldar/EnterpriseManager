using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library.BOL.Salons;
using Library.BOL.Websites;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Controls
{
    public partial class SalonUpdate : SharedControls.BaseControl
    {
        public SalonUpdate()
        {
            InitializeComponent();
        }


        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblContactDescription.Text = Languages.LanguageStrings.AppContact;
            lblEmailDescription.Text = Languages.LanguageStrings.AppEmail;
            lblTelephoneDescription.Text = Languages.LanguageStrings.AppTelephone;
            lblWebsiteDescription.Text = Languages.LanguageStrings.AppWebsite;
        }


        public void Refresh(Salon salon)
        {
            lblAddress.Text = salon.Address + StringConstants.SYMBOL_CRLF + salon.PostCode;
            lblContact.Text = salon.ContactName;
            lblEmail.Text = salon.Email;
            lblSalonName.Text = salon.Name;
            lblTelephone.Text = salon.Telephone;
            lblWebsite.Text = salon.URL;
            string image = FixImage(salon.Image);

            pictureBox1.ImageLocation = image;
        }

        public void ShowChanges(Salon salon)
        {
            if (lblAddress.Text != salon.Address + StringConstants.SYMBOL_CRLF + salon.PostCode)
                SetRedText(lblAddress);

            if (lblContact.Text != salon.ContactName)
                SetRedText(lblContact);

            if (lblEmail.Text != salon.Email)
                SetRedText(lblEmail);

            if (lblSalonName.Text != salon.Name)
                SetRedText(lblSalonName);

            if (lblTelephone.Text != salon.Telephone)
                SetRedText(lblTelephone);

            if (lblWebsite.Text != salon.URL)
                SetRedText(lblWebsite);

            if (pictureBox1.ImageLocation != FixImage(salon.Image))
            {
                Padding pad = new Padding(3);
                pictureBox1.Padding = pad;
            }
        }

        private string FixImage(string image)
        {
            string Result = image;

            if (image == String.Empty)
                Result = StringConstants.FILE_IMAGE_NO_SALON;

            if (!Result.ToUpper().StartsWith(StringConstants.HTML))
            {
                Websites sites = Websites.All();

                if (sites.Count > 0)
                    Result = sites[0].URL + Result;
            }

            return (Result);
        }

        private void SetRedText(Label label)
        {
            label.ForeColor = Color.Red;
        }
    }
}
