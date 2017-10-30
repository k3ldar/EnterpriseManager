using System.Windows.Forms;

using POS.Base.Classes;

using Library.BOL.Products;

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
