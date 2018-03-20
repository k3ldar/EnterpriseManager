using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Web.Helpers;
using System.Web.Mvc;

using SieraDelta.Website.MVC.Models.SmallBusinessManager;

namespace SieraDelta.Website.MVC.Controllers
{
    public class SmallBusinessManagerController : ApiController
    {
        // GET: api/SmallBusinessManager
        public string Get()
        {
            return ("value1");
        }

        
        public string ValidateInstall(ValidateInstallModel model)
        {
            return "value";
        }

        // POST: api/SmallBusinessManager
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SmallBusinessManager/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SmallBusinessManager/5
        public void Delete(int id)
        {
        }
    }
}
