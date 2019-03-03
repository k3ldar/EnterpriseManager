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
 *  File: BaseHomeTabButton.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Languages;

using POS.Base.Classes;
using POS.Base.Plugins;
using SharedControls.Classes;
using Plasmoid.Extensions;

namespace POS.Base.Controls
{
    public partial class BaseHomeTabButton : BaseControl, IComparable<BaseHomeTabButton>
    {
        #region Private Members

        private const int HEADER_HEIGHT = 46;


        private HomeCard _homeTab;
        private TabControl _tabControl;
        private TabPage _tabPage;
        private int _notifications;
        private byte _notificationUpdateStage;
        private bool _isGrowing;
        private Image _scaledImage;

        private StringFormat _dropStringFormat;
        private Font _dropFont;
        private Font _notificationFont;

        private Rectangle _imageRect = new Rectangle(new Point(20, 60), new Size(110, 110));
        private bool _hoverOverButton = false;
        private int _sortOrder = int.MinValue;

        #endregion Private Members

        #region Constructors

        public BaseHomeTabButton()
        {
            InitializeComponent();
            this.ResizeRedraw = true;

            Size = new System.Drawing.Size(150, 194);

            _dropFont = new Font(this.Font.FontFamily, 9.0f);
            _dropStringFormat = new StringFormat();
            _dropStringFormat.Alignment = StringAlignment.Center;
            _dropStringFormat.LineAlignment = StringAlignment.Center;

            _notificationFont = new Font(this.Font.FontFamily, 7.5f);
        }

        public BaseHomeTabButton(HomeCard button, TabControl tabControl)
            : this()
        {
            _homeTab = button;
            _tabControl = tabControl;

            if (!_homeTab.OwnerDrawn())
                _scaledImage = ScaleImage(_homeTab.ButtonImage(), 110, 110);

            _homeTab.HomeTabButton = this;

            //BackGroundLoader loader = new BackGroundLoader(_homeTab);
            //loader.ThreadFinishing += Loader_ThreadFinishing;
            //Shared.Classes.ThreadManager.ThreadStart(loader,
            //    String.Format("Background Loader {0}", _homeTab.GetName()), 
            //    System.Threading.ThreadPriority.Highest);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // draw the header
            Rectangle header = this.ClientRectangle;
            header.Height = HEADER_HEIGHT;

            e.Graphics.FillRectangle(_homeTab.ButtonHeaderColor(), header);
            header.Inflate(-2, -2);

            // draw a border
            e.Graphics.DrawRectangle(new Pen(_homeTab.ButtonBorderColor(), (float)_homeTab.ButtonBorderWidth()),
                this.ClientRectangle);

            // fill header
            using (LinearGradientBrush aGB = new LinearGradientBrush(header,
                _homeTab.ButtonFromColor(), 
                _homeTab.ButtonToColor(), 
                _homeTab.ButtonGradientMode()))
            {
                e.Graphics.FillRectangle(aGB, header);
            }

            // draw header text
            e.Graphics.DrawString(
                _homeTab.GetName(),
                _dropFont,
                Brushes.Black,
                header,
                _dropStringFormat);


            if (_homeTab.OwnerDrawn())
            {
                Rectangle ownerRect = new Rectangle(5, HEADER_HEIGHT + 5, 140, 134);
                PaintEventArgs args = new PaintEventArgs(e.Graphics, ownerRect);
                _homeTab.Paint(args);
            }
            else
            {
                // draw the image
                e.Graphics.DrawImage(_scaledImage, new Point(20, 60));

                if (_hoverOverButton)
                {
                    using (Pen border = new Pen(_homeTab.ButtonBorderColor(), 3))
                    {
                        Rectangle borderRect = _imageRect;
                        borderRect.Inflate(3, 3);
                        e.Graphics.DrawRoundedRectangle(border, borderRect, 3);
                    }

                    if (!_imageRect.Contains(this.PointToClient(Cursor.Position)))
                    {
                        _hoverOverButton = false;
                    }
                }

                // if there are notifications, draw them here
                if (_notifications > 0)
                {
                    Rectangle circleRect = new Rectangle(
                        this.ClientRectangle.Right - 30,
                        this.ClientRectangle.Bottom - 30,
                        19, 19);
                    circleRect.Inflate(_notificationUpdateStage, _notificationUpdateStage);
                    e.Graphics.FillEllipse(_homeTab.GetNotificationColor(), circleRect);

                    // draw number of notifications
                    e.Graphics.DrawString(
                        _notifications.ToString(),
                        _notificationFont,
                        Brushes.White,
                        circleRect,
                        _dropStringFormat);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _hoverOverButton = false;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (_imageRect.Contains(this.PointToClient(Cursor.Position)))
                imageClick();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_imageRect.Contains(this.PointToClient(Cursor.Position)))
            {
                if (!_hoverOverButton)
                {
                    _hoverOverButton = true;
                    Parent.Invalidate(true);
                }
            }
            else
            {
                if (_hoverOverButton)
                {
                    _hoverOverButton = false;
                    Parent.Invalidate(true);
                }
            }
        }
        #endregion Overridden Methods

        #region Properties

        public HomeCard TabPage
        {
            get
            {
                return (_homeTab);
            }
        }

        /// <summary>
        /// Controls sort order, default to value set in HomeTab, otherwise custom value
        /// </summary>
        public int SortOrder
        {
            get
            {
                if (_sortOrder == int.MinValue)
                    _sortOrder = _homeTab.SortOrder();

                return (_sortOrder);
            }

            set
            {
                _sortOrder = value;
            }
        }

        /// <summary>
        /// Indicates the control is going to close
        /// </summary>
        public bool IsClosing { get; set; }


        public bool MouseOverHeader
        {
            get
            {
                Point mouseCoord = PointToClient(Cursor.Position);

                return (!mouseCoord.IsEmpty && mouseCoord.Y <= HEADER_HEIGHT);
            }
        }

        #endregion Properties

        #region Public Methods

        public void ForceClick()
        {
            imageClick();
        }

        public delegate void NotificationHandler(int count);
        public void ShowNotifications(int count)
        {
            if (this.IsDisposed || IsClosing)
                return;

            if (this.InvokeRequired)
            {
                NotificationHandler nh = new NotificationHandler(ShowNotifications);
                this.Invoke(nh, new object[] { count });
            }
            else
            {
                if (_notifications == count)
                    return;

                _notifications = count;
                _notificationUpdateStage = 1;
                _isGrowing = true;
                Invalidate();
            }
        }

        public delegate void UpdateNotificationHandler();
        public void UpdateNotification()
        {
            if (this.InvokeRequired)
            {
                if (this.IsDisposed || IsClosing)
                    return;

                try
                {
                    UpdateNotificationHandler eh = new UpdateNotificationHandler(UpdateNotification);
                    this.Invoke(eh, new object[] { });
                }
                catch (System.ComponentModel.InvalidAsynchronousStateException) { }
            }
            else
            {
                switch (_notificationUpdateStage)
                {
                    case 0:
                        _isGrowing = true;
                        break;
                    case 3:
                        _isGrowing = false;
                        break;
                }

                if (_isGrowing)
                    _notificationUpdateStage++;
                else
                    _notificationUpdateStage--;

                Invalidate();
            }
        }

        #endregion Public Methods

        #region Private Members

        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            if (image == null)
                return (new Bitmap(0, 0));

            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void Loader_ThreadFinishing(object sender, Shared.ThreadManagerEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Shared.ThreadManagerEventDelegate tmed = new Shared.ThreadManagerEventDelegate(Loader_ThreadFinishing);
                this.Invoke(tmed, new object[] { sender, e });
            }
            else
            {
                //newButton.Enabled = true;
            }
        }

