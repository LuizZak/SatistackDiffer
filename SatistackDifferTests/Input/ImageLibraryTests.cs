using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Input;

namespace SatistackDifferTests.Input
{
    [TestClass]
    public class ImageLibraryTests
    {
        [TestMethod]
        public void TestPopulateLibrary()
        {
            var imageLibrary = MakeSut();

            imageLibrary.PopulateLibrary();
        }

        [TestMethod]
        public void TestPathForImageFileContainingSubstring()
        {
            var imageLibrary = MakeSut();

            string result = imageLibrary.PathForImageFileContainingSubstring(Path.GetFileName(MockFilePath1));

            Assert.AreEqual(MockFilePath1, result);
        }

        [TestMethod]
        public void TestPathForImageFileContainingSubstring_ReturnsNullOnPathNotFound()
        {
            var imageLibrary = MakeSut();

            string result = imageLibrary.PathForImageFileContainingSubstring(MockFilePathNonExistent);

            Assert.IsNull(result);
        }

        private static ImageLibrary MakeSut()
        {
            return new ImageLibrary(MakeMockImageSource());
        }

        private static IImageLibrarySource MakeMockImageSource()
        {
            var source = new MockImageLibrarySource();

            source.MockFileList.Add(MockFilePath1);
            source.MockFileList.Add(MockFilePath2);

            return source;
        }

        private static readonly string MockFilePath1 = Path.Join("MockFolder", "Item1.png");
        private static readonly string MockFilePath2 = Path.Join("MockFolder", "MockSubFolder", "Item2.png");
        private static readonly string MockFilePathNonExistent = "NonExistentItem.png";

        private class MockImageLibrarySource: IImageLibrarySource
        {
            public readonly List<string> MockFileList = new List<string>();

            public List<string> ImageFiles()
            {
                return MockFileList;
            }
        }
    }
}
