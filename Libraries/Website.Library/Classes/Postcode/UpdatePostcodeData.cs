using System;
using System.Data;
using Heavenskincare.Website.Library;
using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Types;

namespace Heavenskincare.Classes.Postcode
{
	/// <summary>
	/// Summary description for UpdatePostcodeData.
	/// </summary>
	public class UpdatePostcodeData
	{
		public UpdatePostcodeData()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void UpdatePostCodeDataForSearch()
		{
            FbConnection db = new FbConnection(GlobalClass.ConnString);
			db.Open();
			try
			{
				FbTransaction tran = db.BeginTransaction(IsolationLevel.Snapshot);
				try
				{
					string SQL = "SELECT r.ID, r.POSTCODE FROM WS_SALONS r WHERE POSTCODE <> '' AND r.SHOW_ON_WEB = 0";
					FbCommand cmd = new FbCommand(SQL, db, tran);

					FbDataReader rdr = cmd.ExecuteReader();

					//delete all rows from Mysql DB
                    string MySQLConnect = GlobalClass.ConnStringMySQL;
										
					MySqlConnection dbsql = new MySqlConnection(MySQLConnect);
					dbsql.Open();
					try
					{
						MySqlTransaction msdbtran = dbsql.BeginTransaction(IsolationLevel.RepeatableRead);
						try
						{
							string msSQL = "DELETE FROM hwz_salons";


							MySqlCommand mscmd = new MySqlCommand(msSQL, dbsql, msdbtran);

							mscmd.ExecuteNonQuery();

							while (rdr.Read())
							{
								string test = rdr.GetString(1);
								string pc1 = test;
								pc1 = pc1.Substring(0, pc1.IndexOf(" "));
								string pc2 = test;
								pc2 = pc2.Substring(pc1.Length);

								pc1 = pc1.Trim();
								pc2 = pc2.Trim();

								string s = String.Format("INSERT INTO hwz_salons (salon_id, postcode_1, postcode_2) values ({0}, '{1}', '{2}');", rdr.GetInt32(0), pc1, pc2);
								MySqlCommand msc = new MySqlCommand(s, dbsql, msdbtran);
								msc.ExecuteNonQuery();
							}

							msdbtran.Commit();
						}
						catch 
						{
							msdbtran.Commit();
							throw;
						}
					}
					finally
					{
						dbsql.Close();
					}

					tran.Commit();
				}
				catch (Exception E)
				{
					string s1 = E.Message;
					s1 = s1 + s1;
					tran.Rollback();
					throw;
				}
			}
			finally
			{
				db.Close();
			}
		}
	}
}
