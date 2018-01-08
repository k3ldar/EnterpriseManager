using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ServerAdminConsole
{
    internal static class ServerUsers
    {
        public static string CreateUserName(string name, int maxLength = 12)
        {
            string Result = name.Replace("-", "").Replace(" ", "").Replace(".", "_");

            while (Result.Length > maxLength)
                Result = Result.Substring(1);

            Result = "web_" + Result;


            return (Result);
        }

        public static bool CreateLocalWindowsAccount(string username, string password, 
            string description, bool canChangePwd, bool pwdExpires)
        {
            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Machine);

                UserPrincipal user = UserPrincipal.FindByIdentity(context, username);

                if (user == null)
                {
                    user = new UserPrincipal(context);
                    user.SetPassword(password);
                    user.DisplayName = username;
                    user.Name = username;
                    user.Description = description;
                    user.UserCannotChangePassword = canChangePwd;
                    user.PasswordNeverExpires = pwdExpires;
                    user.Enabled = true;
                }
                else
                {
                    user.SetPassword(password);
                }

                user.Save();

                //now add user to "Users" group so it displays in Control Panel
                //GroupPrincipal group = GroupPrincipal.FindByIdentity(context, "Users");
                //group.Members.Add(user);
                //group.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating account: {0}", ex.Message);
                return false;
            }

        }
    }
}

