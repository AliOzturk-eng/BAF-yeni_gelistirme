static DataTable GetSSTable(string FilePath)
		{

			Excel.Application xlApp = new Excel.Application();
			DataRow myNewRow;
			DataTable myTable;
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FilePath);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets["Standart Süreler"];
			Excel.Range range = xlWorkSheet.UsedRange;

			int rows = range.Rows.Count;
			int cols = range.Columns.Count;

			myTable = new DataTable("MyDataTable");
			myTable.Columns.Add("İş Emri", typeof(string));
			myTable.Columns.Add("Atmosphere Type", typeof(string));
			myTable.Columns.Add("Başlangıç nok", typeof(string));
			myTable.Columns.Add("Bitiş nok", typeof(string));
			myTable.Columns.Add("Ekipman", typeof(string));
			myTable.Columns.Add("Süre", typeof(string));
			myTable.Columns.Add("Ataçman türü", typeof(string));

			for (int i = 2; i <= rows - 1; i++)
			{
				myNewRow = myTable.NewRow();
				myNewRow["İş Emri"] = range.Cells[i, 1].Value2.ToString();
				myNewRow["Atmosphere Type"] = range.Cells[i, 2].Value2.ToString();
				myNewRow["Başlangıç nok"] = range.Cells[i, 3].Value2.ToString();
				myNewRow["Bitiş nok"] = range.Cells[i, 4].Value2.ToString();
				myNewRow["Ekipman"] = range.Cells[i, 5].Value2.ToString();
				//myNewRow["Süre"] = Convert.ToDouble(range.Cells[i, 5].Value2.ToString());
				myNewRow["Süre"] = range.Cells[i, 6].Value2.ToString();
				myNewRow["Ataçman türü"] = range.Cells[i, 7].Value2.ToString();
				myTable.Rows.Add(myNewRow);
			}

			//myNewRow["Süre"] = Convert.ToDouble(range.Cells[i, 5].Value2.ToString());

			return myTable;
		}

		static DataTable GetAATable(string FilePath)
		{

			Excel.Application xlApp = new Excel.Application();
			DataRow myNewRow;
			DataTable myTable;
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FilePath);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets["Ataçman Kanca"];
			Excel.Range range = xlWorkSheet.UsedRange;

			//int rows = range.Rows.Count;
			//int cols = range.Columns.Count;

			myTable = new DataTable("MyDataTable");
			myTable.Columns.Add("Atmosphere Type", typeof(string));
			myTable.Columns.Add("Ekipman", typeof(string));
			myTable.Columns.Add("Ataçman Türü", typeof(string));
			myTable.Columns.Add("Kanca Türü", typeof(string));


			for (int i = 2; i <= 11; i++)
			{
				myNewRow = myTable.NewRow();
				myNewRow["Atmosphere Type"] = range.Cells[i, 1].Value2.ToString();
				myNewRow["Ekipman"] = range.Cells[i, 2].Value2.ToString();
				myNewRow["Ataçman Türü"] = range.Cells[i, 3].Value2.ToString();
				myNewRow["Kanca Türü"] = range.Cells[i, 4].Value2.ToString();

				myTable.Rows.Add(myNewRow);
			}

			//myNewRow["Süre"] = Convert.ToDouble(range.Cells[i, 5].Value2.ToString());

			return myTable;
		}

		static DataTable GetGAETable(string FilePath)
		{

			Excel.Application xlApp = new Excel.Application();
			DataRow myNewRow;
			DataTable myTable;
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FilePath);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets["GetAnnealingEquipments "];
			Excel.Range range = xlWorkSheet.UsedRange;

			//int rows = range.Rows.Count;
			//int cols = range.Columns.Count;

			myTable = new DataTable("MyDataTable");
			myTable.Columns.Add("State", typeof(string));
			myTable.Columns.Add("Description", typeof(string));
			myTable.Columns.Add("Process", typeof(string));
			myTable.Columns.Add("İşlem Sırası", typeof(string));


			for (int i = 2; i <= 17; i++)
			{
				myNewRow = myTable.NewRow();
				myNewRow["State"] = range.Cells[i, 1].Value2.ToString();
				myNewRow["Description"] = range.Cells[i, 2].Value2.ToString();
				myNewRow["Process"] = range.Cells[i, 3].Value2.ToString();
				myNewRow["İşlem Sırası"] = range.Cells[i, 4].Value2.ToString();

				myTable.Rows.Add(myNewRow);
			}

			//myNewRow["Süre"] = Convert.ToDouble(range.Cells[i, 5].Value2.ToString());

			return myTable;
		}
		static string[] ReadExcelFile(string FilePath)
		{


			Excel.Application xlApp = new Excel.Application();
			//xlWorkBook = xlApp.Workbooks.Open(excelData);
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(FilePath);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets["Kaide Kolon eşleşmesi"];
			Excel.Range range = xlWorkSheet.Range["G1", "G91"];
			//xlWorkSheet = xlWorkBook.Sheets["Kaide Kolon eşlemesi"];

			string[] KaiKol = new string[range.Rows.Count + 1];
			//	Console.WriteLine(range.Rows.Count);
			for (int i = 0; i < range.Rows.Count; i++)
			{
				KaiKol[i] = xlWorkSheet.Cells[i + 1, 7].Value2.ToString();
				//		Console.WriteLine(KaiKol[i]+"--"+i);
			}
			string[] SonEs = new string[range.Rows.Count];

			for (int i = 0; i < range.Rows.Count; i++)
			{
				SonEs[i] = KaiKol[i];
			}
			//Console.WriteLine(KaiKol[0]);
			//xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(4);
			//	int[] KaiKol = new int[sHeet[4] de e kolondanki data uzunluğunda];
			// Sheet[2] kolon A-F raw 1-29 arasını datatable yap

			return SonEs;
		}

		[STAThread]

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
		static DataTable UygunSoCaHNX(DataTable dt)
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
		static DataTable DTInuseSoCa(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '0'";
			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//	Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"] );
			}


			return dt;

		}
		static DataTable DTInuseGomlek(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '0'";

			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//	Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static DataTable DTInuseFirin(DataTable dt)
		{
			dt.DefaultView.RowFilter = "IsIdled = '0'";

			dt = dt.DefaultView.ToTable();
			//	Console.WriteLine("INUSE SC");
			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//		Console.WriteLine(dt.Rows[j]["No"].ToString() + " -*- " + dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["AtmosphereType"]);
			}


			return dt;

		}
		static void KolonIsimleri(DataTable dt)
		{



			for (int i = 0; i < dt.Columns.Count; i++)
			{
				//	Console.WriteLine(dt.Columns[i]);
			}

			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//		   Console.WriteLine(dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["PlugNumber"].ToString() + " -*- " + dt.Rows[j]["ProgramNumber"].ToString() + " -*- " + dt.Rows[j]["State"].ToString() + " -*- " + dt.Rows[j]["Process"].ToString());
			}

		}
		static void KolonIsimleri2(DataTable dt)
		{



			for (int i = 0; i < dt.Columns.Count; i++)
			{
				//	Console.WriteLine(dt.Columns[i]);
			}

			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//		Console.WriteLine(dt.Rows[j]["BatchNumber"].ToString() + " -*- " + dt.Rows[j]["Status"].ToString() + " -*- " + dt.Rows[j]["ProgramNumber"].ToString() + " -*- " + dt.Rows[j]["BatchOrder"].ToString() + " -*- " + dt.Rows[j]["A510_B"].ToString());
			}

		}
		static DataTable ProsesSira(DataTable dt)
		{
			//	DataRow row;
			//	row = dt.NewRow();

			//string Text = dt.Rows[1]["PlugNumber"].ToString();
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				//	Console.WriteLine(dt.Columns[i]);
			}
			//string Text = dt.Rows[0]["No"].ToString();
			//string Text2 = dt.Rows[20]["No"].ToString();

			//Console.WriteLine(Text);
			//Console.WriteLine(Text2);
			//Console.WriteLine(dt.Rows.Count);
			//string Text3 = dt.Rows[dt.Rows.Count-1]["No"].ToString();
			dt.DefaultView.RowFilter = "ProcessEnd >= '1.01.1900 00:00:00'";
			dt = dt.DefaultView.ToTable();
			dt.DefaultView.Sort = "ProcessEnd";
			dt = dt.DefaultView.ToTable();

			for (int j = 0; j < dt.Rows.Count; j++)
			{
				//    Console.WriteLine(dt.Rows[j]["BaseNumber"].ToString() + " -*- " + dt.Rows[j]["PlugNumber"].ToString() + " -*- " + dt.Rows[j]["ProgramNumber"].ToString()+ " -*- " + dt.Rows[j]["State"].ToString() + " -*- " + dt.Rows[j]["Process"].ToString() + " -*- " + dt.Rows[j]["ProcessEnd"].ToString());
			}



			return dt;

		}
		public static string idStringHazirla(int oncelik, int islem_sira, int alternatif, int emirSira, double sure)
		{
			return oncelik + (islem_sira % 1000).ToString("D3") + alternatif.ToString("D2") + emirSira.ToString("D2") + ((int)(sure * 10)).ToString("D3");
		}


		static DataTable LoadingBobin(DataTable boskaide, DataTable bosfirin, DataTable bosgomlek, int ProgramNo, string Transpalan, int bobinsayisi, int vinc1kolon, int vinc2kolon, string[] KolonKonum, DataTable SURE)
		{
			//DataTable dt = new DataTable();
			DataRow YuklemeIsEmriH2;
			DataRow YuklemeIsEmriH2Firin;
			DataRow YuklemeIsEmriH2Gomlek;
			DataRow YuklemeIsEmriHNX;
			DataRow YuklemeIsEmriHNXFirin;
			DataRow YuklemeIsEmriHNXGomlek;

			DataTable YuklemeIsEmri = new DataTable();

			//Console.WriteLine("ID_STR: " + id_str);
			//YuklemeIsEmriH2 = YuklemeIsEmri.NewRow();
			//YuklemeIsEmriH2Firin = YuklemeIsEmri.NewRow();
			//YuklemeIsEmriH2Gomlek = YuklemeIsEmri.NewRow();
			YuklemeIsEmriHNX = YuklemeIsEmri.NewRow();
			YuklemeIsEmriHNXFirin = YuklemeIsEmri.NewRow();
			YuklemeIsEmriHNXGomlek = YuklemeIsEmri.NewRow();
			YuklemeIsEmri.Columns.Add("UniqueID", typeof(string));
			YuklemeIsEmri.Columns.Add("Zaman", typeof(string));
			YuklemeIsEmri.Columns.Add("Konum1 -Kolon", typeof(string));
			YuklemeIsEmri.Columns.Add("Konum1 -Kaide", typeof(string));
			YuklemeIsEmri.Columns.Add("Konum2 -Kolon", typeof(string));
			YuklemeIsEmri.Columns.Add("Konum2 -Kaide", typeof(string));
			YuklemeIsEmri.Columns.Add("Atacman Tipi", typeof(string));
			YuklemeIsEmri.Columns.Add("Is Süresi", typeof(string));
			YuklemeIsEmri.Columns.Add("Atmosphere Turu", typeof(string));
			YuklemeIsEmri.Columns.Add("Yapilacakis", typeof(string));
			YuklemeIsEmri.Columns.Add("Yapilacakisgrubu", typeof(string));


			if (ProgramNo >= 160)
			{
				DataTable KaideH2 = UygunKaideH2(boskaide);
				DataTable FirinH2 = UygunFirinH2(bosfirin);
				DataTable GomlekH2 = UygunIcGomlekH2(bosgomlek);
				Console.WriteLine("uygunkaide" + KaideH2.Rows.Count);
				Console.WriteLine("uygunkaide" + KaideH2.DefaultView.Count);
				Console.WriteLine("uygunfirinh2" + FirinH2.Rows.Count);
				Console.WriteLine("uygungomlek" + GomlekH2.Rows.Count);
				//int islem_sirasiH2 = 1;

				//KaideH2.Rows[i]["No"].ToString();
				//SonucArray[Convert.ToInt32(KaideH2.Rows[i]["No"].ToString())];
				//KaideH2.DefaultView.Count;
				for (int i = 0; i < KaideH2.Rows.Count; i++)
				{
					//					Console.WriteLine("boş h2 kaide colon: " + KolonKonum[Convert.ToInt32(KaideH2.Rows[i]["No"].ToString())]+"--- Kaide No:"+ Convert.ToInt32(KaideH2.Rows[i]["No"].ToString()));
					int emir_sirasiH2 = 1;
					int islem_sirasiH2 = 1;
					double süretaşimaBob = Convert.ToDouble(SURE.Rows[0]["Süre"]);
					for (int j = 0; j < bobinsayisi; j++)
					{


						//						Console.WriteLine("Calısıyor" + id_str);
						YuklemeIsEmriH2 = YuklemeIsEmri.NewRow();

						YuklemeIsEmriH2["Zaman"] = DateTime.Now;
						if (Transpalan == "RCM")
						{
							YuklemeIsEmriH2["Konum1 -Kolon"] = 3;
							YuklemeIsEmriH2["Konum1 -Kaide"] = 3;
						}
						else
						{
							YuklemeIsEmriH2["Konum1 -Kolon"] = 15;
							YuklemeIsEmriH2["Konum1 -Kaide"] = 15;
						}
						YuklemeIsEmriH2["Konum2 -Kolon"] = KolonKonum[Convert.ToInt32(KaideH2.Rows[i]["No"].ToString())];
						YuklemeIsEmriH2["Konum2 -Kaide"] = Convert.ToInt32(KaideH2.Rows[i]["No"].ToString());
						YuklemeIsEmriH2["Atacman Tipi"] = "Bobin Aparatı";
						YuklemeIsEmriH2["Is Süresi"] = SURE.Rows[0]["Süre"].ToString();
						YuklemeIsEmriH2["Atmosphere Turu"] = "H2";
						YuklemeIsEmriH2["Yapilacakis"] = "BobinYukleme";
						YuklemeIsEmriH2["Yapilacakisgrubu"] = "KaideYukleme";

						string id_H2_BOB = idStringHazirla(1, islem_sirasiH2, i, emir_sirasiH2, süretaşimaBob);
						YuklemeIsEmriH2["UniqueID"] = id_H2_BOB;
						Console.WriteLine("yuklemeisemrih2" + id_H2_BOB);
						YuklemeIsEmri.Rows.Add(YuklemeIsEmriH2);
						islem_sirasiH2 = islem_sirasiH2 + 1;

					}


					double süretaşimaGom = Convert.ToDouble(SURE.Rows[2]["Süre"]);
					for (int k = 0; k < GomlekH2.DefaultView.Count; k++)
					{
						//						Console.WriteLine("boş h2 gömlek colon: " + KolonKonum[Convert.ToInt32(GomlekH2.Rows[k]["BaseNumber"].ToString())] + "--- Kaide No:" + Convert.ToInt32(GomlekH2.Rows[k]["BaseNumber"].ToString()));
						YuklemeIsEmriH2Gomlek = YuklemeIsEmri.NewRow();

						YuklemeIsEmriH2Gomlek["Zaman"] = DateTime.Now;
						YuklemeIsEmriH2Gomlek["Konum1 -Kolon"] = KolonKonum[Convert.ToInt32(GomlekH2.Rows[k]["No"].ToString())];
						YuklemeIsEmriH2Gomlek["Konum1 -Kaide"] = Convert.ToInt32(GomlekH2.Rows[k]["No"].ToString());
						YuklemeIsEmriH2Gomlek["Konum2 -Kolon"] = KolonKonum[Convert.ToInt32(KaideH2.Rows[i]["No"].ToString())];
						YuklemeIsEmriH2Gomlek["Konum2 -Kaide"] = Convert.ToInt32(KaideH2.Rows[i]["No"].ToString());
						YuklemeIsEmriH2Gomlek["Atacman Tipi"] = "Konvektör Taşıma aparatı";
						YuklemeIsEmriH2Gomlek["Is Süresi"] = SURE.Rows[2]["Süre"].ToString();
						YuklemeIsEmriH2Gomlek["Atmosphere Turu"] = "H2";
						YuklemeIsEmriH2Gomlek["Yapilacakis"] = "GömlekYukleme";
						YuklemeIsEmriH2Gomlek["Yapilacakisgrubu"] = "KaideYukleme";
						string id_H2_Gom = idStringHazirla(1, islem_sirasiH2, i, emir_sirasiH2, süretaşimaGom);
						YuklemeIsEmriH2Gomlek["UniqueID"] = id_H2_Gom;
						Console.WriteLine("yuklemeisemriGomlekh2" + id_H2_Gom);
						YuklemeIsEmri.Rows.Add(YuklemeIsEmriH2Gomlek);
					}

					islem_sirasiH2 = islem_sirasiH2 + 1;
					double süretaşimaFirin = Convert.ToDouble(SURE.Rows[4]["Süre"]);
					for (int j = 0; j < FirinH2.DefaultView.Count; j++)
					{
						//						Console.WriteLine("boş h2 firin colon: " + KolonKonum[Convert.ToInt32(FirinH2.Rows[j]["BaseNumber"].ToString())] + "--- Kaide No:" + Convert.ToInt32(FirinH2.Rows[j]["BaseNumber"].ToString()));
						YuklemeIsEmriH2Firin = YuklemeIsEmri.NewRow();
						double süretaşima = Convert.ToDouble(SURE.Rows[0]["Süre"]);
						YuklemeIsEmriH2Firin["Zaman"] = DateTime.Now;
						YuklemeIsEmriH2Firin["Konum1 -Kolon"] = KolonKonum[Convert.ToInt32(FirinH2.Rows[j]["No"].ToString())];
						YuklemeIsEmriH2Firin["Konum1 -Kaide"] = Convert.ToInt32(FirinH2.Rows[j]["No"].ToString());
						YuklemeIsEmriH2Firin["Konum2 -Kolon"] = KolonKonum[Convert.ToInt32(KaideH2.Rows[i]["No"].ToString())];
						YuklemeIsEmriH2Firin["Konum2 -Kaide"] = Convert.ToInt32(KaideH2.Rows[i]["No"].ToString());
						YuklemeIsEmriH2Firin["Atacman Tipi"] = "YOK";
						YuklemeIsEmriH2Firin["Is Süresi"] = SURE.Rows[4]["Süre"].ToString();
						YuklemeIsEmriH2Firin["Atmosphere Turu"] = "H2";
						YuklemeIsEmriH2Firin["Yapilacakis"] = "FirinYukleme";
						YuklemeIsEmriH2Firin["Yapilacakisgrubu"] = "KaideYukleme";
						string id_H2_Firin = idStringHazirla(1, islem_sirasiH2, j + 1, emir_sirasiH2, süretaşimaFirin);
						YuklemeIsEmriH2Firin["UniqueID"] = id_H2_Firin;
						Console.WriteLine("yuklemeisemriFirinh2" + id_H2_Firin);
						YuklemeIsEmri.Rows.Add(YuklemeIsEmriH2Firin);

					}
					islem_sirasiH2 = islem_sirasiH2 + 1;

				}


				//FirinH2.Rows[i]["BaseNumber"].ToString();
				//KolonKonum[Convert.ToInt32(FirinH2.Rows[i]["BaseNumber"].ToString())];
				//GomlekH2.Rows[i]["BaseNumber"].ToString();
				//KolonKonum[Convert.ToInt32(GomlekH2.Rows[i]["BaseNumber"].ToString())];

			}
			else
			{
				DataTable KaideHNX = UygunKaideHNX(boskaide);
				DataTable FirinHNX = UygunFirinHNX(bosfirin);
				DataTable GomlekHNX = UygunIcGomlekHNX(bosgomlek);
				Console.WriteLine("uygunkaide" + KaideHNX.Rows.Count);
				Console.WriteLine("uygunkaide" + KaideHNX.DefaultView.Count);
				Console.WriteLine("uygunfirinhnx" + FirinHNX.Rows.Count);
				Console.WriteLine("uygungomlekhnx" + GomlekHNX.Rows.Count);
				for (int i = 0; i < KaideHNX.Rows.Count; i++)
				{
					//					Console.WriteLine("boş h2 kaide colon: " + KolonKonum[Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString())] + "--- Kaide No:" + Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString()));
					int islem_sirasiHNX = 1;
					int emir_sirasiHNX = 1;
					for (int j = 0; j <= bobinsayisi; j++)
					{
						double süretaşimaHNXBob = Convert.ToDouble(SURE.Rows[12]["Süre"]);
						//						Console.WriteLine("Calısıyor" + id_str);
						YuklemeIsEmriHNX = YuklemeIsEmri.NewRow();
						YuklemeIsEmriHNX["Zaman"] = DateTime.Now;
						if (Transpalan == "RCM")
						{
							YuklemeIsEmriHNX["Konum1 -Kolon"] = 3;
							YuklemeIsEmriHNX["Konum1 -Kaide"] = 3;
						}
						else
						{
							YuklemeIsEmriHNX["Konum1 -Kolon"] = 15;
							YuklemeIsEmriHNX["Konum1 -Kaide"] = 15;
						}
						YuklemeIsEmriHNX["Konum2 -Kolon"] = KolonKonum[Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString())];
						YuklemeIsEmriHNX["Konum2 -Kaide"] = Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString());
						YuklemeIsEmriHNX["Atacman Tipi"] = "Bobin Aparatı";
						YuklemeIsEmriHNX["Is Süresi"] = SURE.Rows[0]["Süre"].ToString();
						YuklemeIsEmriHNX["Atmosphere Turu"] = "H2";
						YuklemeIsEmriHNX["Yapilacakis"] = "BobinYukleme";
						YuklemeIsEmriHNX["Yapilacakisgrubu"] = "KaideYukleme";
						string id_HNX_BOB = idStringHazirla(1, islem_sirasiHNX, i, emir_sirasiHNX, süretaşimaHNXBob);
						YuklemeIsEmriHNX["UniqueID"] = id_HNX_BOB;
						YuklemeIsEmri.Rows.Add(YuklemeIsEmriHNX);
						islem_sirasiHNX = islem_sirasiHNX + 1;
					}
					double süretaşimaHNXGom = Convert.ToDouble(SURE.Rows[12]["Süre"]);
					for (int k = 0; k < GomlekHNX.DefaultView.Count; k++)
					{
						//						Console.WriteLine("boş HNX gömlek colon: " + KolonKonum[Convert.ToInt32(GomlekHNX.Rows[k]["BaseNumber"].ToString())] + "--- Kaide No:" + Convert.ToInt32(GomlekHNX.Rows[k]["BaseNumber"].ToString()));

						YuklemeIsEmriHNXGomlek = YuklemeIsEmri.NewRow();
						YuklemeIsEmriHNXGomlek["Zaman"] = DateTime.Now;
						YuklemeIsEmriHNXGomlek["Konum1 -Kolon"] = KolonKonum[Convert.ToInt32(GomlekHNX.Rows[k]["No"].ToString())];
						YuklemeIsEmriHNXGomlek["Konum1 -Kaide"] = Convert.ToInt32(GomlekHNX.Rows[k]["No"].ToString());
						YuklemeIsEmriHNXGomlek["Konum2 -Kolon"] = KolonKonum[Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString())];
						YuklemeIsEmriHNXGomlek["Konum2 -Kaide"] = Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString());
						YuklemeIsEmriHNXGomlek["Atacman Tipi"] = "Konvektör Taşıma aparatı";
						YuklemeIsEmriHNXGomlek["Is Süresi"] = SURE.Rows[2]["Süre"].ToString();
						YuklemeIsEmriHNXGomlek["Atmosphere Turu"] = "H2";
						YuklemeIsEmriHNXGomlek["Yapilacakis"] = "GömlekYukleme";
						YuklemeIsEmriHNXGomlek["Yapilacakisgrubu"] = "KaideYukleme";
						string id_HNX_Gom = idStringHazirla(1, islem_sirasiHNX, k + 1, emir_sirasiHNX, süretaşimaHNXGom);
						YuklemeIsEmriHNX["UniqueID"] = id_HNX_Gom;
						YuklemeIsEmri.Rows.Add(YuklemeIsEmriHNXGomlek);
					}
					islem_sirasiHNX = islem_sirasiHNX + 1;
					double süretaşimaFirin = Convert.ToDouble(SURE.Rows[17]["Süre"]);
					for (int j = 0; j < FirinHNX.DefaultView.Count; j++)
					{
						//						Console.WriteLine("boş HNX firin colon: " + KolonKonum[Convert.ToInt32(FirinHNX.Rows[j]["BaseNumber"].ToString())] + "--- Kaide No:" + Convert.ToInt32(FirinHNX.Rows[j]["BaseNumber"].ToString()));
						YuklemeIsEmriHNXFirin = YuklemeIsEmri.NewRow();
						YuklemeIsEmriHNXFirin["Zaman"] = DateTime.Now;
						YuklemeIsEmriHNXFirin["Konum1 -Kolon"] = KolonKonum[Convert.ToInt32(FirinHNX.Rows[j]["No"].ToString())];
						YuklemeIsEmriHNXFirin["Konum1 -Kaide"] = Convert.ToInt32(FirinHNX.Rows[j]["No"].ToString());
						YuklemeIsEmriHNXFirin["Konum2 -Kolon"] = KolonKonum[Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString())];
						YuklemeIsEmriHNXFirin["Konum2 -Kaide"] = Convert.ToInt32(KaideHNX.Rows[i]["No"].ToString());
						YuklemeIsEmriHNXFirin["Atacman Tipi"] = "YOK";
						YuklemeIsEmriHNXFirin["Is Süresi"] = SURE.Rows[4]["Süre"].ToString();
						YuklemeIsEmriHNXFirin["Atmosphere Turu"] = "H2";
						YuklemeIsEmriHNXFirin["Yapilacakis"] = "FirinYukleme";
						YuklemeIsEmriHNXFirin["Yapilacakisgrubu"] = "KaideYukleme";
						string id_HNX_Firin = idStringHazirla(1, islem_sirasiHNX, i, emir_sirasiHNX, süretaşimaFirin);
						YuklemeIsEmriHNXFirin["UniqueID"] = id_HNX_Firin;
						YuklemeIsEmri.Rows.Add(YuklemeIsEmriHNXFirin);

					}
					islem_sirasiHNX = islem_sirasiHNX + 1;
				}


				//FirinH2.Rows[i]["BaseNumber"].ToString();
				//KolonKonum[Convert.ToInt32(FirinH2.Rows[i]["BaseNumber"].ToString())];
				//GomlekH2.Rows[i]["BaseNumber"].ToString();
				//KolonKonum[Convert.ToInt32(GomlekH2.Rows[i]["BaseNumber"].ToString())];
				//GomlekH2.Rows[i]["BaseNumber"].ToString();
				//KolonKonum[Convert.ToInt32(GomlekH2.Rows[i]["BaseNumber"].ToString())];

			}



			return YuklemeIsEmri;
		}

		static double RecursiveFun(double t, String[] dt, Boolean V2Durum, Boolean V3Durum, int V2Konum, int V3Konum, detay V2Detay, detay V3Detay, DataTable tumislergelen)
		{
			/*
			foreach (DataRow dr in tumislergelen.Rows)
			{
				Console.WriteLine("1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4} \t 6 : {5} \t 7 : {6} \t 8 : {7}\t 9 : {8} \t 10 : {9} \t 11 : {10}\t 12 : {11}\t 13(Maliyet) : {12}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12]);
			}
			*/
			//eger 30. zaman birimine gelindiyse sifir donmeli. bunu parametrik yapariz daha sonra, belki 30 yerine daha uzun sure bakilabilir.
			if (t >= 30) { return 0; } //üst limitimiz 30 ise böyle yapalım. double olduğu için böyle yapalım, double olduğu için tam 30 olmayabilir?

			//eger iki vinc'te calisiyorsa en kucuklerinin bitim zamanina gidilebilir.
			if (V2Durum && V3Durum)
			{
				return RecursiveFun(Math.Min(V2Detay.bitimzamani, V3Detay.bitimzamani), dt, V2Durum, V3Durum, V2Konum, V3Konum, V2Detay, V3Detay, tumislergelen);
			}


			int paramp = 3;
			double parameter1 = 2;
			double parameter2 = 1;
			double parameter3 = 0.5;
			double EkMaliyetV2;
			double EkMaliyetV3;
			double PenaltyV2;
			double PenaltyV3;

			double tnow = t;
			String[] islistesi = dt; // reference type - kopya yarattigina emin olmali
			String[] geciciisler = new String[islistesi.Length+1];
			Boolean V2Guncel = V2Durum;
			Boolean V3Guncel = V3Durum;
			int V2Gkom = V2Konum;
			int V3Gkom = V3Konum;
			detay V2Gdetay = V2Detay;
			detay V3Gdetay = V3Detay;
			DataTable tumisler = tumislergelen; //.Clone(); // reference type - kopya yarattigina emin olmali

			if (V2Guncel && V2Gdetay.bitimzamani == tnow)
			{
				V2Guncel = false;
				V2Gkom = V2Gdetay.bitimkonumu;
			}
			if (V3Guncel && V3Gdetay.bitimzamani == tnow)
			{
				V3Guncel = false;
				V3Gkom = V3Gdetay.bitimkonumu;
			}




	//
			double[] vinc2ileyaparsam = new double[tumisler.Rows.Count];
			double[] vinc3ileyaparsam = new double[tumisler.Rows.Count];
			double cakisma1;
			double cakisma2;
			double hicbirseyyapmazsam = RecursiveFun(tnow+1, islistesi, V2Guncel,V3Guncel,V2Gkom,V3Gkom,V2Gdetay,V3Gdetay,tumisler);

			//for (int p=0;p<paramp;p++)
			//Console.WriteLine("counter-----" + tumisler.DefaultView.Count);
			for (int i = 0; i < tumisler.Rows.Count; i++)
			{
				//eger is yapilmadiysa
				//eger onculeri yapildiysa
				//eger zamani gelindiyse
				//!!! HENUZ EKLENMEDI : Eger alternatifinin yoluna girilmediyse...
			//	Console.WriteLine(Convert.ToString(tumisler.Rows[i]["UniqueID"]));
			//	Console.WriteLine(!(islistesi.Contains(Convert.ToString(tumisler.Rows[i]["UniqueID"]))));
				if (!(islistesi.Contains(Convert.ToString(tumisler.Rows[i]["UniqueID"]))) && onculertamam(Convert.ToString(tumisler.Rows[i]["UniqueID"]), islistesi) && tnow>= Convert.ToInt32(tumisler.Rows[i]["IntZaman"]))//)
				{

					//String[] geciciisler = new String[islistesi.Length + 1];
					for (int k = 0; k < islistesi.Length; k++)
					{
						geciciisler[k] = islistesi[k];
					}
					geciciisler[islistesi.Length] = Convert.ToString(tumisler.Rows[i]["UniqueID"]);//islistesi.Length


					//ilk satidaki tum V2Gdetay'lar -> tumisler.Rows[i]'daki islerin detaylari olmali
					//ikinci satidaki tum V3Gdetay'lar -> tumisler.Rows[i]'daki islerin detaylari olmali
					//baska hic bir sey degismemeli
					V2Gdetay.baslangiczamani = tnow;
					V2Gdetay.bitimzamani = tnow + Convert.ToDouble(tumisler.Rows[i]["Is Süresi"]);
					V2Gdetay.bitimkonumu = Convert.ToInt32(tumisler.Rows[i]["Konum2 -Kolon"]);

					V3Gdetay.baslangiczamani = tnow;
					V3Gdetay.bitimzamani = tnow + Convert.ToDouble(tumisler.Rows[i]["Is Süresi"]);
					V3Gdetay.bitimkonumu = Convert.ToInt32(tumisler.Rows[i]["Konum2 -Kolon"]);




					vinc2ileyaparsam[i] = Convert.ToDouble(tumisler.Rows[i]["Maliyet"]) + parameter2 * cakisma(V2Gkom, V2Gdetay, V3Guncel, V3Gkom, V3Gdetay) + RecursiveFun(tnow, geciciisler, true, V3Guncel, V2Gkom, V3Gkom, V2Gdetay, V3Gdetay, tumisler);
					cakisma1 = cakisma(V2Gkom, V2Gdetay, V3Guncel, V3Gkom, V3Gdetay);

					vinc3ileyaparsam[i] = Convert.ToDouble(tumisler.Rows[i]["Maliyet"]) + parameter2 * cakisma(V3Gkom, V3Gdetay, V2Guncel, V2Gkom, V2Gdetay) + RecursiveFun(tnow, geciciisler, V2Guncel, true, V2Gkom, V3Gkom, V2Gdetay, V3Gdetay, tumisler);
					cakisma2 = cakisma(V3Gkom, V3Gdetay, V2Guncel, V2Gkom, V2Gdetay);
					Console.WriteLine("Vinç 2" + "- " + vinc2ileyaparsam[i]+ "-- - " +  cakisma1 + "  " + "Vinç 3" + "- " + vinc3ileyaparsam[i] + "--- " + cakisma2);
				}
			}
			  /*
				for(int i = 0; i < vinc2ileyaparsam.Length; i++)
			     {
				  Console.WriteLine("Vinç 2" + vinc2ileyaparsam[i] + cakisma1 + "  " + "Vinç 3" + vinc3ileyaparsam[i] + cakisma2);
			     }
              */
				//Her iş emri için vinçlerin hangisi olursa olsun başlangıç noktası ve bitiş noktaları tumisler.Row[i]["Konum1 -Kolon"] ----> tumisler.Row[i]["Konum2 -Kolon"] şeklinde belirlenebilir
				//çakışma sayısını da o iş emri vinç2 için yapılırsa yada vinç 3 ile yapılırsa  (tumisler.Row[i]["Konum1 -Kolon"] < V2GKom < tumisler.Row[i]["Konum2 -Kolon"]) bu şekilde arttırı
				//


				//tumisler.Rows[i]["Maliyet"]
				//iki vincle yapilirsa her is, ne kadar cakisma olacagini hesaplar misiniz burada Ali Bey?
				//vinc2ileyaparsam ve vinc3ileyaparsam icine cakisma miktarini parameter2 ile carpip tumisler.Rows[i]["Maliyet"] ekleyerek yazarsaniz yeterli.





			int aksiyon = 0; //aksiyon 0 hic bir sey yap, yoksa vinc #
			double minimumsayi = hicbirseyyapmazsam;
			//Console.WriteLine("enkucuksayi"+ minimumsayi);
			if (vinc2ileyaparsam.Min() > minimumsayi)
			{
				minimumsayi = vinc2ileyaparsam.Min();
				aksiyon = 2;
			}
			if (vinc3ileyaparsam.Min() > minimumsayi)
			{
				minimumsayi = vinc3ileyaparsam.Min();
				aksiyon = 3;
			}
			Console.WriteLine("en kucuk sayi"+ minimumsayi + "aksiyon"+aksiyon);
			// aksiyonlari kaydetmeliyiz bir yere...
			// t aninda en iyi aksiyon nedir (hangi vinc ile hangi isi yapmali)



			return minimumsayi;



		}



		private static bool onculertamam(String v, string[] islistesi)
		{

			bool sonuc = false;


			int prosira = Int32.Parse(v.Substring(6, 2));
			int proy = Int32.Parse(v.Substring(1, 3));
			if (prosira == 1)
			{
				sonuc = true;
			}
			else
			{
				for (int k = 0; k < islistesi.Length; k++)
				{

					int x, y;

					x = Int32.Parse(islistesi[k].Substring(6, 2));
					y = Int32.Parse(islistesi[k].Substring(1, 3));

					if (x == prosira - 1 && y==proy)
					{ sonuc = true; }


				}
			}



			//1005501025 direkt true
			//1005506025  eger 100550 ile baslayan id  5'lisi yapildiysa yani 1005505XXX yapildiysa.

			//eger v strıng'ı bızım ıd yapımıza gore parcalanıp ıs sırasına bakılacak
			// eger 1 ıse dırekt return true
			// 1degılse, bır oncesındekı yapıldıysa yanı ıs lıstesınde varsa return true, yoksa false



			return sonuc;
		}

		static double cakisma(int degerlendirilen_vincin_konumu, detay yapilacak_is_detaylari, Boolean diger_vinc_aktif_mi,int diger_vincin_konumu, detay diger_vinc_is_detaylari)
		{
			// (degerlendirilen_vincin_konumu < diger_vincin_konumu) && (yapilacak_is_detaylari.bitimkonumu < diger_vincin_konumu) ===> Penalty = 0;
			// (degerlendirilen_vincin_konumu > diger_vincin_konumu) && (yapilacak_is_detayları.bitimkonumu > diger_vincin_konumu) ===> Penalty = 0;
			double PenaltyVA = 0;
			if (((degerlendirilen_vincin_konumu < diger_vincin_konumu) && (yapilacak_is_detaylari.bitimkonumu < diger_vincin_konumu))||((degerlendirilen_vincin_konumu > diger_vincin_konumu) && (yapilacak_is_detaylari.bitimkonumu > diger_vincin_konumu)))
			{
				PenaltyVA = 0;
			}
			else
			{
				PenaltyVA = 1000;
			}
			//
			//
			return PenaltyVA;

			//sadece bu fonksiyon yazilacak ve iki vincin detaylarina gore cakisma skorunu dondurecek

			//tumisler.Row[i]["Konum1 -Kolon"] ----> tumisler.Row[i]["Konum2 -Kolon"]


			//double UzaklıkV2 = Math.Abs(degerlendirilen_vincin_konumu - V2Gkom);
			//double UzaklıkV3 = Math.Abs(Convert.ToInt32(tumisler.Rows[i]["Konum1 -Kolon"]) - V3Gkom);
			/*double PenaltyV2 = 0;
				double PenaltyV3 = 0;
			    if(diger_vincin_konumu <)

				if ((Convert.ToInt32(tumisler.Rows[i]["Konum1 -Kolon"]) < V3Gkom)&& (V3Gkom < Convert.ToInt32(tumisler.Rows[i]["Konum2 -Kolon"]))) { PenaltyV2 = 1000; }

				if ((Convert.ToInt32(tumisler.Rows[i]["Konum1 -Kolon"]) < V2Gkom) && (V2Gkom < Convert.ToInt32(tumisler.Rows[i]["Konum2 -Kolon"]))) { PenaltyV3 = 1000; }
				EkMaliyetV2 = (UzaklıkV2 + PenaltyV2);
				EkMaliyetV3 = (UzaklıkV3 + PenaltyV3);
				tumisler.Rows[i]["Maliyet"] = Convert.ToDouble(tumisler.Rows[i]["Maliyet"].ToString()) + Math.Min(EkMaliyetV2, EkMaliyetV3);
				Console.WriteLine(tumisler.Rows[i]["Maliyet"]);


				//simdilik sifir dondurerek bile mantikli bir siralama yapabilmeli...
				*/

		}

		internal class detay
		{
			public double baslangiczamani;
			public double bitimzamani;
			public int bitimkonumu;

		}
