using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Locator
    {
        [JsonProperty("apellido")]
        public string LastName { get; set; }
        [JsonProperty("nombre")]

        public string Name { get; set; }
        [JsonProperty("DNI")]
        public string Sex { get; set; }
        [JsonProperty("telefono")]
        public string PhoneNumber { get; set; }
        [JsonProperty("domicilio")]
        public string Address { get; set; }
    }
}
