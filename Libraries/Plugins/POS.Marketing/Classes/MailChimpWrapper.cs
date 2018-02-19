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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: MailChimpWrapper.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Models;

using SharedControls.Classes;

#pragma warning disable IDE0017 // Simplify object initialization

namespace POS.Marketing.Classes
{
    public sealed class MailChimpWrapper
    {
        #region Private Members

        private string _apiKey;

        #endregion Private Members

        #region Constructors

        public MailChimpWrapper(string apiKey)
        {
            _apiKey = apiKey;
        }

        #endregion Constructors

        #region Public Methods

        #region Lists

        public IEnumerable<MailChimp.Net.Models.List> ListsGet(int maximim = 20)
        {
            IEnumerable<MailChimp.Net.Models.List> Result = null;
            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                Result = mgr.Lists.GetAllAsync(new ListRequest { Limit = maximim }).Result;
            }
            finally
            {
                mgr = null;
            }

            return (Result);
        }

        public MailChimp.Net.Models.List ListGet(string listName)
        {
            MailChimp.Net.Models.List Result = null;

            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                IEnumerable<MailChimp.Net.Models.List> listsAll = ListsGet(500);

                foreach (MailChimp.Net.Models.List list in listsAll)
                {
                    if (list.Name.ToUpper() == listName.ToUpper())
                    {
                        return (list);
                    }
                }
            }
            finally
            {
                mgr = null;
            }

