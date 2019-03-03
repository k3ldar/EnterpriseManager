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
 *  File: ImagesTab.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using Languages;
using SharedBase.Utils;
using Plasmoid.Extensions;

using POS.Base.Classes;
using POS.Base.Plugins;
using POS.Base;

using SharedControls.Classes;

#pragma warning disable IDE1006
#pragma warning disable IDE0017

namespace POS.Images.Controls
{
    public partial class ImagesTab : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private bool _showWebsiteData;
        private StringFormat _headerStringFormat;
        private Font _headerFont;
        private PictureBox _selectedPicture;

        #endregion Private Members

        #region Constructors

        public ImagesTab()
        {
            InitializeComponent();

            NotificationEventArgs args = new NotificationEventArgs(
                StringConstants.PLUGIN_EVENT_WEBSITE_MODULE, null);
            PluginManager.RaiseEvent(args);

            _showWebsiteData = (bool)args.Result;
            _headerFont = new Font(this.Font.FontFamily, 9.0f);
            _headerStringFormat = new StringFormat();
            _headerStringFormat.Alignment = StringAlignment.Center;
            _headerStringFormat.LineAlignment = StringAlignment.Center;

            LoadImageData();
            UpdateUI();
        }

        #endregion Constuctors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            selectImageFiles.Filter = String.Format(StringConstants.IMAGE_SEARCH_FILTER, 
                LanguageStrings.AppAll);

            btnSave.Text = LanguageStrings.Save;
            lblNewFileName.Text = LanguageStrings.AppImagesFileNameNew;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadImageData()
        {
            foreach (string imageType in Enum.GetNames(typeof(ImageTypes)))
            {
                LoadFolder((ImageTypes)Enum.Parse(typeof(ImageTypes), imageType));
            }

            tvImages.SelectedNode = tvImages.Nodes[0];
            tvImages.SelectedNode.Expand();
        }

        private void LoadFolder(ImageTypes imageType)
        {
            TreeNode node = new TreeNode(EnumTranslations.Translate(imageType));
            string imageRoot = AppController.POSFolder(imageType);
            node.Tag = new ImageData(imageType, imageRoot);
            tvImages.Nodes.Add(node);

            if (!Directory.Exists(imageRoot))
                Directory.CreateDirectory(imageRoot);

            LoadFiles(node, imageRoot);

            if (node.Nodes.Count > 0)
                node.Expand();
        }

        private void LoadFiles(TreeNode node, string path)
        {
            string[] files = Directory.GetFiles(path, StringConstants.IMAGE_SEARCH);

            foreach (string file in files)
            {
                TreeNode newNode = new TreeNode(Path.GetFileName(file));
                newNode.Tag = new ImageData(file);
                newNode.SelectedImageIndex = 2;
                newNode.ImageIndex = 2;
                node.Nodes.Add(newNode);
            }
        }

        #region Node Events

        private void tvImages_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ImageData imgData = (ImageData)tvImages.SelectedNode.Tag;

                pnlRoot.Visible = imgData.Type == NodeTypeImage.Folder;
                pnlImage.Visible = imgData.Type == NodeTypeImage.Image;

                if (pnlImage.Visible)
                {
                    pictureImage.ImageLocation = (string)imgData.ImageName;
                }

                flowImage.Controls.Clear();
                flowImages.Controls.Clear();
                txtFileName.Text = String.Empty;
                _selectedPicture = null;
                UpdateUI();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void tvImages_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }

        private void tvImages_AfterCollapse(object sender, TreeViewEventArgs e)
        {

        }

        private void tvImages_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (tvImages.SelectedNode == null)
                return;

            ImageData imgData = (ImageData)tvImages.SelectedNode.Tag;

            if (imgData.Type == NodeTypeImage.Folder)
            {
                // is the user editing images
                if (flowImages.Controls.Count > 0)
                {
                    e.Cancel = !ShowQuestion(LanguageStrings.AppImages, 
                        LanguageStrings.AppImagesLoseData);
                }
            }
        }

        #endregion Node Events

        #region Drag Drop Panel

        private void pnlDragDrop_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = pnlDragDrop.ClientRectangle;

            e.Graphics.FillRectangle(Brushes.White, rect);
            rect.Inflate(-6, -6);

            using (Pen borderPen = new Pen(Brushes.DarkGray, 5))
            {
                borderPen.DashStyle = DashStyle.Dash;
                borderPen.Width = 2;
                e.Graphics.DrawRoundedRectangle(borderPen, rect, 3);
            }

            // draw header text
            e.Graphics.DrawString(
                LanguageStrings.AppImageDropOrSelect,
                _headerFont,
                Brushes.Black,
                rect,
                _headerStringFormat);
        }

        private void pnlDragDrop_DoubleClick(object sender, EventArgs e)
        {
            if (selectImageFiles.ShowDialog(this) == DialogResult.OK)
            {
                ProcessFiles(selectImageFiles.FileNames);
            }
        }

        private void ProcessFiles(string[] allFiles)
        {
            this.Cursor = Cursors.WaitCursor;
            flowImages.SuspendDrawing();
            try
            {
                flowImages.Controls.Clear();

                ImageData imgData = (ImageData)tvImages.SelectedNode.Tag;

                foreach (string file in allFiles)
                {
                    lstMessages.SelectedIndex = lstMessages.Items.Add(String.Format(
                        LanguageStrings.AppImagesProcessingFile, file));

                    string path = System.IO.Path.GetDirectoryName(file);

                    if (path.ToLower() == imgData.Folder.ToLower())
                    {
                        lstMessages.SelectedIndex = lstMessages.Items.Add(
                            LanguageStrings.AppImagesProcessExists);
                        continue;
                    }

                    string fileNoExt = System.IO.Path.GetFileNameWithoutExtension(file);

                    if (fileNoExt.EndsWith(StringConstants.IMAGE_DEFAULT))
                    {
                        lstMessages.SelectedIndex = lstMessages.Items.Add(
                            LanguageStrings.AppImagesProcessInvalidName);
                        continue;
                    }

                    string fileExt = System.IO.Path.GetExtension(file);

                    int[,] sizes = imgData.ImageSizes;

                    Bitmap image = null;
                    try
                    {
                        image = new Bitmap(file);
                        string destinationFile = imgData.Folder +
                            fileNoExt + StringConstants.IMAGE_DEFAULT +
                            fileExt;

                        // image must be at least as big as the biggest sized image
                        int width = sizes[0, 0];
                        int height = sizes[0, 1];

                        if (image.Width < width || (height > 0 && image.Height < height))
                        {
                            lstMessages.SelectedIndex = lstMessages.Items.Add(
                                String.Format(LanguageStrings.AppImagesProcessTooSmall,
                                width, height));
                            continue;
                        }

                        PictureBox newImage = new PictureBox();
                        Bitmap bmp = new Bitmap(file);
                        newImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        newImage.Width = Shared.Utilities.CheckMinMax(width, 320, 320);
                        newImage.Height = LibUtils.ResizeKeepAspect(new Size(bmp.Width, bmp.Height), 320).Height;
                        newImage.Image = bmp;
                        newImage.ContextMenuStrip = contextMenuImages;
                        newImage.BorderStyle = BorderStyle.FixedSingle;
                        newImage.Click += NewImage_Click;
                        flowImages.Controls.Add(newImage);
                        newImage.Tag = file;
                        lstMessages.SelectedIndex = lstMessages.Items.Add(String.Format(
                            LanguageStrings.AppImagesProcessAccepted, Path.GetFileName(file)));
                    }
                    catch (Exception err)
                    {
                        lstMessages.SelectedIndex = lstMessages.Items.Add(err.Message);
                    }
                    finally
                    {
                        if (image != null)
                            image.Dispose();

                        image = null;
                    }

                    // logo is special case, only 1 file
                    if (imgData.ImageType == ImageTypes.Logo)
                        break;
                }
            }
            finally
            {
                flowImages.ResumeDrawing();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void NewImage_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            flowImage.SuspendDrawing();
            try
            {
                _selectedPicture = (PictureBox)sender;
                flowImage.Controls.Clear();
                ImageData imgData = (ImageData)tvImages.SelectedNode.Tag;
                int[,] sizes = imgData.ImageSizes;

                for (int i = 0; i < sizes.Length / 2; i++)
                {
                    PictureBox selectedPicture = (PictureBox)sender;
                    Bitmap newImage = LibUtils.ResizeImage(selectedPicture.Image, 
                        sizes[i, 0], sizes[i, 1], imgData.ImageType != ImageTypes.Logo);
                    PictureBox newPicture = new PictureBox();
                    newPicture.Width = newImage.Width;
                    newPicture.Height = newImage.Height;
                    newPicture.BorderStyle = BorderStyle.FixedSingle;
                    newPicture.SizeMode = PictureBoxSizeMode.Normal;
                    newPicture.Image = newImage;
                    newPicture.Tag = selectedPicture.Tag;

                    if (imgData.ImageType == ImageTypes.Logo)
                    {
                        txtFileName.Text = ImageTypes.Logo.ToString();
                        txtFileName.Enabled = false;
                    }
                    else
                    {
                        string fileName =  (string)selectedPicture.Tag;
                        txtFileName.Text = Path.GetFileNameWithoutExtension(fileName);
                        txtFileName.Enabled = true;
                    }

                    flowImage.Controls.Add(newPicture);
                }
            }
            catch (Exception err)
            {
                lstMessages.SelectedIndex = lstMessages.Items.Add(err.Message);
            }
            finally
            {
                UpdateUI();
                flowImage.ResumeDrawing();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void pnlDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pnlDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                ProcessFiles(files);
            }
        }

        #endregion Drag Drop Panel

        #region Context Menu

        private void contextMenuImages_Opening(object sender, CancelEventArgs e)
        {

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point pt = flowImages.PointToClient(Cursor.Position);

            if (flowImages.GetChildAtPoint(pt) != null)
            {
                PictureBox box = (PictureBox)flowImages.GetChildAtPoint(pt);
                flowImages.Controls.Remove(box);
            }
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowImages.Controls.Clear();
        }

        private void processAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion Context Menu

        private void UpdateUI()
        {
            pnlSaveImages.Enabled = _selectedPicture != null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ImageData imgData = (ImageData)tvImages.SelectedNode.Tag;
                int[,] sizes = imgData.ImageSizes;
                string file = imgData.FixFileName(txtFileName.Text);
                string path = Path.GetDirectoryName(file);
                string fileNoExt = Path.GetFileNameWithoutExtension(file).ToUpper();
                string fileExt = StringConstants.FILE_EXTENSION_JPG;

                Bitmap originalImage = new Bitmap((string)_selectedPicture.Tag);
                try
                {
                    // save original
                    Bitmap newImage = new Bitmap(originalImage, new Size(originalImage.Width, originalImage.Height));
                    try
                    {
                        string destinationFile = imgData.Folder +
                            fileNoExt + StringConstants.IMAGE_DEFAULT +
                            fileExt;

                        bool exists = File.Exists(destinationFile);

                        if (exists && !ShowQuestion(LanguageStrings.AppImageFileExists, LanguageStrings.AppImageFileReplace))
                        {
                            return;
                        }

                        newImage.Save(destinationFile);

                        if (!exists)
                        {
                            TreeNode newNode = new TreeNode(fileNoExt + StringConstants.IMAGE_DEFAULT + fileExt);
                            newNode.Tag = new ImageData(destinationFile);
                            newNode.SelectedImageIndex = 2;
                            newNode.ImageIndex = 2;
                            tvImages.SelectedNode.Nodes.Add(newNode);
                        }
                    }
                    finally
                    {
                        newImage.Dispose();
                        newImage = null;
                    }

                    imgData.GenerateImages((string)_selectedPicture.Tag);
                }
                finally
                {
                    originalImage.Dispose();
                    originalImage = null;
                }
            }
            catch (Exception err)
            {
                lstMessages.SelectedIndex = lstMessages.Items.Add(err.Message);
            }
            finally
            {
                flowImage.Controls.Clear();
                flowImages.Controls.Remove(_selectedPicture);
                _selectedPicture = null;
                UpdateUI();
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion Private Methods
    }
}
