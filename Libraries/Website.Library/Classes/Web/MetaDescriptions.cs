using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website.Library.Classes
{
    internal class MetaDescription
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageName">Name of Page</param>
        /// <param name="description">Meta Description</param>
        internal MetaDescription(string pageName, string description)
        {
            PageName = pageName;
            Description = description;
        }

        #endregion Constructors

        #region Internal Methods

        #endregion Internal Methods

        #region Properties

        /// <summary>
        /// Name of page for meta description
        /// </summary>
        internal string PageName { private set; get; }

        /// <summary>
        /// Meta Description for page
        /// </summary>
        internal string Description { private set; get; }

        #endregion Properties

        #region Public Methods

        public override string ToString()
        {
            return (String.Format("MetaDescription (PageName: {0}; Description: {1}", PageName, Description));
        }

        #endregion Public Methods
    }
}
