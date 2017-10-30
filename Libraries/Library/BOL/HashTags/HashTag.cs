using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.HashTags
{
    [Serializable]
    public sealed class HashTag : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of Tag</param>
        /// <param name="tag">Tag Name</param>
        public HashTag(Int64 id, string tag)
        {
            ID = id;
            Tag = tag;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Tag ID
        /// </summary>
        public Int64 ID
        {
            get;
            set;
        }

        #endregion Properties

        public override string ToString()
        {
            return (String.Format("Index: {0}; Tag: {1}", ID, Tag));
        }
    }
}
