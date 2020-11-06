using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Claim
    {
        [BsonId]
        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PropId")]
        [JsonProperty("prop_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PropId { get; set; }

        [BsonElement("Title")]
        [JsonProperty("titulo")]
        public string Title { get; set; }

        [BsonElement("Description")]
        [JsonProperty("descripcion")]
        public string Description { get; set; }

        [BsonElement("Date")]
        [JsonProperty("fecha")]
        public DateTime Date { get; set; }

        [BsonElement("State")]
        [JsonProperty("estado")]
        public string State { get; set; }

        [BsonElement("Comments")]
        [JsonProperty("comentarios")]
        public List<Comment> Comments { get; set; }
    }
}
