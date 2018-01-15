using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

using Library;
using Library.BOL.Salons;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Members
{
    public partial class UpdateSalon : BaseWebFormSalonOwner
    {
        private Salon _userSalon;
        private string _url;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            btnSave.Text = Languages.LanguageStrings.Save;
            btnPreview.Text = Languages.LanguageStrings.Preview;
            WebsiteAdministration SalonMember = new WebsiteAdministration(GetUser());

            Salon salon = GetUser().Salons.Find(GetFormValue("SalonID", -1));

            if (salon == null)
                DoRedirect("/Members/UpdateSalons.aspx");

            //change next line to look in user salons instead of get by id
            _userSalon = SalonMember.SalonOwnerUpdateGet(GetUser(), salon);

            if (_userSalon == null)
                DoRedirect("/Members/UpdateSalons.aspx");

            if (!IsPostBack)
            {
                Session["SalonUpdateImage"] = _userSalon.Image;
                txtSalonName.Text = _userSalon.Name;
                txtContact.Text = _userSalon.ContactName;
                txtTelephone.Text = _userSalon.Telephone;
                txtFax.Text = _userSalon.Fax;
                txtEmail.Text = _userSalon.Email;
                txtWebsite.Text = _userSalon.URL;
                txtAddress.Text = _userSalon.Address;
                txtPostCode.Text = _userSalon.PostCode;

                txtMonday.Text = _userSalon.OpeningMonday;
                txtTuesday.Text = _userSalon.OpeningTuesday;
                txtWednesday.Text = _userSalon.OpeningWednesday;
                txtThursday.Text = _userSalon.OpeningThursday;
                txtFriday.Text = _userSalon.OpeningFriday;
                txtSaturday.Text = _userSalon.OpeningSaturday;
                txtSunday.Text = _userSalon.OpeningSunday;
            }

            lblError.Visible = false;
        }

        protected string GetSalonPreview()
        {
            //
            //!!!!!!!!!!   changes here need to be made to Salons.aspx     !!!!!!!!!!!!!!
            //

            string Result = "";

            if (_userSalon.VIPSalon)
                Result = "<li class=\"vip\">";
            else
                Result = "<li>";

            Result += String.Format("<h3>{0}</h3>", txtSalonName.Text);

            Result += String.Format("<div class=\"salonImg\"><img src=\"{0}\" alt=\"{1}\" width=\"130\" /></div>", _url == "" ? "/images/Salons/no-salon.png" : _url, _userSalon.Name);

            Result += String.Format("<div class=\"salonAddress\"><p>{0}<br />{1}</p></div>", txtAddress.Text.Replace("\r", "<br />"), txtPostCode.Text);

            Result += "<div class=\"salonContact\"><p>";

            if (txtTelephone.Text != "")
                Result += String.Format("<strong>Tel:</strong> {0}<br />", txtTelephone.Text);

            if (txtEmail.Text != "")
                Result += String.Format("<strong>Email:</strong> <a href=\"mailto:{0}\">{0}</a><br />", txtEmail.Text);

            if (txtWebsite.Text != "")
                Result += String.Format("<strong>Website:</strong> <a href=\"{0}\" target=\"_blank\">{0}</a>", txtWebsite.Text);
            
            string openingTimes = String.Empty;

            openingTimes = String.Format("<div class=\"openingHours\"><h3>{0}</h3><ul>", Languages.LanguageStrings.OpeningTimes);

            if (!String.IsNullOrEmpty(txtMonday.Text))
                openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Monday, txtMonday.Text);

            if (!String.IsNullOrEmpty(txtTuesday.Text))
                openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Tuesday, txtTuesday.Text);

            if (!String.IsNullOrEmpty(txtWednesday.Text))
                openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Wednesday, txtWednesday.Text);

            if (!String.IsNullOrEmpty(txtThursday.Text))
                openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Thursday, txtThursday.Text);

            if (!String.IsNullOrEmpty(txtFriday.Text))
                openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Friday, txtFriday.Text);

            if (!String.IsNullOrEmpty(txtSaturday.Text))
                openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Saturday, txtSaturday.Text);

            if (!String.IsNullOrEmpty(txtSunday.Text))
                openingTimes += String.Format("<li>{0}: <span>{1}</span></li>", Languages.LanguageStrings.Sunday, txtSunday.Text);

            openingTimes += "</ul></div>";

            Result += String.Format("</p><p><strong>{1}:</strong> {0}</p>{2}</div><div class=\"clear\"><!-- clear --></div></li>", txtContact.Text, Languages.LanguageStrings.Contact, openingTimes);

            return (Result.Replace("http:", "https:"));
        }

        public int GetSalonID()
        {
            int Result = GetFormValue("SalonID", -1);
            return (Result);
        }

        private string UploadImage()
        {
            string Result = "";

            //upload a picture if there is one
            if ((idFilePicture.PostedFile != null) && (idFilePicture.PostedFile.ContentLength > 0))
            {
                string fn = "";

                if (System.IO.Path.GetFileName(idFilePicture.PostedFile.FileName).EndsWith(".jpg"))
                    fn = String.Format("Images\\Salons\\Salon{0}{1}.jpg", GetUserID(), _userSalon.ID);
                else
                    fn = String.Format("Images\\Salons\\Salon{0}{1}.gif", GetUserID(), _userSalon.ID);

                Result = fn;

                string NewFile = Global.Path + fn;

                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(NewFile)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(NewFile));
                
                Result = Global.RootURL + "/" + fn.Replace(@"\", "/");
                _url = Result;
                Session["SalonUpdateImage"] = _url;
                idFilePicture.PostedFile.SaveAs(NewFile);
            }


            if (Result == "")
            {
                _url = (string)Session["SalonUpdateImage"];

                if (_url != null && _url != "")
                    Result = _url;
            }

            return (Result);
        }

        private bool ValidateInput()
        {
            bool Result = true;

            try
            {
                if (txtContact.Text.Trim() == "")
                    throw new Exception(Languages.LanguageStrings.InvalidContactName);

                if (txtTelephone.Text.Trim() == "")
                    throw new Exception(Languages.LanguageStrings.InvalidTelephoneNumber);

                if (txtEmail.Text.Trim() == "")
                    throw new Exception(Languages.LanguageStrings.InvalidEmailAddress);

                if (txtWebsite.Text.Trim() != "" && !txtWebsite.Text.StartsWith("http://"))
                    throw new Exception(Languages.LanguageStrings.WebsiteMustBeginWith);

                if (txtAddress.Text.Trim() == "")
                    throw new Exception(Languages.LanguageStrings.AddressCanNotBeBlank);

                if (txtPostCode.Text.Trim() == "")
                    throw new Exception(Languages.LanguageStrings.PostcodeCanNotBeBlank);
            }
            catch (Exception err)
            {
                lblError.Text = err.Message;
                lblError.Visible = true;
                Result = false;
            }

            return (Result);
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                UploadImage();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string image = UploadImage();
                _userSalon.Name = txtSalonName.Text;
                _userSalon.Image = image;
                _userSalon.ContactName = txtContact.Text;
                _userSalon.Address = txtAddress.Text;
                _userSalon.Telephone = txtTelephone.Text;
                _userSalon.Fax = txtFax.Text;
                _userSalon.Email = txtEmail.Text;
                _userSalon.URL = txtWebsite.Text;
                _userSalon.PostCode = txtPostCode.Text;
                _userSalon.SetOpeningHours(txtMonday.Text, txtTuesday.Text, txtWednesday.Text, txtThursday.Text,
                    txtFriday.Text, txtSaturday.Text, txtSunday.Text);

                WebsiteAdministration SalonMember = new WebsiteAdministration(GetUser());
                SalonMember.SalonOwnerUpdateInsert(GetUser(), _userSalon);
                DoRedirect("/Members/UpdateSalons.aspx");
            }
        }
    }
}