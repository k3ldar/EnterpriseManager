using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SieraDelta.Library.BOL.Statistics
{
    public sealed class WebsiteStat
    {
        #region Constructor

        public WebsiteStat (string description, int count)
        {
            Count = count;
            Description = description;
        }

        public WebsiteStat(string description, int count, decimal value1)
        {
            Count = count;
            Description = description;
            Value1 = value1;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Website Description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Website Count
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Variable double Value, optional
        /// </summary>
        public decimal Value1 { get; private set; }

        #endregion Properties
    }
}
