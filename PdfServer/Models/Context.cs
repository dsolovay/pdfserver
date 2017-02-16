using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PdfServer.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<Template> Templates { get; set; }
    }
}