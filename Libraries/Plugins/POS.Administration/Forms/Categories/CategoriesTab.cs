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
 *  File: CategoriesTab.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using SharedBase.BOL.Appointments;
using SharedBase.BOL.Downloads;
using SharedBase.BOL.Helpdesk;
using SharedBase.BOL.Products;

using POS.Base.Classes;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0017 // Object Initialization can be simplified

namespace POS.Administration.Forms.Categories
{
    public partial class CategoriesTab :  Base.Controls.BaseOptionsControl
    {
        #region Private / Protected Members

        private StringFormat _tabStringFormat;

        #endregion Private / Protected Members

        #region Constructors

        public CategoriesTab()
            : base()
        {
            InitializeComponent();

            if (!Base.Classes.AppController.ApplicationRunning)
                return;

            _tabStringFormat = new StringFormat();
            _tabStringFormat.Alignment = StringAlignment.Center;
            _tabStringFormat.LineAlignment = StringAlignment.Center;

            LoadAllTypes();

            AllowRefresh = true;
            UpdateUI(false);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            // product types
            colProductTypeName.Text = LanguageStrings.Name;
            colProductTypePrimary.Text = LanguageStrings.AppPrimary;

            // product item types
            colProductItemTypeDescription.Text = LanguageStrings.Name;

            // product group item types
            colHeaderGroupName.Text = LanguageStrings.Name;

            // support tickets
            colTicketDepartmentsName.Text = LanguageStrings.Name;

            // download type
            colDownloadTypeName.Text = LanguageStrings.Name;

            // appointment groups
            colAppointGroupName.Text = LanguageStrings.Name;

            // tabs etc
            tabPageDownloadTypes.Text = LanguageStrings.AppDownloadTypes;
            tabPageProductGroupTypes.Text = LanguageStrings.AppProductGroupTypes;
            tabPageProductCostTypes.Text = LanguageStrings.AppProductItemTypes;
            tabPageProductTypes.Text = LanguageStrings.AppProductTypes;
            tabPageTicketDepartments.Text = LanguageStrings.AppTicketDepartments;
            tabPageAppointmentGroups.Text = LanguageStrings.AppAppointmentGroups;


            Size tabSize = tabCategories.ItemSize;

            foreach (TabPage page in tabCategories.TabPages)
            {
                Size fontSize = Shared.Utilities.MeasureText(page.Text, tabCategories.Font);
                int newWidth = Shared.Utilities.CheckMinMax(fontSize.Width, tabSize.Width, 200);

                if (tabSize.Width < (fontSize.Width + 30))
                    tabSize.Width = fontSize.Width + 30;

                if (tabSize.Height != fontSize.Height + 12)
                    tabSize.Height = fontSize.Height + 12;
            }

            tabCategories.ItemSize = tabSize;


            RebuildContextMenu(toolStripMain, popupMenuProductType);
            RebuildContextMenu(toolStripMain, popupMenuProductCostTypes);
        }

        protected override void OnCreateClicked()
        {
            if (tabCategories.SelectedTab == tabPageProductTypes)
                CreateProductType();
            else if (tabCategories.SelectedTab == tabPageProductCostTypes)
                CreateProductCostType();
            if (tabCategories.SelectedTab == tabPageProductGroupTypes)
                CreateProductGroupType();
            else if (tabCategories.SelectedTab == tabPageTicketDepartments)
                CreateTicketDepartmentsType();
            else if (tabCategories.SelectedTab == tabPageDownloadTypes)
                CreateDownloadType();
            else if (tabCategories.SelectedTab == tabPageAppointmentGroups)
                CreateAppointmentGroupsType();
        }

        protected override void OnDeleteClicked()
        {
            if (tabCategories.SelectedTab == tabPageProductTypes)
                DeleteProductType();
            else if (tabCategories.SelectedTab == tabPageProductCostTypes)
                DeleteProductCostType();
            else if (tabCategories.SelectedTab == tabPageProductGroupTypes)
                DeleteProductGroupType();
            else if (tabCategories.SelectedTab == tabPageTicketDepartments)
                DeleteTicketDepartmentsType();
            else if (tabCategories.SelectedTab == tabPageDownloadTypes)
                DeleteDownloadType();
            else if (tabCategories.SelectedTab == tabPageAppointmentGroups)
                DeleteAppointmentGroupsType();
        }

