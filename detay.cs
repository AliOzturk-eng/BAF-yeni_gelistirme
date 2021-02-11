using System;

namespace Tavlama
{
    internal class detay
    {
        public double baslangiczamani;
        public double bitimzamani;
        public int baslangickonumu;
        public int bitimkonumu;
        public detay()
        {

        }
       
        public void setDetay(double a, double b, int j, int k)
        {
            this.baslangiczamani = a;
            this.bitimzamani = b;
            this.baslangickonumu = j;
            this.bitimkonumu = k;
        }

        internal bool DetayEq(detay vDetay)
        {
            if (this.baslangickonumu==vDetay.baslangickonumu && this.baslangiczamani==vDetay.baslangiczamani && this.bitimzamani == vDetay.bitimzamani && this.bitimkonumu == vDetay.bitimkonumu)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}