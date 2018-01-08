using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

// https://www.mikesdotnetting.com/article/269/asp-net-5-middleware-or-where-has-my-httpmodule-gone

namespace Shifoo.Website.Global
{
    public class TimeMiddleware
    {
        RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var sw = new Stopwatch();
            sw.Start();

            using (var memoryStream = new MemoryStream())
            {
                var bodyStream = context.Response.Body;
                context.Response.Body = memoryStream;

                await _next(context);

                var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
                if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
                {
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        using (var streamReader = new StreamReader(memoryStream))
                        {
                            var responseBody = await streamReader.ReadToEndAsync();
                            var newFooter = @"<footer><div id=""process"">Page processed in {0} milliseconds.</div>";
                            responseBody = responseBody.Replace("<footer>", string.Format(newFooter, sw.ElapsedMilliseconds));
                            context.Response.Headers.Add("X-ElapsedTime", new[] { sw.ElapsedMilliseconds.ToString() });
                            using (var amendedBody = new MemoryStream())
                            using (var streamWriter = new StreamWriter(amendedBody))
                            {
                                streamWriter.Write(responseBody);
                                amendedBody.Seek(0, SeekOrigin.Begin);
                                await amendedBody.CopyToAsync(bodyStream);
                            }
                        }
                    }
                }
            }
        }
    }
}