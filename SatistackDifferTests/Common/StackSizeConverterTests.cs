using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Common;
using SatistackDiffer.Model;

namespace SatistackDifferTests.Common
{
    [TestClass]
    public class StackSizeConverterTests
    {
        [TestMethod]
        public void TestStackSizeString()
        {
            Assert.AreEqual("1", StackSizeConverter.StackSizeString(StackSize.One));
            Assert.AreEqual("50", StackSizeConverter.StackSizeString(StackSize.Small));
            Assert.AreEqual("100", StackSizeConverter.StackSizeString(StackSize.Medium));
            Assert.AreEqual("200", StackSizeConverter.StackSizeString(StackSize.Big));
            Assert.AreEqual("500", StackSizeConverter.StackSizeString(StackSize.Huge));
            Assert.AreEqual("(fluid)", StackSizeConverter.StackSizeString(StackSize.Fluid));
        }
    }
}
