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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BaseControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Windows.Forms;

using POS.Base.Classes;

using SharedBase.BOL.Products;

namespace POS.Base.Controls
{
    public partial class BaseControl : SharedControls.BaseControl
    {
        #region Constructors

        public BaseControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Virtual Methods

        public virtual void Initialise()
        {

        }

        #endregion Virtual Methods

        #region Protected Methods

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

        protected void RunProgram(string program, 
            string args = StringConstants.SYMBOL_EMPTY_STRING)
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(program, args);
            startInfo.UseShellExecute = true;
            System.Diagnostics.Process.Start(startInfo);
        }

        #endregion Protected Methods

        #region Public Properties

        public string XMLFile
        {
            get
            {
                return (Shared.Utilities.CurrentPath() + StringConstants.FILE_CONFIG);
            }
        }

        #endregion Public Properties
    }
}
