using System;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Types;
using Heavenskincare.Website.Library;


namespace Heavenskincare.Classes.Postcode
{
	/// <summary>
	/// Summary description for PostcodeFindSalons.
	/// </summary>
	public class PostcodeFindSalons
	{
		public PostcodeFindSalons()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Events

		public delegate int EventSalonFound (int SalonID, Double DistanceKM);

		public event EventSalonFound OnSalonFound;

		#endregion Events
	}
}
