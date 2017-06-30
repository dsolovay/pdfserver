using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace PdfServer.Converter
{
    public class PdfConverter
    {
        private string wkloc { get; set; } = @"C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe";
        private string output { get; set; }
        private int timeout { get; set; } = 60000;

        public PdfConverter()
        {
            output = Environment.CurrentDirectory;

            var programfiles = Environment.GetEnvironmentVariable("ProgramFiles");

            if (Directory.Exists(programfiles))
            {
                var pfpath = Path.Combine(programfiles, "wkhtmltopdf", "bin", "wkhtmltopdf.exe");

                if (File.Exists(pfpath))
                {
                    wkloc = pfpath;
                }
            }
        }

        public PdfConverter(string outputlocation)
        {
            if (string.IsNullOrEmpty(outputlocation))
            {
                output = Environment.CurrentDirectory;
            }
            else
            {
                if (!Directory.Exists(outputlocation))
                {
                    Directory.CreateDirectory(outputlocation);
                }

                output = outputlocation;
            }
        }

        public PdfConverter(string outputlocation, string converterlocation)
        {
            output = outputlocation;
            wkloc = converterlocation;
        }

        public Result<string, string> Convert(Args args)
        {
            if (!File.Exists(wkloc))
            {
                return Result<string, string>.Error("Could not find wkhtmltopdf.exe");
            }

            if (!Directory.Exists(output))
            {
                return Result<string, string>.Error("Invalid output directory");
            }

            args.outputname = Path.Combine(output, args.outputname);

            try
            {
                var outStream = new StringBuilder();
                var error = new StringBuilder();

                using (var converter = new Process())
                {
                    converter.StartInfo = new ProcessStartInfo
                    {
                        FileName = wkloc,
                        Arguments = args.Gen(),
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                    };

                    using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                    using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                    {
                        DataReceivedEventHandler outputHandler = (sender, e) =>
                        {
                            if (e.Data == null)
                            {
                                outputWaitHandle.Set();
                            }
                            else
                            {
                                outStream.AppendLine(e.Data);
                            }
                        };

                        DataReceivedEventHandler errorHandler = (sender, e) =>
                        {
                            if (e.Data == null)
                            {
                                errorWaitHandle.Set();
                            }
                            else
                            {
                                error.AppendLine(e.Data);
                            }
                        };

                        converter.OutputDataReceived += outputHandler;
                        converter.ErrorDataReceived += errorHandler;

                        try
                        {
                            converter.Start();
                            converter.BeginErrorReadLine();
                            converter.BeginOutputReadLine();

                            if (!args.isUrl)
                            {
                                using (var stream = converter.StandardInput)
                                {
                                    var buffer = Encoding.UTF8.GetBytes(args.html);
                                    stream.BaseStream.Write(buffer, 0, buffer.Length);
                                    stream.WriteLine();
                                }
                            }

                            if (converter.WaitForExit(timeout) && outputWaitHandle.WaitOne(timeout) && errorWaitHandle.WaitOne(timeout))
                            {
                                if (converter.ExitCode != 0 && !File.Exists(args.outputname))
                                {
                                    return Result<string, string>.Error($"Failed to write pdf. Error: {error.ToString()}");
                                }
                            }
                            else
                            {
                                if (!converter.HasExited)
                                {
                                    converter.Kill();

                                    return Result<string, string>.Error("PDF generation timed out");
                                }
                            }
                        }
                        finally
                        {
                            converter.OutputDataReceived -= outputHandler;
                            converter.ErrorDataReceived -= errorHandler;
                        }
                    }
                }

                if (File.Exists(args.outputname))
                {
                    return Result<string, string>.Success(args.outputname);
                }
            }
            catch (Exception ex)
            {
                return Result<string, string>.Error($"Unknown error: {ex.Message}");
            }

            return Result<string, string>.Error("Could not find wkhtmltopdf.exe");
        }
    }
}
