using System;

using Library;
using Library.BOL.Users;
using Library.BOL.Trade;
using Library.BOL.Distributors;
using Library.BOL.Salons;

#pragma warning disable IDE1005
#pragma warning disable IDE1006

namespace SieraDelta.Website.Controls
{
    public partial class CreateSalon : System.Web.UI.UserControl
    {
        private Client _client;
        private User _clientUser;

        public delegate void EventOnCreateSalon(object sender, EventArgs e);

        public event EventOnCreateSalon OnCreateSalon;

        #region Protected Methods

        protected virtual void RaiseOnCreateSalon(EventArgs args)
        {
            if (OnCreateSalon != null)
                OnCreateSalon(this, args);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rbDistributor.Checked && !rbSalon.Checked && !rbStockist.Checked)
                    throw new Exception("Please select the Salon Type");

                if (String.IsNullOrEmpty(txtSalonName.Text.Trim()))
                    throw new Exception("Enter Name");

                if (txtContact.Text.Trim() == "")
                    throw new Exception("Invalid Contact Name");

                if (txtTelephone.Text.Trim() == "")
                    throw new Exception("Invalid Telephone Number");

                if (txtEmail.Text.Trim() == "")
                    throw new Exception("Invalid Email Address");

                if (txtWebsite.Text.Trim() != "" && !txtWebsite.Text.StartsWith("http://"))
                    throw new Exception("Website must begin with \"http://\"");

                if (txtAddress.Text.Trim() == "")
                    throw new Exception("Address can not be blank");

                if (txtPostCode.Text.Trim() == "")
                    throw new Exception("Postcode can not be blank");

                SalonUser salonUser = new SalonUser();
                int NewID = -1;

                //create the salon
                if (rbDistributor.Checked)
                {
                    Distributor dist = Distributors.Create(txtSalonName.Text);
                    NewID = dist.ID;
                    salonUser.AddDistributorToUser(_clientUser, dist);
                }
                else
                {
                    Salon salon = Salons.Create(txtSalonName.Text, rbSalon.Checked ? Enums.SalonType.Salon : Enums.SalonType.StockistOnly);
                    NewID = salon.ID;
                    salonUser.AddSalonToUser(_clientUser, salon);
                }

                // set other salon properties
                Salon newSalon = _clientUser.Salons.Find(NewID);
                newSalon.VIPSalon = false;
                newSalon.ShowOnWeb = true;
                newSalon.ContactName = txtContact.Text;
                newSalon.Address = txtAddress.Text;
                newSalon.Email = txtEmail.Text;
                newSalon.Fax = txtFax.Text;
                newSalon.PostCode = txtPostCode.Text;
                newSalon.Telephone = txtTelephone.Text;
                newSalon.URL = txtWebsite.Text;

                newSalon.Save();

                //update host page
                RaiseOnCreateSalon(new EventArgs());
            }
            catch (Exception err)
            {
                lblError.Visible = true;
                lblError.Text = err.Message;
            }
        }

        //private string UploadImage(int SalonID)
        //{
        //    string Result = "";

        //    //upload a picture if there is one
        //    if ((idFilePicture.PostedFile != null) && (idFilePicture.PostedFile.ContentLength > 0))
        //    {
        //        string fn = "";

        //        if (System.IO.Path.GetFileName(idFilePicture.PostedFile.FileName).EndsWith(".jpg"))
        //            fn = String.Format("Members\\Data\\Salon{0}{1}.jpg", _clientUser.ID, SalonID);
        //        else
        //            fn = String.Format("Members\\Data\\Salon{0}{1}.gif", _clientUser.ID, SalonID);

        //        Result = fn;


        //        string NewFile = Global.Path + fn;
        //        Result = Library.BOL.Websites.WebsiteSettings.RootURL + "/" + fn.Replace(@"\", "/");
        //        _url = Result;
        //        Session["SalonUpdateImage"] = _url;
        //        idFilePicture.PostedFile.SaveAs(NewFile);
        //    }


        //    if (Result == "")
        //    {
        //        _url = (string)Session["SalonUpdateImage"];

        //        if (_url != null && _url != "")
        //            Result = _url;
        //    }

        //    return (Result);
        //}

        #endregion Protected Methods

        #region Public Methods

        public void Refresh(Client client, User clientUser)
        {
            _client = client;
            _clientUser = clientUser;
        }

        #endregion Public Methods
    }
}