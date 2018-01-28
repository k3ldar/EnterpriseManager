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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: ImageData.cs
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
using System.IO;

using Library.Utils;

namespace POS.Base.Classes
{
    public class ImageData
    {
        #region Constructors

        public ImageData(NodeTypeImage type)
        {
            Type = type;
        }

        public ImageData(ImageTypes imageType, string folder)
            : this(NodeTypeImage.Folder)
        {
            ImageType = imageType;
            Folder = Shared.Utilities.AddTrailingBackSlash(folder);
        }

        public ImageData(string image)
            : this (NodeTypeImage.Image)
        {
            ImageName = image;
        }

        #endregion Constructors

        #region Properties

        public NodeTypeImage Type { get; set; }

        public string Folder { get; set; }

        public ImageTypes ImageType { get; set; }

        public string ImageName { get; set; }

        public int[,] ImageSizes
        {
            get
            {
                // each size is depicted as width, height; height of zero indicates scaled size

                switch (ImageType)
                {
                    // logo is a special case
                    case ImageTypes.Logo:
                        return (new int[,] { { 178, 121 }, { 66, 66 }, { 220, 110 },
                        { 835, 221 }, { 178, 121 }, { 107, 73 }, { 239, 65 },
                        { 250, 209 }, { 25, 0 }, { 323, 99 } } );

                    // always return largest to smallest files for all except the logo
                    case ImageTypes.Products:
                        return (new int[,] { { 288, 268 },
                            { 200, 186 }, { 178, 165 }, 
                            { 148, 137 }, { 89, 82 }, { 66, 61 } });
                    case ImageTypes.Treatments:
                        return (new int[,] { { 148, 137 }, { 66, 61 } });
                    case ImageTypes.WebsiteTreatments:
                        return (new int[,] { { 130, 175 } });
                    case ImageTypes.HomePageBanners:
                        return (new int[,] { { 700, 320 }, { 300, 137 } });
                    case ImageTypes.HomeFixedBanners:
                        return (new int[,] { { 449, 194 } });
                    case ImageTypes.PageBanners:
                        return (new int[,] { { 154, 0 } });
                    case ImageTypes.OfferImages:
                        return (new int[,] { { 650, 0 }, { 154, 0 } });
                    case ImageTypes.Celebrities:
                        return (new int[,] { { 172, 244 }, { 113, 160 } });
                    default:
                        return (new int[,] { { 130, 175 } });
                }
            }
        }

        #endregion Properties

        #region Public Methods

        public string FixFileName(string fileName)
        {
            fileName = fileName.Trim().ToUpper();
            string Result = String.Empty;

            foreach (char c in fileName)
            {
                if (StringConstants.FILE_NAME_CHARACTERS.Contains(c.ToString()))
                    Result += c;
            }

            return (Result);
        }

        public void GenerateImages(string fileName)
        {
            int[,] sizes = ImageSizes;
            string fileNoExt = ImageType == ImageTypes.Logo ?
                ImageType.ToString() :
                FixFileName(Path.GetFileNameWithoutExtension(fileName).ToUpper());
            string fileExt = StringConstants.FILE_EXTENSION_JPG;

            Bitmap originalImage = new Bitmap(fileName);
            try
            {
                // save original
                Bitmap mainImage = new Bitmap(originalImage, new Size(originalImage.Width, originalImage.Height));
                try
                {
                    string originalFile = Folder +
                        fileNoExt + StringConstants.IMAGE_DEFAULT +
                        fileExt;
                    mainImage.Save(originalFile);

                    for (int i = 0; i < sizes.Length / 2; i++)
                    {
                        int newWidth = sizes[i, 1];

                        if (newWidth == 0)
                        {
                            newWidth = LibUtils.ResizeKeepAspect(new Size(
                                originalImage.Width, originalImage.Height), sizes[i, 0]).Width;
                        }

                        Bitmap newImage = LibUtils.ResizeImage(originalImage, sizes[i, 0], newWidth,
                            ImageType != ImageTypes.Logo);
                        try
                        {
                            string destinationFile = Folder +
                                fileNoExt + "_" + sizes[i, 0].ToString() +
                                fileExt;

                            newImage.Save(destinationFile);
                        }
                        finally
                        {
                            newImage.Dispose();
                            newImage = null;
                        }
                    }
                }
                finally
                {
                    mainImage.Dispose();
                    mainImage = null;
                }
            }
            finally
            {
                originalImage.Dispose();
                originalImage = null;
            }
        }

        #endregion Public Methods
    }
}