        protected override void OnEditClicked()
        {
            if (tabCategories.SelectedTab == tabPageProductTypes)
                lvProductType_DoubleClick(this, EventArgs.Empty);
            else if (tabCategories.SelectedTab == tabPageProductCostTypes)
                lvProductCostType_DoubleClick(this, EventArgs.Empty);
            else if (tabCategories.SelectedTab == tabPageProductGroupTypes)
                lvProductGroupType_DoubleClick(this, EventArgs.Empty);
            else if (tabCategories.SelectedTab == tabPageTicketDepartments)
                lvTicketDepartments_DoubleClick(this, EventArgs.Empty);
            else if (tabCategories.SelectedTab == tabPageDownloadTypes)
                lvDownloadType_DoubleClick(this, EventArgs.Empty);
            else if (tabCategories.SelectedTab == tabPageAppointmentGroups)
                lvAppointmentGroups_DoubleClick(this, EventArgs.Empty);
        }

        protected override void OnRefreshClicked()
        {
            if (tabCategories.SelectedTab == tabPageProductTypes)
                LoadProductTypes();
            else if (tabCategories.SelectedTab == tabPageProductCostTypes)
                LoadProductCostTypes();
            else if (tabCategories.SelectedTab == tabPageProductGroupTypes)
                LoadProductGroupTypes();
            else if (tabCategories.SelectedTab == tabPageTicketDepartments)
                LoadTicketDepartmentsTypes();
            else if (tabCategories.SelectedTab == tabPageDownloadTypes)
                LoadDownloadTypes();
            else if (tabCategories.SelectedTab == tabPageAppointmentGroups)
                LoadAppointmentGroupsTypes();
        }

        #endregion Overridden Methods

        #region Private Methods

        #region Tab Control

        private void tabCategories_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush txt_brush;
            Brush box_brush;
            Pen box_pen;

            // We draw in the TabRect rather than on e.Bounds
            // so we can use TabRect later in MouseDown.
            Rectangle tabHeaderRect = tabCategories.GetTabRect(e.Index);

            // Allow room for margins.
            RectangleF layout_rect = new RectangleF(
                tabHeaderRect.Left + 4,
                tabHeaderRect.Y,
                tabHeaderRect.Width - 15,
                tabHeaderRect.Height);


            Brush tabBrush = e.State == DrawItemState.Selected ? Brushes.LightBlue : Brushes.LightGray;

            e.Graphics.FillRectangle(tabBrush, tabHeaderRect);

            // Draw the background.
            // Pick appropriate pens and brushes.
            if (e.State == DrawItemState.Selected)
            {
#if LINEAR_TAB
                using (LinearGradientBrush aGB = new LinearGradientBrush(tabHeaderRect,
                    Color.LightBlue, Color.DarkBlue, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(aGB, tabHeaderRect);
                }
#else
                RectangleF headerLineRect = new RectangleF(
                    tabHeaderRect.Left,
                    tabHeaderRect.Top,
                    tabHeaderRect.Width,
                    3);

                e.Graphics.FillRectangle(Brushes.DarkBlue, headerLineRect);
#endif
            }

            txt_brush = Brushes.Black;
            box_brush = Brushes.Silver;
            box_pen = Pens.Black;

            // Draw the tab's text centered.
            e.Graphics.DrawString(
                tabCategories.TabPages[e.Index].Text,
                tabCategories.Font,
                txt_brush,
                layout_rect,
                _tabStringFormat);
        }

