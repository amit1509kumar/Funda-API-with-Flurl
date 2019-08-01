using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TopAmsMakelaars.Models
{
    public class Makelaar
    {
        [JsonProperty("MakelaarId")]
        public int Id { get; set; }

        [JsonProperty("MakelaarNaam")]
        public string Name { get; set; }        
    }

    public class Root
    {
        [JsonProperty("Objects")]
        public List<Makelaar> Makelaars { get; set; }
    }
}
