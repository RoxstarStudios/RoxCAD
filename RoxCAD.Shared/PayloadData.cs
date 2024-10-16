using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoxCAD.Shared
{
    public class PayloadData
    {
        private static Dictionary<string, string> payloadData = new();

        public static void SetPayloadData(Dictionary<string, string> _payloadData)
        {
            payloadData = _payloadData;
        }

        public static Dictionary<string, string> GetPayloadData()
        {
            return payloadData;
        }
    }
}
