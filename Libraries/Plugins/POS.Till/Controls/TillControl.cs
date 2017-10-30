using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using Reports.Accounts;
using Library.BOL.Accounts;
using Library.BOL.Appointments;
using Library.BOL.Users;
using Library.BOL.Products;
using Library.BOL.Basket;
using Library.BOL.Orders;
using Library.BOL.Invoices;
using Library.BOL.Vouchers;
using Library;

using SharedControls.Forms;
using SharedControls.Classes;

using POS.Base.Classes;
using POS.Base.Forms;

using POS.Till.Forms;

#pragma warning disable IDE0018 // Variable declaration can be inlined
#pragma warning disable IDE0017 // Object initialization can be simplified
#pragma warning disable IDE0018 // Variable declaration can be inlined
#pragma warning disable IDE0029 // Null check can be simplified
#pragma warning disable IDE0017 // Object initialization can be simplified
#pragma warning disable IDE0028 // Collection initialization can be simplified
#pragma warning disable IDE1006 // Naming rule violation: These words must begin with upper case characters
#pragma warning disable IDE1005 // Delegate invocation can be simplified

namespace POS.Till.Controls
{
    public partial class TillControl : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private Users _staffMembers = null;
        private Appointments _appointments = null;
        private ShoppingBasket _basket = null;
        private Order _order = null;
        private Products _products;
        private StringFormat _tabStringFormat;

        private List<BasketProductButton> _productButtons;
        private List<BasketTreatmentButton> _treatmentButtons;

        #endregion Private Members

        #region Constructors / Destructors

        public TillControl()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            _tabStringFormat = new StringFormat();
            _tabStringFormat.Alignment = StringAlignment.Center;
            _tabStringFormat.LineAlignment = StringAlignment.Center;


            _productButtons = new List<BasketProductButton>();
            _treatmentButtons = new List<BasketTreatmentButton>();

            //create new basket
            _basket = new ShoppingBasket(AppController.LocalCountry, AppController.LocalCurrency,
                AppController.LocalSettings.ShippingIsTaxable);
            _basket.MultiCurrency = false;
            _basket.FreeShipping = true;
            _basket.FreeShippingAmount = 0.00m;
            _basket.IgnoreAutoDiscount = true;
            _basket.IgnoreCostMultiplier = true;
            _basket.SaleIsFromShopFront = true;
            _basket.VoucherType = Enums.InvoiceVoucherType.Value;
            _basket.BasketUpdated += new EventHandler(_Basket_BasketUpdated);
            _basket.IgnoreBasketQuantityRestrictions = true;

            _products = AppController.Administration.ProductsGet();

            foreach (Product prod in _products)
                prod.UpdateProductCostInfo(AppController.ActiveUser);

            BuildTreatments();
            BuildStaffList();
            DoRefresh();

            LoadProductTypes();
            BuildProductList();
            cmbProductType.SelectedIndexChanged += new EventHandler(cmbProductType_SelectedIndexChanged);
            BuildBasket(false);
            BuildAppointmentList();

