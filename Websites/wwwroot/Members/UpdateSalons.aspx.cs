using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.Salons;
using Website.Library.Classes;

namespace SieraDelta.Website.Members
{
    public partial class UpdateSalons : BaseWebFormSalonOwner
    {
        private string _url;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            btnSave.Text = Languages.LanguageStrings.Save;
            
            lblError.Visible = false;
            LoadSalons();

            dvCreateNew.Visible = GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.CreateNewSalons);
        }

        private void LoadSalons()
        {
            pSalons.InnerHtml = "";

            foreach (Salon salon in GetUser().Salons)
            {
                pSalons.InnerHtml += BuildSalon(salon);
            }
        }


        private string BuildSalon(Salon salon)
        {
            //
            //!!!!!!!!!!   changes here need to be made to Outlets.aspx and Salons.aspx     !!!!!!!!!!!!!!
            //

            string Result = "";

            if (salon.VIPSalon)
                Result = "<li class=\"vip\">";
            else
                Result = "<li>";
            Result += String.Format("<a href=\"/Account/Distributor/Outlet/Edit/{0}/\">Edit Outlet</a>", salon.ID);
            Result += String.Format("<h3>{0}</h3>", salon.Name);

            Result += String.Format("<div class=\"salonImg\"><img src=\"{0}\" alt=\"{1}\" width=\"130\" /></div>", salon.Image == "" ? "/images/Salons/no-salon.png" : salon.Image, salon.Name);

            Result += String.Format("<div class=\"salonAddress\"><p>{0}<br />{1}</p></div>", salon.Address.Replace("\r", "<br />"), salon.PostCode);

            Result += "<div class=\"salonContact\"><p>";

            if (salon.Telephone != "")
                Result += String.Format("<strong>{1}:</strong> {0}<br />", salon.Telephone, Languages.LanguageStrings.Telephone);

            if (salon.Email != "")
                Result += String.Format("<strong>{1}:</strong> <a href=\"mailto:{0}\">{0}</a><br />", salon.Email,
                    Languages.LanguageStrings.Email);

            if (salon.URL != "")
                Result += String.Format("<strong>{1}:</strong> <a href=\"http://www.heavenskincare.com/Redirect/Index.aspx?rd={0}\" target=\"_blank\">{0}</a>", 
                    salon.URL, Languages.LanguageStrings.Website);

            Result += String.Format("</p><p><strong>{1}:</strong> {0}</p></div><div class=\"clear\"><!-- clear --></div></li>",
                salon.ContactName, Languages.LanguageStrings.Contact);

            if (!String.IsNullOrEmpty(salon.URL))
                Result += String.Format("<p>{1}: {0}</p>", 
                    Library.BOL.Statistics.Statistics.RedirectHitCount(salon.URL),
                    Languages.LanguageStrings.TotalRedirects);

            return (Result.Replace("http:", "https:"));
        }

        private string UploadImage(Salon salon)
        {
            string Result = "";

            //upload a picture if there is one
            if ((idFilePicture.PostedFile != null) && (idFilePicture.PostedFile.ContentLength > 0))
            {
                string fn = "";

                if (System.IO.Path.GetFileName(idFilePicture.PostedFile.FileName).EndsWith(".jpg"))
                    fn = String.Format("Members\\Data\\Salon{0}{1}.jpg", GetUserID(), salon.ID);
                else
                    fn = String.Format("Members\\Data\\Salon{0}{1}.gif", GetUserID(), salon.ID);

                Result = fn;


                string NewFile = Global.Path + fn;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Salon userSalon = Salons.Create(txtSalonName.Text, Enums.SalonType.Salon);
                userSalon.ShowOnWeb = false;
                

                string image = UploadImage(userSalon);
                userSalon.Name = txtSalonName.Text;
                userSalon.Image = image;
                userSalon.ContactName = txtContact.Text;
                userSalon.Address = txtAddress.Text;
                userSalon.Telephone = txtTelephone.Text;
                userSalon.Fax = txtFax.Text;
                userSalon.Email = txtEmail.Text;
                userSalon.URL = txtWebsite.Text;
                userSalon.PostCode = txtPostCode.Text;
                userSalon.SetOpeningHours(txtMonday.Text, txtTuesday.Text, txtWednesday.Text, txtThursday.Text,
                    txtFriday.Text, txtSaturday.Text, txtSunday.Text);

                userSalon.Save();

                WebsiteAdministration SalonMember = new WebsiteAdministration(GetUser());
                SalonMember.SalonOwnerCreate(GetUser(), userSalon);
                SalonMember.SalonOwnerUpdateInsert(GetUser(), userSalon);
                DoRedirect("/Account/Distributor/Outlet/");
            }
        }

    }
}