using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.DependencyInjection;

namespace Shifoo.Website.Global
{
    public static class Initialiser
    {
        public static void InitialiseWebsite(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<SessionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseMiddleware<TimeMiddleware>();
            }
        }

        public static void InitialiseWebsite(IServiceCollection services)
        {
        }
    }
}
