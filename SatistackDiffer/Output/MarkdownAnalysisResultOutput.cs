using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using SatistackDiffer.Analysis;
using SatistackDiffer.Common;

namespace SatistackDiffer.Output
{
    /// <summary>
    /// Produces a Markdown file as output of an analysis result
    /// </summary>
    public class MarkdownAnalysisResultOutput : IAnalysisResultOutput
    {
        private readonly AnalysisResult _analysis;
        private readonly IImagePathConverter _pathConverter;
        private readonly MarkdownIconSize _iconSize;

        public MarkdownAnalysisResultOutput(AnalysisResult analysis, IImagePathConverter pathConverter, MarkdownIconSize iconSize = MarkdownIconSize.Small_64x64)
        {
            _analysis = analysis;
            _pathConverter = pathConverter;
            _iconSize = iconSize;
        }

        public void Output(string path)
        {
            string output = BuildMarkdown();

            using var file = File.CreateText(path);
            file.Write(output);
            file.Flush();
        }

        internal string BuildMarkdown()
        {
            var output = new StringBuilder();

            output.AppendLine("| Material | Old Stack | New Stack |");
            output.AppendLine("| - | - | - |");

            foreach (var change in _analysis.Changes)
            {
                string displayNameBlock = change.New.DisplayName;

                if (change.Old.DisplayName != change.New.DisplayName)
                {
                    displayNameBlock += $" </br>(was '{change.Old.DisplayName}')";
                }

                string imagePath = _iconSize switch
                {
                    MarkdownIconSize.Small_64x64 => _pathConverter.PathForImageResource(change.Old.SmallIcon),
                    MarkdownIconSize.Large_256x256 => _pathConverter.PathForImageResource(change.Old.BigIcon),
                    _ => ""
                };

                output.AppendLine($"| ![text]({imagePath}) </br>{displayNameBlock} | {StackSizeConverter.StackSizeString(change.Old.StackSize)} | **{StackSizeConverter.StackSizeString(change.New.StackSize)}** |");
            }

            return output.ToString().Trim();
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum MarkdownIconSize
    {
        Small_64x64,
        Large_256x256
    }
}