            return (Result);
        }

        public string ListIdGet(string listName)
        {
            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                IEnumerable<MailChimp.Net.Models.List> listsAll = ListsGet(500);

                foreach (MailChimp.Net.Models.List list in listsAll)
                {
                    if (list.Name.ToUpper() == listName.ToUpper())
                    {
                        return (list.Id);
                    }
                }
            }
            finally
            {
                mgr = null;
            }

            return (String.Empty);
        }

        #endregion Lists

        #region Templates

        public bool TemplateUpdate(int templateID, string campaignName, string emailText)
        {
            bool Result = false;

            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                Template newTemplate = mgr.Templates.UpdateAsync(templateID.ToString(), campaignName, String.Empty, emailText).Result;
                Result = newTemplate.Id != 0;
            }
            finally
            {
                mgr = null;
            }

            return (Result);
        }

        public bool TemplateCreate(string campaignName, string emailText, out int templateID)
        {
            bool Result = false;

            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                Template newTemplate = mgr.Templates.CreateAsync(campaignName, String.Empty, emailText).Result;
                Result = newTemplate.Id != 0;
                templateID = newTemplate.Id;
            }
            finally
            {
                mgr = null;
            }

            return (Result);
        }

        public bool TemplateExists(string campaignName, out int templateID)
        {
            templateID = 0;

            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                IEnumerable<MailChimp.Net.Models.Template> templates = mgr.Templates.GetAllAsync(new TemplateRequest { Count = 5000 }).Result;

                foreach (MailChimp.Net.Models.Template template in templates)
                {
                    if (template.Name.ToUpper() == campaignName.ToUpper())
                    {
                        templateID = template.Id;
                        return (true);
                    }
                }


            }
            finally
            {
                mgr = null;
            }

            return (false);
        }

        #endregion Templates

        #region Campaigns

        public bool CampaignExists(string campaignName, out string campaignID)
        {
            campaignID = String.Empty;

            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                // does the campaign exist?
                IEnumerable<MailChimp.Net.Models.Campaign> allCampaigns = mgr.Campaigns.GetAllAsync().Result;

                foreach (MailChimp.Net.Models.Campaign cmp in allCampaigns)
                {
                    if (cmp.Settings.Title.ToUpper() == campaignName.ToUpper())
                    {
                        campaignID = cmp.Id;
                        return (true);
                    }
                }
            }
            finally
            {
                mgr = null;
            }

            return (false);
        }

        public bool CampaignCreate(string campaignName, string subject, string emailText,
            string emailSender, string emailSenderName, DateTime sendTime,
            int templateID, string listID, ref string campaignID)
        {
            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                if (String.IsNullOrWhiteSpace(campaignID))
                    CampaignExists(campaignName, out campaignID);

                // convert to utc and round up to nearest 15 mins
                if (sendTime.Kind != DateTimeKind.Utc)
                    sendTime = sendTime.ToUniversalTime();

                sendTime = sendTime.RoundUp(TimeSpan.FromMinutes(15));

                MailChimp.Net.Models.Campaign newCampaign = new MailChimp.Net.Models.Campaign();
                newCampaign.Id = campaignID;
                newCampaign.Type = CampaignType.Regular;
                newCampaign.Settings = new MailChimp.Net.Models.Setting();
                newCampaign.Settings.Title = campaignName;
                newCampaign.Settings.SubjectLine = subject;
                newCampaign.Recipients = new MailChimp.Net.Models.Recipient();
                newCampaign.Recipients.ListId = listID;
                newCampaign.Settings.FromName = emailSenderName;
                newCampaign.Settings.ReplyTo = emailSender;
                newCampaign.Settings.TemplateId = templateID;

                newCampaign = mgr.Campaigns.AddOrUpdateAsync(newCampaign).Result;

                campaignID = newCampaign.Id;
                ContentRequest content = new ContentRequest();
                content.Html = emailText;

                mgr.Content.AddOrUpdateAsync(campaignID, content);

                mgr.Campaigns.ScheduleAsync(newCampaign.Id, new CampaignScheduleRequest()
                { ScheduleTime = sendTime.ToString("o") });

                mgr.Campaigns.SendAsync(campaignID);

                return (!String.IsNullOrWhiteSpace(campaignID));
            }
            finally
            {
                mgr = null;
            }
        }

        //public bool CampaignUpdate(string campaignID, string campaignName,
        //    string subject, string emailText,
        //    string emailSender, string emailSenderName, DateTime sendTime,
        //    int templateID, string listID)
        //{
        //    bool Result = false;

        //    MailChimpManager mgr = new MailChimpManager(_apiKey);
        //    try
        //    {

        //        object options = new
        //        {
        //            from_email = emailSender,
        //            from_name = emailSenderName,
        //            template_id = templateID,
        //            subject = subject,
        //            list_id = listID,
        //            auto_footer = true
        //        };

        //        MailChimp.Campaigns.CampaignUpdateResult r = mgr.UpdateCampaign(campaignID, "options", options);
        //        Result = r.Errors.Count == 0;
        //    }
        //    finally
        //    {
        //        mgr = null;
        //    }

        //    return (Result);
        //}

        //public bool CampaignSchedule(string campaignID, DateTime scheduledDateTime)
        //{
        //    bool Result = false;

        //    MailChimpManager mgr = new MailChimpManager(_apiKey);
        //    try
        //    {
        //        string schedule = scheduledDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        //        MailChimp.Campaigns.CampaignActionResult r = mgr.ScheduleCampaign(campaignID, schedule);
        //        Result = r.Complete;
        //    }
        //    finally
        //    {
        //        mgr = null;
        //    }

        //    return (Result);
        //}

        //public bool CampaignActivate(string campaignID)
        //{
        //    bool Result = false;

        //    MailChimpManager mgr = new MailChimpManager(_apiKey);
        //    try
        //    {

        //    }
        //    finally
        //    {
        //        mgr = null;
        //    }

        //    return (Result);
        //}

        #endregion Campaigns
#if IncludeIncomplete

        #region Subscribers

        public bool SubscriberAdd(string listName, string emailAddress)
        {
            bool Result = false;

            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                MailChimp.Helper.EmailParameter emailParam = new MailChimp.Helper.EmailParameter();
                emailParam.Email = emailAddress;
                MailChimp.Helper.EmailParameter result = mgr.Subscribe(ListIdGet(listName), emailParam);
                Result = true;
            }
            finally
            {
                mgr = null;
            }

            return (Result);
        }

        public bool SubscriberRemove(string listName, string emailAddress)
        {
            bool Result = false;

            MailChimpManager mgr = new MailChimpManager(_apiKey);
            try
            {
                MailChimp.Helper.EmailParameter emailParam = new MailChimp.Helper.EmailParameter();
                emailParam.Email = emailAddress;
                MailChimp.Lists.UnsubscribeResult result = mgr.Unsubscribe(ListIdGet(listName), emailParam, true, true, true);
                Result = result.Complete;
            }
            finally
            {
                mgr = null;
            }

            return (Result);
        }

        #endregion Subscribers

#endif

        #endregion Public Methods
    }
}
