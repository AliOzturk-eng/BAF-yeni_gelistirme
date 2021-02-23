using System;
namespace Tavlama
{
    public class Sogutmacan
    {
        public int No;
        public String AtmosphereType;
        public String StatusText;
        public int BaseNumber;
        public int IsIdled;
        public double Xkor;
        public double Ykor;
        // burası parametreleri verdiğin anda oluşturur objeyi
        //   public Sogutmacan(int no, String atmosphereType, String statusText, int baseNumber, int isIdled)
        //    {
        //      No = no;
        //      AtmosphereType = atmosphereType;
        //      StatusText = statusText;
        //      BaseNumber = baseNumber;
        //      IsIdled = isIdled;
        //    }

        public Sogutmacan() { } // default verilerle hazırlar. parametresiz
    }
}
