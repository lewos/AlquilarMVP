using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class User
    {

        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        [JsonProperty("userName")]
        public string Name { get; set; }
        [BsonElement("Pass")]
        [JsonProperty("userPass")]
        public string Pass { get; set; }
        [BsonElement("Mail")]
        [JsonProperty("userMail")]
        public string Mail { get; set; }
        [BsonElement("Rol")]
        [JsonProperty("userRol")]
        public string Rol { get; set; }
        //"id": 2,
        //"userName": "Inmobiliaria",
        //"userPass": "admin",
        //"userMail": "test2@gmail.com",
        //"userRol": "Inmobiliaria"
    }
}
