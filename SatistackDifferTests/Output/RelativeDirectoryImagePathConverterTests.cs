using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Output;

namespace SatistackDifferTests.Output
{
    [TestClass]
    public class RelativeDirectoryImagePathConverterTests
    {
        [TestMethod]
        public void TestPathForImageResource()
        {
            var sut = new RelativeDirectoryImagePathConverter();

            Assert.AreEqual(
                @"Game\FactoryGame\Resource\Parts\NuclearWaste\UI\IconDesc_NuclearWaste_64.png",
                sut.PathForImageResource("Texture2D'/Game/FactoryGame/Resource/Parts/NuclearWaste/UI/IconDesc_NuclearWaste_64.IconDesc_NuclearWaste_64")
            );
        }
    }
}
