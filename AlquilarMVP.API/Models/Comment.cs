using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Comment
    {
        [BsonElement("Description")]
        [JsonProperty("descripcion")]
        public string Description { get; set; }
        
        [BsonElement("Date")]
        [JsonProperty("fecha")]
        public DateTime Date { get; set; }
        [BsonElement("CreatedBy")]
        [JsonProperty("creado_por")]
        public string CreatedBy { get; set; }
    }
}
