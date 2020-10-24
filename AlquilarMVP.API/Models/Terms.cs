using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Terms
    {
        //"condiciones": {
        //      "inicio_contrato": "2020-10-01",
        //      "fin_contrato": "2022-09-30",
        //      "direccion_inmueble": "French 3031",
        //      "piso": 9,
        //      "depto": "A",
        //      "ciudad": "",
        //      "provincia": "",
        //      "precio_arg": 15000,
        //      "precio_usd": 400
        //  }


        [JsonProperty("inicio_contrato")]
        public string Start { get; set; }
        [JsonProperty("fin_contrato")]
        public string Ending { get; set; }

        [JsonProperty("direccion_inmueble")]
        public string Address { get; set; }

        [JsonProperty("piso")]
        public int Floor { get; set; }
        [JsonProperty("depto")]
        public string Department { get; set; }

        [JsonProperty("ciudad")]
        public string City { get; set; }
        [JsonProperty("provincia")]
        public string Province { get; set; }

        [JsonProperty("precio_arg")]
        public decimal PriceArg { get; set; }
        [JsonProperty("precio_usd")]
        public decimal PriceUsd { get; set; }
    }
}
