using System;

namespace SieraDelta.Website.MVC.Models.SmallBusinessManager
{
    public class ValidateInstallModel
    {
        #region Properties

        public string Action { get; set; }

        public string ComputerName { get; set; }

        public string ServerName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string InstallType { get; set; }

        public string Path { get; set; }

        public string FirstName { get; set; }

        string LastName { get; set; }

        public string WebsiteUrl { get; set; }

        #endregion Properties
    }
}