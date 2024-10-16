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
        var payloadData = PayloadData.GetPayloadData();
        context.Response.Headers.Add("X-RoxCAD-Payload", System.Text.Json.JsonSerializer.Serialize(payloadData));
    }
}