            AppController.ApplicationController.AppointmentIDChanged += User_AppointmentIDChanged;
            AppController.ApplicationController.OnUserChanged += User_OnUserChanged;
        }

        public TillControl(User user)
            : this()
        {
            WaitInputDialog.ShowWaitScreen();
            try
            {
                WaitInputDialog.UpdateWaitScreen(LanguageStrings.AppTillLoading);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Shared.EventLog.Add(err);
            }
            finally
            {
                WaitInputDialog.HideWaitScreen();
            }
        }

        #endregion Constructors / Destructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            if (DesignMode)
                return;

            pnlTodaysAppointments.HeaderText = LanguageStrings.AppTillTodaysAppointments;
            pnlCurrentSale.HeaderText = LanguageStrings.AppTillCurrentSale;

            tabPageProducts.Text = LanguageStrings.Products;
            tabPageTreatments.Text = LanguageStrings.Treatments;

            lblFilter.Text = LanguageStrings.AppFilter;
            lblPostage.Text = LanguageStrings.AppTillPostageAndPackaging;
            lblSubtotal.Text = LanguageStrings.AppSubTotal;
            lblProductType.Text = LanguageStrings.AppProductType;
            lblVAT.Text = String.Format(LanguageStrings.AppTillTaxValue, _basket.VATRate);

            btnAddtoBasket.Text = LanguageStrings.AppMenuButtonAddToBasket;
            btnApplyDiscount.Text = LanguageStrings.AppMenuButtonApplyDiscount;
            btnArrived.Text = LanguageStrings.AppMenuButtonArrived;
            btnClearAll.Text = LanguageStrings.AppMenuButtonClearAll;
            btnClearBasket.Text = LanguageStrings.AppMenuButtonClearBasket;
            btnComplete.Text = LanguageStrings.AppMenuButtonComplete;
            btnMarkAsPaid.Text = LanguageStrings.AppMenuButtonMarkAsPaid;
            btnrefresh.Text = LanguageStrings.AppMenuButtonRefresh;

            colApptClient.Text = LanguageStrings.AppCustomer;
            colApptStaff.Text = LanguageStrings.AppEmployee;
            colApptTime.Text = LanguageStrings.AppTime;

            Size tabSize = tabSaleItems.ItemSize;

            foreach (TabPage page in tabSaleItems.TabPages)
            {
                Size fontSize = Shared.Utilities.MeasureText(page.Text, tabSaleItems.Font);
                int newWidth = Shared.Utilities.CheckMinMax(fontSize.Width, tabSize.Width, 200);

                if (tabSize.Width < (fontSize.Width + 30))
                    tabSize.Width = fontSize.Width + 30;

                if (tabSize.Height != fontSize.Height + 12)
                    tabSize.Height = fontSize.Height + 12;
            }

            tabSaleItems.ItemSize = tabSize;

            BuildBasket(false);
        }

        public void LoadTillSettings()
        {
            //options
            flowLayoutProducts.Visible = AppController.LocalSettings.TillShowButtons;
            lstProducts.Visible = !AppController.LocalSettings.TillShowButtons;
            flowLayoutTreatments.Visible = AppController.LocalSettings.TillShowButtons;
            lstTreatments.Visible = !AppController.LocalSettings.TillShowButtons;


            //splitBasket.SplitterDistance = SettingGet(StringConstants.XML_SPLITTER_DISTANCE, 
            //    splitBasket.SplitterDistance);
        }

        public void SaveSettings()
        {
            //SettingSave(StringConstants.XML_SPLITTER_DISTANCE, splitBasket.SplitterDistance);
        }

        #endregion Overridden Methods

        #region Public Methods

        public void TakePayment(Appointment appointment)
        {
            btnClearBasket_Click(this, new EventArgs());
            _basket.Add(AppointmentTreatments.Get(appointment.TreatmentID), 1, 
                User.UserGet(appointment.EmployeeID), AppController.LocalCountry.PriceColumn);
            _basket.User = appointment.User;

            foreach (Appointment apptChild in appointment.ChildAppointments)
            {
                // only adjust child appointments if their status matches the parent, 
                // i.e. child appt not cancelled parent appt is still on
                if (apptChild.Status == appointment.Status)
                {
                    _basket.Add(AppointmentTreatments.Get(apptChild.TreatmentID), 1,
                        User.UserGet(apptChild.EmployeeID), AppController.LocalCountry.PriceColumn);
                    apptChild.Status = Enums.AppointmentStatus.Completed;
                    apptChild.Save(AppController.ActiveUser);
                }
            }

            BuildBasket(false);
        }

        public override void AfterTabShow()
        {
           
        }

        public override void AfterResize()
        {
            base.AfterResize();
            ResizeBasketItems();
            ResizeEnd(this, EventArgs.Empty);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            ResizeBasketItems();
        }

        public override int GetStatusCount()
        {
            return (statusStripSummary.Items.Count);
        }
        
        public override string GetStatusText(int index)
        {
            return (statusStripSummary.Items[index].Text);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStripSummary.Items[index].ToolTipText);
        }


        #endregion Public Methods

        #region Internal Methods

        internal void ProductsUpdated()
        {
            _products = AppController.Administration.ProductsGet();

            foreach (Product prod in _products)
                prod.UpdateProductCostInfo(AppController.ActiveUser);

            BuildProductList();
            BuildProducts();
        }

        internal void TreatmentsUpdated()
        {
            BuildTreatments();
        }

        #endregion Internal Methods

        #region Private Methods

        #region AppControler Events

        private void User_AppointmentIDChanged(object sender, AppController.IDChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AppController.IDChangedHandler ch = new AppController.IDChangedHandler(User_AppointmentIDChanged);
                this.Invoke(ch, new object[] { sender, e });
            }
            else
            {
                //BuildAppointmentList();

                foreach (Appointment appt in _appointments)
                {
                    if (appt.ID == e.OldID)
                    {
                        appt.ID = e.NewID;
                    }
                }
            }
        }

        public void BarcodeReceived(object sender, AppController.BarcodeEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AppController.BarcodeHandler eh = new AppController.BarcodeHandler(BarcodeReceived);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                if (e.Barcode.StartsWith(StringConstants.TILL_BARCODE_PREFIX_HV))
                {
                    ShowError(LanguageStrings.Error, LanguageStrings.AppTillNoScanVoucher);
                }
                else
                {
                    if (!e.Barcode.StartsWith(StringConstants.TILL_BARCODE_PREFIX_HHB))
                    {
                        ProductCost newItem = ProductCosts.GetByBarcode(e.Barcode);

                        if (newItem != null)
                        {
                            _basket.Add(newItem, 1, AppController.LocalSettings.TillDefaultUserSystem ? AppController.DefaultSystemUser : _basket.User, AppController.LocalCountry.PriceColumn);
                            BuildBasket(false);
                        }
                        else
                        {
                            if (AppController.ApplicationController.GetUser.HasPermissionPOS(
                                SecurityEnums.SecurityPermissionsPOS.AssignBarcodes))
                            {
                                AssignBarcodeForm frm = new AssignBarcodeForm();
                                try
                                {
                                    frm.Products = _products;
                                    frm.ShowDialog(this);

                                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                                    {
                                        //update the existing product cost and add to basket
                                        foreach (Product product in _products)
                                        {
                                            foreach (ProductCost cost in product.ProductCosts)
                                            {
                                                if (cost.ID == frm.UpdatedProductCost.ID)
                                                {
                                                    cost.Barcode = frm.UpdatedProductCost.Barcode;
                                                    _basket.Add(cost, 1, AppController.LocalSettings.TillDefaultUserSystem ? AppController.DefaultSystemUser : _basket.User, AppController.LocalCountry.PriceColumn);
                                                    BuildBasket(false);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                                finally
                                {
                                    frm.Dispose();
                                    frm = null;
                                }
                            }
                            else
                            {
                                ShowError(LanguageStrings.Error, LanguageStrings.AppTillInvalidBarcode);
                            }
                        }
                    }
                }
            }
        }

        private void User_OnUserChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler eh = new EventHandler(User_OnUserChanged);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                Text = String.Format(LanguageStrings.AppPointOfSale, AppController.ActiveUser.UserName);
            }
        }

        #endregion AppControler Events

        #region Appointments


        private void BuildAppointmentList()
        {
            lvAppointments.BeginUpdate();
            try
            {
                lvAppointments.Items.Clear();

                _appointments = Appointments.Get(DateTime.Now);

                foreach (Appointment appt in _appointments)
                {
                    if (appt.AppointmentType == 0 && appt.MasterAppointment == -1)
                    {
                        Color color = Color.White;

                        switch (appt.Status)
                        {
                            case Enums.AppointmentStatus.Requested: //requested
                                color = Color.FromArgb(0, 153, 204);
                                break;
                            case Enums.AppointmentStatus.Confirmed: //confirmed
                                color = Color.FromArgb(102, 255, 102);
                                break;
                            case Enums.AppointmentStatus.Arrived: //arrived
                                color = Color.FromArgb(255, 153, 0);
                                break;
                            default:
                                continue;
                        }

                        ListViewItem item = new ListViewItem(appt.UserName);
                        item.SubItems.Add(Shared.Utilities.DoubleToTime(appt.StartTime).ToString());
                        item.SubItems.Add(appt.EmployeeName);
                        item.Tag = appt;
                        item.BackColor = color;

                        lvAppointments.Items.Add(item);
                    }
                }

                toolStripStatusAppointments.Text = String.Format(LanguageStrings.AppTillTotalAppointments, lvAppointments.Items.Count);
                SetButtonStatus(null);
            }
            finally
            {
                lvAppointments.EndUpdate();
            }
        }

        private void SetButtonStatus(Appointment appt)
        {
            Enums.AppointmentStatus ApptStatus = appt == null ? Enums.AppointmentStatus.Requested : appt.Status;

            btnArrived.Enabled = lvAppointments.SelectedItems.Count > 0 && (int)ApptStatus < 3;
            btnComplete.Enabled = lvAppointments.SelectedItems.Count > 0 && 
                ApptStatus == Enums.AppointmentStatus.Arrived;
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            BuildAppointmentList();
        }


        #region lstAppointments Private Methods

        private void btnArrived_Click(object sender, EventArgs e)
        {
            //get current appointment
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            Appointment appt = (Appointment)lvAppointments.SelectedItems[0].Tag;

            foreach (Appointment apptChild in appt.ChildAppointments)
            {
                // only adjust child appointments if their status matches the parent, 
                // i.e. child appt not cancelled parent appt is still on
                if (apptChild.Status == appt.Status)
                {
                    apptChild.Status = Enums.AppointmentStatus.Arrived;
                    apptChild.Save(AppController.ActiveUser);
                }
            }

            appt.Status = Enums.AppointmentStatus.Arrived;
            appt.Save(AppController.ActiveUser);

            lvAppointments.Focus();
            lvAppointments_SelectedIndexChanged(lvAppointments, EventArgs.Empty);

            lvAppointments.SelectedItems[0].BackColor = Color.FromArgb(255, 153, 0);

            DoRefresh();

            User user = appt.User;

            if (Shared.Utilities.DateWithin(user.BirthDate, 7))
                ShowInformation(LanguageStrings.AppDiaryBirthday, 
                    String.Format(LanguageStrings.AppDiaryBirthdayClose, user.FirstName,
                    user.BirthDate.ToString(StringConstants.SYMBOL_DATE_FORMAT_M)));
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //get current appointment
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            Appointment appt = (Appointment)lvAppointments.SelectedItems[0].Tag;

            if (appt.TreatmentID > -1)
            {
                _basket.Add(AppointmentTreatments.Get(appt.TreatmentID), 1, 
                    User.UserGet(appt.EmployeeID), 
                    AppController.LocalCountry.PriceColumn);
                _basket.User = User.UserGet(appt.UserID);

                foreach (Appointment apptChild in appt.ChildAppointments)
                {
                    // only adjust child appointments if their status matches the parent, 
                    // i.e. child appt not cancelled parent appt is still on
                    if (apptChild.Status == appt.Status)
                    {
                        _basket.Add(AppointmentTreatments.Get(apptChild.TreatmentID), 1,
                            User.UserGet(apptChild.EmployeeID), AppController.LocalCountry.PriceColumn);
                        apptChild.Status = Enums.AppointmentStatus.Completed;
                        apptChild.Save(AppController.ActiveUser);
                    }
                }

                BuildBasket(false);
            }

            appt.Status = Enums.AppointmentStatus.Completed;
            appt.Save(AppController.ActiveUser);
            lvAppointments.Items.Remove(lvAppointments.SelectedItems[0]);
            SetButtonStatus(null);
            DoRefresh();
        }

        private void lstAppointments_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            Brush brush;

            //get current appointment
            int apptID = Convert.ToInt32(lvAppointments.Items[e.Index].ToString());

            Appointment appt = _appointments.Find(apptID);

            switch (appt.Status)
            {
                case Enums.AppointmentStatus.Requested: //requested
                    brush = new SolidBrush(Color.FromArgb(0, 153, 204));
                    break;
                case Enums.AppointmentStatus.Confirmed: //confirmed
                    brush = new SolidBrush(Color.FromArgb(102, 255, 102));
                    break;
                case Enums.AppointmentStatus.Arrived: //arrived
                    brush = new SolidBrush(Color.FromArgb(255, 153, 0));
                    break;
                default:
                    brush = new SolidBrush(Color.White);
                    break;
            }

            // Fill the background
            e.Graphics.FillRectangle(brush, e.Bounds);

            Font font = new System.Drawing.Font(e.Font.FontFamily, e.Font.SizeInPoints, 
                (e.State & DrawItemState.Selected) > 0 ? FontStyle.Bold : FontStyle.Regular);

            string itemText = String.Format(LanguageStrings.AppTillAppointment, appt.UserName, 
                Shared.Utilities.DoubleToTime(appt.StartTime), appt.EmployeeName);

            // Display the text using the default font and with black foreground
            e.Graphics.DrawString(itemText, font, Brushes.Black, e.Bounds.X + 5, e.Bounds.Y + 2);
        }

        private void lstAppointments_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
        }

        private void lvAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get current appointment
            if (lvAppointments.SelectedItems.Count == 0)
                return;

            Appointment appt = (Appointment)lvAppointments.SelectedItems[0].Tag;
            SetButtonStatus(appt);
        }

        #endregion lstAppointments Private Methods

        #endregion Appointments

        #region Products

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildProducts();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            BuildProducts();
        }

        private void LoadProductTypes()
        {
            cmbProductType.Items.Clear();

            // the following is a bit slow on LOTS of products
            //cmbProductType.Items.Add(new ProductCostType(-1, LanguageStrings.AppAll));

            foreach (ProductCostType item in ProductCostTypes.Get())
            {
                cmbProductType.Items.Add(item);
            }

            cmbProductType.SelectedIndex = 0;
        }

        private void BuildProductList()
        {
            lstProducts.BeginUpdate();
            try
            {
                flowLayoutProducts.Controls.Clear();
                lstProducts.Items.Clear();
                WaitInputDialog.UpdateWaitScreen(LanguageStrings.AppProductsLoading);
                //splash.Update(_Products.Count);
                int I = 1;
                ProductCostType prodCostType = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];

                foreach (Product product in _products)
                {
                    WaitInputDialog.UpdateWaitScreen(String.Format(LanguageStrings.AppProductLoadingName, product.Name), I);

                    foreach (ProductCost cost in product.ProductCosts)
                    {
                        BasketProductButton button = new BasketProductButton();
                        button.Product = cost;
                        button.AddProductToBasket += button_AddProductToBasket;
                        _productButtons.Add(button);

                        if (prodCostType.ID == -1 || cost.ProductCostType.ID == prodCostType.ID)
                        {
                            lstProducts.Items.Add(cost);
                            ShowBasketButton(cost);
                        }
                    }

                    I++;
                }
            }
            finally
            {
                lstProducts.EndUpdate();
            }
        }

        private void button_AddProductToBasket(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                BasketProductButton button = (BasketProductButton)sender;

                BasketItem newBasketItem = _basket.Add(button.Product, 1, 
                    AppController.LocalSettings.TillDefaultUserSystem ? AppController.DefaultSystemUser : AppController.ActiveUser, 
                    AppController.LocalCountry.PriceColumn);

                FindBasketItem(newBasketItem);

                BuildBasket(true);
                flowLayoutProducts.Focus();
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void button_AddTreatmentToBasket(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                BasketTreatmentButton button = (BasketTreatmentButton)sender;

                BasketItem newBasketItem = _basket.Add(button.Treatment, 1, 
                    AppController.LocalSettings.TillDefaultUserSystem ? AppController.DefaultSystemUser : AppController.ActiveUser,
                    AppController.LocalCountry.PriceColumn);

                FindBasketItem(newBasketItem);

                BuildBasket(true);
                flowLayoutTreatments.Focus();
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void BuildProducts()
        {
            lstProducts.BeginUpdate();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                flowLayoutProducts.SuspendDrawing();
                try
                {
                    ProductCostType type = (ProductCostType)cmbProductType.Items[cmbProductType.SelectedIndex];

                    lstProducts.Items.Clear();
                    flowLayoutProducts.Controls.Clear();

                    foreach (Product product in _products)
                    {
                        foreach (ProductCost cost in product.ProductCosts)
                        {
                            if (CanShowItem(product, cost, type))
                            {
                                lstProducts.Items.Add(cost);
                                ShowBasketButton(cost);
                            }
                        }
                    }

                }
                finally
                {
                    flowLayoutProducts.ResumeDrawing();
                }

            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                lstProducts.EndUpdate();
            }
        }

        private ShoppingBasketItem FindBasketItem(BasketItem basketItem)
        {
            ShoppingBasketItem Result = null;

            foreach (ShoppingBasketItem basket in pnlBasket.Controls)
            {
                if (basket.Item.ItemID == basketItem.ItemID)
                {
                    Result = basket;
                    Result.UpdateQuantity(basketItem.Quantity);
                    break;
                }
            }

            if (Result == null)
            {
                Result = new ShoppingBasketItem(_staffMembers, 
                    AppController.LocalSettings.TillDefaultUserSystem ? AppController.DefaultSystemUser : AppController.ActiveUser);
                Result.IgnoreCostMultiplier = _basket.IgnoreCostMultiplier;

                Result.Basket = _basket;
                Result.Item = basketItem;
                Result.Updated += new EventHandler(itm_Updated);
                Result.Deleted += new EventHandler(itm_Deleted);
                pnlBasket.Controls.Add(Result);
            }

            ResizeBasketItems();

            return (Result);
        }


        /// <summary>
        /// Determines wether the item is shown
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        private bool CanShowItem(Product product, ProductCost cost, ProductCostType type)
        {
            bool Result = false;

            if (type.ID == -1 || cost.ProductCostType.ID == type.ID)
            {
                if (product.Name.ToLower().Contains(txtFilter.Text.ToLower()) ||
                    cost.Size.ToLower().Contains(txtFilter.Text.ToLower()))
                {
                    Result = true;
                }
            }

            if (!cost.ProductCostType.HasStock())
                return (Result);

            if (Result && AppController.LocalSettings.HideOutOfStockProducts &&
                (product.OutOfStock || cost.OutOfStock))
            {
                Result = false;
            }

            if (Result && AppController.LocalSettings.HideProductsWithZeroStock &&
                (cost.GetStockLevel(Library.DAL.DALHelper.StoreID) < 1))
            {
                Result = false;
            }

            return (Result);
        }

        private void ShowBasketButton(ProductCost cost)
        {
            foreach (BasketProductButton button in _productButtons)
            {
                if (button.Product.ID == cost.ID)
                {
                    flowLayoutProducts.Controls.Add(button);
                    break;
                }
            }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddtoBasket.Enabled = (lstProducts.SelectedItems.Count > 0) || 
                (lstTreatments.SelectedItems.Count > 0);
        }

        private void lstProducts_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCost cost = (ProductCost)e.ListItem;

            //switch (cost.ProductCostType)
            //{
            //    case ProductCostType.BlackLabelBottlesAndJars:
            //    case ProductCostType.BlackLabel:
                    e.Value = String.Format(StringConstants.PRODUCT_COST_SIZE_TYPE,
                        cost.ProductCostType.Description, 
                        cost.Product.Name, cost.Size);
            //        break;
            //    default:
            //        e.Value = String.Format(StringConstants.PRODUCT_COST_SIZE_DEFAULT, 
            //            cost.Product.Name, cost.Size);
            //        break;
            //}

        }

        #endregion Products

        #region Treatments

        private void BuildTreatments()
        {
            lstTreatments.BeginUpdate();
            try
            {
                WaitInputDialog.UpdateWaitScreen(LanguageStrings.AppTreatmemtsLoading);
                lstTreatments.Items.Clear();
                _treatmentButtons.Clear();
                flowLayoutTreatments.Controls.Clear();

                AppointmentTreatments treatments = AppointmentTreatments.Get();
                //splash.Update(treatments.Count);
                int I = 1;

                foreach (AppointmentTreatment treatment in treatments)
                {
                    BasketTreatmentButton button = new BasketTreatmentButton();
                    button.Treatment = treatment;
                    button.AddTreatmentToBasket += button_AddTreatmentToBasket;
                    _treatmentButtons.Add(button);

                    WaitInputDialog.UpdateWaitScreen(String.Format(LanguageStrings.AppTreatmentLoadingName, treatment.Name), I);

                    if (treatment.IsActive)
                    {
                        flowLayoutTreatments.Controls.Add(button);
                        lstTreatments.Items.Add(treatment);
                    }

                    I++;
                }
            }
            finally
            {
                lstTreatments.EndUpdate();
            }
        }

        private void lstTreatments_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentTreatment treatment = (AppointmentTreatment)e.ListItem;

            e.Value = treatment.Name;
        }

        private void lstTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddtoBasket.Enabled = (lstProducts.SelectedItems.Count > 0) || 
                (lstTreatments.SelectedItems.Count > 0);
        }

        #endregion Treatments

        #region Users

        private void cmbStaffMembers_Format(object sender, ListControlConvertEventArgs e)
        {
            User user = (User)e.ListItem;

            e.Value = user.UserName;
        }

        private void cmbStaffMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void BuildStaffList()
        {
            _staffMembers = User.StaffMembers(false);
        }

        #endregion Users

        #region Form

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductCostType item = (ProductCostType)e.ListItem;
            e.Value = item.Description;
        }

        public void OnFocus(EventArgs e)
        {
            _basket.Reset(POS.Base.Classes.AppController.LocalCurrency.PriceColumn);

            statusStripSummary.Visible = AppController.LocalSettings.TillShowSummaryBar;
            DoRefresh();
            ResizeEnd(this, e);
        }

        private void ResizeBasketItems()
        {
            foreach (ShoppingBasketItem basket in pnlBasket.Controls)
            {
                if (pnlBasket.VerticalScroll.Visible)
                    basket.Width = pnlBasket.Width - 30;
                else
                    basket.Width = pnlBasket.Width - 10;
            }
        }

        private void DoRefresh()
        {
            btnClearBasket.Enabled = _order == null && _basket == null ? false : _basket.HasItems();
            btnAddtoBasket.Enabled = (lstProducts.SelectedItems.Count > 0) || 
                (lstTreatments.SelectedItems.Count > 0);
        }

        #endregion form

        #region Basket

        void _Basket_BasketUpdated(object sender, EventArgs e)
        {
            btnMarkAsPaid.Enabled = (_basket.HasItems());// _Basket.SubTotalMinusVAT > 0.00m;
            btnClearBasket.Enabled = _basket.HasItems();

            POS.Base.Classes.PluginManager.RaiseEvent(
                new Base.Plugins.NotificationEventArgs(StringConstants.PLUGIN_EVENT_UPDATE_STATUS_BAR));

            BuildBasket(true);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstTreatments.ClearSelected();
            lstProducts.ClearSelected();
        }

        private void btnAddtoBasket_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selected = new ListBox.SelectedObjectCollection(lstProducts);

            foreach (Object obj in selected)
            {
                ProductCost costitem = (ProductCost)obj;

                _basket.Add(costitem, 1, AppController.LocalSettings.TillDefaultUserSystem ? AppController.DefaultSystemUser : AppController.ActiveUser, AppController.LocalCountry.PriceColumn);
            }

            selected = new ListBox.SelectedObjectCollection(lstTreatments);

            foreach (Object obj in selected)
            {
                AppointmentTreatment costitem = (AppointmentTreatment)obj;

                _basket.Add(costitem, 1, 
                    AppController.LocalSettings.TillDefaultUserSystem ? AppController.DefaultSystemUser : AppController.ActiveUser,
                    AppController.LocalCountry.PriceColumn);
            }

            btnClearAll_Click(sender, e);
            BuildBasket(false);
        }

        private void BuildBasket(bool TotalsOnly)
        {
            pnlBasket.SuspendDrawing();
            try
            {
                if (!TotalsOnly)
                {

                    pnlBasket.Controls.Clear();

                    foreach (BasketItem item in _basket.Items)
                    {
                        ShoppingBasketItem itm = new ShoppingBasketItem(_staffMembers, AppController.ActiveUser);
                        itm.IgnoreCostMultiplier = _basket.IgnoreCostMultiplier;

                        itm.Basket = _basket;
                        itm.Item = item;
                        itm.Updated += new EventHandler(itm_Updated);
                        itm.Deleted += new EventHandler(itm_Deleted);
                        pnlBasket.Controls.Add(itm);
                    }
                }

                DoRefresh();

                // update labels
                lblPostageTotal.Text = _basket.ShippingCost;
                lblSubtotalValue.Text = _basket.SubTotalMinusVATCost;
                lblVATTotal.Text = _basket.VATCost;
                lblTotalTotal.Text = _basket.TotalCost;
                lblVAT.Text = String.Format(LanguageStrings.AppTillTaxValue, _basket.VATRate);
                lblDiscountTotal.Text = _basket.DiscountCost;

                switch (_basket.DiscountType)
                {
                    case BasketDiscountType.Percentage:
                        lblDiscount.Text = String.Format(LanguageStrings.AppDiscountPercent,
                            _basket.Discount, _basket.DiscountCouponName);
                        break;
                    case BasketDiscountType.Value:
                        lblDiscount.Text = String.Format(LanguageStrings.AppDiscountValue,
                            AppController.LocalCountry.CurrencySymbol, _basket.Discount, _basket.DiscountCouponName);
                        break;
                    case BasketDiscountType.Coupon:
                        if (_basket.CouponUsed.VoucherType == Enums.InvoiceVoucherType.Percent)
                            lblDiscount.Text = String.Format(LanguageStrings.AppDiscountPercent,
                                _basket.CouponUsed.Discount, _basket.CouponUsed.Name);
                        else
                            lblDiscount.Text = String.Format(LanguageStrings.AppDiscountValue,
                                AppController.LocalCountry.CurrencySymbol, _basket.CouponUsed.Discount, _basket.CouponUsed.Name);
                        break;
                }

                // update status bar
                toolStripStatusTotal.Text = String.Format(LanguageStrings.AppTillTotalsTotal, _basket.TotalCost);
                toolStripStatusSubTotal.Text = String.Format(LanguageStrings.AppTillTotalsSub, _basket.SubTotalMinusVATCost);
                toolStripStatusTax.Text = String.Format(LanguageStrings.AppTillTotalsTax, _basket.VATCost);
                toolStripStatusPostage.Text = String.Format(LanguageStrings.AppTillTotalsPost, _basket.ShippingCost);
                toolStripStatusDiscount.Text = String.Format(LanguageStrings.AppTillTotalsDiscount, _basket.DiscountCost);

                ResizeBasketItems();
            }
            finally
            {
                pnlBasket.ResumeDrawing();
            }
        }

        void itm_Deleted(object sender, EventArgs e)
        {
            ShoppingBasketItem deletedItem = (ShoppingBasketItem)sender;

            deletedItem = FindBasketItem(deletedItem.Item);
            pnlBasket.Controls.Remove(deletedItem);
            ResizeBasketItems();
            BuildBasket(false);

            string resultText = String.Empty;

            _basket.ValidateCouponCode(_basket.DiscountCouponName, ref resultText);

        }

        private void itm_Updated(object sender, EventArgs e)
        {
            BuildBasket(true);

            string resultText = String.Empty;

            _basket.ValidateCouponCode(_basket.DiscountCouponName, ref resultText);

        }

        private void btnMarkAsPaid_Click(object sender, EventArgs e)
        {
            if (_basket.Items.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppTillBasketEmpty);
                return;
            }
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //select user if not yet selected
                if (_basket.User == null)
                {
                    SelectUser form = new SelectUser(_basket.User, true);
                    try
                    {
                        if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            _basket.User = form.SelectedUser;
                        }
                        else
                            return;
                    }
                    finally
                    {
                        form.Dispose();
                        form = null;
                    }
                }


                MarkAsPaidForm frm = new MarkAsPaidForm(true);
                try
                {
                    frm.TotalToPay = _basket.TotalAmount;
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Vouchers vouchers = new Vouchers();

                        if (!AddVoucherCodes(vouchers))
                            return;

                        Vouchers.SellVouchers(vouchers);

                        Order order = MarkAsPaid(frm.PaymentStatus, frm.AdditionalPaymentInformation);

                        if (order == null)
                        {

                        }
                        else
                        {
                            if (frm.PaymentStatus.ID == PaymentStatuses.Get(StringConstants.PAYMENT_TYPE_SPLIT).ID)
                            {
                                frm.ProcessSplitPayment(order);
                            }
                        }
                    }
                }
                finally
                {
                    frm.Dispose();
                    frm = null;
                }
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppTillErrorTakingPayment, err.Message));
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, sender, e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool AddVoucherCodes(Vouchers vouchers)
        {
            Vouchers Result = new Vouchers();

            foreach (BasketItem item in _basket.Items)
            {
                if (item.ItemType == ProductCostItemType.Voucher)
                {
                    for (int i = 1; i <= item.Quantity; i++)
                    {
                        VoucherForm frm = new VoucherForm(true, _basket.User, item.Price);
                        try
                        {
                            frm.Discount = item.Price;

                            if (frm.ShowDialog(this) == DialogResult.OK)
                                vouchers.Add(new Voucher(frm.Code, item.Price, _basket.User, frm.Expires));
                            else
                                return (false);
                        }
                        finally
                        {
                            frm.Dispose();
                            frm = null;
                        }
                    }
                }
            }

            return (true);
        }

        private Order MarkAsPaid(PaymentStatus status, string additionalInfo)
        {
            Order Result = null;
            try
            {
                _order = _basket.ConvertToOrder(PaymentStatuses.Get(StringConstants.PAYMENT_TYPE_SALON_NOT_PAID),
                    AppController.ActiveUser.Email, StringConstants.ORDER_LOCATION_HOST,
                    AppController.LocalSettings.CustomCulture);
                _order.Paid(AppController.ActiveUser, status, additionalInfo, String.Empty);
                Invoice inv = Invoices.Get(_order);
                inv.SetProcessStatus(AppController.ActiveUser, ProcessStatus.Dispatched);
                Result = _order;

                if (ShowQuestion(LanguageStrings.AppTillPrintInvoice, 
                    LanguageStrings.AppTillPrintInvoiceQuestion))
                {
                    PDFInvoice invPDF = new PDFInvoice(inv, AppController.LocalSettings.InvoiceHeaderRight,
                        AppController.LocalSettings.InvoiceFooter, AppController.LocalSettings.InvoiceAddress,
                        AppController.LocalSettings.InvoiceVATRegistrationNumber, AppController.LocalSettings.CustomCulture,
                        Library.DAL.DALHelper.HideVATOnWebsiteAndInvoices,
                        AppController.LocalSettings.InvoiceShowProductDiscount, String.Empty, String.Empty, 1,
                        AppController.LocalSettings.InvoicePrefix);
                    invPDF.Print();
                }
            }
            catch (Exception error)
            {
                if (error.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowInformation(LanguageStrings.AppTillLockConflict, LanguageStrings.AppTillLockConflictMessage);
                }
                else if (error.Message.Contains(StringConstants.ERROR_STOCK_ZERO))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorStockZero);
                }
                else
                    throw;
            }
            finally
            {
                btnClearBasket_Click(this, EventArgs.Empty);
            }

            PluginManager.RaiseEvent(StringConstants.PLUGIN_EVENT_ORDER_DISPATCHED);

            return (Result);
        }

        private void btnClearBasket_Click(object sender, EventArgs e)
        {
            _basket.ApplyDiscount(0, String.Empty);
            _basket.User = null;
            _basket.Empty();
            _order = null;
            BuildBasket(false);
            DoRefresh();
        }

        #endregion Basket

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            TillDiscountForm frm = new TillDiscountForm();
            try
            {
                frm.Basket = _basket;
                frm.ShowDialog(this);
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            BuildBasket(false);
        }

        private void pnlTodaysAppointments_AfterCollapse(object sender, EventArgs e)
        {
            pnlCurrentSale.Left = pnlTodaysAppointments.Left + pnlTodaysAppointments.CollapsedSize + 5;
            pnlCurrentSale.Width = this.Width - (pnlCurrentSale.Left + 25);
        }

        private void pnlTodaysAppointments_AfterExpand(object sender, EventArgs e)
        {
            pnlCurrentSale.Left = pnlTodaysAppointments.Width + 15;
            pnlCurrentSale.Width = this.Width - (pnlCurrentSale.Left + 25);
        }

        private void pnlCurrentSale_BeforeCollapse(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void pnlCurrentSale_Resize(object sender, EventArgs e)
        {
            splitBasket.Left = 5;
            splitBasket.Width = pnlCurrentSale.Width - 10;
            ResizeBasketItems();
        }

        public void ResizeEnd(object sender, EventArgs e)
        {
            pnlCurrentSale.Height = Parent.Height - 6;
            pnlTodaysAppointments.Height = Parent.Height - 6;
            splitBasket.Left = 3;
            splitBasket.Top = 3;
            splitBasket.Width = pnlCurrentSale.Width - 6;
            splitBasket.Height = pnlCurrentSale.Height - (pnlCurrentSale.CollapsedSize + 6);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush txt_brush;
            Brush box_brush;
            Pen box_pen;

            // We draw in the TabRect rather than on e.Bounds
            // so we can use TabRect later in MouseDown.
            Rectangle tabHeaderRect = tabSaleItems.GetTabRect(e.Index);

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
                tabSaleItems.TabPages[e.Index].Text,
                tabSaleItems.Font,
                txt_brush,
                layout_rect,
                _tabStringFormat);
        }

        #endregion Private Methods
    }
}
