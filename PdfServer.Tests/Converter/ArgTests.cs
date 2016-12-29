using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfServer.Converter;

namespace PdfServer.Tests.Converter
{
    [TestClass]
    public class ArgTests
    {
        [TestMethod]
        public void CreateArgsWithUrlAsUri()
        {
            var args = new Args(new Uri("https://www.google.com/"));

            Assert.IsTrue(args.isUrl == true);
        }

        [TestMethod]
        public void CreateArgsWithUrlAsString()
        {
            var args = new Args("https://www.google.com/");

            Assert.IsTrue(args.isUrl == true);
        }

        [TestMethod]
        public void CreateArgsWithHtml()
        {
            var args = new Args("<html><head></head><body>hello</body></html>");

            Assert.IsTrue(args.isUrl == false);
        }
    }
}
