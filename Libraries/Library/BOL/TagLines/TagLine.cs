using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.TagLines
{
    [Serializable]
    public sealed class TagLine : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of TagLine</param>
        /// <param name="text">TagLine text</param>
        public TagLine (Int64 id, string text)
        {
            ID = id;
            Text = text;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.TagLineSave(this);
            TagLines.Reset();
        }

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// ID of Tagline
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Tagline Text
        /// </summary>
        public string Text { get; set; }

        #endregion Properties
    }
}
