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
        public static int ServicePort = 6071;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logger.UnregisterLogger<ConsoleLogger>();

            ServicePort = SavedPortStore.LoadSavedPort();

            SetPortsDialog.ServicePort = ServicePort;

            SetPortsDialog portsDialog = new();

            var portsDialogResult = portsDialog.ShowDialog();

            if (portsDialogResult == DialogResult.OK)
            {
                ServicePort = SetPortsDialog.ServicePort;
            }

            ColoredConsole.WriteLine(Red($@"Starting {"RoxCAD".DarkMagenta()} Servers")).WriteLine();

            ApiServer apiServer = new(ServicePort);
            WsServer wsServer = new(ServicePort);

            var apiTask = apiServer.StartAsync();
            var wsTask = wsServer.StartAsync();

            if (apiTask.Success == false && wsTask.Success == false) return;

            ColoredConsole.WriteLine(Magenta($@"Backend Data Servers Running"))
            .WriteLine(Gray($@"Backend Interface (API) Server: {$"http://127.0.0.1:{ServicePort}{apiTask.ServerEndpoint}".Blue()}"))
            .WriteLine(Gray($@"Backend WebSocket (WS) Server: {$"http://127.0.0.1:{ServicePort}{wsTask.ServerEndpoint}".Blue()}")).WriteLine();

            WebServerApp webServer = new(ServicePort);

            var webTask = webServer.StartAsync();

            if (webTask.Success == false) return;

            ColoredConsole.WriteLine(Magenta($@"Frontend Web Server Running"))
            .WriteLine(Gray($@"Frontend Website (App) Server: {$"http://127.0.0.1:{ServicePort}{webTask.ServerEndpoint}".Blue()}")).WriteLine();

            ColoredConsole.WriteLine(DarkGreen($@"Started {"RoxCAD".DarkMagenta()} Servers")).WriteLine();

            SavedPortStore.SavePort(ServicePort);

            ColoredConsole.WriteLine(Gray($@"Press {"Enter".DarkGray()} to stop {"RoxCAD".DarkMagenta()} Servers"));

            Console.ReadLine();
        }
    }
}
