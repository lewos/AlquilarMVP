using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class ClaimResponse : ClaimCommon
    {
        [JsonProperty("fecha_creacion")]
        public string CreationDate { get; set; }

        [JsonProperty("fecha_modificacion")]
        public string ModifiedDate{ get; set; }
    }
}
