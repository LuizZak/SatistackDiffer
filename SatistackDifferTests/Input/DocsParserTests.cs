using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Input;
using SatistackDiffer.Model;

namespace SatistackDifferTests.Input
{
    [TestClass]
    public class DocsParserTests
    {
        [TestMethod]
        public void TestParseDocument()
        {
            var json = TestUtils.JsonFromString(@"
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

            var result = DocsParser.Parse(json);

            Assert.That.SequenceEqual(
                result.ItemDescriptors,
                new []
                {
                    new ItemDescriptor
                    (
                        "Desc_NuclearWaste_C",
                        "Nuclear Waste",
                        StackSize.Huge,
                        "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'",
                        "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'"
                    ),
                    new ItemDescriptor
                    (
                        "Desc_Cement_C",
                        "Concrete",
                        StackSize.Medium,
                        "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_64.IconDesc_Concrete_64'",
                        "Texture2D'/Game/FactoryGame/Resource/Parts/Cement/UI/IconDesc_Concrete_256.IconDesc_Concrete_256'"
                    )
                });
        }
    }
}
