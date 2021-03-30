using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Analysis;
using SatistackDiffer.Model;
using SatistackDiffer.Output;

namespace SatistackDifferTests.Output
{
    [TestClass]
    public class MarkdownAnalysisResultOutputCreatorTests
    {
        [TestMethod]
        public void TestBuildMarkdown_EmptyResult()
        {
            var sut = MakeSut(MakeEmptyResult());

            string result = sut.BuildMarkdown();

            Assert.AreEqual(@"
| Material | Old Stack | New Stack |
| - | - | - |
".Trim(), result);
        }

        [TestMethod]
        public void TestBuildMarkdown_OneItemList()
        {
            var sut = MakeSut(MakeOneResult());

            string result = sut.BuildMarkdown();

            Assert.AreEqual(@"
| Material | Old Stack | New Stack |
| - | - | - |
| ![text](Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.png) </br>Concrete | 100 | **500** |
".Trim(), result);
        }

        [TestMethod]
        public void TestBuildMarkdown_MultipleItemList()
        {
            var sut = MakeSut(MakeOneResult());

            string result = sut.BuildMarkdown();

            Assert.AreEqual(@"
| Material | Old Stack | New Stack |
| - | - | - |
| ![text](Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.png) </br>Concrete | 100 | **500** |
".Trim(), result);
        }

        [TestMethod]
        public void TestBuildMarkdown_ItemRename()
        {
            var sut = MakeSut(MakeRenameResult());

            string result = sut.BuildMarkdown();

            Assert.AreEqual(@"
| Material | Old Stack | New Stack |
| - | - | - |
| ![text](Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.png) </br>Uranium Waste </br>(was 'Nuclear Waste') | 100 | **500** |
".Trim(), result);
        }

        [TestMethod]
        public void TestCreateFileOutputs()
        {
            var sut = MakeSut(MakeEmptyResult(), @"Z:\test.md");

            var result = sut.CreateFileOutputs();

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(@"Z:\test.md", result[0].Path);
            Assert.AreEqual(@"
| Material | Old Stack | New Stack |
| - | - | - |
".Trim(), Encoding.UTF8.GetString(result[0].Contents));
        }

        #region

        private static MarkdownAnalysisResultOutputCreator MakeSut(AnalysisResult result, string path = @"ZZZ:\test.md")
        {
            return new MarkdownAnalysisResultOutputCreator(result, new RelativeDirectoryImagePathConverter(), path);
        }

        private static AnalysisResult MakeEmptyResult()
        {
            return new AnalysisResult(new AnalysisResult.ItemChange[0]);
        }

        private static AnalysisResult MakeOneResult()
        {
            return new AnalysisResult(
                new []
                {
                    new AnalysisResult.ItemChange(
                        new ItemDescriptor("Desc_Concrete_C", "Concrete", StackSize.Medium, "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.IconDesc_Concrete_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_256.IconDesc_Concrete_256'"),
                        new ItemDescriptor("Desc_Concrete_C", "Concrete", StackSize.Huge, "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.IconDesc_Concrete_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_256.IconDesc_Concrete_256'")
                    )
                }
            );
        }

        private static AnalysisResult MakeMultipleResults()
        {
            return new AnalysisResult(
                new[]
                {
                    new AnalysisResult.ItemChange(
                        new ItemDescriptor("Desc_NuclearWaste_C", "Nuclear Waste", StackSize.Medium, "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'"),
                        new ItemDescriptor("Desc_NuclearWaste_C", "Nuclear Waste", StackSize.Huge, "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'")
                    ),
                    new AnalysisResult.ItemChange(
                        new ItemDescriptor("Desc_Concrete_C", "Concrete", StackSize.Medium, "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.IconDesc_Concrete_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_256.IconDesc_Concrete_256'"),
                        new ItemDescriptor("Desc_Concrete_C", "Concrete", StackSize.Huge, "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.IconDesc_Concrete_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_256.IconDesc_Concrete_256'")
                    )
                }
            );
        }

        private static AnalysisResult MakeRenameResult()
        {
            return new AnalysisResult(
                new[]
                {
                    new AnalysisResult.ItemChange(
                        new ItemDescriptor("Desc_NuclearWaste_C", "Nuclear Waste", StackSize.Medium, "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'"),
                        new ItemDescriptor("Desc_NuclearWaste_C", "Uranium Waste", StackSize.Huge, "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'", "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'")
                    )
                }
            );
        }

        #endregion
    }
}
