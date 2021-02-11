using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace Tavlama
{
    public class JsonRead
    {
        public List<IsemriL> LoadJsonIsEmr(string fileaddress)
        {
            List<IsemriL> items;
            using (StreamReader r = new StreamReader(fileaddress))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<IsemriL>>(json);
            }
            return items;
        }
    }
}