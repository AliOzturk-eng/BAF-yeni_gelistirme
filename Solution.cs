using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Tavlama
{
    public class Solution
    {
        public List<IsemriL> IsemriTable { get; }

        private int DurumCounter = 0;

        private bool vinc2_on = true;
        private bool vinc3_on = true;


        private int timelimit = 30;
        private int min_kolon;
        private int max_kolon;
        private int vinc2_ilkkonum;
        private int vinc3_ilkkonum;
        private int[,] vinc_sinirlar = null;
        private double parameterCakisma = 1;
        private bool detayliyaz = false;

        private int eniyi_kactane_bol = 4;
        private int bol_timelimit = 8;

        private int eniyi_kactane = 3;
        private Dictionary<Durum, Yapilacak> cevap;
        private Dictionary<IsemriL, string> Predecessor;
        public Solution(List<IsemriL> isemriTable, int min_kolon, int max_kolon)
        {
            this.min_kolon = min_kolon;
            this.max_kolon = max_kolon;
            // IsEmriTable == problem.list (gerek var mı? extra memory?)
            this.IsemriTable = isemriTable;
            vinc_sinirlar = new int[2, 2] { { 1, (max_kolon - 2) }, { 2, max_kolon } };
            vinc2_ilkkonum = this.min_kolon;
            vinc3_ilkkonum = this.max_kolon;
            SkorlariTersCevir();
            PredecessorOlustur();
            PredecessorYazdir();
        }

        private void PredecessorYazdir()
        {
            foreach(var r in Predecessor.Keys)
            {
                Console.WriteLine(r.UniqueID + "->" + Predecessor[r]);
            }
        }

        public void SkorlariTersCevir()
        {
            double maxSkor = 0;
            foreach (var i in this.IsemriTable)
            {
                if (i.skor > maxSkor)
                {
                    maxSkor = i.skor;
                }
            }
            foreach (var i in this.IsemriTable)
            {
                i.skor = maxSkor - i.skor + 100;
            }
        }

        public void Solve(out List<IsemriL> WorkList)
        {
            Console.WriteLine($"{this.IsemriTable.Count} is emri mevcut. {this.timelimit} dakika icinde yapilacaklar optimize ediliyor...");
            this.cevap = new Dictionary<Durum, Yapilacak>();
            String[] yapilanisler = new String[0];
            WorkList = new List<IsemriL>();
            detay dummy = new detay();
            double totalcost;

            detay vinc2iptal = new detay();
            vinc2iptal.bitimzamani = timelimit + 1;
            vinc2iptal.baslangiczamani = 0;
            vinc2iptal.bitimkonumu = vinc2_ilkkonum;

            detay vinc3iptal = new detay();
            vinc3iptal.bitimzamani = timelimit + 1;
            vinc3iptal.baslangiczamani = 0;
            vinc3iptal.bitimkonumu = vinc3_ilkkonum;

            Durum simdikidurum;


            if (this.vinc2_on && this.vinc3_on)
                simdikidurum = new Durum(this.DurumCounter++, 0, yapilanisler, false, false, this.vinc2_ilkkonum, this.vinc3_ilkkonum, dummy, dummy);
            else if (this.vinc2_on)
                simdikidurum = new Durum(this.DurumCounter++, 0, yapilanisler, false, true, this.vinc2_ilkkonum, this.vinc3_ilkkonum, dummy, vinc3iptal);
            else
                simdikidurum = new Durum(this.DurumCounter++, 0, yapilanisler, true, false, this.vinc2_ilkkonum, this.vinc3_ilkkonum, vinc2iptal, dummy);

            if (this.vinc2_on && this.vinc3_on)
                totalcost = RecursiveFun(simdikidurum, null, null);
            else if (this.vinc2_on)
                totalcost = RecursiveFun(simdikidurum, null, null);
            else
                totalcost = RecursiveFun(simdikidurum, null, null);

            //resolve the answer here

            while (simdikidurum.getZaman() < this.timelimit && this.cevap.Keys.Contains(simdikidurum))
            {
                Yapilacak yap = this.cevap[simdikidurum];
                int aksiyon = yap.aksiyontipi;
                string yazilacak = yap.id;

                IsemriL data = IsemriTable.FirstOrDefault(o => o.UniqueID.Equals(yazilacak));

                string temp;

                if (aksiyon == 2)
                {
                    temp = ($"t={simdikidurum.getZaman()}, {data.AtmosphereTuru},  vinc 2 ile {data.Konum1Kaide} nolu kaideden {data.Konum2Kaide} nolu kaideye {data.Yapilacakis} | {data.UniqueID}  |  Konum (kolon1) {data.Konum1Kolon}  Konum (kolon2) {data.Konum2Kolon} | {yap.skor}");
                    data.VincNo = 2;
                    data.yapilacagi_dk = simdikidurum.getZaman();
                    Console.WriteLine(temp);
                    Program.writeLog(temp, "ATAMA");
                }
                else if (aksiyon == 3)
                {

                    temp = ($"t={simdikidurum.getZaman()}, {data.AtmosphereTuru},   vinc 3 ile {data.Konum1Kaide} nolu kaideden {data.Konum2Kaide} nolu kaideye {data.Yapilacakis} | {data.UniqueID} |  Konum (kolon1) {data.Konum1Kolon}  Konum (kolon2) {data.Konum2Kolon} | {yap.skor}");
                    data.VincNo = 3;
                    data.yapilacagi_dk = simdikidurum.getZaman();
                    Console.WriteLine(temp);
                    Program.writeLog(temp, "ATAMA");
                }
                else
                {
                    Console.WriteLine($"{yap.id}");
                    Program.writeLog($"{yap.id}", "ATAMA");
                }
                WorkList.Add(data);
                simdikidurum = yap.sonDurum;
            }
        }

        private double RecursiveFun(Durum baslangicDurumu, string V2SonIs, string V3SonIs)
        {
            //asagidaki is emirlerini iceren her durum icin, sirada hangi islere bakacagini ve skorlarini raporlar
            string[] incelenecekListe = { "60010101020HNX","50020101020H2"};

            if (baslangicDurumu.t >= this.timelimit)
            {
                return 0;
            }

            //eger iki vinc'te calisiyorsa en kucuklerinin bitim zamanina gidilebilir.
            if (baslangicDurumu.V2Durum && baslangicDurumu.V3Durum && baslangicDurumu.t < baslangicDurumu.V2Detay.bitimzamani && baslangicDurumu.t < baslangicDurumu.V3Detay.bitimzamani)
            {
                Durum next = new Durum(this.DurumCounter++, Math.Min(baslangicDurumu.V2Detay.bitimzamani, baslangicDurumu.V3Detay.bitimzamani), baslangicDurumu.yapilan, baslangicDurumu.V2Durum, baslangicDurumu.V3Durum, baslangicDurumu.V2Konum, baslangicDurumu.V3Konum, baslangicDurumu.V2Detay, baslangicDurumu.V3Detay);
                double sonuc = RecursiveFun(next, V2SonIs, V3SonIs);
                Yapilacak yp = new Yapilacak(0, $"{Math.Min(baslangicDurumu.V2Detay.bitimzamani, baslangicDurumu.V3Detay.bitimzamani) - baslangicDurumu.t} dk bekle", sonuc, next);
                this.cevap.Add(baslangicDurumu, yp);
                return sonuc;
            }

            /***
            Su kopyalari olustur: V2Guncel, V3Guncel, V2Gkonum, V3Gkonum, V2Gdetay, V3Gdetay, islistesi
            **/
            double tnow = baslangicDurumu.t;
            bool V2Guncel = baslangicDurumu.V2Durum;
            bool V3Guncel = baslangicDurumu.V3Durum;
            int V2Gkonum = baslangicDurumu.V2Konum;
            int V3Gkonum = baslangicDurumu.V3Konum;
            // reference type - kopya yarattigina emin olmali
            detay V2Gdetay = new detay();
            V2Gdetay.setDetay(baslangicDurumu.V2Detay.baslangiczamani, baslangicDurumu.V2Detay.bitimzamani, baslangicDurumu.V2Detay.baslangickonumu, baslangicDurumu.V2Detay.bitimkonumu);
            detay V3Gdetay = new detay();
            V3Gdetay.setDetay(baslangicDurumu.V3Detay.baslangiczamani, baslangicDurumu.V3Detay.bitimzamani, baslangicDurumu.V3Detay.baslangickonumu, baslangicDurumu.V3Detay.bitimkonumu);
            string[] islistesi = new string[baslangicDurumu.yapilan.Length];
            for (int i = 0; i < baslangicDurumu.yapilan.Length; i++) islistesi[i] = baslangicDurumu.yapilan[i].ToString();
            // kopyalar olustu


            //bittiyse isler vinc konumunu guncelle
            if (V2Guncel && V2Gdetay.bitimzamani == tnow)
            {
                V2Guncel = false;
                V2Gkonum = V2Gdetay.bitimkonumu;
            }
            if (V3Guncel && V3Gdetay.bitimzamani == tnow)
            {
                V3Guncel = false;
                V3Gkonum = V3Gdetay.bitimkonumu;
            }

            // KRITIK: cakisma vs olduysa ve biri digerini (aktif ya da degil) ittirdiyse burada sacmalamamasi icin konumu guncelliyorum
            // bu zaten issiz olan da olabilir, isi yeni biten de olabilir

            if (!V2Guncel)
            {
                int v3nerede = 0;
                if (V3Guncel)
                    v3nerede = V3Gdetay.bitimkonumu;
                else
                    v3nerede = V3Gkonum;
                V2Gkonum = Math.Min(V2Gkonum, v3nerede - 2);
            }
            if (!V3Guncel)
            {
                int v2nerede = 0;
                if (V2Guncel)
                    v2nerede = V2Gdetay.bitimkonumu;
                else
                    v2nerede = V2Gkonum;
                V3Gkonum = Math.Max(V3Gkonum, v2nerede + 2);
            }

            //YAZDIRIP YAZDIRMAMA KARARI

            bool yazdir = false; 
            if (this.detayliyaz)
            {
                yazdir = true;
                foreach (var b in incelenecekListe)
                    yazdir = yazdir && islistesi.Contains(b);
                yazdir = yazdir && (islistesi.Length == incelenecekListe.Length);
            }
            bool[] secki2 = new bool[IsemriTable.Count];
            bool[] secki3 = new bool[IsemriTable.Count];
            double[] skor2 = new double[IsemriTable.Count];
            double[] skor3 = new double[IsemriTable.Count];
            for (int u = 0; u < IsemriTable.Count; u++)
            {
                skor2[u] = 0;
                skor3[u] = 0;
            }

            bool enAzBirIsUygun = false;


            for (int u = 0; u < IsemriTable.Count; u++)
            {
                // eger is yapilmadiysa, onculeri yapildiysa, zamani geldiyse
                //!!! MUTLAKA EKLE : Alternatifinin oncusu yapilmadiysa... 
                if (DoesNotInclude(islistesi, IsemriTable[u].UniqueID) && onculersaglandi(IsemriTable[u], islistesi) && tnow >= IsemriTable[u].IntZaman)
                {
                    enAzBirIsUygun = true;
                    detay YAPANVINCdetay = new detay();
                    VincNumarasi vincNo = new VincNumarasi();//  VincNo vincNo;
                    YAPANVINCdetay.setDetay(tnow, tnow + Convert.ToDouble(IsemriTable[u].Issuresi), Convert.ToInt32(IsemriTable[u].Konum1Kolon), Convert.ToInt32(IsemriTable[u].Konum2Kolon));

                    if (!V2Guncel)
                    {
                        vincNo = VincNumarasi.vinc2;
                        if (sinirlaricinde(2, IsemriTable[u]))
                        {
                            // sag yarimindaysa layoutun cok az cezalandiriyorum - skor eksilterek
                            skor2[u] = IsemriTable[u].skor - .5 * sagda(IsemriTable[u]) - this.parameterCakisma * cakisma(vincNo, V2Gkonum, YAPANVINCdetay, V3Guncel, V3Gkonum, V3Gdetay);
                        }
                    }
                    if (!V3Guncel)
                    {
                        if (sinirlaricinde(3, IsemriTable[u]))
                        {
                            vincNo = VincNumarasi.vinc3;
                            // sol yarimindaysa cok az cezalandiriyorum
                            skor3[u] = IsemriTable[u].skor - .5 * solda(IsemriTable[u]) - this.parameterCakisma * cakisma(vincNo, V3Gkonum, YAPANVINCdetay, V2Guncel, V2Gkonum, V2Gdetay);
                        }
                    }
                }
            }

            // bu durumdaki hepsinin kismi skorunu basti - simdi kacina bakacagina karar verip en iyi 2-4 tanesinden secki olusturacak
            if (!enAzBirIsUygun)
            {
                Durum next = new Durum(this.DurumCounter++, tnow + 0.5, baslangicDurumu.yapilan, baslangicDurumu.V2Durum, baslangicDurumu.V3Durum, baslangicDurumu.V2Konum, baslangicDurumu.V3Konum, baslangicDurumu.V2Detay, baslangicDurumu.V3Detay);
                double sonuc = RecursiveFun(next, V2SonIs, V3SonIs);
                Yapilacak yp = new Yapilacak(0, $"{0.5} dk bekle", sonuc, next);
                this.cevap.Add(baslangicDurumu, yp);
                return sonuc;
            }
            else
            {
                // kacinabak dinamik degisiyor, bastan 4 alternatife bakarken sonra 2'ye dusuyor. 
                int kacinabak = eniyi_kactane;
                if (baslangicDurumu.t < bol_timelimit)
                {
                    kacinabak = eniyi_kactane_bol;
                }
                bool v2ZorluIs = false;
                bool v3ZorluIs = false;

                v2ZorluIs = zorundalikTara(islistesi, secki2, skor2, skor3, V2SonIs);
                v3ZorluIs = zorundalikTara(islistesi, secki3, skor3, skor2, V3SonIs);


                // v2ZorluIs ya da v3ZorluIs true olmasi demek, onun devam eden ya da bitmis isi var, digeri o isi yapamaz demek.
                // eger devam etmekteyse zaten guncel'i true'dur tarama yapmayacakti
                // eger bittiyse ve tarayacaktiysa da bu durumda taramasin, zaten zorundalikTara icinde secki'sini true yaptim sira yapmak zorunda oldugu isi

                if (!V2Guncel && !v2ZorluIs) tara(secki2, skor2, kacinabak);
                if (!V3Guncel && !v3ZorluIs) tara(secki3, skor3, kacinabak);


                // yazdir = true;
                if (yazdir)
                {
                    Console.Write("Yapilanlar @ " + tnow + " ");
                }
                if (yazdir)
                {
                    foreach (var u in islistesi) Console.Write(u + " ");
                    Console.Write("\n Bakilanlar (tekadimda): ");
                    for (int u = 0; u < IsemriTable.Count; u++)
                    {
                        if (secki2[u] || secki3[u])
                        {
                            Console.Write(IsemriTable[u].UniqueID + " ");
                            if (secki2[u])
                                Console.Write("vinc2 "+skor2[u] + " ");
                            if (secki3[u])
                                Console.Write("vinc3 " + skor3[u] + " ");
                        }
                    }
                }
                string[] geciciisler = new string[islistesi.Length + 1];


                double[] vinc2ileyaparsam = new double[IsemriTable.Count];
                double[] vinc3ileyaparsam = new double[IsemriTable.Count];
                Durum[] vinc2ileyaparsamSonDurum = new Durum[IsemriTable.Count];
                Durum[] vinc3ileyaparsamSonDurum = new Durum[IsemriTable.Count];

                for (int u = 0; u < IsemriTable.Count; u++)
                {
                    vinc2ileyaparsam[u] = 0;
                    vinc3ileyaparsam[u] = 0;
                }

                for (int i = 0; i < IsemriTable.Count; i++)
                {
                    if (secki2[i] || secki3[i])
                    {
                        for (int k = 0; k < islistesi.Length; k++)
                        {
                            geciciisler[k] = islistesi[k];
                        }
                        geciciisler[islistesi.Length] = IsemriTable[i].UniqueID;

                        //YAPANVINCdetay -> tumisler.Rows[i]'daki islerin detaylari olmali
                        //baska hic bir sey degismemeli
                        //EKLE : seyahat suresini eklemedik, vinc uzaksa!
                        //EKLE: is yapinca reward eklemeli, yoksa hic bir sey yapmamak 0 maliyetle optimal cikar
                        detay YAPANVINCdetay = new detay();
                        YAPANVINCdetay.setDetay(tnow, tnow + Convert.ToDouble(IsemriTable[i].Issuresi), Convert.ToInt32(IsemriTable[i].Konum1Kolon), Convert.ToInt32(IsemriTable[i].Konum2Kolon));

                        //!!! EKLE: maliyet eksik, raw sure vs maliyeti islerin... asagidaki iki equation'da da eksik. travel time eksik!
                        if (!V2Guncel && secki2[i])
                        {
                            Durum next = new Durum(this.DurumCounter++, tnow, geciciisler, true, V3Guncel, V2Gkonum, V3Gkonum, YAPANVINCdetay, V3Gdetay);
                            vinc2ileyaparsam[i] = skor2[i] + RecursiveFun(next, IsemriTable[i].UniqueID, V3SonIs);
                            vinc2ileyaparsamSonDurum[i] = next;
                        }
                        if (!V3Guncel && secki3[i])
                        {
                            Durum next = new Durum(this.DurumCounter++, tnow, geciciisler, V2Guncel, true, V2Gkonum, V3Gkonum, V2Gdetay, YAPANVINCdetay);
                            vinc3ileyaparsam[i] = skor3[i] + RecursiveFun(next, V2SonIs, IsemriTable[i].UniqueID);
                            vinc3ileyaparsamSonDurum[i] = next;
                        }
                    }
                }


                if (yazdir)
                {
                    Console.Write("\n Bakilanlar (recursion): ");
                    for (int u = 0; u < IsemriTable.Count; u++)
                    {
                        if (secki2[u] || secki3[u])
                        {
                            Console.Write(IsemriTable[u].UniqueID + " ");
                            if (secki2[u])
                                Console.Write("vinc2 " + vinc2ileyaparsam[u] + " ");
                            if (secki3[u])
                                Console.Write("vinc3 " + vinc3ileyaparsam[u] + " ");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }

                //Console.WriteLine();


                int aksiyon = -1;
                double maximumsayi = 0;
                double vinc2ileyaparsamMax = vinc2ileyaparsam.Max();
                double vinc3ileyaparsamMax = vinc3ileyaparsam.Max();


                if (vinc2ileyaparsamMax > maximumsayi)
                {
                    maximumsayi = vinc2ileyaparsamMax;
                    aksiyon = 2;
                }

                if (vinc3ileyaparsamMax > maximumsayi)
                {
                    maximumsayi = vinc3ileyaparsamMax;
                    aksiyon = 3;
                }

                Yapilacak yap;
                Durum sonDurum;

                if (aksiyon == 2)
                {
                    int satir = Array.IndexOf(vinc2ileyaparsam, maximumsayi);
                    //Console.WriteLine($"{t} zamaninda vinc 2 ile {IsemriTable[Array.IndexOf(vinc2ileyaparsam, minimumsayi)].UniqueID} isini yap.");
                    sonDurum = vinc2ileyaparsamSonDurum[satir];
                    yap = new Yapilacak(aksiyon, IsemriTable[satir].UniqueID, maximumsayi, sonDurum);
                    this.cevap.Add(baslangicDurumu, yap);
                }
                else if (aksiyon == 3)
                {
                    int satir = Array.IndexOf(vinc3ileyaparsam, maximumsayi);
                    //Console.WriteLine($"{t} zamaninda vinc 3 ile {IsemriTable[Array.IndexOf(vinc3ileyaparsam, minimumsayi)].UniqueID} isini yap.");
                    sonDurum = vinc3ileyaparsamSonDurum[satir];
                    yap = new Yapilacak(aksiyon, IsemriTable[satir].UniqueID, maximumsayi, sonDurum);
                    this.cevap.Add(baslangicDurumu, yap);
                }
                else
                {   // bulamadigina gore ikisi de bossa tamam, degilse devam eden bitmeli

                    if (!V2Guncel && !V3Guncel)
                    {
                        return 0;
                    }
                    else
                    {
                        //eger iki vinc'te calisiyorsa en kucuklerinin bitim zamanina gidilebilir.
                        if (V2Guncel && tnow < V2Gdetay.bitimzamani)
                        {
                            Durum next = new Durum(this.DurumCounter++, V2Gdetay.bitimzamani, islistesi, V2Guncel, V3Guncel, V2Gkonum, V3Gkonum, V2Gdetay, V3Gdetay);
                            double sonuc = RecursiveFun(next, V2SonIs, V3SonIs);
                            Yapilacak yp = new Yapilacak(0, $"{V2Gdetay.bitimzamani - tnow} dk (vinc3 idle) bekle", sonuc, next);
                            this.cevap.Add(baslangicDurumu, yp);
                            return sonuc;
                        }
                        if (V3Guncel && tnow < V3Gdetay.bitimzamani)
                        {
                            Durum next = new Durum(this.DurumCounter++, V3Gdetay.bitimzamani, islistesi, V2Guncel, V3Guncel, V2Gkonum, V3Gkonum, V2Gdetay, V3Gdetay);
                            double sonuc = RecursiveFun(next, V2SonIs, V3SonIs);
                            Yapilacak yp = new Yapilacak(0, $"{V3Gdetay.bitimzamani - tnow} dk (vinc2 idle) bekle", sonuc, next);
                            this.cevap.Add(baslangicDurumu, yp);
                            return sonuc;
                        }
                    }
                }
                return maximumsayi;
            }
        }

        private bool sinirlaricinde(int vincNo, IsemriL isemriL)
        {
            int vincIndex = vincNo - 2;
            int lowerIndex = this.vinc_sinirlar[vincIndex, 0];
            int upperIndex = this.vinc_sinirlar[vincIndex, 1];
            int konum1 = Convert.ToInt32(isemriL.Konum1Kolon);
            int konum2 = Convert.ToInt32(isemriL.Konum2Kolon);
            return konum1 <= upperIndex && konum1 >= lowerIndex && konum2 <= upperIndex && konum2 >= lowerIndex;
        }

        private double solda(IsemriL isemriL)
        {
            int cevap = Convert.ToInt32(Convert.ToInt32(isemriL.Konum1Kolon) + Convert.ToInt32(isemriL.Konum2Kolon) < this.max_kolon + this.min_kolon);
            // sifirsa -1, 1 ise 1 donmeli
            return 2 * cevap - 1;
        }

        private double sagda(IsemriL isemriL)
        {
            return -solda(isemriL);
        }

        private bool zorundalikTara(string[] islistesi, bool[] secki, double[] skor, double[] digerVincskor, string sonis)
        {
            bool arananZorundalikBulundu = false;
            string sonrakiIsIlkAltiHanesi = BirSonraAyniVincYapmakZorunda(sonis);
            if (sonrakiIsIlkAltiHanesi != "") // ilk 6 digit doner
            {
                for (int i = 0; i < IsemriTable.Count; i++)
                {
                    if (ilkAltiDigit(IsemriTable[i].UniqueID).Equals(sonrakiIsIlkAltiHanesi) && !islistesi.Contains(IsemriTable[i].UniqueID)) //yapilmasi gereken sonraki isi bulduk vinc icin
                    {
                        digerVincskor[i] = 0; // digeri yapamaz
                        arananZorundalikBulundu = true;
                        // break yapmiyorum cunku sirasi gelen var gelmeyen var. hepsi icin diger vinc yapamaz diye max'a esitlesin, ama yapabilecegi varsa
                        // asagida onu belirliyorum
                        if (skor[i] > 0)// onculeri tamam ki skor hesaplanmis, bunun kesinlikle secki'de olmasi gerekir
                            secki[i] = true;
                    }
                }
            }
            return arananZorundalikBulundu;
        }

        private void tara(bool[] secki, double[] skor, int kacinabak)
        {
            for (int k = 0; k < kacinabak; k++)
            {
                double maxskor = 0;
                int ind = -1;
                for (int i = 0; i < IsemriTable.Count; i++)
                {
                    if (skor[i] > maxskor && !secki[i])
                    {
                        maxskor = skor[i];
                        ind = i;
                    }
                }
                if (ind != -1)
                    secki[ind] = true;
            }

        }

        private string BirSonraAyniVincYapmakZorunda(string sonis)
        {
            string sonraki = "";
            if (sonis != null)
            {
                int ilkD = ilkDigit(sonis);
                if (ilkD == 6 || ilkD == 7)
                {
                    sonraki = (ilkD + 1) + islemID(sonis);
                }
                else if (ilkD == 8)
                {
                    sonraki = ilkD + islemID(sonis);
                }
            }
            return sonraki;
        }
        private string ilkAltiDigit(string v)
        {
            return v.Substring(0, 6);
        }

        private int ilkDigit(string v)
        {
            return (int)Double.Parse(v.Substring(0, 1));
        }

        private bool DoesNotInclude(string[] islistesi, string uniqueID)
        {
            bool hasit = false;
            foreach (String s in islistesi)
            {
                if (s.Equals(uniqueID))
                {
                    hasit = true;
                    break;
                }
            }
            return !hasit;
        }

        private bool onculersaglandi(IsemriL isemriL, string[] islistesi)
        {
            if (Predecessor.ContainsKey(isemriL))
            {
                string oncu = Predecessor[isemriL];
                if (oncu is null)
                    return true;
                else
                    return islistesi.Contains(oncu);
            }
            else
                return true;
        }

        private void PredecessorOlustur()
        {
            this.Predecessor = new Dictionary<IsemriL, string>();

            foreach (var vrow in this.IsemriTable)
            {
                string v = vrow.UniqueID;
             
                string islem = islemID(v);
                int sirasi = siraID(v);
                string tipi = tipID(v);
                int agrup = altgrup(v);

                if (sirasi == 1)
                {
                    this.Predecessor.Add(vrow, null);
                }
                else
                {
                    foreach (var krow in this.IsemriTable)
                    {
                        string k = krow.UniqueID;
                        string islemK = islemID(k);
                        int sirasiK = siraID(k);
                        string tipiK = tipID(k);
                        int agrupk = altgrup(k);

                        if (islemK.Equals(islem) && tipiK.Equals(tipi) && sirasiK == sirasi - 1 && Ustgrup(agrup) == Ustgrup(agrupk))
                        {
                            if (vrow.Konum2Kaide == krow.Konum2Kaide || vrow.Konum1Kaide == krow.Konum1Kaide)
                            {
                                this.Predecessor.Add(vrow, k);
                            }
                        }
                    }
                }
            }
        }

        private int Ustgrup(int agrup)
        {
            int ug = 0;
            if (agrup <= 3)
            {
                ug = 1;
            }
            else if (agrup <= 5)
            {
                ug = 2;
            }
            else
            {
                ug = 3;
            }
            return ug;
        }

        private int altgrup(string v)
        {
            return Convert.ToInt32(v.Substring(0, 1)); // ilk digit
        }

        private string tipID(string v)
        {
            return v.Substring(11, 2); // HN ya da H2
        }

        private int siraID(string v)
        {
            return Convert.ToInt32(v.Substring(6, 2)); // İşlem içi iş emri sırası
        }

        private string islemID(string v)
        {
            return v.Substring(1, 5); // Tarihe göre işlem sırası +	Alternatifler
        }

        private bool alternatifyapildi(String v, string[] islistesi) { return true; }

        double cakisma(VincNumarasi vincNo, int degerlendirilen_vincin_konumu, detay yapilacak_is_detaylari, Boolean diger_vinc_aktif_mi, int diger_vincin_konumu, detay diger_vinc_is_detaylari)
        {
            double katsayi = 10;

            // BOS VINC HAREKETLERINI DEGERLENDIRMIYORUZ - O YUZDEN GIRDIGIMIZDE YER DEGISTIRMIS GORUNEBILIRLER, BURADA ONA GORE DEGERLENDIRMEK ICIN:
            if (vincNo == VincNumarasi.vinc2 && degerlendirilen_vincin_konumu >= diger_vincin_konumu)
            {
                degerlendirilen_vincin_konumu = diger_vincin_konumu - 2;
            }
            if (vincNo == VincNumarasi.vinc3 && degerlendirilen_vincin_konumu <= diger_vincin_konumu)
            {
                degerlendirilen_vincin_konumu = diger_vincin_konumu + 2;
            }
            // ASLINDA ITTIRDIGIM YERDEN BASLATIYORUM ARTIK.

            // degerlendirilen vinc (konum, zaman): konum1, zaman1 -> konum2, zaman2
            int konum1 = degerlendirilen_vincin_konumu;
            int konum2 = yapilacak_is_detaylari.baslangickonumu;
            int konum3 = yapilacak_is_detaylari.bitimkonumu;
            double zaman1 = yapilacak_is_detaylari.baslangiczamani;
            double zaman2 = zaman1 + 0.5;
            double zaman3 = yapilacak_is_detaylari.bitimzamani;
            // diger vinc (konum, zaman): digerKonum1,digerZaman1 -> digerKonum2, digerZaman2
            int digerKonum1 = diger_vincin_konumu; // bu hic onemli degil aslinda
            int digerKonum2, digerKonum3;
            double digerZaman1, digerZaman2, digerZaman3;

            if (diger_vinc_aktif_mi)
            {
                digerKonum2 = diger_vinc_is_detaylari.baslangickonumu;
                digerKonum3 = diger_vinc_is_detaylari.bitimkonumu;
                digerZaman1 = diger_vinc_is_detaylari.baslangiczamani - 0.5;
                digerZaman2 = diger_vinc_is_detaylari.baslangiczamani;
                digerZaman3 = diger_vinc_is_detaylari.bitimzamani;
            }
            else
            {
                digerKonum2 = digerKonum1;
                digerKonum3 = digerKonum1;
                digerZaman1 = zaman1;
                digerZaman2 = zaman1 + .5;
                digerZaman3 = zaman2 + .5;
            }
            return katsayi * cakismaZamanMesafe(vincNo, konum1, konum2, konum3, zaman1, zaman2, zaman3, digerKonum1, digerKonum2, digerKonum3, digerZaman1, digerZaman2, digerZaman3);
        }

        private double cakismaZamanMesafe(VincNumarasi vincNo, int konum1, int konum2, int konum3, double zaman1, double zaman2, double zaman3, int digerKonum1, int digerKonum2, int digerKonum3, double digerZaman1, double digerZaman2, double digerZaman3)
        {
            double mesafehareketederken = 0;
            double mesafeisyaparken = 0;
            double sureisyaparken = 0;

            if (digerZaman1 >= zaman1 - .05)// ayni anda hareket ediyorlarsa
            //double esit gelmez diye bu sekilde yaziyorum: istenen sart su (digerZaman1==zaman1) ama diger zaman daha buyuk olamaz zaten
            {
                if ((konum1 < digerKonum1 && konum2 < digerKonum2) || (konum1 > digerKonum1 && konum2 > digerKonum2)) // bu durumda cakismaz
                {
                    mesafehareketederken = 0;
                }
                else
                {
                    // baslangic ya da bitisteki tuhafligin maksimumunu aliyorum cakisma olarak
                    mesafehareketederken = Math.Max(Math.Abs(konum1 - digerKonum1) + 2, Math.Abs(digerKonum2 - konum2) + 2);
                }
            }
            //ayni anda hareket etsin ya da etmesin bundan sonra degerlendirilen isin yapilis suresindeki cakisma hesaplanir
            //son baslayandan ilk bitene kadar gecen sure 
            sureisyaparken = Math.Max(0, Math.Min(zaman3, digerZaman3) - Math.Max(zaman2, digerZaman2));

            //konum1ie bakarak kım ne tarafta anlıyoruz
            //
            if ((vincNo == VincNumarasi.vinc2 && konum2 < digerKonum2 && konum3 < digerKonum3) || (vincNo == VincNumarasi.vinc3 && konum2 > digerKonum2 && konum3 > digerKonum3)) // bu durumda cakismaz
            {
                mesafeisyaparken = 0;
            }
            else
            {
                // yolun ortasinda diger is var
                // harekete basladigim degil varacagim yere uzakligi onemli - cunku sonunda oraya push edecegim bunu yapacaksam
                mesafeisyaparken = Math.Abs(konum3 - digerKonum3) + 2;
            }

            return mesafehareketederken * 0.5 + mesafeisyaparken * sureisyaparken;
        }
    }
}
