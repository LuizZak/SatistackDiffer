using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Analysis;
using SatistackDiffer.Input;
using SatistackDiffer.Output;

namespace SatistackDifferTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void TestIntegration_Markdown()
        {
            var oldJson = TestUtils.JsonFromString(@"
                [
                    {
                        ""NativeClass"": ""Class'/Script/FactoryGame.FGItemDescriptor'"",
                        ""Classes"": [
                            {
                                ""ClassName"": ""Desc_NuclearWaste_C"",
                                ""mDisplayName"": ""Nuclear Waste"",
                                ""mDescription"": ""Nuclear Waste is the byproduct of nuclear power plants. You gotta find a way to handle all of this.\r\nEXTREMELY RADIOACTIVE"",
                                ""mAbbreviatedDisplayName"": """",
                                ""mStackSize"": ""SS_HUGE"",
                                ""mCanBeDiscarded"": ""False"",
                                ""mRememberPickUp"": ""False"",
                                ""mEnergyValue"": ""0.000000"",
                                ""mRadioactiveDecay"": ""20.000000"",
                                ""mForm"": ""RF_SOLID"",
                                ""mSmallIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'"",
                                ""mPersistentBigIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'"",
                                ""mFluidColor"": ""(B=0,G=0,R=0,A=0)"",
                                ""mResourceSinkPoints"": ""0""
                            },
                            {
                                ""ClassName"": ""Desc_Cement_C"",
                                ""mDisplayName"": ""Concrete"",
                                ""mDescription"": ""Used for building.\r\nGood for stable foundations."",
                                ""mAbbreviatedDisplayName"": """",
                                ""mStackSize"": ""SS_MEDIUM"",
                                ""mCanBeDiscarded"": ""True"",
                                ""mRememberPickUp"": ""False"",
                                ""mEnergyValue"": ""0.000000"",
                                ""mRadioactiveDecay"": ""0.000000"",
                                ""mForm"": ""RF_SOLID"",
                                ""mSmallIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.IconDesc_Concrete_64'"",
                                ""mPersistentBigIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_256.IconDesc_Concrete_256'"",
                                ""mFluidColor"": ""(B=0,G=0,R=0,A=0)"",
                                ""mResourceSinkPoints"": ""12""
                            }
                        ]
                    }
                ]");

            var newJson = TestUtils.JsonFromString(@"
                [
                    {
                        ""NativeClass"": ""Class'/Script/FactoryGame.FGItemDescriptor'"",
                        ""Classes"": [
                            {
                                ""ClassName"": ""Desc_NuclearWaste_C"",
                                ""mDisplayName"": ""Uranium Waste"",
                                ""mDescription"": ""Uranium Waste is the byproduct of nuclear power plants. You gotta find a way to handle all of this.\r\nEXTREMELY RADIOACTIVE"",
                                ""mAbbreviatedDisplayName"": """",
                                ""mStackSize"": ""SS_SMALL"",
                                ""mCanBeDiscarded"": ""False"",
                                ""mRememberPickUp"": ""False"",
                                ""mEnergyValue"": ""0.000000"",
                                ""mRadioactiveDecay"": ""20.000000"",
                                ""mForm"": ""RF_SOLID"",
                                ""mSmallIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'"",
                                ""mPersistentBigIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'"",
                                ""mFluidColor"": ""(B=0,G=0,R=0,A=0)"",
                                ""mResourceSinkPoints"": ""0""
                            },
                            {
                                ""ClassName"": ""Desc_Cement_C"",
                                ""mDisplayName"": ""Concrete"",
                                ""mDescription"": ""Used for building.\r\nGood for stable foundations."",
                                ""mAbbreviatedDisplayName"": """",
                                ""mStackSize"": ""SS_ONE"",
                                ""mCanBeDiscarded"": ""True"",
                                ""mRememberPickUp"": ""False"",
                                ""mEnergyValue"": ""0.000000"",
                                ""mRadioactiveDecay"": ""0.000000"",
                                ""mForm"": ""RF_SOLID"",
                                ""mSmallIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.IconDesc_Concrete_64'"",
                                ""mPersistentBigIcon"": ""Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_256.IconDesc_Concrete_256'"",
                                ""mFluidColor"": ""(B=0,G=0,R=0,A=0)"",
                                ""mResourceSinkPoints"": ""12""
                            }
                        ]
                    }
                ]");

            var oldDocs = DocsParser.Parse(oldJson);
            var newDocs = DocsParser.Parse(newJson);

            var result = DocsAnalyzer.Analyze(oldDocs, newDocs);

            var output = new MarkdownAnalysisResultOutputCreator(result, new RelativeDirectoryImagePathConverter(), @"ZZZ:\test.md");

            var markdown = output.CreateFileOutputs();

            Assert.AreEqual(1, markdown.Length);
            Assert.AreEqual(@"ZZZ:\test.md", markdown[0].Path);
            Assert.AreEqual(@"
| Material | Old Stack | New Stack |
| - | - | - |
| ![text](Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.png) </br>Uranium Waste </br>(was 'Nuclear Waste') | 500 | **50** |
| ![text](Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.png) </br>Concrete | 100 | **1** |
".Trim(), Encoding.UTF8.GetString(markdown[0].Contents));
        }
    }
}
