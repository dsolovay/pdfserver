using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfServer.Converter
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class ArgumentAttribute : Attribute
    {
        public string ArgName { get; set; }

        public ArgumentAttribute(string ArgName)
        {
            this.ArgName = ArgName;
        }
    }

    public sealed class Args
    {
        public bool isUrl { get; set; }
        public string url { get; set; }
        public string html { get; set; }
        public string outputname { get; set; }

        [Argument("--page-size")]
        public string pagesize { get; set; } = "letter";

        [Argument("-l")]
        public bool lowquality { get; set; } = false;

        [Argument("--title")]
        public string title { get; set; }

        [Argument("--margin-top")]
        public string margintop { get; set; }
        [Argument("--margin-right")]
        public string marginright { get; set; } = "10mm";
        [Argument("--margin-bottom")]
        public string marginbottom { get; set; }
        [Argument("--margin-left")]
        public string marginleft { get; set; } = "10mm";

        [Argument("--debug-javascript")]
        public bool jsdebug { get; set; } = false;
        [Argument("--javascript-delay")]
        public string jsdelay { get; set; } = "1000";

        private Args()
        {
            outputname = $"{Guid.NewGuid().ToString()}.pdf";
        }

        public Args(string html) : this()
        {
            if (html.StartsWith("http://") || html.StartsWith("https://"))
            {
                isUrl = true;
                url = html;
            }
            else
            {
                isUrl = false;
                this.html = html;
            }
        }

        public Args(Uri url) : this()
        {
            isUrl = true;
            this.url = url.ToString();
        }

        public string Gen()
        {
            var commandlineargs = GetType().GetProperties().Where(x => x.CustomAttributes.Any());
            var argbuilder = new List<string>();

            foreach (var a in commandlineargs)
            {
                var currentarg = (ArgumentAttribute)a.GetCustomAttributes(false).FirstOrDefault(x => x is ArgumentAttribute);

                if (a.PropertyType == typeof(bool))
                {
                    if ((bool)a.GetValue(this, null))
                    {
                        argbuilder.Add(currentarg.ArgName);
                    }
                }
                else if (a.PropertyType == typeof(string))
                {
                    var cur = (string)a.GetValue(this, null);

                    if (!string.IsNullOrEmpty(cur))
                    {
                        argbuilder.Add($"{currentarg.ArgName} {cur}");
                    }
                }
            }

            if (isUrl)
            {
                argbuilder.Add(url);
            }
            else
            {
                argbuilder.Add($"-");
            }

            argbuilder.Add(outputname);

            return string.Join(" ", argbuilder.ToArray());
        }
    }
}
