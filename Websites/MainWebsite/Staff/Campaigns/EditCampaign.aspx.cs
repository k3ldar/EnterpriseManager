using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using Website.Library.Classes;

using Library;
using Library.Utils;
using Library.BOL.Products;
using Library.BOL.Campaigns;

namespace Heavenskincare.WebsiteTemplate.Staff.Campaigns
{
    public partial class EditCampaign : BaseWebFormStaff
    {
        #region Private Members

        private Campaign _campaign;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            pError.Visible = false;

            if (Session["CAMPAIGN"] == null)
            {
                Session["CAMPAIGN"] = Campaign.Get(GetFormValue("id", -1));
                DoRedirect("/Staff/Campaigns/EditCampaign.aspx");
            }
            else
                _campaign = (Campaign)Session["CAMPAIGN"];

            if (_campaign == null)
                DoRedirect("/Staff/Campaigns/Index.aspx");

            cbSendEmails.CheckedChanged += new EventHandler(cbSendEmails_CheckedChanged);
            cbSendLetter.CheckedChanged += new EventHandler(cbSendLetter_CheckedChanged);

            if (!IsPostBack)
                LoadCampaign();

            btnSave.Visible = GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.SaveCampaigns);
            btnDelete.Visible = GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.SaveCampaigns);
        }

        private void AjaxFileUploadHomepageImage_UploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            DoRedirect("/Staff/Campaigns/EditCampaign.aspx");
        }

        protected string GetCampaignTitle()
        {
            return (_campaign.Title);
        }

        protected string GetCampaignID()
        {
            return (_campaign.ID.ToString());
        }

        #endregion Protected Methods

        #region Private Methods

        private void cbSendEmails_CheckedChanged(object sender, EventArgs e)
        {
            pEmailSettings.Visible = cbSendEmails.Checked;
        }

        private void cbSendLetter_CheckedChanged(object sender, EventArgs e)
        {
            pLetters.Visible = cbSendLetter.Checked;
        }

        protected void LoadCampaign()
        {
            //settings
            txtStart.Text = _campaign.StartDateTime.ToString("dd/MM/yyyy HH:mm");
            txtFinish.Text = _campaign.FinishDateTime.ToString("dd/MM/yyyy HH:mm");
            
            //name / title
            txtCampaignName.Text = _campaign.CampaignName;
            txtCampaignTitle.Text = _campaign.Title;

            //emails
            cbSendEmails.Checked = _campaign.SendEmail;
            pEmailSettings.Visible = cbSendEmails.Checked;
            txtSenderName.Text = _campaign.SenderName;
            txtSenderEmail.Text = _campaign.SenderEmail;
            txtEmailMessage.Text = _campaign.Message;
            txtEmailSubject.Text = _campaign.EmailSubject;

            //letters
            cbSendLetter.Checked = _campaign.SendLetter;
            pLetters.Visible = _campaign.SendLetter;
            txtLetter.Text = _campaign.Letter;

            //website changes
            txtImageHomePage.Text = _campaign.ImageMainPage;
            imageHomePage.ImageUrl = _campaign.ImageMainPage;

            txtImageLeftMenu.Text = _campaign.ImageLeftMenu;
            imageLeftMenu.ImageUrl = _campaign.ImageLeftMenu;

            txtImageOffersPage.Text = _campaign.ImageOffersPage;
            imageOffersPage.ImageUrl = _campaign.ImageOffersPage;

            txtOffersPage.Text = _campaign.OffersPageText;

            txtLinkOverride.Text = _campaign.LinkOverride;

            if (Library.BOL.Campaigns.Campaigns.CanSetReplicationStatus())
            {
                cbReplicate.Checked = _campaign.CanReplicate;

                if (_campaign.CanReplicate)
                    cbReplicate.Enabled = false;
            }
            else
            {
                cbReplicate.Checked = false;
                pReplicate.Visible = false;
            }

            LoadGroups();
        }

        private void LoadGroups()
        {
            lstProductGroup.Items.Clear();

            lstProductGroup.Items.Add(new ListItem("None", "-1"));

            WebsiteAdministration admin = new WebsiteAdministration(GetUser());

            ProductGroups groups = admin.ProductGroupsGet(1, 1000);
            int idx = 0;
            foreach (ProductGroup grp in groups)
            {
                lstProductGroup.Items.Add(new ListItem(grp.Description, grp.ID.ToString()));

                if (_campaign.ActivateProductGroup == grp.ID)
                    lstProductGroup.SelectedIndex = idx;
            }

            lstProductGroup.SelectedValue = _campaign.ActivateProductGroup.ToString();
        }

        protected void btnUploadHomeImage_Click(object sender, EventArgs e)
        {
            if (FileUploadHomeImage.HasFile)
            {
                string FileName = String.Format("home{0}{1}", _campaign.ID, Path.GetExtension(FileUploadHomeImage.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadHomeImage.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                txtImageHomePage.Text = FileURL;
                _campaign.ImageMainPage = FileURL;
                imageHomePage.ImageUrl = _campaign.ImageMainPage;
                DoRedirect("/Staff/Campaigns/EditCampaign.aspx");
            }
        }

        protected void btnUploadLeftMenuImage_Click(object sender, EventArgs e)
        {
            if (FileUploadLeftMenu.HasFile)
            {
                string FileName = String.Format("menu{0}{1}", _campaign.ID, Path.GetExtension(FileUploadLeftMenu.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadLeftMenu.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                txtImageLeftMenu.Text = FileURL;
                _campaign.ImageLeftMenu = FileURL;
                imageLeftMenu.ImageUrl = _campaign.ImageLeftMenu;
                DoRedirect("/Staff/Campaigns/EditCampaign.aspx");
            }
        }

        protected void btnUploadOffersPageImage_Click(object sender, EventArgs e)
        {
            if (FileUploadOffersPage.HasFile)
            {
                string FileName = String.Format("offerspage{0}{1}", _campaign.ID, Path.GetExtension(FileUploadOffersPage.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadOffersPage.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                txtImageOffersPage.Text = FileURL;
                _campaign.ImageOffersPage = FileURL;
                imageOffersPage.ImageUrl = _campaign.ImageOffersPage;
                DoRedirect("/Staff/Campaigns/EditCampaign.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.SaveCampaigns))
            {
                CultureInfo culture = new CultureInfo("en-GB");

                try
                {
                    _campaign.StartDateTime = DateTime.ParseExact(txtStart.Text, "dd/MM/yyyy HH:mm", culture);
                    _campaign.FinishDateTime = DateTime.ParseExact(txtFinish.Text, "dd/MM/yyyy HH:mm", culture);

                }
                catch
                {
                    pError.Visible = true;
                    pError.InnerHtml = String.Format("<font color=\"red\">ERROR: Invalid start/end date time.</font>", txtCampaignName.Text);
                    return;
                }


                //name / title
                _campaign.CampaignName = txtCampaignName.Text.Replace(" ", "");
                _campaign.Title = txtCampaignTitle.Text;

                //emails
                _campaign.SendEmail = cbSendEmails.Checked;
                _campaign.SenderName = txtSenderName.Text;
                _campaign.SenderEmail = txtSenderEmail.Text;
                _campaign.Message = txtEmailMessage.Text;
                _campaign.EmailSubject = txtEmailSubject.Text;

                //letters
                _campaign.SendLetter = cbSendLetter.Checked;
                _campaign.SendLetter = pLetters.Visible;
                _campaign.Letter = txtLetter.Text;

                //website changes
                _campaign.ImageMainPage = txtImageHomePage.Text;

                _campaign.ImageLeftMenu = txtImageLeftMenu.Text;

                _campaign.ImageOffersPage = txtImageOffersPage.Text;
                _campaign.OffersPageText = txtOffersPage.Text;

                _campaign.LinkOverride = txtLinkOverride.Text;
                _campaign.ActivateProductGroup = Convert.ToInt32(lstProductGroup.SelectedValue);

                _campaign.CanReplicate = cbReplicate.Checked;

                try
                {
                    _campaign.Save();
                    DoRedirect(String.Format("/Staff/Campaigns/EditCampaign.aspx?ID={0}", _campaign.ID));
                }
                catch (Exception err)
                {
                    if (err.Message.Contains("lock conflict on no wait transaction"))
                    {
                        pError.Visible = true;
                        pError.InnerHtml = "<font color=\"red\">ERROR: Unable to save campaign at this time!</font>";
                    }
                    else if (err.Message.Contains(" violation of PRIMARY or UNIQUE KEY constraint \"IDX_CAMPAIGN_STATS_NAME") ||
                        err.Message.Contains("PRIMARY or UNIQUE KEY constraint \"IDX_CAMPAIGN_STATS_NAME\" on table \"WS_CAMPAIGN_STATS"))
                    {
                        pError.Visible = true;
                        pError.InnerHtml = String.Format("<font color=\"red\">ERROR: A Campaign with the name of {0} already exists, please choose a different name.</font>", txtCampaignName.Text);
                    }
                    else
                        throw;
                }

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (_campaign.Visits == 0)
            {
                _campaign.Delete();
                DoRedirect("/Staff/Campaigns/Index.aspx");
            }
        }

        protected void btnTestEmail_Click(object sender, EventArgs e)
        {
            _campaign.SendTestEmail(GetUser(), txtSenderName.Text, txtSenderEmail.Text, txtEmailMessage.Text.Replace("{campaign}", txtCampaignName.Text), txtEmailSubject.Text, txtCampaignName.Text);
        }

        #endregion Private Methods
    }
}