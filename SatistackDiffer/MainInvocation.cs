using System.IO;
using System.Threading.Tasks;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SatistackDiffer.Analysis;
using SatistackDiffer.Input;
using SatistackDiffer.Output;

namespace SatistackDiffer
{
    public class MainInvocation
    {
        [Option("old", Required = true, HelpText = "Path to old Docs.json")]
        public string OldPath { get; set; }

        [Option("new", Required = true, HelpText = "Path to new Docs.json")]
        public string NewPath { get; set; }

        [Option('o', "output", Required = true, HelpText = "File name to output to")]
        public string OutputPath { get; set; }

        public void Run()
        {
            var oldJsonStream = File.OpenRead(OldPath);
            var newJsonStream = File.OpenRead(NewPath);

            var output = RunAnalysis(oldJsonStream, newJsonStream);

            DiskOutputSaver.SaveFilesToDisk(output);
        }

        public AnalysisFileOutput[] RunAnalysis(Stream oldJsonStream, Stream newJsonStream)
        {
            using var oldJsonReader = new StreamReader(oldJsonStream);
            using var newJsonReader = new StreamReader(newJsonStream);
            
            // Load .json files
            var oldJson = JToken.LoadAsync(new JsonTextReader(oldJsonReader));
            var newJson = JToken.LoadAsync(new JsonTextReader(newJsonReader));
            
            Task.WaitAll(oldJson, newJson);

            var oldDocs = DocsParser.Parse(oldJson.Result);
            var newDocs = DocsParser.Parse(newJson.Result);

            var result = DocsAnalyzer.Analyze(oldDocs, newDocs);

            var markdownCreator = new MarkdownAnalysisResultOutputCreator(result, new RelativeDirectoryImagePathConverter(), OutputPath);

            return markdownCreator.CreateFileOutputs();
        }
    }
}