﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilarMVP.API.Models
{
    public class AlquilarDatabaseSettings : IAlquilarDatabaseSettings
    {
        public string PropertiesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAlquilarDatabaseSettings
    {
        string PropertiesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
