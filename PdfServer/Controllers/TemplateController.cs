using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PdfServer.Models;

namespace PdfServer.Controllers
{
    public class TemplateController : Controller
    {
        private readonly Context ctx = new Context();

        // GET: Template
        public ActionResult GetTemplates()
        {
            return Json(ctx.Templates.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}