        private void imageClick()
        {
            if (!_homeTab.ValidateSecurity(AppController.ActiveUser))
            {
                ShowError(LanguageStrings.InvalidPermission, LanguageStrings.InvalidPermissionGeneric);
                return;
            }

            if (!_homeTab.DisplayTab())
            {
                _homeTab.Execute();
                return;
            }

            _tabControl.Parent.Cursor = Cursors.WaitCursor;
            try
            {
                // does this control already exist in the tab items?
                foreach (TabPage tabPage in _tabControl.TabPages)
                {
                    if (tabPage.Tag != null)
                    {
                        HomeCard btn = (HomeCard)tabPage.Tag;

                        if (btn.GetName() == _homeTab.GetName())
                        {
                            _tabControl.SelectedTab = tabPage;
                            return;
                        }
                    }
                }

                if (_tabPage == null)
                {
                    BaseControl tabControl = _homeTab.TabContents();

                    if (tabControl == null)
                        return;

                    _tabPage = new TabPage(_homeTab.GetName());
                    _tabPage.Disposed += Page_Disposed;
                    _tabPage.Resize += Page_Resize;
                    _tabPage.Tag = _homeTab;
                    _tabPage.Controls.Add(tabControl);
                    tabControl.Width = _tabPage.Width - 6;
                    tabControl.Height = _tabPage.Height - 6;
                    tabControl.Top = 3;
                    tabControl.Left = 3;
                    tabControl.Initialise();
                }

                _tabControl.Parent.SuspendDrawing();
                try
                {
                    string settingName = String.Format(StringConstants.TRACKING_REFERENCE,
                        AppController.ActiveUser.ID.ToString(), _homeTab.GetName(), "P");
                    int userPosition = SharedBase.LibraryHelperClass.SettingsGetInt(settingName, 10000);

                    if (userPosition == 10000)
                    {
                        _tabControl.TabPages.Add(_tabPage);
                    }
                    else
                    {
                        userPosition = Shared.Utilities.CheckMinMax(userPosition, 1, _tabControl.TabPages.Count);
                        _tabControl.TabPages.Insert(userPosition, _tabPage);
                    }

                    _tabControl.SelectedTab = _tabPage;
                }
                finally
                {
                    _tabControl.Parent.ResumeDrawing();
                }
            }
            finally
            {
                _tabControl.Parent.Cursor = Cursors.Arrow;
            }
        }

        private void Page_Disposed(object sender, EventArgs e)
        {
            TabPage page = (TabPage)sender;

            page.Controls.Clear();
        }

        private void Page_Resize(object sender, EventArgs e)
        {
            TabPage page = (TabPage)sender;

            if (page.Controls.Count == 0)
                return;

            POS.Base.Controls.BaseControl ctl = (POS.Base.Controls.BaseControl)page.Controls[0];
            ctl.Width = page.Width - 6;
            ctl.Height = page.Height - 6;
            ctl.Top = 3;
            ctl.Left = 3;
        }

        public int CompareTo(BaseHomeTabButton other)
        {
            if (this.SortOrder < other.SortOrder)
                return (-1);
            else if (this.SortOrder > other.SortOrder)
                return (1);
            else
                return (0);
        }

        #endregion Private Members
    }

    //public class BackGroundLoader : Shared.Classes.ThreadManager
    //{
    //    #region Constructor

    //    public BackGroundLoader(HomeTab button)
    //        : base (button, new TimeSpan())
    //    {

    //    }

    //    #endregion Constructor

    //    #region Overridden Methods

    //    protected override bool Run(object parameters)
    //    {
    //        HomeTab tab = (HomeTab)parameters;
    //        tab.GetContents();
    //        return base.Run(false);
    //    }

    //    #endregion Overridden Methods
    //}
}
