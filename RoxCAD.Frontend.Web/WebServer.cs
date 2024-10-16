using EmbedIO;
using EmbedIO.Files;

using RoxCAD.Shared;

namespace RoxCAD.Frontend.Web
{
    public class WebServerApp
    {
        private readonly int _port;
        private readonly WebServer _server;

        public WebServerApp(int port)
        {
            _port = port;
            _server = new WebServer(o => o.WithUrlPrefix($"http://localhost:{_port}").WithMode(HttpListenerMode.EmbedIO))
                .WithModule(new CustomInjectModule())
                .WithModule(new FileModule("/", new FileSystemProvider("www/", true)))
                .WithLocalSessionManager();
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
