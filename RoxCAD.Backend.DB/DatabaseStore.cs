using System.Security.Cryptography.X509Certificates;

using Couchbase;

namespace RoxCAD.Backend.DB
{
    public class DatabaseStore
    {
        private static readonly object _padlock = new();
        private static ICluster _instance;

        private DatabaseStore()
        {

        }

        public static ICluster Instance
        {
            get
            {
                lock (_padlock)
                {
                    var options = new ClusterOptions
                    {
                        UserName = "",
                        Password = "",
                        EnableTls = true
                    };

                    return _instance ??= Cluster.ConnectAsync("couchbases://", options).GetAwaiter().GetResult();
                }
            }
        }
    }
}
