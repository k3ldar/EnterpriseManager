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
 *  File: BaseForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Linq;

using Languages;
using Library.BOL.Products;
using POS.Base.Classes;

namespace POS.Base.Forms
{
    public class BaseForm : SharedControls.Forms.BaseForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public BaseForm ()
        {

        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// If set this control will show hint information for the active control
        /// </summary>
        public Label HintControl { get; set; }

        /// <summary>
        /// Configuration File
        /// </summary>
        public string ConfigFile
        {
            get
            {
                return (Shared.Utilities.CurrentPath(true) + StringConstants.FILE_CONFIG_2);
            }
        }

        public string HelpTopic 
        { 
            get
            {
                return (POS.Base.Classes.AppController.ActiveHelpTopic);
            }

            set
            {
                POS.Base.Classes.AppController.ActiveHelpTopic = value;
            }
        }
      
        #endregion Properties

        #region Internal Methods

        public string XMLFile
        {
            get
            {
                string Result = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                Result = Path.GetDirectoryName(Result).Substring(6) + StringConstants.FILE_CONFIG;
                return (Result);
            }
        }

        public string GetHintText(string controlName, string subControlName)
        {
            string Result = LanguageStrings.AppHintNoText;

            if (String.IsNullOrEmpty(controlName) || String.IsNullOrEmpty(subControlName))
                return (Result);

            XDocument xdoc = XDocument.Load(StringConstants.FILE_HINTS);

            if (xdoc.Root.Element(controlName).Elements(subControlName).SingleOrDefault() != null)
                Result = @xdoc.Root.Element(controlName).Elements(subControlName).SingleOrDefault().Value;

            Result = Result.Replace(StringConstants.SYMBOL_CRLF_SAVED, StringConstants.SYMBOL_CRLF);
            return (Result);
        }

        public void Execute(string FileName)
        {
            try
            {
                ProcessStartInfo p = new ProcessStartInfo(FileName);
                p.WorkingDirectory = CurrentPath();
                Process _process = Process.Start(p);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, Languages.LanguageStrings.AppErrorStartingApplication);
            }
        }

        public string GetXMLValue(string ConfigFile, string ParentName, string KeyName)
        {
            return (XMLManipulation.GetXMLValue(ConfigFile, ParentName, KeyName, String.Empty));
        }

        public void SetXMLValue(string ConfigFile, string ParentName, string KeyName, string Value)
        {
            XMLManipulation.SetXMLValue(ConfigFile, ParentName, KeyName, Value);
        }

        #endregion Internal Methods

        #region Private Methods

