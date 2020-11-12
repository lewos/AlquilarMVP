using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class PropertyResponse :PropertyCommon
    {       
        [JsonProperty("estado")]
        public string Status { get; set; }        
    }
}
