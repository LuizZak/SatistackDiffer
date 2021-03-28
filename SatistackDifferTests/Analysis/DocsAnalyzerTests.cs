using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Analysis;
using SatistackDiffer.Model;

namespace SatistackDifferTests.Analysis
{
    [TestClass]
    public class DocsAnalyzerTests
    {
        [TestMethod]
        public void TestAnalyze()
        {
            var previousVersion = new DocsFile(
                new []
                {
                    new ItemDescriptor("I1", "Item 1", StackSize.Small, "", ""),
                    new ItemDescriptor("I2", "Item 2", StackSize.Small, "", "")
                }
            );
            var currentVersion = new DocsFile(
                new []
                {
                    new ItemDescriptor("I1", "Item 1", StackSize.Small, "", ""),
                    new ItemDescriptor("I2", "Item 2", StackSize.Huge, "", "")
                }
            );

            var result = DocsAnalyzer.Analyze(previousVersion, currentVersion);

            Assert.That.SequenceEqual(
                new []
                {
                    new AnalysisResult.ItemChange(
                        previousVersion.ItemDescriptors[1],
                        currentVersion.ItemDescriptors[1]
                    )
                },
                result.Changes
            );
        }
    }
}
