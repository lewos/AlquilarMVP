﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Claim : ClaimCommon
    {        
        [BsonElement("CreationDate")]
        [JsonProperty("fecha_creacion")]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [JsonProperty("fecha_modificacion")]
        public DateTime ModifiedDate{ get; set; }       
    }
}
