using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Guarantor
    {

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


        [JsonProperty("domicilio")]
        public string Address { get; set; }
        [JsonProperty("cuiudad")]
        public string City { get; set; }
        [JsonProperty("provincia")]
        public string Province { get; set; }


            //        "garante": {
            //    "apellido": "Di Martino",
            //    "nombre": "Leonardo",
            //    "DNI": 35456758,
            //    "telefono": 113432344,
            //    "sexo": "M"
            //    "domicilio": "Bulnes 1655",
            //    "cuiudad": "CABA",
            //    "provincia": "Buenos Aires",
            //},
    }
}
