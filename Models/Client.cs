using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clientsapi.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Gender { get; set; }
        public int IdType { get; set; }
        public int IdSituation { get; set; }
    }
}