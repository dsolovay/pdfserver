using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PdfServer.Converter;
using PdfServer.Models;
using Newtonsoft.Json;
using System.Text;
using System.Dynamic;

namespace PdfServer.Controllers
{
    public class ConvertController : PdfBaseController
    {
        public ActionResult Display(string data)
        {
            var d = Encoding.UTF8.GetString(System.Convert.FromBase64String(data));
            var m = JsonConvert.DeserializeObject<TemplateViewModel>(d);

            return View($"~/Views/Templates/{m.Template}.cshtml", m);
        }

        public ActionResult Convert(TemplateViewModel m)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { error = "invalid request " });
            }

            var data = JsonConvert.DeserializeObject<ExpandoObject>(m.Data);

            ViewData.Model = data;

            var str = ToHtml($"~/Views/Templates/{m.Template}.cshtml", ViewData);

            var converter = new PdfConverter(@"D:\pdfs");
            var name = $"{Guid.NewGuid()}.pdf";

            var args = new Args(str)
            {
                title = m.Title,
                outputname = m.FileName
            };

            var result = converter.Convert(args);

            if (result.success)
            {
                var file = System.IO.File.ReadAllBytes(result.data);

                return File(file, "application/pdf", name);
            }
            else
            {
                return Content(result.error);
            }
        }

        public ActionResult ConvertTest()
        {
            var m = new TemplateViewModel
            {
                Template = "Hello",
                Title = "none",
                FileName = "htmltest.pdf"
            };

            ViewData.Model = m;

            var str = ToHtml($"~/Views/Templates/{m.Template}.cshtml", ViewData);

            var converter = new PdfConverter(@"D:\pdfs");
            var data = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(m)));

            var args = new Args($"{Request.Url.Scheme}://{Request.Url.Authority}/convert/display?data={data}")
            {
                title = m.Title,
                outputname = m.FileName
            };

            var result = converter.Convert(args);

            if (result.success)
            {
                var file = System.IO.File.ReadAllBytes(result.data);

                return File(file, "application/pdf", m.FileName);
            }
            else
            {
                return Content(result.error);
            }
        }

        //public ActionResult Convert(string url, string pdfname = null)
        //{
        //    var converter = new PdfConverter(@"D:\pdfs");
        //    var args = new Args(url)
        //    {
        //        outputname = pdfname
        //    };
        //    var result = converter.Convert(args);

        //    if (result.success)
        //    {
        //        var file = System.IO.File.ReadAllBytes(result.data);

        //        return File(file, "application/pdf", args.outputname);
        //    }
        //    else
        //    {
        //        return Content(result.error);
        //    }
        //}
    }
}