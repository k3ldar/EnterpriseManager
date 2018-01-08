<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="FirebirdReplicationForHighAvailability.aspx.cs" Inherits="SieraDelta.Website.Papers.FirebirdReplicationForHighAvailability" %>

<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register src="~/Controls/FileDownload.ascx" tagname="FileDownload" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Firebird Replication for High Availability</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Jscript for syntax highlighting -->
	<script type="text/javascript" src="/js/shCore.js"></script>
	<script type="text/javascript" src="/js/shBrushCSharp.js"></script>
	<link type="text/css" rel="stylesheet" href="/css/shCoreDefault.css"/>
	<script type="text/javascript">SyntaxHighlighter.defaults['gutter'] = false; SyntaxHighlighter.defaults['toolbar'] = false; SyntaxHighlighter.all();</script>
    <!-- END of Jscript for syntax highlighting -->
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Papers/Index.aspx"><%=Languages.LanguageStrings.Papers %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Papers/FirebirdReplicationForHighAvailability.aspx">Firebird Replication For High Availability</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <%--<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />--%>
		
			<div class="mainContent" style="width:100%">
			
				<h3>1.  Firebird Replication For High Availability</h3>
				
				<p><a href="https://firebirdsql.org/" target="_blank">Firebird</a> is an open source SQL relational database 
                    management system that is ACID compliant and supports many features including SQL compatibility, 
                    triggers, stored procedures and much more.  This is delivered with a very small footprint and is 
                    scalable for both small and large databases with a very low cost base.  This makes it an ideal 
                    database for both small and large businesses.</p>

                <h3>2.	Introduction</h3>

                <p>Creating high availability architecture for 24/7 real world business operations introduces many challenges.  
                    Balancing availability and maintenance encompasses a number of important aspects:</p>

                <ul>
                    <li>Data availability.  Prevent interruption to business processes by ensuring access to data.</li>
                    <li>Performance.  Providing adequate response times for efficient business operations.</li>
                    <li>Cost.  Reducing costs as part of overall business strategy.</li>
                </ul>

                <h3>3.	Replication</h3>

                <p>Replication allows data from a master database to be replicated to one or more child databases 
                    (also known as nodes) and vice versa.  SieraDelta’s 
                    <a href="/Products/FBReplication.aspx">replication engine</a> is easy to setup and configure 
                    and allows workloads to be scaled between instances of Firebird on multiple servers.</p>

                <h3>3.1	Advantages of replication</h3>
                <p>There are many advantages to replication, including:</p>
                <ul>
                    <li>Analytics.  Analysis of information can take place on a child database, without affecting performance 
                        of the master database.</li>
                    <li>Data distribution.  Remote sites can work on local copies of data without permanent access to the 
                        master database.</li>
                    <li>Increased availability.  Should a node become unavailable due to hardware or other failure, clients 
                        can access an alternative node.</li>
                    <li>Increased speed.  Accessing data on a local network is generally faster than public network access.</li>
                </ul>
                <h3>3.2	Disadvantages of replication</h3>
                <p>There are several disadvantages to replication, including:</p>
                <ul>
                    <li>Increased disk space.  Storing copies of data on different sites consumes more disk space.</li>
                    <li>Maintaining data integrity is more complex.</li>
                </ul>
                <h3>3.3	Replication Schema</h3>
                <p>The replication engine stores DML changes within a series of tables in each database that is replicated 
                    at user defined intervals between master and child databases.  The interval specified would depend on 
                    the necessity of available data within the location.  For instance, a support department or help desk 
                    facility linked to an online portal would require replication more regularly  than the human 
                    resources department.</p>
                <h3>3.4	Asynchronous Replication</h3>
                <p>The replication engine is asynchronous by default; data is stored within a replication schema which 
                    is requested by child databases on request.  This has the advantage that:</p>
                <ul>
                    <li>The master database does not rely on or wait for child databases.</li>
                    <li>Child databases determine which data is read from the master database.</li>
                    <li>Child databases synchronise at pre-determined intervals.</li>
                </ul>
                <h3>4	Resilience</h3>
                <p>Providing a database for resilience, would allow business operations to continue should the 
                    primary database become unavailable through failure or maintenance.  Replication is used to 
                    ensure the resilience and uptime within a site or location. </p>
                <img src="/Images/Products/Replication/Resilience.png" alt="" border="0" />
                <p>This image shows a configuration for departments on a site, each department would use their database 
                    instance, optimised for their needs, replication would synchronise their data and a further “resilience” 
                    database would be available should their primary database become unavailable.  This model can be easily 
                    replicated across multiple sites and departments.</p>
                <h3>5	Remote Updates</h3>
                <p>As applications and websites evolve the need to automatically update remote databases will be necessary 
                    within a distributed model using replication.  The replication engine provides a mechanism to update 
                    the database remotely.  Remote update is configurable for each database to allow maximum flexibility 
                    and different database optimisations.</p>
                <h3>6	One Size Fits All</h3>
                <p>This is very rarely true; more often than not different business operations would require different 
                    database optimisations.  Using replication, applications can connect to the most appropriate database 
                    for their needs.  For instance, a website collecting SEO data would need to optimise the writing of 
                    data in order to optimise the user experience.  This could be achieved by removing all indexes used 
                    in search operations.  Using replication, a specific child database could be designated for SEO reports 
                    and include the required indexes to optimise querying the data.  Primary and foreign keys should never
                     be disabled in node databases.</p>
 
                <h3>7	Database Maintenance</h3>
                <p>At some point in the life cycle of a database it will require maintenance, whether it be backup 
                    and restore, optimizations or upgrading system versions.  Using resilience and the Replication 
                    Engine a database, even the master database, can be taken off line for a pre-determined period 
                    for maintenance purposes.  </p>
                <p>If the master database is taken off line then no replication can occur until it becomes available again.</p>
                <h3>8	Automatic Backups</h3>
                <p>The replication engine has built in support for backing up databases and optionally sending copies 
                    of the backup, via FTP to a remote offsite location for safety.</p>
                <h3>9	Automatic Data Correction Rules</h3>
                <p>The replication engine contains a rules engine for automatically correcting data should it fail to
                     replicate.  In general the primary reasons for records to fail in replication are:</p>
                <ul>
                    <li>Inconsistency in database structure between child and master databases.</li>
                    <li>Index validation.</li>
                </ul>
                <p>System managers can configure the replication engine to automatically adjust data in either the master 
                    or child database when records fail to replicate.</p>
                <p>Should records fail to replicate due to validation errors etc, then an error log will be produced with 
                    complete details about the record that has failed to replicate.</p>
                <h3>10	Forced Verification</h3>
                <p>The replication engine contains a process of validating all records between master and child databases.</p>
                <p>The process can be initiated in several ways:</p>
                <ul>
                    <li>After a predetermined time each day.</li>
                    <li>After a specific number of replications have taken place.</li>
                    <li>Manually using the replication console.</li>
                </ul>
                <p>Forced verification allows the replication engine to scan all records within replicated tables and verify 
                    that records match in both master and child databases.  Missing records will be automatically inserted 
                    and subject to Automatic Data Correction Rules.</p>



                <h3>11	Connecting To Databases</h3>
                    <p>The application code required to access multiple databases requires little overhead, a single method can be used to connect to a specific database, a further method would be required to specify the connection string.</p>
                    <p>The following code is in C# but can easily be ported to other languages.</p>
                    <h3>11.1	Database Type</h3>
                <p>An enum is used to specify which database to connect to.  The Standard database is generic for most connections and the FailOver is used should the connection to the Standard database fail.  The enum can be expanded to suit business specific requirements.</p>
                <pre class="brush: csharp;">
                    public enum DatabaseType
                    {
                        Standard = 0,
                        FailOver = 1,
                        Reports = 2,
                        SeoData = 3
                    }
                </pre>
                <h3>11.2	Connection Strings</h3>
                <p>A string array is used to hold connection strings to specific database types, this would be one for each enum in DatabaseType.</p>


                <pre class="brush: csharp;">
                protected string[] _connectionString;
                // If true, then the connection string provided will be used, 
                // otherwise the connection string provided will be substituted for a
                // standard build connection string
                protected bool StandardConnection = false;
                </pre>
                <p>The array can be initialised thus:</p>
                <pre class="brush: csharp;">
                _connectionString = new string[Enum.GetNames(typeof(DatabaseType)).Length];
                 </pre>

                <h3>11.3	GetConnectionString Method</h3>
                <p>The GetConnectionString method will return the connection string required to connect to the database type specified.</p>

                <pre class="brush: csharp;">
                        private string GetConnectionString(DatabaseType databaseType)
                        {
                            string connString = _connectionString[(int)databaseType];

                            if (databaseType != DatabaseType.Standard && String.IsNullOrEmpty(connString))
                            {
                                connString = _connectionString[(int)DatabaseType.Standard];
                            }

                            FbConnectionStringBuilder csb = new FbConnectionStringBuilder(connString);

                            if (csb.ServerType == FbServerType.Embedded)
                                csb.ClientLibrary = String.Format("{0}\\fbembed\\fbembed.dll", Utilities.CurrentPath());

                            if (StandardConnection)
                            {
                                csb.Pooling = true;
                                csb.MinPoolSize = 0;
                                csb.MaxPoolSize = 250;
                                csb.ConnectionTimeout = 15;
                                csb.ConnectionLifeTime = 60 * 20;
                            }

                            return (csb.ToString());
                        }
                    </pre>


                    <h3>11.4	ConnectToDatabase Method</h3>
                    <p>The connect to database method makes a physical connection to the required database and 
                        starts a transaction, this method requires several private fields in order to automatically 
                        attempt to switch back from a FailOver database to the Standard database.</p>
                    <p>Please note it is the responsibility of the calling method to dispose of the FbConnection and FbTransaction objects.</p>
                    <p>The method will attempt to make a connection to the specified database type, if an error occurs more than 3 times whilst making the connection then the FailOver connection will be used up to MaxReconnectAttempts, after this the method will throw an exception.</p>
                    <p>This method will also work for pooled connections, if for any reason the pooled connection is lost then further connection attempts will be made. </p>
                <pre class="brush: csharp;">
                    // Maximum database connection attempts
                    private const int MaxReconnectAttempts = 6;

                    // Maximum number of minutes to use fail over database
                    private const double MaxFailOverUsage = 5.0;

                    // Determines whether the fail over database is in use
                    private bool FailOverInUse = false;

                    // Date/Time Fail over database started to be used
                    private DateTime FailOverStart = DateTime.MaxValue;

                    private FbConnection ConnectToDatabase(ref FbTransaction tran, 
                        DatabaseType databaseType, 
                        System.Data.IsolationLevel isolationLevel = IsolationLevel.Snapshot,
                        int attempt = 0)
                    {
                        FbConnection Result = null;
                        try
                        {
                            if (FailOverInUse)
                            {
                                TimeSpan span = DateTime.Now - FailOverStart;

                                if (span.TotalMinutes > MaxFailOverUsage)
                                    FailOverInUse = false;
                                else
                                    databaseType = DatabaseType.FailOver;
                            }

                            Result = new FbConnection(GetConnectionString(databaseType));
                            Result.Open();
                            tran = Result.BeginTransaction(isolationLevel);

                            return (Result);
                        }
                        catch (Exception err)
                        {
                            if (err.Message.Contains("Error reading data from the connection") ||
                                err.Message.Contains("connection shutdown") ||
                                err.Message.Contains("Unable to complete network request"))
                            {
                                if (attempt < MaxReconnectAttempts)
                                {
                                    if (attempt > 3 || 
                                        err.Message.Contains("Unable to complete network request"))
                                    {
                                        FbConnection failedConn = ConnectToDatabase(ref tran, DatabaseType.FailOver, isolationLevel, attempt + 1);

                                        if (!FailOverInUse && failedConn != null)
                                        {
                                            FailOverInUse = true;
                                            FailOverStart = DateTime.Now;
                                        }
                                
                                        return (failedConn);
                                    }
                                    else
                                    {
                                        return (ConnectToDatabase(ref tran, databaseType, isolationLevel, attempt + 1));
                                    }
                                }
                                else
                                {
                                    throw new Exception("Unable to connect to database");
                                }
                            }
                            else
                                throw;
                        }

                    }
                    </pre>
                <h3>11.5	Example Usage</h3>
                <p>The following code shows example usage for connecting to a database using the above methods.</p>

                <pre class="brush: csharp;">
                        internal override void AutoUpdateDelete(AutoUpdate autoUpdate)
                        {
                            FbTransaction tran = null;
                            FbConnection db = ConnectToDatabase(ref tran, DatabaseType.Standard);
                            try
                            {
                                string SQL = "DELETE FROM AUTO_UPDATE_DATA WHERE ID = @ID";

                                FbCommand cmd = new FbCommand(SQL, db, tran);
                                try
                                {
                                    cmd.Parameters.Add("@ID", FbDbType.BigInt);
                                    cmd.Parameters["@ID"].Direction = ParameterDirection.Input;
                                    cmd.Parameters["@ID"].Value = autoUpdate.ID;
                                    cmd.ExecuteNonQuery();
                                }
                                finally
                                {
                                    cmd.Dispose();
                                    cmd = null;
                                    tran.Commit();
                                }
                            }
                            finally
                            {
                                tran.Dispose();
                                tran = null;
                                db.Dispose();
                                db = null;
                            }
                        }
                    </pre>
                <h3>Summary</h3>
                <p>
                    This paper talks about Firebird and SieraDelta's <a href="/Products/FBReplication.aspx">replication engine</a>,
                    there are many replication engines available and users should choose the one that suits their business
                    requirements.  Likewise, there are many RDBMS Servers available and the methodology discussed here
                    is easily transportable to these.
                </p>
                <p>Author:  Simon Carter</p>

                            <%--<uc1:FileDownload ID="FileDownload1" runat="server" />--%>

			</div><!-- end of #mainContent -->
			

            <uc2:medialinks id="MediaLinks1" runat="server" />
            <uc2:webpagetags id="WebPageTags1" runat="server" />

			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
