using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Contract
    {
        [JsonProperty("locatario")]
        public Lessee Lessee { get; set; }
        [JsonProperty("locador")]
        public Locator Locator { get; set; }
        [JsonProperty("garante")]
        public Guarantor Guarantor { get; set; }
        [JsonProperty("condiciones")]
        public Terms Terms { get; set; }
    }
}
