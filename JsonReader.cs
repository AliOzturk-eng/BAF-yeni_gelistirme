using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tavlama
{
    public class JsonReader
    {
        public List<IsEmriObj> IsListe { get; set; }
        public List<Kolon> Kolonlar { get; set; }
        public List<SSure> StandartSure { get; set; }
        public List<SStatus> Status { get; set; }
        public List<KaideKolon> KaideKolonEslesmesi { get; set; }
        public List<AtacKanca> AtacmanKanca { get; set; }

        public JsonReader()
        {
            string Path = @"..\..\IsEmri.json";
            string data = File.ReadAllText(Path);
             IsListe = JsonConvert.DeserializeObject<List<IsEmriObj>>(data);

            Path = @"..\..\Kolon.json";
            data = File.ReadAllText(Path);
            Kolonlar = JsonConvert.DeserializeObject<List<Kolon>>(data);

            Path = @"..\..\StandartSureler.json";
            data = File.ReadAllText(Path);
            StandartSure = JsonConvert.DeserializeObject<List<SSure>>(data);

            Path = @"..\..\Status.json";
            data = File.ReadAllText(Path);
           Status = JsonConvert.DeserializeObject<List<SStatus>>(data);

            Path = @"..\..\KaideKolonEslesmesi.json";
            data = File.ReadAllText(Path);
             KaideKolonEslesmesi = JsonConvert.DeserializeObject<List<KaideKolon>>(data);

            Path = @"..\..\AtacmanKanca.json";
            data = File.ReadAllText(Path);
            AtacmanKanca = JsonConvert.DeserializeObject<List<AtacKanca>>(data);
        }


    }


    public class IsEmriObj
    {
        public string IsEmri { get; set; }
        public string AtmosphereType { get; set; }
        public string Baslangıcnok { get; set; }
        public string Bitisnok { get; set; }
        public string Ekipman { get; set; }
        public string Sure { get; set; }
        public string Atacmanturu { get; set; }
    }

    public class Kolon
    {
        public int Kolonno { get; set; }
        public string BaseNumber { get; set; }
        public int Ekipmantipi { get; set; }
        public string AtmosphereType { get; set; }
    }

    public class SSure
    {
        public string IsEmri { get; set; }
        public string AtmosphereType { get; set; }
        public string Baslangıcnok { get; set; }
        public string Bitisnok { get; set; }
        public string Ekipman { get; set; }
        public string Sure { get; set; }
        public string Atacmanturu { get; set; }
    }

    public class SStatus
    {
        public int Status { get; set; }
        public string Description { get; set; }
        public int IsIdled { get; set; }
    }

    public class KaideKolon
    {
        public int Kolonno { get; set; }
        public int BaseNumber { get; set; }
        public int Ekipmantipi { get; set; }
        public string AtmosphereType { get; set; }
    }

    public class AtacKanca
    {
        public string AtmosphereType { get; set; }
        public string Ekipman { get; set; }
        public string AtacmanTuru { get; set; }
        public string Kancaturu { get; set; }
    }

}
