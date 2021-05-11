using System;
using System.ComponentModel;

namespace Tavlama
{
	public enum WorkType
	{
		[Description("Bobin Taşıma")]
		bobin_tasima = 1,
		[Description("Soğutma Çanı Tak")]
		scan_tak = 2,
		[Description("Soğutma Çanı Çıkart")]
		scan_cikart = 3,
		[Description("Gömlek Tak")]
		gomlek_tak = 4,
		[Description("Gömlek Çıkart")]
		gomlek_cikart = 5,
		[Description("Fırın Tak")]
		firin_tak = 6,
		[Description("Fırın Çıkart")]
		firin_cikart = 7,
		[Description("Konvektör Tak")]
		konvektor_tak = 8,
		[Description("Konvektör Çıkart")]
		konvektor_cikart = 9
	}
	public enum WorkTypeDetail { kaide_bosalt = 1, kaide_yukle = 2 , Others = 3}
	public class IsemriL
    {
		public String UniqueID;
		public DateTime Zaman;
		public double IntZaman;
		public double EkipmanX;
		public double EkipmanY;
		public string Konum1Kolon;
		public string Konum1Kaide;
		public double AlHatX;
		public double AlHatY;
		public string Konum2Kolon;
		public string Konum2Kaide;
		public double BirakHatX;
		public double BirakHatY;
		public string AtacmanTipi;
		public double Issuresi;
		public string AtmosphereTuru;
		public string Yapilacakis;
		public string Yapilacakisturu;
		public double skor;
		public string equipmentNumber;
		public WorkType isTipi;
		public WorkTypeDetail isDetayi;
		public int VincNo;
		public double yapilacagi_dk;
		public IsemriL()
        {

        }
		public void konumlar(string k1k,string k2k) {
			this.Konum1Kaide = k1k;
			this.Konum2Kaide = k2k;
		}
	}
}