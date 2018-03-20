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
 *  File: Initialisation.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Website.Library.Core.Classes;
using Website.Library.Core.Interfaces;
using Website.Library.Core.Services;

using Library.DAL;
using Library.BOL.Websites;

namespace Website.Library.Core
{
    public static class Initialisation
    {
        public static IServiceProvider GetServiceProvider { get; private set; }

        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<ILogging, Logging>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<IBaseServices, BaseServices>();
            services.AddSingleton<IBaseWebApplication, BaseWebApplication>();
            services.AddSingleton<ILocalizedLanguages, LocalizedLanguages>();
            services.AddSingleton<IGeoIPLocation, GeoIPLocation>();

            GetServiceProvider = services.BuildServiceProvider();
        }

        public static void InitialiseWebsite(IApplicationBuilder app, IHostingEnvironment env)
        {
            IBaseWebApplication baseWebApplication = GetServiceProvider.GetRequiredService<IBaseWebApplication>();
            baseWebApplication.ApplicationStart();

            app.UseMiddleware<SessionMiddleware>();
        }
    }
}
