using System;

namespace Tavlama
{
    internal class Durum
    {
        public int durumId;
        public double t;
        public string[] yapilan;
        public bool V2Durum, V3Durum;
        public int V2Konum, V3Konum;
        public detay V2Detay, V3Detay;
        public Durum(int counter,double t, string[] yapilan, bool V2Durum, bool V3Durum, int V2Konum, int V3Konum, detay V2Detay, detay V3Detay)
        {
            this.durumId = counter;
            this.t = t;
            this.yapilan = new string[yapilan.Length];
            for (int y = 0; y < yapilan.Length; y++)
                this.yapilan[y] = yapilan[y];

            this.V2Durum = V2Durum;
            this.V3Durum = V3Durum;
            this.V2Konum = V2Konum;
            this.V3Konum = V3Konum;
            this.V2Detay = new detay();
            this.V3Detay = new detay();
            this.V2Detay.setDetay(V2Detay.baslangiczamani, V2Detay.bitimzamani, V2Detay.baslangickonumu, V2Detay.bitimkonumu);
            this.V3Detay.setDetay(V3Detay.baslangiczamani, V3Detay.bitimzamani, V3Detay.baslangickonumu, V3Detay.bitimkonumu);
        }

        public double getZaman()
        {
            return this.t;
        }
    }
}