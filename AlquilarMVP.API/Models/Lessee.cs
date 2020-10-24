using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Lessee
    {
        //apellido": "Diaz",
        //        "nombre": "Juan",
        //        "DNI": 35492724,
        //        "sexo": "M",
        //        "telefono": 114543456,
        //        "cant_inquilinos": 2

        [JsonProperty("apellido")]
        public string LastName { get; set; }
        [JsonProperty("nombre")]

        public string Name { get; set; }
        [JsonProperty("DNI")]

        public string DocumentId { get; set; }
        [JsonProperty("sexo")]
        public string Sex { get; set; }
        [JsonProperty("telefono")]
        public string PhoneNumber { get; set; }
        [JsonProperty("cant_inquilinos")]
        public int NumberOfTenants { get; set; }
    }
}
