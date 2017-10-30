using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;

namespace Heavenskincare.WebsiteTemplate.Trade
{
    public partial class Signup : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TradeSignup11.Visible = true;
                TradeSignup21.Visible = false;
                TradeSignup31.Visible = false;
                TradeSignupFinished1.Visible = false;
            }

            TradeSignup11.OnNextPage += new WizardNextPageDelegate(TradeSignup11_OnNextPage);
            TradeSignup21.OnNextPage += new WizardNextPageDelegate(TradeSignup21_OnNextPage);
            TradeSignup31.OnNextPage += new WizardNextPageDelegate(TradeSignup31_OnNextPage);
        }

        void TradeSignup31_OnNextPage(object sender, NextPageArgs e)
        {
            //submit details
            string Notes = TradeSignup21.GetData() + TradeSignup31.GetData();

            Clients.New(TradeSignup11.Name, TradeSignup11.Company, TradeSignup11.Telephone,
                TradeSignup11.Email, TradeSignup11.Address, TradeSignup11.Postcode, Notes);
            
            string email = TradeSignup11.GetData();
            email += TradeSignup21.GetData();
            email += TradeSignup31.GetData();

            Global.SendEMail(Global.WebsiteEmail, Global.WebsiteEmail, "Trade Signup", email);

            TradeSignup31.Visible = false;
            TradeSignupFinished1.Visible = true;
        }

        void TradeSignup21_OnNextPage(object sender, NextPageArgs e)
        {
            TradeSignup21.Visible = false;
            TradeSignup31.Visible = true;
        }

        void TradeSignup11_OnNextPage(object sender, NextPageArgs e)
        {
            TradeSignup11.Visible = false;
            TradeSignup21.Visible = true;
        }
    }
}