using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Tavlama
{
	public class ProblemVerisiFULL
	{
		private double parameter1 = 0.5; //Queryable
		private double parameter2 = 1;
		private double parameter3 = 3;
		public JsonReader JSONdosyalar { get; set; }
		public List<Prosesbitim> ProsesbitimListesi { get; set; }
		public List<Prosesbitim> ProsesbitimListesiO { get; set; }
		public List<Kaide> KaideListesi { get; set; }
		public List<Gomlek> GomlekListesi { get; set; }
		public List<Firin> FirinListesi { get; set; }
		public List<Sogutmacan> SogutmacanListesi { get; set; }
		public List<Kaidebobin> KaideBobinListesi { get; set; }

		public List<IsemriL> list { get; set; }
		public List<IsemriL> YukleListHNX { get; set; }
		public List<IsemriL> YukleListH2 { get; set; }
		public Konvektor konvektor { get; set; }
		public Liste liste { get; set; }
		public Kaidebobin kaidebobin { get; set; }
		public Bobinsayisi bobinsayisi { get; set; }
		public static string idStringHazirla(int oncelik, int islem_sira, int alternatif, int emirSira, double sure, string AtmType)
		{
			return oncelik + (islem_sira % 1000).ToString("D3") + alternatif.ToString("D2") + emirSira.ToString("D2") + ((int)(sure) * 10).ToString("D3") + AtmType;
		}
		static DataTable UygunIcGomlekH2(DataTable dt)
		{
			dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
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
			dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//			Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable UygunSoCaHNX(DataTable dt)
		{
			dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
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
			dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
			//dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//	Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable UygunFirinHNX(DataTable dt)
		{
			dt.DefaultView.RowFilter = "AtmosphereType = 'HNX'";
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
			dt.DefaultView.RowFilter = "AtmosphereType = 'H2'";
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

		public List<Kaide> GetUygunKaideler(string AType)
		{
			return KaideListesi.Where(o => o.StatusText.Equals("BOŞALTILDI") && o.AtmosphereType.Equals(AType)).ToList();
		}

		public List<Gomlek> GetUygunGomlek(string AType)
		{
			return GomlekListesi.Where(o => o.StatusText.Equals("BOŞALTILDI") && o.AtmosphereType.Equals(AType)).ToList();
		}
		private double skorhesapla(string uniqueID)
		{
			double oncelik = 0;

			oncelik += Math.Abs(-5 + Double.Parse(uniqueID.Substring(0, 1))) * this.parameter3;
			oncelik += Double.Parse(uniqueID.Substring(8, 3)) / 10 * this.parameter1;
			return oncelik;
		}

		public int ProcessBitimNumber;
		public ProblemVerisiFULL()
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

			//objService.CreateSsysWorkOrder(strObjeNo, strObjeTipi, strEmirTipi, strAlHat, strBrkHat, strAciklama);
			OOtahmini_proses_bitim = DTtahmini_proses_bitim;

			SogutmacanListesi = new List<Sogutmacan>();
			foreach (DataRow dr in DTsogutmacani.Rows)
			{
				// objeyi oluşturmak gerekiyor. Parametresiz oluşturacaksan constructor eklemen lazım
				// İstersen Sogutmacan(int no, String atmosphereType, String statusText, int baseNumber, int isIdled) olarak doldurabilirsin
				Sogutmacan sogutmacani = new Sogutmacan();
				sogutmacani.AtmosphereType = dr["AtmosphereType"].ToString();
				sogutmacani.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				sogutmacani.StatusText = dr["StatusText"].ToString();
				sogutmacani.IsIdled = Convert.ToInt32(dr["IsIdled"].ToString());
				// yukardakileri direkt constructor içinde de yazabilirsin. Classta parametrelerle tanımlamıştık, yapmicam şimdi :D

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
				KaideListesi.Add(kaide);
			}
			GomlekListesi = new List<Gomlek>();
			foreach (DataRow dr in DTgomlek.Rows)
			{
				Gomlek gomlek = new Gomlek();
				gomlek.AtmosphereType = dr["AtmosphereType"].ToString();
				gomlek.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				gomlek.StatusText = dr["StatusText"].ToString();
				gomlek.IsIdled = Convert.ToInt32(dr["IsIdled"].ToString());
				GomlekListesi.Add(gomlek);
			}
			FirinListesi = new List<Firin>();
			foreach (DataRow dr in DTfirin.Rows)
			{
				Firin firinl = new Firin();
				firinl.AtmosphereType = dr["AtmosphereType"].ToString();
				firinl.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				firinl.StatusText = dr["StatusText"].ToString();
				firinl.IsIdled = Convert.ToInt32(dr["IsIdled"].ToString());
				FirinListesi.Add(firinl);
			}
			//	OOtahmini_proses_bitim.DefaultView.RowFilter = "ProcessEnd = '1.01.1900 00:00:00'";
			//	OOtahmini_proses_bitim = OOtahmini_proses_bitim.DefaultView.ToTable();
			//	OOtahmini_proses_bitim.DefaultView.RowFilter = "State = '102'";
			//	OOtahmini_proses_bitim = OOtahmini_proses_bitim.DefaultView.ToTable();
			DateTime TimeNow = DateTime.Now;
			DateTime UpTimeNow = TimeNow.AddMinutes(720);
			//Console.WriteLine(TimeNow);
			string TimeNowS = TimeNow.ToString();
			//TimeNow.ToString("MM.dd.yyyy HH:mm:ss");
			//	DTtahmini_proses_bitim.DefaultView.RowFilter = "ProcessEnd > #1.01.1900 00:00:00#";
			//	DTtahmini_proses_bitim = DTtahmini_proses_bitim.DefaultView.ToTable();
			DTtahmini_proses_bitim.DefaultView.RowFilter = "ProcessEnd <#" + UpTimeNow.ToString("MM.dd.yyyy HH:mm:ss") + "#";
			DTtahmini_proses_bitim = DTtahmini_proses_bitim.DefaultView.ToTable();
			DTtahmini_proses_bitim.DefaultView.Sort = "ProcessEnd";
			DTtahmini_proses_bitim = DTtahmini_proses_bitim.DefaultView.ToTable();
			ProsesbitimListesi = new List<Prosesbitim>();
			foreach (DataRow dr in DTtahmini_proses_bitim.Rows)
			{
				Prosesbitim ProcessBitimL = new Prosesbitim();
				ProcessBitimL.BaseNumber = Convert.ToInt32(dr["BaseNumber"].ToString());
				ProcessBitimL.PlugNumber = Convert.ToInt32(dr["PlugNumber"].ToString());
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
			int IS_TAHMIN = ProsesbitimListesi.Count;
			int islem_sirasiTAV = 1;
			int islem_sirasiBOS = 1;
			int islem_sirasiSOG = 1;
			for (int i = 0; i < IS_TAHMIN; i++)
			{
				IsemriL isemri = new IsemriL();
				Prosesbitim ProTurn = ProsesbitimListesi[i];

				int emir_sirasiTAV = 1;
				int emir_sirasiBOS = 1;
				int emir_sirasiSOG = 1;
				string id_strBOS;
				double süretaşimaBOS;
				string id_strTAV;
				double süretaşimaFIR;
				double süretaşimaSOCA;
				string id_strSOG;
				double süretaşimaSOG;
				string id_strBOB;
				double süretaşimaBOB;



				DateTime IsBas = Convert.ToDateTime(ProTurn.ProcessEnd);
				if (ProTurn.State == 202 || ProTurn.State == 210 || ProTurn.State == 0) //
				{
					if (ProTurn.PlugNumber != 0)
					{
						bobinsayisi = DTkaidebobin;
						int BobinNO = Convert.ToInt32(ProTurn.BaseNumber.ToString());
						bobinsayisi.DefaultView.RowFilter = String.Format("ProgramNumber  = '{0}'", BobinNO);
						bobinsayisi.DefaultView.RowFilter = $"ProgramNumber  = '{BobinNO}'";
						if (bobinsayisi.DefaultView.Count > 0)
						{
							IsemriL isemriSC = new IsemriL();
							isemriSC.Konum1Kaide = ProTurn.BaseNumber.ToString();

							TimeSpan ZamanFark = IsBas - DateTime.Now;
							//yoksa bu şekilde zaman farkı falan hesaplayamazsın, ya da zaman<diğer zaman gibi if içine koyamazsın
							//	int zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
							if (IsBas.ToString() == "1.01.1900 00:00:00")
							{
								isemriSC.IntZaman = 0;
							}
							else
							{
								double zamfark = Convert.ToDouble(ZamanFark.TotalMinutes);
								isemriSC.IntZaman = Math.Round(zamfark, 1);
							}


							isemriSC.Zaman = IsBas;

							var koloneslesme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurn.BaseNumber);

							isemriSC.Konum1Kaide = ProTurn.BaseNumber.ToString();
							isemriSC.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriSC.Konum1Kolon = koloneslesme.Kolonno + "";
							isemriSC.Konum2Kolon = koloneslesme.Kolonno + "";

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
							isemriSC.Yapilacakis = ProTurn.PlugNumber + "no lu Sogutma Canını çıkart";
							isemriSC.Yapilacakisturu = "Soğuma bitişi";
							id_strSOG = idStringHazirla(3, islem_sirasiSOG, 1, emir_sirasiSOG, isemriSC.Issuresi, isemriSC.AtmosphereTuru);
							isemriSC.UniqueID = id_strSOG;
							if (isemriSC.AtmosphereTuru == "H2")
							{
								isemriSC.skor = 3 * skorhesapla(isemriSC.UniqueID);
							}
							else
							{
								isemriSC.skor = 2 * skorhesapla(isemriSC.UniqueID);
							}

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
							if (IsBas.ToString() == "1.01.1900 00:00:00")
							{
								isemriGO.IntZaman = 0;
							}
							else
							{
								double zamfarkGO = Convert.ToDouble(ZamanFarkGO.TotalMinutes);
								isemriGO.IntZaman = Math.Round((zamfarkGO + isemriGO.Issuresi), 1);
							}

							//int zamfarkGO = Convert.ToInt32(ZamanFarkGO.TotalMinutes);


							isemriGO.Zaman = IsBas;
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
							isemriGO.Yapilacakis = "Gömleği çıkart";
							isemriGO.Yapilacakisturu = "Soğuma bitişi";
							id_strSOG = idStringHazirla(3, islem_sirasiSOG, 1, emir_sirasiSOG, isemriGO.Issuresi, isemriGO.AtmosphereTuru);
							isemriGO.UniqueID = id_strSOG;
							isemriGO.skor = skorhesapla(isemriGO.UniqueID);
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

							for (int j = 0; j < bobinsayisi.DefaultView.Count; j++)
							{
								IsemriL isemriBOS = new IsemriL();


								//tahmini_proses_bitim.Rows[i]["ProcessEnd"].ToString()


								//	isemriBOS.Konum1Kolon = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
								isemriBOS.Konum1Kaide = ProTurn.BaseNumber.ToString();
								isemriBOS.Konum1Kolon = koloneslesme.Kolonno + "";
								isemriBOS.Zaman = IsBas;
								isemriBOS.Konum2Kolon = "22";
								isemriBOS.Konum2Kaide = "C.S.";
								//IsemriNewRowBEM["Konum2 -Kolon"] = "22 Cebir Soğutma";
								//IsemriNewRowBEM["Konum2 -Kaide"] = "22 Cebir Soğutma";
								if (IsBas.ToString() == "1.01.1900 00:00:00")
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


								isemriBOS.Yapilacakis = "Bobin taşı";// temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
								isemriBOS.Yapilacakisturu = "Kaide boşalt";
								id_strBOB = idStringHazirla(4, islem_sirasiBOS, 1, emir_sirasiSOG, isemriBOS.Issuresi, isemriBOS.AtmosphereTuru);
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
				}
				else if (ProTurn.State == 1 || ProTurn.State == 2 || ProTurn.State == 3 || ProTurn.State == 4 || ProTurn.State == 5 || ProTurn.State == 6 || ProTurn.State == 7 || ProTurn.State == 8 || ProTurn.State == 9 || ProTurn.State == 10 || ProTurn.State == 190 || ProTurn.State == 200)
				{

					DataTable UygunKaideATMHNX = UygunKaideHNX(DTkaide);
					DataTable UygunKaideATMH2 = UygunKaideH2(DTkaide);



					IsemriL isemriTAVBIT = new IsemriL();
					isemriTAVBIT.Konum1Kaide = ProTurn.BaseNumber.ToString();

					double zamfark = 0;
					TimeSpan ZamanFark = IsBas - DateTime.Now;
					zamfark = ZamanFark.TotalMinutes;
					if (IsBas.ToString("dd.MM.yyy HH:mm:ss") == "01.01.1900 00:00:00") { isemriTAVBIT.IntZaman = 0; }
					else { isemriTAVBIT.IntZaman = Math.Round(zamfark); }

					//	Console.WriteLine(isemriTAVBIT.IntZaman);

					isemriTAVBIT.Zaman = IsBas;
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
					isemriTAVBIT.Yapilacakisturu = "TAV bitişi";
					id_strTAV = idStringHazirla(2, islem_sirasiTAV, 1, emir_sirasiTAV, isemriTAVBIT.Issuresi, isemriTAVBIT.AtmosphereTuru);
					isemriTAVBIT.UniqueID = id_strTAV;
					if (isemriTAVBIT.AtmosphereTuru == "H2")
					{
						isemriTAVBIT.skor = 3 * skorhesapla(isemriTAVBIT.UniqueID);
					}
					else
					{
						isemriTAVBIT.skor = 2 * skorhesapla(isemriTAVBIT.UniqueID);
					}

					emir_sirasiTAV = emir_sirasiTAV + 1;
					list.Add(isemriTAVBIT);
					//	}
					DataTable UygunSOCAH2 = UygunSoCaH2(DTsogutmacani);
					DataTable UygunSOCAHNX = UygunSoCaHNX(DTsogutmacani);

					int Finalfark = 100;
					int MinRow = 0;




					if (Convert.ToInt32(ProTurn.BaseNumber.ToString()) <= 34)
					{
						//int Alternatif = 1;
						//for (int k = 0; k < UygunSOCAHNX.DefaultView.Count; k++)
						//{
						if (UygunSOCAHNX.DefaultView.Count > 0)
						{
							IsemriL isemriSoCaHNX = new IsemriL();
							for (int t = 0; t < UygunSOCAHNX.DefaultView.Count; t++)
							{
								var SSkoloneslesmeSOCA = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunSOCAHNX.Rows[t]["BaseNumber"]));
								int farkC = Math.Abs(koloneslesme.Kolonno - SSkoloneslesmeSOCA.Kolonno);
								if (farkC < Finalfark)
								{
									Finalfark = farkC;
									MinRow = t;

								}
							}

							//	TimeSpan ZamanFark = IsBas - DateTime.Now;
							//	zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
							if (IsBas.ToString() == "1.01.1900 00:00:00") { isemriSoCaHNX.IntZaman = 0; }
							else { isemriSoCaHNX.IntZaman = Math.Round((zamfark + isemriTAVBIT.Issuresi), 1); };



							isemriSoCaHNX.Zaman = IsBas;
							isemriSoCaHNX.Konum1Kaide = UygunSOCAHNX.Rows[MinRow]["BaseNumber"].ToString();
							var koloneslesmeSOCA = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunSOCAHNX.Rows[MinRow]["BaseNumber"]));
							isemriSoCaHNX.Konum1Kolon = koloneslesmeSOCA.Kolonno + "";
							isemriSoCaHNX.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriSoCaHNX.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriSoCaHNX.AtmosphereTuru = "HNX";
							isemriSoCaHNX.AtacmanTipi = "Konvektor Tasima Aparatı";
							isemriSoCaHNX.Issuresi = 2.0;

							isemriSoCaHNX.Yapilacakis = UygunSOCAHNX.Rows[MinRow]["No"].ToString() + " Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriSoCaHNX.Yapilacakisturu = "TAV bitişi";
							id_strTAV = idStringHazirla(2, islem_sirasiTAV, 1, emir_sirasiTAV, isemriSoCaHNX.Issuresi, isemriSoCaHNX.AtmosphereTuru);
							emir_sirasiTAV = emir_sirasiTAV + 1;
							islem_sirasiTAV = islem_sirasiTAV + 1;
							isemriSoCaHNX.UniqueID = id_strTAV;

							isemriSoCaHNX.skor = 2 * skorhesapla(isemriSoCaHNX.UniqueID);
							list.Add(isemriSoCaHNX);
							//Alternatif = Alternatif + 1;
						}
						else { Console.WriteLine("Boş HNX soğutma çanı yok"); }

						//}
					}
					else
					{
						if (UygunSOCAH2.DefaultView.Count > 0)
						{
							for (int t = 0; t < UygunSOCAH2.DefaultView.Count; t++)
							{
								var SSkoloneslesmeSOCA = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunSOCAH2.Rows[t]["BaseNumber"]));
								int farkC = Math.Abs(koloneslesme.Kolonno - SSkoloneslesmeSOCA.Kolonno);
								if (farkC < Finalfark)
								{
									Finalfark = farkC;
									MinRow = t;

								}
							}
							IsemriL isemriSoCaH2 = new IsemriL();

							//TimeSpan ZamanFark = IsBas - DateTime.Now;
							//zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
							if (IsBas.ToString() == "1.01.1900 00:00:00") { isemriSoCaH2.IntZaman = 0; }
							else { isemriSoCaH2.IntZaman = Math.Round((zamfark + isemriTAVBIT.Issuresi), 1); };
							isemriSoCaH2.Zaman = IsBas;
							isemriSoCaH2.Konum1Kaide = UygunSOCAH2.Rows[MinRow]["BaseNumber"].ToString();
							var koloneslesmeSOCAH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunSOCAH2.Rows[MinRow]["BaseNumber"]));
							isemriSoCaH2.Konum1Kolon = koloneslesmeSOCAH2.Kolonno + "";
							isemriSoCaH2.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriSoCaH2.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriSoCaH2.AtmosphereTuru = "H2";
							isemriSoCaH2.AtacmanTipi = "Konvektor Tasima Aparatı";
							isemriSoCaH2.Issuresi = 2.0;

							isemriSoCaH2.Yapilacakis = UygunSOCAH2.Rows[MinRow]["No"].ToString() + "Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriSoCaH2.Yapilacakisturu = "TAV bitişi";
							id_strTAV = idStringHazirla(2, islem_sirasiTAV, 1, emir_sirasiTAV, isemriSoCaH2.Issuresi, isemriSoCaH2.AtmosphereTuru);
							islem_sirasiTAV = islem_sirasiTAV + 1;
							emir_sirasiTAV = emir_sirasiTAV + 1;
							isemriSoCaH2.UniqueID = id_strTAV;
							isemriSoCaH2.skor = 3 * skorhesapla(isemriSoCaH2.UniqueID);
							list.Add(isemriSoCaH2);

						}
						else { Console.WriteLine("Boş H2 soğutma çanı yok"); }


					}



				}

				else if (ProTurn.State == 102 || ProTurn.State == 101)
				{
					//Uygun fırını bul tak
					DataTable UygunFurH2 = UygunFirinH2(DTfirin);
					DataTable UygunFurHNX = UygunFirinHNX(DTfirin);
					Console.WriteLine("H2 firin :" + UygunFurH2.DefaultView.Count + "HNX firin :" + UygunFurHNX.DefaultView.Count);
					int zamfark = 0;
					if (Convert.ToInt32(ProTurn.BaseNumber.ToString()) <= 34)
					{
						if (UygunFurHNX.Rows.Count != 0)
						{
							int Finalfark = 100;
							int MinRow = 0;
							IsemriL isemriFirinHNX = new IsemriL();
							for (int t = 0; t < UygunFurHNX.DefaultView.Count; t++)
							{
								var koloneslesmeFur = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunFurHNX.Rows[t]["BaseNumber"]));
								int farkC = Math.Abs(koloneslesmeFur.Kolonno - koloneslesmeFur.Kolonno);
								if (farkC < Finalfark)
								{
									Finalfark = farkC;
									MinRow = t;

								}
							}
							var koloneslesme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurn.BaseNumber);
							if (IsBas.ToString("dd.MM.yyyy HH:mm:ss") == "01.01.1900 00:00:00")
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
							isemriFirinHNX.Konum1Kaide = UygunFurHNX.Rows[MinRow]["BaseNumber"].ToString();
							var koloneslesmeFurHNX = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunFurHNX.Rows[MinRow]["BaseNumber"]));
							isemriFirinHNX.Konum1Kolon = koloneslesmeFurHNX.Kolonno + "";
							isemriFirinHNX.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriFirinHNX.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriFirinHNX.AtmosphereTuru = "HNX";
							isemriFirinHNX.AtacmanTipi = "YOK";
							isemriFirinHNX.Issuresi = 2.0;

							isemriFirinHNX.Yapilacakis = " Fırın tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriFirinHNX.Yapilacakisturu = "Tav baslama";
							id_strTAV = idStringHazirla(1, islem_sirasiTAV, 1, emir_sirasiTAV, isemriFirinHNX.Issuresi, isemriFirinHNX.AtmosphereTuru);
							isemriFirinHNX.UniqueID = id_strTAV;
							if (isemriFirinHNX.AtmosphereTuru == "H2")
							{
								isemriFirinHNX.skor = 3 * skorhesapla(isemriFirinHNX.UniqueID);
							}
							else
							{
								isemriFirinHNX.skor = 2 * skorhesapla(isemriFirinHNX.UniqueID);
							}

							list.Add(isemriFirinHNX);

						}


					}
					else
					{
						if (UygunFurH2.Rows.Count != 0)
						{
							int Finalfark = 100;
							int MinRow = 0;
							IsemriL isemriFirinH2 = new IsemriL();
							for (int t = 0; t < UygunFurH2.DefaultView.Count; t++)
							{
								var koloneslesmeFur = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunFurH2.Rows[t]["BaseNumber"]));
								int farkC = Math.Abs(koloneslesmeFur.Kolonno - koloneslesmeFur.Kolonno);
								if (farkC < Finalfark)
								{
									Finalfark = farkC;
									MinRow = t;

								}
							}
							var koloneslesme = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == ProTurn.BaseNumber);
							if (IsBas.ToString("dd.MM.yyyy HH:mm:ss") == "01.01.1900 00:00:00")
							{

								isemriFirinH2.IntZaman = 0;
							}
							else
							{
								TimeSpan ZamanFark = IsBas - DateTime.Now;
								zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
								isemriFirinH2.IntZaman = zamfark;
							}


							isemriFirinH2.Zaman = IsBas;
							isemriFirinH2.Konum1Kaide = UygunFurH2.Rows[MinRow]["BaseNumber"].ToString();
							var koloneslesmeFurH2 = JSONdosyalar.KaideKolonEslesmesi.Find(e => e.BaseNumber == Convert.ToInt32(UygunFurH2.Rows[MinRow]["BaseNumber"]));
							isemriFirinH2.Konum1Kolon = koloneslesmeFurH2.Kolonno + "";
							isemriFirinH2.Konum2Kaide = ProTurn.BaseNumber.ToString();
							isemriFirinH2.Konum2Kolon = koloneslesme.Kolonno + "";
							isemriFirinH2.AtmosphereTuru = "H2";
							isemriFirinH2.AtacmanTipi = "YOK";
							isemriFirinH2.Issuresi = 2.0;

							isemriFirinH2.Yapilacakis = " Fırın tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							isemriFirinH2.Yapilacakisturu = "Tav baslama";
							id_strTAV = idStringHazirla(1, islem_sirasiTAV, 1, emir_sirasiTAV, isemriFirinH2.Issuresi, isemriFirinH2.AtmosphereTuru);
							isemriFirinH2.UniqueID = id_strTAV;
							if (isemriFirinH2.AtmosphereTuru == "H2")
							{
								isemriFirinH2.skor = 3 * skorhesapla(isemriFirinH2.UniqueID);
							}
							else
							{
								isemriFirinH2.skor = 2 * skorhesapla(isemriFirinH2.UniqueID);
							}

							list.Add(isemriFirinH2);

						}


					}
				}

			}
			//ProsesbitimListesi = list;

			//return list;

		}


	}
}
