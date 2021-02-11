using System;

namespace Tavlama
{
    internal class Yapilacak
    {
        public int aksiyontipi;
        public String id;
        public double skor;
        public Durum sonDurum;
        public Yapilacak(int aksiyontipi,String id,double skor,Durum sonDurum)
        {
            this.aksiyontipi = aksiyontipi;
            this.id = id;
            this.skor = skor;
            this.sonDurum = sonDurum;
        }

    }
}