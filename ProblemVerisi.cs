using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Tavlama
{
	public class ProblemVerisi
	{
		private double parameterSure = 0.5; //Queryable
		private double parameterOncelik = 3;
		public JsonReader JSONdosyalar { get; set; }
		public List<Prosesbitim> ProsesbitimListesi { get; set; }
		public List<Prosesbitim> ProsesbitimListesiO { get; set; }
		public List<Kaide> KaideListesi { get; set; }
		public List<Gomlek> GomlekListesi { get; set; }
		public List<Firin> FirinListesi { get; set; }
		public List<Sogutmacan> SogutmacanListesi { get; set; }
		public List<Kaidebobin> KaideBobinListesi { get; set; }
		public List<SSYSEquipment> SSYSEquipmentList { get; set; }
		//public List<SSYSBobin> SSYSBobinList { get; set; }
		public List<IsemriL> list { get; set; }
		public List<IsemriL> YukleListHNX { get; set; }
		public List<IsemriL> YukleListH2 { get; set; }
		public List<IsemriL> YuklemeIsListe { get; set; }
		public Konvektor konvektor { get; set; }
		public Liste liste { get; set; }
		public Kaidebobin kaidebobin { get; set; }
		public Bobinsayisi bobinsayisi { get; set; }
		public string idStringHazirla(int oncelik, int islem_sira, int alternatif, int emirSira, double sure, string AtmType)
		{
			return oncelik + (islem_sira % 1000).ToString("D3") + alternatif.ToString("D2") + emirSira.ToString("D2") + ((int)(sure)*10).ToString("D3") + AtmType;
		}
	/*
		static DataTable UygunIcGomlekH2(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'H2'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//	Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable UygunIcGomlekHNX(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'HNX'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//			Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		
		static DataTable UygunFirinHNX(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'HNX'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//	Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable UygunFirinH2(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'H2'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//	Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;
		}

		static DataTable UygunKaideHNX(DataTable dt)
		{
			//dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'HNX'";
			dt.DefaultView.RowFilter = "StatusText = 'BOŞALTILDI' AND AtmosphereType = 'HNX'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable UygunKaideH2(DataTable dt)
		{
			//dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'H2'";
			dt.DefaultView.RowFilter = "StatusText = 'BOŞALTILDI' AND AtmosphereType = 'H2'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable UygunSoCaHNX(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'HNX'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//		Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable UygunSoCaH2(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '1' AND AtmosphereType = 'H2'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//	Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		*/
		public List<Firin> GetUygunFirin(string AType) {
			return FirinListesi.Where(o => o.IsIdled == 1 && o.AtmosphereType.Equals(AType)).ToList();
		}
		public List<Sogutmacan> GetUygunSoCa(bool isFull,string AType)
		{
			return SogutmacanListesi.Where(o => o.IsIdled == 1 && o.AtmosphereType.Equals(AType)).ToList();
		//	return SogutmacanListesi.Where(o => (isFull || (!isFull && o.IsIdled == 1)) && o.AtmosphereType.Equals(AType)).ToList();
		}
		public List<Kaide> GetUygunKaideler(string AType) {
			//return KaideListesi.Where(o => o.StatusText.Equals("BOŞALTILDI") && o.AtmosphereType.Equals(AType)).ToList();
			return KaideListesi.Where(o => o.IsIdled ==1 && o.AtmosphereType.Equals(AType)).ToList();
		}

		public List<Gomlek> GetUygunGomlek(string AType)
		{
			return GomlekListesi.Where(o => o.IsIdled == 1 && o.AtmosphereType.Equals(AType)).ToList();
		}
		private double skorhesapla(string uniqueID)
		{
			double oncelik = 0;
			oncelik += IsEmriOncelik(uniqueID) * this.parameterOncelik;
			oncelik += Double.Parse(uniqueID.Substring(8, 3)) / 10 * this.parameterSure;
			if(uniqueID.Substring(11, 2)=="H2")
            {
				oncelik = 2 * oncelik;
            }
			else
            {
				oncelik = 3 * oncelik;
            }
			return oncelik;
		}

        private double IsEmriOncelik(string uniqueID)
        {
			int[] onemSirasi = { 3, 2, 1, 6, 5, 4, 8, 7 };
			//int[] puan = { 50, 50, 50, 25, 50, 50, 10, 25 };
			int[] puan = { 1, 2, 3, 25, 16, 17, 60, 37 };
			int sonuc =0;
			int ilkDigit = (int) Double.Parse(uniqueID.Substring(0, 1));
			for(int i=0;i<onemSirasi.Length;i++)
            {
				if(ilkDigit==onemSirasi[i])
                {
					sonuc = puan[i];
					break;
                }
            }
			return sonuc;
		}

        public int ProcessBitimNumber;
		public ProblemVerisi(bool isFull)
		{
			JSONdosyalar = new JsonReader();
			DataTable DTtahmini_proses_bitim = new DataTable();
			DataTable OOtahmini_proses_bitim = new DataTable();
			DataTable DTkaide = new DataTable();
			DataTable DTgomlek = new DataTable();
			DataTable DTfirin = new DataTable();
			DataTable DTsogutmacani = new DataTable();
			DataTable DTkonvektor = new DataTable();
			DataTable DTliste = new DataTable();
			DataTable DTkaidebobin = new DataTable();
			DataTable DTbobinsayisi = new DataTable();
			DataTable bobinsayisi = new DataTable();
			DataTable DTEquipList = new DataTable();
			DataTable DTZoneList = new DataTable();
			DataTable CreateSsysWorkOrder = new DataTable();
			DataTable BobinBatchList = new DataTable();
			string[] SonucArray = new string[100];
			Console.WriteLine("web service bağlanılıyor-" + DateTime.Now.ToString());
			BAF_WebService.BAF_WebService objService = new BAF_WebService.BAF_WebService();


			byte equipmentID = 1;
			DTtahmini_proses_bitim = objService.GetAnnealingEstimatedProcessEnding().Tables[0];
			DTkaide = objService.GetAnnealingEquipments(equipmentID).Tables[0];
			DTgomlek = objService.GetAnnealingEquipments(++equipmentID).Tables[0];
			DTfirin = objService.GetAnnealingEquipments(++equipmentID).Tables[0];
			DTsogutmacani = objService.GetAnnealingEquipments(++equipmentID).Tables[0];
			DTkonvektor = objService.GetAnnealingEquipments(++equipmentID).Tables[0];
			DTkaidebobin = objService.GetAnnealingWarehouseBatchesForLogistic().Tables[0];
			DTliste = objService.GetAnnealingStateRecords().Tables[0];
			DTEquipList = objService.GetSsysEquipmentList().Tables[0];
			DTZoneList = objService.GetSsysBafZoneDefinitions().Tables[0];
			BobinBatchList = objService.GetSsysBatchList("").Tables[0];
			//objService.CreateSsysWorkOrder(strObjeNo, strObjeTipi, strEmirTipi, strAlHat, strBrkHat, strAciklama);
			OOtahmini_proses_bitim = DTtahmini_proses_bitim;
			DataTable CS = new DataTable(); 
			CS = objService.GetSsysForcedCoolingOverview().Tables[0];
			DataTable SSYSCraneLOC = new DataTable();
			SSYSCraneLOC = objService.GetSsysCraneLocations().Tables[0];
			List<SSYSBobin> SSYSBobinList = new List<SSYSBobin>();
			foreach (DataRow dr in BobinBatchList.Rows)
			{
				SSYSBobin eq = new SSYSBobin();
				eq.BobinNo = dr["BobinNo"].ToString();
				eq.X = Convert.ToDouble(dr["X"].ToString());
				eq.Y = Convert.ToDouble(dr["Y"].ToString());
				SSYSBobinList.Add(eq);
			}
			List<CebriSog> CebriSListe = new List<CebriSog>();
			foreach (DataRow dr in CS.Rows)
			{
				CebriSog ceb = new CebriSog();
				ceb.AlanKodu = dr["AlanKodu"].ToString();
				ceb.AlanTanimi = dr["AlanTanimi"].ToString();
				ceb.X1 = Convert.ToInt32(dr["X1"].ToString());
				ceb.Y1 = Convert.ToInt32(dr["Y1"].ToString());
				ceb.X2 = Convert.ToInt32(dr["X2"].ToString());
				ceb.Y2 = Convert.ToInt32(dr["Y2"].ToString());
				ceb.HatKodu = dr["HatKodu"].ToString();
				ceb.BobinSayisi = Convert.ToInt32(dr["BobinSayisi"].ToString());
				CebriSListe.Add(ceb);
			}

			SSYSEquipmentList = new List<SSYSEquipment>();
			foreach (DataRow dr in DTEquipList.Rows)
			{
				SSYSEquipment eq = new SSYSEquipment();
				eq.EkipmanNo = dr["EkipmanNo"].ToString();
				eq.EkipmanTipi = dr["EkipmanTipi"].ToString();
				eq.CalTipi = dr["CalTipi"].ToString();
				eq.AlanKodu = dr["AlanKodu"].ToString();
				eq.AlanTanimi = dr["AlanTanimi"].ToString();
				eq.BolgeKodu = dr["BolgeKodu"].ToString();
				eq.BolgeTanimi = dr["BolgeTanimi"].ToString();
				eq.HatKodu = dr["HatKodu"].ToString();
				eq.HatTanimi = dr["HatTanimi"].ToString();
				eq.Havuz = dr["Havuz"].ToString().Length>0 ? Convert.ToBoolean(dr["Havuz"].ToString()):false;
				eq.Paketleme = dr["Paketleme"].ToString().Length > 0 ? Convert.ToBoolean(dr["Paketleme"].ToString()):false;
				eq.X = Convert.ToDouble(dr["X"].ToString());
				eq.Y = Convert.ToDouble(dr["Y"].ToString());
				eq.Z = Convert.ToDouble(dr["Z"].ToString());

				SSYSEquipmentList.Add(eq);
			}

			SogutmacanListesi = new List<Sogutmacan>();
			foreach (DataRow dr in DTsogutmacani.Rows)
			{
				// objeyi oluşturmak gerekiyor. Parametresiz oluşturacaksan constructor eklemen lazım
				// İstersen Sogutmacan(int no, String atmosphereType, String statusText, int baseNumber, int isIdled) olarak doldurabilirsin
				Sogutmacan sogutmacani = new Sogutmacan();
				sogutmacani.No = Convert.ToInt32(dr["No"].ToString());
				sogutmacani.AtmosphereType = dr["AtmosphereType"].ToString();
				sogutmacani.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				sogutmacani.StatusText = dr["StatusText"].ToString();
				sogutmacani.IsIdled = Convert.ToInt32(dr["IsIdled"].ToString());
				/*
				if (sogutmacani.IsIdled == 1)
				{
					int indexX = SSYSEquipmentList.FindIndex(x => x.EkipmanNo.Trim().Equals("SC" + sogutmacani.No));
					if (indexX >= 0)
					{
						if (SSYSEquipmentList[indexX].AlanKodu != "00008_SA") { sogutmacani.IsIdled = 0; }
					}
				}
				// yukardakileri direkt constructor içinde de yazabilirsin. Classta parametrelerle tanımlamıştık, yapmicam şimdi :D
				*/
				int indexSCX = SSYSEquipmentList.FindIndex(x => x.EkipmanNo.Trim().Equals("SC" + sogutmacani.No));
				if (indexSCX >= 0)
				{
					sogutmacani.Xkor = SSYSEquipmentList[indexSCX].X;
					sogutmacani.Ykor = SSYSEquipmentList[indexSCX].Y;
				}
				SogutmacanListesi.Add(sogutmacani);
			}
			
			KaideListesi = new List<Kaide>();
			foreach (DataRow dr in DTkaide.Rows)
			{
				Kaide kaide = new Kaide();
				kaide.AtmosphereType = dr["AtmosphereType"].ToString();
				kaide.No = Convert.ToInt32(dr["No"].ToString());
				kaide.StatusText = dr["StatusText"].ToString();
				kaide.IsIdled = Convert.ToInt32(dr["IsIdled"].ToString());

				// Phoenixten gelen isIDle=true ise kontrol et
				/*if (kaide.IsIdled==1) {
					int index = SSYSEquipmentList.FindIndex(x => x.AlanKodu.Trim().Equals(kaide.AtmosphereType.Trim() +"_"+ kaide.No));
					if (index >= 0)
						kaide.IsIdled = 0;
				}
				*/
				int indexX = SSYSEquipmentList.FindIndex(x => x.AlanKodu.Trim().Equals(kaide.AtmosphereType.Trim() + "_" + kaide.No));
				
				if(indexX >= 0) { 
				   kaide.Xkor = SSYSEquipmentList[indexX].X;
				   kaide.Ykor = SSYSEquipmentList[indexX].Y;
				}
				KaideListesi.Add(kaide);
			}
			GomlekListesi = new List<Gomlek>();
			foreach (DataRow dr in DTgomlek.Rows)
			{
				Gomlek gomlek = new Gomlek();
				gomlek.No = Convert.ToInt32(dr["No"].ToString());
				gomlek.AtmosphereType = dr["AtmosphereType"].ToString();
				gomlek.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				gomlek.StatusText = dr["StatusText"].ToString();
				gomlek.IsIdled = Convert.ToInt32(dr["IsIdled"].ToString());
				/*
				if (gomlek.IsIdled == 1)
				{
					int indexX = SSYSEquipmentList.FindIndex(x => x.EkipmanNo.Trim().Equals("G" + gomlek.No));
					if (indexX >= 0)
					{
						if (SSYSEquipmentList[indexX].AlanKodu != "00008_SA") { gomlek.IsIdled = 0; }
					}
				}
				*/
				int indexGX = SSYSEquipmentList.FindIndex(x => x.EkipmanNo.Trim().Equals("G" + gomlek.No));
				if (indexGX >= 0)
				{
					gomlek.Xkor = SSYSEquipmentList[indexGX].X;
					gomlek.Ykor = SSYSEquipmentList[indexGX].Y;
				}
				GomlekListesi.Add(gomlek);
			}
			FirinListesi = new List<Firin>();
			foreach (DataRow dr in DTfirin.Rows)
			{
				Firin firinl = new Firin();
				firinl.AtmosphereType = dr["AtmosphereType"].ToString();
				firinl.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				firinl.Phase = Convert.ToInt32(dr["Phase"].ToString());
				firinl.StatusText = dr["StatusText"].ToString();
				firinl.IsIdled = Convert.ToInt32(dr["IsIdled"].ToString());
				firinl.No = Convert.ToInt32(dr["No"].ToString());
				/*
				if (firinl.IsIdled == 1)
				{
					int indexX = SSYSEquipmentList.FindIndex(x => x.EkipmanNo.Trim().Equals("F" + firinl.No));
					if (indexX >= 0)
					{
						if (SSYSEquipmentList[indexX].AlanKodu != "00008_SA") { firinl.IsIdled = 0; }
					}
				}
				*/
				int indexFX = SSYSEquipmentList.FindIndex(x => x.EkipmanNo.Trim().Equals("F" + firinl.No));
				if (indexFX >= 0)
				{
					firinl.Xkor = SSYSEquipmentList[indexFX].X;
					firinl.Ykor = SSYSEquipmentList[indexFX].Y;
				}
				FirinListesi.Add(firinl);
			}
			//	OOtahmini_proses_bitim.DefaultView.RowFilter = "ProcessEnd = '1.01.1900 00:00:00'";
			//	OOtahmini_proses_bitim = OOtahmini_proses_bitim.DefaultView.ToTable();
			//	OOtahmini_proses_bitim.DefaultView.RowFilter = "State = '102'";
			//	OOtahmini_proses_bitim = OOtahmini_proses_bitim.DefaultView.ToTable();
			DateTime TimeNow = DateTime.Now;
			DateTime UpTimeNow = TimeNow.AddMinutes(120);
			if (isFull) { 
				UpTimeNow = TimeNow.AddMinutes(720);
				}
			//Console.WriteLine(TimeNow);
			string TimeNowS = TimeNow.ToString();
			//TimeNow.ToString("MM.dd.yyyy HH:mm:ss");
		//	DTtahmini_proses_bitim.DefaultView.RowFilter = "ProcessEnd > #1.01.1900 00:00:00#";
		//	DTtahmini_proses_bitim = DTtahmini_proses_bitim.DefaultView.ToTable();
			DTtahmini_proses_bitim.DefaultView.RowFilter = "ProcessEnd <#"+ UpTimeNow.ToString("MM.dd.yyyy HH:mm:ss")+"#";
			DTtahmini_proses_bitim = DTtahmini_proses_bitim.DefaultView.ToTable();
			DTtahmini_proses_bitim.DefaultView.Sort = "ProcessEnd";
			DTtahmini_proses_bitim = DTtahmini_proses_bitim.DefaultView.ToTable();
			ProsesbitimListesi = new List<Prosesbitim>();
			foreach (DataRow dr in DTtahmini_proses_bitim.Rows)
			{
				Prosesbitim ProcessBitimL = new Prosesbitim();
				ProcessBitimL.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				ProcessBitimL.PlugNumber = Convert.ToInt32(dr["PlugNumber"].ToString());
				ProcessBitimL.InnerBellNumber = Convert.ToInt32(dr["InnerBellNumber"].ToString());
				ProcessBitimL.ProgramNumber = Convert.ToInt32(dr["ProgramNumber"].ToString());
				ProcessBitimL.State = Convert.ToInt32(dr["State"].ToString());
				ProcessBitimL.ProcessEnd = dr["ProcessEnd"].ToString();
				ProsesbitimListesi.Add(ProcessBitimL);
				//	}
			}
			KaideBobinListesi = new List<Kaidebobin>();
			foreach (DataRow dr in DTkaidebobin.Rows)
			{
				Kaidebobin kaideBobin = new Kaidebobin();
				kaideBobin.BatchNumber = dr["BatchNumber"].ToString();
				kaideBobin.BatchOrder = Convert.ToInt32(dr["BatchOrder"].ToString());
				kaideBobin.ProgramNumber = Convert.ToInt32(dr["ProgramNumber"].ToString());
				kaideBobin.Status = dr["Status"].ToString();
				kaideBobin.A510_B = dr["A510_B"].ToString();
				KaideBobinListesi.Add(kaideBobin);	
			}

			//	ProsesbitimListesiO = new List<Prosesbitim>();
			//	foreach (DataRow drO in OOtahmini_proses_bitim.Rows)
			//	{
			//		Prosesbitim ProcessBitimO = new Prosesbitim();
			//		ProcessBitimO.BaseNumber = Convert.ToInt32(drO["BaseNumber"].ToString());
			//		ProcessBitimO.PlugNumber = Convert.ToInt32(drO["PlugNumber"].ToString());
			//		ProcessBitimO.State = Convert.ToInt32(drO["State"].ToString());
			//		ProcessBitimO.ProcessEnd = drO["ProcessEnd"].ToString();
			//		ProsesbitimListesiO.Add(ProcessBitimO);
			//
			//	}
			//Console.WriteLine(DTkaidebobin.DefaultView.Count);
			//Console.WriteLine(ProsesbitimListesiO.Count);
			list = new List<IsemriL>();
			YukleListHNX = new List<IsemriL>();
			YukleListH2 = new List<IsemriL>();
			YuklemeIsListe = new List<IsemriL>();
			int IS_TAHMIN = ProsesbitimListesi.Count;
			int islem_sirasiTAV = 1;
			int islem_sirasiBOS = 1;
			int islem_sirasiSOG = 1;
			List<Firin> UygunFurH2 = GetUygunFirin( "H2");
			List<Firin> UygunFurH2Faz1 = UygunFurH2.Where(o => o.Phase ==1).ToList();
			List<Firin> UygunFurH2Faz2 = UygunFurH2.Where(o => o.Phase == 2).ToList();
			List<Firin> UygunFurHNX = GetUygunFirin("HNX");
			List<Kaide> UygunKaideATMHNX = GetUygunKaideler("HNX");
			List<Kaide> UygunKaideATMH2 = GetUygunKaideler("H2");
			//List<Sogutmacan> UygunSOCAHNX = GetUygunSoCa("HNX");
			//List<Sogutmacan> UygunSOCAH2 = GetUygunSoCa("H2");
			List<Sogutmacan> UygunSOCAHNX = GetUygunSoCa(isFull, "HNX");
			List<Sogutmacan> UygunSOCAH2 = GetUygunSoCa(isFull, "H2");
			List<CebriSog> UygunCS = CebriSListe.Where(o => o.BobinSayisi == 0).ToList();
			for (int i = 0; i < IS_TAHMIN; i++)
			{
				IsemriL isemri = new IsemriL();
				Prosesbitim ProTurn = ProsesbitimListesi[i];
				
				int ISXLOKASYON = Convert.ToInt32(KaideListesi.Find(e => e.No == ProTurn.BaseNumber).Xkor); 
				int emir_sirasiTAV = 1;
				int emir_sirasiBOS = 1;
				int emir_sirasiSOG = 1;
				string id_strBOS;
				string id_strTAV;
				string id_strSOG;
				string id_strBOB;
				

				DateTime IsBas = Convert.ToDateTime(ProTurn.ProcessEnd);
				if (ProTurn.State == 202||ProTurn.State == 250) //
				{
					if (ProTurn.PlugNumber != 0) { 
					bobinsayisi = DTkaidebobin;
					int BobinNO = Convert.ToInt32(ProTurn.BaseNumber.ToString());
					bobinsayisi.DefaultView.RowFilter = String.Format("ProgramNumber  = '{0}'", BobinNO);
					bobinsayisi.DefaultView.RowFilter = $"ProgramNumber  = '{BobinNO}'";
					List<Kaidebobin> BobinTas = KaideBobinListesi.Where(o => o.ProgramNumber == ProTurn.BaseNumber).ToList();
					Console.WriteLine(bobinsayisi.Rows[5]["BatchNumber"].ToString());
					
					if (bobinsayisi.DefaultView.Count > 0)
					{
						IsemriL isemriSC = new IsemriL();
						isemriSC.Konum1Kaide = ProTurn.BaseNumber.ToString();

						TimeSpan ZamanFark = IsBas - DateTime.Now;
							//yoksa bu şekilde zaman farkı falan hesaplayamazsın, ya da zaman<diğer zaman gibi if içine koyamazsın
						//	int zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
						if (Hazir(IsBas))
						{
							isemriSC.IntZaman = 0;
						}
					else
						{
							double zamfark = Convert.ToDouble(ZamanFark.TotalMinutes);
							isemriSC.IntZaman = Math.Round(zamfark, 1);
						}


						isemriSC.Zaman = IsBas;

						

						if (ProTurn.BaseNumber <= 34)
						{
							isemriSC.AtmosphereTuru = "HNX";
							isemriSC.AtacmanTipi = "Konvektor Tasima Aparatı";
							isemriSC.Issuresi = 2.5;
							//süretaşimaBOS = Convert.ToDouble(SureTable.Rows[20]["Süre"]);
						}
						else
						{
							isemriSC.AtmosphereTuru = "H2";
							isemriSC.AtacmanTipi = "Yok";
							isemriSC.Issuresi = 2.5;
							//süretaşimaBOS = Convert.ToDouble(SureTable.Rows[8]["Süre"]);
						}
							var koloneslesme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurn.BaseNumber);

							isemriSC.Konum1Kaide = ProTurn.BaseNumber.ToString();
							isemriSC.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriSC.Konum1Kolon = koloneslesme.Kolonno + "";
							isemriSC.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriSC.Yapilacakis = ProTurn.PlugNumber + "nolu Sogutma Canını çıkart" ;
						isemriSC.isTipi = WorkType.scan_cikart;
						isemriSC.isDetayi = WorkTypeDetail.kaide_bosalt;
						isemriSC.equipmentNumber = ProTurn.PlugNumber.ToString();
						isemriSC.Yapilacakisturu = "Soğuma bitişi";
						id_strSOG = idStringHazirla(6, islem_sirasiSOG, 1, emir_sirasiSOG, isemriSC.Issuresi, isemriSC.AtmosphereTuru);
						isemriSC.UniqueID = id_strSOG;
							/*if (isemriSC.AtmosphereTuru == "H2")
							{
								isemriSC.skor = 3 * skorhesapla(isemriSC.UniqueID);
							}
							else
							{
								isemriSC.skor = 2 * skorhesapla(isemriSC.UniqueID);
							}*/
							//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim
							isemriSC.skor = skorhesapla(isemriSC.UniqueID); 
							

							list.Add(isemriSC);
						emir_sirasiSOG = emir_sirasiSOG + 1;

						IsemriL isemriGO = new IsemriL();
						if (ProTurn.BaseNumber <= 34)
						{
							isemriGO.AtmosphereTuru = "HNX";
							isemriGO.AtacmanTipi = "Konvektor Tasima Aparatı";
							isemriGO.Issuresi = 2.5;
							//süretaşimaSOG = Convert.ToDouble(SureTable.Rows[20]["Süre"]);
						}
						else
						{
							isemriGO.AtmosphereTuru = "H2";
							isemriGO.AtacmanTipi = "Yok";
							isemriGO.Issuresi = 2.5;
							//süretaşimaSOG = Convert.ToDouble(SureTable.Rows[8]["Süre"]);
						}
						isemriGO.Konum1Kaide = ProTurn.BaseNumber.ToString();
						TimeSpan ZamanFarkGO = IsBas - DateTime.Now;
						if (Hazir(IsBas))
							{
							isemriGO.IntZaman = 0;
						}
						else
						{
							double zamfarkGO = Convert.ToDouble(ZamanFarkGO.TotalMinutes);
							isemriGO.IntZaman = Math.Round((zamfarkGO + isemriGO.Issuresi), 1);
						}
				
						//int zamfarkGO = Convert.ToInt32(ZamanFarkGO.TotalMinutes);
				
				
						isemriGO.Zaman = IsBas.AddMinutes(2.5);
						isemriGO.Konum1Kaide = ProTurn.BaseNumber.ToString();
						isemriGO.Konum2Kaide = ProTurn.BaseNumber.ToString();
						isemriGO.Konum1Kolon = koloneslesme.Kolonno + "";
						isemriGO.Konum2Kolon = koloneslesme.Kolonno + "";
							//
							//	if (ProTurn.BaseNumber <= 34)
							//	{
							//		isemriGO.AtmosphereTuru = "HNX";
							//		isemriGO.AtacmanTipi = "Konvektor Tasima Aparatı";
							//		isemriGO.Issuresi = "2.5";
							//		//süretaşimaSOG = Convert.ToDouble(SureTable.Rows[20]["Süre"]);
							//	}
							//	else
							//	{
							//		isemriGO.AtmosphereTuru = "H2";
							//		isemriGO.AtacmanTipi = "Yok";
							//		isemriGO.Issuresi = "2.5";
							//		//süretaşimaSOG = Convert.ToDouble(SureTable.Rows[8]["Süre"]);
							//	}
							 
						List<Gomlek> GomlekOut = GomlekListesi.Where(o => o.BaseNumber == ProTurn.BaseNumber).ToList();
					//	isemriGO.Yapilacakis = GomlekOut[0].No +  "nolu Gömleği çıkart";
						isemriGO.Yapilacakis = ProTurn.InnerBellNumber + "nolu Gömleği çıkart";
						isemriGO.isTipi = WorkType.gomlek_cikart;
						isemriGO.equipmentNumber = ProTurn.InnerBellNumber.ToString();
						isemriGO.isDetayi = WorkTypeDetail.kaide_bosalt;
						isemriGO.Yapilacakisturu = "Soğuma bitişi";
						id_strSOG = idStringHazirla(7, islem_sirasiSOG, 1, emir_sirasiSOG, isemriGO.Issuresi, isemriGO.AtmosphereTuru);
						isemriGO.UniqueID = id_strSOG;
						isemriGO.skor = skorhesapla(isemriGO.UniqueID);
						//isemriGO.skor = 1.5*skorhesapla(isemriGO.UniqueID);
						//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim

							list.Add(isemriGO);
						//islem_sirasiSOG = islem_sirasiSOG + 1;
						emir_sirasiSOG = emir_sirasiSOG + 1;
				
				
						//	bobinsayisi = DTkaidebobin;
						//	int BobinNO = Convert.ToInt32(ProTurn.BaseNumber.ToString());
						//	bobinsayisi.DefaultView.RowFilter = String.Format("ProgramNumber  = '{0}'", BobinNO);
						//	bobinsayisi.DefaultView.RowFilter = $"ProgramNumber  = '{BobinNO}'";
						//Console.WriteLine("bobin sayisısısıs" + bobinsayisi.DefaultView.Count);
				        TimeSpan ZamanFarkBOS = IsBas - DateTime.Now;
				        double zamfarkBOS = Convert.ToDouble(ZamanFarkBOS.TotalMinutes);
						zamfarkBOS = Math.Round((isemriGO.IntZaman + isemriGO.Issuresi), 1);
				        zamfarkBOS = Math.Round((isemriSC.IntZaman + isemriSC.Issuresi), 1);
					//	List<CebriSog> UygunCS = CebriSListe.Where(o => o.BobinSayisi == 0).ToList();
						for (int j = 0; j < bobinsayisi.DefaultView.Count; j++)
						{
							IsemriL isemriBOS = new IsemriL();


							//tahmini_proses_bitim.Rows[i]["ProcessEnd"].ToString()


							//	isemriBOS.Konum1Kolon = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
							isemriBOS.Konum1Kaide = ProTurn.BaseNumber.ToString();
							isemriBOS.Konum1Kolon = koloneslesme.Kolonno + "";
							isemriBOS.Zaman = IsBas;
							isemriBOS.Konum2Kolon = "22";
							if (UygunCS.Count > 0) { isemriBOS.Konum2Kaide = UygunCS[0].AlanKodu; }
								//IsemriNewRowBEM["Konum2 -Kolon"] = "22 Cebir Soğutma";
								//IsemriNewRowBEM["Konum2 -Kaide"] = "22 Cebir Soğutma";
							if (Hazir(IsBas))
								{ isemriBOS.IntZaman = 0; }
							else
							{ isemriBOS.IntZaman = zamfarkBOS; }
							if (Convert.ToInt32(ProTurn.BaseNumber.ToString()) <= 34)
							{
								isemriBOS.AtmosphereTuru = "HNX";
								isemriBOS.AtacmanTipi = "Bobin Aparatı";
								isemriBOS.Issuresi = 4.0;
								//isemriBOS.IntZaman = zamfarkBOS;
								zamfarkBOS = zamfarkBOS + 4;
							}
							else
							{
								isemriBOS.AtmosphereTuru = "H2";
								isemriBOS.AtacmanTipi = "Bobin Aparatı";
								isemriBOS.Issuresi = 4.0;
								zamfarkBOS = zamfarkBOS + 4;
							}

						//		isemriBOS.Yapilacakis = BobinTas[j].BatchNumber + "--Nolu  Bobin taşı";// temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
								isemriBOS.Yapilacakis = BobinTas[bobinsayisi.DefaultView.Count-j-1].BatchNumber +  "--Nolu  Bobin taşı";// temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriBOS.isTipi = WorkType.bobin_tasima;
							isemriBOS.isDetayi = WorkTypeDetail.kaide_bosalt;
							isemriBOS.equipmentNumber = BobinTas[j].BatchNumber;
							isemriBOS.Yapilacakisturu = "Kaide boşalt";
							id_strBOB = idStringHazirla(8, islem_sirasiBOS, 1, emir_sirasiSOG, isemriBOS.Issuresi, isemriBOS.AtmosphereTuru);
							//islem_sirasiBOS = islem_sirasiBOS + 1;
							emir_sirasiSOG = emir_sirasiSOG + 1;
							isemriBOS.UniqueID = id_strBOB;
							isemriBOS.skor = skorhesapla(isemriBOS.UniqueID);
							list.Add(isemriBOS);

							emir_sirasiBOS = emir_sirasiBOS + 1;
							//	

						}
						
						islem_sirasiBOS = islem_sirasiBOS + 1;
						islem_sirasiSOG = islem_sirasiSOG + 1;



					}
				}
					if (UygunCS.Count > 0) { UygunCS.RemoveAt(0); }
					
				}
				else if (ProTurn.State == 1|| ProTurn.State == 2 || ProTurn.State == 3 || ProTurn.State == 4 || ProTurn.State == 5 || ProTurn.State == 6 || ProTurn.State == 7 || ProTurn.State == 8 || ProTurn.State == 9 || ProTurn.State == 10 || ProTurn.State == 20 || ProTurn.State == 200)
				{

				//	List<Kaide> UygunKaideATMHNX = GetUygunKaideler("HNX");
				//	List<Kaide> UygunKaideATMH2 = GetUygunKaideler("H2");



					IsemriL isemriTAVBIT = new IsemriL();
					isemriTAVBIT.Konum1Kaide = ProTurn.BaseNumber.ToString();

					double zamfark = 0;
					TimeSpan ZamanFark = IsBas - DateTime.Now;
					zamfark = ZamanFark.TotalMinutes;
					if (Hazir(IsBas)) { isemriTAVBIT.IntZaman = 0; }
					else { isemriTAVBIT.IntZaman = Math.Round(zamfark); }
					
					//	Console.WriteLine(isemriTAVBIT.IntZaman);

					isemriTAVBIT.Zaman = IsBas ;
					var koloneslesme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurn.BaseNumber);
					
					isemriTAVBIT.Konum1Kolon = koloneslesme.Kolonno + "";
					isemriTAVBIT.Konum1Kaide = ProTurn.BaseNumber.ToString();
					isemriTAVBIT.Konum2Kolon = koloneslesme.Kolonno + "";
					isemriTAVBIT.Konum2Kaide = ProTurn.BaseNumber.ToString();
				//	if (ProsesbitimListesiO.Count > 0)
				//	{
				//		Prosesbitim ProTurnO = ProsesbitimListesiO[0];
				//		var koloneslesmeO = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurnO.BaseNumber);
				//		isemriTAVBIT.Konum2Kolon = koloneslesmeO.Kolonno + "";
				//		isemriTAVBIT.Konum2Kaide = ProTurnO.BaseNumber.ToString();
				//	}
				//	else
				//	{
				//		isemriTAVBIT.Konum2Kolon = koloneslesme.Kolonno + "";
				//		isemriTAVBIT.Konum2Kaide = ProTurn.BaseNumber.ToString();
				//
				//	}
					
              //  if(ProTurn.PlugNumber!= 0) { 
					if (Convert.ToInt32(ProTurn.BaseNumber.ToString()) <= 34)
					{
						isemriTAVBIT.AtmosphereTuru = "HNX";
						isemriTAVBIT.AtacmanTipi = "YOK";
						isemriTAVBIT.Issuresi = 2.0;
						//süretaşimaFIR = Convert.ToDouble(SureTable.Rows[17]["Süre"]);
						//isemriTAVBIT.IntZaman = zamfark + süretaşimaFIR;
					}
					else
					{
						isemriTAVBIT.AtmosphereTuru = "H2";
						isemriTAVBIT.AtacmanTipi = "YOK";
						isemriTAVBIT.Issuresi = 2.0;
						//süretaşimaFIR = Convert.ToDouble(SureTable.Rows[5]["Süre"]);
						//IsemriNewRowTAV["IntZaman"] = zamfark + süretaşimaFIR;
					}

					isemriTAVBIT.Yapilacakis = ProTurn.PlugNumber + " Nolu Fırın çıkart";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
					isemriTAVBIT.isTipi = WorkType.firin_cikart;
					isemriTAVBIT.isDetayi = WorkTypeDetail.kaide_bosalt;
					isemriTAVBIT.equipmentNumber = ProTurn.PlugNumber.ToString();
					isemriTAVBIT.Yapilacakisturu = "TAV bitişi";
					id_strTAV = idStringHazirla(4, islem_sirasiTAV, 1, emir_sirasiTAV,isemriTAVBIT.Issuresi, isemriTAVBIT.AtmosphereTuru);
					isemriTAVBIT.UniqueID = id_strTAV;
					/*if(isemriTAVBIT.AtmosphereTuru == "H2")
					{
						isemriTAVBIT.skor = 3*skorhesapla(isemriTAVBIT.UniqueID);
					}
					else
					{
						isemriTAVBIT.skor = 2 * skorhesapla(isemriTAVBIT.UniqueID);
					}*/
					//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim
					isemriTAVBIT.skor = skorhesapla(isemriTAVBIT.UniqueID);


					emir_sirasiTAV = emir_sirasiTAV + 1;
					list.Add(isemriTAVBIT);
					//	}

				//	List<Sogutmacan> UygunSOCAHNX = GetUygunSoCa(isFull,"HNX");
				//	List<Sogutmacan> UygunSOCAH2 = GetUygunSoCa(isFull, "H2");

					double Finalfark = 100000;
					int MinRow = 0;

					if (ProTurn.BaseNumber <= 34)
					{
						//int Alternatif = 1;
						//for (int k = 0; k < UygunSOCAHNX.DefaultView.Count; k++)
						//{
						if (UygunSOCAHNX.Count > 0)
						{
							IsemriL isemriSoCaHNX = new IsemriL();
							for (int t = 0; t < UygunSOCAHNX.Count; t++)
							{
							//	var SSkoloneslesmeSOCA = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunSOCAHNX[t].BaseNumber);
							//	int farkC = Math.Abs(koloneslesme.Kolonno - SSkoloneslesmeSOCA.Kolonno);
								double FARKC = Math.Abs(ISXLOKASYON - UygunSOCAHNX[t].Xkor);
								if (FARKC < Finalfark)
								{
									Finalfark = FARKC;
									MinRow = t;

								}
							}
							
							//	TimeSpan ZamanFark = IsBas - DateTime.Now;
							//	zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
							if (Hazir(IsBas)) { isemriSoCaHNX.IntZaman = 0; }
							else { isemriSoCaHNX.IntZaman = Math.Round((zamfark + isemriTAVBIT.Issuresi), 1); };
							


							isemriSoCaHNX.Zaman = IsBas.AddMinutes(2.5);
							isemriSoCaHNX.Konum1Kaide = UygunSOCAHNX[MinRow].BaseNumber.ToString();
							var koloneslesmeSOCA = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunSOCAHNX[MinRow].BaseNumber);
							isemriSoCaHNX.Konum1Kolon = koloneslesmeSOCA.Kolonno + "";
							isemriSoCaHNX.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriSoCaHNX.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriSoCaHNX.AtmosphereTuru = "HNX";
							isemriSoCaHNX.AtacmanTipi = "Konvektor Tasima Aparatı";
							isemriSoCaHNX.Issuresi = 2.0;

							isemriSoCaHNX.Yapilacakis = UygunSOCAHNX[MinRow].No + " Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriSoCaHNX.isTipi = WorkType.scan_tak;
							isemriSoCaHNX.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriSoCaHNX.equipmentNumber = UygunSOCAHNX[MinRow].No.ToString();
							UygunSOCAHNX.RemoveAt(MinRow);
					        //UygunSOCAHNX.Add(UygunSOCAHNX[MinRow]);                                                                              //			UygunSOCAHNX.RemoveAt(MinRow);																			   //			UygunSOCAHNX.RemoveAt(MinRow);
							isemriSoCaHNX.Yapilacakisturu = "TAV bitişi";
							id_strTAV = idStringHazirla(5, islem_sirasiTAV, 1, emir_sirasiTAV, isemriSoCaHNX.Issuresi, isemriSoCaHNX.AtmosphereTuru);
							emir_sirasiTAV = emir_sirasiTAV + 1;
							islem_sirasiTAV = islem_sirasiTAV + 1;
							isemriSoCaHNX.UniqueID = id_strTAV;

							//isemriSoCaHNX.skor = 2*skorhesapla(isemriSoCaHNX.UniqueID);
							//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim
							isemriSoCaHNX.skor = skorhesapla(isemriSoCaHNX.UniqueID);

							list.Add(isemriSoCaHNX);
							//Alternatif = Alternatif + 1;
						}
						else { Console.WriteLine("Boş HNX soğutma çanı yok"); }

						//}
					}
					else
					{
						if (UygunSOCAH2.Count > 0) { 
							for (int t = 0; t < UygunSOCAH2.Count; t++)
					        {
								double FARKC = Math.Abs(ISXLOKASYON - UygunSOCAH2[t].Xkor);
								if (FARKC < Finalfark)
								{
									Finalfark = FARKC;
									MinRow = t;

								}
							}
						   IsemriL isemriSoCaH2 = new IsemriL();

							//TimeSpan ZamanFark = IsBas - DateTime.Now;
							//zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
						if (Hazir(IsBas)) { isemriSoCaH2.IntZaman = 0; }
						else { isemriSoCaH2.IntZaman = Math.Round((zamfark + isemriTAVBIT.Issuresi), 1); };
						isemriSoCaH2.Zaman = IsBas.AddMinutes(2.5);
						isemriSoCaH2.Konum1Kaide = UygunSOCAH2[MinRow].BaseNumber.ToString();
						var koloneslesmeSOCAH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunSOCAH2[MinRow].BaseNumber);
						isemriSoCaH2.Konum1Kolon = koloneslesmeSOCAH2.Kolonno + "";
						isemriSoCaH2.Konum2Kaide = ProTurn.BaseNumber.ToString();
						isemriSoCaH2.Konum2Kolon = koloneslesme.Kolonno + "";
						isemriSoCaH2.AtmosphereTuru = "H2";
						isemriSoCaH2.AtacmanTipi = "Konvektor Tasima Aparatı";
						isemriSoCaH2.Issuresi = 2.0;

						isemriSoCaH2.Yapilacakis = UygunSOCAH2[MinRow].No + "Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
						isemriSoCaH2.isTipi = WorkType.scan_tak;
						isemriSoCaH2.equipmentNumber = UygunSOCAH2[MinRow].No.ToString();
						isemriSoCaH2.isDetayi = WorkTypeDetail.kaide_yukle;

						UygunSOCAH2.RemoveAt(MinRow);
					//	UygunSOCAH2.Add(UygunSOCAH2[MinRow]);
						isemriSoCaH2.Yapilacakisturu = "TAV bitişi";
						id_strTAV = idStringHazirla(5, islem_sirasiTAV, 1, emir_sirasiTAV, isemriSoCaH2.Issuresi, isemriSoCaH2.AtmosphereTuru);
						//islem_sirasiTAV = islem_sirasiTAV + 1;
						emir_sirasiTAV = emir_sirasiTAV + 1;
						isemriSoCaH2.UniqueID = id_strTAV;
						//isemriSoCaH2.skor = 3*skorhesapla(isemriSoCaH2.UniqueID);
						//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim
						isemriSoCaH2.skor = skorhesapla(isemriSoCaH2.UniqueID);
						list.Add(isemriSoCaH2);

						}
						else { Console.WriteLine("Boş H2 soğutma çanı yok"); }


					}



				}
                else if (ProTurn.State == 30) 
				{
					double Finalfark = 10000;
					int MinRow = 0;
					var koloneslesme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurn.BaseNumber);
					if (ProTurn.BaseNumber <= 34)
					{
						//int Alternatif = 1;
						//for (int k = 0; k < UygunSOCAHNX.DefaultView.Count; k++)
						//{
						if (UygunSOCAHNX.Count > 0)
						{
							IsemriL isemriSoCaHNX = new IsemriL();
							for (int t = 0; t < UygunSOCAHNX.Count; t++)
							{
								double FARKC = Math.Abs(ISXLOKASYON - UygunSOCAHNX[t].Xkor);
								if (FARKC < Finalfark)
								{
									Finalfark = FARKC;
									MinRow = t;

								}
							}
							double zamfark = 0;
							TimeSpan ZamanFark = IsBas - DateTime.Now;
							zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
							if (Hazir(IsBas)) { isemriSoCaHNX.IntZaman = 0; }
							else { isemriSoCaHNX.IntZaman = Math.Round(zamfark , 1); }



							isemriSoCaHNX.Zaman = IsBas;
							isemriSoCaHNX.Konum1Kaide = UygunSOCAHNX[MinRow].BaseNumber.ToString();
							var koloneslesmeSOCA = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunSOCAHNX[MinRow].BaseNumber);
							isemriSoCaHNX.Konum1Kolon = koloneslesmeSOCA.Kolonno + "";
							isemriSoCaHNX.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriSoCaHNX.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriSoCaHNX.AtmosphereTuru = "HNX";
							isemriSoCaHNX.AtacmanTipi = "Konvektor Tasima Aparatı";
							isemriSoCaHNX.Issuresi = 2.0;

							isemriSoCaHNX.Yapilacakis = UygunSOCAHNX[MinRow].No + " Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriSoCaHNX.isTipi = WorkType.scan_tak;
							isemriSoCaHNX.equipmentNumber = UygunSOCAHNX[MinRow].No.ToString();
							isemriSoCaHNX.isDetayi = WorkTypeDetail.kaide_yukle;
							UygunSOCAHNX.RemoveAt(MinRow);
							//UygunSOCAHNX.Add(UygunSOCAHNX[MinRow]);                                                                              //			UygunSOCAHNX.RemoveAt(MinRow);																			   //			UygunSOCAHNX.RemoveAt(MinRow);
							isemriSoCaHNX.Yapilacakisturu = "TAV bitişi";
							id_strTAV = idStringHazirla(3, islem_sirasiTAV, 1, emir_sirasiTAV, isemriSoCaHNX.Issuresi, isemriSoCaHNX.AtmosphereTuru);
							emir_sirasiTAV = emir_sirasiTAV + 1;
							islem_sirasiTAV = islem_sirasiTAV + 1;
							isemriSoCaHNX.UniqueID = id_strTAV;

							//isemriSoCaHNX.skor = 2 * skorhesapla(isemriSoCaHNX.UniqueID);
							//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim

							isemriSoCaHNX.skor = skorhesapla(isemriSoCaHNX.UniqueID);

							list.Add(isemriSoCaHNX);
							//Alternatif = Alternatif + 1;
						}
						else { Console.WriteLine("Boş HNX soğutma çanı yok"); }

						//}
					}
					else
					{
						if (UygunSOCAH2.Count > 0)
						{
							for (int t = 0; t < UygunSOCAH2.Count; t++)
							{
								double FARKC = Math.Abs(ISXLOKASYON - UygunSOCAH2[t].Xkor);
								if (FARKC < Finalfark)
								{
									Finalfark = FARKC;
									MinRow = t;

								}
							}
							IsemriL isemriSoCaH2 = new IsemriL();
							double zamfark = 0;
							TimeSpan ZamanFark = IsBas - DateTime.Now;
							zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
							if (Hazir(IsBas)) { isemriSoCaH2.IntZaman = 0; }
							else { isemriSoCaH2.IntZaman = Math.Round(zamfark , 1); };
							isemriSoCaH2.Zaman = IsBas;
							isemriSoCaH2.Konum1Kaide = UygunSOCAH2[MinRow].BaseNumber.ToString();
							var koloneslesmeSOCAH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunSOCAH2[MinRow].BaseNumber);
							isemriSoCaH2.Konum1Kolon = koloneslesmeSOCAH2.Kolonno + "";
							isemriSoCaH2.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriSoCaH2.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriSoCaH2.AtmosphereTuru = "H2";
							isemriSoCaH2.AtacmanTipi = "Konvektor Tasima Aparatı";
							isemriSoCaH2.Issuresi = 2.0;

							isemriSoCaH2.Yapilacakis = UygunSOCAH2[MinRow].No + "Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriSoCaH2.isTipi = WorkType.scan_tak;
							isemriSoCaH2.equipmentNumber = UygunSOCAH2[MinRow].No.ToString();
							isemriSoCaH2.isDetayi = WorkTypeDetail.kaide_yukle;
							UygunSOCAH2.RemoveAt(MinRow);
							//	UygunSOCAH2.Add(UygunSOCAH2[MinRow]);
							isemriSoCaH2.Yapilacakisturu = "TAV bitişi";
							id_strTAV = idStringHazirla(5, islem_sirasiTAV, 1, emir_sirasiTAV, isemriSoCaH2.Issuresi, isemriSoCaH2.AtmosphereTuru);
							//islem_sirasiTAV = islem_sirasiTAV + 1;
							emir_sirasiTAV = emir_sirasiTAV + 1;
							isemriSoCaH2.UniqueID = id_strTAV;
							//isemriSoCaH2.skor = 3 * skorhesapla(isemriSoCaH2.UniqueID);
							//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim

							isemriSoCaH2.skor = skorhesapla(isemriSoCaH2.UniqueID);
							list.Add(isemriSoCaH2);

						}
						else { Console.WriteLine("Boş H2 soğutma çanı yok"); }


					}
				}
				else if (ProTurn.State == 100 || ProTurn.State == 101 || ProTurn.State == 102)
				{
					//Uygun fırını bul tak
					//	List<Firin> UygunFurH2 = GetUygunFirin(isFull,"H2");
					//	List<Firin> UygunFurHNX = GetUygunFirin(isFull,"HNX");
					
					Console.WriteLine("H2 firin :" + UygunFurH2.Count + "HNX firin :" + UygunFurHNX.Count);
					int zamfark = 0;
					if(ProTurn.PlugNumber == 0) 
					{
						var koloneslesme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurn.BaseNumber);
						if (ProTurn.BaseNumber <= 34)
				    	{
				    		if (UygunFurHNX.Count != 0) 
						     { 
					        	double Finalfark = 100000;
					        	int MinRow = 0;
					        	
					        	IsemriL isemriFirinHNX = new IsemriL();
					        	for (int t = 0; t < UygunFurHNX.Count; t++)
					        	{
									double FARKC = Math.Abs(ISXLOKASYON - UygunFurHNX[t].Xkor);
									if (FARKC < Finalfark)
									{
										Finalfark = FARKC;
										MinRow = t;

									}
								//	var koloneslesmeFur = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurHNX[t].BaseNumber);
					        	//	int farkC = Math.Abs(koloneslesme.Kolonno - koloneslesmeFur.Kolonno);
					        	//	if (farkC < Finalfark)
					        	//	{
					        	//		Finalfark = farkC;
					        	//		MinRow = t;
					        	//
					        	//	}
					        	}
					        	
					        	if (Hazir(IsBas))
					        	{
					        		isemriFirinHNX.IntZaman = 0;
					        	}
					        	else
					        	{
					        		TimeSpan ZamanFark = IsBas - DateTime.Now;
					        		zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
					        		isemriFirinHNX.IntZaman = zamfark;
					        	}
					        
					        
					        	isemriFirinHNX.Zaman = IsBas;
					        	isemriFirinHNX.Konum1Kaide = UygunFurHNX[MinRow].BaseNumber.ToString();
					        	var koloneslesmeFurHNX = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurHNX[MinRow].BaseNumber);
					        	isemriFirinHNX.Konum1Kolon = koloneslesmeFurHNX.Kolonno + "";
					        	isemriFirinHNX.Konum2Kaide = ProTurn.BaseNumber.ToString();
					        	isemriFirinHNX.Konum2Kolon = koloneslesme.Kolonno + "";
					        	isemriFirinHNX.AtmosphereTuru = "HNX";
					        	isemriFirinHNX.AtacmanTipi = "YOK";
					        	isemriFirinHNX.Issuresi = 2.0;
					        
					        	isemriFirinHNX.Yapilacakis = UygunFurHNX[MinRow].No+ " Fırın tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
					        	isemriFirinHNX.isTipi = WorkType.firin_tak;
					        	isemriFirinHNX.isDetayi = WorkTypeDetail.kaide_yukle;
					        	isemriFirinHNX.equipmentNumber = UygunFurHNX[MinRow].No.ToString();
					        	UygunFurHNX.RemoveAt(MinRow);
					        	isemriFirinHNX.Yapilacakisturu = "Tav baslama";
					        	id_strTAV = idStringHazirla(2, islem_sirasiTAV, 1, emir_sirasiTAV, isemriFirinHNX.Issuresi, isemriFirinHNX.AtmosphereTuru);
					        	isemriFirinHNX.UniqueID = id_strTAV;
					        			/*if (isemriFirinHNX.AtmosphereTuru == "H2")
					        			{
					        				isemriFirinHNX.skor = 3 * skorhesapla(isemriFirinHNX.UniqueID);
					        			}
					        			else
					        			{
					        				isemriFirinHNX.skor = 2 * skorhesapla(isemriFirinHNX.UniqueID);
					        			}*/
					        			//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim
					        			isemriFirinHNX.skor = skorhesapla(isemriFirinHNX.UniqueID);
					        
					        			list.Add(isemriFirinHNX);
					        
					        	}
				            
				            
				        }
				    	else if((76>=ProTurn.BaseNumber) && (ProTurn.BaseNumber >= 61)) 
				    	{
						   if (UygunFurH2Faz1.Count != 0)
						   {
							double Finalfark = 10000;
							int MinRow = 0;
							
							IsemriL isemriFirinH2Faz1 = new IsemriL();
							for (int t = 0; t < UygunFurH2Faz1.Count; t++)
							{
									double FARKC = Math.Abs(ISXLOKASYON - UygunFurH2Faz1[t].Xkor);
									if (FARKC < Finalfark)
									{
										Finalfark = FARKC;
										MinRow = t;

									}
							//		var koloneslesmeFur = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurH2Faz1[t].BaseNumber);
							//	int farkC = Math.Abs(koloneslesme.Kolonno - koloneslesmeFur.Kolonno);
							//	if (farkC < Finalfark)
							//	{
							//		Finalfark = farkC;
							//		MinRow = t;
							//
							//	}
							}
							
							if (Hazir(IsBas))
							{
								isemriFirinH2Faz1.IntZaman = 0;
							}
							else
							{
								TimeSpan ZamanFark = IsBas - DateTime.Now;
								zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
								isemriFirinH2Faz1.IntZaman = zamfark;
							}


							isemriFirinH2Faz1.Zaman = IsBas;
							isemriFirinH2Faz1.Konum1Kaide = UygunFurH2Faz1[MinRow].BaseNumber.ToString();
							var koloneslesmeFurH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurH2Faz1[MinRow].BaseNumber);
							isemriFirinH2Faz1.Konum1Kolon = koloneslesmeFurH2.Kolonno + "";
							isemriFirinH2Faz1.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriFirinH2Faz1.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriFirinH2Faz1.AtmosphereTuru = "H2";
							isemriFirinH2Faz1.AtacmanTipi = "YOK";
							isemriFirinH2Faz1.Issuresi = 2.0;

							isemriFirinH2Faz1.Yapilacakis = UygunFurH2Faz1[MinRow].No + " Fırın tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriFirinH2Faz1.isTipi = WorkType.firin_tak;
							isemriFirinH2Faz1.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriFirinH2Faz1.equipmentNumber = UygunFurH2Faz1[MinRow].No.ToString();
							UygunFurH2Faz1.RemoveAt(MinRow);
							isemriFirinH2Faz1.Yapilacakisturu = "Tav baslama";
							id_strTAV = idStringHazirla(3, islem_sirasiTAV, 1, emir_sirasiTAV, isemriFirinH2Faz1.Issuresi, isemriFirinH2Faz1.AtmosphereTuru);
							isemriFirinH2Faz1.UniqueID = id_strTAV;
							/*if (isemriFirinH2Faz1.AtmosphereTuru == "H2")
							{
								isemriFirinH2Faz1.skor = 3 * skorhesapla(isemriFirinH2Faz1.UniqueID);
							}
							else
							{
								isemriFirinH2Faz1.skor = 2 * skorhesapla(isemriFirinH2Faz1.UniqueID);
							}*/
								//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim
								isemriFirinH2Faz1.skor = skorhesapla(isemriFirinH2Faz1.UniqueID);

								list.Add(isemriFirinH2Faz1);

						}

						   islem_sirasiTAV = islem_sirasiTAV + 1;
					    }
				    	else 
				    	{
						if (UygunFurH2Faz2.Count != 0) 
						{ 
						double Finalfark = 10000;
						int MinRow = 0;
						IsemriL isemriFirinH2Faz2 = new IsemriL();
						for (int t = 0; t < UygunFurH2Faz2.Count; t++)
						{
									double FARKC = Math.Abs(ISXLOKASYON - UygunFurH2Faz2[t].Xkor);
									if (FARKC < Finalfark)
									{
										Finalfark = FARKC;
										MinRow = t;

									}
						//			var koloneslesmeFur = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurH2Faz2[t].BaseNumber);
						//	int farkC = Math.Abs(koloneslesme.Kolonno - koloneslesmeFur.Kolonno);
						//	if (farkC < Finalfark)
						//	{
						//		Finalfark = farkC;
						//		MinRow = t;
						//
						//	}
						}
						
						if (Hazir(IsBas))
						{
								isemriFirinH2Faz2.IntZaman = 0;
						}
						else
						{
							TimeSpan ZamanFark = IsBas - DateTime.Now;
							zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
								isemriFirinH2Faz2.IntZaman = zamfark;
						}

								
							isemriFirinH2Faz2.Zaman = IsBas;
							isemriFirinH2Faz2.Konum1Kaide = UygunFurH2Faz2[MinRow].BaseNumber.ToString();
						var koloneslesmeFurH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurH2Faz2[MinRow].BaseNumber);
							isemriFirinH2Faz2.Konum1Kolon = koloneslesmeFurH2.Kolonno + "";
							isemriFirinH2Faz2.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriFirinH2Faz2.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriFirinH2Faz2.AtmosphereTuru = "H2";
							isemriFirinH2Faz2.AtacmanTipi = "YOK";
							isemriFirinH2Faz2.Issuresi = 2.0;

							isemriFirinH2Faz2.Yapilacakis = UygunFurH2Faz2[MinRow].No+" Fırın tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriFirinH2Faz2.isTipi = WorkType.firin_tak;
							isemriFirinH2Faz2.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriFirinH2Faz2.equipmentNumber = UygunFurH2Faz2[MinRow].No.ToString();
							UygunFurH2Faz2.RemoveAt(MinRow);
							isemriFirinH2Faz2.Yapilacakisturu = "Tav baslama";
						id_strTAV = idStringHazirla(3, islem_sirasiTAV, 1, emir_sirasiTAV, isemriFirinH2Faz2.Issuresi, isemriFirinH2Faz2.AtmosphereTuru);
							isemriFirinH2Faz2.UniqueID = id_strTAV;
								/*if (isemriFirinH2Faz2.AtmosphereTuru == "H2")
								{
										isemriFirinH2Faz2.skor = 3 * skorhesapla(isemriFirinH2Faz2.UniqueID);
								}
								else
								{
										isemriFirinH2Faz2.skor = 2 * skorhesapla(isemriFirinH2Faz2.UniqueID);
								}*/
								//buradaki taleplerin tamami skor hesapla metodunun sorumlulugunda olmali ki degisiklik gerekirse kolayca adapte olalim
								isemriFirinH2Faz2.skor = skorhesapla(isemriFirinH2Faz2.UniqueID);


								list.Add(isemriFirinH2Faz2);

						}
						islem_sirasiTAV = islem_sirasiTAV + 1;

					}
					}
				}
                
			}
			//ProsesbitimListesi = list;

			//return list;

		}

        private bool Hazir(DateTime isBas)
        {
			return isBas.Year<2000;
		}

        public List<IsemriL> IsEmriYarat()//string hat, int bobinSayisi
		{ 			
			List<Kaide> h2Uygun = GetUygunKaideler("H2");
			List<Kaide> hnxUygun = GetUygunKaideler("HNX");
			List<Gomlek> h2UygunGom = GetUygunGomlek("H2");
			List<Gomlek> hnxUygunGom = GetUygunGomlek("HNX");
			List<Firin> UygunFurH2 = GetUygunFirin("H2");
			List<Firin> UygunFurH2Faz1 = UygunFurH2.Where(o => o.Phase == 1).ToList();
			List<Firin> UygunFurH2Faz2 = UygunFurH2.Where(o => o.Phase == 2).ToList();
			List<Firin> UygunFurHNX = GetUygunFirin("HNX");
			
			string id_yukleHNX;
			string id_yukleH2;
			foreach (var itemkaide in h2Uygun)
			{
				Console.WriteLine("Boş H2  :" + itemkaide.No);
			}
			foreach (var itemkaide in hnxUygun)
			{
				Console.WriteLine("Boş Hnx  :" + itemkaide.No);
			}

		//	List<Kaidebobin> H2ResultRCMNEW = KaideBobinListesi.Where(o => o.A510_B == "RCM BOBIN DEVIRICI").ToList();
		//	List<Kaidebobin> H2ResultECLNEW = KaideBobinListesi.Where(o => o.A510_B == "ECL BOBIN DEVIRICI").ToList();
		//	List <Kaidebobin> H2ResultRCM = KaideBobinListesi.Where(o => o.ProgramNumber >= 180 && o.ProgramNumber <= 190 && o.A510_B == "RCM BOBIN DEVIRICI").ToList();
		//	List<Kaidebobin> H2ResultECL = KaideBobinListesi.Where(o => o.ProgramNumber >= 161 && o.ProgramNumber <= 170 && o.A510_B == "ECL BOBIN DEVIRICI").ToList();
		//	List<Kaidebobin> HnxResultRCM = KaideBobinListesi.Where(o => o.ProgramNumber >= 101 && o.ProgramNumber<=110 && o.A510_B == "RCM BOBIN DEVIRICI").ToList();
		//	List<Kaidebobin> HnxResultECL = KaideBobinListesi.Where(o => o.ProgramNumber >= 120 && o.ProgramNumber <= 130 && o.A510_B == "ECL BOBIN DEVIRICI").ToList();
			List<Kaidebobin> H2ResultRCM = KaideBobinListesi.Where(o => o.ProgramNumber >= 180 && o.ProgramNumber <= 190 ).ToList();
			List<Kaidebobin> H2ResultECL = KaideBobinListesi.Where(o => o.ProgramNumber >= 161 && o.ProgramNumber <= 170 ).ToList();
			List<Kaidebobin> HnxResultRCM = KaideBobinListesi.Where(o => o.ProgramNumber >= 101 && o.ProgramNumber <= 110 ).ToList();
			List<Kaidebobin> HnxResultECL = KaideBobinListesi.Where(o => o.ProgramNumber >= 120 && o.ProgramNumber <= 130 ).ToList();

			var HNXGroupsRCM = HnxResultRCM.GroupBy(h => h.ProgramNumber).Select(s => new { ProgramNumber = s.Key, List = s.ToList() });
			var HNXGroupsECL = HnxResultECL.GroupBy(h => h.ProgramNumber).Select(s => new { ProgramNumber = s.Key, List = s.ToList() });
			int AAA = HNXGroupsRCM.Count();
			int islem_sirasiLOAD = 1;
			
			
			if (hnxUygun.Count > 0)
			{
				
				foreach (var item in HNXGroupsRCM)
				{
					
					if (hnxUygun.Count > 0)
					{
						Console.WriteLine("HNX GRUBU IN RCM TRANSPALAN(PROGRAM NO: " + item.ProgramNumber + ")");
						int FinalFark = 100;
						int MinRow = 0;
						
						for (int t = 0; t < hnxUygun.Count; t++)
						{
							var koloneslemeLoadHNX = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == hnxUygun[t].No);
							int FarkC = Math.Abs(koloneslemeLoadHNX.Kolonno - 4);
							if (FarkC < FinalFark)
							{
								FinalFark = FarkC;
								MinRow = t;
							}

						}
						var YukleEsleme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == hnxUygun[MinRow].No);
						int ISYUKLOKASYON = Convert.ToInt32(KaideListesi.Find(e => e.No == hnxUygun[MinRow].No).Xkor);
						int ssss = item.List.Count();
						
						int emir_sirasiLOAD = 1;
						foreach (Kaidebobin kb in item.List)
						{
							IsemriL isemriYukleHNX = new IsemriL();
							Console.WriteLine("Batch: " + kb.BatchNumber + " BOrder: " + kb.BatchOrder + " Yeri: " + kb.A510_B + " Status: " + kb.Status);

							isemriYukleHNX.Zaman = DateTime.Now;
							isemriYukleHNX.IntZaman = 0.0;
							isemriYukleHNX.AtmosphereTuru = "HNX";
							isemriYukleHNX.AtacmanTipi = "Bobin Aparati";
							isemriYukleHNX.Issuresi = 4.0;
							isemriYukleHNX.Konum1Kaide = "BAF_RCM_TRN";//kb.A510_B
							isemriYukleHNX.Konum1Kolon = "4";
							isemriYukleHNX.Konum2Kaide = Convert.ToString(hnxUygun[MinRow].No);
							isemriYukleHNX.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleHNX.Yapilacakis = kb.BatchNumber + "-- No  Bobin Tasi";
							isemriYukleHNX.isTipi = WorkType.bobin_tasima;
							isemriYukleHNX.equipmentNumber = kb.BatchNumber;
							isemriYukleHNX.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleHNX.Yapilacakisturu = "Kaide yukle";
							id_yukleHNX = idStringHazirla(1, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleHNX.Issuresi, isemriYukleHNX.AtmosphereTuru);
							isemriYukleHNX.UniqueID = id_yukleHNX;
							isemriYukleHNX.skor = skorhesapla(isemriYukleHNX.UniqueID);
							//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleHNX);
							emir_sirasiLOAD = emir_sirasiLOAD + 1;
						}
						

						IsemriL isemriYukleHNXGom = new IsemriL();
						//hnxUygunGom[t].BaseNumber;
						//isemriYukleHNX e gömlek ekle
						//YuklemeIsListe.Add(isemriYukleHNXGom);
						if (hnxUygunGom.Count > 0) { 
					    	double FinalFarkGom = 10000;
					    	int MinRowGom = 0;
					    	for(int t=0;t<hnxUygunGom.Count;t++)
						{
							double FARKC = Math.Abs(ISYUKLOKASYON - hnxUygunGom[t].Xkor);
							if (FARKC < FinalFarkGom)
							{
								FinalFarkGom = FARKC;
								MinRowGom = t;

							}
						//	var LoadHNXGom = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == hnxUygunGom[t].BaseNumber);
						//	int FarkG = Math.Abs(LoadHNXGom.Kolonno - YukleEsleme.Kolonno);
						//	if(FarkG<FinalFarkGom)
						//	{
						//		FinalFarkGom = FarkG;
						//		MinRowGom = t;
						//	}
						}
					    	var YukleGom = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == hnxUygunGom[MinRowGom].BaseNumber);
					    	isemriYukleHNXGom.Zaman = DateTime.Now;
					    	isemriYukleHNXGom.IntZaman = 0.0;
					    	isemriYukleHNXGom.AtmosphereTuru = "HNX";
					    	isemriYukleHNXGom.AtacmanTipi = "Konvektor Aparatı";
					    	isemriYukleHNXGom.Issuresi = 2.5;
					    	isemriYukleHNXGom.Konum1Kaide = hnxUygunGom[MinRowGom].BaseNumber.ToString();
					    	isemriYukleHNXGom.Konum1Kolon = YukleGom.Kolonno + "";
					    	isemriYukleHNXGom.Konum2Kaide = Convert.ToString(hnxUygun[MinRow].No);
					    	isemriYukleHNXGom.Konum2Kolon = YukleEsleme.Kolonno + "";
					    	isemriYukleHNXGom.Yapilacakis = hnxUygunGom[MinRowGom].No + "-- Nolu  Gomlek Tak";
					    	isemriYukleHNXGom.isTipi = WorkType.gomlek_tak;
					    	isemriYukleHNXGom.isDetayi = WorkTypeDetail.kaide_yukle;
					    	isemriYukleHNXGom.equipmentNumber = hnxUygunGom[MinRowGom].No.ToString();
					    	hnxUygunGom.RemoveAt(MinRowGom);
					    	isemriYukleHNXGom.Yapilacakisturu = "Gomlek yukle";
					    	id_yukleHNX = idStringHazirla(2, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleHNXGom.Issuresi, isemriYukleHNXGom.AtmosphereTuru);
					    	isemriYukleHNXGom.UniqueID = id_yukleHNX;
					    	isemriYukleHNXGom.skor = skorhesapla(isemriYukleHNXGom.UniqueID);
					    	//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
					    	YuklemeIsListe.Add(isemriYukleHNXGom);
					    	emir_sirasiLOAD = emir_sirasiLOAD + 1;
						}
						IsemriL isemriYukleHNXFirin = new IsemriL();
						//hnxUygunGom[t].BaseNumber;
						//isemriYukleHNX e gömlek ekle
						//YuklemeIsListe.Add(isemriYukleHNXGom);
						if (hnxUygunGom.Count > 0 && UygunFurHNX.Count > 0) 
						{
							double FinalFarkFur = 10000;
							int MinRowGomFur = 0;
							for (int t = 0; t < UygunFurHNX.Count; t++)
							{
								double FARKC = Math.Abs(ISYUKLOKASYON - UygunFurHNX[t].Xkor);
								if (FARKC < FinalFarkFur)
								{
									FinalFarkFur = FARKC;
									MinRowGomFur = t;

								}
							//	var LoadHNXFur = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurHNX[t].BaseNumber);
							//	int FarkG = Math.Abs(LoadHNXFur.Kolonno - YukleEsleme.Kolonno);
							//	if (FarkG < FinalFarkFur)
							//	{
							//		FinalFarkFur = FarkG;
							//		MinRowGomFur = t;
							//	}
							}
							var YukleFurHNX = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurHNX[MinRowGomFur].BaseNumber);
							isemriYukleHNXFirin.Zaman = DateTime.Now;
							isemriYukleHNXFirin.IntZaman = 0.0;
							isemriYukleHNXFirin.AtmosphereTuru = "HNX";
							isemriYukleHNXFirin.AtacmanTipi = "Konvektor Aparatı";
							isemriYukleHNXFirin.Issuresi = 2.5;
							isemriYukleHNXFirin.Konum1Kaide = UygunFurHNX[MinRowGomFur].BaseNumber.ToString();
							isemriYukleHNXFirin.Konum1Kolon = YukleFurHNX.Kolonno + "";
							isemriYukleHNXFirin.Konum2Kaide = Convert.ToString(hnxUygun[MinRow].No);
							isemriYukleHNXFirin.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleHNXFirin.Yapilacakis = UygunFurHNX[MinRowGomFur].No + "-- Nolu  Firin Tak";
							isemriYukleHNXFirin.isTipi = WorkType.firin_tak;
							isemriYukleHNXFirin.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleHNXFirin.equipmentNumber = UygunFurHNX[MinRowGomFur].No.ToString();
							UygunFurHNX.RemoveAt(MinRowGomFur);
							isemriYukleHNXFirin.Yapilacakisturu = "Fırın yukle";
							id_yukleHNX = idStringHazirla(3, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleHNXFirin.Issuresi, isemriYukleHNXFirin.AtmosphereTuru);
							isemriYukleHNXFirin.UniqueID = id_yukleHNX;
							isemriYukleHNXFirin.skor = skorhesapla(isemriYukleHNXFirin.UniqueID);
							//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleHNXFirin);
						}
						


						hnxUygun.RemoveAt(MinRow);

					}
					
					islem_sirasiLOAD = islem_sirasiLOAD + 1;
				}
				
				foreach (var item in HNXGroupsECL)
				{
					//int islem_sirasiLOAD = 1;
					if (hnxUygun.Count > 0)
					{
						Console.WriteLine("HNX GRUBU IN ECL TRANSPALAN(PROGRAM NO: " + item.ProgramNumber + ")");
						int FinalFark = 100;
						int MinRow = 0;
						for (int t = 0; t < hnxUygun.Count; t++)
						{
							var koloneslemeLoadHNX = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == hnxUygun[t].No);
							int FarkC = Math.Abs(koloneslemeLoadHNX.Kolonno - 16);
							if (FarkC < FinalFark)
							{
								FinalFark = FarkC;
								MinRow = t;
							}

						}
						var YukleEsleme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == hnxUygun[MinRow].No);
						int ISYUKLOKASYON = Convert.ToInt32(KaideListesi.Find(e => e.No == hnxUygun[MinRow].No).Xkor);
						int emir_sirasiLOAD = 1;
						foreach (Kaidebobin kb in item.List)
						{

							IsemriL isemriYukleHNX = new IsemriL();
							Console.WriteLine("Batch: " + kb.BatchNumber + " BOrder: " + kb.BatchOrder + " Yeri: " + kb.A510_B + " Status: " + kb.Status);

							isemriYukleHNX.Zaman = DateTime.Now;
							isemriYukleHNX.IntZaman = 0.0;
							isemriYukleHNX.AtmosphereTuru = "HNX";
							isemriYukleHNX.AtacmanTipi = "Bobin Aparati";
							isemriYukleHNX.Issuresi = 4.0;
							isemriYukleHNX.Konum1Kaide = "BAF_ECL_TRN";
							isemriYukleHNX.Konum1Kolon = "16";
							isemriYukleHNX.Konum2Kaide = Convert.ToString(hnxUygun[MinRow].No);
							isemriYukleHNX.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleHNX.Yapilacakis = kb.BatchNumber + "-- No  Bobin Tasi";
							isemriYukleHNX.isTipi = WorkType.bobin_tasima;
							isemriYukleHNX.equipmentNumber = kb.BatchNumber;
							isemriYukleHNX.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleHNX.Yapilacakisturu = "Kaide yukle";
							id_yukleHNX = idStringHazirla(1, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleHNX.Issuresi, isemriYukleHNX.AtmosphereTuru);
							isemriYukleHNX.UniqueID = id_yukleHNX;
							isemriYukleHNX.skor = skorhesapla(isemriYukleHNX.UniqueID);
							//		Console.WriteLine("HNX-ECL" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleHNX);
							emir_sirasiLOAD = emir_sirasiLOAD + 1;
						}
						

						IsemriL isemriYukleHNXGom = new IsemriL();
						//hnxUygunGom[t].BaseNumber;
						//isemriYukleHNX e gömlek ekle
						//YuklemeIsListe.Add(isemriYukleHNXGom);
						if (hnxUygunGom.Count > 0) { 
					    	int MinRowGom = 0;
					    	double FinalFarkGom = 10000;
					    		int MinRowGomFur = 0;
					    		for (int t = 0; t < hnxUygunGom.Count; t++)
							{
								double FARKC = Math.Abs(ISYUKLOKASYON - hnxUygunGom[t].Xkor);
								if (FARKC < FinalFarkGom)
								{
									FinalFarkGom = FARKC;
									MinRowGomFur = t;

								}
							}
					    	var YukleGom = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == hnxUygunGom[MinRowGom].BaseNumber);
					    	isemriYukleHNXGom.Zaman = DateTime.Now;
					    	isemriYukleHNXGom.IntZaman = 0.0;
					    	isemriYukleHNXGom.AtmosphereTuru = "HNX";
					    	isemriYukleHNXGom.AtacmanTipi = "Konvektor Aparatı";
					    	isemriYukleHNXGom.Issuresi = 2.5;
					    	isemriYukleHNXGom.Konum1Kaide = hnxUygunGom[MinRowGomFur].BaseNumber.ToString();
					    	isemriYukleHNXGom.Konum1Kolon = YukleGom.Kolonno + "";
					    	isemriYukleHNXGom.Konum2Kaide = Convert.ToString(hnxUygun[MinRow].No);
					    	isemriYukleHNXGom.Konum2Kolon = YukleEsleme.Kolonno + "";
					    	isemriYukleHNXGom.Yapilacakis = hnxUygunGom[MinRowGomFur].No + "-- Nolu  Gomlek Tak";
					    	isemriYukleHNXGom.isTipi = WorkType.gomlek_tak;
					    	isemriYukleHNXGom.isDetayi = WorkTypeDetail.kaide_yukle;
					    	isemriYukleHNXGom.equipmentNumber = hnxUygunGom[MinRowGomFur].No.ToString();
					    	hnxUygunGom.RemoveAt(MinRowGomFur);
					    	isemriYukleHNXGom.Yapilacakisturu = "Gomlek yukle";
					    	id_yukleHNX = idStringHazirla(2, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleHNXGom.Issuresi, isemriYukleHNXGom.AtmosphereTuru);
					    	isemriYukleHNXGom.UniqueID = id_yukleHNX;
					    	isemriYukleHNXGom.skor = skorhesapla(isemriYukleHNXGom.UniqueID);
					    	//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
					    	YuklemeIsListe.Add(isemriYukleHNXGom);
					    	emir_sirasiLOAD = emir_sirasiLOAD + 1;
						}
						IsemriL isemriYukleHNXFirin = new IsemriL();
						//hnxUygunGom[t].BaseNumber;
						//isemriYukleHNX e gömlek ekle
						//YuklemeIsListe.Add(isemriYukleHNXGom);
						if (hnxUygunGom.Count > 0 && UygunFurHNX.Count > 0) 
						{
							

							double FinalFarkFur = 10000;
							int MinRowFur = 0;
							for (int t = 0; t < UygunFurHNX.Count; t++)
							{
								double FARKC = Math.Abs(ISYUKLOKASYON - UygunFurHNX[t].Xkor);
								if (FARKC < FinalFarkFur)
								{
									FinalFarkFur = FARKC;
									MinRowFur = t;

								}
							}
							var YukleFurHNX = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurHNX[MinRowFur].BaseNumber);
							isemriYukleHNXFirin.Zaman = DateTime.Now;
							isemriYukleHNXFirin.IntZaman = 0.0;
							isemriYukleHNXFirin.AtmosphereTuru = "HNX";
							isemriYukleHNXFirin.AtacmanTipi = "Konvektor Aparatı";
							isemriYukleHNXFirin.Issuresi = 2.5;
							isemriYukleHNXFirin.Konum1Kaide = UygunFurHNX[MinRowFur].BaseNumber.ToString();
							isemriYukleHNXFirin.Konum1Kolon = YukleFurHNX.Kolonno + "";
							isemriYukleHNXFirin.Konum2Kaide = Convert.ToString(hnxUygun[MinRow].No);
							isemriYukleHNXFirin.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleHNXFirin.Yapilacakis = UygunFurHNX[MinRowFur].No + "-- Nolu  Firin Tak";
							isemriYukleHNXFirin.isTipi = WorkType.firin_tak;
							isemriYukleHNXFirin.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleHNXFirin.equipmentNumber = UygunFurHNX[MinRowFur].No.ToString();
							UygunFurHNX.RemoveAt(MinRowFur);
							isemriYukleHNXFirin.Yapilacakisturu = "Fırın yukle";
							id_yukleHNX = idStringHazirla(3, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleHNXFirin.Issuresi, isemriYukleHNXFirin.AtmosphereTuru);
							isemriYukleHNXFirin.UniqueID = id_yukleHNX;
							isemriYukleHNXFirin.skor = skorhesapla(isemriYukleHNXFirin.UniqueID);
							//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleHNXFirin);
						}
						
						hnxUygun.RemoveAt(MinRow);
					}
					islem_sirasiLOAD = islem_sirasiLOAD + 1;
				}
				islem_sirasiLOAD = islem_sirasiLOAD - 1;
			}
			var H2GroupsRCM = H2ResultRCM.GroupBy(h => h.ProgramNumber).Select(s => new { ProgramNumber = s.Key, List = s.ToList() });
			var H2GroupsECL = H2ResultECL.GroupBy(h => h.ProgramNumber).Select(s => new { ProgramNumber = s.Key, List = s.ToList() });
			if(h2Uygun.Count>0)
			{
				//int islem_sirasiLOAD = 1;
				foreach (var item in H2GroupsRCM)
			    {
					if (h2Uygun.Count > 0)
					{
						Console.WriteLine("H2 GRUBU IN RCM TRANSPALAN(PROGRAM NO: " + item.ProgramNumber + ")");

						int FinalFark = 100;
						int MinRow = 0;

						for (int t = 0; t < h2Uygun.Count; t++)
						{
							var koloneslemeLoadH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == h2Uygun[t].No);
							int FarkC = Math.Abs(koloneslemeLoadH2.Kolonno - 4);
							if (FarkC < FinalFark)
							{
								FinalFark = FarkC;
								MinRow = t;
							}

						}

						var YukleEsleme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == h2Uygun[MinRow].No);
						int ISYUKLOKASYON = Convert.ToInt32(KaideListesi.Find(e => e.No == h2Uygun[MinRow].No).Xkor);
						int emir_sirasiLOAD = 1;
						foreach (Kaidebobin kb in item.List)
						{
							IsemriL isemriYukleH2 = new IsemriL();
							Console.WriteLine("Batch: " + kb.BatchNumber + " BOrder: " + kb.BatchOrder + " Yeri: " + kb.A510_B + " Status: " + kb.Status);

							isemriYukleH2.Zaman = DateTime.Now;
							isemriYukleH2.IntZaman = 0.0;
							isemriYukleH2.AtmosphereTuru = "H2";
							isemriYukleH2.AtacmanTipi = "Bobin Aparati";
							isemriYukleH2.Issuresi = 4.0;
							isemriYukleH2.Konum1Kaide = "BAF_RCM_TRN";
							isemriYukleH2.Konum1Kolon = "4";
							isemriYukleH2.Konum2Kaide = Convert.ToString(h2Uygun[MinRow].No);
							isemriYukleH2.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleH2.Yapilacakis = kb.BatchNumber + "-- No  Bobin Tasi";
							isemriYukleH2.isTipi = WorkType.bobin_tasima;
							isemriYukleH2.equipmentNumber = kb.BatchNumber;
							isemriYukleH2.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleH2.Yapilacakisturu = "Kaide yukle";
							id_yukleH2 = idStringHazirla(1, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleH2.Issuresi, isemriYukleH2.AtmosphereTuru);
							isemriYukleH2.UniqueID = id_yukleH2;
							isemriYukleH2.skor = skorhesapla(isemriYukleH2.UniqueID);
							//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleH2);
							emir_sirasiLOAD = emir_sirasiLOAD + 1;
						}

						if (h2UygunGom.Count > 0) { 
					    	IsemriL isemriYukleH2Gom = new IsemriL();
					    	//hnxUygunGom[t].BaseNumber;
					    	//isemriYukleHNX e gömlek ekle
					    	//YuklemeIsListe.Add(isemriYukleHNXGom);
					    	int MinRowGom = 0;
					    	double FinalFarkGom = 10000;
					    
					    	for (int t = 0; t < h2UygunGom.Count; t++)
						{
							double FARKC = Math.Abs(ISYUKLOKASYON - h2UygunGom[t].Xkor);
							if (FARKC < FinalFarkGom)
							{
								FinalFarkGom = FARKC;
								MinRowGom = t;

							}
						}
					    
					    	var YukleGom = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == h2UygunGom[MinRowGom].BaseNumber);
					    	isemriYukleH2Gom.Zaman = DateTime.Now;
					    	isemriYukleH2Gom.IntZaman = 0.0;
					    	isemriYukleH2Gom.AtmosphereTuru = "H2";
					    	isemriYukleH2Gom.AtacmanTipi = "Konvektor Aparatı";
					    	isemriYukleH2Gom.Issuresi = 2.5;
					    	isemriYukleH2Gom.Konum1Kaide = h2UygunGom[MinRowGom].BaseNumber.ToString();
					    	isemriYukleH2Gom.Konum1Kolon = YukleGom.Kolonno + "";
					    	isemriYukleH2Gom.Konum2Kaide = Convert.ToString(h2Uygun[MinRow].No);
					    	isemriYukleH2Gom.Konum2Kolon = YukleEsleme.Kolonno + "";
					    	isemriYukleH2Gom.Yapilacakis = h2UygunGom[MinRowGom].No + "-- Nolu  Gomlek Tak";
					    	isemriYukleH2Gom.isTipi = WorkType.gomlek_tak;
					    	isemriYukleH2Gom.isDetayi = WorkTypeDetail.kaide_yukle;
					    	isemriYukleH2Gom.equipmentNumber = h2UygunGom[MinRowGom].No.ToString();
					    	h2UygunGom.RemoveAt(MinRowGom);
					    	isemriYukleH2Gom.Yapilacakisturu = "Gomlek yukle";
					    	id_yukleHNX = idStringHazirla(2, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleH2Gom.Issuresi, isemriYukleH2Gom.AtmosphereTuru);
					    	isemriYukleH2Gom.UniqueID = id_yukleHNX;
					    	isemriYukleH2Gom.skor = skorhesapla(isemriYukleH2Gom.UniqueID);
					    	//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
					    	YuklemeIsListe.Add(isemriYukleH2Gom);
					    	emir_sirasiLOAD = emir_sirasiLOAD + 1;
					}
						IsemriL isemriYukleH2Firin = new IsemriL();
						if (61 <= Convert.ToInt32(YukleEsleme.BaseNumber) && Convert.ToInt32(YukleEsleme.BaseNumber) <= 76)
						{
							UygunFurH2 = UygunFurH2Faz1;
						}
						else if(Convert.ToInt32(YukleEsleme.BaseNumber) > 76) 
						{ 
							UygunFurH2 = UygunFurH2Faz2; 
						}

						if (h2UygunGom.Count > 0 && UygunFurH2.Count > 0)
						{
							double FinalFarkFur = 10000;
							int MinRowGomFur = 0;
							for (int t = 0; t < UygunFurH2.Count; t++)
							{
								double FARKC = Math.Abs(ISYUKLOKASYON - UygunFurH2[t].Xkor);
								if (FARKC < FinalFarkFur)
								{
									FinalFarkFur = FARKC;
									MinRowGomFur = t;

								}
							}
							var YukleFurH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurH2[MinRowGomFur].BaseNumber);
							isemriYukleH2Firin.Zaman = DateTime.Now;
							isemriYukleH2Firin.IntZaman = 0.0;
							isemriYukleH2Firin.AtmosphereTuru = "H2";
							isemriYukleH2Firin.AtacmanTipi = "Konvektor Aparatı";
							isemriYukleH2Firin.Issuresi = 2.5;
							isemriYukleH2Firin.Konum1Kaide = UygunFurH2[MinRowGomFur].BaseNumber.ToString();
							isemriYukleH2Firin.Konum1Kolon = YukleFurH2.Kolonno + "";
							isemriYukleH2Firin.Konum2Kaide = Convert.ToString(h2Uygun[MinRow].No);
							isemriYukleH2Firin.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleH2Firin.Yapilacakis = UygunFurH2[MinRowGomFur].No + "-- Nolu  Firin Tak";
							isemriYukleH2Firin.isTipi = WorkType.firin_tak;
							isemriYukleH2Firin.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleH2Firin.equipmentNumber = UygunFurH2[MinRowGomFur].No.ToString();
							UygunFurH2.RemoveAt(MinRowGomFur);
							isemriYukleH2Firin.Yapilacakisturu = "Fırın yukle";
							id_yukleHNX = idStringHazirla(3, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleH2Firin.Issuresi, isemriYukleH2Firin.AtmosphereTuru);
							isemriYukleH2Firin.UniqueID = id_yukleHNX;
							isemriYukleH2Firin.skor = skorhesapla(isemriYukleH2Firin.UniqueID);
							//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleH2Firin);
						}

						h2Uygun.RemoveAt(MinRow);
					}
					islem_sirasiLOAD = islem_sirasiLOAD + 1;
					
				}
			    foreach (var item in H2GroupsECL)
			  {
					if (h2Uygun.Count > 0)
					{
						Console.WriteLine("H2 GRUBU IN ECL TRANSPALAN(PROGRAM NO: " + item.ProgramNumber + ")");
						int FinalFark = 100;
						int MinRow = 0;
						for (int t = 0; t < h2Uygun.Count; t++)
						{
							var koloneslemeLoadHNX = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == h2Uygun[t].No);
							int FarkC = Math.Abs(koloneslemeLoadHNX.Kolonno - 16);
							if (FarkC < FinalFark)
							{
								FinalFark = FarkC;
								MinRow = t;
							}

						}
						var YukleEsleme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == h2Uygun[MinRow].No);
						int ISYUKLOKASYON = Convert.ToInt32(KaideListesi.Find(e => e.No == h2Uygun[MinRow].No).Xkor);
						int emir_sirasiLOAD = 1;
						foreach (Kaidebobin kb in item.List)
						{

							IsemriL isemriYukleH2 = new IsemriL();
							Console.WriteLine("Batch: " + kb.BatchNumber + " BOrder: " + kb.BatchOrder + " Yeri: " + kb.A510_B + " Status: " + kb.Status);
							isemriYukleH2.Zaman = DateTime.Now;
							isemriYukleH2.IntZaman = 0.0;

							isemriYukleH2.AtmosphereTuru = "H2";
							isemriYukleH2.AtacmanTipi = "Bobin Aparati";
							isemriYukleH2.Issuresi = 4.0;
							isemriYukleH2.Konum1Kaide = "BAF_ECL_TRN";
							isemriYukleH2.Konum1Kolon = "16";
							isemriYukleH2.Konum2Kaide = Convert.ToString(h2Uygun[MinRow].No);
							isemriYukleH2.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleH2.Yapilacakis = kb.BatchNumber + "-- No  Bobin Tasi";
							isemriYukleH2.isTipi = WorkType.bobin_tasima;
							isemriYukleH2.equipmentNumber = kb.BatchNumber;
							isemriYukleH2.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleH2.Yapilacakisturu = "Kaide yukle";
							id_yukleHNX = idStringHazirla(1, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleH2.Issuresi, isemriYukleH2.AtmosphereTuru);
							isemriYukleH2.UniqueID = id_yukleHNX;
							isemriYukleH2.skor = skorhesapla(isemriYukleH2.UniqueID);

							//		Console.WriteLine("HNX-ECL" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleH2);
							emir_sirasiLOAD = emir_sirasiLOAD + 1;
						}
						
						IsemriL isemriYukleH2Gom = new IsemriL();
						//hnxUygunGom[t].BaseNumber;
						//isemriYukleHNX e gömlek ekle
						//YuklemeIsListe.Add(isemriYukleHNXGom);
						if (h2UygunGom.Count > 0) { 
					    	int MinRowGom = 0;
					    	double FinalFarkGom = 10000;
					    
					    	for (int t = 0; t < h2UygunGom.Count; t++)
						{
							double FARKC = Math.Abs(ISYUKLOKASYON - h2UygunGom[t].Xkor);
							if (FARKC < FinalFarkGom)
							{
								FinalFarkGom = FARKC;
								MinRowGom = t;

							}
						}
					    	var YukleGom = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == h2UygunGom[MinRowGom].BaseNumber);
					    	isemriYukleH2Gom.Zaman = DateTime.Now;
					    	isemriYukleH2Gom.IntZaman = 0.0;
					    	isemriYukleH2Gom.AtmosphereTuru = "H2";
					    	isemriYukleH2Gom.AtacmanTipi = "Konvektor Aparatı";
					    	isemriYukleH2Gom.Issuresi = 2.5;
					    	isemriYukleH2Gom.Konum1Kaide = h2UygunGom[MinRowGom].BaseNumber.ToString();
					    	isemriYukleH2Gom.Konum1Kolon = YukleGom.Kolonno + "";
					    	isemriYukleH2Gom.Konum2Kaide = Convert.ToString(h2Uygun[MinRow].No);
					    	isemriYukleH2Gom.Konum2Kolon = YukleEsleme.Kolonno + "";
					    	isemriYukleH2Gom.Yapilacakis = h2UygunGom[MinRowGom].No + "-- Nolu  Gomlek Tak";
					    	isemriYukleH2Gom.isTipi = WorkType.gomlek_tak;
					    	isemriYukleH2Gom.isDetayi = WorkTypeDetail.kaide_yukle;
					    	isemriYukleH2Gom.equipmentNumber = h2UygunGom[MinRowGom].No.ToString();
					    	h2UygunGom.RemoveAt(MinRowGom);
					    	isemriYukleH2Gom.Yapilacakisturu = "Gomlek yukle";
					    	id_yukleHNX = idStringHazirla(2, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleH2Gom.Issuresi, isemriYukleH2Gom.AtmosphereTuru);
					    	isemriYukleH2Gom.UniqueID = id_yukleHNX;
					    	isemriYukleH2Gom.skor = skorhesapla(isemriYukleH2Gom.UniqueID);
					    	//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
					    	YuklemeIsListe.Add(isemriYukleH2Gom);
					    	emir_sirasiLOAD = emir_sirasiLOAD + 1;
						}
						IsemriL isemriYukleH2Firin = new IsemriL();
						if (61 <= Convert.ToInt32(YukleEsleme.BaseNumber) && Convert.ToInt32(YukleEsleme.BaseNumber) <= 76)
						{
							UygunFurH2 = UygunFurH2Faz1;
						}
						else if (Convert.ToInt32(YukleEsleme.BaseNumber) > 76)
						{
							UygunFurH2 = UygunFurH2Faz2;
						}
						if (h2UygunGom.Count > 0 && UygunFurH2.Count > 0)
						{
							int FinalFarkFur = 100;
							int MinRowGomFur = 0;
							for (int t = 0; t < UygunFurH2.Count; t++)
							{
								var LoadHNXFur = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurH2[t].BaseNumber);
								int FarkG = Math.Abs(LoadHNXFur.Kolonno - YukleEsleme.Kolonno);
								if (FarkG < FinalFarkFur)
								{
									FinalFarkFur = FarkG;
									MinRowGomFur = t;
								}
							}
							var YukleFurH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == UygunFurH2[MinRowGomFur].BaseNumber);
							isemriYukleH2Firin.Zaman = DateTime.Now;
							isemriYukleH2Firin.IntZaman = 0.0;
							isemriYukleH2Firin.AtmosphereTuru = "HNX";
							isemriYukleH2Firin.AtacmanTipi = "Konvektor Aparatı";
							isemriYukleH2Firin.Issuresi = 2.5;
							isemriYukleH2Firin.Konum1Kaide = UygunFurH2[MinRowGomFur].BaseNumber.ToString();
							isemriYukleH2Firin.Konum1Kolon = YukleFurH2.Kolonno + "";
							isemriYukleH2Firin.Konum2Kaide = Convert.ToString(h2Uygun[MinRow].No);
							isemriYukleH2Firin.Konum2Kolon = YukleEsleme.Kolonno + "";
							isemriYukleH2Firin.Yapilacakis = UygunFurH2[MinRowGomFur].No + "-- Nolu  Firin Tak";
							isemriYukleH2Firin.isTipi = WorkType.firin_tak;
							isemriYukleH2Firin.isDetayi = WorkTypeDetail.kaide_yukle;
							isemriYukleH2Firin.equipmentNumber = UygunFurH2[MinRowGomFur].No.ToString();
							UygunFurH2.RemoveAt(MinRowGomFur);
							isemriYukleH2Firin.Yapilacakisturu = "Fırın yukle";
							id_yukleHNX = idStringHazirla(3, islem_sirasiLOAD, 1, emir_sirasiLOAD, isemriYukleH2Firin.Issuresi, isemriYukleH2Firin.AtmosphereTuru);
							isemriYukleH2Firin.UniqueID = id_yukleHNX;
							isemriYukleH2Firin.skor = skorhesapla(isemriYukleH2Firin.UniqueID);
							//	Console.WriteLine("HNX-RCM" + hnxUygun[MinRow].No);
							YuklemeIsListe.Add(isemriYukleH2Firin);
						}

						h2Uygun.RemoveAt(MinRow);
					}
					islem_sirasiLOAD = islem_sirasiLOAD + 1;

			  }
			}
			// Eşlemek istersen join
			//	Console.WriteLine("\r\nHAT: " + hat + " BOBIN SAYISI: " + bobinSayisi 
			//		+ " KAIDE SAYISI: " + KaideListesi.Count + " H2 UYGUNLAR: " + h2Uygun.Count
			//		+ " HNX UYGUNLAR: " + hnxUygun.Count);

			return YuklemeIsListe;
		}

	}
}
