
			Console.WriteLine("algoritma başlıyor-" + DateTime.Now.ToString());
			KolonIsimleri(tahmini_proses_bitim);
			KolonIsimleri2(kaidebobin);

			DataTable InuseSoCa = DTInuseSoCa(sogutmacani);

			DataTable InuseFirin = DTInuseFirin(firin);

			DataTable InuseGomlek = DTInuseGomlek(gomlek);

			// N nolu kaidedeki  bobin sayısı
			bobinsayisi = kaidebobin;


			for (int k = 91; k <= 200; k++)
			{
				bobinsayisi = kaidebobin;
				bobinsayisi.DefaultView.RowFilter = String.Format("ProgramNumber  = '{0}'", k);
				if (bobinsayisi.DefaultView.Count != 0)
				{
					//					Console.WriteLine("Program number --*--" + k);
				}

			}

			DataTable SureTable = new DataTable();
			DataTable AtacmanTable = new DataTable();
			DataTable AnnealingEqu = new DataTable();
			DataTable Siraliemir = new DataTable();
			SureTable = GetSSTable(path);
			AtacmanTable = GetAATable(path);
			AnnealingEqu = GetGAETable(path);

			// İş emirleri burada yarat
			DataRow IsemriNewRowSC;
			DataRow IsemriNewRowGO;
			DataRow IsemriNewRowTAV;
			DataRow IsemriNewRowBEM;
			DataRow IsemriNewRowSoCaH2;
			DataRow IsemriNewRowSoCaHNX;

			DataRow IsemriNewRowSCG;
			DataRow IsemriNewRowGOG;
			DataRow IsemriNewRowTAVG;
			DataRow IsemriNewRowBEMG;
			DataRow IsemriNewRowSoCaH2G;
			DataRow IsemriNewRowSoCaHNXG;
			DataTable IsemriTable;
			DataTable IsemriTableG;
			IsemriTable = new DataTable("MyDataTable");
			IsemriTable.Columns.Add("UniqueID", typeof(string));
			IsemriTable.Columns.Add("Zaman", typeof(string));
			IsemriTable.Columns.Add("IntZaman", typeof(int));
			IsemriTable.Columns.Add("Konum1 -Kolon", typeof(string));
			IsemriTable.Columns.Add("Konum1 -Kaide", typeof(string));
			IsemriTable.Columns.Add("Konum2 -Kolon", typeof(string));
			IsemriTable.Columns.Add("Konum2 -Kaide", typeof(string));
			IsemriTable.Columns.Add("Atacman Tipi", typeof(string));
			IsemriTable.Columns.Add("Is Süresi", typeof(string));
			IsemriTable.Columns.Add("Atmosphere Turu", typeof(string));
			IsemriTable.Columns.Add("Yapilacakis", typeof(string));
			IsemriTable.Columns.Add("Yapilacakisgrubu", typeof(string));
			IsemriNewRowSC = IsemriTable.NewRow();
			IsemriNewRowGO = IsemriTable.NewRow();
			IsemriNewRowTAV = IsemriTable.NewRow();
			IsemriNewRowBEM = IsemriTable.NewRow();
			IsemriNewRowSoCaH2 = IsemriTable.NewRow();
			IsemriNewRowSoCaHNX = IsemriTable.NewRow();

			IsemriTableG = new DataTable("MyDataTableG");
			IsemriTableG.Columns.Add("UniqueID", typeof(string));
			IsemriTableG.Columns.Add("Zaman", typeof(string));
			IsemriTableG.Columns.Add("IntZaman", typeof(int));
			IsemriTableG.Columns.Add("Konum1 -Kolon", typeof(string));
			IsemriTableG.Columns.Add("Konum1 -Kaide", typeof(string));
			IsemriTableG.Columns.Add("Konum2 -Kolon", typeof(string));
			IsemriTableG.Columns.Add("Konum2 -Kaide", typeof(string));
			IsemriTableG.Columns.Add("Atacman Tipi", typeof(string));
			IsemriTableG.Columns.Add("Is Süresi", typeof(string));
			IsemriTableG.Columns.Add("Atmosphere Turu", typeof(string));
			IsemriTableG.Columns.Add("Yapilacakis", typeof(string));
			IsemriTableG.Columns.Add("Yapilacakisgrubu", typeof(string));
			IsemriNewRowSCG = IsemriTableG.NewRow();
			IsemriNewRowGOG = IsemriTableG.NewRow();
			IsemriNewRowTAVG = IsemriTableG.NewRow();
			IsemriNewRowBEMG = IsemriTableG.NewRow();
			IsemriNewRowSoCaH2G = IsemriTableG.NewRow();
			IsemriNewRowSoCaHNXG = IsemriTableG.NewRow();

			// Yükleme Fonksiyonu gir
			Console.WriteLine("--------- HNX Kaide");
			UygunKaideHNX(kaide);
			Console.WriteLine("--------- H2 Kaide");
			UygunKaideH2(kaide);
			Console.WriteLine("-----------------");
			DataTable YuklemeIsEmri = new DataTable();

			//string id_str = idStringHazirla(1, islem_sirasi, 2, emir_sirasi, süretaşima);
			YuklemeIsEmri = LoadingBobin(kaide, firin, gomlek, 188, "RCM", 3, 13, 22, SonucArray, SureTable);

			int Zaman = 0;
			Boolean V1Durum = false;
			Boolean V2Durum = false;
			int V1Konum = 1;
			int V2Konum = 26;
			tahmini_proses_bitim = ProsesSira(tahmini_proses_bitim);


			Console.WriteLine(YuklemeIsEmri.Rows.Count);
			foreach (DataRow dr in YuklemeIsEmri.Rows)
			{

				Console.WriteLine("Yükleme : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} \t 7 : {6} \t 8 : {7}\t 9 : {8} \t 10 : {9} \t 11 : {10}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
				//Console.WriteLine("tahminprocess1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4}\t 6 : {5} ", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
			}



			//---- State 0 (soğuma bitti) state 200 soğutma çanı bul ve tak emirleri
			//tahmini_proses_bitim = ProsesSira(tahmini_proses_bitim);
			//	Console.WriteLine("before filter"+tahmini_proses_bitim.Rows.Count);
			//tahmini_proses_bitim.DefaultView.RowFilter = "State = '0'";
			tahmini_proses_bitim.DefaultView.RowFilter = "State = '202' OR State = '200' OR  State = '0'";
			tahmini_proses_bitim = tahmini_proses_bitim.DefaultView.ToTable();
			//	Console.WriteLine("after filter" + tahmini_proses_bitim.Rows.Count);
			/*
			DataTable tahmini_proses_bitimG = new DataTable();
			tahmini_proses_bitimG = tahmini_proses_bitim;
			tahmini_proses_bitimG.DefaultView.RowFilter = "ProcessEnd = '1.01.1900 00:00:00'";
			tahmini_proses_bitimG = tahmini_proses_bitimG.DefaultView.ToTable();





			tahmini_proses_bitim.DefaultView.RowFilter = "ProcessEnd > '1.01.1900 00:00:00'";
			tahmini_proses_bitim = tahmini_proses_bitim.DefaultView.ToTable();
			*/
			int isemirsayi = tahmini_proses_bitim.Rows.Count;
			tahmini_proses_bitim.Columns.Add("Yeni", typeof(string));
			/*tahmini_proses_bitimG.Columns.Add("Yeni", typeof(string));
			for (int i = 0; i < tahmini_proses_bitimG.Rows.Count; i++)
			{
				DataRow dr = tahmini_proses_bitimG.Rows[i];
				Console.WriteLine(" G :: 1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} ", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
				//	Console.WriteLine(tahmini_proses_bitim.Rows[i]["BaseNumber"]);
			}
			Console.WriteLine("-----------------------------------------------------------");
			*/
			for (int i = 0; i < tahmini_proses_bitim.Rows.Count; i++)
			{
				DataRow dr = tahmini_proses_bitim.Rows[i];
				Console.WriteLine(" T :: 1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} ", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
				Console.WriteLine(tahmini_proses_bitim.Rows[i]["BaseNumber"]);
			}




			int islem_sirasiTAV = 1;

			int islem_sirasiBOS = 1;
			int islem_sirasiSOG = 1;



			int Is_Tahmin = tahmini_proses_bitim.Rows.Count;

			for (int i = 0; i < Is_Tahmin; i++)
			{
				int emir_sirasiTAV = 1;
				int emir_sirasiBOS = 1;
				int emir_sirasiSOG = 1;
				string isSTATE = tahmini_proses_bitim.Rows[i]["State"].ToString();
				//	Console.WriteLine(tahmini_proses_bitim.Rows[i]["State"].ToString());
				string id_strBOS;
				double süretaşimaBOS;
				string id_strTAV;
				double süretaşimaFIR;
				double süretaşimaSOCA;
				string id_strSOG;
				double süretaşimaSOG;
				string id_strBOB;
				double süretaşimaBOB;


				if (isSTATE == "0" || isSTATE == "202") // Soguma bitti sogutma canı cıkarisSTATE == "0" ||
				{
					//	Console.WriteLine("State 202 BASE NUM :" + tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString()+"   Soğuma bitti");
					//Sogutma canı çıkar

					string expression = "BaseNumber = " + tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
					DataRow[] temp = sogutmacani.Select(expression);
					//if ((temp.Length > 0)&&(temp[0]["StatusID"].ToString() !="80"))
					if (temp.Length > 0)
					{
						//			Console.WriteLine("--" + temp[0]["No"].ToString());
					}


					if (temp.Length > 0)
					{
						tahmini_proses_bitim.Rows[i]["Yeni"] = temp[0]["No"].ToString();
					}
					else
						tahmini_proses_bitim.Rows[i]["Yeni"] = "-";
					//	DataRow[] temp = sogutmacani.Select("BaseNumber = ' '");

					// InuseSoCa da BaseNumber ı aynı olan SoCa nın No sunu bir column kısmına yazdır
					//Console.WriteLine("soca nosu :"+InuseSoCa.Rows[0]["No"]);
					DateTime IsBas = Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"]);
					int zamfark = 0;
					IsemriNewRowSC = IsemriTable.NewRow();
					if (IsBas.ToString() == "1.01.1900 00:00:00")
					{

						IsemriNewRowSC["IntZaman"] = 0;
					}
					else
					{
						TimeSpan ZamanFark = IsBas - DateTime.Now;
						zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
						IsemriNewRowSC["IntZaman"] = zamfark;
					}
					//Console.WriteLine(IsemriNewRowSC["IntZaman"]);

					//	Double zamfark = Convert.ToDouble(ZamanFark.TotalMinutes);
					//	Console.WriteLine(DateTime.Now.ToString());
					//	Console.WriteLine(IsBas.ToString());
					//	Console.WriteLine("time fark"+zamfark);

					//	IsemriNewRowSC["Zaman"] = Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"]);
					IsemriNewRowSC["Zaman"] = IsBas.ToString("yyyy.MM.dd HH:mm:ss");

					IsemriNewRowSC["Konum1 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
					IsemriNewRowSC["Konum1 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
					IsemriNewRowSC["Konum2 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
					IsemriNewRowSC["Konum2 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();


					if (Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString()) <= 34)
					{
						IsemriNewRowSC["Atmosphere Turu"] = "HNX";
						IsemriNewRowSC["Atacman Tipi"] = "Konvektor Tasima Aparatı";
						IsemriNewRowSC["Is Süresi"] = SureTable.Rows[20]["Süre"].ToString();
						süretaşimaBOS = Convert.ToDouble(SureTable.Rows[20]["Süre"]);
					}
					else
					{
						IsemriNewRowSC["Atmosphere Turu"] = "H2";
						IsemriNewRowSC["Atacman Tipi"] = "Yok";
						IsemriNewRowSC["Is Süresi"] = SureTable.Rows[8]["Süre"].ToString();
						süretaşimaBOS = Convert.ToDouble(SureTable.Rows[8]["Süre"]);
					}

					IsemriNewRowSC["Yapilacakis"] = tahmini_proses_bitim.Rows[i]["PlugNumber"].ToString() + "no lu Sogutma Canını çıkart";// temp[0]["No"].ToString()+ temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
					IsemriNewRowSC["Yapilacakisgrubu"] = "Soğuma bitişi";
					id_strSOG = idStringHazirla(3, islem_sirasiSOG, 1, emir_sirasiSOG, süretaşimaBOS);
					IsemriNewRowSC["UniqueID"] = id_strSOG;
					IsemriTable.Rows.Add(IsemriNewRowSC);
				//	islem_sirasiSOG = islem_sirasiSOG + 1;
					emir_sirasiSOG = emir_sirasiSOG + 1;
					//Gömlek çıkar
					DataRow[] tempG = gomlek.Select(expression);
					//if ((tempG.Length > 0)&&(tempG[0]["StatusID"].ToString() !="80"))
					if (tempG.Length > 0)
					{
						//	Console.WriteLine("--" + tempG[0]["StatusID"].ToString());
					}


					if (tempG.Length > 0)
					{
						tahmini_proses_bitim.Rows[i]["Yeni"] = tempG[0]["No"].ToString();
					}
					else
						tahmini_proses_bitim.Rows[i]["Yeni"] = "-";

					IsemriNewRowGO = IsemriTable.NewRow();
					DateTime IsBasGO = IsBas.AddMinutes(Convert.ToDouble(SureTable.Rows[21]["Süre"]));

					//	IsemriNewRowGO["Zaman"] = Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"]);
					IsemriNewRowGO["Zaman"] = IsBasGO.ToString("yyyy.MM.dd HH:mm:ss");  // IsBas.AddMinutes(Convert.ToDouble(SureTable.Rows[9]["Süre"]));

					IsemriNewRowGO["Konum1 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
					IsemriNewRowGO["Konum1 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
					IsemriNewRowGO["Konum2 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
					IsemriNewRowGO["Konum2 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();

					if (Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString()) <= 34)
					{
						IsemriNewRowGO["Atmosphere Turu"] = "HNX";
						IsemriNewRowGO["Atacman Tipi"] = "Konvektor Tasima Aparatı";
						IsemriNewRowGO["Is Süresi"] = SureTable.Rows[21]["Süre"].ToString();
						süretaşimaSOG = Convert.ToDouble(SureTable.Rows[21]["Süre"]);
						IsemriNewRowGO["IntZaman"] = zamfark + Convert.ToInt16(süretaşimaSOG);
						zamfark = zamfark + Convert.ToInt16(süretaşimaSOG);
					}
					else
					{
						IsemriNewRowGO["Atmosphere Turu"] = "H2";
						IsemriNewRowGO["Atacman Tipi"] = "Konvektor Tasima Aparatı";
						IsemriNewRowGO["Is Süresi"] = SureTable.Rows[9]["Süre"].ToString();
						süretaşimaSOG = Convert.ToDouble(SureTable.Rows[9]["Süre"]);
						IsemriNewRowGO["IntZaman"] = zamfark + Convert.ToInt16(süretaşimaSOG);
						zamfark = zamfark + Convert.ToInt16(süretaşimaSOG);
					}

					IsemriNewRowGO["Yapilacakis"] = "Gömleği çıkart";// temp[0]["No"].ToString()+ temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
					IsemriNewRowGO["Yapilacakisgrubu"] = "Soğuma bitişi";
					id_strSOG = idStringHazirla(3, islem_sirasiSOG, 1, emir_sirasiSOG, süretaşimaSOG);
					IsemriNewRowGO["UniqueID"] = id_strSOG;
					IsemriTable.Rows.Add(IsemriNewRowGO);
					islem_sirasiSOG = islem_sirasiSOG + 1;
					emir_sirasiSOG = emir_sirasiSOG + 1;

					//Bobinleri cs ye taşı

					bobinsayisi = kaidebobin;
					int BobinNO = Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString());
					bobinsayisi.DefaultView.RowFilter = String.Format("ProgramNumber  = '{0}'", BobinNO);
					bobinsayisi.DefaultView.RowFilter = $"ProgramNumber  = '{BobinNO}'";
					//			Console.WriteLine("bobin sayisısısıs" + bobinsayisi.DefaultView.Count);
					DateTime IsBasBOB;
					if (Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString()) <= 34)
					{
						IsBasBOB = IsBasGO.AddMinutes(Convert.ToDouble(SureTable.Rows[21]["Süre"]));
					}
					else
					{
						IsBasBOB = IsBasGO.AddMinutes(Convert.ToDouble(SureTable.Rows[21]["Süre"]));
					}
					for (int j = 0; j < bobinsayisi.DefaultView.Count; j++)
					{
						IsemriNewRowBEM = IsemriTable.NewRow();
						Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"]);
						//tahmini_proses_bitim.Rows[i]["ProcessEnd"].ToString()
						IsemriNewRowBEM["Zaman"] = IsBasBOB.ToString("yyyy.MM.dd HH:mm:ss"); ;// Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"]);

						IsemriNewRowBEM["Konum1 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
						IsemriNewRowBEM["Konum1 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
						IsemriNewRowBEM["Konum2 -Kolon"] = "22";
						IsemriNewRowBEM["Konum2 -Kaide"] = "22";
						//IsemriNewRowBEM["Konum2 -Kolon"] = "22 Cebir Soğutma";
						//IsemriNewRowBEM["Konum2 -Kaide"] = "22 Cebir Soğutma";

						if (Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString()) <= 34)
						{
							IsemriNewRowBEM["Atmosphere Turu"] = "HNX";
							IsemriNewRowBEM["Atacman Tipi"] = "Bobin Aparatı";
							IsemriNewRowBEM["Is Süresi"] = SureTable.Rows[22]["Süre"].ToString();
							süretaşimaBOB = Convert.ToDouble(SureTable.Rows[22]["Süre"]);
							IsBasBOB = IsBasBOB.AddMinutes(Convert.ToDouble(SureTable.Rows[22]["Süre"]));
							IsemriNewRowBEM["IntZaman"] = zamfark + Convert.ToInt16(süretaşimaBOB);
							zamfark = zamfark + Convert.ToInt16(süretaşimaBOB);
						}
						else
						{
							IsemriNewRowBEM["Atmosphere Turu"] = "H2";
							IsemriNewRowBEM["Atacman Tipi"] = "Bobin Aparatı";
							IsemriNewRowBEM["Is Süresi"] = SureTable.Rows[10]["Süre"].ToString();
							süretaşimaBOB = Convert.ToDouble(SureTable.Rows[10]["Süre"]);
							IsBasBOB = IsBasBOB.AddMinutes(Convert.ToDouble(SureTable.Rows[10]["Süre"]));
							IsemriNewRowBEM["IntZaman"] = zamfark + Convert.ToInt16(süretaşimaBOB);
							zamfark = zamfark + Convert.ToInt16(süretaşimaBOB);
						}

						IsemriNewRowBEM["Yapilacakis"] = "Bobin taşı";// temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
						IsemriNewRowBEM["Yapilacakisgrubu"] = "Kaide boşalt";
						id_strBOB = idStringHazirla(4, islem_sirasiBOS, 1, emir_sirasiBOS, süretaşimaBOB);
						IsemriNewRowBEM["UniqueID"] = id_strBOB;
						IsemriTable.Rows.Add(IsemriNewRowBEM);

						emir_sirasiBOS = emir_sirasiBOS + 1;
					//	islem_sirasiBOS = islem_sirasiBOS + 1;

					}
					islem_sirasiBOS = islem_sirasiBOS + 1;




				}

				else if (isSTATE == "200") // Tav bitti
				{
					//					Console.WriteLine("State 200 BASE NUM :" + tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString() + "   TAV bitti");
					string expression = "BaseNumber = " + tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
					DataRow[] tempF = firin.Select(expression);
					//if ((temp.Length > 0)&&(temp[0]["StatusID"].ToString() !="80"))
					if (tempF.Length > 0)
					{
						//		Console.WriteLine("--" + tempF[0]["No"].ToString());
					}
					if (tempF.Length > 0)
					{
						tahmini_proses_bitim.Rows[i]["Yeni"] = tempF[0]["No"].ToString();
					}
					else
						tahmini_proses_bitim.Rows[i]["Yeni"] = "-";



					//firini çikar
					//DataRow[] tempG = gomlek.Select(expression);
					//if ((tempG.Length > 0)&&(tempG[0]["StatusID"].ToString() !="80"))
					//if (tempG.Length > 0)
					//{
					//	Console.WriteLine("--" + tempG[0]["StatusID"].ToString());
					//}
					DateTime IsTav = Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"]);
					int zamfark = 0;
					IsemriNewRowTAV = IsemriTable.NewRow();


					if (IsTav.ToString() == "1.01.1900 00:00:00")
					{

						IsemriNewRowTAV["IntZaman"] = 0;
					}
					else
					{
						TimeSpan ZamanFark = IsTav - DateTime.Now;
						zamfark = Convert.ToInt32(ZamanFark.TotalMinutes);
						IsemriNewRowTAV["IntZaman"] = zamfark;
					}
					Console.WriteLine(IsemriNewRowTAV["IntZaman"]);







					IsemriNewRowTAV["Zaman"] = IsTav.ToString("yyyy.MM.dd HH:mm:ss");

					IsemriNewRowTAV["Konum1 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
					IsemriNewRowTAV["Konum1 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
					IsemriNewRowTAV["Konum2 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
					IsemriNewRowTAV["Konum2 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();

					if (Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString()) <= 34)
					{
						IsemriNewRowTAV["Atmosphere Turu"] = "HNX";
						IsemriNewRowTAV["Atacman Tipi"] = "YOK";
						IsemriNewRowTAV["Is Süresi"] = SureTable.Rows[17]["Süre"].ToString();
						süretaşimaFIR = Convert.ToDouble(SureTable.Rows[17]["Süre"]);
						IsemriNewRowTAV["IntZaman"] = zamfark + süretaşimaFIR;
					}
					else
					{
						IsemriNewRowTAV["Atmosphere Turu"] = "H2";
						IsemriNewRowTAV["Atacman Tipi"] = "YOK";
						IsemriNewRowTAV["Is Süresi"] = SureTable.Rows[5]["Süre"].ToString();
						süretaşimaFIR = Convert.ToDouble(SureTable.Rows[5]["Süre"]);
						IsemriNewRowTAV["IntZaman"] = zamfark + süretaşimaFIR;
					}

					IsemriNewRowTAV["Yapilacakis"] = tahmini_proses_bitim.Rows[i]["PlugNumber"].ToString() + " Nolu Fırın çıkart";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
					IsemriNewRowTAV["Yapilacakisgrubu"] = "TAV bitişi";
					id_strTAV = idStringHazirla(2, islem_sirasiTAV, 1, emir_sirasiTAV, süretaşimaFIR);
					IsemriNewRowTAV["UniqueID"] = id_strTAV;
					IsemriTable.Rows.Add(IsemriNewRowTAV);

					emir_sirasiTAV = emir_sirasiTAV + 1;
					//UygunSoCa ile uygun soğutma çanı bul
					//if BaseNumber 1-34 ise HNX UygunSoCaHNX
					//   BaseNumber 61-90 ise H2 UygunSoCaH2 çağırılır
					DataTable UygunSOCAH2 = UygunSoCaH2(sogutmacani);
					DataTable UygunSOCAHNX = UygunSoCaHNX(sogutmacani);



					if (Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString()) <= 34)
					{
						int Alternatif = 1;
						süretaşimaSOCA = Convert.ToDouble(SureTable.Rows[19]["Süre"]);
						for (int k = 0; k < UygunSOCAHNX.DefaultView.Count; k++)
						{
							IsemriNewRowSoCaHNX = IsemriTable.NewRow();
							//Console.WriteLine("---SOCAYER---" + SonucArray[Convert.ToInt32(UygunSOCAHNX.Rows[k]["BaseNumber"].ToString())]);
							IsemriNewRowSoCaHNX["Zaman"] = Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"].ToString()).ToString("yyyy.MM.dd HH:mm:ss");
							IsemriNewRowSoCaHNX["IntZaman"] = zamfark + süretaşimaSOCA;
							IsemriNewRowSoCaHNX["Konum1 -Kolon"] = SonucArray[Convert.ToInt32(UygunSOCAHNX.Rows[k]["BaseNumber"].ToString())];
							IsemriNewRowSoCaHNX["Konum1 -Kaide"] = UygunSOCAHNX.Rows[k]["BaseNumber"].ToString();
							IsemriNewRowSoCaHNX["Konum2 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
							IsemriNewRowSoCaHNX["Konum2 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
							IsemriNewRowSoCaHNX["Atmosphere Turu"] = "H2";
							IsemriNewRowSoCaHNX["Atacman Tipi"] = "Konvektor Tasima Aparatı";
							IsemriNewRowSoCaHNX["Is Süresi"] = SureTable.Rows[7]["Süre"].ToString();
							süretaşimaSOCA = Convert.ToDouble(SureTable.Rows[7]["Süre"]);
							IsemriNewRowSoCaHNX["Yapilacakis"] = UygunSOCAHNX.Rows[k]["BaseNumber"].ToString() + " Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							IsemriNewRowSoCaHNX["Yapilacakisgrubu"] = "TAV bitişi";
							id_strTAV = idStringHazirla(2, islem_sirasiTAV, Alternatif, emir_sirasiTAV, süretaşimaSOCA);
							IsemriNewRowSoCaHNX["UniqueID"] = id_strTAV;
							IsemriTable.Rows.Add(IsemriNewRowSoCaHNX);
							Alternatif = Alternatif + 1;




						}
					}
					else
					{
						int AlternatifH2 = 1;
						süretaşimaSOCA = Convert.ToDouble(SureTable.Rows[7]["Süre"]);
						for (int k = 0; k < UygunSOCAH2.DefaultView.Count; k++)
						{
							IsemriNewRowSoCaH2 = IsemriTable.NewRow();

							IsemriNewRowSoCaH2["Zaman"] = Convert.ToDateTime(tahmini_proses_bitim.Rows[i]["ProcessEnd"].ToString()).ToString("yyyy.MM.dd HH:mm:ss");
							IsemriNewRowSoCaH2["IntZaman"] = zamfark + süretaşimaSOCA;
							IsemriNewRowSoCaH2["Konum1 -Kolon"] = SonucArray[Convert.ToInt32(UygunSOCAH2.Rows[k]["BaseNumber"].ToString())];
							IsemriNewRowSoCaH2["Konum1 -Kaide"] = UygunSOCAH2.Rows[k]["BaseNumber"].ToString();
							IsemriNewRowSoCaH2["Konum2 -Kolon"] = SonucArray[Convert.ToInt32(tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString())];
							IsemriNewRowSoCaH2["Konum2 -Kaide"] = tahmini_proses_bitim.Rows[i]["BaseNumber"].ToString();
							IsemriNewRowSoCaH2["Atmosphere Turu"] = "H2";
							IsemriNewRowSoCaH2["Atacman Tipi"] = "YOK";
							IsemriNewRowSoCaH2["Is Süresi"] = SureTable.Rows[7]["Süre"].ToString();
							süretaşimaSOCA = Convert.ToDouble(SureTable.Rows[7]["Süre"]);
							IsemriNewRowSoCaH2["Yapilacakis"] = UygunSOCAH2.Rows[k]["BaseNumber"].ToString() + " Nolu Soğutma Çanı tak";// tempF[0]["No"].ToString() + temp[0]["No"].ToString()  can numarasını yaz kaide numarasını yazdır
							IsemriNewRowSoCaH2["Yapilacakisgrubu"] = "TAV bitişi";
							id_strTAV = idStringHazirla(2, islem_sirasiTAV, AlternatifH2, emir_sirasiTAV, süretaşimaSOCA);
							IsemriNewRowSoCaH2["UniqueID"] = id_strTAV;
							IsemriTable.Rows.Add(IsemriNewRowSoCaH2);
							AlternatifH2 = AlternatifH2 + 1;

						}
					}
					islem_sirasiTAV = islem_sirasiTAV + 1;






				}

			}


			DateTime currentTime = DateTime.Now;
			DateTime x30MinsLater = currentTime.AddMinutes(120);
			DataTable topRows = IsemriTable;

			topRows.DefaultView.RowFilter = "'Zaman' < '" + x30MinsLater.ToString("yyyy.MM.dd HH:mm:ss") + "'";


			topRows = topRows.DefaultView.ToTable();

			DateTime IsZaman = DateTime.Now;
			int[] V1K1K2 = new int[3];
			int[] V2K1K2 = new int[3];
			DataTable VincHareket = new DataTable();


			String[] yapilanisler = new String[0];
			detay detaydummy = new detay();
			IsemriTable.Columns.Add("Maliyet", typeof(double));
			double parameter1 = 2;
			double parameter3 = 0.5;
			string input;
			string oncelik;
			string sure;
			int x;
			int y;
			for (int i = 0; i < IsemriTable.Rows.Count; i++)
			{
				input = Convert.ToString(IsemriTable.Rows[i]["UniqueID"]);
				oncelik = input.Substring(0, 1);
				sure = input.Substring(9, 2);
				x = Int32.Parse(sure);
				y = Int32.Parse(oncelik);
				IsemriTable.Rows[i]["Maliyet"] = parameter1 * x + parameter3 * y;


			}
			//IsemriTable.DefaultView.Sort = "Konum1 -Kolon";
			//IsemriTable = IsemriTable.DefaultView.ToTable();



			//IsemriTableG -> Kolon ekle discrete zmaan gore musait olacaklari t'leri yaz.
			//prınt IsemriTableG oncekı prıntlerın hepsını sılelım!
			//ID, zaman 1900-> t=0, diyelim aug 18: 12:03, aug 18: 12:03->t=0, aug 18: 12:23 -> t=20
			//dakikaya bagli dinamik aralikt=2dk aug 18: 12:23 -> t=10

			/*
			double yapilanistoplami = RecursiveFun(0, yapilanisler, false, false, 1, 26, detaydummy, detaydummy, IsemriTable);
			*/



			//------------------------
			Console.WriteLine("algoritma bitti-" + DateTime.Now.ToString());
			//IsemriTable.DefaultView.RowFilter = "Zaman > '1.01.1900 00:00:00'";
			//IsemriTable = IsemriTable.DefaultView.ToTable();
/*
			foreach (DataRow dr in IsemriTableG.Rows)
			{
				Console.WriteLine("1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} \t 7 : {6} \t 8 : {7}\t 9 : {8} \t 10 : {9} \t 11 : {10}\t 12 : {11}\t 13(Maliyet) : {12}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12]);
			}
*/


			Console.WriteLine("---------------------------------------------------------------");

			foreach (DataRow dr in IsemriTable.Rows)
			{
				Console.WriteLine("1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} \t 7 : {6} \t 8 : {7}\t 9 : {8} \t 10 : {9} \t 11 : {10}\t 12 : {11}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11]);
			}
			Console.WriteLine("---------------------------------------------------------------");
			//var topRows = IsemriTable.AsEnumerable().Take(5).ToList();
			Console.WriteLine("current time" + currentTime);
			foreach (DataRow dr in topRows.Rows)
			{
				Console.WriteLine("liste eleman/1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} \t 7 : {6} \t 8 : {7}\t 9 : {8} \t 10 : {9} \t 11 : {10}\t 12 : {11}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11]);
			}

			foreach (DataRow dr in SureTable.Rows)
			{
				//		Console.WriteLine("1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} \t 7 : {6} \t", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
			}
			Console.WriteLine("---------------------------------------------------------------");
			foreach (DataRow dr in AtacmanTable.Rows)
			{
				//		Console.WriteLine("1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t", dr[0], dr[1], dr[2], dr[3]);
			}
			Console.WriteLine("---------------------------------------------------------------");
			foreach (DataRow dr in AnnealingEqu.Rows)
			{
				//		Console.WriteLine("1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t", dr[0], dr[1], dr[2], dr[3]);
			}
