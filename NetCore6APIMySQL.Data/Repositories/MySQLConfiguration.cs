﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connectionString) 
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
    }
}
