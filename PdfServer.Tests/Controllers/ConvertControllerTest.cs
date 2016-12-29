using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfServer;
using PdfServer.Controllers;
using PdfServer.Models;
using Moq;
using System.Web;
using System.Web.Routing;

namespace PdfServer.Tests.Controllers
{
    [TestClass]
    public class ConvertControllerTest
    {
        [TestMethod]
        public void ConvertHtml()
        {
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            var routedata = new RouteData();
            routedata.Values.Add("controller", "convert");

            context.Setup(x => x.Request).Returns(request.Object);

            var controller = new ConvertController();
            controller.ControllerContext = new ControllerContext(context.Object, routedata, controller);

            var model = new TemplateViewModel
            {
                Template = "Hello",
                Title = "none",
                FileName = "htmltest.pdf"
            };

            var result = controller.Convert(model);

            Assert.IsTrue(System.IO.File.Exists(@"D:\pdfs\htmltest.pdf"));
        }

        [TestMethod]
        public void ConvertUrl()
        {
            var controller = new ConvertController();

            var result = controller.Convert("https://www.google.com", "googletest.pdf");

            Assert.IsTrue(System.IO.File.Exists(@"D:\pdfs\googletest.pdf"));
        }
    }
}
