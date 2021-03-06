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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Campaigns.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace SharedBase.BOL.Campaigns
{
    [Serializable]
    public sealed class Campaigns : BaseCollection
    {
        #region Internal Methods

        internal bool Exists(string name)
        {
            bool Result = false;

            foreach (Campaign cmp in this)
            {
                if (cmp.CampaignName.ToLower() == name.ToLower())
                {
                    Result = true;
                    break;
                }
            }

            return Result;
        }

        #endregion Internal Methods

        #region Static Methods

        public static Campaigns GetWizard()
        {
            return DAL.FirebirdDB.CampaignsGetWizard();
        }

        /// <summary>
        /// Retrieves all campaigns
        /// </summary>
        /// <returns>
        /// Campaigns collection</returns>
        public static Campaigns Get()
        {
            return DAL.FirebirdDB.CampaignsGet();
        }

        public static Campaigns Active()
        {
            return DAL.FirebirdDB.CampaignsGetActive();
        }

        public static Campaign Create(string campaignName)
        {
            //is it a duplicate name?
            Campaigns currentCampaigns = Get();
            string newName = campaignName;
            int i = 0;

            while (currentCampaigns.Exists(newName))
            {
                i++;
                newName = String.Format("{0}{1}", campaignName, i);
            }

            // create the new campaign with a unique name
            return DAL.FirebirdDB.CampaignCreate(newName);
        }

        public static bool CanSetReplicationStatus()
        {
            return DAL.FirebirdDB.CampaignsCanSetReplication();
        }

        #endregion Static Methods

        public void Sort(CampaignSortType sortType)
        {
            CampaignSortComparer comparer = new CampaignSortComparer(sortType);
            try
            {
                this.InnerList.Sort(comparer);
            }
            finally
            {
                comparer = null;
            }
        }

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public Campaign this[int Index]
        {
            get
            {
                return (Campaign)this.InnerList[Index];
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(Campaign value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Campaign value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Campaign value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Campaign value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Campaign value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return List.Contains(value);
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Campaigns.Campaign";
        private const string OBJECT_TYPE_ERROR = "Must be of type Campaign";


        #endregion Private Members

        #region Overridden Methods

        /// <summary>
        /// When Inserting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnInsert(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When removing an item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnRemove(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When Setting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            if (newValue.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "newValue");
        }


        /// <summary>
        /// Validates an object
        /// </summary>
        /// <param name="value"></param>
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR);
        }


        #endregion Overridden Methods

        #endregion Generic CollectionBase Code
    }
}
