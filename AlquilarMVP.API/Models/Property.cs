﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class Property : PropertyCommon
    {       
        [JsonProperty("estado")]
        public StatusSpanish Status { get; set; }        
    }
}
