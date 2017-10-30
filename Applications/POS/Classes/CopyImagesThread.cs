using System;
using System.Collections.Generic;
using System.Text;

using SieraDelta.Shared.Classes;

namespace Heavenskincare.PointOfSale.Classes
{
    /// <summary>
    /// Thread which copies images (.jpg, .bmp, .jpeg, .gif, .ico) from one path to another
    /// </summary>
    public class CopyImagesThread : ThreadManager
    {
        #region Private Members

        private string _pathFrom;
        private string _pathTo;

        #endregion Private Members

        #region Constructor

        public CopyImagesThread(string fromPath, string toPath)
            : base (null, new TimeSpan())
        {
            _pathFrom = fromPath;
            _pathTo = toPath;
        }

        #endregion Constructor

        #region Overridden Methods

        protected override bool Run(object parameters)
        {


            return (false);
        }

        #endregion Overridden Methods
    }
}
