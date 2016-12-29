using Newtonsoft.Json;
using PdfServer.Converter;
using PdfServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PdfServer.Controllers
{
    public class HomeController : PdfBaseController
    {
        // GET: Home
        public ActionResult Index() => View();

        public ActionResult Templates()
        {
            var files = System.IO.Directory.EnumerateFiles(Server.MapPath("~/Views/Templates")).Select(x => x.Substring(x.LastIndexOf(@"\") + 1));

            return ToJson(files);
        }
    }
}