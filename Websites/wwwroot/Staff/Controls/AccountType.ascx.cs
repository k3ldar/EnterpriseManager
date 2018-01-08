using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Trade;

namespace SieraDelta.Website.Controls
{
    public partial class AccountType : BaseControlClass
    {
        private Client _client;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            int type = SharedUtils.StrToIntDef(ddlClientType.SelectedItem.Value, 0);

            _client.State = (Enums.ClientState)type;
        }

        public void Refresh(Client client)
        {
            _client = client;

            if (!IsPostBack)
            {
                //SieraDeltaUtils u = new SieraDeltaUtils();

                foreach (ListItem item in ddlClientType.Items)
                {
                    if (SharedUtils.StrToIntDef(item.Value, -1) == (int)_client.State)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }
    }
}