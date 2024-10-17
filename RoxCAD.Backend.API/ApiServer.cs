using RoxCAD.Shared;
using EmbedIO;
using EmbedIO.Actions;

namespace RoxCAD.Backend.API
{
    public class ApiServer
    {
        private readonly int _port;
        private readonly WebServer _server;

        public ApiServer(int port)
        {
            _port = port;
            _server = new WebServer(o => o.WithUrlPrefix($"http://*:{_port}/api/").WithMode(HttpListenerMode.EmbedIO))
                .WithCors("*")
                .WithModule(new ActionModule("/api", HttpVerbs.Any, ctx => ctx.SendStringAsync("Hello from API Server!", "text/plain", System.Text.Encoding.UTF8)));
        }

        public ServerTaskResult StartAsync()
        {
            try
            {
                _server.RunAsync();

                return new ServerTaskResult
                {
                    Success = true,
                    HostUrl = _server.Options.UrlPrefixes[0].Replace("*", "127.0.0.1")
                };
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);

                return new ServerTaskResult
                {
                    Success = false,
                };
            }
        }
    }
}
