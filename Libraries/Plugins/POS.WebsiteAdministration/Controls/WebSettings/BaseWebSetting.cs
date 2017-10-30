using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Library.BOL.Websites;

namespace POS.WebsiteAdministration.Controls.WebSettings
{
    public partial class BaseWebSetting : POS.Base.Controls.BaseControl
    {
        public BaseWebSetting()
        {
            InitializeComponent();
        }

        protected void RaiseOnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        public virtual string HelpString()
        {
            return (String.Empty);
        }

        public void UpdateSetting(string setting, bool isGlobal, int settingIndex)
        {
            SettingName = setting.ToUpper();
            IsGlobal = isGlobal;
            SettingIndex = settingIndex;
        }

        public void WebsiteChanged(Website website)
        {
            WebSite = website;

            Reload();
        }

        public virtual void Reload()
        {

        }

        public virtual void Save()
        {

        }

        public virtual void Clear()
        {

        }

        public virtual bool AllowDelete()
        {
            return (false);
        }

        public Website WebSite { get; private set; }

        public bool IsGlobal { get; private set; }

        public string SettingName { get; private set; }

        public int SettingIndex { get; set; }

        public event EventHandler Changed;
    }
}
