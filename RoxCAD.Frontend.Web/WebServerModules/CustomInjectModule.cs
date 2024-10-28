using EmbedIO;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using RoxCAD.Shared;

public class CustomInjectModule : WebModuleBase
{
    public CustomInjectModule() : base("/")
    {
    }

    public override bool IsFinalHandler => false;

    protected override async Task OnRequestAsync(IHttpContext context)
    {
        var path = context.RequestedPath;

        await Task.Delay(0);

        if (path == "/api" || path == "/ws")
        {
            var redirectUrl = path + "/";
            context.Response.StatusCode = 301;
            context.Response.Headers["Location"] = redirectUrl;
            context.SetHandled();
        }
    }
}
