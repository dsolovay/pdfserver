using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PdfServer.Models
{
    public class TemplateViewModel
    {
        public string Title { get; set; }
        public string Template { get; set; }
        public string FileName { get; set; }
        public string Data { get; set; }
    }
}