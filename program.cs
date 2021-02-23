using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;


using System.Runtime.Remoting.MetadataServices;
 
namespace Tavlama
{
    public class Program
    {
        public List<IsemriL> IsemriTable { get; set; }
		public static void writeLog(string log, string type)
		{
			string logPath = AppDomain.CurrentDomain.BaseDirectory + "Logs";
			Directory.CreateDirectory(logPath);
			StreamWriter sw = new StreamWriter(logPath + "\\Tavlama_" + DateTime.Now.ToString("yyyy_MM_dd") + "_Log.txt", true);
			sw.WriteLine("[" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "] [" + type + "]: " + log);
			sw.Flush();
			sw.Close();
		}
		public static void writeJson(string log, string type)
		{
			string logPath = AppDomain.CurrentDomain.BaseDirectory + "Logs";
			Directory.CreateDirectory(logPath);
			//FileStream stream = new FileStream(logPath + "\\Tavlama_" + DateTime.Now.ToString("yyyy_MM_dd HH:mm:ss") + "_Log.json",FileMode.CreateNew);
			StreamWriter sw = new StreamWriter(logPath + "\\Tavlama_" + DateTime.Now.ToString("yyyy_MM_dd-HH-mm-ss") +type + "_Log.json");
			sw.WriteLine(log);
			sw.Flush();
			sw.Close();
		}
		static void Main()
        {
			writeLog("Program Baþladý", "INF");
			DateTime t = DateTime.Now;
			bool readDB = true;
			String fileaddress = "Tavlama_2021_02_01-13-33-49IsEmr_Log.json";
			List<IsemriL> IsemriTableTZ = null;
			List<IsemriL> IsemriTableTN = null;
			List<IsemriL> WorkList = new List<IsemriL>();
			ProblemVerisi problem = null;
			if (readDB)
			{
				problem = new ProblemVerisi(false);
				writeLog("Problem verisi alýndý (Geçen Süre: " + DateTime.Now.Subtract(t).TotalSeconds + " sn)", "INF");

				Console.WriteLine(DateTime.Now.Subtract(t).TotalSeconds);
				t = DateTime.Now;
				ProblemVerisi problemFULL = new ProblemVerisi(true);
				writeLog("ProblemFULL verisi alýndý (Geçen Süre: " + DateTime.Now.Subtract(t).TotalSeconds + " sn)", "INF");
				Console.WriteLine(DateTime.Now.Subtract(t).TotalSeconds);


				List<IsemriL> isemrilistesi = problem.IsEmriYarat();//"CGL3", 4
																	//	LoadingEmir YüklemeProb = new LoadingEmir();
																	//double islemZamaniMS = DateTime.Now.Subtract(t).TotalMilliseconds;
																	//LoadingEmir YuklemeIsEmri = LoadingEmir(kaide, firin, gomlek, 82, "RCM", 4, 1, 26, SonucArray, SureTable);
				IsEmriObj Isjr = new IsEmriObj();
				Kolon Koll = new Kolon();
				SSure Surr = new SSure();
				SStatus Status = new SStatus();
				KaideKolon KaKol = new KaideKolon();
				AtacKanca ataka = new AtacKanca();

				// IsemriTable olus (
				List<IsemriL> IsemriTable = new List<IsemriL>();
				IsemriTableTZ = new List<IsemriL>();
				IsemriTableTN = new List<IsemriL>();
			//	List<IsemriL> IsemriTableTN = new List<IsemriL>();
				IsemriTable = problem.list;
				//   IsemriTable.AddRange(isemrilistesi);
				if (isemrilistesi.Count > 0)
				{
					Solution recursionLOAD = new Solution(isemrilistesi);
					recursionLOAD.Solve(out WorkList);
				}

				//	IsemriTableTZ = IsemriTable.OrderByDescending(o => o.Zaman).ThenByDescending(x => x.skor).ToList();

				//	IsemriTableTZ = IsemriTable.Where(o => o.Zaman.Year == 1900).ToList();

				
				IsemriTableTZ = IsemriTable.Where(o => o.Zaman.Year < 2000).ToList();
				IsemriTableTZ = IsemriTableTZ.OrderByDescending(o => o.skor).ToList();
				IsemriTableTN = IsemriTable.Where(o => o.Zaman.Year >= 2000).ToList();
				IsemriTableTZ.AddRange(IsemriTableTN);
				//	IsemriTableTZ = IsemriTable.Where(o => o.Zaman.ToString("dd.MM.yyyy HH:mm:ss") == "01.01.1900 00:00:00").ToList();
				// ses deneme bir ki
			//	isemrilistesi.AddRange(IsemriTableTZ);
			//	IsemriTableTZ = isemrilistesi;
				for (int i = 0; i < problem.ProcessBitimNumber; i++)
				{
					IsemriL IsemriO = new IsemriL();
					IsemriO.konumlar(problem.ProsesbitimListesi[i].BaseNumber.ToString(), problem.ProsesbitimListesi[i].BaseNumber.ToString());
					IsemriTable.Add(IsemriO);
				}
				Console.WriteLine("1 : UniqueID\t 2 :Zaman \t 3 : IntZaman \t 4 : AtmosphereTürü \t 5 : Konum1-Kolon\t 6 : Konum1 -Kaide \t 7 : Konum2 -Kolon \t 8 : Konum2 -Kaide \t  9 : Yapilacakis\t 10 : Skor");
				foreach (IsemriL dr in IsemriTableTZ)
				{
					Console.WriteLine("1 : {0}\t 2 : {1} \t 3 : {2} \t 4 : {3}\t 5 : {4}\t 6 : {5}\t 7 : {6}\t 8 : {7}\t 9 : {8}\t 10 : {9} ", dr.UniqueID, dr.Zaman, dr.IntZaman, dr.AtmosphereTuru, dr.Konum1Kolon, dr.Konum1Kaide, dr.Konum2Kolon, dr.Konum2Kaide, dr.Yapilacakis, dr.skor);
				}
				var json = JsonConvert.SerializeObject(IsemriTableTZ);
				writeJson(json, "IsEmr");
			}
			else
			{
				JsonRead jr = new JsonRead();
				IsemriTableTZ = jr.LoadJsonIsEmr(fileaddress);
			}
			
			if (IsemriTableTZ.Count > 0)
			{
				Solution recursion = new Solution(IsemriTableTZ);
				recursion.Solve(out WorkList);
			}
			Console.ReadLine();
		}
		
	}

   


}
