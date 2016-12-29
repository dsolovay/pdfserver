using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PdfServer.Controllers
{
    public class PdfBaseController : Controller
    {
        public string ToHtml(string view, ViewDataDictionary data)
        {
            var ctx = ControllerContext;
            var result = ViewEngines.Engines.FindView(ctx, view, null);

            using (var output = new StringWriter())
            {
                var vctx = new ViewContext(ctx, result.View, data, ctx.Controller.TempData, output);
                result.View.Render(vctx, output);
                result.ViewEngine.ReleaseView(ctx, result.View);

                return output.ToString();
            }
        }

        public ActionResult ToJson(object model) => Content(JsonConvert.SerializeObject(model), "application/json");
    }
}
