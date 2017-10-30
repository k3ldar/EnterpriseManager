using System;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Shared.Classes;

namespace POSRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialising POS Release {0}", Assembly.GetExecutingAssembly().GetName().Version);
            Parameters.Initialise(args, new char[] { '/', '-' }, new char[] { ':' });

            bool privateBuild = Parameters.OptionExists("private");


            if (privateBuild)
                Console.WriteLine("Private Build, Setup will not be deployed!");

            try
            {

                if (!privateBuild &&  !FTPDetailsGet())
                {
                    Console.Write("FTP Details not Set");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                Console.WriteLine("Validating Current Builds");

                if (BuildsFailed())
                {
                    Console.Write("Builds Failed");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                string uploadConfig = Parameters.GetOption("configXML", String.Empty);

                Console.WriteLine("Validating Configuration XML");

                if (!privateBuild && (String.IsNullOrEmpty(uploadConfig) || !System.IO.File.Exists(uploadConfig)))
                {
                    Console.Write("Invalid Configuration XML File");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                string innoSetup = Parameters.GetOption("inno", String.Empty);

                Console.WriteLine("Validating Inno Setup Options");

                if (String.IsNullOrEmpty(innoSetup) || !System.IO.File.Exists(innoSetup))
                {
                    Console.Write("Invalid Inno Parameter");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                // find the current pos version
                string pos = Parameters.GetOption("pos", String.Empty);

                Console.WriteLine("Validating POS Version");

                if (String.IsNullOrEmpty(pos) || !System.IO.File.Exists(pos))
                {
                    Console.Write("Invalid pos parameter");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                FileVersionInfo ver = FileVersionInfo.GetVersionInfo(pos);

                string newVersion = String.Format("{0}.{1}.{2}",
                    ver.ProductMajorPart, ver.ProductMinorPart, ver.FileBuildPart);

                Console.WriteLine("New POS Version {0}", newVersion);

                Console.WriteLine("Validating GIT");

                if (!privateBuild && !GitDetailsGet())
                {
                    Console.Write("Failed to validate GIT File");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                if (!privateBuild)
                {
                    Console.WriteLine("Creating GIT tag");

                    // git create tag
                    ProcessStartInfo gitStartInfo = new ProcessStartInfo(git,
                        String.Format("tag -a POS_VER_{0} -m \"Pos Release v{0}\"", newVersion));
                    gitStartInfo.WorkingDirectory = git_working;
                    gitStartInfo.UseShellExecute = false;
                    Process gitProc = System.Diagnostics.Process.Start(gitStartInfo);

                    gitProc.WaitForExit();


                    gitStartInfo = new ProcessStartInfo(git,
                        String.Format("push --progress \"HeavenMain\" tag POS_VER_{0}", newVersion));
                    gitStartInfo.WorkingDirectory = git_working;
                    gitStartInfo.UseShellExecute = false;
                    gitProc = System.Diagnostics.Process.Start(gitStartInfo);

                    gitProc.WaitForExit();
                }

                // get the pos install file and update version
                string installer = Parameters.GetOption("installer", String.Empty);

                if (String.IsNullOrEmpty(installer) || !System.IO.File.Exists(installer))
                {
                    Console.Write("Invalid Installer");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                string installFile = Shared.Utilities.FileRead(installer, true);

                int verPos = installFile.IndexOf("#define MyAppVersion \"");

                Console.WriteLine("Setting Inno Version in Config");

                if (verPos < 0)
                {
                    Console.Write("Invalid Installer Version File");
#if DEBUG
                Console.ReadLine();
#endif
                    return;
                }

                int eolPos = installFile.IndexOf("\r\n", verPos + 1);

                string start = installFile.Substring(0, verPos + 22);
                string end = installFile.Substring(eolPos - 1);
                string newInstallFile = String.Format("{0}{1}{2}",
                    start, newVersion, end);

                Shared.Utilities.FileWrite(installer, newInstallFile);

                string uploadEXE = String.Format(Parameters.GetOption("compiledInstall", String.Empty), newVersion);

                if (System.IO.File.Exists(uploadEXE))
                {
                    System.IO.File.Delete(uploadEXE);
                }

                Console.WriteLine("New Setup file is {0}", uploadEXE);

                // compile install file
                ProcessStartInfo startInfo = new ProcessStartInfo(innoSetup,
                    String.Format("/cc \"{0}\"", installer));
                Process proc = System.Diagnostics.Process.Start(startInfo);

                Console.WriteLine("Building Setup File");

                proc.WaitForExit();

                // is the install file valid

                if (!privateBuild)
                {
                    if (!System.IO.File.Exists(uploadEXE))
                    {
                        Console.Write("Failed to build install file");
#if DEBUG
                Console.ReadLine();
#endif
                        return;
                    }

                    // upload install file
                    Console.WriteLine("Uploading Executable Installer");
                    Shared.Classes.ftp ftp = new Shared.Classes.ftp(ftp_server, ftp_user, ftp_pass);
                    ftp.Upload(System.IO.Path.GetFileName(uploadEXE), uploadEXE);

                    // update the version config

                    Console.WriteLine("Updating Config File Version");
                    Console.WriteLine("Config File {0}", uploadConfig);

                    string newXML = String.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                        "<SieraDelta>\r\n  <Application>\r\n    <Version>{0}</Version>\r\n    <Location>" +
                        "http://www.heavenskincare.com/Download/Files/POS/HeavenPOSUpdate_v_{0}.exe</Location>\r\n" +
                        "    <CRC>{1}</CRC>\r\n  </Application>\r\n</SieraDelta>", newVersion,
                        Shared.Utilities.FileCRC(uploadEXE, false));
                    Shared.Utilities.FileWrite(uploadConfig, newXML);

                    // upload version config
                    ftp.Upload(System.IO.Path.GetFileName(uploadConfig), uploadConfig);
                }

                Console.WriteLine("Finished");
            }
            catch (Exception err)
            {
                Console.Write(err.Message);
                Shared.EventLog.Add(err);
            }
        }

        #region Private Static Methods

        private static string git;
        private static string git_working;

        private static bool GitDetailsGet()
        {
            git = Parameters.GetOption("git", String.Empty);
            git_working = Parameters.GetOption("git_working_dir", String.Empty);
            return (!String.IsNullOrEmpty(git) && !String.IsNullOrEmpty(git_working));
        }


        private static string ftp_user;
        private static string ftp_pass;
        private static string ftp_server;
        private static string ftp_port;

        private static bool FTPDetailsGet()
        {
            Console.WriteLine("Obtaining FTP Details");
            ftp_user = Parameters.GetOption("ftp_user", String.Empty);
            ftp_pass = Parameters.GetOption("ftp_password", String.Empty);
            ftp_server = Parameters.GetOption("ftp_server", String.Empty);
            ftp_port = Parameters.GetOption("ftp_port", "21");

            return (!String.IsNullOrEmpty(ftp_user) && !String.IsNullOrEmpty(ftp_pass) && !String.IsNullOrEmpty(ftp_server));
        }

        private static bool BuildsFailed()
        {
            for (int i = 1; i <= 10; i++)
            {
                string buildFile = Parameters.GetOption(String.Format("buildFile{0}", i), String.Empty);

                if (String.IsNullOrEmpty(buildFile))
                    continue;

                if (!System.IO.File.Exists(buildFile))
                {
                    Console.Write("Build File not found {0}", String.Format("buildFile", i));
                    return (true);
                }

                string fileContents = Shared.Utilities.FileRead(buildFile, false);

                int startPOS = fileContents.IndexOf(" succeeded, ");

                if (startPOS < 10)
                {
                    Console.Write("Invalid build File {0}", String.Format("buildFile", i));
                    return (true);
                }

                int endPOS = fileContents.IndexOf(" ", startPOS + 13);

                string data = fileContents.Substring(startPOS + 12, endPOS - (startPOS + 12));

                if (data != "0")
                {
                    Console.Write(String.Format("Builds Failed within", buildFile));
                    return (true);
                }
            }
                
            return (false);
        }

        #endregion Private Static Methods
    }
}
