using System.IO;
using CommandLine;
using Newtonsoft.Json.Linq;
using SatistackDiffer.Analysis;
using SatistackDiffer.Input;
using SatistackDiffer.Output;

namespace SatistackDiffer
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
            {
                var invocation = new Invocation(options.OldPath, options.NewPath, options.OutputPath);

                invocation.Run();
            });
        }
    }

    class Invocation
    {
        public string OldPath { get; }
        public string NewPath { get; }
        public string OutputPath { get; }

        public Invocation(string oldPath, string newPath, string outputPath)
        {
            OldPath = oldPath;
            NewPath = newPath;
            OutputPath = outputPath;
        }

        public void Run()
        {
            // Load .json files
            var oldJson = JToken.Parse(File.ReadAllText(OldPath));
            var newJson = JToken.Parse(File.ReadAllText(NewPath));

            var oldDocs = DocsParser.Parse(oldJson);
            var newDocs = DocsParser.Parse(newJson);

            var result = DocsAnalyzer.Analyze(oldDocs, newDocs);

            var output = new MarkdownAnalysisResultOutput(result, new RelativeDirectoryImagePathConverter());

            output.Output(OutputPath);
        }
    }

    public class Options
    {
        [Option("old", Required = true, HelpText = "Path to old Docs.json")]
        public string OldPath { get; set; }

        [Option("new", Required = true, HelpText = "Path to new Docs.json")]
        public string NewPath { get; set; }

        [Option('o', "output", Required = true, HelpText = "File name to output to")]
        public string OutputPath { get; set; }
    }
}
