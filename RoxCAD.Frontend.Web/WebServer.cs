using EmbedIO;
using EmbedIO.Files;

using RoxCAD.Frontend.Web.WebServerModules;
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
            _server = new WebServer(o => o.WithUrlPrefix($"http://*:{_port}/").WithMode(HttpListenerMode.EmbedIO))
                .WithCors("*")
                .WithModule(new CustomInjectModule())
                .WithModule(new AngularRoutingModule(Path.Combine("www", "index.html")))
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
                    ServerEndpoint = "/"
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
