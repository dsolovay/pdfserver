using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PdfServer.Models
{
    public class Template
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tags { get; set; }
        public bool active { get; set; }
    }
}