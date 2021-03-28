using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SatistackDiffer.Model;

namespace SatistackDifferTests.Model
{
    [TestClass]
    public class ItemDescriptorTests
    {
        [TestMethod]
        public void TestDeserialize()
        {
            const string jsonString = @"
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
                }";

            var result = JsonConvert.DeserializeObject<ItemDescriptor>(jsonString);

            Assert.AreEqual(
                result,
                new ItemDescriptor(
                    "Desc_NuclearWaste_C",
                    "Nuclear Waste",
                    StackSize.Huge,
                    "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64'",
                    "Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_256.IconDesc_NuclearWaste_256'")
                );
        }
    }

    [TestClass]
    public class StackSizeTests
    {
        [TestMethod]
        public void TestDeserialize()
        {
            const string jsonString = @"
                [
                    ""SS_ONE"",
                    ""SS_SMALL"",
                    ""SS_MEDIUM"",
                    ""SS_BIG"",
                    ""SS_HUGE"",
                    ""SS_FLUID"",
                ]";

            var result = JsonConvert.DeserializeObject<StackSize[]>(jsonString);

            Assert.That.SequenceEqual(result, new StackSize[]
            {
                StackSize.One,
                StackSize.Small,
                StackSize.Medium,
                StackSize.Big,
                StackSize.Huge,
                StackSize.Fluid
            });
        }
    }
}
