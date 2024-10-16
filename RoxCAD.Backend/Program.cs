using RoxCAD.Backend.API;
using RoxCAD.Backend.WS;
using RoxCAD.Frontend.Web;
using RoxCAD.Shared;

using Swan.Logging;

using Colors.Net;
using Colors.Net.StringColorExtensions;
using static Colors.Net.StringStaticMethods;

namespace RoxCAD.Backend
{
    internal class Program
    {
        public static int BackendApiPort = 6071;
        public static int BackendWSPort = 6072;
        public static int FrontendWebPort = 6073;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logger.UnregisterLogger<ConsoleLogger>();

            SetPortsDialog.BackendApiPort = BackendApiPort;
            SetPortsDialog.BackendWSPort = BackendWSPort;
            SetPortsDialog.FrontendWebPort = FrontendWebPort;

            SetPortsDialog portsDialog = new SetPortsDialog();

            var portsDialogResult = portsDialog.ShowDialog();

            if (portsDialogResult == DialogResult.OK)
            {
                BackendApiPort = SetPortsDialog.BackendApiPort;
                BackendWSPort = SetPortsDialog.BackendWSPort;
                FrontendWebPort = SetPortsDialog.FrontendWebPort;
            }

            PayloadData.SetPayloadData(new Dictionary<string, string>
            {
                {
                    "api_url", $"http://localhost:{BackendApiPort}/"
                },
                {
                    "ws_url", $"http://localhost:{BackendWSPort}/"
                }
            });

            ColoredConsole.WriteLine(Red($@"Starting {"RoxCAD".DarkMagenta()} Servers")).WriteLine();

            var apiServer = new ApiServer(BackendApiPort);
            var wsServer = new WsServer(BackendWSPort);

            var apiTask = apiServer.StartAsync();
            var wsTask = wsServer.StartAsync();

            if (apiTask.Success == false && wsTask.Success == false) return;

            ColoredConsole.WriteLine(Magenta($@"Backend Data Servers Running"))
            .WriteLine(Gray($@"Backend Interface (API) Server: {$"http://localhost:{apiTask.Port}/".Blue()}"))
            .WriteLine(Gray($@"Backend WebSocket (WS) Server: {$"http://localhost:{wsTask.Port}/".Blue()}")).WriteLine();

            var webServer = new WebServerApp(FrontendWebPort);

            var webTask = webServer.StartAsync();

            if (webTask.Success == false) return;

            ColoredConsole.WriteLine(Magenta($@"Frontend Web Server Running"))
            .WriteLine(Gray($@"Frontend Website (App) Server: {$"http://localhost:{webTask.Port}/".Blue()}")).WriteLine();

            ColoredConsole.WriteLine(DarkGreen($@"Started {"RoxCAD".DarkMagenta()} Servers")).WriteLine();

            ColoredConsole.WriteLine(Gray($@"Press {"Enter".DarkGray()} to stop {"RoxCAD".DarkMagenta()} Servers"));

            Console.ReadLine();
        }
    }
}
