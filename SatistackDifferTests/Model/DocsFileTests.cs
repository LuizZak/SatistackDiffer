using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Model;

namespace SatistackDifferTests.Model
{
    [TestClass]
    public class DocsFileTests
    {
        [TestMethod]
        public void TestItemWithClassName()
        {
            // Arrange
            var docsFile = new DocsFile
            {
                ItemDescriptors = new [] {
                    new ItemDescriptor("I1", "Item 1", StackSize.One, "", ""),
                    new ItemDescriptor("I2", "Item 2", StackSize.One, "", "")
                }
            };

            Assert.AreEqual("Item 1", docsFile.ItemWithClassName("Item 1")?.DisplayName);
            Assert.AreEqual("Item 2", docsFile.ItemWithClassName("Item 2")?.DisplayName);
        }

        [TestMethod]
        public void TestItemWithClassName_ReturnsNullOnNotFound()
        {
            var docsFile = new DocsFile(new ItemDescriptor[0]);

            Assert.IsNull(docsFile.ItemWithClassName("Item"));
        }
    }
}
