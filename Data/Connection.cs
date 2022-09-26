using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clientsapi.Data
{
    public class Connection
    {
        public string ConnectionString { get; set; }

        static public string GetConnectionString()
        {
            return @"Data Source=LIMA\SQLEXPRESS;Initial Catalog=ClientsAPI;Integrated Security=True";
        }
    }
}