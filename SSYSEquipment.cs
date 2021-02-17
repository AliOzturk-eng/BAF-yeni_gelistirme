using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavlama
{
    public class SSYSEquipment
    {
        public string EkipmanNo { get; set; }
        public string EkipmanTipi { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string AlanKodu { get; set; }
        public string AlanTanimi { get; set; }
        public string HatKodu { get; set; }
        public string HatTanimi { get; set; }
        public string BolgeKodu { get; set; }
        public string BolgeTanimi { get; set; }
        public string CalTipi { get; set; }
        public bool Havuz { get; set; }
        public bool Paketleme { get; set; }

    }
}
