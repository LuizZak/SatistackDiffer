using System.Collections.Generic;
using System.Linq;
using SatistackDiffer.Model;

namespace SatistackDiffer.Analysis
{
    public class DocsAnalyzer
    {
        public static AnalysisResult Analyze(DocsFile previousVersion, DocsFile currentVersion)
        {
            var changes = new List<AnalysisResult.ItemChange>();
            
            var itemPairs = 
                previousVersion
                    .ItemDescriptors
                    .Concat(currentVersion.ItemDescriptors)
                    .GroupBy(c => c.ClassName);

            foreach (var itemPair in itemPairs.Where(p => p.Count() == 2))
            {
                var oldItem = itemPair.ElementAt(0);
                var newItem = itemPair.ElementAt(1);

                if (oldItem.StackSize != newItem.StackSize)
                {
                    var change = new AnalysisResult.ItemChange(oldItem, newItem);

                    changes.Add(change);
                }
            }

            var result = new AnalysisResult(changes.ToArray());

            return result;
        }
    }

    public struct AnalysisResult
    {
        public ItemChange[] Changes;

        public AnalysisResult(ItemChange[] changes)
        {
            Changes = changes;
        }

        public struct ItemChange
        {
            public ItemDescriptor Old;
            public ItemDescriptor New;

            public ItemChange(ItemDescriptor old, ItemDescriptor @new)
            {
                Old = old;
                New = @new;
            }
        }
    }
}
