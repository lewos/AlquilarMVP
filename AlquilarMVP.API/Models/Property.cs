using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Property
    {
        [BsonId]
        [JsonProperty("prop_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Adress")]
        [JsonProperty("direccion")]
        public string Adress { get; set; }
        public string Province { get; set; }
        [JsonProperty("tipo")]
        public string UnitType { get; set; }
        [JsonProperty("operacion")]
        public string OperationType { get; set; }
        [JsonProperty("precio")]
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        [JsonProperty("expensas")]
        public double Expenses { get; set; }
        [JsonProperty("piso")]
        public int Floor { get; set; }
        [JsonProperty("depto")]
        public string Apartment { get; set; }
        [JsonProperty("sup_total")]
        public string TotalArea { get; set; }
        [JsonProperty("sup_cubierta")]
        public string CoveredArea { get; set; }
        [JsonProperty("ambientes")]
        public int Rooms { get; set; }
        [JsonProperty("baños")]
        public int BathRooms { get; set; }
        [JsonProperty("cocheras")]
        public int Garages { get; set; }
        [JsonProperty("dormitorios")]
        public int BedRooms { get; set; }
        // este dato se deberia calcular con la fecha de finalizacion de la construccion
        [JsonProperty("antiguedad")]
        public string Age { get; set; }
        [JsonProperty("estado_inmueble")]
        public string PropertyStatus { get; set; }
        [JsonProperty("estado")]
        public StatusSpanish Status { get; set; }
        [JsonProperty("descripcion")]
        public string Description { get; set; }
        [JsonProperty("miniatura")]
        public string ImagePath { get; set; }

        [JsonProperty("servicios")]
        public List<string> Services { get; set; }
        [JsonProperty("instalaciones")]
        public List<string> Installations { get; set; }

        [JsonProperty("contrato_vigente")]
        public bool CurrentContract { get; set; }
        [JsonProperty("contrato")]
        public Contract Contract { get; set; }
        
    }
}