        private void PrepareAutoHint(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                ctl.Enter += ctl_Enter;
                PrepareAutoHint(ctl);
            }
        }

        private void ctl_Enter(object sender, EventArgs e)
        {
            if (HintControl == null)
                return;

            if (sender is Control)
            {
                if (!String.IsNullOrEmpty(((Control)sender).Name))
                    HintControl.Text = GetHintText(this.Name, ((Control)sender).Name);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = StringConstants.BASE_FORM;
            this.ResumeLayout(false);

        }

        private int GetMinMax(int Value, int Minimum, int Maximum, int Default)
        {
            int Result = Value;

            if (Value < Minimum || Value > Maximum)
                Result = Default;

            return (Result);
        }

        /// <summary>
        /// Adds a text change to each text control to determine if the text contained within is RTL or LTR
        /// </summary>
        private void UpdateRightToLeft(Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                //recursively look in all controls
                UpdateRightToLeft(ctl.Controls);

                ctl.TextChanged += CheckRightToLeftText;
                CheckRightToLeftText(ctl, EventArgs.Empty);
            }
        }

        private void CheckRightToLeftText(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                Control ctl = (Control)sender;
                ctl.RightToLeft = Shared.Utilities.IsRightToLeftCharacter(ctl.Text) ? RightToLeft.Yes : RightToLeft.No;
            }
        }

        #endregion Private Methods

        #region Protected Methods

        protected void RebuildContextMenu(ToolStrip toolStrip, ContextMenuStrip menu)
        {
            if (toolStrip == null)
                throw new ArgumentNullException("toolStrip");

            if (menu == null)
                throw new ArgumentNullException("menu");

            menu.Items.Clear();
            int newSize = POS.Base.Icons.IconSize();
            toolStrip.ImageScalingSize = new System.Drawing.Size(newSize, newSize);
            toolStrip.Text = String.Empty;

            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item.GetType() == typeof(ToolStripButton))
                {
                    item.EnabledChanged += item_EnabledChanged;
                    item.TextChanged += item_TextChanged;
                    ((ToolStripButton)item).CheckedChanged += BaseForm_CheckedChanged;

                    ToolStripMenuItem newMenu = new ToolStripMenuItem(item.ToolTipText);
                    newMenu.Image = item.Image;
                    newMenu.Enabled = item.Enabled;
                    item.Tag = newMenu;
                    newMenu.Tag = item;
                    newMenu.Click += newMenu_Click;

                    menu.Items.Add(newMenu);
                }

                if (item.GetType() == typeof(ToolStripSeparator))
                {
                    ToolStripSeparator newSep = new ToolStripSeparator();

                    menu.Items.Add(newSep);
                }
            }

            while (menu.Items[menu.Items.Count - 1].GetType() == typeof(ToolStripSeparator))
                menu.Items.Remove(menu.Items[menu.Items.Count - 1]);
        }

        protected void LoadPrimaryGroupTypes(ToolStripComboBox comboBox, bool addAllItems, bool setIndex = false)
        {
            ProductTypes prodTypes = ProductTypes.Get();
            comboBox.Items.Clear();
            comboBox.Tag = prodTypes;

            foreach (ProductType primaryGroup in prodTypes)
            {
                comboBox.Items.Add(primaryGroup.Description);
            }

            comboBox.SelectedIndex = 0;
        }

        protected void LoadPrimaryGroupTypes(ComboBox comboBox, bool addAllItems, bool setIndex = false)
        {
            comboBox.Items.Clear();
            comboBox.Format += comboBox_Format;

            foreach (ProductType primaryGroup in ProductTypes.Get())
            {
                comboBox.Items.Add(primaryGroup);
            }

            comboBox.SelectedIndex = 0;
        }

        protected void comboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductType primary = (ProductType)e.ListItem;

            e.Value = primary.Description;
        }

        protected virtual void SetPermissions()
        {
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            SetPermissions();

            PrepareAutoHint(this);

            base.OnLoad(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            AppController.ActiveForm = this;
        }

        protected void GetRecordedDeliveryLocal(ref string Prefix, ref Int64 UniqueNumber, ref string Suffix)
        {
            Prefix = GetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, StringConstants.XML_PREFIX);
            Suffix = GetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, StringConstants.XML_SUFFIX);
            bool autoIncrement = Shared.Utilities.StrToBool(GetXMLValue(XMLFile,
                StringConstants.XML_LOCAL_DELIVERY, StringConstants.XML_AUTO_INCREMENT));

            UniqueNumber = Shared.Utilities.StrToInt64Def(GetXMLValue(XMLFile,
                StringConstants.XML_LOCAL_DELIVERY, StringConstants.XML_UNIQUE_NUMBER), 0);

            if (autoIncrement)
            {
                UniqueNumber++;

                SetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                    StringConstants.XML_UNIQUE_NUMBER, UniqueNumber.ToString());
            }
        }

        protected void GetRecordedDeliveryInternational(ref string Prefix, ref Int64 UniqueNumber, 
            ref string Suffix)
        {
            Prefix = GetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                StringConstants.XML_PREFIX);
            Suffix = GetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                StringConstants.XML_SUFFIX);
            bool autoIncrement = Shared.Utilities.StrToBool(GetXMLValue(
                XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, StringConstants.XML_AUTO_INCREMENT));

            UniqueNumber = Shared.Utilities.StrToInt64Def(GetXMLValue(
                XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, StringConstants.XML_UNIQUE_NUMBER), 0);

            if (autoIncrement)
            {
                UniqueNumber++;

                SetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY,
                    StringConstants.XML_UNIQUE_NUMBER, UniqueNumber.ToString());
            }
        }

        #endregion Protected Methods

        #region Private Methods

        #region Context Menu

        private void newMenu_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;

                if (menu.Tag == null)
                    return;

                ToolStripButton btn = (ToolStripButton)menu.Tag;

                btn.PerformClick();
            }
        }

        private void BaseForm_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton btn = (ToolStripButton)sender;
                if (btn.Tag == null)
                    return;

                ToolStripMenuItem menu = (ToolStripMenuItem)btn.Tag;

                menu.Checked = btn.Checked;
            }
        }

        private void item_TextChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton btn = (ToolStripButton)sender;
                if (btn.Tag == null)
                    return;

                ToolStripMenuItem menu = (ToolStripMenuItem)btn.Tag;

                menu.Text = btn.Text;
            }
        }

        private void item_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton btn = (ToolStripButton)sender;
                if (btn.Tag == null)
                    return;

                ToolStripMenuItem menu = (ToolStripMenuItem)btn.Tag;

                menu.Enabled = btn.Enabled;
            }
        }

        #endregion Context Menu

        #endregion Private Methods
    }
}
