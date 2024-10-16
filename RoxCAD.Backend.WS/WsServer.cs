using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.WebSockets;

using RoxCAD.Shared;

namespace RoxCAD.Backend.WS
{
    public class WsServer
    {
        private readonly int _port;
        private readonly WebServer _server;

        public WsServer(int port)
        {
            _port = port;
            _server = new WebServer($"http://localhost:{_port}")
                .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendStringAsync("Hello from WS Server!", "text/plain", System.Text.Encoding.UTF8)));
        }

        public ServerTaskResult StartAsync()
        {
            try
            {
                _server.RunAsync();

                return new ServerTaskResult
                {
                    Success = true,
                    Port = _port
                };
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);

                return new ServerTaskResult
                {
                    Success = false,
                    Port = _port
                };
            }
        }
    }
}
