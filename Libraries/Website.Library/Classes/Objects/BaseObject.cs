#region License
// dnfBB 
// 
// The contents of this file are subject to the Initial Developer's Public License Version 1.0 
// (the "License"); you may not use this file except in compliance with the License. You may 
// obtain a copy of the License from dnfBB Project website.
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT 
// WARRANTY OF ANY KIND, either express or implied. See the License for the specific language 
// governing rights and limitations under the License.
// 
// The Original Code is part of dnfBB .
// 
// The Initial Developer of the Original Code is Simon Carter.
// 
// Portions created by Simon Carter (http://www.tectsoft.net/) are 
// Copyright (C) 2005 - 2006. Simon Carter. All Rights Reserved.
// 
// All Rights Reserved.
// 
// Contributor(s): Simon Carter.

#endregion License

using System;

namespace Website.Library.Classes.Objects
{

	/// <summary>
	/// BaseBOLObject is the base class for all BOL Objects, excluding Collections.
	/// </summary>
	public abstract class BaseObject
	{
		#region Private Members

		private bool _isdirty;

		#endregion Private Members

		#region Properties

		/// <summary>
		/// Indicates wether the object has changed
		/// </summary>
		public bool IsDirty
		{
			get
			{
				return (_isdirty);
			}
		}

		#endregion Properties

		#region Constructors
		
		
		/// <summary>
		/// Constructor for BaseBOLObject
		/// </summary>
		public BaseObject()
		{
			_isdirty = false;
		}

		#endregion Constructors

		#region Protected Methods

		/// <summary>
		/// Indicates that the object has changed
		/// </summary>
		protected void Changed()
		{
			_isdirty = true;
		}

		#endregion Protected Methods

		#region Public Abstract Methods

		/// <summary>
		/// Saves the current object
		/// </summary>
		public abstract void Save();

		/// <summary>
		/// Forces the object to revert previous unchanged state, rolls back any changes
		/// </summary>
		public abstract void Refresh();

		#endregion Public Abstract Methods
	}
}
