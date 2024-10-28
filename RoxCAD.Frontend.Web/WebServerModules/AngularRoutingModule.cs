using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmbedIO;
using RoxCAD.Shared;

namespace RoxCAD.Frontend.Web.WebServerModules
{
    public class AngularRoutingModule : WebModuleBase
    {
        private readonly string _indexPath;

        public AngularRoutingModule(string indexPath) : base("/")
        {
            _indexPath = indexPath;
        }

        public override bool IsFinalHandler => true;

        protected override async Task OnRequestAsync(IHttpContext context)
        {
            var path = context.RequestedPath.Trim('/');

            var filePath = Path.Combine("www/", path);

            if (File.Exists(filePath))
            {
                var mimeType = GetMimeType(filePath);

                context.Response.StatusCode = 200;

                // Check if the file is binary (image, ico, etc.)
                if (mimeType.StartsWith("image") || mimeType == "application/octet-stream")
                {
                    // Serve binary files as a stream
                    using var fileStream = File.OpenRead(filePath);
                    context.Response.ContentType = mimeType;
                    context.Response.ContentLength64 = fileStream.Length;
                    await fileStream.CopyToAsync(context.Response.OutputStream);
                    return;
                }
                else
                {
                    // Serve text files (like HTML, CSS, JS)
                    var filePathContent = await File.ReadAllTextAsync(filePath);
                    await context.SendStringAsync(filePathContent, mimeType, Encoding.UTF8);
                    return;
                }
            }

            // Serve index.html for any other requests (fallback)
            context.Response.StatusCode = 200;
            context.Response.Headers["Content-Type"] = "text/html";

            var indexPath = Path.Combine("www/", "index.html");

            if (File.Exists(indexPath))
            {
                var indexHtmlContent = await File.ReadAllTextAsync(indexPath);
                await context.SendStringAsync(indexHtmlContent, "text/html", Encoding.UTF8);
            }
            else
            {
                context.Response.StatusCode = 404;
                await context.SendStringAsync("404 Not Found", "text/plain", Encoding.UTF8);
            }
        }

        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".js" => "application/javascript",
                ".css" => "text/css",
                ".html" => "text/html",
                ".json" => "application/json",
                ".png" => "image/png",
                ".ico" => "image/x-icon",
                ".jpg" => "image/jpeg",
                ".gif" => "image/gif",
                ".svg" => "image/svg+xml",
                _ => "application/octet-stream"
            };
        }
    }
}
