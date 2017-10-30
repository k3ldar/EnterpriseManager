using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POS.Base.Classes;

namespace POS.Images.Classes
{
    public class UpdatedFile
    {
        internal UpdatedFile (bool remote, string filename, ImageTypes imageType)
        {
            IsRemote = remote;
            FileName = filename;
            ImageType = imageType;
        }

        public bool IsRemote { get; private set; }
        public string FileName { get; private set; }
        public ImageTypes ImageType { get; private set; }
    }
}
