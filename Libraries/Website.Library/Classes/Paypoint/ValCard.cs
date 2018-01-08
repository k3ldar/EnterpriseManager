using System;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using System.Collections.Specialized;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Basket;

namespace Website.Library.Classes.Paypoint
{
	/// <summary>
	/// determines what type of post to perform.
	/// Get: Does a get against the source.
	/// Post: Does a post against the source.
	/// </summary>
	public enum PostType {Get, Post}

	/// <summary>
	/// Summary description for ValCard.
	/// </summary>
	public class ValCard
	{
		#region Private / Protected Members

		private string m_url = "https://www.secpay.com/java-bin/ValCard";
		private NameValueCollection m_values = new NameValueCollection();
		private PostType m_type = PostType.Post;
		private string TransID;
		private string Amount;
		private string Digest;

		private bool TestOnly = false; // change to true for live


		#endregion Private / Protected Members

		#region Constants

		private const string _URLSuccess = "http://www.heavenskincare.com/Basket/BasketValCard.aspx";
		//private const string URLCancel = "http://www.heavenskincare.com/Basket/";
		private const string _RemotePassword = "chall3ng3 Auth0r1ty 13A";
		//private const string Digest = "th1s 1s th3 way th1ngs are d0n3";
		private const string _MerchantID = "heaven01";
		private string _Currency = "GBP";
		
		private const int Timeout = 10000;


		#endregion Constants

        #region Static Properties

        /// <summary>
        /// Currencies available for Paynet
        /// </summary>
        public static string Currencies { get; set; }

        #endregion Static Properties

        #region Properties

        /// <summary>
		/// Gets or sets the url to submit the post to.
		/// </summary>
		public string Url
		{
			get
			{
				return m_url;
			}
			set
			{
				m_url=value;
			}
		}

		/// <summary>
		/// Gets or sets the name value collection of items to post.
		/// </summary>
		public NameValueCollection PostItems
		{
			get
			{
				return m_values;
			}
			set
			{
				m_values=value;
			}
		}

		/// <summary>
		/// Gets or sets the type of action to perform against the url.
		/// </summary>
		public PostType Type
		{
			get
			{
				return m_type;
			}
			set
			{
				m_type=value;
			}
		}


		#endregion Properties

		#region Public Methods

		/// <summary>
		/// Constructor
		/// </summary>
		public ValCard(User user, string OrderReference, Double Cost, string CurrencyInUse)
		{
            _Currency = CurrencyInUse;
			TransID = OrderReference;
            Amount = Convert.ToString(Cost);
			CreateDigest();
			BuildParamList(user);
		}

        public ValCard(User user, string OrderReference, Double Cost, string CurrencyInUse, bool Test)
        {
            TestOnly = Test;
            _Currency = CurrencyInUse;
            TransID = OrderReference;
            Amount = Convert.ToString(Cost);
            CreateDigest();
            BuildParamList(user);
        }

		public string GetURL()
		{
			StringBuilder parameters = new StringBuilder();

			for (int i = 0; i < m_values.Count; i++)
			{
				EncodeAndAddItem(ref parameters, m_values.GetKey(i), m_values[i]);
			}


			string result = m_url + "?" + parameters.ToString();
			return result;
		}


		/// <summary>
		/// Posts the supplied data to specified url.
		/// </summary>
		/// <returns>a string containing the result of the post.</returns>
		public string Post()
		{
			StringBuilder parameters = new StringBuilder();

			for (int i = 0; i < m_values.Count; i++)
			{
				EncodeAndAddItem(ref parameters, m_values.GetKey(i), m_values[i]);
			}


			string result = PostData(m_url, parameters.ToString());
			return result;
		}

		/// <summary>
		/// Posts the supplied data to specified url.
		/// </summary>
		/// <param name="url">The url to post to.</param>
		/// <returns>a string containing the result of the post.</returns>
		public string Post(string url)
		{
			m_url=url;
			return this.Post();
		}


		/// <summary>
		/// Posts the supplied data to specified url.
		/// </summary>
		/// <param name="url">The url to post to.</param>
		/// <param name="values">The values to post.</param>
		/// <returns>a string containing the result of the post.</returns>
		public string Post(string url, NameValueCollection values)
		{
			m_values = values;
			return this.Post(url);
		}


		#endregion Public Methods

		#region Private Methods

		private void CreateDigest()
		{
            Digest = Shared.Utilities.HashStringMD5(TransID + Amount + _RemotePassword);
		}


		private void BuildParamList(User user)
		{
			m_values.Clear();
			m_values.Add("merchant", _MerchantID);
			m_values.Add("trans_id", TransID);
			m_values.Add("amount", Amount);
			m_values.Add("callback", _URLSuccess);// + ";" + URLCancel);
			m_values.Add("digest", Digest);
            m_values.Add("currency", _Currency);

			if (TestOnly)
			{
				m_values.Add("test_status", "true");
			}

            
            //m_values.Add("bill_addr_1", user.AddressLine1);
            //m_values.Add("bill_city", user.City);
            //m_values.Add("bill_post_code", user.PostCode);
		}


		/// <summary>
		/// Posts data to a specified url. Note that this assumes that you have already url encoded the post data.
		/// </summary>
		/// <param name="postData">The data to post.</param>
		/// <param name="url">the url to post to.</param>
		/// <returns>Returns the result of the post.</returns>
		private string PostData(string url, string postData)
		{
			HttpWebRequest request = null;

			if (m_type == PostType.Post)
			{
				Uri uri = new Uri(url);
				request = (HttpWebRequest) WebRequest.Create(uri);
				request.Method = "POST";
				request.Timeout = Timeout;
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = postData.Length;
				using(Stream writeStream = request.GetRequestStream())
				{
					UTF8Encoding encoding = new UTF8Encoding();
					byte[] bytes = encoding.GetBytes(postData);
					writeStream.Write(bytes, 0, bytes.Length);
				}
			}
			else
			{
				Uri uri = new Uri(url + "?" + postData);
				request = (HttpWebRequest) WebRequest.Create(uri);
				request.Method = "GET";
			}

			string result = string.Empty;

			using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
			{
				using (Stream responseStream = response.GetResponseStream())
				{
					using (StreamReader readStream = new StreamReader (responseStream, Encoding.UTF8))
					{
						result = readStream.ReadToEnd();
					}
				}
			}
			return result;
		}


		/// <summary>
		/// Encodes an item and ads it to the string.
		/// </summary>
		/// <param name="baseRequest">The previously encoded data.</param>
		/// <param name="dataItem">The data to encode.</param>
		/// <returns>A string containing the old data and the previously encoded data.</returns>
		private void EncodeAndAddItem(ref StringBuilder baseRequest, string key, string dataItem)
		{
			if (baseRequest == null)
			{
				baseRequest = new StringBuilder();
			}

			if (baseRequest.Length != 0)
			{
				baseRequest.Append("&");
			}

			baseRequest.Append(key);
			baseRequest.Append("=");
			baseRequest.Append(System.Web.HttpUtility.UrlEncode(dataItem));
		}


		#endregion Private Methods
	}
}
