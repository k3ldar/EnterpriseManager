using System;
using System.Collections.Generic;
using System.Text;

using Library;

namespace Library.BOL.Search
{
    [Serializable]
    public sealed class SearchItem : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="memberLevel"></param>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="url"></param>
        public SearchItem(string description, Enums.SearchResultType type, MemberLevel memberLevel, 
            Int64 id, string text, string url, int primaryProductType)
        {
            Description = description;
            Type = type;
            MemberLevel = memberLevel;
            ID = id;
            Text = text;
            URL = url;
            PrimaryProductType = primaryProductType;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Description of search item
        ///</summary>
        public string Description { private set; get; }

        /// <summary>
        /// Type of search result
        /// </summary>
        public Enums.SearchResultType Type { private set; get; }

        /// <summary>
        /// Users member level
        /// </summary>
        public MemberLevel MemberLevel { private set; get; }

        /// <summary>
        /// ID of search Item
        /// </summary>
        public Int64 ID { private set; get; }

        /// <summary>
        /// Full text from search item
        /// </summary>
        public string Text { private set; get; }

        /// <summary>
        /// URL if provided
        /// </summary>
        public string URL { private set; get; }

        /// <summary>
        /// Primary product type of search result returns a product
        /// </summary>
        public int PrimaryProductType { get; set; }

        #endregion Properties
    }
}
