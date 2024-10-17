using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RoxCAD.Backend
{
    public class SavedPortStore
    {
        static string filePath = "RoxCAD.PortStore.rox";


        public static int LoadSavedPort()
        {
            if (File.Exists(filePath))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    return reader.ReadInt32();
                }
            }

            return 6071;
        }

        public static void SavePort(int port)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(port);
            }
        }
    }
}
