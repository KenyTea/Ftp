using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftp.lib
{
    [Serializable]
    public class GoodsReceipt
    {
        public string Tipe { get; set; }

        public INVOICE[] INVOICE { get; set; }
    }
    [Serializable]
    public class INVOICE
    {
        public int BUKRS { get; set; }

        public int KUNNR { get; set; }
        public ITEMS[] ITEMS { get; set; }
    }
    [Serializable]
    public class ITEMS
    {
        public string MTART { get; set; }
    }
}