        private void tabCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCategories.SelectedTab == tabPageProductTypes)
            {
                lvProductType.Focus();
                UpdateUI(lvProductType.SelectedItems.Count > 0);
                AllowEdit = true;
                AppController.ActiveHelpTopic = HelpTopics.CategoryTypesProducts;
            }
            else if (tabCategories.SelectedTab == tabPageProductCostTypes)
            {
                lvProductCostType.Focus();
                UpdateUI(lvProductCostType.SelectedItems.Count > 0);
                AllowEdit = true;
                AppController.ActiveHelpTopic = HelpTopics.CategoryTypesProductCosts;
            }
            else if (tabCategories.SelectedTab == tabPageProductGroupTypes)
            {
                lvProductGroupType.Focus();
                UpdateUI(lvProductGroupType.SelectedItems.Count > 0);
                AllowEdit = true;
                AppController.ActiveHelpTopic = HelpTopics.CategoryTypesProductGroups;
            }
            else if (tabCategories.SelectedTab == tabPageTicketDepartments)
            {
                lvTicketDepartments.Focus();
                UpdateUI(lvTicketDepartments.SelectedItems.Count > 0);
                AllowEdit = true;
                AppController.ActiveHelpTopic = HelpTopics.CategoryTypesHelpDeskDepartments;
            }
            else if (tabCategories.SelectedTab == tabPageDownloadTypes)
            {
                lvDownloadTypes.Focus();
                UpdateUI(lvDownloadTypes.SelectedItems.Count > 0);
                AllowEdit = true;
                AppController.ActiveHelpTopic = HelpTopics.CategoryTypesDownloads;
            }
            else if (tabCategories.SelectedTab == tabPageAppointmentGroups)
            {
                lvAppointmentGroups.Focus();
                UpdateUI(lvAppointmentGroups.SelectedItems.Count > 0);
                AllowEdit = true;
                AppController.ActiveHelpTopic = HelpTopics.CategoryTypesAppointmentGroups;
            }
        }

        #endregion Tab Control

        #region General

        private void LoadAllTypes()
        {
            LoadProductTypes();
            LoadProductCostTypes();
            LoadProductGroupTypes();
            LoadTicketDepartmentsTypes();
            LoadDownloadTypes();
            LoadAppointmentGroupsTypes();
        }

        #endregion General

        #region Appointment Groups

        private void LoadAppointmentGroupsTypes()
        {
            lvAppointmentGroups.Items.Clear();
            AppointmentGroups allTypes = AppointmentGroups.Get();

            foreach (AppointmentGroup type in allTypes)
            {
                ListViewItem item = new ListViewItem(type.Description);
                item.Tag = type;
                lvAppointmentGroups.Items.Add(item);
            }
        }

        private void CreateAppointmentGroupsType()
        {
            AppointmentGroup newType = null;

            if (AppointmentGroupCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                ListViewItem item = new ListViewItem(newType.Description);
                item.Tag = newType;
                lvAppointmentGroups.Items.Add(item);
            }
        }

        private void lvAppointmentGroups_DoubleClick(object sender, EventArgs e)
        {
            if (lvAppointmentGroups.SelectedItems.Count == 0)
                return;

            AppointmentGroup newType = (AppointmentGroup)lvAppointmentGroups.SelectedItems[0].Tag;

            if (AppointmentGroupCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                lvAppointmentGroups.SelectedItems[0].SubItems[0].Text = newType.Description;
            }

            UpdateUI(lvAppointmentGroups.SelectedItems.Count > 0);
        }

        private void DeleteAppointmentGroupsType()
        {
            if (lvAppointmentGroups.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppDeleteApptGroupType))
            {
                try
                {
                    AppointmentGroup type = (AppointmentGroup)lvAppointmentGroups.SelectedItems[0].Tag;
                    type.Delete();
                    lvAppointmentGroups.Items.Remove(lvAppointmentGroups.SelectedItems[0]);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_EXISTS))
                    {
                        ShowError(LanguageStrings.Error, LanguageStrings.AppApptGroupDeleteError);
                    }
                    else
                        throw;
                }
            }
        }

        private void lvAppointmentGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = lvAppointmentGroups.SelectedItems.Count > 0;
            AllowDelete = lvAppointmentGroups.Items.Count > 1;
            UpdateUI(AllowEdit);
        }

        #endregion Appointment Groups

        #region Download Types

        private void LoadDownloadTypes()
        {
            lvDownloadTypes.Items.Clear();
            DownloadTypes allTypes = DownloadTypes.All();

            foreach (DownloadType type in allTypes)
            {
                ListViewItem item = new ListViewItem(type.Description);
                item.Tag = type;
                lvDownloadTypes.Items.Add(item);
            }
        }

        private void CreateDownloadType()
        {
            DownloadType newType = null;

            if (DownloadTypeCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                ListViewItem item = new ListViewItem(newType.Description);
                item.Tag = newType;
                lvDownloadTypes.Items.Add(item);
            }
        }

        private void lvDownloadType_DoubleClick(object sender, EventArgs e)
        {
            if (lvDownloadTypes.SelectedItems.Count == 0)
                return;

            DownloadType newType = (DownloadType)lvDownloadTypes.SelectedItems[0].Tag;

            if (DownloadTypeCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                lvDownloadTypes.SelectedItems[0].SubItems[0].Text = newType.Description;
            }

            UpdateUI(lvDownloadTypes.SelectedItems.Count > 0);
        }

        private void DeleteDownloadType()
        {
            if (lvDownloadTypes.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppDeleteDownloadType))
            {
                try
                {
                    DownloadType type = (DownloadType)lvDownloadTypes.SelectedItems[0].Tag;
                    type.Delete();
                    lvDownloadTypes.Items.Remove(lvDownloadTypes.SelectedItems[0]);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_EXISTS))
                    {
                        ShowError(LanguageStrings.Error, LanguageStrings.AppDownloadTypeDeleteError);
                    }
                    else
                        throw;
                }
            }
        }

        private void lvDownloadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = lvDownloadTypes.SelectedItems.Count > 0;
            AllowDelete = lvDownloadTypes.Items.Count > 1;
            UpdateUI(AllowEdit);
        }

        #endregion Download Types

        #region Ticket Departments Types

        private void LoadTicketDepartmentsTypes()
        {
            lvTicketDepartments.Items.Clear();
            TicketDepartments allTypes = TicketDepartments.Get();

            foreach (TicketDepartment type in allTypes)
            {
                ListViewItem item = new ListViewItem(type.Description);
                item.Tag = type;
                lvTicketDepartments.Items.Add(item);
            }
        }

        private void CreateTicketDepartmentsType()
        {
            TicketDepartment newType = null;

            if (TicketDepartmentsCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                ListViewItem item = new ListViewItem(newType.Description);
                item.Tag = newType;
                lvTicketDepartments.Items.Add(item);
            }
        }

        private void lvTicketDepartments_DoubleClick(object sender, EventArgs e)
        {
            if (lvTicketDepartments.SelectedItems.Count == 0)
                return;

            TicketDepartment newType = (TicketDepartment)lvTicketDepartments.SelectedItems[0].Tag;

            if (TicketDepartmentsCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                lvTicketDepartments.SelectedItems[0].SubItems[0].Text = newType.Description;
            }

            UpdateUI(lvTicketDepartments.SelectedItems.Count > 0);
        }

        private void DeleteTicketDepartmentsType()
        {
            if (lvTicketDepartments.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppDeleteTicketDepartmentsType))
            {
                try
                {
                    TicketDepartment type = (TicketDepartment)lvTicketDepartments.SelectedItems[0].Tag;
                    type.Delete();
                    lvTicketDepartments.Items.Remove(lvTicketDepartments.SelectedItems[0]);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_EXISTS))
                    {
                        ShowError(LanguageStrings.Error, LanguageStrings.AppTicketDepartmentsTypeDeleteError);
                    }
                    else
                        throw;
                }
            }
        }

        private void lvTicketDepartmentsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = lvTicketDepartments.SelectedItems.Count > 0;
            AllowDelete = lvTicketDepartments.Items.Count > 1;
            UpdateUI(AllowEdit);
        }

        #endregion Ticket Departments Types

        #region Product Group Types

        private void LoadProductGroupTypes()
        {
            lvProductGroupType.Items.Clear();
            ProductGroupTypes allTypes = ProductGroupTypes.Get(true);

            foreach (ProductGroupType type in allTypes)
            {
                ListViewItem item = new ListViewItem(type.Description);
                item.Tag = type;
                lvProductGroupType.Items.Add(item);
            }
        }

        private void CreateProductGroupType()
        {
            ProductGroupType newType = null;

            if (ProductGroupCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                ListViewItem item = new ListViewItem(newType.Description);
                item.Tag = newType;
                lvProductGroupType.Items.Add(item);
            }
        }

        private void lvProductGroupType_DoubleClick(object sender, EventArgs e)
        {
            if (lvProductGroupType.SelectedItems.Count == 0)
                return;

            ProductGroupType newType = (ProductGroupType)lvProductGroupType.SelectedItems[0].Tag;

            if (ProductGroupCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                lvProductGroupType.SelectedItems[0].SubItems[0].Text = newType.Description;
            }

            UpdateUI(lvProductGroupType.SelectedItems.Count > 0);
        }

        private void DeleteProductGroupType()
        {
            if (lvProductGroupType.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppDeleteSelectedProductGroupType))
            {
                try
                {
                    ProductGroupType type = (ProductGroupType)lvProductGroupType.SelectedItems[0].Tag;
                    type.Delete();
                    lvProductGroupType.Items.Remove(lvProductGroupType.SelectedItems[0]);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_EXISTS))
                    {
                        ShowError(LanguageStrings.Error, LanguageStrings.AppProductGroupTypeDeleteError);
                    }
                    else
                        throw;
                }
            }
        }

        private void lvProductGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = lvProductGroupType.SelectedItems.Count > 0;
            AllowDelete = lvProductGroupType.Items.Count > 1;
            UpdateUI(AllowEdit);
        }

        #endregion Product Group Types

        #region Product Cost Types

        private void LoadProductCostTypes()
        {
            lvProductCostType.Items.Clear();
            ProductCostTypes allTypes = ProductCostTypes.Get(true);

            foreach (ProductCostType type in allTypes)
            {
                ListViewItem item = new ListViewItem(type.Description);
                item.Tag = type;
                lvProductCostType.Items.Add(item);
            }
        }

        private void CreateProductCostType()
        {
            ProductCostType newType = null;

            if (ProductCostCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                ListViewItem item = new ListViewItem(newType.Description);
                item.Tag = newType;
                lvProductCostType.Items.Add(item);
            }
        }

        private void lvProductCostType_DoubleClick(object sender, EventArgs e)
        {
            if (lvProductCostType.SelectedItems.Count == 0)
                return;

            ProductCostType newType = (ProductCostType)lvProductCostType.SelectedItems[0].Tag;

            if (ProductCostCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                lvProductCostType.SelectedItems[0].SubItems[0].Text = newType.Description;
            }

            UpdateUI(lvProductCostType.SelectedItems.Count > 0);
        }

        private void DeleteProductCostType()
        {
            if (lvProductCostType.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppDeleteSelectedProductCostType))
            {
                try
                {
                    ProductCostType type = (ProductCostType)lvProductCostType.SelectedItems[0].Tag;
                    type.Delete();
                    lvProductCostType.Items.Remove(lvProductCostType.SelectedItems[0]);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_EXISTS))
                    {
                        ShowError(LanguageStrings.Error, LanguageStrings.AppProductCostTypeDeleteError);
                    }
                    else
                        throw;
                }
            }
        }

        private void lvProductCostType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = lvProductCostType.SelectedItems.Count > 0;
            AllowDelete = lvProductCostType.Items.Count > 1;
            UpdateUI(AllowEdit);
        }

        #endregion Product Cost Types

        #region Product Types

        private void LoadProductTypes()
        {
            lvProductType.Items.Clear();
            ProductTypes allTypes = ProductTypes.Get(true);

            foreach (ProductType type in allTypes)
            {
                ListViewItem item = new ListViewItem(type.Description);
                item.SubItems.Add(type.PrimaryType ? LanguageStrings.Yes : String.Empty);
                item.Tag = type;
                lvProductType.Items.Add(item);
            }
        }

        private void CreateProductType()
        {
            ProductType newType = null;

            if (ProductCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                ListViewItem item = new ListViewItem(newType.Description);
                item.SubItems.Add(newType.PrimaryType ? LanguageStrings.Yes : String.Empty);
                item.Tag = newType;
                lvProductType.Items.Add(item);

                // remove other primaries
                if (newType.PrimaryType)
                {
                    foreach (ListViewItem lItem in lvProductType.Items)
                    {
                        if (lItem == item)
                            continue;

                        ProductType pt = (ProductType)lItem.Tag;

                        if (pt.PrimaryType)
                        {
                            pt.PrimaryType = false;
                        }

                        lItem.SubItems[1].Text = String.Empty;
                    }
                }
            }
        }

        private void lvProductType_DoubleClick(object sender, EventArgs e)
        {
            if (lvProductType.SelectedItems.Count == 0)
                return;

            ProductType newType = (ProductType)lvProductType.SelectedItems[0].Tag;

            if (ProductCategoryTypeForm.ShowCategoryForm(ref newType))
            {
                lvProductType.SelectedItems[0].SubItems[0].Text = newType.Description;
                lvProductType.SelectedItems[0].SubItems[1].Text = newType.PrimaryType ? LanguageStrings.Yes : String.Empty;

                // remove other primaries
                if (newType.PrimaryType)
                {
                    foreach (ListViewItem item in lvProductType.Items)
                    {
                        ProductType pt = (ProductType)item.Tag;

                        if (pt.PrimaryType)
                        {
                            pt.PrimaryType = false;
                        }

                        item.SubItems[1].Text = String.Empty;
                    }

                    lvProductType.SelectedItems[0].SubItems[1].Text = LanguageStrings.Yes;
                }
           }

            UpdateUI(lvProductType.SelectedItems.Count > 0);
        }

        private void DeleteProductType()
        {
            if (lvProductType.SelectedItems.Count == 0)
                return;

            if (ShowQuestion(LanguageStrings.Delete, LanguageStrings.AppDeleteSelectedProductType))
            {
                try
                {
                    ProductType type = (ProductType)lvProductType.SelectedItems[0].Tag;
                    type.Delete();
                    lvProductType.Items.Remove(lvProductType.SelectedItems[0]);
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_FOREIGN_KEY_EXISTS))
                    {
                        ShowError(LanguageStrings.Error, LanguageStrings.AppProductTypeDeleteError);
                    }
                    else
                        throw;
                }
            }
        }

        private void lvProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = lvProductType.SelectedItems.Count > 0;
            AllowDelete = lvProductType.Items.Count > 1;
            UpdateUI(AllowEdit);
        }

        #endregion Product Types

        #endregion Private Methods
    }
}
